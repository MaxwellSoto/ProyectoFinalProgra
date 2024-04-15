using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace proyectoFinal.CDatos
{
    public class ClsUsuario
    {
        public static int Ingresar(string username, string password)
        {
            int resultado = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["proyectoConexion"].ConnectionString;

            string consulta = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Username AND Contraseña = @Password";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Username", username);
                    comando.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conexion.Open();
                        resultado = (int)comando.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al intentar autenticar al usuario: " + ex.Message);
                    }
                }
            }

            return resultado;
        }

        public static int verificarUsuario(string username)
        {
            int resultado = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["proyectoConexion"].ConnectionString;
            string consulta = "EXEC verificarUsuario @Usuario";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", username);

                    try
                    {
                        conexion.Open();
                        resultado = (int)comando.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }

                }
            }

            return resultado;
        }

        public static int CrearUsuario(int idEmpleado, string usuario, string contraseña)
        {
            int idNuevoUsuario = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["proyectoConexion"].ConnectionString;
            string consulta = "EXEC CrearUsuarioNuevo @IdEmpleado, @Usuario, @Contraseña";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idNuevoUsuario = reader.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }
                }
            }

            return idNuevoUsuario;
        }

    }

    }

