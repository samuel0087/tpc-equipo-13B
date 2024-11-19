<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="compraexito.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web118" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Resumen de Compra</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-3">Resumen de Compra</h2>
        
        <!-- Información del proveedor y usuario -->
        <div class="mb-3">
            <strong>Proveedor:</strong> 
            <asp:Label ID="lblProveedor" runat="server" CssClass="form-control-plaintext"></asp:Label>
        </div>
        <div class="mb-3">
            <strong>Usuario:</strong> 
            <asp:Label ID="lblUsuario" runat="server" CssClass="form-control-plaintext"></asp:Label>
        </div>
            <div class="mb-3">
            <strong>Fecha de Compra:</strong>
            <asp:Label ID="lblFechaCompra" runat="server" CssClass="form-control-plaintext"></asp:Label>
        </div>
        <!-- Tabla de productos -->
        <h4>Productos</h4>
        <table class="table">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Cantidad</th>
                    <th>Precio Total</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptProductos" runat="server">
                  <ItemTemplate>
    <tr runat="server" visible='<%# Convert.ToInt32(Eval("Cantidad")) > 0 %>'>
        <td><%# Eval("NombreProducto") %></td>
        <td><%# Eval("Cantidad") %></td>
        <td><%# Eval("PrecioTotal", "{0:C}") %></td>
    </tr>
</ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <!-- Total -->
        <div class="mt-3">
            <strong>Total a Pagar:</strong> 
            <asp:Label ID="lblTotal" runat="server" CssClass="form-control-plaintext fs-5 fw-bold"></asp:Label>
        </div>

        <!-- Botones -->
        <div class="mt-4">
            <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" CssClass="btn btn-success" OnClick="btnFinalizar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger ms-2" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
