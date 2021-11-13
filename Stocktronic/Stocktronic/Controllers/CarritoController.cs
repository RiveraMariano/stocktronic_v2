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

        [HttpGet]
        public ActionResult ReducirCantidad(int idCarrito)
        {
            try
            {
                CarritoModel carrito = new CarritoModel();
                var productos = carrito.ReducirCantidad(idCarrito);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult AumentarCantidad(int idCarrito)
        {
            try
            {
                CarritoModel carrito = new CarritoModel();
                var productos = carrito.AumentarCantidad(idCarrito);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult EliminarProducto(int idCarrito)
        {
            try
            {
                CarritoModel carrito = new CarritoModel();
                var productos = carrito.EliminarProducto(idCarrito);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

    }
}
