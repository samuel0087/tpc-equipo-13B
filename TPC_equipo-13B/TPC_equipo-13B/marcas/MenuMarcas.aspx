<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuMarcas.aspx.cs" Inherits="TPC_equipo_13B.MenuMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Marcas</h2>

            <div class="menu">
                <a href="VerMarcas.aspx">Mostrar Todo</a>
                <a href="FormMarca.aspx">Agregar</a>
                <a href="#">Modificar</a>
                <a href="#">Eliminar</a>

            </div>
        </div>
    </div>
</asp:Content>
