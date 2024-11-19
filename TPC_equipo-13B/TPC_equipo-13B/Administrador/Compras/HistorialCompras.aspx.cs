using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web119 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            NegocioCompra negocioCompra = new NegocioCompra();
            if (!IsPostBack)
            {
                gvCompras.DataSource = negocioCompra.CargarCompras();
                gvCompras.DataBind();
               
            }
            
        }

       

        protected void gvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {   NegocioProductoXcompra negocioProductoXcompra= new NegocioProductoXcompra();
                int idCompra = Convert.ToInt32(e.CommandArgument);
                gvDetalle.DataSource = negocioProductoXcompra.CargarDetallesCompra(idCompra);
                gvDetalle.DataBind();
                // Mostrar el modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#detalleModal').modal('show');", true);
            }
        }
        
        /*protected void gvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                // Crear la instancia de la clase NegocioProductoXcompra
                NegocioProductoXcompra negocioProductoXcompra = new NegocioProductoXcompra();

                // Obtener el ID de la compra desde el argumento del comando
                int idCompra = Convert.ToInt32(e.CommandArgument);

                // Cargar los detalles de la compra en el GridView gvDetalle
                gvDetalle.DataSource = negocioProductoXcompra.CargarDetallesCompra(idCompra);
                gvDetalle.DataBind();

                // Mostrar el modal con los detalles de la compra
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "showModal();", true);
            }
        }*/
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuCompras.aspx");
        }


    }
}