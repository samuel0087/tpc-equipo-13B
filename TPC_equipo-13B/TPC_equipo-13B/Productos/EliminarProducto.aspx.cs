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
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["producto"] != null)
                {
                    Producto producto = (Producto)Session["producto"];

                    lblIdProducto.Text=producto.IdProducto.ToString();
                    LblCodigo.Text = producto.Codigo.ToString();
                    lblNombre.Text = producto.Nombre.ToString();
                    lblMarca.Text = producto.Marca.ToString();
                }
                else
                {
                    Response.Redirect("FaltamensajedeError");
                }
            
            
            }
            
        }
        protected void btnsi_Click(object sender, EventArgs e)
        {
            if (Session["producto"] != null) 
            {
                Producto productoaeliminar = (Producto)Session["producto"];
                int idproductoaeliminar = productoaeliminar.IdProducto;
                NegocioProducto negocioProducto = new NegocioProducto();
                negocioProducto.EliminarProducto(idproductoaeliminar);

                Response.Redirect("exitoproductoeliminado.aspx");


            }
            else
            {
                Response.Redirect("PaginaDeError.aspx"); //Falta crear la pagina de error aclaro
            }
            
        }
        protected void btnno_Click(object sender, EventArgs e)
        {
            Response.Redirect("productos.aspx");
        }
    }
}