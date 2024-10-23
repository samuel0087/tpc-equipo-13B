<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="ListadoCompras.aspx.cs" Inherits="TPC_equipo_13B.Compras.ListadoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <a href="MenuCompras.aspx"><- VOLVER</a>
        <div class="col-6 main">
            <h2>Historico de Compras</h2>


            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
