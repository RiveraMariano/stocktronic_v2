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

        public ActionResult Index(int idUsuario)
        {
            try
            {
                CarritoModel carrito = new CarritoModel();
                var productosAgregados = carrito.ListarProductosAgregados(idUsuario);
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
            var idUsuario = Session["ID_USUARIO"];

            try
            {
                CarritoModel carrito = new CarritoModel();
                var productos = carrito.ReducirCantidad(idCarrito);
                Session["Cantidad"] = carrito.CantidadCarrito(Convert.ToInt32(idUsuario));
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
            var idUsuario = Session["ID_USUARIO"];

            try
            {
                CarritoModel carrito = new CarritoModel();
                var productos = carrito.AumentarCantidad(idCarrito);
                Session["Cantidad"] = carrito.CantidadCarrito(Convert.ToInt32(idUsuario));
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
                Session["Cantidad"] = int.Parse(Session["Cantidad"].ToString()) - 1;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

    }
}
