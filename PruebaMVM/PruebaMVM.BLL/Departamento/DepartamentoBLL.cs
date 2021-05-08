using Prueba.BLL.Helper;
using PruebaMVM.DAL.DepartamentoDAL;
using PruebaMVM.DTO.DepartamentoDTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.BLL.DepartamentoBLL
{
    /// <summary>
    /// Crud de departamentos
    /// </summary>
    public class DepartamentoBLL
    {
        private DepartamentoDAL departamentoDAL = new DepartamentoDAL();

        /// <summary>
        /// Obtiene los departamentos
        /// </summary>
        /// <returns></returns>
        public List<DepartamentoRes> ObtenerDepartamentos()
        {
            List<DepartamentoRes> departamentos = new List<DepartamentoRes>();
            try
            {
                departamentos = departamentoDAL.ObtenerDepartamentos();
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

            return departamentos;
        }

    }
}
