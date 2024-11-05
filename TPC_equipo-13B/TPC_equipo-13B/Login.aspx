<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_equipo_13B.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4 main">
            <h2>Login</h2>

                <asp:ScriptManager ID="ScriptManager1" runat="server" />

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <div class="mb-3">
                            <asp:Label Text="Usuario"  ID="lblNombreUsuario" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtNombreUsuario"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Contraseña"  ID="lblContraseña" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" textMode="Password" cssClass="form-control" ID="txtContraseña"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text=""  ID="lblErrorLogin" CssClass="form-label my-1 mr-2 error" runat="server" />
                        </div>

                        <div class="mb-3 button-container ">
                            <asp:Button Text="Ingresar" ID="btnIngresar" cssClass="btn btn-primary" runat="server" onclick="btnIngresar_Click"/>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

                
            
        </div>
    </div>
</asp:Content>
