using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class UsuariosModel
    {

        public List<UsuariosJoin> ListarUsuarios()
        {
            using (var contexto = new STEntities())
            {
                var usuarios = (from x in contexto.PF_USUARIO
                                join y in contexto.PF_ROL
                                on x.FK_ID_ROL equals y.ID_ROL
                                select new
                                {
                                    ID_USUARIO = x.ID_USUARIO,
                                    USR_NOMBRE = x.USR_NOMBRE,
                                    USR_APELLIDO1 = x.USR_APELLIDO1,
                                    USR_APELLIDO2 = x.USR_APELLIDO2,
                                    USR_EMAIL = x.USR_EMAIL,
                                    ROL_TIPO = y.ROL_TIPO,
                                }).ToList();

                List<UsuariosJoin> listaUsuarios = new List<UsuariosJoin>();
                if (usuarios.Count > 0)
                {
                    foreach (var usuario in usuarios)
                    {
                        listaUsuarios.Add(new UsuariosJoin
                        {
                            ID_USUARIO = usuario.ID_USUARIO,
                            USR_NOMBRE = usuario.USR_NOMBRE,
                            USR_APELLIDO1 = usuario.USR_APELLIDO1,
                            USR_APELLIDO2 = usuario.USR_APELLIDO2,
                            USR_EMAIL = usuario.USR_EMAIL,
                            ROL_TIPO = usuario.ROL_TIPO,
                        });
                    }
                }
                return listaUsuarios;
            }
        }

        public PF_USUARIO ListarUsuario(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_USUARIO
                        where x.ID_USUARIO == idUsuario
                        select x).FirstOrDefault();

            }
        }

    }
}