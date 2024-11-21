using Dominio;
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
        public Cliente Cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ErrorCliente"] != null)
            {
                Session.Remove("ErrorCliente");
            }

            if (Session["Cliente"] != null)
            {
                Cliente = (Cliente)Session["Cliente"];
            }

            txtCantidad.Text = "1";

            if (!IsPostBack)
            {
                CargarProductos();
                CargarMarcas();
                List<Producto> ListaVenta = new List<Producto>();
                Session.Add("ListaVenta", ListaVenta);
                CargarLista();
            }
        }

        private void CargarProductos()
        {   
            NegocioProducto negocioProducto = new NegocioProducto();
            try
            {
                List<Producto> productos = negocioProducto.listar();
                Session.Add("ListadoProductos", productos);
                ddlProductos.DataSource = productos;
                ddlProductos.DataValueField = "IdProducto";
                ddlProductos.DataTextField = "Nombre";
                ddlProductos.DataBind();
                // Agregar opción por defecto
                ddlProductos.Items.Insert(0, new ListItem("Seleccione un producto", ""));
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Error al cargar productos: " + ex.Message;
                //lblMensaje.CssClass = "alert alert-danger";
            }
        }

        private void CargarMarcas()
        {
            NegocioMarca negocio = new NegocioMarca();
            try
            {
                Session.Add("ListadoMarcas",negocio.listar());
                ddlMarcas.DataSource = (List<Marca>)Session["ListadoMarcas"];
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "IdMarca";
                ddlMarcas.DataBind();
                ddlProductos.Items.Insert(0, new ListItem("Seleccione un producto", ""));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarLista()
        {
            dgvProductos.DataSource = (List<Producto>)Session["ListaVenta"];
            dgvProductos.DataBind();
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

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                validarCampo(int.Parse(txtDni.Text));
                if (lblError.Text != "")
                {
                    return;
                }
                Cliente = (Cliente)Session["Cliente"];

                lblCliente.Text = Cliente.Nombre + "" + Cliente.Apellido;
                lblDni.Text = Cliente.DNI.ToString();
                lblEmail.Text = Cliente.Email;
            }
            catch(Exception ex)
            {
                Session.Add("ErrorCliente", "Por favor ingrese un numero de documento valido" );
                return;
            }
            


        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/Administrador/Clientes/FormClientes.aspx?create=true"), false);
        }

        public void validarCampo(int dni)
        {
            string error = "";
            lblError.CssClass = "error";
            try
            {
                //dar una validacion al campo
                if (dni.ToString() != "" && dni > 0)
                {
                    NegocioCliente negocio = new NegocioCliente();
                    var aux = negocio.getOneByDNI(dni);

                    if (aux.ID == 0)
                    {
                        error = "inexistente";
                    }
                    else
                    {
                        Session.Add("Cliente", aux);
                    }


                   

                }
                else
                {
                    error = "vacio";
                }

                if (error == "vacio")
                {
                    lblError.Text = "Campo vacio, ingrese un dni valido";
                }
                else if (error == "inexistente")
                {
                    lblError.Text = "El Cliente no esta registrado";
                }
                else
                {
                    lblError.Text = "";
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnCambiarCliente_Click(object sender, EventArgs e)
        {
            if (Session["Cliente"] != null)
            {
                Session.Remove("Cliente");
            }
            Cliente = null;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioProducto negocio = new NegocioProducto();

            try
            {
                int id = int.Parse(ddlProductos.SelectedItem.Value);
                Producto aux = negocio.buscarProductoPorId(id);
                aux.Cantidad = int.Parse(txtCantidad.Text);
                List<Producto> ListaVenta = (List<Producto>)Session["ListaVenta"];

                if (aux != null)
                {

                    Producto productoExistente = ListaVenta.Find(x => x.IdProducto == aux.IdProducto);
                    if (productoExistente != null)
                    {
                        productoExistente.Cantidad += aux.Cantidad;
                    }
                    else
                    {
                        ((List<Producto>)Session["ListaVenta"]).Add(aux);
                    }

                    dgvProductos.DataSource = ((List<Producto>)Session["ListaVenta"]);
                    DataBind();
                }

                Session["ListaVenta"] = ListaVenta;
                CargarProductos();
                CargarMarcas();


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlMarcas.SelectedItem.Value);
            ddlProductos.DataSource = ((List<Producto>)Session["ListadoProductos"]).FindAll(x => x.Marca.IdMarca == id);
            ddlProductos.DataBind();
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            int aux;
            if(txtCodigo.Text != "")
            {
               aux = int.Parse(txtCodigo.Text);
            }
            else
            {
                CargarProductos();
                CargarMarcas();
                return;
            }

            try
            {
                var resultado = ((List<Producto>)Session["ListadoProductos"]).Find(x => x.Codigo == aux);
                if(resultado != null)
                {
                    ddlProductos.DataSource = (List<Producto>)Session["ListadoProductos"];
                    ddlProductos.DataBind();

                    ddlProductos.SelectedValue = resultado.IdProducto.ToString();
                    ddlMarcas.SelectedValue = resultado.Marca.IdMarca.ToString();
                    lblErrorCodigo.Text = "";
                }
                else
                {
                    lblErrorCodigo.Text = "El codigo de producto no existe, intente nuevamente";
                    txtCodigo.Text = "";
                    CargarProductos();
                    CargarMarcas();
                }

                
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioProducto negocio = new NegocioProducto();
            int id =int.Parse(ddlProductos.SelectedItem.Value);

            try
            {
                Producto aux = negocio.buscarProductoPorId(id);
                if (aux != null)
                {
                    ddlMarcas.SelectedValue = aux.Marca.IdMarca.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {

        }
    }
}