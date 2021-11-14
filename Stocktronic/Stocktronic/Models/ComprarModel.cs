using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ComprarModel
    {

        public Boolean InsertarInfoPago(string numTarjeta, string dirFact1, string dirFact2, string telefono, decimal total, int idUsuario, int idMetodoPago)
        {
            using (var contexto = new STEntities())
            {
                PF_INFO_PAGO infoPago = new PF_INFO_PAGO();
                infoPago.PAG_NUM_TARJETA = numTarjeta;
                infoPago.PAG_DIR_FACTURACION = dirFact1;
                infoPago.PAG_DIR_FACTURACION2 = dirFact2;
                infoPago.PAG_TELEFONO = telefono;
                infoPago.PAG_TOTAL = total;
                infoPago.FK_ID_USUARIO = idUsuario;
                infoPago.FK_ID_METODOPAGO = idMetodoPago;

                contexto.PF_INFO_PAGO.Add(infoPago);
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean InsertarOrden(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                var infoPago = (from x in contexto.PF_INFO_PAGO
                                where x.FK_ID_USUARIO == idUsuario
                                select x).LastOrDefault();

                PF_ORDEN orden = new PF_ORDEN();
                orden.ORD_FEC_ORDEN = DateTime.Now;
                orden.ORD_MONTO_TOTAL = infoPago.PAG_TOTAL * 2; // Cambiar a 1.13 IVA
                orden.FK_ID_INFOPAGO = infoPago.ID_INFOPAGO;
                orden.FK_ID_USUARIO = idUsuario;

                contexto.PF_ORDEN.Add(orden);
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean InsertarDetalleOrden(int idUsuario)
        {
            using (var contexto = new STEntities())
            {

                // Obtener ID de la última orden
                var orden = (from x in contexto.PF_ORDEN
                             where x.FK_ID_USUARIO == idUsuario
                             select x).LastOrDefault();

                // Obtener info de todos los artículos del carrito de compras
                var productosCarrito = (from x in contexto.PF_CARRITO
                                        join y in contexto.PF_PRODUCTO
                                        on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                                        where x.FK_ID_USUARIO == idUsuario
                                        select new
                                        {
                                            CAR_CANTIDAD = x.CAR_CANTIDAD,
                                            ID_PRODUCTO = y.ID_PRODUCTO,
                                            PRO_PRECIO = y.PRO_PRECIO,
                                            PRO_URL_IMAGEN = y.PRO_URL_IMAGEN,
                                        }).ToList();

                // Crear lista para insertar la info de inner join
                List<CarritoProductoJoin> listaProductosCarrito = new List<CarritoProductoJoin>();
                if (productosCarrito.Count > 0)
                {
                    foreach (var producto in productosCarrito)
                    {
                        listaProductosCarrito.Add(new CarritoProductoJoin
                        {
                            ID_PRODUCTO = producto.ID_PRODUCTO,
                            PRO_PRECIO = producto.PRO_PRECIO,
                            CAR_CANTIDAD = producto.CAR_CANTIDAD,
                            PRO_URL_IMAGEN = producto.PRO_URL_IMAGEN
                        });
                    }
                }

                // Crear lista para insetar los detalles de la orden
                List<PF_DETALLE_ORDEN> listaDetallesOrden = new List<PF_DETALLE_ORDEN>();
                if (listaProductosCarrito.Count > 0)
                {
                    foreach (var producto in listaProductosCarrito)
                    {
                        listaDetallesOrden.Add(new PF_DETALLE_ORDEN
                        {
                            FK_ID_PRODUCTO = producto.ID_PRODUCTO,
                            DET_PRECIO = producto.PRO_PRECIO,
                            DET_CANTIDAD = producto.CAR_CANTIDAD,
                            DET_URL_IMAGEN = producto.PRO_URL_IMAGEN,
                            FK_ID_ORDEN = orden.ID_ORDEN,
                            FK_ID_USUARIO = idUsuario,
                        });
                    }
                }

                // Insertar los detalles de la orden
                foreach (var detalle in listaDetallesOrden)
                {
                    contexto.PF_DETALLE_ORDEN.Add(detalle);
                    contexto.SaveChanges();
                }
                return true;
            }
        }

    }
}