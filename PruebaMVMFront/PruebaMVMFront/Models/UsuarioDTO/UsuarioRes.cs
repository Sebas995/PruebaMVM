using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DTO.UsuarioDTO
{
    public class UsuarioRes
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public int ContactoId { get; set; }
        public string TelefonoContacto { get; set; }
        public bool Activo { get; set; }
    }
}
