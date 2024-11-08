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
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioRol negocio = new NegocioRol();
                ddlRoles.DataSource = negocio.listar();
                ddlRoles.DataBind();



            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            NegocioUsuario negocioUsuario = new NegocioUsuario();

            usuario.Nombre = txtNombre.Text;
            usuario.Contraseña = TextContraseña.Text;
            usuario.Rol.IdRol =int.Parse(TextRol.Text);

            negocioUsuario.AgregarUsuario(usuario);

            Response.Redirect("ExitoUsuario.aspx");
        }
        protected void btnCancelar_Click(Object sender, EventArgs e) 
        {
            Response.Redirect("usuario.aspx");
        }
    }
}