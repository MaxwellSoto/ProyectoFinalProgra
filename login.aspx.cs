using proyectoFinal.CDatos;
using System;
using System.Web.UI;

namespace proyectoFinal
{
    public partial class WebForm1 : Page
    {
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContra.Text;

            int resultado = ClsUsuario.Ingresar(username, password);

            if (resultado == 1)
            {
                Response.Redirect("CVistas/Inicio.aspx");
            }
            else
            {
                Response.Write($"<script>alert('Usuario o contraseña incorrectos: {username} y {password}');</script>");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CVistas/Registrar.aspx");
        }
    }
}
