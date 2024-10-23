<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="AgregarProductos.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <h2>Agregar Producto:</h2>
      <div><!--<div>
          <label>ID:</label>
          </div>
          <div>
         <asp:TextBox ID="txtIdUsuario" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>   -->  
      </div>
      <div>
          <div>
          <label>Codigo:</label>
          </div>
          <div>
          <asp:TextBox ID="txtCodigo" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
          <div>
       <label>Nombre:</label>
          </div>
          <div>
          <asp:TextBox ID="TxtNombre" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
      <div>
             <div>
<label>IdMarca:</label>
   </div>
   <div>
   <asp:TextBox ID="TxtMarca" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
          <div>
             <div>
<label>IdProveedor:</label>
   </div>
   <div>
   <asp:TextBox ID="TxtIdproveedor" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
          <div>
             <div>
<label>stock:</label>
   </div>
   <div>
   <asp:TextBox ID="Txtstock" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
   <div>
   <div>
<label>IdTipo:</label>
   </div>
   <div>
   <asp:TextBox ID="TxtIdTipo" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
   </div>
      </div>
      <div class="col-12 text-center">
 <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnGuardar_Click"/>
 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnCancelar_Click"/>
  </div>
  </div>
      </div>
</asp:Content>
