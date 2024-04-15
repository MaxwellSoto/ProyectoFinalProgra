using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class ProductoManager
{
    private readonly string _connectionString;

    public ProductoManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Método para agregar un nuevo producto
    public void AgregarProducto(Producto producto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"INSERT INTO Productos (IdCategoria, Nombre, Marca, Stock, PrecioCompra, PrecioVenta, FechaVencimiento) 
                             VALUES (@IdCategoria, @Nombre, @Marca, @Stock, @PrecioCompra, @PrecioVenta, @FechaVencimiento)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Marca", producto.Marca);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@FechaVencimiento", producto.FechaVencimiento);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener un producto por su IdProducto
    public Producto ObtenerProductoPorId(int idProducto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Productos WHERE IdProducto = @IdProducto";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto
                        {
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            Nombre = reader["Nombre"].ToString(),
                            Marca = reader["Marca"].ToString(),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                            PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }

    // Método para actualizar un producto existente
    public void ActualizarProducto(Producto producto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"UPDATE Productos 
                             SET IdCategoria = @IdCategoria, 
                                 Nombre = @Nombre, 
                                 Marca = @Marca, 
                                 Stock = @Stock, 
                                 PrecioCompra = @PrecioCompra, 
                                 PrecioVenta = @PrecioVenta, 
                                 FechaVencimiento = @FechaVencimiento 
                             WHERE IdProducto = @IdProducto";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Marca", producto.Marca);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@FechaVencimiento", producto.FechaVencimiento);
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para eliminar un producto por su IdProducto
    public void EliminarProducto(int idProducto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener todos los productos
    public List<Producto> ObtenerTodosLosProductos()
    {
        List<Producto> productos = new List<Producto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Productos";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            Nombre = reader["Nombre"].ToString(),
                            Marca = reader["Marca"].ToString(),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                            PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"])
                        });
                    }
                }
            }
        }

        return productos;
    }
}