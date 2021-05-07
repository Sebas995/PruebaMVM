using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DTO.ComunicacionDTO
{
    public class ComunicacionRes
    {
        public int ComunicacionId { get; set; }
        public string TipoCorrespondencia { get; set; }
        public string NumeroRadicado { get; set; }
        public string Estado { get; set; }
        public string ContactoDestinatario { get; set; }
        public string ContactoRemitente { get; set; }
    }
}
