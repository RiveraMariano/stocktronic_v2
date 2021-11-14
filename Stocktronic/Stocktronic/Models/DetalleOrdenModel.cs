using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class DetalleOrdenModel
    {

        public List<DetalleProductoJoin> ListarDetallesOrden(int idOrden)
        {
            using (var contexto = new STEntities())
            {
                var productosCarrito = (from x in contexto.PF_DETALLE_ORDEN
                                        join y in contexto.PF_PRODUCTO
                                        on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                                        where x.FK_ID_ORDEN == idOrden
                                        select new
                                        {
                                            ID_DETALLEORDEN = x.ID_DETALLEORDEN,
                                            DET_PRECIO = x.DET_PRECIO,
                                            DET_CANTIDAD = x.DET_CANTIDAD,
                                            DET_URL_IMAGEN = x.DET_URL_IMAGEN,
                                            PRO_NOMBRE = y.PRO_NOMBRE,
                                        }).ToList();

                List<DetalleProductoJoin> listaDetallesOrden = new List<DetalleProductoJoin>();
                if (productosCarrito.Count > 0)
                {
                    foreach (var producto in productosCarrito)
                    {
                        listaDetallesOrden.Add(new DetalleProductoJoin
                        {
                            ID_DETALLEORDEN = producto.ID_DETALLEORDEN,
                            DET_PRECIO = producto.DET_PRECIO,
                            DET_CANTIDAD = producto.DET_CANTIDAD,
                            DET_URL_IMAGEN = producto.DET_URL_IMAGEN,
                            PRO_NOMBRE = producto.PRO_NOMBRE
                        });
                    }
                }

                return listaDetallesOrden;
            }
        }

    }
}