using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult IniciarSesion(string correo, string contrasenna)
        {
            LoginModel login = new LoginModel();
            var usuario = login.IniciarSesion(correo, contrasenna);

            if (usuario != null)
            {
                Session["ID_USUARIO"] = usuario.ID_USUARIO;
                Session["USR_NOMBRE"] = usuario.USR_NOMBRE;
                Session["USR_APELLIDO1"] = usuario.USR_APELLIDO1;
                Session["FK_ID_ROL"] = usuario.FK_ID_ROL;
                CarritoModel carrito = new CarritoModel();
                Session["Cantidad"] = carrito.ListarProductosAgregados(Convert.ToInt32(usuario.ID_USUARIO)).Count();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult RegistrarUsuario(string nombre, string apellido1, string apellido2, string correo, string contrasenna)
        {
            LoginModel registro = new LoginModel();
            var usuario = registro.RegistrarUsuario(nombre, apellido1, apellido2, correo, contrasenna);
            var usuarioAuth = registro.IniciarSesion(correo, contrasenna);

            if (usuario != null)
            {
                Session["ID_USUARIO"] = usuarioAuth.ID_USUARIO;
                Session["USR_NOMBRE"] = usuarioAuth.USR_NOMBRE;
                Session["USR_APELLIDO1"] = usuarioAuth.USR_APELLIDO1;
                Session["FK_ID_ROL"] = usuarioAuth.FK_ID_ROL;
                CarritoModel carrito = new CarritoModel();
                Session["Cantidad"] = carrito.CantidadCarrito(Convert.ToInt32(usuarioAuth.ID_USUARIO));
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            Session["ID_USUARIO"] = null;
            Session["USR_NOMBRE"] = null;
            Session["USR_APELLIDO1"] = null;
            Session["FK_ID_ROL"] = null;
            Session["Cantidad"] = null;
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
