using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class Formulario_web118 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar los datos de la compra desde la sesión
                lblProveedor.Text = Session["Proveedor"] as string ?? "Proveedor no especificado";
                lblUsuario.Text = Session["Usuario"] as string ?? "Usuario no especificado";

                // Cargar los productos
                var productos = Session["Productos"] as List<dynamic>;
                if (productos != null && productos.Count > 0)
                {
                    // Filtrar los productos seleccionados (cantidad > 0)
                    var productosSeleccionados = productos.Where(p =>
                    {
                        int cantidad;
                        return int.TryParse(p.Cantidad, out cantidad) && cantidad > 0;
                    }).ToList();

                    // Enlazar los productos al Repeater
                    rptProductos.DataSource = productosSeleccionados;
                    rptProductos.DataBind();
                }

                // Cargar el total desde la sesión
                string total = Session["Total"] as string;
                if (!string.IsNullOrEmpty(total))
                {
                    lblTotal.Text = total;
                }
                else
                {
                    lblTotal.Text = "0.00";
                }
            }
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para guardar la compra en la base de datos

            // Luego redirigir a una página de éxito
            Response.Redirect("MenuCompras.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Lógica para cancelar la operación y regresar al formulario de compras
            Response.Redirect("FormCompras.aspx");
        }
    }
}