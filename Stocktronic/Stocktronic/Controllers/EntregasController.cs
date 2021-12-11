using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class EntregasController : Controller
    {
        // GET: Entregas
        public ActionResult Index()
        {
            try
            {
                EntregasModel entregas = new EntregasModel();
                var listaEntregas = entregas.ListarEntregas();
                return View(listaEntregas);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}