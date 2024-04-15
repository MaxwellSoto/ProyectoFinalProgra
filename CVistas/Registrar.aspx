<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="proyectoFinal.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../lib/css/registro.css">
    <title>Registro de Usuario</title>
</head>
<body>

    <form id="registro" runat="server">
        <div class="body"></div>
        <div class="grad"></div>
        <div class="header">
            <div>Registro de Usuario</div>
        </div>
        <br />
        <div class="registro">
            <asp:TextBox ID="txtNuevoUsuario" runat="server" CssClass="input-field" placeholder="Nuevo Usuario"></asp:TextBox><br />
            <asp:TextBox ID="txtNuevaContraseña" runat="server" CssClass="input-field" TextMode="Password" placeholder="Nueva Contraseña"></asp:TextBox><br />
            <asp:TextBox ID="txtDNI" runat="server" CssClass="input-field" placeholder="DNI" maxlength="8"></asp:TextBox><br />
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="input-field" placeholder="Apellidos" maxlength="255"></asp:TextBox><br />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-field" placeholder="Nombre" maxlength="255"></asp:TextBox><br />
            <asp:DropDownList ID="listSexo" runat="server" CssClass="input-field">
                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                <asp:ListItem Text="Otro" Value="O"></asp:ListItem> 
            </asp:DropDownList><br />
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="input-field" placeholder="Direccion" maxlength="255"></asp:TextBox><br />
            <asp:DropDownList ID="listEstadoCivil" runat="server" CssClass="input-field">
                <asp:ListItem Text="Soltero" Value="Soltero"></asp:ListItem>
                <asp:ListItem Text="Casado" Value="Casado"></asp:ListItem>
                <asp:ListItem Text="Divorciado" Value="Divorciado"></asp:ListItem>
                <asp:ListItem Text="Complicado" Value="Complicado"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="btnCrearUsuario" runat="server" CssClass="btn-submit" Text="Crear Usuario" OnClick="btnCrearUsuario_Click" />
        </div>
    </form>

</body>
</html>
