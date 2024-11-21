using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web122 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string idProducto = Request.QueryString["IdProducto"];

                if (string.IsNullOrEmpty(idProducto))
                {
                    Response.Redirect("verstock.aspx");
                }

                CargarDatosProducto(int.Parse(idProducto));
            }

        }
        private void CargarDatosProducto(int idProducto)
        {
            // Lógica para cargar los datos del producto desde la base de datos
            NegocioStock negocioStock = new NegocioStock();
            var producto = negocioStock.ObtenerProductoPorId(idProducto);

            if (producto != null)
            {
                lblProductoIdValue.Text = producto.IdProducto.ToString();
                lblNombreProductoValue.Text = producto.Nombre;
                lblCantidadActualValue.Text = producto.Cantidad.ToString();
            }
            else
            {
                lblMensaje.Text = "El producto no existe.";
                lblMensaje.Visible = true;
                btnGuardar.Enabled = false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(lblProductoIdValue.Text);
                int nuevaCantidad = int.Parse(txtNuevaCantidad.Text);

                NegocioStock negocioStock = new NegocioStock();
                bool actualizado = negocioStock.ActualizarCantidadStock(idProducto, nuevaCantidad);

                if (actualizado)
                {
                    lblMensaje.Text = "La cantidad de stock fue actualizada exitosamente.";
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al actualizar el stock.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }
    }
}