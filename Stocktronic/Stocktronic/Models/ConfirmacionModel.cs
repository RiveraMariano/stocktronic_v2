using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ConfirmacionModel
    {

        public ConfirmacionJoin ConfirmacionPago(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                var confirmacion = (from x in contexto.PF_ORDEN
                                    join y in contexto.PF_INFO_PAGO
                                    on x.FK_ID_INFOPAGO equals y.ID_INFOPAGO
                                    join z in contexto.PF_METODO_PAGO
                                    on y.FK_ID_METODOPAGO equals z.ID_METODOPAGO
                                    where x.FK_ID_USUARIO == idUsuario
                                    select new
                                    {
                                        ID_ORDEN = x.ID_ORDEN,
                                        ORD_FEC_ORDEN = x.ORD_FEC_ORDEN,
                                        ORD_MONTO_TOTAL = x.ORD_MONTO_TOTAL,
                                        PAG_NUM_TARJETA = y.PAG_NUM_TARJETA,
                                        PAG_DIR_FACTURACION = y.PAG_DIR_FACTURACION,
                                        PAG_DIR_FACTURACION2 = y.PAG_DIR_FACTURACION2,
                                        METP_NOMBRE = z.METP_NOMBRE,
                                    }).LastOrDefault();


                var innerJoin = new ConfirmacionJoin();
                innerJoin.ID_ORDEN = confirmacion.ID_ORDEN;
                innerJoin.ORD_FEC_ORDEN = confirmacion.ORD_FEC_ORDEN;
                innerJoin.ORD_MONTO_TOTAL = confirmacion.ORD_MONTO_TOTAL;
                innerJoin.PAG_NUM_TARJETA = confirmacion.PAG_NUM_TARJETA;
                innerJoin.PAG_DIR_FACTURACION = confirmacion.PAG_DIR_FACTURACION;
                innerJoin.PAG_DIR_FACTURACION2 = confirmacion.PAG_DIR_FACTURACION2;
                innerJoin.METP_NOMBRE = confirmacion.METP_NOMBRE;
                return innerJoin;
            }
        }

    }
}