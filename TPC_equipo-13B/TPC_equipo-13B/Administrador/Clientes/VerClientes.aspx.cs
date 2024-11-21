using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_equipo_13B.Clientes
{
    public partial class VerClientes : System.Web.UI.Page
    {
        public bool Buscar = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Buscar"] != null)
            {
                Buscar = true;
            }

            if (!IsPostBack)
            {
                NegocioCliente negocio = new NegocioCliente();
                try
                {
                    Session.Add("ListarClientes", negocio.listar());

                    dgvClientes.DataSource = (List<Cliente>)Session["ListarClientes"];
                    dgvClientes.DataBind();

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Cliente> lista  = (List<Cliente>)Session["ListarClientes"];
            List<Cliente> listaFiltrada  = new List<Cliente>();

            try
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) ||  x.Apellido.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                dgvClientes.DataSource = listaFiltrada;
                dgvClientes.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvClientes.SelectedDataKey.Value;
            Response.Redirect("FormClientes.aspx?id=" + id);
        }
    }
}