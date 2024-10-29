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
        public bool confirmarEliminacion = false;
        public Marca Marca { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnAñadir.Visible = true;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    NegocioMarca negocio = new NegocioMarca();
                    Marca = new Marca();
                    Marca = negocio.getOne(id);

                    if( Marca == null || Marca.IdMarca == 0)
                    {
                        Response.Redirect("VerMarcas.aspx");
                    }

                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;

                    
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


        //Metodo para validar campo cuando cambia el texto
        //protected void txtNombreMarca_TextChanged(object sender, EventArgs e)
        //{
        //    validarCampo(txtNombreMarca.Text);
        //    if(lblError.Text != "")
        //    {
        //        return;
        //    }

        //}

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
            confirmarEliminacion = true;
        }

        protected void txtNombreMarca_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfrimarEliminacion_Click(object sender, EventArgs e)
        {
            NegocioMarca negocio = new NegocioMarca();
            try
            {
                negocio.EliminarMarca(Marca);
                Response.Redirect("VerMarcas.aspx");
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