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
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Usuario", usuarioBLL.ObtenerUsuarioPorId(Id));
            }
            catch (MVMException exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Response = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Response = false;
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
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Usuario", usuarioBLL.ObtenerUsuarios());
            }
            catch (MVMException exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Response = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Response = false;
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
                responseModel.Message = "Usuario guardado correctamente";
                responseModel.Response = true;
            }
            catch (MVMException exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Response = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Response = false;
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
                responseModel.Message = "Usuario editado correctamente";
                responseModel.Response = true;
            }
            catch (MVMException exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Response = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Response = false;
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
                responseModel.Message = "Usuario eliminado correctamente";
                responseModel.Response = true;
            }
            catch (MVMException exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(exc.CodigoError);
                responseModel.Response = false;
                LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                responseModel.Message = MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_USER.ToString());
                responseModel.Response = false;
                MVMException pruebaExc = new MVMException(MensajeUtil.ObtenerMensaje(EnumMensajes.ERROR_EXCEPTION.ToString()), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
            }

            return responseModel;
        }
    }
}
