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
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Departamentos", departamentoBLL.ObtenerDepartamentos(departamentoReq));
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
