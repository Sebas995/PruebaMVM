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
using PruebaMVM.DTO.CorrespondenciaDTO;

namespace PruebaMVM.DAL
{
    /// <summary>
    /// Crud de Correspondenciaes
    /// </summary>
    public class CorrespondenciaDAL
    {
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Obtiene las Correspondenciaes por Id
        /// </summary>
        /// <param name="Id">Id de la Correspondencia</param>
        /// <returns>Correspondencia</returns>
        public CorrespondenciaRes ObtenerCorrespondenciaPorId(int Id) {

            CorrespondenciaRes Correspondencia = new CorrespondenciaRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarCorrespondencias", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorrespondenciaId", Id);
                    cmd.Parameters.AddWithValue("@ContactoId", 0);
                    cmd.Parameters.AddWithValue("@Estado", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Correspondencia = new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(rdr["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            NumeroRadicado = Convert.ToString(rdr["NumeroRadicado"]).Trim(),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return Correspondencia;
        }

        /// <summary>
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        public List<CorrespondenciaRes> ObtenerCorrespondenciaPorIdContacto(int Id)
        {

            List<CorrespondenciaRes> correspondencias = new List<CorrespondenciaRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarCorrespondencias", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorrespondenciaId", 0);
                    cmd.Parameters.AddWithValue("@ContactoId", Id); 
                    cmd.Parameters.AddWithValue("@Estado", 1);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        correspondencias.Add(new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(rdr["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            NumeroRadicado = Convert.ToString(rdr["NumeroRadicado"]),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return correspondencias;
        }

        /// <summary>
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        public List<CorrespondenciaRes> ObtenerCorrespondencias()
        {

            List<CorrespondenciaRes> Correspondenciaes = new List<CorrespondenciaRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarCorrespondencias", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorrespondenciaId", 0);
                    cmd.Parameters.AddWithValue("@ContactoId", 0);
                    cmd.Parameters.AddWithValue("@Estado", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Correspondenciaes.Add(new CorrespondenciaRes
                        {
                            CorrespondenciaId = Convert.ToInt32(rdr["CorrespondenciaId"]),
                            TipoCorrespondencia = Convert.ToInt32(rdr["TipoCorrespondencia"]),
                            Estado = Convert.ToString(rdr["Estado"]).Trim(),
                            NumeroRadicado = Convert.ToString(rdr["NumeroRadicado"]).Trim(),
                            ContactoRemitente = Convert.ToString(rdr["Remitente"]).Trim(),
                            ContactoDestinatario = Convert.ToString(rdr["Destinatario"]).Trim(),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return Correspondenciaes;
        }

        /// <summary>
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        public CorrespondenciaRes GuardarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            CorrespondenciaRes Correspondencia = new CorrespondenciaRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarCorrespondencia", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoCorrespndencia", CorrespondenciaReq.TipoCorrespondencia);
                    cmd.Parameters.AddWithValue("@Estado", CorrespondenciaReq.Estado);
                    cmd.Parameters.AddWithValue("@ContactoDestinatario", CorrespondenciaReq.ContactoDestinatario);
                    cmd.Parameters.AddWithValue("@ContactoRemitente", CorrespondenciaReq.ContactoRemitente);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", CorrespondenciaReq.UsuarioCreacion);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Correspondencia = new CorrespondenciaRes { 
                            CorrespondenciaId = Convert.ToInt32(rdr["CorrespondenciaId"]),
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

            return Correspondencia;
        }

        /// <summary>
        /// Editar las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq"></param>
        public void EditarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EditarCorrespondencia", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorrespondenciaId", CorrespondenciaReq.CorrespondenciaId);
                    cmd.Parameters.AddWithValue("@Estado", CorrespondenciaReq.Estado);
                    cmd.Parameters.AddWithValue("@ContactoDestinatario", CorrespondenciaReq.ContactoDestinatario);
                    cmd.Parameters.AddWithValue("@ContactoRemitente", CorrespondenciaReq.ContactoRemitente);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", CorrespondenciaReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Eliminar las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq"></param>
        public void EliminarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarCorrespondencia", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CorrespondenciaId", CorrespondenciaReq.CorrespondenciaId);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", CorrespondenciaReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }
    }
}
