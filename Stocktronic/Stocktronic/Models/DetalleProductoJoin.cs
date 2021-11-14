using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class DetalleProductoJoin
    {
        public long ID_DETALLEORDEN { get; set; }
        public decimal DET_PRECIO { get; set; }
        public long DET_CANTIDAD { get; set; }
        public string DET_URL_IMAGEN { get; set; }
        public string PRO_NOMBRE { get; set; }
    }
}