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

    }
}