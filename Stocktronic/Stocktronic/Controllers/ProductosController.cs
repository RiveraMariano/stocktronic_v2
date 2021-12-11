using Stocktronic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stocktronic.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            try
            {
                ProductosModel productos = new ProductosModel();
                var listaProductos = productos.ListarProductos();
                return View(listaProductos);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult FormAgregarProducto()
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

        public ActionResult FormActualizarProducto(int idProducto)
        {
            try
            {
                ProductosModel producto = new ProductosModel();
                var productoSeleccionado = producto.ListarProducto(idProducto);
                return View(productoSeleccionado);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [ChildActionOnly]
        public ActionResult ListarProveedores()
        {
            ProveedoresModel proveedor = new ProveedoresModel();
            var proveedores = proveedor.ListarProveedores();
            return PartialView("~/Views/Shared/_ListaProveedores.cshtml", proveedores);
        }


        [ChildActionOnly]
        public ActionResult ListarCategoria()
        {
            CategoriasModel categoria = new CategoriasModel();
            var categorias = categoria.ListarCategorias();
            return PartialView("~/Views/Shared/_ListaCategorias.cshtml", categorias);
        }

        [HttpGet]
        public ActionResult InsertarProducto(string nombre, string descripcion, string imagen, decimal precio, int cantidad, int idProveedor, int idCategoria)
        {
            ProductosModel producto = new ProductosModel();
            var exitoso = producto.InsertarProducto(nombre, descripcion, imagen, precio, cantidad, idProveedor, idCategoria);

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
        public ActionResult ActualizarProducto(int idProducto, string nombre, string descripcion, string imagen, decimal precio, int cantidad, int idProveedor, int idCategoria)
        {
            ProductosModel producto = new ProductosModel();
            var exitoso = producto.ActualizarProducto(idProducto, nombre, descripcion, imagen, precio, cantidad, idProveedor, idCategoria);

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
        public ActionResult EliminarProducto(int idProducto)
        {
            ProductosModel producto = new ProductosModel();
            var exitoso = producto.EliminarProducto(idProducto);

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