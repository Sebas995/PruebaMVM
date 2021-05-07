using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PruebaMVM.DTO;
using PruebaMVM.DTO.ComunicacionDTO;

namespace PruebaMVM.DAL
{
    public class ComunicacionDAL
    {
        Entities entities = new Entities();
        /// <summary>
        /// Obtiene las comunicaciones por Id
        /// </summary>
        /// <param name="Id">Id de la Comunicacion</param>
        /// <returns>Comunicacion</returns>
        public ComunicacionRes ObtenerComunicacionPorId(int Id) {

            ComunicacionRes comunicacion = new ComunicacionRes();

            return comunicacion;
        }

        /// <summary>
        /// Obtiene las comunicaciones
        /// </summary>
        /// <returns>Comunicaciones</returns>
        public List<ComunicacionRes> ObtenerComunicaciones()
        {

            List<ComunicacionRes> comunicaciones = new List<ComunicacionRes>();

            return comunicaciones;
        }
    }
}
