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

            if (lblPrecio != null)
            {
              

                int productoId;
                // Verificar que el ID del producto es válido
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {
                        // Obtener el precio del producto desde la base de datos
                        decimal precioProducto = negocioProducto.ObtenerPrecioProducto(productoId);
                        // Mostrar el precio en el Label
                        lblPrecio.Text = precioProducto.ToString(); // Formato de moneda
                    }
                    catch (Exception ex)
                    {
                        lblPrecio.Text = "Error al obtener el precioooo";
                        // Puedes registrar el error o manejarlo según sea necesario
                    }
                }
                else
                {
                    lblPrecio.Text = "Selecciona un producto válido";
                }
            }
        }



        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {

        }
    }
}
