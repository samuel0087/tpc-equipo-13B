<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="FormVentas.aspx.cs" Inherits="TPC_equipo_13B.Ventas.FormVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-10 main">
            <h2>Nueva Venta</h2>

            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="row">

                        <%if (Cliente == null)
                            {%>
                            <label class="form-label">DNI Cliente: </label>
                            <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" />
                            <asp:Label Text=""  runat="server" ID="lblError"/>
                            <%if (Session["ErrorCliente"] != null)
                                {%>
                                <div class="mb-3">
                                    <span class="error"><%:(string)Session["ErrorCliente"].ToString() %></span>
                                
                                </div>
                            <%} %>

                            <div class="button-container">
                                <asp:Button Text="Buscar" ID="btnBuscarCliente" CssClass="btn btn-primary" runat="server" onClick="btnBuscarCliente_Click" />
                                <asp:Button Text="Nuevo cliente" ID="btnNuevoCliente"  CssClass="btn btn-success" runat="server" onClick="btnNuevoCliente_Click" />
                            </div>
                        <%}%>

                        <%if (Cliente != null){%>
                            <div class="col info ">

                                <h4 class="info-title">Informacion Cliente</h4>

                                <div>
                                    <label class="form-label info-item">Nombre:</label>
                                    <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                                </div>

                                <div>
                                    <label class="form-label info-item">Dni:</label>
                                    <asp:Label ID="lblDni" runat="server" Text=""></asp:Label>
                                </div>

                                <div>
                                    <label class="form-label info-item">Email:</label>
                                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="button-cancelar">
                                    <asp:Button Text="X" ID="btnCambiarCliente" CssClass="btn btn-danger" runat="server" onClick="btnCambiarCliente_Click" />
                                </div>
                            </div>
                        <%}%>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>                    

                    <div class="row form">

                        <h3>Seleccion de productos</h3>

                        <div class="col-9">
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" TextMode="Number"  Placeholder="Codigo"></asp:TextBox>
                            <asp:Label Text="" ID="lblErrorCodigo" CssClass="error" runat="server" />
                        </div>

                        <div class="col">
                            <asp:Button Text="Buscar" ID="btnBuscarProducto" CssClass="btn btn-primary" runat="server" onClick="btnBuscarProducto_Click" />
                        </div>
                    </div>

                    <div class="row form">


                        <div class="col">
                            <asp:DropDownList ID="ddlMarcas" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged">
                                <asp:ListItem Text="Seleccione un producto" Value="" />
                            </asp:DropDownList>
                        </div>

                        <div class="col">
                            <asp:DropDownList ID="ddlProductos" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" >
                                <asp:ListItem Text="Seleccione un producto" Value="" />
                            </asp:DropDownList>
                        </div>

                        <div class="col">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" Min="1" Placeholder="Cantidad"></asp:TextBox>
                        </div>

                        <div class="col">
                            <asp:Button Text="Añadir" ID="btnAgregar" CssClass="btn btn-primary" runat="server" onClick="btnAgregar_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:GridView runat="server" ID="dgvProductos" DataKeyNames="IdProducto"  CssClass="table" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" />
                                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" ControlStyle-CssClass="btn btn-primary" HeaderText="Detalles" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>



                    <asp:Button ID="btnConfirmarVenta" runat="server" CssClass="btn btn-success" Text="Confirmar Venta" OnClick="btnConfirmarVenta_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
