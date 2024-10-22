<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="row" >
  <div class="col-6 main">
      <h2>Modificar</h2>
      <div><div>
          <label>ID:</label>
          </div>
          <div>
         <asp:TextBox ID="txtIdUsuario" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>     
      </div>
      <div>
          <div>
          <label>Nombre de usuario:</label>
          </div>
          <div>
          <asp:TextBox ID="txtNombre" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
          <div>
       <label>Contraseña:</label>
          </div>
          <div>
          <asp:TextBox ID="TextContraseña" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
             <div>
<label>Cargo:</label>
   </div>
   <div>
   <asp:TextBox ID="TextRol" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
      <div class="col-12 text-center">
 <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnGuardar_Click"/>
 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnCancelar_Click"/>
  </div>
  </div>
      </div>
</asp:Content>
