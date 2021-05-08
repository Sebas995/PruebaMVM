using Prueba.BLL.Helper;
using PruebaMVM.DAL.TipoCorrespondenciaDAL;
using PruebaMVM.DTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.BLL.TipoCorrespondenciaBLL
{
    /// <summary>
    /// Crud de tipos correspondencia
    /// </summary>
    public class TipoCorrespondenciaBLL
    {
        TipoCorrespondenciaDAL tipoCorrespondenciaBLL = new TipoCorrespondenciaDAL();

        /// <summary>
        /// Obtiene los Tipo de correspondencia
        /// </summary>
        /// <returns>TipoCorrespondencia</returns>
        public List<TipoCorrespondencia> ObtenerTipoCorrespondencia()
        {
            List<TipoCorrespondencia> comunicacion = new List<TipoCorrespondencia>();
            try
            {
                comunicacion = tipoCorrespondenciaBLL.ObtenerTipoCorrespondencia();
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

            return comunicacion;
        }
    }
}
