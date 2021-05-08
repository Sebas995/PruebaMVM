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
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Correspondencia", CorrespondenciaBLL.ObtenerCorrespondenciaPorId(Id));
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
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        [HttpGet]
        [Route("Api/ObtenerCorrespondenciaes")]
        public ResponseModel ObtenerCorrespondenciaes()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Correspondenciaes", CorrespondenciaBLL.ObtenerCorrespondenciaes());
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        /// <returns>Correspondencia Guardada</returns>
        [HttpPost]
        [Route("Api/GuardarCorrespondencia")]
        public ResponseModel GuardarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Comunicación guardada correctamente";
                responseModel.Response = true;
                responseModel.Data.Add("Correspondenciaes", CorrespondenciaBLL.GuardarCorrespondencia(CorrespondenciaReq));
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        [HttpPut]
        [Route("Api/EditarCorrespondencia")]
        public ResponseModel EditarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                CorrespondenciaBLL.EditarCorrespondencia(CorrespondenciaReq);
                responseModel.Message = "Comunicación editada correctamente";
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
        /// <param name="CorrespondenciaReq">Datos de la comunicación</param>
        [HttpDelete]
        [Route("Api/EliminarCorrespondencia")]
        public ResponseModel EliminarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                CorrespondenciaBLL.EliminarCorrespondencia(CorrespondenciaReq);
                responseModel.Message = "Comunicación eliminada correctamente";
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
