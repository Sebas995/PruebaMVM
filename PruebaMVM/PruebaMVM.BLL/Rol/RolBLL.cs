using Prueba.BLL.Helper;
using PruebaMVM.DAL.RolDAL;
using PruebaMVM.DTO;
using PruebaMVM.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.BLL.RolBLL
{
    /// <summary>
    /// Crud de roles
    /// </summary>
    public class RolBLL
    {
        RolDAL rolDAL = new RolDAL();

        /// <summary>
        /// Obtiene las lista de roles
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerRoles()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                roles = rolDAL.ObtenerRoles();
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

            return roles;
        }

    }
}
