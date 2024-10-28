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
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Marca=new Marca();
            producto.Tipo = new Tipo();
            NegocioProducto negocioProducto = new NegocioProducto();

            producto.Codigo = int.Parse(txtCodigo.Text);
            producto.Nombre=TxtNombre.Text;
            producto.Marca.IdMarca=int.Parse(TxtMarca.Text);
            producto.Tipo.IdTipo = int.Parse(TxtIdTipo.Text);

            negocioProducto.AgregarProducto(producto);

            Response.Redirect("ExitoProducto.aspx");


        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("productos.aspx");

        }
    }
}