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
    public partial class Formulario_web116 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ProveedoraModificar"] != null)
            {
                Proveedor proveedor = (Proveedor)Session["ProveedoraModificar"];


                /*txtIdUsuario.Text = usuario.IdUsuario.ToString();*/
                txtNombre.Text = proveedor.Nombre;
                TextApellido.Text = proveedor.Apellido;
                TextEmail.Text = proveedor.Email;
                TextTelefono.Text= proveedor.Telefono;
                TextCelular.Text = proveedor.Celular;
                TextDireccion.Text= proveedor.Direccion;
                TextProvincia.Text= proveedor.Provincia;
                TextPais.Text= proveedor.Pais;


            }
            else
            {
                Response.Redirect("AgregarPaginaDeError_Falacrear");
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NegocioProveedor negocioProveedor = new NegocioProveedor();
            Proveedor ProveedorModificado = (Proveedor)Session["ProveedoraModificar"];

            /*usuarioModificado.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);*/
            ProveedorModificado.Nombre = txtNombre.Text;
            ProveedorModificado.Apellido = TextApellido.Text;
            ProveedorModificado.Email=TextEmail.Text;
            ProveedorModificado.Telefono = TextTelefono.Text;
            ProveedorModificado.Celular = TextCelular.Text;
            ProveedorModificado.Direccion = TextDireccion.Text;
            ProveedorModificado.Provincia = TextProvincia.Text;
            ProveedorModificado.Pais = TextPais.Text;

            negocioProveedor.ModificarProveedor(ProveedorModificado);

            Response.Redirect("Proveedormodificadoconexito.aspx");


        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    }
}