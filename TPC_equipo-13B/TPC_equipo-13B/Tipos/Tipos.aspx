<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web112" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div  >
       <div >
           <h2>Tipos</h2>
           <div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnAgregar_Click"/>
</div>
    </div>
<asp:GridView ID="GridViewTipos" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="true" AllowPaging="True" OnRowCommand="GridViewProveedores_RowCommand">
    <Columns>
       
        <asp:BoundField DataField="IdTipo" HeaderText="ID Tipo" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
   
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("IdTipo") %>' CssClass="btn btn-primary" style="margin-bottom: 10px;"/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdTipo") %>' CssClass="btn btn-danger" style="margin-bottom: 10px;"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
           

           </div>
           </div>
</asp:Content>
