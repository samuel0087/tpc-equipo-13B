using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web121 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarStock();
            }
        }
       protected void gvStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Verifica si el CommandName corresponde a los botones esperados
            string commandName = e.CommandName;
            int idProducto = Convert.ToInt32(e.CommandArgument); // Obtiene el IdProducto desde CommandArgument

            if (commandName == "Modificar")
            {
                // Lógica para modificar
                Response.Redirect($"ModificarStock.aspx?IdProducto={idProducto}");
            }
            else if (commandName == "Eliminar")
            {
                // Lógica para eliminar
                try
                {
                    // Llama a la lógica de eliminación en la base de datos
                    NegocioStock negocioStock = new NegocioStock();
                    negocioStock.EliminarStockPorIdProducto(idProducto);

                    // Refresca el GridView
                    CargarStock();
                }
                catch (Exception ex)
                {
                    //lblError.Text = "Error al eliminar el producto: " + ex.Message;
                    //lblError.Visible = true;
                }
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("menustock.aspx");
        }
        private void CargarStock()
        {
            try
            {
                NegocioStock negocioStock = new NegocioStock();
                DataTable dtStock = negocioStock.ObtenerStock();

                gvStock.DataSource = dtStock;
                gvStock.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar el stock: " + ex.Message + "');</script>");
            }
        }

    }
}