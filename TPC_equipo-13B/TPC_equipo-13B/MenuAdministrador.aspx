<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="TPC_equipo_13B.MenuAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Administrador</h2>

            <div class="menu">
                <a href="<%=ResolveUrl("~/Administrador/marcas/MenuMarcas.aspx") %>">Marcas</a>
                <a href="<%=ResolveUrl("~/Administrador/Categorias/MenuCategorias.aspx") %>">Categorias</a>
                <a href="<%=ResolveUrl("~/Administrador/Tipos/MenuTipos.aspx") %>">Tipos de productos</a>
                <a href="<%=ResolveUrl("~/Administrador/Productos/MenuProductos.aspx") %>">Productos</a>
                <a href="<%=ResolveUrl("~/Administrador/Proveedores/Proveedores.aspx") %>">Proveedores</a>
                <a href="<%=ResolveUrl("~/Administrador/Usuarios/Usuario.aspx") %>">Usuarios</a>
                <a href="<%=ResolveUrl("~/Administrador/stock/menustock.aspx") %>">stock</a>
                <a href="<%=ResolveUrl("~/Administrador/Clientes/MenuClientes.aspx") %>">Clientes</a>
            </div>
        </div>
    </div>
</asp:Content>
