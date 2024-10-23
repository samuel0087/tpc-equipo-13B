<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="comfirmareliminacion.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row" >
  <div class="col-6 main">
      <h2>¿Desea eliminar el siguiente usuario?</h2>
      <div>
          <label>ID:</label>
         <asp:Label ID="lblIdUsuario" runat="server" Text=""></asp:Label><br />
      </div>
      <div>
          <label>Nombre de usuario:</label>
          <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
      </div>
      <div>
       <label>Cargo:</label>
          <asp:Label ID="lblRol" runat="server" Text=""></asp:Label><br />
      </div>
      <div class="col-12 text-center">
 <asp:Button ID="btnsi" runat="server" Text="si"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnsi_Click"/>
 <asp:Button ID="btnno" runat="server" Text="no"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnno_Click"/>
  </div>
  </div>
      </div>

</asp:Content>
