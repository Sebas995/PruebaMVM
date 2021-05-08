using PruebaMVM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.RolDAL
{
    /// <summary>
    /// Crud de roles
    /// </summary>
    public class RolDAL
    {
        /// <summary>
        /// Obtiene las lista de roles
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerRoles()
        {
            List<Rol> roles = new List<Rol>();

            using (Entities entities = new Entities())
            {
                roles = entities.Rols.ToList();
            }

            return roles;
        }
    }
}
