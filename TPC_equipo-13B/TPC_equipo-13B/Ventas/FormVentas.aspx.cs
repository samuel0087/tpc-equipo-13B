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
        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
      
        }
    }
}