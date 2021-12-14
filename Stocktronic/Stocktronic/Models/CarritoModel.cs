using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class CarritoModel
    {

        public List<CarritoJoin> ListarProductosAgregados(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                var carrito = (from x in contexto.PF_CARRITO
                               join y in contexto.PF_PRODUCTO
                               on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                               where x.FK_ID_USUARIO == idUsuario
                               select new
                               {
                                   ID_CARRITO = x.ID_CARRITO,
                                   CAR_CANTIDAD = x.CAR_CANTIDAD,
                                   PRO_NOMBRE = y.PRO_NOMBRE,
                                   PRO_DESCRIPCION = y.PRO_DESCRIPCION,
                                   PRO_PRECIO = y.PRO_PRECIO,
                                   PRO_URL_IMAGEN = y.PRO_URL_IMAGEN,
                               }).ToList();

                List<CarritoJoin> listaProductos = new List<CarritoJoin>();
                foreach (var producto in carrito)
                {
                    var innerJoin = new CarritoJoin();
                    innerJoin.ID_CARRITO = producto.ID_CARRITO;
                    innerJoin.CAR_CANTIDAD = producto.CAR_CANTIDAD;
                    innerJoin.PRO_NOMBRE = producto.PRO_NOMBRE;
                    innerJoin.PRO_DESCRIPCION = producto.PRO_DESCRIPCION;
                    innerJoin.PRO_PRECIO = producto.PRO_PRECIO;
                    innerJoin.PRO_URL_IMAGEN = producto.PRO_URL_IMAGEN;
                    listaProductos.Add(innerJoin);
                }
                return listaProductos;
            }
        }

        public Boolean ReducirCantidad(int idCarrito)
        {
            using (var contexto = new STEntities())
            {
                var producto = (from x in contexto.PF_CARRITO
                                where x.ID_CARRITO == idCarrito
                                select x).FirstOrDefault();

                producto.CAR_CANTIDAD = producto.CAR_CANTIDAD - 1;
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean AumentarCantidad(int idCarrito)
        {
            using (var contexto = new STEntities())
            {
                var producto = (from x in contexto.PF_CARRITO
                                where x.ID_CARRITO == idCarrito
                                select x).FirstOrDefault();

                producto.CAR_CANTIDAD = producto.CAR_CANTIDAD + 1;
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean EliminarProducto(int idCarrito)
        {
            using (var contexto = new STEntities())
            {
                var producto = (from x in contexto.PF_CARRITO
                                where x.ID_CARRITO == idCarrito
                                select x).FirstOrDefault();

                contexto.PF_CARRITO.Remove(producto);
                contexto.SaveChanges();
                return true;
            }
        }

        public long CantidadCarrito(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                var carrito = (from x in contexto.PF_CARRITO
                               join y in contexto.PF_PRODUCTO
                               on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                               where x.FK_ID_USUARIO == idUsuario
                               select new
                               {
                                   ID_CARRITO = x.ID_CARRITO,
                                   CAR_CANTIDAD = x.CAR_CANTIDAD,
                                   PRO_NOMBRE = y.PRO_NOMBRE,
                                   PRO_DESCRIPCION = y.PRO_DESCRIPCION,
                                   PRO_PRECIO = y.PRO_PRECIO,
                                   PRO_URL_IMAGEN = y.PRO_URL_IMAGEN,
                               }).ToList();

                List<CarritoJoin> listaProductos = new List<CarritoJoin>();
                foreach (var producto in carrito)
                {
                    var innerJoin = new CarritoJoin();
                    innerJoin.ID_CARRITO = producto.ID_CARRITO;
                    innerJoin.CAR_CANTIDAD = producto.CAR_CANTIDAD;
                    innerJoin.PRO_NOMBRE = producto.PRO_NOMBRE;
                    innerJoin.PRO_DESCRIPCION = producto.PRO_DESCRIPCION;
                    innerJoin.PRO_PRECIO = producto.PRO_PRECIO;
                    innerJoin.PRO_URL_IMAGEN = producto.PRO_URL_IMAGEN;
                    listaProductos.Add(innerJoin);
                }

                var totalCarrito = listaProductos.Sum(x => x.CAR_CANTIDAD);

                return totalCarrito;
            }
        }

    }
}