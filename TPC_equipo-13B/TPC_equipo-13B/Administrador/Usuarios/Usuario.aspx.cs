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
  
    
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("AgregarUsuario.aspx");
        }
      
  
        protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                Usuario UsuarioaModificar = negocioUsuario.buscarUsuarioPorId(idUsuario);
                if(UsuarioaModificar != null)
                {
                    Session["UsuarioaModificar"] = UsuarioaModificar;
                }

                Response.Redirect("Modificar.aspx");
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