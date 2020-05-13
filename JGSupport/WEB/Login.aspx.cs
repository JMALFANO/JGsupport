using System;
using BL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WEB {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {


            int PrivilegioUsuario;
            int IdUsuario;

            string usuario, contraseña;

            usuario = TextBoxMail.Text.ToString();
            contraseña = TextBoxContraseña.Text.ToString();




            PrivilegioUsuario = new blPersonal().ValidarUsuario(usuario, contraseña);


            switch (PrivilegioUsuario)
            {
                case -1:
                    LabelRespuesta.Text = "Usuario o contraseña incorrectos.";
                    break;
                case -2:
                    LabelRespuesta.Text = "Esta cuenta se encuentra desactivada.";
                    break;
                default:

                    IdUsuario = new blPersonal().ObtenerIdUsuario(usuario, contraseña);

                    Session["usuario"] = usuario;
                    Session["privilegioUsuario"] = PrivilegioUsuario;
                    Session["sessionActiva"] = true;
                    Session["IdUsuario"] = IdUsuario;
                    Response.Redirect("~/Home.aspx");            

                    //      FormsAuthentication.RedirectFromLoginPage(Home.UserName, Home.RememberMeSet);
                    break;
            }
        }
    

    }
}