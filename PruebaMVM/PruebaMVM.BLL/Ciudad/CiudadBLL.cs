using Prueba.BLL.Helper;
using PruebaMVM.DAL.CiudadDAL;
using PruebaMVM.DTO;
using PruebaMVM.DTO.CiudadDTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.BLL.CiudadBLL
{
    /// <summary>
    /// Crud de ciudades
    /// </summary>
    public class CiudadBLL
    {
        CiudadDAL ciudadDAL = new CiudadDAL();

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns>Ciudades</returns>
        public List<CiudadRes> ObtenerCiudades(CiudadReq ciudadReq)
        {
            List<CiudadRes> ciudades = new List<CiudadRes>();
            try
            {
                ciudades = ciudadDAL.ObtenerCiudades(ciudadReq);

                if (!ciudadReq.DepartamentoId.Equals(0))
                    ciudades = ciudades.Where(c => c.DepartamentoId == ciudadReq.DepartamentoId).ToList();
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return ciudades;
        }
    }
}
