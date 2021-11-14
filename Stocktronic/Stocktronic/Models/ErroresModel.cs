using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ErroresModel
    {

        public List<ErroresJoin> ListarErrores()
        {
            using (var contexto = new STEntities())
            {
                var errores = (from x in contexto.PF_H_ERRORES
                                join y in contexto.PF_USUARIO
                                on x.FK_ID_USUARIO equals y.ID_USUARIO
                                select new
                                {
                                    ID_ERRORES = x.ID_ERRORES,
                                    ERR_FEC = x.ERR_FEC,
                                    ERR_DESCRIPCION = x.ERR_DESCRIPCION,
                                    USR_NOMBRE = y.USR_NOMBRE,
                                }).ToList();

                List<ErroresJoin> listaErrores = new List<ErroresJoin>();
                if (errores.Count > 0)
                {
                    foreach (var error in errores)
                    {
                        listaErrores.Add(new ErroresJoin
                        {
                            ID_ERRORES = error.ID_ERRORES,
                            ERR_FEC = error.ERR_FEC,
                            ERR_DESCRIPCION = error.ERR_DESCRIPCION,
                            USR_NOMBRE = error.USR_NOMBRE,
                        });
                    }
                }
                return listaErrores;
            }
        }

    }
}