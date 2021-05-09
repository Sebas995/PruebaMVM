using Prueba.BLL.Helper;
using PruebaMVM.BLL;
using PruebaMVM.DTO.CorrespondenciaDTO;
using PruebaMVM.DTO.Response;
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
    /// Crud De Correspondenciaes
    /// </summary>
    public class CorrespondenciaController : ApiController
    {
        CorrespondenciaBLL CorrespondenciaBLL = new CorrespondenciaBLL();

        /// <summary>
        /// Obtiene las Correspondenciaes por Id
        /// </summary>
        /// <param name="Id">Id de la Correspondencia</param>
        /// <returns>Correspondencia</returns>
        [HttpGet]
        [Route("Api/ObtenerCorrespondenciaPorId/{Id}")]
        public ResponseModel ObtenerCorrespondenciaPorId(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Correspondencia", CorrespondenciaBLL.ObtenerCorrespondenciaPorId(Id));
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
        /// Obtiene las Correspondenciaes por Id contacto
        /// </summary>
        /// <param name="Id">Id de la Correspondencia</param>
        /// <returns>Correspondencia</returns>
        [HttpGet]
        [Route("Api/ObtenerCorrespondenciaPorIdContacto/{Id}")]
        public ResponseModel ObtenerCorrespondenciaPorIdContacto(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Correspondencia", CorrespondenciaBLL.ObtenerCorrespondenciaPorIdContacto(Id));
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
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        [HttpGet]
        [Route("Api/ObtenerCorrespondencias")]
        public ResponseModel ObtenerCorrespondencias()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Correspondencias", CorrespondenciaBLL.ObtenerCorrespondencias());
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        /// <returns>Correspondencia Guardada</returns>
        [HttpPost]
        [Route("Api/GuardarCorrespondencia")]
        public ResponseModel GuardarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Comunicación guardada correctamente";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Correspondenciaes", CorrespondenciaBLL.GuardarCorrespondencia(CorrespondenciaReq));
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        [HttpPut]
        [Route("Api/EditarCorrespondencia")]
        public ResponseModel EditarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                CorrespondenciaBLL.EditarCorrespondencia(CorrespondenciaReq);
                responseModel.Mensaje = "Comunicación editada correctamente";
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        [HttpPost]
        [Route("Api/EliminarCorrespondencia")]
        public ResponseModel EliminarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                CorrespondenciaBLL.EliminarCorrespondencia(CorrespondenciaReq);
                responseModel.Mensaje = "Comunicación eliminada ";
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
