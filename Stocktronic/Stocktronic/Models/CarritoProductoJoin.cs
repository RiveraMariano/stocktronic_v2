using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class CarritoProductoJoin
    {
        public long ID_CARRITO { get; set; }
        public long CAR_CANTIDAD { get; set; }
        public string PRO_NOMBRE { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string PRO_DESCRIPCION { get; set; }
        public decimal PRO_PRECIO { get; set; }
        public string PRO_URL_IMAGEN { get; set; }
    }
}