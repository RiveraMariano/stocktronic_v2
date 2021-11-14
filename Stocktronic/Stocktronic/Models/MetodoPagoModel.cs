using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class MetodoPagoModel
    {

        public List<PF_METODO_PAGO> ListarMetodosPago()
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_METODO_PAGO
                        select x).ToList();
            }
        }

    }
}