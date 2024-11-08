<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_equipo_13B.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>¡Bienvenido!</h2>

            <div class="menu">
                <a href="<%: ResolveUrl("~/Ventas/MenuVentas.aspx") %>">Ventas</a>

                <%if (Session["Admin"] != null) {%>

                    <%if ((bool)Session["admin"]) { %>
                            <a href="<%: ResolveUrl("~/Administrador/Compras/MenuCompras.aspx") %>">Compras</a>
                            <a href="<%: ResolveUrl("~/MenuAdministrador.aspx") %>">Administrar</a>
                    <%}%>

                <%} %>
                
                <a href="<%: ResolveUrl("~/Logout.aspx") %>">Cerrar Sesion</a>

            </div>
        </div>
    </div>
</asp:Content>
