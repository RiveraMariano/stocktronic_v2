using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class EntregasModel
    {
        public List<EntregasJoin> ListarEntregas()
        {
            using (var contexto = new STEntities())
            {
                var entregas = (from x in contexto.PF_H_ENTREGAS
                                join y in contexto.PF_PRODUCTO
                                on x.FK_ID_PRODUCTO equals y.ID_PRODUCTO
                                join z in contexto.PF_PROVEEDOR
                                on y.FK_ID_PROVEEDOR equals z.ID_PROVEEDOR
                                select new
                                {
                                    ID_ENTREGAS = x.ID_ENTREGAS,
                                    ENT_FEC_ENTREGA = x.ENT_FEC_ENTREGA,
                                    PRO_NOMBRE = y.PRO_NOMBRE,
                                    PROV_NOMBRE = z.PROV_NOMBRE,
                                }).ToList();

                List<EntregasJoin> listaEntregas = new List<EntregasJoin>();
                if (entregas.Count > 0)
                {
                    foreach (var entrega in entregas)
                    {
                        listaEntregas.Add(new EntregasJoin
                        {
                            ID_ENTREGAS = entrega.ID_ENTREGAS,
                            ENT_FEC_ENTREGA = entrega.ENT_FEC_ENTREGA,
                            PRO_NOMBRE = entrega.PRO_NOMBRE,
                            PROV_NOMBRE = entrega.PROV_NOMBRE,
                        });
                    }
                }
                return listaEntregas;
            }
        }

    }
}