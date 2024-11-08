using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B.Tipos
{
    public partial class VerTipos : System.Web.UI.Page
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
                NegocioTipo negocio = new NegocioTipo();
                try
                {
                    Session.Add("ListaTipos", negocio.listar(true));

                    dgvTipos.DataSource = (List<Tipo>)Session["ListaTipos"];
                    dgvTipos.DataBind();

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Tipo> lista = (List<Tipo>)Session["ListaTipos"];
            List<Tipo> listaFiltrada = new List<Tipo>();

            try
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                dgvTipos.DataSource = listaFiltrada;
                dgvTipos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void dgvTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvTipos.SelectedDataKey.Value;
            Response.Redirect("FormTipos.aspx?id=" + id);
        }
    }
}