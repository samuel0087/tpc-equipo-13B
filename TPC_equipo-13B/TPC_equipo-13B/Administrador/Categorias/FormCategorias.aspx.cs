using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Security.Cryptography.X509Certificates;

namespace TPC_equipo_13B.Categorias
{
    public partial class FormCategorias : System.Web.UI.Page
    {
        public bool confirmarEliminacion = false;
        public Categoria Categoria{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    NegocioCategoria negocio = new NegocioCategoria();
                    Categoria = new Categoria();
                    Categoria = negocio.getOne(id);

                    if (Categoria == null || Categoria.IdCategoria == 0)
                    {
                        Response.Redirect("VerMarcas.aspx");
                    }

                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;

                    if (!IsPostBack)
                    {
                        txtNombreCategoria.Text = Categoria.Nombre;

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
            validarCampo(txtNombreCategoria.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioCategoria negocio = new NegocioCategoria();

            try
            {
                if (Categoria == null)
                {
                    Categoria = new Categoria();
                    Categoria.Nombre = txtNombreCategoria.Text;
                    negocio.AgregarCategoria(Categoria);
                    lblError.Text = "Guardado exitosamente";
                    lblError.CssClass = "exito";
                    txtNombreCategoria.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {

            validarCampo(txtNombreCategoria.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioCategoria negocio = new NegocioCategoria();

            try
            {
                if (Categoria != null)
                {
                    Categoria.Nombre = txtNombreCategoria.Text;
                    negocio.ModificarCategoria(Categoria);
                }

                Response.Redirect("VerCategorias.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            validarCampo(txtNombreCategoria.Text);
            if(lblError.Text != "")
            {
                return;
            }

        }

        public void validarCampo(string text)
        {
            string error = "";
            lblError.CssClass = "error";
            try
            {
                //dar una validacion al campo
                if (!string.IsNullOrEmpty(text))
                {
                    NegocioCategoria negocio = new NegocioCategoria();
                    var aux = negocio.getOneByNombre(text);

                    if (aux != null)
                    {
                        if ((aux.Nombre != null) || (aux.IdCategoria != 0))
                        {
                            error = "existente";
                        }
                    }

                }
                else
                {
                    error = "vacio";
                }

                if (error == "vacio")
                {
                    lblError.Text = "Campo vacio, ingrese un nombre valido";
                }
                else if (error == "existente")
                {
                    lblError.Text = "El nombre ya existe";
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfrimarEliminacion_Click(object sender, EventArgs e)
        {
            NegocioCategoria negocio = new NegocioCategoria();
            try
            {
                negocio.EliminarCategoria(Categoria);
                Response.Redirect("VerCategorias.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
        }
    }
}