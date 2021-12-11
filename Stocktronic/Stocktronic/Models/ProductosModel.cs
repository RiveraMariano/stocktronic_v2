using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ProductosModel
    {
        public List<ProductosJoin> ListarProductos()
        {
            using (var contexto = new STEntities())
            {
                var productos = (from x in contexto.PF_PRODUCTO
                                 join y in contexto.PF_CATEGORIA
                                 on x.FK_ID_CATEGORIA equals y.ID_CATEGORIA
                                 select new
                                {
                                    ID_PRODUCTO = x.ID_PRODUCTO,
                                    NOMBRE = x.PRO_NOMBRE,
                                    IMAGEN = x.PRO_URL_IMAGEN,
                                    PRECIO = x.PRO_PRECIO,
                                    CANTIDAD = x.PRO_CANTIDAD,
                                    CATEGORIA = y.CAT_TIPO,
                                }).ToList();

                List<ProductosJoin> listaProductos = new List<ProductosJoin>();
                if (productos.Count > 0)
                {
                    foreach (var producto in productos)
                    {
                        listaProductos.Add(new ProductosJoin
                        {
                            ID_PRODUCTO = producto.ID_PRODUCTO,
                            PRO_NOMBRE = producto.NOMBRE,
                            PRO_URL_IMAGEN = producto.IMAGEN,
                            PRECIO = producto.PRECIO,
                            CANTIDAD = producto.CANTIDAD,
                            CATEGORIA = producto.CATEGORIA,
                        });
                    }
                }
                return listaProductos;
            }
        }

        public PF_PRODUCTO ListarProducto(int idProducto)
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_PRODUCTO
                        where x.ID_PRODUCTO == idProducto
                        select x).FirstOrDefault();

            }
        }

        public Boolean InsertarProducto(string nombre, string descripcion, string imagen, decimal precio, int cantidad, int idProveedor, int idCategoria)
        {
            using (var contexto = new STEntities())
            {
                PF_PRODUCTO producto = new PF_PRODUCTO();
                producto.PRO_NOMBRE = nombre;
                producto.PRO_DESCRIPCION = descripcion;
                producto.PRO_URL_IMAGEN = imagen;
                producto.PRO_PRECIO = precio;
                producto.PRO_CANTIDAD = cantidad;
                producto.FK_ID_PROVEEDOR = idProveedor;
                producto.FK_ID_CATEGORIA = idCategoria;

                contexto.PF_PRODUCTO.Add(producto);
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean ActualizarProducto(int idProducto, string nombre, string descripcion, string imagen, decimal precio, int cantidad, int idProveedor, int idCategoria)
        {
            using (var contexto = new STEntities())
            {
                var producto = (from x in contexto.PF_PRODUCTO
                               where x.ID_PRODUCTO == idProducto
                                select x).FirstOrDefault();

                if (producto != null)
                {
                    producto.PRO_NOMBRE = nombre;
                    producto.PRO_DESCRIPCION = descripcion;
                    producto.PRO_URL_IMAGEN = imagen;
                    producto.PRO_PRECIO = precio;
                    producto.PRO_CANTIDAD = cantidad;
                    producto.FK_ID_PROVEEDOR = idProveedor;
                    producto.FK_ID_CATEGORIA = idCategoria;
                    contexto.SaveChanges();
                    return true;
                } else 
                {
                    return false;
                }


            }
        }

        public Boolean EliminarProducto(int idProducto)
        {
            using (var contexto = new STEntities())
            {
                var listaproducto = (from x in contexto.PF_PRODUCTO
                                     where x.ID_PRODUCTO == idProducto
                                     select x).FirstOrDefault();

                var listacarrito = (from x in contexto.PF_CARRITO
                                    where x.FK_ID_PRODUCTO == idProducto
                                    select x).FirstOrDefault();

                var listaorden = (from x in contexto.PF_DETALLE_ORDEN
                                  where x.FK_ID_PRODUCTO == idProducto
                                  select x).FirstOrDefault();

                var listaentregas = (from x in contexto.PF_H_ENTREGAS
                                     where x.FK_ID_PRODUCTO == idProducto
                                     select x).FirstOrDefault();

                //Elimina el producto si no hay ordenes, pedidos en el carrito o entregas con ese ID
                if (listacarrito == null && listaorden == null)
                {
                    contexto.PF_H_ENTREGAS.Remove(listaentregas);
                    contexto.PF_PRODUCTO.Remove(listaproducto);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }


    }
}