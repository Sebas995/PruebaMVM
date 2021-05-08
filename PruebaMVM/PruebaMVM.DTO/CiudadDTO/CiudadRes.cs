using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DTO.CiudadDTO
{
    public class CiudadRes
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public bool Activo { get; set; }
    }
}
