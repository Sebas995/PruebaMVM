using Prueba.BLL.Helper;
using PruebaMVM.DTO.Response;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMVM.Controllers
{
    public class HomeController : Controller
    {
        private ResponseModel responseModel = new ResponseModel();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// Get all employees items
        /// </summary>
        /// <returns>List of Employees</returns>
        [HttpGet]
        [Route("api/redarbor")]
        public ResponseModel Formis()
        {

            try
            {
                this.responseModel.Message = "Datos Encontrados";
                this.responseModel.Response = true;
            }
            catch (MVMException exc)
            {
                LogError.GuardarError(exc);
                this.responseModel.Message = EnumMensajes.ERROR_USER.ToString();
                this.responseModel.Response = false;
            }
            catch (Exception exc)
            {
                MVMException pruebaExc = new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
                LogError.GuardarError(pruebaExc);
                this.responseModel.Message = EnumMensajes.ERROR_USER.ToString();
                this.responseModel.Response = false;
            }

            return this.responseModel;
        }
    }
}
