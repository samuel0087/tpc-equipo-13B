<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormMarca.aspx.cs" Inherits="TPC_equipo_13B.marcas.FormMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Formulario Marcas</h2>

            
                <asp:ScriptManager ID="ScriptManager1" runat="server" />

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="NombreMarca" class="form-label">Nombre</label>
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtNombreMarca" AutoPostBack="true" OnTextChanged="txtNombreMarca_TextChanged" />
                            <asp:Label Text="" CssClass="error" runat="server" ID="lblError"/>
                        </div>

                        <asp:Button Text="Añadir" ID="btnAñadir" cssClass="btn btn-primary" runat="server" onclick="btnAñadir_Click"/>
                    </ContentTemplate>
                </asp:UpdatePanel>

                
            
        </div>
    </div>
</asp:Content>
