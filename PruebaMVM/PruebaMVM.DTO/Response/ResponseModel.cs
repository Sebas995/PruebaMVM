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
            Data = new Dictionary<string, object>();
        }

        /// <summary>
        /// Message of response
        /// </summary>
        public string Message { get; set; } 
        /// <summary>
        /// Response (true or false)
        /// </summary>
        public bool Response { get; set; } 
        /// <summary>
        /// Data Response
        /// </summary>
        public Dictionary<string, object> Data { get; set; } 
    }
}
