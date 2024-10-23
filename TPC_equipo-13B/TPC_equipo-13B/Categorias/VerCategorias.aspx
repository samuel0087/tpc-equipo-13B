<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="VerCategorias.aspx.cs" Inherits="TPC_equipo_13B.Categorias.VerCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Categorias</h2>

            <asp:GridView runat="server" ID="dgvCategorias" DataKeyNames="IdCategoria" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" CssClass="table" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Categoria" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver"  ControlStyle-CssClass="btn btn-primary" HeaderText="Detalles" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
