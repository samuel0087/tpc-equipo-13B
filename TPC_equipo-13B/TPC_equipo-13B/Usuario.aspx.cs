using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                DataTable dt = new DataTable();
                dt = negocioUsuario.cargartablausuario();

                GridViewUsuarios.DataSource = dt;
                GridViewUsuarios.DataBind();
            }
        }
  
    
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            // Aquí puedes redirigir a la página para crear un nuevo usuario
            Response.Redirect("NuevoUsuario.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Verifica que haya un usuario seleccionado
            if (ViewState["SelectedUserId"] != null)
            {
                int userId = (int)ViewState["SelectedUserId"];
                // Redirige a la página de modificación pasando el userId
                Response.Redirect($"ModificarUsuario.aspx?userId={userId}");
            }
            else
            {
                // Mostrar un mensaje de error o alertar al usuario de que debe seleccionar un usuario primero
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e) {
        
         
        }
  
        protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                NegocioUsuario negocioUsuario = new NegocioUsuario();
               
            }
            else if (e.CommandName == "Eliminar")
            {   NegocioUsuario negocioUsuario= new NegocioUsuario();
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                Usuario usuarioAEliminar = negocioUsuario.buscarUsuarioPorId(idUsuario);
                if (usuarioAEliminar != null)
                {
                    Session["UsuarioAEliminar"] = usuarioAEliminar; 
                }

                Response.Redirect("comfirmareliminacion.aspx");

            }
        }


    }
}