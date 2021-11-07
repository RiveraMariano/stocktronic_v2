using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class OrdenesModel
    {

        public List<OrdenInfoPagoJoin> ListarOrdenes()
        {
            using (var contexto = new STEntities())
            {
                var ordenes = (from x in contexto.PF_ORDEN
                              join y in contexto.PF_INFO_PAGO
                              on x.FK_ID_INFOPAGO equals y.ID_INFOPAGO
                              join z in contexto.PF_METODO_PAGO
                              on y.FK_ID_METODOPAGO equals z.ID_METODOPAGO
                              where x.FK_ID_USUARIO == 1
                              select new
                              {
                                  ID_ORDEN = x.ID_ORDEN,
                                  ORD_FEC_ORDEN = x.ORD_FEC_ORDEN,
                                  ORD_MONTO_TOTAL = x.ORD_MONTO_TOTAL,
                                  PAG_NUM_TARJETA = y.PAG_NUM_TARJETA,
                                  METP_NOMBRE = z.METP_NOMBRE,
                              }).ToList();

                List<OrdenInfoPagoJoin> listaOrdenes = new List<OrdenInfoPagoJoin>();
                foreach (var producto in ordenes)
                {
                    var innerJoin = new OrdenInfoPagoJoin();
                    innerJoin.ID_ORDEN = producto.ID_ORDEN;
                    innerJoin.ORD_FEC_ORDEN = producto.ORD_FEC_ORDEN;
                    innerJoin.ORD_MONTO_TOTAL = producto.ORD_MONTO_TOTAL;
                    innerJoin.PAG_NUM_TARJETA = producto.PAG_NUM_TARJETA;
                    innerJoin.METP_NOMBRE = producto.METP_NOMBRE;
                    listaOrdenes.Add(innerJoin);
                }
                return listaOrdenes;
            }
        }

    }
}