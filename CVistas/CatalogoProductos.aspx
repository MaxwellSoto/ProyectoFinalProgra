<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catálogo de Productos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Catálogo de Productos</h1>
            <asp:GridView ID="GridViewProductos" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewProductos_RowEditing" OnRowCancelingEdit="GridViewProductos_RowCancelingEdit" OnRowUpdating="GridViewProductos_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" ReadOnly="true" />
                    <asp:BoundField DataField="IdCategoria" HeaderText="IdCategoria" ReadOnly="true" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" />
                    <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" />
                    <asp:BoundField DataField="FechaVencimiento" HeaderText="FechaVencimiento" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>