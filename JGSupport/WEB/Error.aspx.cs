using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Obtengo error por GET
            var errorMessage = Request.QueryString["errorMessage"];
            if (errorMessage != null)
            {
                setErrorMessage(errorMessage);
            }
            else
            //Obtengo error por session
            if (Session["errorMessage"] != null)
            {
                Exception exception = (Exception)Session["errorMessage"];
                setErrorMessage(exception.Message);
            }
        }

        /***
         * Establezco mensaje de error
         */
        protected void setErrorMessage(String message)
        {
            errorLabel.Text = "Error message: " + message;
        }
    }
}