using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class UsuariosJoin
    {
        public long ID_USUARIO { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_APELLIDO1 { get; set; }
        public string USR_APELLIDO2 { get; set; }
        public string USR_EMAIL { get; set; }
        public string ROL_TIPO { get; set; }
    }
}