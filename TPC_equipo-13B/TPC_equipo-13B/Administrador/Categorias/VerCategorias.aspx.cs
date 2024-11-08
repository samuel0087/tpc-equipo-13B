using Negocio;
using Dominio;
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
        public bool Buscar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Buscar"] != null)
                {
                    Buscar = true;
                }

                if (!IsPostBack)
                {
                    NegocioCategoria negocio = new NegocioCategoria();
                    Session.Add("ListaCategorias", negocio.listar(true));
                    dgvCategorias.DataSource = (List<Categoria>)Session["ListaCategorias"];
                    dgvCategorias.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvCategorias.SelectedDataKey.Value;
            Response.Redirect("FormCategorias.aspx?id=" + id);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Categoria> ListaFiltrada = new List<Categoria>();
            ListaFiltrada = ((List<Categoria>)Session["ListaCategorias"]).FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            dgvCategorias.DataSource = ListaFiltrada;
            dgvCategorias.DataBind();

        }
    }
}