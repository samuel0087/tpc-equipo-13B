using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B.Tipos
{
    public partial class FormTipos : System.Web.UI.Page
    {
        public Tipo Tipo { get; set; }

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

                    NegocioTipo negocio = new NegocioTipo();
                    int id = int.Parse(Request.QueryString["id"]);
                    Tipo = new Tipo();
                    Tipo = negocio.getOne(id);
                    if (!IsPostBack)
                    {
                        txtNombreTipo.Text = Tipo.Nombre;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo para validar campo cuando cambia el texto
        //protected void txtNombreTipo_TextChanged(object sender, EventArgs e)
        //{
        //    validarCampo(txtNombreTipo.Text);
        //    if(lblError.Text != "")
        //    {
        //        return;
        //    }

        //}

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            validarCampo(txtNombreTipo.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioTipo negocio = new NegocioTipo();

            try
            {
                if (Tipo == null)
                {
                    Tipo = new Tipo();
                    Tipo.Nombre = txtNombreTipo.Text;
                    negocio.AgregarTipo(Tipo);
                    lblError.Text = "Guardado exitosamente";
                    lblError.CssClass = "exito";
                    txtNombreTipo.Text = "";
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
                    NegocioTipo negocio = new NegocioTipo();
                    var aux = negocio.getOneByNombre(text);

                    if (aux != null)
                    {
                        if ((aux.Nombre != null) || (aux.IdTipo != 0))
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


        protected void btnModificar_Click(object sender, EventArgs e)
        {

            validarCampo(txtNombreTipo.Text);
            if (lblError.Text != "")
            {
                return;
            }
            NegocioTipo negocio = new NegocioTipo();

            try
            {
                if (Tipo != null)
                {
                    Tipo.Nombre = txtNombreTipo.Text;
                    negocio.ModificarTipo(Tipo);
                }

                Response.Redirect("VerTipos.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void txtNombreTipo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}