using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVMFront.Models.ContactoDTO
{
    public class ContactoRes
    {
        public int ContactoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Ciudad { get; set; }
        public bool Activo { get; set; }
    }
}
