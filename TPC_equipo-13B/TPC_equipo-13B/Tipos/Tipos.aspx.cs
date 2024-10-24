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
    public partial class Formulario_web112 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioTipo negocioTipo = new NegocioTipo();
                DataTable dt = new DataTable();
                dt = negocioTipo.cargartablaTipos();

                GridViewTipos.DataSource = dt;
                GridViewTipos.DataBind();
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