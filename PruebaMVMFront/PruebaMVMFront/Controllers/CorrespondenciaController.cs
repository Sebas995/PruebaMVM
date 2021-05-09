using PruebaMVM.DTO.CorrespondenciaDTO;
using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVMFront.LlamarServicios;
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

        public ActionResult Correspondencias()
        {
            var Usuario = (UsuarioRes)Session["Usuario"];
            List <CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();
            correspondenciaRes = serviciosCorrespondencia.ObtenerCorrespondenciaPorIdContacto(Usuario.ContactoId);

            return View("Correspondencia", correspondenciaRes);
        }
    }
}