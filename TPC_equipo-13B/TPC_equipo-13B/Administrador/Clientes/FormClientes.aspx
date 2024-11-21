<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormClientes.aspx.cs" Inherits="TPC_equipo_13B.Clientes.FormClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6 main">
            <h2>Formulario Clientes</h2>

            
                <asp:ScriptManager ID="ScriptManager1" runat="server" />

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <div class="mb-3">
                            <asp:Label Text="Nombre"  ID="lblNombreCliente" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtNombreCliente" />
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Apellido"  ID="lblApellidoCliente" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtApellido"  />
                            <asp:Label Text=""  runat="server" ID="Label2"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="DNI"  ID="lblDniCliente" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtDNI" TextMode="Number" />
                            <asp:Label Text=""  runat="server" ID="Label4"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Email"  ID="lblEmail" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtEmail" />
                            <asp:Label Text=""  runat="server" ID="Label6"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Telefono"  ID="lblTelefono" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtTelefono"/>
                            <asp:Label Text=""  runat="server" ID="Label8"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Celular"  ID="lblCelular" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtCelular"  />
                            <asp:Label Text=""  runat="server" ID="Label10"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Pais"  ID="lblPais" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtPais"  />
                            <asp:Label Text=""  runat="server" ID="Label12"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Provincia"  ID="lblProvincia" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtProvincia"/>
                            <asp:Label Text=""  runat="server" ID="Label14"/>
                        </div>

                        <div class="mb-3">
                            <asp:Label Text="Direccion"  ID="lblDireccion" CssClass="form-label my-1 mr-2" runat="server" />
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtDireccion" />
                            <asp:Label Text=""  runat="server" ID="Label16"/>
                        </div>

                        <asp:Label Text=""  runat="server" ID="lblError"/>



                        <%if (!confirmarEliminacion){%>
                            <div class="mb-3 button-container ">
                                <asp:Button Text="Añadir" ID="btnAñadir" cssClass="btn btn-primary" runat="server" onclick="btnAñadir_Click"/>
                                <asp:Button Text="Modificar" ID="btnModificar" cssClass="btn btn-primary" runat="server" onClick="btnModificar_Click1"/>
                                <asp:Button Text="Eliminar" ID="btnEliminar" cssClass="btn btn-danger" runat="server" onClick="btnEliminar_Click"/>
                            </div>
                        <%} %>

                        <%if (confirmarEliminacion){%>
                            <div class="mb-3">
                                <span class="form-label button-container">¿Esta seguro que desea eliminar?</span>
                                <div class="button-container">
                                    <asp:Button Text="Eliminar" ID="btnConfrimarEliminacion" cssClass="btn btn-outline-danger" runat="server" onClick="btnConfrimarEliminacion_Click"/>
                                    <asp:Button Text="Cancelar" ID="btnCancelar" cssClass="btn btn btn-outline-secondary" runat="server" onClick="btnCancelar_Click"/>
                                </div>
                            </div>
                        <%} %>

                    </ContentTemplate>
                </asp:UpdatePanel>

                
            
        </div>
    </div>
</asp:Content>
