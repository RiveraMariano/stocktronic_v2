using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class CatalogoController : Controller
    {

        public ActionResult Index(int id)
        {
            try
            {
                CatalogoModel catalogo = new CatalogoModel();
                var productos = catalogo.ListarProductos(id);
                return View(productos);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult InsertarProducto(int id)
        {
            try
            {
                CatalogoModel catalogo = new CatalogoModel();
                var productos = catalogo.InsertarProducto(id);
                return View(productos);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

    }
}
