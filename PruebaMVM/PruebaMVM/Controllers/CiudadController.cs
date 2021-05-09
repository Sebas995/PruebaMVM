using Prueba.BLL.Helper;
using PruebaMVM.BLL.CiudadBLL;
using PruebaMVM.DTO.CiudadDTO;
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
    /// Crud de ciudades
    /// </summary>
    public class CiudadController : ApiController
    {
        CiudadBLL ciudadBLL = new CiudadBLL();

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns>Ciudades</returns>
        [HttpPost]
        [Route("Api/ObtenerCiudades")]
        public ResponseModel ObtenerCiudades(CiudadReq ciudadReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Ciudades", ciudadBLL.ObtenerCiudades(ciudadReq));
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
