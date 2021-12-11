using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class ProductosJoin
    {
        public long ID_PRODUCTO { get; set; }
        public string PRO_NOMBRE { get; set; }
        public string PRO_URL_IMAGEN { get; set; }
        public decimal PRECIO { get; set; }
        public long CANTIDAD { get; set; }
        public string CATEGORIA { get; set; }
    }
}