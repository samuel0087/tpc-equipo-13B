<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="comfirmareliminacionproveedor.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web115" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="row" >
 <div >
     <h2>¿Desea eliminar el siguiente usuario?</h2>
     <div>
         <label>ID:</label>
        <asp:Label ID="lblIdProveedor" runat="server" Text=""></asp:Label><br />
     </div>
     <div>
         <label>Nombre:</label>
         <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
     </div>
     <div>
      <label>Apellido:</label>
         <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label><br />
     </div>
      <div>
  <label>Email:</label>
     <asp:Label ID="lblemail" runat="server" Text=""></asp:Label><br />
 </div>
      <div>
  <label>Telefono:</label>
     <asp:Label ID="lbltelefono" runat="server" Text=""></asp:Label><br />
 </div>
 <div>
  <label>Celular:</label>
     <asp:Label ID="lblcelular" runat="server" Text=""></asp:Label><br />
 </div>
 <div>
  <label>Provincia:</label>
     <asp:Label ID="lblprovincia" runat="server" Text=""></asp:Label><br />
</div>
 <div>
  <label>Direccion:</label>
     <asp:Label ID="lbldireccion" runat="server" Text=""></asp:Label><br />
 </div>
 <div>
  <label>Pais:</label>
     <asp:Label ID="lblpais" runat="server" Text=""></asp:Label><br />
 </div>
     <div class="col-12 text-center">
<asp:Button ID="btnsi" runat="server" Text="si"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnsi_Click"/>
<asp:Button ID="btnno" runat="server" Text="no"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnno_Click"/>
 </div>
 </div>
     </div>
</asp:Content>
