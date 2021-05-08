using PruebaMVM.DTO;
using PruebaMVM.DTO.CiudadDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns>Ciudades</returns>
        public List<CiudadRes> ObtenerCiudades(CiudadReq ciudadReq)
        {
            List<CiudadRes> ciudades = new List<CiudadRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarCiudaddes", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CiudadId", ciudadReq.CiudadId);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ciudades.Add(new CiudadRes
                        {
                            CiudadId = Convert.ToInt32(rdr["CiudadId"]),
                            Nombre = Convert.ToString(rdr["Nombre"]),
                            DepartamentoId = Convert.ToInt32(rdr["DepartamentoId"]),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return ciudades;
        }
    }
}
