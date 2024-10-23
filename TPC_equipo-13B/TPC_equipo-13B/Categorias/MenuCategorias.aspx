<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuCategorias.aspx.cs" Inherits="TPC_equipo_13B.Categorias.MenuCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Categorias</h2>

            <div class="menu">
                <a href="VerCategorias.aspx">Mostrar Todo</a>
                <a href="FormCategorias.aspx">Agregar</a>
                <a href="#">Buscar</a>

            </div>
        </div>
    </div>
</asp:Content>
