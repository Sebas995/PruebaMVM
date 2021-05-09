using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DTO.Response
{
    [JsonObject]
    public class ResponseModel
    {
        public ResponseModel()
        {
            Datos = new Dictionary<string, object>();
        }

        /// <summary>
        /// Message of response
        /// </summary>
        public string Mensaje { get; set; } 
        /// <summary>
        /// Response (true or false)
        /// </summary>
        public bool Respuesta { get; set; } 
        /// <summary>
        /// Data Response
        /// </summary>
        public Dictionary<string, object> Datos { get; set; } 
    }
}
