using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class CategoriasModel
    {
        public List<PF_CATEGORIA> ListarCategorias()
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_CATEGORIA
                        select x).ToList();
            }
        }
    }
}