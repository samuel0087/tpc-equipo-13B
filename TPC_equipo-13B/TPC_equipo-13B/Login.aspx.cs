using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_equipo_13B
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            Usuario usuario = new Usuario();

            try
            {
                usuario.Nombre = txtNombreUsuario.Text;
                usuario.Contraseña = txtContraseña.Text;

                if (negocio.loguear(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Session.Add("Admin", false);

                    if (usuario.Rol.NombreRol == "Administrador")
                    {
                        Session.Add("Admin", true);
                    }

                    Response.Redirect("Default.aspx", false);

                }
                else
                {
                    lblErrorLogin.Text = "No se pudo iniciar sesion, verifique los datos por favor";
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}