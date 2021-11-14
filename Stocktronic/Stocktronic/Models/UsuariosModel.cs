using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stocktronic.Models
{
    public class UsuariosModel
    {

        public List<UsuariosJoin> ListarUsuarios()
        {
            using (var contexto = new STEntities())
            {
                var usuarios = (from x in contexto.PF_USUARIO
                                join y in contexto.PF_ROL
                                on x.FK_ID_ROL equals y.ID_ROL
                                select new
                                {
                                    ID_USUARIO = x.ID_USUARIO,
                                    USR_NOMBRE = x.USR_NOMBRE,
                                    USR_APELLIDO1 = x.USR_APELLIDO1,
                                    USR_APELLIDO2 = x.USR_APELLIDO2,
                                    USR_EMAIL = x.USR_EMAIL,
                                    ROL_TIPO = y.ROL_TIPO,
                                }).ToList();

                List<UsuariosJoin> listaUsuarios = new List<UsuariosJoin>();
                if (usuarios.Count > 0)
                {
                    foreach (var usuario in usuarios)
                    {
                        listaUsuarios.Add(new UsuariosJoin
                        {
                            ID_USUARIO = usuario.ID_USUARIO,
                            USR_NOMBRE = usuario.USR_NOMBRE,
                            USR_APELLIDO1 = usuario.USR_APELLIDO1,
                            USR_APELLIDO2 = usuario.USR_APELLIDO2,
                            USR_EMAIL = usuario.USR_EMAIL,
                            ROL_TIPO = usuario.ROL_TIPO,
                        });
                    }
                }
                return listaUsuarios;
            }
        }

        public PF_USUARIO ListarUsuario(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                return (from x in contexto.PF_USUARIO
                        where x.ID_USUARIO == idUsuario
                        select x).FirstOrDefault();

            }
        }

        public Boolean InsertarUsuario(string nombre, string apellido1, string apellido2, string correo, string password, int idRol)
        {
            using (var contexto = new STEntities())
            {
                PF_USUARIO usuario = new PF_USUARIO();
                usuario.USR_NOMBRE = nombre;
                usuario.USR_APELLIDO1 = apellido1;
                usuario.USR_APELLIDO2 = apellido2;
                usuario.USR_EMAIL = correo;
                usuario.USR_PASSWORD = password;
                usuario.FK_ID_ROL = idRol;

                contexto.PF_USUARIO.Add(usuario);
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean ActualizarUsuario(int idUsuario, string nombre, string apellido1, string apellido2, string correo, string password, int idRol)
        {
            using (var contexto = new STEntities())
            {
                var usuario = (from x in contexto.PF_USUARIO
                               where x.ID_USUARIO == idUsuario
                               select x).FirstOrDefault();

                usuario.USR_NOMBRE = nombre;
                usuario.USR_APELLIDO1 = apellido1;
                usuario.USR_APELLIDO2 = apellido2;
                usuario.USR_EMAIL = correo;
                usuario.USR_PASSWORD = password;
                usuario.FK_ID_ROL = idRol;
                contexto.SaveChanges();
                return true;
            }
        }

        public Boolean EliminarUsuario(int idUsuario)
        {
            using (var contexto = new STEntities())
            {
                // Eliminar los errores del usuario
                var listaErrores = (from x in contexto.PF_H_ERRORES
                                    where x.FK_ID_USUARIO == idUsuario
                                    select x).ToList();
                foreach (var error in listaErrores)
                {
                    contexto.PF_H_ERRORES.Remove(error);
                }

                // Eliminar los productos del carrito del usuario
                var listaProductos = (from x in contexto.PF_CARRITO
                                      where x.FK_ID_USUARIO == idUsuario
                                      select x).ToList();
                foreach (var producto in listaProductos)
                {
                    contexto.PF_CARRITO.Remove(producto);
                }

                // Eliminar los detalles de las ordenes del usuario
                var listaDetalleOrdenes = (from x in contexto.PF_DETALLE_ORDEN
                                           where x.FK_ID_USUARIO == idUsuario
                                           select x).ToList();
                foreach (var detalleOrden in listaDetalleOrdenes)
                {
                    contexto.PF_DETALLE_ORDEN.Remove(detalleOrden);
                }

                // Eliminar las ordenes del usuario
                var listaOrdenes = (from x in contexto.PF_ORDEN
                                    where x.FK_ID_USUARIO == idUsuario
                                    select x).ToList();
                foreach (var orden in listaOrdenes)
                {
                    contexto.PF_ORDEN.Remove(orden);
                }

                // Eliminar la información de los pagos del usuario
                var listaPagos = (from x in contexto.PF_INFO_PAGO
                                  where x.FK_ID_USUARIO == idUsuario
                                  select x).ToList();
                foreach (var infoPago in listaPagos)
                {
                    contexto.PF_INFO_PAGO.Remove(infoPago);
                }

                // Eliminar el usuario
                var usuario = (from x in contexto.PF_USUARIO
                               where x.ID_USUARIO == idUsuario
                               select x).FirstOrDefault();

                contexto.PF_USUARIO.Remove(usuario);
                contexto.SaveChanges();
                return true;
            }
        }

    }
}