using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace proyectoFinal
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            string connectionString = "tu_cadena_de_conexion";
            string query = "SELECT IdProducto, IdCategoria, Nombre, Marca, Stock, PrecioCompra, PrecioVenta, FechaVencimiento FROM Productos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    GridViewProductos.DataSource = reader;
                    GridViewProductos.DataBind();

                    reader.Close();
                }
            }
        }

        protected void GridViewProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProductos.EditIndex = e.NewEditIndex;
            CargarProductos();
        }

        protected void GridViewProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProductos.EditIndex = -1;
            CargarProductos();
        }

        protected void GridViewProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewProductos.Rows[e.RowIndex];
            int idProducto = Convert.ToInt32(GridViewProductos.DataKeys[e.RowIndex].Value);

            TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
            TextBox txtMarca = (TextBox)row.FindControl("txtMarca");
            TextBox txtStock = (TextBox)row.FindControl("txtStock");
            TextBox txtPrecioCompra = (TextBox)row.FindControl("txtPrecioCompra");
            TextBox txtPrecioVenta = (TextBox)row.FindControl("txtPrecioVenta");
            TextBox txtFechaVencimiento = (TextBox)row.FindControl("txtFechaVencimiento");

            string nombre = txtNombre.Text;
            string marca = txtMarca.Text;
            int stock = Convert.ToInt32(txtStock.Text);
            decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
            decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            DateTime fechaVencimiento = Convert.ToDateTime(txtFechaVencimiento.Text);

            ActualizarProducto(idProducto, nombre, marca, stock, precioCompra, precioVenta, fechaVencimiento);

            GridViewProductos.EditIndex = -1;
            CargarProductos();
        }

        private void ActualizarProducto(int idProducto, string nombre, string marca, int stock, decimal precioCompra, decimal precioVenta, DateTime fechaVencimiento)
        {
            string connectionString = "tu_cadena_de_conexion";
            string query = "UPDATE Productos SET Nombre = @Nombre, Marca = @Marca, Stock = @Stock, PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, FechaVencimiento = @FechaVencimiento WHERE IdProducto = @IdProducto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Marca", marca);
                    command.Parameters.AddWithValue("@Stock", stock);
                    command.Parameters.AddWithValue("@PrecioCompra", precioCompra);
                    command.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                    command.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                    command.Parameters.AddWithValue("@IdProducto", idProducto);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}