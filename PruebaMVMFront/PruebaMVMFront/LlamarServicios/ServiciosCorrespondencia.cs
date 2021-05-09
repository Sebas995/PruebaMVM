using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaMVM.DTO.CorrespondenciaDTO;
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
        public List<CorrespondenciaRes> ObtenerCorrespondenciaPorIdContacto(int Id)
        {
            List<CorrespondenciaRes> correspondenciaRes = new List<CorrespondenciaRes>();

            try
            {
                string urlApi = string.Format("{0}ObtenerCorrespondenciaPorIdContacto/{1}", servicios, Id);
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
                        throw new Exception(jContent["mensaje"].ToString());

                    var respuesta = jContent["Datos"]["Usuario"];

                    foreach (var dato in respuesta)
                    {
                        correspondenciaRes.Add(new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(dato["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(dato["TipoCorrespondencia"]),
                            Estado = Convert.ToString(dato["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(dato["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(dato["Destinatario"]).Trim(),
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
    }
}