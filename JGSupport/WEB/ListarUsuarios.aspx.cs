using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");

            if (!(bool)Session["sessionActiva"] == true) Response.Redirect("~/Login.aspx");

            if ((int)Session["PrivilegioUsuario"] <= 2) Response.Redirect("~/Error.aspx?errorMessage=No+tenés+los+permisos+suficientes+para+ver+esta+página.");

        }

    }
}