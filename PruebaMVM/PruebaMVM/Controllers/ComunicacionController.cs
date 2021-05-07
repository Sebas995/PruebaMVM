﻿using Prueba.BLL.Helper;
using PruebaMVM.BLL;
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
    /// Crud De Comunicaciones
    /// </summary>
    public class ComunicacionController : ApiController
    {
        ComunicacionBLL comunicacionBLL = new ComunicacionBLL();

        /// <summary>
        /// Obtiene las comunicaciones por Id
        /// </summary>
        /// <param name="Id">Id de la Comunicacion</param>
        /// <returns>Comunicacion</returns>
        [HttpGet]
        [Route("Api/ObtenerComunicacionPorId/{Id}")]
        public ResponseModel ObtenerComunicacionPorId(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Comunicacion", comunicacionBLL.ObtenerComunicacionPorId(Id));
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
        /// Obtiene las comunicaciones
        /// </summary>
        /// <returns>Comunicaciones</returns>
        [HttpGet]
        [Route("Api/ObtenerComunicaciones")]
        public ResponseModel ObtenerComunicacionPorId()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Comunicaciones", comunicacionBLL.ObtenerComunicaciones());
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
