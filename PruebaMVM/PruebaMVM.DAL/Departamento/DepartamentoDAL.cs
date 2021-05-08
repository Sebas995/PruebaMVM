using PruebaMVM.DTO;
using PruebaMVM.DTO.DepartamentoDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.DepartamentoDAL
{
    /// <summary>
    /// CRUD de departamentos
    /// </summary>
    public class DepartamentoDAL
    {
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Obtiene los departamentos
        /// </summary>
        /// <returns>Departamentos</returns>
        public List<DepartamentoRes> ObtenerDepartamentos(DepartamentoReq departamentoReq)
        {
            List<DepartamentoRes> departamentos = new List<DepartamentoRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarDepartamentos", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartamentoId", departamentoReq.DepartamentoId);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        departamentos.Add(new DepartamentoRes
                        {
                            DepartamentoId = Convert.ToInt32(rdr["DepartamentoId"]),
                            Nombre = Convert.ToString(rdr["Nombre"]),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return departamentos;
        }
    }
}
