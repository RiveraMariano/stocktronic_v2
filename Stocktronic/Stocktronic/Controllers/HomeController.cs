﻿using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                CatalogoModel catalogo = new CatalogoModel();
                var productos = catalogo.ListarProductosAleatorios();
                return View(productos);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

    }
}