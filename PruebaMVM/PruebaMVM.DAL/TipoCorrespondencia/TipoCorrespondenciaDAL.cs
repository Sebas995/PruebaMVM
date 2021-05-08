using PruebaMVM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.TipoCorrespondenciaDAL
{
    /// <summary>
    /// Crud de tipos correspondencia
    /// </summary>
    public class TipoCorrespondenciaDAL
    {
        /// <summary>
        /// Obtiene los Tipo de correspondencia
        /// </summary>
        /// <returns>TipoCorrespondencia</returns>
        public List<TipoCorrespondencia> ObtenerTipoCorrespondencia()
        {
            List<TipoCorrespondencia> tipoCorrespondencias = new List<TipoCorrespondencia>();

            using (Entities entities = new Entities())
            {
                tipoCorrespondencias = entities.TipoCorrespondencias.ToList();
            }

            return tipoCorrespondencias;
        }
    }
}
