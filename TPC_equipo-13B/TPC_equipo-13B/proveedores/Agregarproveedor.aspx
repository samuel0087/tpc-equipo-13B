<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Agregarproveedor.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web113" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <h2>Agregar Proveedor:</h2>
      <div><!--<div>
          <label>ID:</label>
          </div>
          <div>
         <asp:TextBox ID="txtIdUsuario" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>   -->  
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
    <asp:TextBox ID="TxtApelldio" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>
    <div>
    <div>
    <label>Email:</label>
    </div>
    <div>
    <asp:TextBox ID="TxtEmail" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>
    <div>
    <div>
    <label>Telefono:</label>
    </div>
    <div>
    <asp:TextBox ID="TxtTelefono" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>

    <div>
    <div>
    <label>Celular:</label>
    </div>
    <div>
    <asp:TextBox ID="TxtCelular" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>
        <div>
    <div>
    <label>Direccion:</label>
    </div>
    <div>
    <asp:TextBox ID="TxtDireccion" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>
 <div>
    <div>
    <label>Provincia:</label>
    </div>
    <div>
    <asp:TextBox ID="TxtProvincia" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
    </div>
</div>
 <div>
          <div>
       <label>Pais:</label>
          </div>
          <div>
          <asp:TextBox ID="TxtPais" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
          </div>
      </div>
     <!-- <div>
             <div>
<label>Cargo:</label>
   </div>
   <div>
   <asp:TextBox ID="TextRol" runat="server" style="margin-bottom: 10px;"></asp:TextBox><br />
       <asp:DropDownList runat="server" ID="ddlRoles">
       </asp:DropDownList>
   </div>
      </div>-->
      <div class="col-12 text-center">
 <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnGuardar_Click"/>
 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  CssClass="btn btn-danger" style="margin-bottom: 10px;" OnClick="btnCancelar_Click"/>
  </div>
  </div>
      </div>
</asp:Content>
