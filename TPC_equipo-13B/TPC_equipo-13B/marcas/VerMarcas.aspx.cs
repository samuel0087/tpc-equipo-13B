using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_equipo_13B.marcas
{
    public partial class VerMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioMarca negocio = new NegocioMarca();
                dgvMarcas.DataSource = negocio.listar(true);
                dgvMarcas.DataBind();

            }

        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvMarcas.SelectedDataKey.Value;
            Response.Redirect("FormMarca.aspx?id=" + id);
        }
    }
}