<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuClientes.aspx.cs" Inherits="TPC_equipo_13B.Administrador.Clientes.MenuClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-6 main">
            <h2>Clientes</h2>

            <div class="menu">
                <a href="VerClientes.aspx">Mostrar Todo</a>
                <a href="FormClientes.aspx">Agregar</a>

            </div>
        </div>
    </div>
</asp:Content>
