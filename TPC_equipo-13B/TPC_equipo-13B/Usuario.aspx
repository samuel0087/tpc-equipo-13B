<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row" >
       <div class="col-6 main">
           <h2>Usuario</h2>
           <div>
    <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" OnClick="btnnuevo_Click" Enabled="False" CssClass="btn btn-primary" style="margin-bottom: 10px;" />
</div>
<asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="true" AllowPaging="True" OnRowCommand="GridViewUsuarios_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre de usuario" />
        <asp:BoundField DataField="Rol" HeaderText="Cargo" />
        
        
      
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn btn-primary" style="margin-bottom: 10px;"/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn btn-danger" style="margin-bottom: 10px;"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
           

           </div>
           </div>
  
</asp:Content>
