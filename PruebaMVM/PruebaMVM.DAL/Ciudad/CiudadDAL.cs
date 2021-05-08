using PruebaMVM.DTO;
using PruebaMVM.DTO.CiudadDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.CiudadDAL
{
    /// <summary>
    /// Crud de ciudades
    /// </summary>
    public class CiudadDAL
    {
        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns>Ciudades</returns>
        public List<CiudadRes> ObtenerCiudades()
        {
            List<CiudadRes> ciudades = new List<CiudadRes>();

            //using (Entities entities = new Entities())
            //{
            //    ciudades = entities.Ciudads.Include("Departamento").ToList();
            //}

            return ciudades;
        }
    }
}
