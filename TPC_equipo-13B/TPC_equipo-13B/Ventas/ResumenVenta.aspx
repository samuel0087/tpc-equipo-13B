<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="ResumenVenta.aspx.cs" Inherits="TPC_equipo_13B.Ventas.ResumenVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="row">
        <div class="col-10 main">
            <h2>Nueva Venta</h2>

            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="row">

                        <%if (Cliente == null)
                            {%>
                            <label class="form-label">DNI Cliente: </label>
                            <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" />
                            <asp:Label Text=""  runat="server" ID="lblError"/>
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
                            </div>
                        <%}%>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                    

                    

                    <div class="row">
                        <h3>Detalle de venta</h3>
                        <div class="col info">
                            <asp:GridView runat="server" ID="dgvProductos" DataKeyNames="IdProducto"  CssClass="table" AutoGenerateColumns="false" OnRowDataBound="dgvProductos_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="PecioFinal" HeaderText="Precio Unitario"  DataFormatString="{0:F2}"/>
                                    <asp:TemplateField  HeaderText="Precio Final" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioFinal" runat="server" text=""/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="row">
                        <h3><asp:Label Text="text" ID="PrecioTotal" runat="server" /></h3>
                    </div>

                    <div class="row">
                        <asp:DropDownList ID="ddlMetodos" runat="server" AutoPostBack="false" CssClass="form-control">
                                <asp:ListItem Text="Seleccione un metodo de pago" Value="" />
                        </asp:DropDownList>
                    </div>


                    <div class="button-container">
                        <asp:Button ID="btnConfirmarVenta" runat="server" CssClass="btn btn-success" Text="Finalizar Venta" OnClick="btnConfirmarVenta_Click" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
