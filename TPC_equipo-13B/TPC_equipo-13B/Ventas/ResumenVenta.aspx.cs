using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_equipo_13B.Ventas
{
    public partial class ResumenVenta : System.Web.UI.Page
    {
        public Cliente Cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Venta"] != null)
                {
                    Venta venta = (Venta)Session["Venta"];
                    Cliente = venta.Cliente;
                    lblCliente.Text = Cliente.Nombre + "" + Cliente.Apellido;
                    lblDni.Text = Cliente.DNI.ToString();
                    lblEmail.Text = Cliente.Email;

                    dgvProductos.DataSource = venta.Productos;
                    dgvProductos.DataBind();

                    cargarMetodos();
                    PrecioTotal.Text = venta.CostoTotal.ToString();
                }
                else
                {
                    Response.Redirect("MenuVentas.aspx");
                }
            }
            

        }

        public void cargarMetodos()
        {
            NegocioMetodoPago negocio = new NegocioMetodoPago();
            ddlMetodos.DataSource = negocio.listar();
            ddlMetodos.DataTextField = "Nombre";
            ddlMetodos.DataValueField = "IdMetodoDePago";
            ddlMetodos.DataBind();
            ddlMetodos.Items.Insert(0, new ListItem("Seleccione un Metodo de pago", ""));

        }

        protected void dgvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrecioFinal = (Label)e.Row.FindControl("lblPrecioFinal");

                //Valor Unitario
                decimal precioUnitario = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PecioFinal"));
                //cantidad
                int cantidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));


                lblPrecioFinal.Text = (precioUnitario * cantidad).ToString("F2");

            }
        }

        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = (Venta)Session["Venta"];
            venta.MetodoDePago = new MetodoDePago();
            venta.MetodoDePago.IdMetodoDePago = int.Parse(ddlMetodos.SelectedValue);

            NegocioVenta negocioVenta = new NegocioVenta();
            venta.NumeroFactura = negocioVenta.generarCodigoFactura();
            negocioVenta.InsertarVenta(venta);

            venta = negocioVenta.buscarVentaPorFactura(venta);

            negocioVenta.registrarProductos(venta);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormVentas.aspx?edit=true");
        }
    }
}