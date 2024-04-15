using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class ImagenManager
{
    private readonly string _connectionString;

    public ImagenManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Método para guardar una imagen en la base de datos
    public void GuardarImagen(int id, byte[] imagen, string tipo)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "";
            if (tipo == "Usuario")
            {
                query = "UPDATE Usuarios SET Foto = @Imagen WHERE IdUsuario = @Id";
            }
            else if (tipo == "Producto")
            {
                query = "UPDATE Productos SET FotoProducto = @Imagen WHERE IdProducto = @Id";
            }

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Imagen", imagen);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener una imagen de la base de datos
    public byte[] ObtenerImagen(int id, string tipo)
    {
        byte[] imagen = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "";
            if (tipo == "Usuario")
            {
                query = "SELECT Foto FROM Usuarios WHERE IdUsuario = @Id";
            }
            else if (tipo == "Producto")
            {
                query = "SELECT FotoProducto FROM Productos WHERE IdProducto = @Id";
            }

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        imagen = (byte[])reader["Foto"];
                    }
                }
            }
        }

        return imagen;
    }

    // Método para convertir una imagen a bytes
    public byte[] ImagenToBytes(string rutaImagen)
    {
        byte[] imagenBytes = null;
        if (File.Exists(rutaImagen))
        {
            imagenBytes = File.ReadAllBytes(rutaImagen);
        }
        return imagenBytes;
    }
}