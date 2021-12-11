using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class EntregasJoin
    {
        public long ID_ENTREGAS { get; set; }
        public System.DateTime ENT_FEC_ENTREGA { get; set; }
        public string PRO_NOMBRE { get; set; }
        public string PROV_NOMBRE { get; set; }

    }
}