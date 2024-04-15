using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class ReporteManager
{
    private string connectionString;

    public ReporteManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void ImprimirReporteCatalogos()
    {
        string query = "SELECT * FROM Productos";

        DataTable dt = ExecuteQuery(query);

        if (dt.Rows.Count > 0)
        {
            StringBuilder reporte = new StringBuilder();
            reporte.AppendLine("----- Reporte de Catálogos -----");
            foreach (DataRow row in dt.Rows)
            {
                reporte.AppendLine($"ID: {row["Id"]}, Nombre: {row["Nombre"]}, Descripción: {row["Descripcion"]}");
            }

            Console.WriteLine(reporte.ToString());
        }
        else
        {
            Console.WriteLine("No hay datos para mostrar en el reporte de catálogos.");
        }
    }

    public void ImprimirReporteVentas(DateTime fechaInicio, DateTime fechaFin, int idCliente, int idProducto)
    {
        string query = "SELECT * FROM Ventas WHERE FechaVenta";

        if (idCliente != 0)
        {
            query += " AND IdCliente = @IdCliente";
        }

        if (idProducto != 0)
        {
            query += " AND IdProducto = @IdProducto";
        }

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@FechaInicio", fechaInicio),
            new SqlParameter("@FechaFin", fechaFin),
            new SqlParameter("@IdCliente", idCliente),
            new SqlParameter("@IdProducto", idProducto)
        };

        DataTable dt = ExecuteQuery(query, parameters);

        if (dt.Rows.Count > 0)
        {
            StringBuilder reporte = new StringBuilder();
            reporte.AppendLine("----- Reporte de Ventas -----");
            foreach (DataRow row in dt.Rows)
            {
                reporte.AppendLine($"ID: {row["Id"]}, Fecha: {row["FechaVenta"]}, Cliente: {row["IdCliente"]}, Producto: {row["IdProducto"]}, Total: {row["Total"]}");
            }

            Console.WriteLine(reporte.ToString());
        }
        else
        {
            Console.WriteLine("No hay datos para mostrar en el reporte de ventas con los filtros seleccionados.");
        }
    }

    private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
        }

        return dt;
    }
}