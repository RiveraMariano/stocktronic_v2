using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ProveedoresModel
    {
        public List<PF_PROVEEDOR> ListarProveedores()
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_PROVEEDOR
                        select x).ToList();
            }
        }
    }
}