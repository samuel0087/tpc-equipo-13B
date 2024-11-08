<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="modificarproveedores.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web116" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="row" >
  <div class="col-6 main">
      <h2>Modificar</h2>
      <div><!--<div>
          <label>ID:</label>
          </div>
          <div>
         <asp:TextBox ID="txtIdUsuario" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>  -->   
      </div>
      <div>
          <div>
          <label>Nombre:</label>
          </div>
          <div>
          <asp:TextBox ID="txtNombre" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
          <div>
       <label>Apellido:</label>
          </div>
          <div>
          <asp:TextBox ID="TextApellido" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
             <div>
<label>Email:</label>
   </div>
   <div>
   <asp:TextBox ID="TextEmail" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
            <div>
             <div>
<label>Telefono:</label>
   </div>
   <div>
   <asp:TextBox ID="TextTelefono" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
            <div>
             <div>
<label>Celular:</label>
   </div>
   <div>
   <asp:TextBox ID="TextCelular" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
            <div>
             <div>
<label>Direccion:</label>
   </div>
   <div>
   <asp:TextBox ID="TextDireccion" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
            <div>
             <div>
<label>Provincia:</label>
   </div>
   <div>
   <asp:TextBox ID="TextProvincia" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
            <div>
             <div>
<label>Pais:</label>
   </div>
   <div>
   <asp:TextBox ID="TextPais" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
      <div class="col-12 text-center">
 <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnGuardar_Click"/>
 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnCancelar_Click"/>
  </div>
  </div>
      </div>
</asp:Content>
