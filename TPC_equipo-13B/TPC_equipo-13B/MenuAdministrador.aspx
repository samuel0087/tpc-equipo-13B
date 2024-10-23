<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="TPC_equipo_13B.MenuAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Administrador</h2>

            <div class="menu">
                <a href="marcas/MenuMarcas.aspx">Marcas</a>
                <a href="<%=ResolveUrl("~/Categorias/MenuCategorias.aspx") %>">Categorias</a>
                <a href="#">Tipos de productos</a>
                <a href="#">Productos</a>
                <a href="#">Proveedores</a>
                <a href="<%=ResolveUrl("~/Usuarios/Usuario.aspx") %>">Usuarios</a>
            </div>
        </div>
    </div>
</asp:Content>
