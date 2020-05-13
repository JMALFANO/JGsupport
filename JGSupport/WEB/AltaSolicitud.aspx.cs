using BL;
using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class AltaSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");

            if (!(bool)Session["sessionActiva"] == true) Response.Redirect("~/Login.aspx");

            if ((int)Session["PrivilegioUsuario"] <= 2) Response.Redirect("~/Error.aspx?errorMessage=No+tenés+los+permisos+suficientes+para+ver+esta+página.");

            if (!IsPostBack)
            {
                CargarClientes();
                CargarTecnicos();
                CargarEstados();
                CargarPrioridad();
                CargarComplejidad();

                LabelFecha.Text = DateTime.Today.ToShortDateString(); 

                String accion = Request.QueryString["accion"];
                int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
                switch (accion)
                {
                    case "modificar":
                        CargarSolicitud(id);
                        this.btnGuardar.Text = "Modificar Solicitud";
                        break;
                    case "nuevo":
                        this.btnGuardar.Text = "Asentar Solicitud";
                        break;
                }
            }

        }

        protected void CargarTecnicos()
        {
            this.DropDownListTecnico.DataSource = new blPersonal().ListarTecnicos();
            this.DropDownListTecnico.DataTextField = "Nombre";
            this.DropDownListTecnico.DataValueField = "PersonalId";
            this.DropDownListTecnico.DataBind();
        }

        protected void CargarClientes()
        {
            this.DropDownListCliente.DataSource = new blPersonal().ListarClientes();
            this.DropDownListCliente.DataTextField = "Nombre";
            this.DropDownListCliente.DataValueField = "PersonalId";
            this.DropDownListCliente.DataBind();
        }

        private void CargarEstados()
        {

            foreach(EstadoSolicitudEnum estado in Enum.GetValues(typeof(EstadoSolicitudEnum)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(EstadoSolicitudEnum), estado), estado.ToString());
                DropDownListEstado.Items.Add(item);
            }

        }

        private void CargarPrioridad()
        {

            foreach (PrioridadSolicitudEnum estado in Enum.GetValues(typeof(PrioridadSolicitudEnum)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(PrioridadSolicitudEnum), estado), estado.ToString());
                DropDownListPrioridad.Items.Add(item);
            }

        }

        private void CargarComplejidad()
        {

            foreach (ComplejidadSolicitudEnum estado in Enum.GetValues(typeof(ComplejidadSolicitudEnum)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(ComplejidadSolicitudEnum), estado), estado.ToString());
                DropDownListComplejidad.Items.Add(item);
            }

        } 

        protected void CrearSolicitud()
        {
            Solicitud solicitud = ObtenerSolicitudFormulario();
            new blSolicitud().Guardar(solicitud);
        }


        protected void ActualizarSolicitud()
        {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            Solicitud solicitud = ObtenerSolicitudFormulario();
            solicitud.SolicitudId = id;

            new blSolicitud().Guardar(solicitud);

            if (DropDownListEstado.Text == "Finalizado")
            {
                solicitud.FechaFin = DateTime.Today;
                new blSolicitud().FinalizarSolicitudId(solicitud);
            }

        }

        protected void CargarSolicitud(int id)
        {
            Solicitud solicitud = new blSolicitud().ObtenerPorSolicitudId(id);
            solicitud.SolicitudId = id;

            this.DropDownListCliente.SelectedIndex = DropDownListCliente.Items.IndexOf(DropDownListCliente.Items.FindByValue(solicitud.Cliente.ToString()));        
            this.DropDownListComplejidad.SelectedIndex = DropDownListComplejidad.Items.IndexOf(DropDownListComplejidad.Items.FindByValue(solicitud.Complejidad.ToString()));
            this.DropDownListEstado.SelectedIndex = DropDownListEstado.Items.IndexOf(DropDownListEstado.Items.FindByValue(solicitud.Estado.ToString()));
            this.DropDownListPrioridad.SelectedIndex = DropDownListPrioridad.Items.IndexOf(DropDownListPrioridad.Items.FindByValue(solicitud.Prioridad.ToString()));
            this.DropDownListTecnico.SelectedIndex = DropDownListTecnico.Items.IndexOf(DropDownListTecnico.Items.FindByValue(solicitud.TecnicoAsignado.ToString()));
            this.LabelFecha.Text = solicitud.FechaInicio.ToString();
            this.TextBoxProblema.Text = solicitud.DescripcionTarea;               
        }

        protected Solicitud ObtenerSolicitudFormulario()
        {
            Solicitud solicitud = new Solicitud();
            solicitud.SolicitudId = null;
            solicitud.Cliente = int.Parse(DropDownListCliente.SelectedValue);
            solicitud.Complejidad = (ComplejidadSolicitudEnum)Enum.Parse(typeof(ComplejidadSolicitudEnum), DropDownListComplejidad.SelectedValue);
            solicitud.Estado = (EstadoSolicitudEnum)Enum.Parse(typeof(EstadoSolicitudEnum), DropDownListEstado.SelectedValue); 
            solicitud.Prioridad = (PrioridadSolicitudEnum)Enum.Parse(typeof(PrioridadSolicitudEnum), DropDownListPrioridad.SelectedValue);
            solicitud.FechaInicio = DateTime.Today;
            solicitud.FechaFin = DateTime.Today;
            solicitud.TecnicoAsignado = int.Parse(DropDownListTecnico.SelectedValue);
            solicitud.DescripcionTarea = this.TextBoxProblema.Text;
         
            return solicitud;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            switch (accion)
            {
                case "modificar":
                    this.ActualizarSolicitud();
                    break;
                case "nuevo":
                    this.CrearSolicitud();
                    break;
            }
            Response.Redirect("~/Home.aspx");
        }

    }
}