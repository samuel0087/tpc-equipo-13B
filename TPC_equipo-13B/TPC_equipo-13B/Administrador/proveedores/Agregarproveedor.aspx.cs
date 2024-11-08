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
    public partial class Formulario_web113 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioRol negocio = new NegocioRol();
                ddlRoles.DataSource = negocio.listar();
                ddlRoles.DataBind();



            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            NegocioProveedor negocioProveedor = new NegocioProveedor();

            proveedor.Nombre = txtNombre.Text;
            proveedor.Apellido=TxtApelldio.Text;
            proveedor.Email=TxtEmail.Text;
            proveedor.Telefono=TxtTelefono.Text;
            proveedor.Celular=TxtCelular.Text;
            proveedor.Pais=TxtPais.Text;
            proveedor.Direccion=TxtDireccion.Text;
            proveedor.Provincia=TxtProvincia.Text;

            negocioProveedor.AgregarProveedor(proveedor);

            Response.Redirect("ExitoProveedor.aspx");
        }
        protected void btnCancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    }
}