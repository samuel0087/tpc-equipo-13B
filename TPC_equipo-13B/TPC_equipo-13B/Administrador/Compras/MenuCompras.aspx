<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuCompras.aspx.cs" Inherits="TPC_equipo_13B.Compras.MenuCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-6 main">
            <h2>Compra</h2>

            <div class="menu">
                <a href="<%: ResolveUrl("~/Administrador/Compras/FormCompras.aspx") %>">Nueva compra</a>
                <a href="<%: ResolveUrl("~/Administrador/Compras/ListadoCompras.aspx") %>">Historico de Compras</a>

            </div>
        </div>
    </div>
</asp:Content>
