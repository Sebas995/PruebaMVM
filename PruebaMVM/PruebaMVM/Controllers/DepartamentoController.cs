using Prueba.BLL.Helper;
using PruebaMVM.BLL.DepartamentoBLL;
using PruebaMVM.DTO.DepartamentoDTO;
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
    /// CRUD de departamentos
    /// </summary>
    public class DepartamentoController : ApiController
    {
        private DepartamentoBLL departamentoBLL = new DepartamentoBLL();

        /// <summary>
        /// Obtiene los departamentos
        /// </summary>
        /// <returns>Departamentos</returns>
        [HttpGet]
        [Route("Api/ObtenerDepartamentos")]
        public ResponseModel ObtenerDepartamentos(DepartamentoReq departamentoReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Mensaje = "Datos Encontrados";
                responseModel.Respuesta = true;
                responseModel.Datos.Add("Departamentos", departamentoBLL.ObtenerDepartamentos(departamentoReq));
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
