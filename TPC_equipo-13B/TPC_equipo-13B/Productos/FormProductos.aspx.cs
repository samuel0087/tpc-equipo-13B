using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        public bool confirmarEliminacion = false;
        public Producto Producto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioProducto marcaNegocio = new NegocioProducto();
            NegocioTipo tipoNegocio = new NegocioTipo();

            try
            {
                btnAñadir.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;

                //ddl para Productos
                ddlMarca.DataSource = marcaNegocio.listar();
                ddlMarca.DataValueField = "IdProducto";
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();

                //ddl para tipos
                ddlTipo.DataSource = tipoNegocio.listar(true);
                ddlTipo.DataValueField = "IdTipo";
                ddlTipo.DataTextField = "Nombre";
                ddlTipo.DataBind();

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
                        txtNombreProducto.Text = Producto.Nombre;
                        ddlMarca.SelectedValue = Producto.Marca.IdMarca.ToString();
                        ddlTipo.SelectedValue = Producto.Tipo.IdTipo.ToString();

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
            if(Producto == null || Producto.IdProducto== 0)
            {
                Producto = new Producto();
            }

            Producto.Tipo = new Tipo();
            NegocioProducto negocioProducto = new NegocioProducto();

            Producto.Codigo = int.Parse(txtCodigo.Text);
            Producto.Nombre = txtNombreProducto.Text;
            Producto.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
            Producto.Marca.IdMarca = int.Parse(ddlTipo.SelectedValue);

            negocioProducto.AgregarProducto(Producto);

            Response.Redirect("ExitoProducto.aspx");


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
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {

        }
    }
}