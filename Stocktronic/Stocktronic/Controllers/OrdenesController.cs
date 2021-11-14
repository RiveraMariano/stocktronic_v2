using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class OrdenesController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                OrdenesModel ordenes = new OrdenesModel();
                var historialOrdenes = ordenes.ListarOrdenes();
                return View(historialOrdenes);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult ListarDetallesOrden(int idOrden)
        {
            DetalleOrdenModel detalleOrden = new DetalleOrdenModel();
            var detallesOrden = detalleOrden.ListarDetallesOrden(idOrden);

            if (detallesOrden.Count > 0)
            {
                return Json(detallesOrden, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

    }
}
