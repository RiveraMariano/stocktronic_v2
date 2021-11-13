using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class LoginModel
    {

        public PF_USUARIO IniciarSesion(string correo, string contrasenna)
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_USUARIO
                        where x.USR_EMAIL == correo &&
                        x.USR_PASSWORD == contrasenna
                        select x).FirstOrDefault();
            }
        }

    }
}