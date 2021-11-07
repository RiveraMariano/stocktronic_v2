using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class CarritoController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                CarritoModel carrito = new CarritoModel();
                var productosAgregados = carrito.ListarProductosAgregados();
                return View(productosAgregados);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

    }
}
