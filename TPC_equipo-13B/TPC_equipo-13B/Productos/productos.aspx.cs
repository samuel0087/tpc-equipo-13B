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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioProducto negocioProducto = new NegocioProducto();

                GridViewProductos.DataSource = negocioProducto.listar();
                GridViewProductos.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProductos.aspx");
        }
        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                /*int idUsuario = Convert.ToInt32(e.CommandArgument);
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                Usuario UsuarioaModificar = negocioUsuario.buscarUsuarioPorId(idUsuario);
                if (UsuarioaModificar != null)
                {
                    Session["UsuarioaModificar"] = UsuarioaModificar;
                }

                Response.Redirect("Modificar.aspx");*/
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