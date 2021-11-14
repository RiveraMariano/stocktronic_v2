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

        public ActionResult ActualizarUsuario(int idUsuario)
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

    }
}
