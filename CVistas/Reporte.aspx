<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Reportes</h1>
            <asp:Button ID="btnReporteCatalogos" runat="server" Text="Reporte de Catálogos" OnClick="btnReporteCatalogos_Click" />
            <br />
            <br />
            <asp:Label ID="lblFiltros" runat="server" Text="Filtrar Reporte de Ventas:" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtFechaInicio" runat="server" Visible="false"></asp:TextBox>
            <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtFechaFin" runat="server" Visible="false"></asp:TextBox>
            <asp:Button ID="btnFiltrarVentas" runat="server" Text="Filtrar Ventas" OnClick="btnFiltrarVentas_Click" Visible="false" />
        </div>
    </form>
</body>
</html>