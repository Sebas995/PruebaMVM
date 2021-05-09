using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVM.Utilities.Logs;
using PruebaMVMFront.LlamarServicios;
using PruebaMVMFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMVMFront.Controllers
{
    /// <summary>
    /// Inicio de sesion del usuario
    /// </summary>
    public class HomeController : Controller
    {
        ServiciosUsuario serviciosUsuario = new ServiciosUsuario();

        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();

            LoginModel login = new LoginModel();
            ViewBag.Title = "Inicio de sesion";
            return View(login);
        }

        /// <summary>
        /// Inicio de sesion del usuario
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public ActionResult Login(LoginModel loginModel)
        {

            try
            {
                var Usuario = serviciosUsuario.Login(new UsuarioReq { Correo = loginModel.Usuario, Contrasena = loginModel.Contrasena});
                Session["Usuario"] = Usuario;
                Session["Rol"] = Usuario.Rol;
            }
            catch (MVMException exc)
            {
                ModelState.AddModelError("LoginError", exc.Message);
                //LogError.GuardarError(exc);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("LoginError", exc.Message);
                MVMException pruebaExc = new MVMException("Error en la aplicación", exc.GetType().ToString(), exc.Message, exc.StackTrace);
                //LogError.GuardarError(pruebaExc);
            }
            return View("Index", loginModel);
        }
    }
}
