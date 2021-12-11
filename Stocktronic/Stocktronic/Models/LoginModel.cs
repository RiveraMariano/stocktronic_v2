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

        public string RegistrarUsuario(string nombre, string apellido1, string apellido2, string correo, string contrasenna)
        {
            using (var contexto = new STEntities())
            {
                PF_USUARIO usuario = new PF_USUARIO();
                usuario.USR_NOMBRE = nombre;
                usuario.USR_APELLIDO1 = apellido1;
                usuario.USR_APELLIDO2 = apellido2;
                usuario.USR_EMAIL = correo;
                usuario.USR_PASSWORD = contrasenna;
                usuario.FK_ID_ROL = 3;

                contexto.PF_USUARIO.Add(usuario);
                contexto.SaveChanges();
                return "Registro de usuario exitoso";
            }
        }

    }
}