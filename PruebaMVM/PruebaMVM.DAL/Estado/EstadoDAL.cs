using PruebaMVM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.EstadoDAL
{
    /// <summary>
    /// Crud de Estados
    /// </summary>
    public class EstadoDAL
    {
        /// <summary>
        /// Obtiene estados
        /// </summary>
        /// <returns>Estados</returns>
        public List<Estado> ObtenerEstados()
        {
            List<Estado> estados = new List<Estado>();

            using (Entities entities = new Entities())
            {
                estados = entities.Estadoes.ToList();
            }

            return estados;
        }
    }
}
