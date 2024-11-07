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
    public partial class Formulario_web115 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

                if (Session["ProveedoraEliminar"] != null)
                {
                    Proveedor proveedoraeliminar = (Proveedor)Session["ProveedoraEliminar"];


                    lblIdProveedor.Text = proveedoraeliminar.IdProveedor.ToString();
                    lblNombre.Text = proveedoraeliminar.Nombre;
                    lblApellido.Text = proveedoraeliminar.Apellido;
                    lblemail.Text=proveedoraeliminar.Email;
                    lbltelefono.Text=proveedoraeliminar.Telefono;
                    lblcelular.Text=proveedoraeliminar.Celular;
                    lbldireccion.Text = proveedoraeliminar.Direccion;
                    lblprovincia.Text=proveedoraeliminar.Provincia;
                    lblpais.Text = proveedoraeliminar.Pais;
                }
                else
                {

                    Response.Redirect("PaginaDeError.aspx"); // Falta crear la pagina de error
                }

            }

        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            if (Session["ProveedoraEliminar"] != null)
            {
                Proveedor Proveedoraeliminar = (Proveedor)Session["ProveedoraEliminar"];

                int idproveedor = Proveedoraeliminar.IdProveedor;

                NegocioProveedor negocioprovedor = new NegocioProveedor();

                negocioprovedor.EliminarProveedor(idproveedor);

                Response.Redirect("Proveedores.aspx");

            }
            else
            {

                Response.Redirect("PaginaDeError.aspx"); //Falta crear la pagina de error aclaro
            }
        }
        protected void btnno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    }
}