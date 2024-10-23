using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B.Categorias
{
    public partial class VerCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioCategoria negocio = new NegocioCategoria();
                dgvCategorias.DataSource = negocio.listar(true);
                dgvCategorias.DataBind();

            }

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvCategorias.SelectedDataKey.Value;
            Response.Redirect("FormCategorias.aspx?id=" + id);

        }
    }
}