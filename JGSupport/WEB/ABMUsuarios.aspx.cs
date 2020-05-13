using System;
using BL;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class ABMUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");

            if (!(bool)Session["sessionActiva"] == true) Response.Redirect("~/Login.aspx");

            if ((int)Session["PrivilegioUsuario"] <= 2)
            {
                divActivoPrivileigio.Style.Add("display", "none");
            }
         
            if (!IsPostBack) {
                String accion = Request.QueryString["accion"];
                int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;

                CargarCategorias();

                switch (accion) {
                    case "micuenta":
                        CargarUsuario((int)Session["IdUsuario"]);
                        this.btnGuardarUsuario.Text = "Modificar";
                        break;

                    case "modificar":
                        CargarUsuario(id);
                        this.btnGuardarUsuario.Text = "Modificar";
                        break;
                    case "nuevo":
                        this.btnGuardarUsuario.Text = "Agregar";
                        break;

                }
            }
        }

        protected void CargarCategorias() {

            this.DropDownListCategorias.DataSource = new blCategoria().Listar();
            this.DropDownListCategorias.DataTextField = "privilegio_desc";
            this.DropDownListCategorias.DataValueField = "id_privilegio";
            this.DropDownListCategorias.DataBind();
        }


        protected void CargarUsuario(int id) {
            Personal personal = new blPersonal().ObtenerPorId(id);
            personal.PersonalId = id;

            this.TextBoxNombre.Text = personal.Nombre;
            this.TextBoxApellido.Text = personal.Apellido;
            this.TextBoxMail.Text = personal.Mail;
            this.TextBoxTelefono.Text = personal.Telefono;
            this.TextBoxContraseña.Text = personal.Contraseña;
            this.ListBoxAcitvo.Text= personal.Activo.ToString();

            this.DropDownListCategorias.SelectedIndex = DropDownListCategorias.Items.IndexOf(DropDownListCategorias.Items.FindByValue(personal.Privilegio.id_privilegio.ToString()));
          
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e) {
            String accion = Request.QueryString["accion"];
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            switch (accion) {
                case "micuenta":
                    this.ActualizarMiCuenta();
                    Response.Redirect("~/Configuracion.aspx");
                    break;
                case "modificar":
                    this.ActualizarUsuario();
                    Response.Redirect("~/ListarUsuarios.aspx");
                    break;
                case "nuevo":
                    this.CrearUsuario();
                    Response.Redirect("~/ListarUsuarios.aspx");
                    break;
            }

      
        }


        protected void CrearUsuario() {
            Personal usuario = ObtenerUsuarioFormulario();
            new blPersonal().Guardar(usuario);
        }

        protected void ActualizarMiCuenta()
        {           
            Personal personal = ObtenerUsuarioFormulario();
            personal.PersonalId = (int)Session["IdUsuario"];
            new blPersonal().Guardar(personal);
        }

        protected void ActualizarUsuario() {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            Personal personal = ObtenerUsuarioFormulario();
            personal.PersonalId = id;
            new blPersonal().Guardar(personal);
        }

        protected Personal ObtenerUsuarioFormulario() {
            Personal personal = new Personal();

            personal.PersonalId = null;
            personal.Nombre= this.TextBoxNombre.Text;
            personal.Apellido = this.TextBoxApellido.Text;
            personal.Mail = this.TextBoxMail.Text;
            personal.Telefono = this.TextBoxTelefono.Text;
            personal.Contraseña = this.TextBoxContraseña.Text;
            personal.Activo = bool.Parse(this.ListBoxAcitvo.Text);
            personal.Privilegio.id_privilegio = int.Parse(DropDownListCategorias.SelectedValue);
            return personal;
        }

        protected void DropDownListActivo_SelectedIndexChanged(object sender, EventArgs e) {

        }

       
    }
}