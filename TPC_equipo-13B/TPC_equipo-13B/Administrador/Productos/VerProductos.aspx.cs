using Dominio;
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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        public bool Buscar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Buscar"] != null)
            {
                Buscar = true;
            }

            if (!IsPostBack)
            {
                NegocioProducto negocioProducto = new NegocioProducto();
                Session.Add("ListaProductos", negocioProducto.listar());


                GridViewProductos.DataSource = (List<Producto>)Session["ListaProductos"];
                GridViewProductos.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProductos.aspx");
        }
        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("FormProductos.aspx?id=" + idProducto);
            }
            else if (e.CommandName == "Eliminar")
            {   
                NegocioProducto negocioProducto = new NegocioProducto();
                int idprducto = Convert.ToInt32(e.CommandArgument);
                Producto producto = negocioProducto.buscarProductoPorId(idprducto);
                if (producto != null) 
                {
                    Session["Producto"]= producto;
                }

                Response.Redirect("EliminarProducto.aspx");

            }
        }
    }
}