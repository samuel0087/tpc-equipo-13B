﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormCategorias.aspx.cs" Inherits="TPC_equipo_13B.Categorias.FormCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Formulario Categorias</h2>


            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Label Text="Nombre" ID="lblNombreCategoria" CssClass="form-label" runat="server" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreCategoria" AutoPostBack="true" OnTextChanged="txtNombreCategoria_TextChanged" />
                        <asp:Label Text="" runat="server" ID="lblError" />
                    </div>

                     <%if (!confirmarEliminacion){%>
                        <div class="mb-3 button-container">
                            <asp:Button Text="Añadir" ID="btnAñadir" CssClass="btn btn-primary" runat="server" OnClick="btnAñadir_Click" />
                            <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-primary" runat="server" OnClick="btnModificar_Click1" />
                            <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" />
                        </div>
                    <%} %>

                    <%if (confirmarEliminacion){%>
                        <div class="mb-3">
                            <span class="form-label button-container">¿Esta seguro que desea eliminar?</span>
                            <div class="button-container">
                                <asp:Button Text="Eliminar" ID="btnConfrimarEliminacion" CssClass="btn btn-outline-danger" runat="server" OnClick="btnConfrimarEliminacion_Click" />
                                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn btn-outline-secondary" runat="server" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    <%} %>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
