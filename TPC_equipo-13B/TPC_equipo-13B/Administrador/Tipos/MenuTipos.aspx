<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuTipos.aspx.cs" Inherits="TPC_equipo_13B.Tipos.MenuTipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-6 main">
            <h2>Tipo de Productos</h2>

            <div class="menu">
                <a href="VerTipos.aspx">Mostrar Todo</a>
                <a href="FormTipos.aspx">Agregar</a>
                <a href="VerTipos.aspx?Buscar=true">Buscar</a>

            </div>
        </div>
    </div>
</asp:Content>
