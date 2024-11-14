<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormCompras.aspx.cs" Inherits="TPC_equipo_13B.Compras.FormCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-6 main">
            <h2>Nueva Compra</h2>
                       <asp:ScriptManager ID="ScriptManager1" runat="server" />

           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   
                   <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" AssociatedControlID="ddlProveedor"></asp:Label>
                   <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control">
                       <asp:ListItem Text="Seleccione un Proveedor" Value="" />
                   </asp:DropDownList>

                   <h3>Productos</h3>
                 <asp:Repeater ID="rptProductos" runat="server" OnItemDataBound="rptProductos_ItemDataBound">
    <HeaderTemplate>
        <table class="table">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Cantidad</th>
                    <th>Precio</th> <!-- Nueva columna para el precio -->
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
               <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
               <asp:ListItem Text="Seleccione un producto" Value="" />
              </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" Min="1" Placeholder="Cantidad"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblPrecio" runat="server" CssClass="form-control"></asp:Label> <!-- Control para mostrar el precio -->
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
        <asp:Button ID="btnAddProduct" runat="server" CssClass="btn btn-primary" Text="Agregar Producto" OnClick="btnAddProduct_Click" />
    </FooterTemplate>
</asp:Repeater>

                   <asp:Button ID="btnConfirmarVenta" runat="server" CssClass="btn btn-success" Text="Confirmar Venta" OnClick="btnConfirmarVenta_Click" />
               </ContentTemplate>
           </asp:UpdatePanel>
       </div>
   </div>

</asp:Content>
