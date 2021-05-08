using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PruebaMVM.DTO;
using PruebaMVM.DTO.ComunicacionDTO;

namespace PruebaMVM.DAL
{
    /// <summary>
    /// Crud de comunicaciones
    /// </summary>
    public class ComunicacionDAL
    {
        private Entities entities = new Entities();
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Obtiene las comunicaciones por Id
        /// </summary>
        /// <param name="Id">Id de la Comunicacion</param>
        /// <returns>Comunicacion</returns>
        public ComunicacionRes ObtenerComunicacionPorId(int Id) {

            ComunicacionRes comunicacion = new ComunicacionRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarComunicaciones", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComunicacionId", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        comunicacion = new ComunicacionRes
                        {
                            ComunicacionId = Convert.ToInt32(rdr["ComunicacionId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return comunicacion;
        }

        /// <summary>
        /// Obtiene las comunicaciones
        /// </summary>
        /// <returns>Comunicaciones</returns>
        public List<ComunicacionRes> ObtenerComunicaciones()
        {

            List<ComunicacionRes> comunicaciones = new List<ComunicacionRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarComunicaciones", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComunicacionId", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        comunicaciones.Add(new ComunicacionRes
                        {
                            ComunicacionId = Convert.ToInt32(rdr["ComunicacionId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return comunicaciones;
        }

        /// <summary>
        /// Obtiene las comunicaciones
        /// </summary>
        /// <returns>Comunicaciones</returns>
        public ComunicacionRes GuardarComunicacion(ComunicacionReq comunicacionReq)
        {
            ComunicacionRes comunicacion = new ComunicacionRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarComunicacion", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoCorrespndencia", comunicacionReq.TipoCorrespondencia);
                    cmd.Parameters.AddWithValue("@Estado", comunicacionReq.Estado);
                    cmd.Parameters.AddWithValue("@ContactoDestinatario", comunicacionReq.ContactoDestinatario);
                    cmd.Parameters.AddWithValue("@ContactoRemitente", comunicacionReq.ContactoRemitente);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", comunicacionReq.UsuarioCreacion);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        comunicacion = new ComunicacionRes { 
                            ComunicacionId = Convert.ToInt32(rdr["ComunicacionId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return comunicacion;
        }

        /// <summary>
        /// Editar las comunicaciones
        /// </summary>
        /// <param name="comunicacionReq"></param>
        public void EditarComunicacion(ComunicacionReq comunicacionReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EditarComunicacion", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComunicacionId", comunicacionReq.ComunicacionId);
                    cmd.Parameters.AddWithValue("@Estado", comunicacionReq.Estado);
                    cmd.Parameters.AddWithValue("@ContactoDestinatario", comunicacionReq.ContactoDestinatario);
                    cmd.Parameters.AddWithValue("@ContactoRemitente", comunicacionReq.ContactoRemitente);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", comunicacionReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Eliminar las comunicaciones
        /// </summary>
        /// <param name="comunicacionReq"></param>
        public void EliminarComunicacion(ComunicacionReq comunicacionReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarComunicacion", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComunicacionId", comunicacionReq.ComunicacionId);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", comunicacionReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }
    }
}
