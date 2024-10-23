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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioProducto negocioProducto = new NegocioProducto();
                DataTable dt = new DataTable();
                dt = negocioProducto.cargartaProducto();

                GridViewProductos.DataSource = dt;
                GridViewProductos.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProductos.aspx");
        }
        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}