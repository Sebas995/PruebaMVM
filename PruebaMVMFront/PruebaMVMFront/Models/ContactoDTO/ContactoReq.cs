using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVMFront.Models.ContactoDTO
{
    public class ContactoReq
    {
        public int ContactoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int CiudadId { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
