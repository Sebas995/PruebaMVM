using PruebaMVM.DTO.UsuarioDTO;
using PruebaMVM.Utilities.Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVM.DAL.UsuarioDAL
{
    /// <summary>
    /// CRUD de usuarios
    /// </summary>
    public class UsuarioDAL
    {
        private string pruebaMVM = ConfigurationManager.ConnectionStrings["PruebaMVM"].ToString();

        /// <summary>
        /// Iniciar Sesion del usuario
        /// </summary>
        /// <param name="UsuarioReq">Correo y contraseña
        /// <returns>Usuario</returns>
        public UsuarioRes IniciarSesion(UsuarioReq usuarioReq)
        {
            UsuarioRes usuario = new UsuarioRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("IniciarSesion", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", usuarioReq.Correo);
                    cmd.Parameters.AddWithValue("@Contrasena", SeguridadContrasena.Encrypt(usuarioReq.Contrasena));
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuario = new UsuarioRes
                        {
                            UsuarioId = Convert.ToInt32(rdr["UsuarioId"]),
                            Nombres = Convert.ToString(rdr["Nombres"]),
                            Apellidos = Convert.ToString(rdr["Apellidos"]),
                            Correo = Convert.ToString(rdr["Correo"]),
                            Rol = Convert.ToString(rdr["Rol"]),
                            TelefonoContacto = Convert.ToString(rdr["TelefonoContacto"]),
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene los Usuarios por Id
        /// </summary>
        /// <param name="Id">Id de la Usuario</param>
        /// <returns>Usuario</returns>
        public UsuarioRes ObtenerUsuarioPorId(int Id)
        {
            UsuarioRes usuario = new UsuarioRes();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarUsuarios", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuario = new UsuarioRes
                        {                            
                            UsuarioId = Convert.ToInt32(rdr["UsuarioId"]),                            
                            Nombres = Convert.ToString(rdr["Nombres"]),                            
                            Apellidos = Convert.ToString(rdr["Apellidos"]),    
                            Correo = Convert.ToString(rdr["Correo"]),
                            Rol = Convert.ToString(rdr["Rol"]),
                            ContactoId = Convert.ToInt32(rdr["ContactoId"]),
                            TelefonoContacto = Convert.ToString(rdr["TelefonoContacto"]),
                        };
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene los Usuarios
        /// </summary>
        /// <returns>Usuarios</returns>
        public List<UsuarioRes> ObtenerUsuarios()
        {

            List<UsuarioRes> usuarios = new List<UsuarioRes>();

            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("ConsultarUsuarios", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuarios.Add(new UsuarioRes
                        {
                            UsuarioId = Convert.ToInt32(rdr["UsuarioId"]),
                            Nombres = Convert.ToString(rdr["Nombres"]),
                            Apellidos = Convert.ToString(rdr["Apellidos"]),
                            Correo = Convert.ToString(rdr["Correo"]),
                            Rol = Convert.ToString(rdr["Rol"]),
                            ContactoId = Convert.ToInt32(rdr["ContactoId"]),
                            TelefonoContacto = Convert.ToString(rdr["TelefonoContacto"]),
                        });
                    }
                    rdr.Close();

                }
                cnx.Close();
            }

            return usuarios;
        }

        /// <summary>
        /// Obtiene los Usuarios
        /// </summary>
        /// <returns>Usuarios</returns>
        public void GuardarUsuario(UsuarioReq UsuarioReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", UsuarioReq.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", UsuarioReq.Apellidos);
                    cmd.Parameters.AddWithValue("@Correo", UsuarioReq.Correo);
                    cmd.Parameters.AddWithValue("@Contrasena", UsuarioReq.Contrasena);
                    cmd.Parameters.AddWithValue("@Rol", UsuarioReq.RolId);
                    cmd.Parameters.AddWithValue("@Telefono", UsuarioReq.TelefonoContacto);
                    cmd.Parameters.AddWithValue("@ContactoId", UsuarioReq.ContactoId);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", UsuarioReq.UsuarioCreacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Editar los Usuarios
        /// </summary>
        /// <param name="UsuarioReq"></param>
        public void EditarUsuario(UsuarioReq UsuarioReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EditarUsuario", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", UsuarioReq.UsuarioId);
                    cmd.Parameters.AddWithValue("@Nombres", UsuarioReq.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", UsuarioReq.Apellidos);
                    cmd.Parameters.AddWithValue("@Correo", UsuarioReq.Correo);
                    cmd.Parameters.AddWithValue("@Rol", UsuarioReq.RolId);
                    cmd.Parameters.AddWithValue("@Telefono", UsuarioReq.TelefonoContacto);
                    cmd.Parameters.AddWithValue("ContactoId", UsuarioReq.ContactoId);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", UsuarioReq.UsuarioCreacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }

        /// <summary>
        /// Eliminar los Usuarios
        /// </summary>
        /// <param name="UsuarioReq"></param>
        public void EliminarUsuario(UsuarioReq UsuarioReq)
        {
            using (SqlConnection cnx = new SqlConnection(pruebaMVM))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", UsuarioReq.UsuarioId);
                    cmd.Parameters.AddWithValue("@UsuarioModificacion", UsuarioReq.UsuarioModificacion);
                    cmd.ExecuteReader();

                }
                cnx.Close();
            }
        }
    }
}
