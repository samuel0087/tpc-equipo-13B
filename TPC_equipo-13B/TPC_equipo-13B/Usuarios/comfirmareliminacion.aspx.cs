using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo cargar si no es un postback
            {
                
                if (Session["UsuarioAEliminar"] != null)
                {
                    Usuario usuarioAEliminar = (Usuario)Session["UsuarioAEliminar"];

                    
                    lblIdUsuario.Text = usuarioAEliminar.IdUsuario.ToString(); // Asigna el ID
                    lblNombre.Text = usuarioAEliminar.Nombre; // Asigna el nombre
                    lblRol.Text = usuarioAEliminar.Rol; // Asigna el rol
                }
                else
                {
                    
                    Response.Redirect("PaginaDeError.aspx"); // Falta crear la pagina de error
                }
            }
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            if (Session["UsuarioAEliminar"] != null)
            {
                Usuario usuarioaeliminar = (Usuario)Session["UsuarioAEliminar"];

                int idusuario = usuarioaeliminar.IdUsuario;

                NegocioUsuario negocioUsuario = new NegocioUsuario();

                negocioUsuario.EliminarUsuario(idusuario);

                Response.Redirect("Usuario.aspx");

            }
            else
            {
               
                Response.Redirect("PaginaDeError.aspx"); //Falta crear la pagina de error aclaro
            }
        }
        protected void btnno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario.aspx");
        }
    }
}