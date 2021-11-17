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

        [HttpGet]
        public ActionResult InsertarProducto(int idProducto, int idUsuario)
        {
            try
            {
                CatalogoModel catalogo = new CatalogoModel();
                var productos = catalogo.InsertarProducto(idProducto, idUsuario);
                Session["Cantidad"] = int.Parse(Session["Cantidad"].ToString()) + 1;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

    }
}
