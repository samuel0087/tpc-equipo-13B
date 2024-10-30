<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6 main">
    <h2>Formulario Producto</h2>

    <asp:ScriptManager runat="server" id="ScriptManager1"/>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <label>Codigo:</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Nombre:</label>
                    <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Marca:</label>
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select">
                    </asp:DropDownList>

                </div>

                <div class="mb-3">
                    <label>Tipo</label>
                    <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-select">
                    </asp:DropDownList>
                </div>

                <%if (!confirmarEliminacion){%>
                <div class="mb-3 button-container ">
                    <asp:Button Text="Añadir" ID="btnAñadir" CssClass="btn btn-primary" runat="server" OnClick="btnAñadir_Click" />
                    <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-primary" runat="server" OnClick="btnModificar_Click" />
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


</asp:Content>
