using System;
using System.Collections.Generic;

public class FacturacionManager
{
    private List<Producto> productosFacturados;

    public FacturacionManager()
    {
        productosFacturados = new List<Producto>();
    }

    public void AgregarProductoFacturado(Producto producto)
    {
        productosFacturados.Add(producto);
    }

    public void RemoverProductoFacturado(Producto producto)
    {
        productosFacturados.Remove(producto);
    }

    public void LimpiarProductosFacturados()
    {
        productosFacturados.Clear();
    }

    public decimal CalcularTotalFactura()
    {
        decimal total = 0;

        foreach (var producto in productosFacturados)
        {
            total += producto.PrecioVenta;
        }

        return total;
    }

    public void FacturarProductos()
    {
        GuardarProductosEnBaseDeDatos();
              GenerarDocumentoFacturaTXT();
    }
}

private void GuardarProductosEnBaseDeDatos()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["proyectoConexion"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            foreach (var producto in productosFacturados)
            {
                string query = "INSERT INTO FacturaProductos (IdProducto, IdCategoria, Nombre, Marca, Stock, PrecioVenta, FechaVencimiento) VALUES (@IdProducto, @IdCategoria, @Nombre, @Marca, @Stock, @PrecioVenta, @FechaVencimiento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@FechaVencimiento", producto.FechaVencimiento);

                    command.ExecuteNonQuery();
                }
            }
        }
    }

      private void GenerarDocumentoFacturaTXT()
    {
        string rutaArchivo = "factura.txt";

        using (StreamWriter sw = new StreamWriter(rutaArchivo))
        {
            sw.WriteLine("----- Factura -----");
            sw.WriteLine($"Fecha: {DateTime.Now}");
            sw.WriteLine("Productos:");

            foreach (var producto in productosFacturados)
            {
                sw.WriteLine($"- {producto.Nombre}, Marca: {producto.Marca}, Precio: {producto.PrecioVenta}");
            }

            sw.WriteLine($"Total: {CalcularTotalFactura()}");
        }
    }
}


public class Producto
{
    public int IdProducto { get; set; }
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }
    public string Marca { get; set; }
    public int Stock { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public DateTime FechaVencimiento { get; set; }
}