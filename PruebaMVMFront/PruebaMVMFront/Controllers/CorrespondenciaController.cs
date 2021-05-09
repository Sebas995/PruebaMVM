using PruebaMVM.Utilities.Logs;
using PruebaMVMFront.LlamarServicios;
using PruebaMVMFront.Models.CorrespondenciaDTO;
using PruebaMVMFront.Models.UsuarioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMVMFront.Controllers
{
    /// <summary>
    /// Administrador de correspondencias
    /// </summary>
    public class CorrespondenciaController : Controller
    {
        ServiciosCorrespondencia serviciosCorrespondencia = new ServiciosCorrespondencia();

        public ActionResult Correspondencia()
        {
            List<CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();

            try
            {
                ViewBag.Title = "Correspondencias";
                correspondenciaRes = serviciosCorrespondencia.ObtenerCorrespondencias();
            }
            catch (MVMException exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                //LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                MVMException pruebaExc = new MVMException(exc.Message, exc.GetType().ToString(), exc.Message, exc.StackTrace);
                //LogError.GuardarError(pruebaExc);
            }

            return View(correspondenciaRes);
        }

        public ActionResult CorrespondenciaDestinatario()
        {
            List<CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();

            try
            {
                ViewBag.Title = "Correspondencia de destinatario";
                var Usuario = (UsuarioRes)Session["Usuario"];
                correspondenciaRes = serviciosCorrespondencia.ObtenerCorrespondenciaPorIdContacto(Usuario.ContactoId);
            }
            catch (MVMException exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                //LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                MVMException pruebaExc = new MVMException(exc.Message, exc.GetType().ToString(), exc.Message, exc.StackTrace);
                //LogError.GuardarError(pruebaExc);
            }

            return View("Correspondencia", correspondenciaRes);
        }

        //public ActionResult EditarCorrespondencia(int Id)
        //{ 

        //}

        /// <summary>
        /// Eliminar la correspondencia
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EliminarCorrespondencia(int Id)
        {
            string Mensaje = String.Empty;

            try
            {
                var Usuario = (UsuarioRes)Session["Usuario"];
                Mensaje = serviciosCorrespondencia.EliminarCorrespondencia(new CorrespondenciaReq { CorrespondenciaId = Id, UsuarioModificacion = Usuario.UsuarioId});
                TempData["Correspondencia"] = Mensaje;
            }
            catch (MVMException exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                return View();
                //LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("CorrespondenciaError", exc.Message);
                MVMException pruebaExc = new MVMException(exc.Message, exc.GetType().ToString(), exc.Message, exc.StackTrace);
                return View();
                //LogError.GuardarError(pruebaExc);
            }

            return RedirectToAction("CorrespondenciaDestinatario", "Correspondencia");
        }
    }
}