
<%@ Page Title="Historial de Compras" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web119" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Historial de Compras</h2>
        <asp:GridView ID="gvCompras" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="False" OnRowCommand="gvCompras_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
                <asp:BoundField DataField="IdProveedor" HeaderText="ID Proveedor" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:C}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDetalle" runat="server" Text="Detalle" CssClass="btn btn-primary btn-sm"
                                    CommandName="VerDetalle" CommandArgument='<%# Eval("IdCompra") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

       
        <div class="modal fade" id="detalleModal" tabindex="-1" aria-labelledby="detalleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="detalleModalLabel">Detalles de la Compra</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:GridView ID="gvDetalle" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="PrecioXUnidad" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                                <asp:BoundField DataField="PrecioXCantidad" HeaderText="Precio Total" DataFormatString="{0:C}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="mt-4">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
        </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

    
    <script type="text/javascript">
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('detalleModal'), {
                keyboard: false
            });
            myModal.show();
        }
    </script>
</asp:Content>
