using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B.Ventas
{
    public partial class FormVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarProductos();
            }
        }

        private void CargarClientes()
        {   NegocioCliente negocioCliente = new NegocioCliente();   
            try
            {   
                DataTable clientes = negocioCliente.ObtenerClientes();
                ddlCliente.DataSource = clientes;
                ddlCliente.DataTextField = "Nombre"; // Columna que deseas mostrar
                ddlCliente.DataValueField = "IdCliente"; // Columna con el valor de cada opción
                ddlCliente.DataBind();
            }
            catch (Exception ex)
            {
               // lblMensaje.Text = "Error al cargar clientes: " + ex.Message;
                //lblMensaje.CssClass = "alert alert-danger";
            }
        }
        private void CargarProductos()
        {   NegocioProducto negocioProducto = new NegocioProducto();
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
        {   NegocioProducto negocioProducto1 = new NegocioProducto();   
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
            // Crear una instancia de la capa de negocio
            NegocioProducto negocioProducto = new NegocioProducto();

            // Obtener el control DropDownList que generó el evento
            DropDownList ddlProducto = (DropDownList)sender;

            // Obtener el contenedor del DropDownList (el RepeaterItem)
            RepeaterItem item = (RepeaterItem)ddlProducto.NamingContainer;

            // Buscar el Label correspondiente para mostrar el precio
            Label lblPrecio = (Label)item.FindControl("lblPrecio");

            if (lblPrecio == null)
            {
                System.Diagnostics.Debug.WriteLine("Error: No se encontró el control lblPrecio.");
                return;
            }

            int productoId;

            // Validar y convertir el valor seleccionado en el DropDownList
            if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
            {
                try
                {
                    // Depuración del ID seleccionado
                    System.Diagnostics.Debug.WriteLine($"Producto seleccionado: {productoId}");

                    // Obtener el precio del producto desde la base de datos
                    decimal precioProducto = negocioProducto.ObtenerPrecioProducto(productoId);

                    // Mostrar el precio en el Label
                    lblPrecio.Text = precioProducto.ToString("C"); // "C" muestra el formato de moneda local
                }
                catch (Exception ex)
                {
                    lblPrecio.Text = "Error al obtener el precio";
                    System.Diagnostics.Debug.WriteLine($"Error al obtener el precio: {ex.Message}, StackTrace: {ex.StackTrace}");
                   
                }
            }
            else
            {
                lblPrecio.Text = "Seleccione un producto válido";
            }
        }
        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            // Recargar productos en el Repeater
            int count = rptProductos.Items.Count + 1; // Incrementar el número de productos
            List<int> productsCount = Enumerable.Range(1, count).ToList();

            rptProductos.DataSource = productsCount;
            rptProductos.DataBind();
        }
    }
}