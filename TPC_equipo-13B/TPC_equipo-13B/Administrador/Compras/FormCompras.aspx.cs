using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B.Compras
{
    public partial class FormCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedor();
                CargarProductos();
            }
        }
            private void CargarProveedor()
            {
                NegocioProveedor negocioProveedor = new NegocioProveedor();
                try
                {
                DataTable Proveedor = negocioProveedor.cargartablaProveedor();
                foreach (DataRow row in Proveedor.Rows)
                {
                    row["Nombre"] = row["IdProveedor"].ToString() + " - " + row["Nombre"] + " " + row["Apellido"];
                }

                ddlProveedor.DataSource = Proveedor;
                    ddlProveedor.DataTextField = "Nombre"; // Columna que deseas mostrar
                    ddlProveedor.DataValueField = "IdProveedor"; // Columna con el valor de cada opción
                    ddlProveedor.DataBind();
                }
                catch (Exception ex)
                {
                    // lblMensaje.Text = "Error al cargar clientes: " + ex.Message;
                    //lblMensaje.CssClass = "alert alert-danger";
                }
            }
        private void CargarProductos()
        {
            NegocioProducto negocioProducto = new NegocioProducto();
            try
            {
                DataTable productos = negocioProducto.ObtenerProductos();
                rptProductos.DataSource = productos;
                rptProductos.DataBind();
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Error al cargar productos: " + ex.Message;
                //lblMensaje.CssClass = "alert alert-danger";
            }
        }

        // Evento para cargar productos en el DropDownList del Repeater
        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            NegocioProducto negocioProducto1 = new NegocioProducto();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener la lista de productos
                DataTable productos = negocioProducto1.ObtenerProductos();

                // Encontrar el DropDownList en el Repeater
                DropDownList ddlProducto = (DropDownList)e.Item.FindControl("ddlProducto");

                if (ddlProducto != null)
                {
                    // Enlazar la lista de productos al DropDownList
                    ddlProducto.DataSource = productos;
                    ddlProducto.DataTextField = "Nombre";      // Mostrar el nombre del producto
                    ddlProducto.DataValueField = "IdProducto"; // Valor es el ID del producto
                    ddlProducto.DataBind();

                    // Agregar opción por defecto
                    ddlProducto.Items.Insert(0, new ListItem("Seleccione un producto", ""));
                }
            }
        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Código para agregar una nueva fila al Repeater
            List<int> productsCount = new List<int>(rptProductos.Items.Count + 1);
            rptProductos.DataSource = productsCount;
            rptProductos.DataBind();

            // Recargar productos en cada nuevo DropDownList


        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioProducto negocioProducto = new NegocioProducto();
            DropDownList ddlProducto = (DropDownList)sender;

            // Obtener el RepeaterItem contenedor del DropDownList
            RepeaterItem item = (RepeaterItem)ddlProducto.NamingContainer;

            // Obtener el Label donde se mostrará el precio
            Label lblPrecio = (Label)item.FindControl("lblPrecio");

            // Obtener el TextBox de cantidad
            TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");

            if (lblPrecio != null && txtCantidad != null)
            {
                int productoId;
                // Verificar que el ID del producto es válido
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {
                        // Obtener el precio del producto desde la base de datos
                        decimal precioProducto = negocioProducto.ObtenerPrecioProducto(productoId);

                        // Verificar que la cantidad es válida
                        int cantidad = 1;  // Valor por defecto
                        if (!string.IsNullOrEmpty(txtCantidad.Text) && int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0)
                        {
                            // Multiplicar el precio por la cantidad
                            decimal precioTotal = precioProducto * cantidad;
                            lblPrecio.Text = precioTotal.ToString("C2"); // Formato moneda con 2 decimales
                        }
                        else
                        {
                            lblPrecio.Text = "Cantidad inválida";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblPrecio.Text = "Error al obtener el precio: " + ex.Message;
                    }
                }
                else
                {
                    lblPrecio.Text = "Selecciona un producto válido";
                }
            }
        }
        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            NegocioProducto negocioProducto = new NegocioProducto();
            TextBox txtCantidad = (TextBox)sender;

            // Obtener el contenedor (RepeaterItem) del TextBox
            RepeaterItem item = (RepeaterItem)txtCantidad.NamingContainer;

            DropDownList ddlProducto = (DropDownList)item.FindControl("ddlProducto");
            Label lblPrecio = (Label)item.FindControl("lblPrecio");

            if (ddlProducto != null && lblPrecio != null)
            {
                int productoId;
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {
                        decimal precioProducto = negocioProducto.ObtenerPrecioProducto(productoId);

                        int cantidad;
                        if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0)
                        {
                            decimal precioTotal = precioProducto * cantidad;
                            lblPrecio.Text = precioTotal.ToString("C");
                        }
                        else
                        {
                            lblPrecio.Text = "Cantidad no válida";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblPrecio.Text = "Error al obtener el precio";
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else
                {
                    lblPrecio.Text = "Selecciona un producto válido";
                }
            }

            // Actualizar el total general
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0;

            foreach (RepeaterItem item in rptProductos.Items)
            {
                Label lblPrecio = (Label)item.FindControl("lblPrecio");

                if (lblPrecio != null && !string.IsNullOrWhiteSpace(lblPrecio.Text))
                {
                    if (decimal.TryParse(lblPrecio.Text, System.Globalization.NumberStyles.Currency, null, out decimal precio))
                    {
                        total += precio;
                    }
                }
            }

            // Actualizar el TextBox de total
            txtTotal.Text = total.ToString("C");
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("MenuCompras.aspx"); 
        }
    }
}
