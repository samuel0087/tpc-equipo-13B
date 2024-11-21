<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="verstock.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web121" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Stock</h1>
<asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvStock_RowCommand">
    <Columns>
        
        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />

       
        <asp:BoundField DataField="NombreProducto" HeaderText="Nombre" />

       
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

   
    </Columns>
</asp:GridView>
    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
</asp:Content>
