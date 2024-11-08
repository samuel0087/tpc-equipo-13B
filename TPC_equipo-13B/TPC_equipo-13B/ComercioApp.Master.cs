using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_13B
{
    public partial class ComercioApp : System.Web.UI.MasterPage
    {
        public bool Admin { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
                string rutaActual = Request.RawUrl;

                if (Session["Usuario"] == null)
                {
                    if (!rutaActual.Contains("Login.aspx"))
                    {
                        Response.Redirect(ResolveUrl("~/Login.aspx"), false);

                    }

                }
                else
                {

                    if(!IsPostBack) { 

                        if (Session["Admin"]  != null)
                        {
                            if (!((bool)Session["Admin"]))
                            {
                                if (rutaActual.Contains("Administrador"))
                                {
                                    Response.Redirect(ResolveUrl("~/Default.aspx"), false);

                                }
                            }
                        }
                    }
                }

        }
    }
}