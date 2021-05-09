using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace PruebaMVMFront.LlamarServicios
{
    /// <summary>
    /// Consume todos los servidos relacionados al usuario
    /// </summary>
    public class ServiciosUsuario
    {
        private string servicios = ConfigurationManager.AppSettings["UrlServicios"].ToString();

        /// <summary>
        /// Logueo del usuario
        /// </summary>
        /// <param name="usuarioReq"></param>
        /// <returns></returns>
        public UsuarioRes Login(UsuarioReq usuarioReq) 
        {

            UsuarioRes usuarioRes = new UsuarioRes();

            try
            {
                string urlApi = string.Format("{0}IniciarSesion", servicios);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlApi);
                request.Method = "POST";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(urlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(urlApi, new StringContent(JsonConvert.SerializeObject(usuarioReq).ToString(), Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    JObject jContent = JObject.Parse(response.Content.ReadAsStringAsync().Result); 

                    if (jContent["Respuesta"].ToString() == "False")                    
                        throw new Exception(jContent["Mensaje"].ToString());

                    var respuesta = jContent["Datos"]["Usuario"];

                    usuarioRes = new UsuarioRes
                    {
                        UsuarioId = Convert.ToInt32(respuesta["UsuarioId"]),
                        Nombres = Convert.ToString(respuesta["Nombres"]),
                        Apellidos = Convert.ToString(respuesta["Apellidos"]),
                        Correo = Convert.ToString(respuesta["Correo"]),
                        Rol = Convert.ToString(respuesta["Rol"]),
                        ContactoId = Convert.ToInt32(respuesta["ContactoId"]),
                        TelefonoContacto = Convert.ToString(respuesta["TelefonoContacto"]),
                    };
                    
                }
            }
            catch (MVMException exc)
            {
                throw new MVMException(exc.Message, exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return usuarioRes;
        }
    }
}