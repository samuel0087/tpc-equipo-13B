using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_equipo_13B.Clientes
{
    public partial class FormClientes : System.Web.UI.Page
    {
        public bool confirmarEliminacion = false;
        public Cliente Cliente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if (Session["error"] != null)
                    {
                        Session.Remove("error");
                    }
                }

                btnAñadir.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    NegocioCliente negocio = new NegocioCliente();
                    Cliente = new Cliente();
                    Cliente = negocio.getOne(id);

                    if( Cliente == null || Cliente.ID == 0)
                    {
                        Response.Redirect("VerClientes.aspx");
                    }

                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;

                    
                    if (!IsPostBack)
                    {
                        txtNombreCliente.Text = Cliente.Nombre;
                        txtApellido.Text = Cliente.Apellido;
                        txtDNI.Text = Cliente.DNI.ToString();
                        txtEmail.Text = Cliente.Email;
                        txtTelefono.Text = Cliente.Telefono;
                        txtCelular.Text = Cliente.Celular;
                        txtPais.Text = Cliente.Pais;
                        txtProvincia.Text = Cliente.Provincia;
                        txtDireccion.Text = Cliente.Direccion;
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        protected void btnAñadir_Click(object sender, EventArgs e)
        {

            NegocioCliente negocio = new NegocioCliente();

            try
            {
                if (Cliente == null)
                {
                    Cliente = new Cliente();

                    Cliente.Nombre = txtNombreCliente.Text;
                    Cliente.Apellido = txtApellido.Text;
                    Cliente.DNI = int.Parse(txtDNI.Text);
                    Cliente.Email = txtEmail.Text;
                    Cliente.Telefono = txtTelefono.Text;
                    Cliente.Celular = txtCelular.Text;
                    Cliente.Pais = txtPais.Text;
                    Cliente.Provincia = txtProvincia.Text;
                    Cliente.Direccion = txtDireccion.Text;

                    negocio.AgregarCliente(Cliente);
                    lblError.Text = "Guardado exitosamente";
                    lblError.CssClass = "exito";

                    txtNombreCliente.Text = "";
                    txtApellido.Text = "";
                    txtDNI.Text = "";
                    txtEmail.Text = "";
                    txtTelefono.Text = "";
                    txtCelular.Text = "";
                    txtPais.Text = "";
                    txtProvincia.Text = "";
                    txtDireccion.Text = "";
                }

                if (Request.QueryString["create"]  != null)
                {
                    Session.Add("Cliente", Cliente);
                    Response.Redirect(ResolveUrl("~/Ventas/FormVentas.aspx"), false);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }




        protected void btnModificar_Click1(object sender, EventArgs e)
        {

            NegocioCliente negocio = new NegocioCliente();

            try
            {
                if (Cliente != null)
                {
                    Cliente.Nombre = txtNombreCliente.Text;
                    Cliente.Apellido = txtApellido.Text;
                    Cliente.DNI = int.Parse(txtDNI.Text);
                    Cliente.Email = txtEmail.Text;
                    Cliente.Telefono = txtTelefono.Text;
                    Cliente.Celular = txtCelular.Text;
                    Cliente.Pais = txtPais.Text;
                    Cliente.Provincia = txtProvincia.Text;
                    Cliente.Direccion = txtDireccion.Text;

                    negocio.ModificarCliente(Cliente);
                }

                Response.Redirect("VerClientes.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }


        protected void btnConfrimarEliminacion_Click(object sender, EventArgs e)
        {
            NegocioCliente negocio = new NegocioCliente();
            try
            {
                negocio.EliminarCliente(Cliente);
                Response.Redirect("VerClientes.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
        }
    }
}