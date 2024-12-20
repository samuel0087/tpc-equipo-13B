﻿using Dominio;
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
            txtCantidad.Text = "1";

            // Obtener el TextBox de Precio Unitario
            TextBox txtPrecioUnitario = (TextBox)item.FindControl("txtPrecioUnitario");

            if (lblPrecio != null && txtCantidad != null)
            {
                int productoId;
                // Verificar que el ID del producto es válido
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {
                        // Obtener el precio del producto

                        txtPrecioUnitario.Text = negocioProducto.ObtenerPrecioProducto(productoId).ToString();
                        decimal precioProducto = decimal.Parse(txtPrecioUnitario.Text);

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
                            txtCantidad.Text = "1";
                            decimal precioTotal = Decimal.Parse(txtCantidad.Text) * cantidad;
                            lblPrecio.Text = precioTotal.ToString("C2"); // Formato moneda con 2 decimales
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
            TextBox txtPrecioUnitario = (TextBox)item.FindControl("txtPrecioUnitario");

            if (ddlProducto != null && lblPrecio != null)
            {
                int productoId;
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {
                        decimal precioProducto = Decimal.Parse(txtPrecioUnitario.Text);

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
        //REVISAR
        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Preparar datos para pasar al resumen
                string proveedor = ddlProveedor.SelectedItem.Text;
                string usuario = Session["NombreUsuario"] as string ?? "Usuario no autenticado";
                DateTime fechaCompra = DateTime.Now;
                
                // Crear una lista de productos
                var productos = new List<object>();
                foreach (RepeaterItem item in rptProductos.Items)
                {
                    DropDownList ddlProducto = (DropDownList)item.FindControl("ddlProducto");
                    TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                    TextBox txtPrecioUnitario = (TextBox)item.FindControl("txtPrecioUnitario");
                    Label lblPrecio = (Label)item.FindControl("lblPrecio");

                    if (ddlProducto != null && txtCantidad.Text != "" && lblPrecio.Text != "")
                    {
                        string textoprecioXunidad = txtPrecioUnitario.Text.Replace("$", "").Trim();
                        string textoprecioXcantidad = lblPrecio.Text.Replace("$", "").Trim();
                        productos.Add(new
                        {
                            NombreProducto = ddlProducto.SelectedItem.Text,
                            Cantidad = txtCantidad.Text,
                            PrecioUnitario = Decimal.Parse(textoprecioXunidad),
                            PrecioFinal = Decimal.Parse(textoprecioXcantidad)
                        });
                    }
                }

                // Proceso para guardar compra en la base de datos
                Compra compra = new Compra
                {
                    IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue),
                    fecha = DateTime.Now
                };

                string textoTotal = txtTotal.Text.Replace("$", "").Trim();
                if (decimal.TryParse(textoTotal, out decimal precioTotal))
                {
                    compra.Precio = precioTotal;
                }
                else
                {
                    lblError.Text = "El total ingresado no es válido.";
                    lblError.Visible = true;
                    return;
                }

                NegocioCompra negocioCompra = new NegocioCompra();
                negocioCompra.InsertarCompra(compra);

                // Proceso para guardar los registros en la base de datos de compraXproducto
                NegocioProductoXcompra negocioproductoxcompra = new NegocioProductoXcompra();
                List<CompraXproducto> listaCompraXProducto = new List<CompraXproducto>();

                foreach (RepeaterItem item in rptProductos.Items)
                {
                    DropDownList ddlProducto = (DropDownList)item.FindControl("ddlProducto");
                    TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                    TextBox txtPrecioUnitario = (TextBox)item.FindControl("txtPrecioUnitario");
                    Label lblPrecio = (Label)item.FindControl("lblPrecio");

                    if (!string.IsNullOrEmpty(ddlProducto.SelectedValue) && !string.IsNullOrEmpty(txtCantidad.Text))
                    {
                        string textoprecioXunidad = txtPrecioUnitario.Text.Replace("$", "").Trim();
                        string textoprecioXcantidad = lblPrecio.Text.Replace("$", "").Trim();

                        // Crear una nueva instancia de CompraXproducto para cada producto
                        CompraXproducto compraXproducto = new CompraXproducto
                        {
                            IdCompra = negocioCompra.ObtenerUltimaCompraId(),
                            IdProducto = Convert.ToInt32(ddlProducto.SelectedValue),
                            Cantidad = Convert.ToInt32(txtCantidad.Text),
                            PrecioXunidad = Decimal.Parse(textoprecioXunidad),
                            precioXcantidad = Decimal.Parse(textoprecioXcantidad)
                        };

                        //string textoprecioXunidad = lblPrecio.Text.Replace("$", "").Trim();
                        //if (decimal.TryParse(textoprecioXunidad, out decimal precioXunidad))
                        //{
                        //    compraXproducto.PrecioXunidad = precioXunidad;
                        //}

                        //compraXproducto.precioXcantidad = compraXproducto.PrecioXunidad * compraXproducto.Cantidad;

                        listaCompraXProducto.Add(compraXproducto);

                        NegocioStock negocioStock = new NegocioStock();
                        negocioStock.ActualizarStock(compraXproducto.IdProducto, compraXproducto.Cantidad);

                        //Actualizar el precio del producto
                        NegocioProducto negocioProducto = new NegocioProducto();
                        negocioProducto.actualizarPrecio(compraXproducto.IdProducto, compraXproducto.PrecioXunidad);


                    }
                }

                negocioproductoxcompra.InsertarComprasConProductos(listaCompraXProducto);

                // Guardar datos en Session
                Session["Proveedor"] = proveedor;
                Session["Usuario"] = usuario;
                Session["Productos"] = productos;
                Session["Total"] = txtTotal.Text;

                // Redirigir al resumen
                Response.Redirect("compraexito.aspx", false);
                Context.ApplicationInstance.CompleteRequest(); // Finaliza la solicitud de manera segura
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
                lblError.Visible = true;
            }
        }

        /*protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                // Preparar datos para pasar al resumen
                string proveedor = ddlProveedor.SelectedItem.Text;
                string usuario = Session["NombreUsuario"] as string ?? "Usuario no autenticado";
                DateTime fechaCompra = DateTime.Now;

                // Crear la compra
                Compra compra = new Compra();
                
                    compra.IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                    compra.FechaCompra = fechaCompra;
                    compra.CostoTotal = Convert.ToDecimal(txtTotal.Text);
                    compra.Proveedor = new Proveedor { IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue) };

                NegocioCompra negocioCompra = new NegocioCompra();
                int idCompraGenerada = negocioCompra.InsertarCompra(compra);

                // Crear una lista de productos de la compra
               var productos = new List<CompraXproducto>();
                foreach (RepeaterItem item in rptProductos.Items)
                {
                    DropDownList ddlProducto = (DropDownList)item.FindControl("ddlProducto");
                    TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                    Label lblPrecio = (Label)item.FindControl("lblPrecio");

                    if (ddlProducto != null && txtCantidad != null && lblPrecio != null)
                    {
                        var producto = new CompraXproducto
                        {
                            IdProducto = Convert.ToInt32(ddlProducto.SelectedValue),
                            Cantidad = Convert.ToInt32(txtCantidad.Text),
                            precioXcantidad = Convert.ToDecimal(lblPrecio.Text),
                            Producto = new Producto { IdProducto = Convert.ToInt32(ddlProducto.SelectedValue) }
                        };
                        productos.Add(producto);
                    }
                }

                // Guardar datos en Session
                Session["Proveedor"] = proveedor;
                Session["Usuario"] = usuario;
                Session["Productos"] = productos;
                Session["Total"] = txtTotal.Text;

              

                NegocioProductoXcompra negocioCompraProducto = new NegocioProductoXcompra();
                foreach (var producto in productos)
                {
                    producto.IdCompra = idCompraGenerada; // Asociar la compra a cada producto
                    negocioCompraProducto.InsertarCompraConProductos(producto); // Insertar el producto
                }

                // Redirigir al resumen
                
                Response.Redirect("compraexito.aspx");
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes agregar un mensaje de error o redirigir a una página de error
                Console.WriteLine("Error: " + ex.Message);
                // Mostrar un mensaje en la UI si es necesario
                lblError.Text = "Hubo un error al procesar la compra.";
            }
        }*/
        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("MenuCompras.aspx"); 
        }

        protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {

            NegocioProducto negocioProducto = new NegocioProducto();
            TextBox txtPrecioUnitario = (TextBox)sender;

            // Obtener el contenedor (RepeaterItem) del TextBox
            RepeaterItem item = (RepeaterItem)txtPrecioUnitario.NamingContainer;

            DropDownList ddlProducto = (DropDownList)item.FindControl("ddlProducto");
            Label lblPrecio = (Label)item.FindControl("lblPrecio");

            // Obtener el TextBox de Cantidad
            TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");

            if (ddlProducto != null && lblPrecio != null)
            {
                int productoId;
                if (int.TryParse(ddlProducto.SelectedValue, out productoId) && productoId > 0)
                {
                    try
                    {


                        decimal precioUnitario;
                        if (decimal.TryParse(txtPrecioUnitario.Text, out precioUnitario) && precioUnitario > 0)
                        {
                            decimal precioTotal = precioUnitario * int.Parse(txtCantidad.Text);
                            lblPrecio.Text = precioTotal.ToString("C");
                        }
                        else
                        {
                            txtPrecioUnitario.Text = "1";
                            decimal precioTotal = Decimal.Parse(txtPrecioUnitario.Text) * int.Parse(txtCantidad.Text);
                            lblPrecio.Text = precioTotal.ToString("C");
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
    }
}
