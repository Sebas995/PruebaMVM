using Prueba.BLL.Helper;
using PruebaMVM.BLL.UsuarioBLL;
using PruebaMVM.DTO.Response;
using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaMVM.Controllers
{
    /// <summary>
    /// CRUD de usuarios
    /// </summary>
    public class UsuarioController : ApiController
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        /// <summary>
        /// Iniciar Sesion del usuario
        /// </summary>
        /// <param name="UsuarioReq">Correo y contraseña
        /// <returns>Usuario</returns>
        [HttpPost]
        [Route("Api/IniciarSesion")]
        public ResponseModel IniciarSesion(UsuarioReq UsuarioReq)
        {
            ResponseModel responseModel = new ResponseModel();
            string Mensaje = String.Empty;
            bool Respuesta = true;
            try
            {
                responseModel.Datos.Add("Usuario", usuarioBLL.IniciarSesion(UsuarioReq, ref Mensaje, ref Respuesta));
                responseModel.Mensaje = Mensaje;
                responseModel.Respuesta = Respuesta;
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }

        /// <summary>
        /// Obtiene los Usuarios por Id
        /// </summary>
        /// <param name="Id">Id del Usuario</param>
        /// <returns>Usuario</returns>
        [HttpGet]
        [Route("Api/ObtenerUsuarioPorId/{Id}")]
        public ResponseModel ObtenerUsuarioPorId(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Usuario", usuarioBLL.ObtenerUsuarioPorId(Id));
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }

        /// <summary>
        /// Obtiene los Usuarios
        /// </summary>
        /// <returns>Usuarios</returns>
        [HttpGet]
        [Route("Api/ObtenerUsuarios")]
        public ResponseModel ObtenerUsuarios()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Usuario", usuarioBLL.ObtenerUsuarios());
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }

        /// <summary>
        /// Guarda las Correspondenciaes
        /// </summary>
        /// <param name="UsuarioReq">Datos del Usuario</param>
        /// <returns>Usuario Guardado</returns>
        [HttpPost]
        [Route("Api/GuardarUsuario")]
        public ResponseModel GuardarUsuario(UsuarioReq UsuarioReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                usuarioBLL.GuardarUsuario(UsuarioReq);
                responseModel.Mensaje = "Usuario guardado correctamente";
                responseModel.Respuesta = true;
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }

        /// <summary>
        /// Editar las Correspondenciaes
        /// </summary>
        /// <param name="UsuarioReq">Datos del Usuario</param>
        [HttpPut]
        [Route("Api/EditarUsuario")]
        public ResponseModel EditarUsuario(UsuarioReq UsuarioReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                usuarioBLL.EditarUsuario(UsuarioReq);
                responseModel.Mensaje = "Usuario editado correctamente";
                responseModel.Respuesta = true;
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }

        /// <summary>
        /// Eliminar las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq"></param>
        [HttpDelete]
        [Route("Api/EliminarUsuario")]
        public ResponseModel EliminarUsuario(UsuarioReq UsuarioReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                usuarioBLL.EliminarUsuario(UsuarioReq);
                responseModel.Mensaje = "Usuario eliminado correctamente";
                responseModel.Respuesta = true;
            }
            catch (MVMException exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Respuesta = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Mensaje = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Respuesta = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }
    }
}
