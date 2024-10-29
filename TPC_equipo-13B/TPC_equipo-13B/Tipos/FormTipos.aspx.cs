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
        public bool confirmarEliminacion = false;
        public Tipo Tipo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    NegocioTipo negocio = new NegocioTipo();
                    Tipo = new Tipo();
                    Tipo = negocio.getOne(id);

                    if (Tipo == null || Tipo.IdTipo == 0)
                    {
                        Response.Redirect("VerTipos.aspx");
                    }

                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnAñadir.Visible = false;

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
            confirmarEliminacion = true;
        }

        protected void txtNombreTipo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfrimarEliminacion_Click(object sender, EventArgs e)
        {
            NegocioTipo negocio = new NegocioTipo();
            try
            {
                negocio.EliminarTipo(Tipo);
                Response.Redirect("VerTipos.aspx");
            }
            catch(Exception ex) 
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