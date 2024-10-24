<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web111" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div  >
       <div >
           <h2>Proveedores</h2>
           <div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnAgregar_Click"/>
</div>
    </div>
<asp:GridView ID="GridViewProveedores" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="true" AllowPaging="True" OnRowCommand="GridViewProveedores_RowCommand">
    <Columns>
       
        <asp:BoundField DataField="IdProveedor" HeaderText="ID Proveedor" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:BoundField DataField="Celular" HeaderText="Celular" />
        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
        <asp:BoundField DataField="Pais" HeaderText="País" />
   
        
        
      
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-primary" style="margin-bottom: 10px;"/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProveedor") %>' CssClass="btn btn-danger" style="margin-bottom: 10px;"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
           

           </div>
           </div>
  
</asp:Content>
