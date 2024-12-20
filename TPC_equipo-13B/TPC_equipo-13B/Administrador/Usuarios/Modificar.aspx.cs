﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                    NegocioRol negocio = new NegocioRol();
                    ddlRoles.DataSource = negocio.listar();
                    ddlRoles.DataValueField = "IdRol";
                    ddlRoles.DataTextField = "NombreRol";
                    ddlRoles.DataBind();


                if (Session["UsuarioaModificar"] != null)
                {
                    Usuario usuario = (Usuario)Session["UsuarioaModificar"];
                  

                    /*txtIdUsuario.Text = usuario.IdUsuario.ToString();*/
                    txtNombre.Text = usuario.Nombre;
                    TextContraseña.Text = usuario.Contraseña;
                    ddlRoles.SelectedValue = usuario.Rol.IdRol.ToString();
                    
                    
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/Administrador/Usuarios/Usuario.aspx"));
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {   NegocioUsuario negocioUsuario=new NegocioUsuario();
            Usuario usuarioModificado = (Usuario)Session["UsuarioaModificar"];

            /*usuarioModificado.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);*/
            usuarioModificado.Nombre = txtNombre.Text;
            usuarioModificado.Contraseña = TextContraseña.Text;
            usuarioModificado.Rol.IdRol = int.Parse(ddlRoles.SelectedValue);

            negocioUsuario.ModificarUsuario(usuarioModificado);

            Response.Redirect("UsuarioModificadoconExito.aspx");
                              

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario.aspx");
        }
    }
}