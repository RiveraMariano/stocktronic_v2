using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class ConfirmacionController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                ConfirmacionModel confirmacion = new ConfirmacionModel();
                var confirmacionPago = confirmacion.ConfirmacionPago(1);
                return View(confirmacionPago);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [ChildActionOnly]
        public ActionResult ListarDetallesOrden(int idOrden)
        {
            DetalleOrdenModel detalleOrden = new DetalleOrdenModel();
            var detallesOrden = detalleOrden.ListarDetallesOrden(idOrden);
            return PartialView("~/Views/Shared/_ListaDetalleOrden.cshtml", detallesOrden);
        }

    }
}
