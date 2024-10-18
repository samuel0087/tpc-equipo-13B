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
            DataTable dt = new DataTable();
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("Nombre de usuario");
            dt.Columns.Add("cargo");
            dt.Columns.Add("FechaRegistro");

            dt.Rows.Add(1, "Juan Pérez", "juan@example.com", DateTime.Now);
            dt.Rows.Add(2, "María López", "maria@example.com", DateTime.Now);

            GridViewUsuarios.DataSource = dt;
            GridViewUsuarios.DataBind();
        }
  
            protected void GridViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Obtener el ID del usuario seleccionado
                int userId = Convert.ToInt32(GridViewUsuarios.SelectedDataKey.Value);

                // Almacenar el ID en ViewState si necesitas usarlo más adelante
                ViewState["SelectedUserId"] = userId;

                // Habilitar los botones para modificar y eliminar
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
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
        protected void btnEliminar_Click(object sender, EventArgs e) { }


    }
}