using System;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinal
{
    public partial class Reportes : System.Web.UI.Page
    {
        private string connectionString = "tu_cadena_de_conexion";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnReporteCatalogos_Click(object sender, EventArgs e)
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

        protected void btnFiltrarVentas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fechaFin = Convert.ToDateTime(txtFechaFin.Text);

            string query = "SELECT * FROM Ventas WHERE FechaVenta BETWEEN @FechaInicio AND @FechaFin"; 

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin),
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
}