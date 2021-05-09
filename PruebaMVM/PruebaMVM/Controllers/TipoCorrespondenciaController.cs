using Prueba.BLL.Helper;
using PruebaMVM.BLL.TipoCorrespondenciaBLL;
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
    /// Crud de tipos correspondencia
    /// </summary>
    public class TipoCorrespondenciaController : ApiController
    {
        TipoCorrespondenciaBLL tipoCorrespondenciaBLL = new TipoCorrespondenciaBLL();

        /// <summary>
        /// Obtiene los Tipo de correspondencia
        /// </summary>
        /// <returns>TipoCorrespondencia</returns>
        [HttpGet]
        [Route("Api/ObtenerTipoCorrespondencia")]
        public ResponseModel ObtenerTipoCorrespondencia()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("TipoCorrespondencia", tipoCorrespondenciaBLL.ObtenerTipoCorrespondencia());
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
