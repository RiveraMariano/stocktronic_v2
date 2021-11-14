using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class ComprarController : Controller
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

        [ChildActionOnly]
        public ActionResult ListarMetodosPago()
        {
            MetodoPagoModel metodoPago = new MetodoPagoModel();
            var metodosPago = metodoPago.ListarMetodosPago();
            return PartialView("~/Views/Shared/_ListaMetodoPago.cshtml", metodosPago);
        }

        [HttpGet]
        public ActionResult RealizarCompra(string numTarjeta, string dirFact1, string dirFact2, string telefono, decimal total, int idUsuario, int idMetodoPago)
        {
            ComprarModel compra = new ComprarModel();
            compra.InsertarInfoPago(numTarjeta, dirFact1, dirFact2, telefono, total, idUsuario, idMetodoPago);
            compra.InsertarOrden(idUsuario);
            var exitoso = compra.InsertarDetalleOrden(idUsuario);

            if (exitoso)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

    }
}
