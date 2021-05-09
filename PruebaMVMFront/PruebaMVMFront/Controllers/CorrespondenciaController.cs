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
            return View();
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
                ModelState.AddModelError("LoginError", exc.Message);
                //LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("LoginError", exc.Message);
                MVMException pruebaExc = new MVMException(exc.Message, exc.GetType().ToString(), exc.Message, exc.StackTrace);
                //LogError.GuardarError(pruebaExc);
            }

            return View("Correspondencia", correspondenciaRes);
        }
    }
}