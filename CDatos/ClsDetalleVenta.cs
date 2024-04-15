using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DetalleVentaManager
{
    private readonly string _connectionString;

    public DetalleVentaManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Método para agregar un nuevo detalle de venta
    public void AgregarDetalleVenta(DetalleVenta detalleVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"INSERT INTO DetalleVentas (IdProducto, IdVenta, Cantidad, PrecioUnitario, Igv, Subtotal) 
                             VALUES (@IdProducto, @IdVenta, @Cantidad, @PrecioUnitario, @Igv, @Subtotal)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdProducto", detalleVenta.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", detalleVenta.IdVenta);
                command.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", detalleVenta.PrecioUnitario);
                command.Parameters.AddWithValue("@Igv", detalleVenta.Igv);
                command.Parameters.AddWithValue("@Subtotal", detalleVenta.Subtotal);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener un detalle de venta por su IdDetalleVenta
    public DetalleVenta ObtenerDetalleVentaPorId(int idDetalleVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM DetalleVentas WHERE IdDetalleVenta = @IdDetalleVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DetalleVenta
                        {
                            IdDetalleVenta = Convert.ToInt32(reader["IdDetalleVenta"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                            Igv = Convert.ToDecimal(reader["Igv"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"])
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

    // Método para actualizar un detalle de venta existente
    public void ActualizarDetalleVenta(DetalleVenta detalleVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"UPDATE DetalleVentas 
                             SET IdProducto = @IdProducto, 
                                 IdVenta = @IdVenta, 
                                 Cantidad = @Cantidad, 
                                 PrecioUnitario = @PrecioUnitario, 
                                 Igv = @Igv, 
                                 Subtotal = @Subtotal 
                             WHERE IdDetalleVenta = @IdDetalleVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdProducto", detalleVenta.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", detalleVenta.IdVenta);
                command.Parameters.AddWithValue("@Cantidad", detalleVenta.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", detalleVenta.PrecioUnitario);
                command.Parameters.AddWithValue("@Igv", detalleVenta.Igv);
                command.Parameters.AddWithValue("@Subtotal", detalleVenta.Subtotal);
                command.Parameters.AddWithValue("@IdDetalleVenta", detalleVenta.IdDetalleVenta);

                command.ExecuteNonQuery();
            }
        }
    }

    // Método para eliminar un detalle de venta por su IdDetalleVenta
    public void EliminarDetalleVenta(int idDetalleVenta)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM DetalleVentas WHERE IdDetalleVenta = @IdDetalleVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);
                command.ExecuteNonQuery();
            }
        }
    }

    // Método para obtener todos los detalles de venta de una venta específica por su IdVenta
    public List<DetalleVenta> ObtenerDetallesVentaPorIdVenta(int idVenta)
    {
        List<DetalleVenta> detallesVenta = new List<DetalleVenta>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM DetalleVentas WHERE IdVenta = @IdVenta";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detallesVenta.Add(new DetalleVenta
                        {
                            IdDetalleVenta = Convert.ToInt32(reader["IdDetalleVenta"]),
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                            Igv = Convert.ToDecimal(reader["Igv"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"])
                        });
                    }
                }
            }
        }

        return detallesVenta;
    }
}