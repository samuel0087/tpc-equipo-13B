﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ComercioApp.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="TPC_equipo_13B.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="row" >
       <div >
           <h2>Producto</h2>
           <div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" style="margin-bottom: 10px;" OnClick="btnAgregar_Click"/>
</div>
<asp:GridView ID="GridViewProductos" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="true" AllowPaging="True" OnRowCommand="GridViewProductos_RowCommand">
    <Columns>

        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="IdMarca" HeaderText="IdMarca" />
        <asp:BoundField DataField="idProveedor" HeaderText="Proveedor" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
        <asp:BoundField DataField="idTipo" HeaderText="Tipo" />


        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-primary" style="margin-bottom: 10px;"/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-danger" style="margin-bottom: 10px;"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
           

           </div>
           </div>
</asp:Content>
