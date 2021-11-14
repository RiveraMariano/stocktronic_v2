using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class ErroresController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                ErroresModel error = new ErroresModel();
                var listaErrores = error.ListarErrores();
                return View(listaErrores);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

    }
}
