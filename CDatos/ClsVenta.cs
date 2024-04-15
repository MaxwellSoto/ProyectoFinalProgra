using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class VentaManager
{
    private readonly string _connectionString;

    public VentaManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Método para agregar una nueva venta
    public void AgregarVenta(Venta venta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"INSERT INTO Ventas (IdEmpleado, IdCliente, Serie, NroDocumento, TipoDocumento, FechaVenta, Total) 
                             VALUES (@IdEmpleado, @IdCliente, @Serie, @NroDocumento, @TipoDocumento, @FechaVenta, @Total)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdEmpleado", venta.IdEmpleado);
                command.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                command.Parameters.AddWithValue("@Serie", venta.Serie);
                command.Parameters.AddWithValue("@NroDocumento", venta.NroDocumento);
                command.Parameters.AddWithValue("@TipoDocumento", venta.TipoDocumento);
                command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                command.Parameters.AddWithValue("@Total", venta.Total);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener una venta por su IdVenta
    public Venta ObtenerVentaPorId(int idVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Ventas WHERE IdVenta = @IdVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Venta
                        {
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Serie = reader["Serie"].ToString(),
                            NroDocumento = reader["NroDocumento"].ToString(),
                            TipoDocumento = reader["TipoDocumento"].ToString(),
                            FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                            Total = Convert.ToDecimal(reader["Total"])
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

    // Método para actualizar una venta existente
    public void ActualizarVenta(Venta venta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"UPDATE Ventas 
                             SET IdEmpleado = @IdEmpleado, 
                                 IdCliente = @IdCliente, 
                                 Serie = @Serie, 
                                 NroDocumento = @NroDocumento, 
                                 TipoDocumento = @TipoDocumento, 
                                 FechaVenta = @FechaVenta, 
                                 Total = @Total 
                             WHERE IdVenta = @IdVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdEmpleado", venta.IdEmpleado);
                command.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                command.Parameters.AddWithValue("@Serie", venta.Serie);
                command.Parameters.AddWithValue("@NroDocumento", venta.NroDocumento);
                command.Parameters.AddWithValue("@TipoDocumento", venta.TipoDocumento);
                command.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                command.Parameters.AddWithValue("@Total", venta.Total);
                command.Parameters.AddWithValue("@IdVenta", venta.IdVenta);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para eliminar una venta por su IdVenta
    public void EliminarVenta(int idVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Ventas WHERE IdVenta = @IdVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener todas las ventas
    public List<Venta> ObtenerTodasLasVentas()
    {
        List<Venta> ventas = new List<Venta>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Ventas";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ventas.Add(new Venta
                        {
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Serie = reader["Serie"].ToString(),
                            NroDocumento = reader["NroDocumento"].ToString(),
                            TipoDocumento = reader["TipoDocumento"].ToString(),
                            FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                            Total = Convert.ToDecimal(reader["Total"])
                        });
                    }
                }
            }
        }

        return ventas;
    }
}