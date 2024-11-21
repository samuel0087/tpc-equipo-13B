<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="VerClientes.aspx.cs" Inherits="TPC_equipo_13B.Clientes.VerClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-8 main">
            <h2>Clientes</h2>

            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if (Buscar){ %>
                        <div class="mb-3 ">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtBuscar" />
                        </div>

                        <div class="mb-3 col-5">
                            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>
                        </div>
                    <%} %>


                    <asp:GridView runat="server" ID="dgvClientes" DataKeyNames="ID" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" CssClass="table" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Ver" ControlStyle-CssClass="btn btn-primary" HeaderText="Detalles" />
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>

            
        </div>
    </div>
</asp:Content>
