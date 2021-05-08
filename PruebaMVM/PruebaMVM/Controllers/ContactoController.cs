using Prueba.BLL.Helper;
using PruebaMVM.BLL.ContactoBLL;
using PruebaMVM.DTO.ContactoDTO;
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
    /// CRUD de contacto
    /// </summary>
    public class ContactoController : ApiController
    {
        ContactoBLL contactoBLL = new ContactoBLL();

        /// <summary>
        /// Obtiene los contactos por Id
        /// </summary>
        /// <param name="Id">Id del contacto</param>
        /// <returns>Contacto</returns>
        [HttpGet]
        [Route("Api/ObtenerContactoPorId/{Id}")]
        public ResponseModel ObtenerContactoPorId(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Contacto", contactoBLL.ObtenerContactoPorId(Id));
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
        /// Obtiene los Contactos
        /// </summary>
        /// <returns>Contactos</returns>
        [HttpGet]
        [Route("Api/ObtenerContactos")]
        public ResponseModel ObtenerContactos()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.Message = "Datos Encontrados";
                responseModel.Response = true;
                responseModel.Data.Add("Contacto", contactoBLL.ObtenerContactos());
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
        /// Guarda los Contactos
        /// </summary>
        /// <param name="contactoReq">Datos del contacto</param>
        /// <returns>Contacto Guardado</returns>
        [HttpPost]
        [Route("Api/GuardarContacto")]
        public ResponseModel GuardarContacto(ContactoReq contactoReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                contactoBLL.GuardarContacto(contactoReq);
                responseModel.Message = "Contacto guardado correctamente";
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
        /// Editar los contactos
        /// </summary>
        /// <param name="contactoReq">Datos del contacto</param>
        [HttpPut]
        [Route("Api/EditarContacto")]
        public ResponseModel EditarContacto(ContactoReq contactoReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                contactoBLL.EditarContacto(contactoReq);
                responseModel.Message = "Contacto editado correctamente";
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
        /// Eliminar los Contactos
        /// </summary>
        /// <param name="CorrespondenciaReq"></param>
        [HttpDelete]
        [Route("Api/EliminarContacto")]
        public ResponseModel EliminarContacto(ContactoReq contactoReq)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                contactoBLL.EliminarContacto(contactoReq);
                responseModel.Message = "Contacto eliminado correctamente";
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
