using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class CatalogoModel
    {

        public List<PF_PRODUCTO> ListarProductos(int id)
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_PRODUCTO
                        where x.FK_ID_CATEGORIA == id
                        select x).ToList();
            }
        }

        public List<PF_PRODUCTO> ListarProductosAleatorios()
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_PRODUCTO
                        orderby Guid.NewGuid()
                        select x).Take(6).ToList();
            }
        }

        public string InsertarProducto(int idProducto, int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                PF_CARRITO carrito = new PF_CARRITO();
                carrito.CAR_CANTIDAD = 1;
                carrito.FK_ID_USUARIO = idUsuario;
                carrito.FK_ID_PRODUCTO = idProducto;
                contexto.PF_CARRITO.Add(carrito);
                contexto.SaveChanges();
                return "Registro de dispositivo exitoso";
            }
        }

    }
}