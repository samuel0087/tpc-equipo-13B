using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        public bool confirmarEliminacion = false;
        public bool confirmarModificacion = false;
        public Producto Producto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioMarca marcaNegocio = new NegocioMarca();
            NegocioTipo tipoNegocio = new NegocioTipo();

            try
            {
                btnAñadir.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;

                if (!IsPostBack)
                {
                    //ddl para Productos
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Nombre";
                    ddlMarca.DataBind();

                    //ddl para tipos
                    ddlTipo.DataSource = tipoNegocio.listar(true);
                    ddlTipo.DataValueField = "IdTipo";
                    ddlTipo.DataTextField = "Nombre";
                    ddlTipo.DataBind();
                }

                
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    NegocioProducto negocio = new NegocioProducto();
                    Producto = new Producto();
                    Producto = negocio.getOne(id);

                    if (Producto == null || Producto.IdProducto == 0)
                    {
                        Response.Redirect("VerProductos.aspx");
                    }

                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;


                    if (!IsPostBack)
                    {
                        txtCodigo.Text = Producto.Codigo.ToString();
                        txtCodigo.Enabled = false;
                        txtNombreProducto.Text = Producto.Nombre;
                        ddlMarca.SelectedValue = Producto.Marca.IdMarca.ToString();
                        ddlTipo.SelectedValue = Producto.Tipo.IdTipo.ToString();
                        txtGanancia.Text = Producto.Ganancia.ToString();

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            confirmarEliminacion = true;

        }

        protected void btnConfrimarEliminacion_Click(object sender, EventArgs e)
        {
            NegocioProducto negocio = new NegocioProducto();
            try
            {
                negocio.EliminarProducto(Producto);
                Response.Redirect("VerProductos.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
            confirmarModificacion = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            confirmarModificacion = true;
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Producto == null || Producto.IdProducto == 0)
                {
                    Producto = new Producto();
                    Producto.Marca = new Marca();
                    Producto.Tipo = new Tipo();
                }

                Producto.Tipo = new Tipo();
                NegocioProducto negocioProducto = new NegocioProducto();
                NegocioStock negocioStock = new NegocioStock();

                Producto.Codigo = int.Parse(txtCodigo.Text);
                Producto.Nombre = txtNombreProducto.Text;
                Producto.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
                Producto.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                Producto.Ganancia = Decimal.Parse(txtGanancia.Text);
                Producto.Cantidad = 0;

                negocioProducto.AgregarProducto(Producto);

                Producto = negocioProducto.getOneByCodigo(Producto.Codigo);
                negocioStock.InsertarStock(Producto);

                Response.Redirect("VerProductos.aspx");



            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnConfirmarModificacion_Click(object sender, EventArgs e)
        {
            NegocioProducto negocio = new NegocioProducto();

            try
            {
                if (Producto != null)
                {
                    Producto.Codigo = int.Parse(txtCodigo.Text);
                    Producto.Nombre = txtNombreProducto.Text;
                    Producto.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                    Producto.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
                    Producto.Ganancia = Decimal.Parse(txtGanancia.Text);

                    negocio.ModificarProducto(Producto);

                }

                Response.Redirect("VerProductos.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}