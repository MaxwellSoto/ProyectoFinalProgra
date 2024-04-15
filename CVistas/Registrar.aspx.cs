using proyectoFinal.CDatos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace proyectoFinal
{
    public partial class Registrar : Page
    {
        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string nuevoUsuario = txtNuevoUsuario.Text;
            string nuevaContraseña = txtNuevaContraseña.Text;
            string dni = txtDNI.Text;
            string apellidos = txtApellidos.Text;
            string nombre = txtNombre.Text;
            string sexo = listSexo.Text;
            string direccion = txtDireccion.Text;
            string estadoCivil = listEstadoCivil.Text;

            int resultado = ClsUsuario.verificarUsuario(nuevoUsuario);
            if (resultado == 1)
            {
                Response.Write($"<script>alert('El usuario {nuevoUsuario} ya existe, intente con otro usuario');</script>");
            }
            else
            {
                // Crear el empleado
                int nuevoIdEmpleado = ClsEmpleado.CrearEmpleado(2, dni, apellidos, nombre, sexo, direccion, estadoCivil);
                if (nuevoIdEmpleado > 0)
                {
                    // El empleado se creó correctamente
                    int resultadoCrearUsuario = ClsUsuario.CrearUsuario(nuevoIdEmpleado, nuevoUsuario, nuevaContraseña);
                    if (resultadoCrearUsuario > 0)
                    {
                        Response.Write($"<script>alert('El usuario {nuevoUsuario} fue creado con éxito, su ID de empleado es {nuevoIdEmpleado}');</script>");
                    }
                    else
                    {
                        Response.Write($"<script>alert('El usuario {nuevoUsuario} no pudo ser creado');</script>");
                    }
                }
                else
                {
                    Response.Write($"<script>alert('El empleado no pudo ser creado');</script>");
                }


            }
        }
    }
}
