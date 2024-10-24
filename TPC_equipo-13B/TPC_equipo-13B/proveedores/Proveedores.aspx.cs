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
    public partial class Formulario_web111 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioProveedor negocioProveedor = new NegocioProveedor();
                DataTable dt = new DataTable();
                dt = negocioProveedor.cargartablaProveedor();

                GridViewProveedores.DataSource = dt;
                GridViewProveedores.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        
        protected void GridViewProveedores_RowCommand(object sender, EventArgs e)
        {

        }
    }
}