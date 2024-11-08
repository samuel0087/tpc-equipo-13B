<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="EliminarProducto.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="row" >
  <div >
      <h2>¿Desea eliminar el siguiente producto?</h2>
      <div>
          <label>ID:</label>
         <asp:Label ID="lblIdProducto" runat="server" Text=""></asp:Label><br />
      </div>
      <div>
       <label>Codigo:</label>
      <asp:Label ID="LblCodigo" runat="server" Text=""></asp:Label><br />
   </div>
      <div>
          <label>Nombre:</label>
          <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
      </div>
      <div>
       <label>IdMarca:</label>
          <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label><br />
      </div>
        <div>
   <label>IdProveedor:</label>
      <asp:Label ID="LblProveedor" runat="server" Text=""></asp:Label><br />
  </div>
  <div>
  <div>
 <label>IdTipo:</label>
    <asp:Label ID="LblTipo" runat="server" Text=""></asp:Label><br />
</div>
<div>
  <label>stock:</label>
     <asp:Label ID="Lblstock" runat="server" Text=""></asp:Label><br />
 </div>
      <div class="col-12 text-center">
 <asp:Button ID="btnsi" runat="server" Text="si"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnsi_Click"/>
 <asp:Button ID="btnno" runat="server" Text="no"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnno_Click"/>
  </div>
  </div>
      </div>
</asp:Content>
