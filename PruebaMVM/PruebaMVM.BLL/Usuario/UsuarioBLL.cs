using Prueba.BLL.Helper;
using PruebaMVM.DAL.UsuarioDAL;
using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.BLL.UsuarioBLL
{
    /// <summary>
    /// CRUD de usuarios
    /// </summary>
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        /// <summary>
        /// Metodo de iniciar sesion
        /// </summary>
        /// <param name="UsuarioReq">Datos para iniciar sesion</param>
        /// <param name="Mensaje">Mensaje de respuesta</param>
        /// <returns>Datos del usuario</returns>
        public UsuarioRes IniciarSesion(UsuarioReq usuarioReq, ref string Mensaje, ref bool Respuesta)
        {
            UsuarioRes usuario = new UsuarioRes();
            try
            {
                usuario = usuarioDAL.IniciarSesion(usuarioReq);
                if (usuario.UsuarioId != 0) {
                    Mensaje = "Usuario Encontrado";
                    Respuesta = true;
                }
                else
                {
                    Mensaje = "Usuario o Contraseña incorrectos";
                    Respuesta = false;
                }
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene el Usuario por Id
        /// </summary>
        /// <param name="Id">Id de la Usuario</param>
        /// <returns>Usuario</returns>
        public UsuarioRes ObtenerUsuarioPorId(int Id)
        {
            UsuarioRes usuario = new UsuarioRes();
            try
            {
                usuario = usuarioDAL.ObtenerUsuarioPorId(Id);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene los Usuarios
        /// </summary>
        /// <returns>Usuarioes</returns>
        public List<UsuarioRes> ObtenerUsuarios()
        {
            List<UsuarioRes> usuarios = new List<UsuarioRes>();
            try
            {
                usuarios = usuarioDAL.ObtenerUsuarios();
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return usuarios;
        }

        /// <summary>
        /// Guarda los Usuarios
        /// </summary>
        /// <param name="UsuarioReq">Datos del Usuario</param>
        /// <returns>Datos del Usuario</returns>
        public void GuardarUsuario(UsuarioReq UsuarioReq)
        {
            try
            {
                usuarioDAL.GuardarUsuario(UsuarioReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
        }

        /// <summary>
        /// Editar los Usuarios
        /// </summary>
        /// <param name="UsuarioReq">Datos del Usuario</param>
        public void EditarUsuario(UsuarioReq UsuarioReq)
        {

            try
            {
                usuarioDAL.EditarUsuario(UsuarioReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
        }

        /// <summary>
        /// Eliminar los Usuarios
        /// </summary>
        /// <param name="UsuarioReq">Datos del Usuario</param>
        public void EliminarUsuario(UsuarioReq UsuarioReq)
        {
            try
            {
                usuarioDAL.EliminarUsuario(UsuarioReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
        }
    }
}
