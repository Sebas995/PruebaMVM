using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaMVMFront.Models.CorrespondenciaDTO;
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
    public class ServiciosCorrespondencia
    {
        private string servicios = ConfigurationManager.AppSettings["UrlServicios"].ToString();

        /// <summary>
        /// Obtiene las correspondencia de un usuario 
        /// </summary>
        /// <param name="Id">Contacto</param>
        /// <returns>correspondencias</returns>
        public List<CorrespondenciaRes> ObtenerCorrespondencias()
        {
            List<CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();

            try
            {
                string urlApi = String.Format("{0}ObtenerCorrespondencias", servicios);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlApi);
                request.Method = "GET";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(urlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(urlApi).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    JObject jContent = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                    if (jContent["Respuesta"].ToString() == "false")
                        throw new Exception(jContent["Mensaje"].ToString());

                    var respuesta = jContent["Datos"]["Correspondencias"];

                    foreach (var dato in respuesta)
                    {
                        correspondenciaRes.Add(new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(dato["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(dato["TipoCorrespondencia"]),
                            NumeroRadicado = Convert.ToString(dato["NumeroRadicado"]).Trim(),
                            Estado = Convert.ToString(dato["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(dato["ContactoRemitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(dato["ContactoDestinatario"]).Trim(),
                        });
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return correspondenciaRes;
        }

        /// <summary>
        /// Obtiene las correspondencia de un usuario 
        /// </summary>
        /// <param name="Id">Contacto</param>
        /// <returns>correspondencias</returns>
        public List<CorrespondenciaRes> ObtenerCorrespondenciaPorIdContacto(int Id)
        {
            List<CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();

            try
            {
                string urlApi = String.Format("{0}ObtenerCorrespondenciaPorIdContacto/{1}", servicios, Id);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlApi);
                request.Method = "GET";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(urlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(urlApi).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    JObject jContent = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                    if (jContent["Respuesta"].ToString() == "false")
                        throw new Exception(jContent["Mensaje"].ToString());

                    var respuesta = jContent["Datos"]["Correspondencia"];

                    foreach (var dato in respuesta)
                    {
                        correspondenciaRes.Add(new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(dato["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(dato["TipoCorrespondencia"]),
                            NumeroRadicado = Convert.ToString(dato["NumeroRadicado"]).Trim(),
                            Estado = Convert.ToString(dato["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(dato["ContactoRemitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(dato["ContactoDestinatario"]).Trim(),
                        });
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return correspondenciaRes;
        }

        /// <summary>
        /// Elimina la correspondencia
        /// </summary>
        /// <param name="correspondenciaReq"></param>
        /// <returns>Mensaje del proceso</returns>
        public string EliminarCorrespondencia(CorrespondenciaReq correspondenciaReq)
        {
            string Mensaje = String.Empty;

            try
            {
                string urlApi = String.Format("{0}EliminarCorrespondencia", servicios);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlApi);
                request.Method = "POST";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(urlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync(urlApi, new StringContent(JsonConvert.SerializeObject(correspondenciaReq).ToString(), Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    JObject jContent = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                    if (jContent["Respuesta"].ToString() == "false")
                        throw new Exception(jContent["Mensaje"].ToString());

                    Mensaje = jContent["Mensaje"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Mensaje;
        }
    }
}