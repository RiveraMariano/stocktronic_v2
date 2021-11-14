using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ErroresJoin
    {
        public long ID_ERRORES { get; set; }
        public DateTime ERR_FEC { get; set; }
        public string ERR_DESCRIPCION { get; set; }
        public string USR_NOMBRE { get; set; }
    }
}