using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_equipo_13B.marcas
{
    public partial class VerMarcas : System.Web.UI.Page
    {
        public bool Buscar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Buscar"] != null)
            {
                Buscar = true;
            }

            if (!IsPostBack)
            {
                NegocioMarca negocio = new NegocioMarca();
                try
                {
                    Session.Add("ListaMarcas", negocio.listar(true));

                    dgvMarcas.DataSource = (List<Marca>)Session["ListaMarcas"];
                    dgvMarcas.DataBind();

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvMarcas.SelectedDataKey.Value;
            Response.Redirect("FormMarca.aspx?id=" + id);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Marca> lista  = (List<Marca>)Session["ListaMarcas"];
            List<Marca> listaFiltrada  = new List<Marca>();

            try
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                dgvMarcas.DataSource = listaFiltrada;
                dgvMarcas.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}