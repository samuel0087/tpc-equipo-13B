<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="ModificarStock.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web122" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modificar Cantidad de Stock</h1>

    <asp:Panel ID="pnlModificarStock" runat="server" CssClass="form-container">
        <asp:Label ID="lblIdProducto" runat="server" Text="ID Producto:" CssClass="form-label"></asp:Label>
        <asp:Label ID="lblProductoIdValue" runat="server" CssClass="form-value"></asp:Label>
        <br />

        <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre del Producto:" CssClass="form-label"></asp:Label>
        <asp:Label ID="lblNombreProductoValue" runat="server" CssClass="form-value"></asp:Label>
        <br />

        <asp:Label ID="lblCantidadActual" runat="server" Text="Cantidad Actual:" CssClass="form-label"></asp:Label>
        <asp:Label ID="lblCantidadActualValue" runat="server" CssClass="form-value"></asp:Label>
        <br />

        <asp:Label ID="lblNuevaCantidad" runat="server" Text="Nueva Cantidad:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtNuevaCantidad" runat="server" CssClass="form-input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtNuevaCantidad" ErrorMessage="La nueva cantidad es requerida." CssClass="error-message"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvCantidad" runat="server" ControlToValidate="txtNuevaCantidad" MinimumValue="0" MaximumValue="1000000" Type="Integer" ErrorMessage="La cantidad debe ser un número válido." CssClass="error-message"></asp:RangeValidator>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" PostBackUrl="~/verstock.aspx" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="success-message" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
