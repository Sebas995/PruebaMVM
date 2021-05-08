using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.BLL.Helper;
using PruebaMVM.DAL.EstadoDAL;
using PruebaMVM.DTO;
using PruebaMVM.Utilities.Logs;

namespace PruebaMVM.BLL.EstadoBLL
{
    /// <summary>
    /// Crud de Estados
    /// </summary>
    public class EstadoBLL
    {
        EstadoDAL estadoDAL = new EstadoDAL();

        /// <summary>
        /// Obtiene los estados
        /// </summary>
        /// <returns>Estados</returns>
        public List<Estado> ObtenerEstados()
        {
            List<Estado> estados = new List<Estado>();
            try
            {
                estados = estadoDAL.ObtenerEstados();
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

            return estados;
        }
    }
}
