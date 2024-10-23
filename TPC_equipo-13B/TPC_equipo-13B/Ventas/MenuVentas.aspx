<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="MenuVentas.aspx.cs" Inherits="TPC_equipo_13B.Ventas.MenuVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Ventas</h2>

            <div class="menu">
                <a href="<%: ResolveUrl("~/Ventas/FormVentas.aspx") %>">Nueva venta</a>
                <a href="<%: ResolveUrl("~/Ventas/ListadoVentas.aspx") %>">Historico de ventas</a>

            </div>
        </div>
    </div>
</asp:Content>
