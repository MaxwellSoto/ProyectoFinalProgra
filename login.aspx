<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="proyectoFinal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="lib/css/login.css" /> <!-- Vinculación del archivo CSS -->
    <title></title>
</head>
<body>

    <form id="login" runat="server">
        <div class="body"></div>
        <div class="grad"></div>
        <a href="Controlador/">Controlador/</a>
        <div class="header">
            <div>Grupo <span>IV</span></div>
        </div>
        <br />
        <div class="login">
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox><br />
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox><br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn-submit" Text="Registrarse" OnClick="btnRegistrar_Click" />
        </div>
    </form>

</body>
</html>
