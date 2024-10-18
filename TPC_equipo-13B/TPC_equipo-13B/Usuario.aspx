<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
       <div class="col-6 main">
           <h2>Usuario</h2>
           
<asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="true" OnSelectedIndexChanged="GridViewUsuarios_SelectedIndexChanged" AllowPaging="True">
    <Columns>
        <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
        <asp:BoundField DataField="Nombre de usuario" HeaderText="Nombre de usuario" />
        <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" />
    </Columns>
    <RowStyle CssClass="row-style" />
    <SelectedRowStyle CssClass="selected-row" />
</asp:GridView>
           
           <div class="menu">
              
<div>
    <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" OnClick="btnnuevo_Click" Enabled="False" CssClass="btn btn-primary" style="margin-bottom: 10px;" />
</div>
<div>
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" Enabled="False" CssClass="btn btn-primary" style="margin-bottom: 10px;"/>
</div>
<div>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="False" CssClass="btn btn-danger" style="margin-bottom: 10px;"/>
</div>     
          
       </div>
           </div>
           </div>
  
</asp:Content>
