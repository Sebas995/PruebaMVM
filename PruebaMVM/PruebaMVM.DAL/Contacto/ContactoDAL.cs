using PruebaMVM.DTO.ContactoDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.ContactoDAL
{
    public class ContactoDAL
    {
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Obtiene los contactos por Id
        /// </summary>
        /// <param name="Id">Id de la Contacto</param>
        /// <returns>Contacto</returns>
        public ContactoRes ObtenerContactoPorId(int Id)
        {

            ContactoRes Contacto = new ContactoRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarContactos", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactoId", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Contacto = new ContactoRes
                        {                            
                            ContactoId = Convert.ToInt32(rdr["ContactoId"]),                            
                            Nombres = Convert.ToString(rdr["Nombres"]),                            
                            Apellidos = Convert.ToString(rdr["Apellidos"]),                            
                            Ciudad = Convert.ToString(rdr["Ciudad"]),                                
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return Contacto;
        }

        /// <summary>
        /// Obtiene los contactos
        /// </summary>
        /// <returns>Contactos</returns>
        public List<ContactoRes> ObtenerContactos()
        {

            List<ContactoRes> Contactos = new List<ContactoRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarContactos", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactoId", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Contactos.Add(new ContactoRes
                        {
                            ContactoId = Convert.ToInt32(rdr["ContactoId"]),
                            Nombres = Convert.ToString(rdr["Nombres"]),
                            Apellidos = Convert.ToString(rdr["Apellidos"]),
                            Ciudad = Convert.ToString(rdr["Ciudad"]),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return Contactos;
        }

        /// <summary>
        /// Obtiene los contactos
        /// </summary>
        /// <returns>Contactos</returns>
        public void GuardarContacto(ContactoReq ContactoReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarContacto", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", ContactoReq.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", ContactoReq.Apellidos);
                    cmd.Parameters.AddWithValue("@Ciudad", ContactoReq.CiudadId);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", ContactoReq.UsuarioCreacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Editar los contactos
        /// </summary>
        /// <param name="ContactoReq"></param>
        public void EditarContacto(ContactoReq ContactoReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EditarContacto", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactoId", ContactoReq.ContactoId);
                    cmd.Parameters.AddWithValue("@Nombres", ContactoReq.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", ContactoReq.Apellidos);
                    cmd.Parameters.AddWithValue("@Ciudad", ContactoReq.CiudadId);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", ContactoReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Eliminar los contactos
        /// </summary>
        /// <param name="ContactoReq"></param>
        public void EliminarContacto(ContactoReq ContactoReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarContacto", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactoId", ContactoReq.ContactoId);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", ContactoReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }
    }
}
