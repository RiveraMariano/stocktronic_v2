using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class RolesModel
    {

        public List<PF_ROL> ListarRoles()
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_ROL
                        select x).ToList();
            }
        }

    }
}