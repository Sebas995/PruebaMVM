using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVMFront.Models.CorrespondenciaDTO
{
    public class CorrespondenciaReq
    {
        public int CorrespondenciaId { get; set; }
        public int TipoCorrespondencia { get; set; }
        public string NumeroRadicado { get; set; }
        public int Estado { get; set; }
        public int ContactoDestinatario { get; set; }
        public int ContactoRemitente { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Eliminado { get; set; }
    }
}
