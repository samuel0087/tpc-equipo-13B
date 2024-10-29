<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuProductos.aspx.cs" Inherits="TPC_equipo_13B.Productos.MenuProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-6 main">
            <h2>Productos</h2>

            <div class="menu">
                <a href="VerProductos.aspx">Mostrar Todo</a>
                <a href="FormProducto.aspx">Agregar</a>
                <a href="VerProductos.aspx?Buscar=true">Buscar</a>

            </div>
        </div>
    </div>
</asp:Content>
