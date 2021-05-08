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
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("TipoCorrespondencia", tipoCorrespondenciaBLL.ObtenerTipoCorrespondencia());
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
