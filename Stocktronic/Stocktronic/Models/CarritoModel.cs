using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class CarritoModel
    {

        public List<CarritoProductoJoin> ListarProductosAgregados()
        {
            using (var contexto = new STEntities())
            {
                var carrito = (from x in contexto.PF_CARRITO
                               join y in contexto.PF_PRODUCTO 
                               on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                               where x.FK_ID_USUARIO == 1
                               select new 
                               {
                                   ID_CARRITO = x.ID_CARRITO,
                                   CAR_CANTIDAD = x.CAR_CANTIDAD,
                                   PRO_NOMBRE = y.PRO_NOMBRE, 
                                   PRO_DESCRIPCION = y.PRO_DESCRIPCION, 
                                   PRO_PRECIO = y.PRO_PRECIO,
                                   PRO_URL_IMAGEN = y.PRO_URL_IMAGEN,
                               }).ToList();

                List<CarritoProductoJoin> listaProductos = new List<CarritoProductoJoin>();
                foreach (var producto in carrito)
                {
                    var innerJoin = new CarritoProductoJoin();
                    innerJoin.ID_CARRITO = producto.ID_CARRITO;
                    innerJoin.CAR_CANTIDAD = producto.CAR_CANTIDAD;
                    innerJoin.PRO_NOMBRE = producto.PRO_NOMBRE;
                    innerJoin.PRO_DESCRIPCION = producto.PRO_DESCRIPCION;
                    innerJoin.PRO_URL_IMAGEN = producto.PRO_URL_IMAGEN;
                    listaProductos.Add(innerJoin);
                }
                return listaProductos;
            }
        }

    }
}