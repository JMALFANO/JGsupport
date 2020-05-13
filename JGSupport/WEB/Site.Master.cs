using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class CRM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");
            else
            {
                if ((int)Session["PrivilegioUsuario"] <= 3) HyperLinkAdministracion.Style.Add("display", "none");

                if ((int)Session["PrivilegioUsuario"] <= 2) HyperLinkNuevaSolicitud.Style.Add("display", "none");

                if ((int)Session["PrivilegioUsuario"] <= 1) HyperLinkNuevoParte.Style.Add("display", "none");
            }
            */

            }
        }
    }
