using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinal.CDatos
{
    public class ClsEmpleado
    {
        public static int CrearEmpleado(int idCargo, string dni, string apellidos, string nombre, string sexo, string direccion, string estadoCivil)
        {
            int nuevoIdEmpleado = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["proyectoConexion"].ConnectionString;
            string consulta = "EXEC CrearEmpleadoNuevo @IdCargo, @DNI, @Apellidos, @Nombre, @Sexo, @Direccion, @EstadoCivil";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCargo", idCargo);
                    comando.Parameters.AddWithValue("@DNI", dni);
                    comando.Parameters.AddWithValue("@Apellidos", apellidos);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Sexo", sexo);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@EstadoCivil", estadoCivil);

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nuevoIdEmpleado = reader.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    }
                }
            }

            return nuevoIdEmpleado;
        }

    }
}
