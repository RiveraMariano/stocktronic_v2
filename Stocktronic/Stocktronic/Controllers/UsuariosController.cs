using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class UsuariosController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                UsuariosModel usuario = new UsuariosModel();
                var listaUsuarios = usuario.ListarUsuarios();
                return View(listaUsuarios);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult FormUsuarioInsertar()
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

        public ActionResult FormUsuarioActualizar(int idUsuario)
        {
            try
            {
                UsuariosModel usuario = new UsuariosModel();
                var usuarioSeleccionado = usuario.ListarUsuario(idUsuario);
                return View(usuarioSeleccionado);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [ChildActionOnly]
        public ActionResult ListarRoles()
        {
            RolesModel rol = new RolesModel();
            var roles = rol.ListarRoles();
            return PartialView("~/Views/Shared/_ListaRoles.cshtml", roles);
        }

        [HttpGet]
        public ActionResult InsertarUsuario(string nombre, string apellido1, string apellido2, string correo, string password, int idRol)
        {
            UsuariosModel usuario = new UsuariosModel();
            var exitoso = usuario.InsertarUsuario(nombre, apellido1, apellido2, correo, password, idRol);

            if (exitoso)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(int idUsuario, string nombre, string apellido1, string apellido2, string correo, string password, int idRol)
        {
            UsuariosModel usuario = new UsuariosModel();
            var exitoso = usuario.ActualizarUsuario(idUsuario, nombre, apellido1, apellido2, correo, password, idRol);

            if (exitoso)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult EliminarUsuario(int idUsuario)
        {
            UsuariosModel usuario = new UsuariosModel();
            var exitoso = usuario.EliminarUsuario(idUsuario);

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
