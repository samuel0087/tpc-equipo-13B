using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_equipo_13B.marcas
{
    public partial class FormMarca : System.Web.UI.Page
    {
        public Marca Marca { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;

                    NegocioMarca negocio = new NegocioMarca();
                    int id = int.Parse(Request.QueryString["id"]);
                    Marca = new Marca();
                    Marca = negocio.getOne(id);
                    if (!IsPostBack)
                    {
                        txtNombreMarca.Text = Marca.Nombre;
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        protected void txtNombreMarca_TextChanged(object sender, EventArgs e)
        {
            validarCampo(txtNombreMarca.Text);
            if(lblError.Text != "")
            {
                return;
            }

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            validarCampo(txtNombreMarca.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioMarca negocio = new NegocioMarca();

            try
            {
                if (Marca == null)
                {
                    Marca = new Marca();
                    Marca.Nombre = txtNombreMarca.Text;
                    negocio.AgregarMarca(Marca);
                    lblError.Text = "Guardado exitosamente";
                    lblError.CssClass = "exito";
                    txtNombreMarca.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
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
                    NegocioMarca negocio = new NegocioMarca();
                    var aux = negocio.getOneByNombre(text);

                    if (aux != null)
                    {
                        if ((aux.Nombre != null) || (aux.IdMarca != 0))
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
                else if(error == "existente")
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


        protected void btnModificar_Click1(object sender, EventArgs e)
        {

            validarCampo(txtNombreMarca.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioMarca negocio = new NegocioMarca();

            try
            {
                if (Marca != null)
                {
                    Marca.Nombre = txtNombreMarca.Text;
                    negocio.ModificarMarca(Marca);
                }

                Response.Redirect("VerMarcas.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}