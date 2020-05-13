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
    public partial class AltaParte : System.Web.UI.Page
    {
        String solicitudId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");

            if (!(bool)Session["sessionActiva"] == true) Response.Redirect("~/Login.aspx");

            if ((int)Session["PrivilegioUsuario"] < 2) Response.Redirect("~/Error.aspx?errorMessage=No+tenés+los+permisos+suficientes+para+ver+esta+página.");

     

            if (!Page.IsPostBack)
            {

                CargarClientes();

                CargarTecnicos();

                LabelFecha.Text = DateTime.Today.ToShortDateString();

                solicitudId = Request.QueryString["solicitud"];
                String accion = Request.QueryString["accion"];
                int tareaId = int.TryParse(Request.QueryString["tarea"], out tareaId) ? tareaId : 0;
                switch (accion)
                {
                    case "modificar":
                        CargarParte(tareaId);
                        this.ButtonGuardar.Text = "Modificar";
                        break;
                    case "nuevo":
                        this.ButtonGuardar.Text = "Crear";
                        break;
                }

               

              

          
            }
        }

        protected void CargarClientes()
        {
            this.DropDownListClientes.DataSource = new blPersonal().ListarClientes();
            this.DropDownListClientes.DataTextField = "Nombre";
            this.DropDownListClientes.DataValueField = "PersonalId";
            this.DropDownListClientes.DataBind();
        }

        protected void CargarTecnicos()
        {
            this.DropDownListTecnico.DataSource = new blPersonal().ListarTecnicos();
            this.DropDownListTecnico.DataTextField = "Nombre";
            this.DropDownListTecnico.DataValueField = "PersonalId";
            this.DropDownListTecnico.DataBind();
        }

        protected void CargarPedidos(int pedido)
        {
            this.DropDownListPedidos.DataSource = new blSolicitud().ListarPorCliente(pedido);
            this.DropDownListPedidos.DataTextField = "DescripcionTarea";
            this.DropDownListPedidos.DataValueField = "SolicitudId";
            this.DropDownListPedidos.DataBind();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
            int tareaId = int.TryParse(Request.QueryString["tarea"], out tareaId) ? tareaId : 0;
            switch (accion)
            {
                case "modificar":
                    this.ActualizarParte();
                    break;
                case "nuevo":
                    this.CrearParte();
                    break;
            }
            Response.Redirect("~/Home.aspx");
        }

        protected void CargarParte(int tareaid)
        {
            Tarea tarea = new blTarea().ObtenerPorId(tareaid);
            tarea.TareaId = tareaid;

            LabelFecha.Text = tarea.Fecha.ToString();
            TextBoxHoraInicio.Text = tarea.HoraInicio.ToString();
            TextBoxHoraFin.Text = tarea.HoraFin.ToString();
            TextBoxReporte.Text = tarea.Reporte;

            this.DropDownListClientes.SelectedIndex = DropDownListClientes.Items.IndexOf(DropDownListClientes.Items.FindByValue(tarea.ClienteId.ToString()));

            CargarPedidos(tarea.ClienteId);

            this.DropDownListPedidos.SelectedIndex = DropDownListPedidos.Items.IndexOf(DropDownListPedidos.Items.FindByValue(tarea.SolicitudId.ToString()));

            this.DropDownListTecnico.SelectedIndex = DropDownListTecnico.Items.IndexOf(DropDownListTecnico.Items.FindByValue(tarea.TecnicoAsignado.ToString()));

            if (tarea.ModoSolucion == true) RadioButtonPresencial.Checked = true;
            if (tarea.ModoSolucion == false) RadioButtonRemoto.Checked = true;
        
        }

        protected void CrearParte()
        {
            Tarea tarea = ObtenerTareaFormulario();
            new blTarea().Guardar(tarea);
        }

        protected void ActualizarParte()
        {
            int tareaId = int.TryParse(Request.QueryString["tarea"], out tareaId) ? tareaId : 0;
            Tarea tarea = ObtenerTareaFormulario();
            tarea.TareaId = tareaId;
            new blTarea().Guardar(tarea);


            if (CheckBoxFinalizado.Checked == true)
            {
                Solicitud solicitud = new Solicitud();
                solicitud.SolicitudId = tarea.SolicitudId;
                solicitud.FechaFin = DateTime.Today;
                solicitud.Estado = (EstadoSolicitudEnum)Enum.Parse(typeof(EstadoSolicitudEnum), "Finalizado");
                new blSolicitud().FinalizarSolicitudId(solicitud);
            }

        }

        protected Tarea ObtenerTareaFormulario()
        {
            Tarea tarea = new Tarea();
            tarea.TareaId = null;
            tarea.SolicitudId = int.Parse(DropDownListPedidos.SelectedValue);
            tarea.ClienteId = int.Parse(DropDownListClientes.SelectedValue);
            tarea.Reporte = this.TextBoxReporte.Text;
            tarea.HoraInicio = TimeSpan.Parse(TextBoxHoraInicio.Text);
            tarea.HoraFin = TimeSpan.Parse(TextBoxHoraFin.Text);
            tarea.Fecha = Convert.ToDateTime(LabelFecha.Text);
            tarea.TecnicoAsignado = int.Parse(DropDownListTecnico.SelectedValue);

            if (RadioButtonPresencial.Checked == true) tarea.ModoSolucion = true;
            if (RadioButtonRemoto.Checked == true) tarea.ModoSolucion = false;

            return tarea;
        }

        protected void DropDownListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPedidos(Convert.ToInt32(DropDownListClientes.SelectedValue));
        }

        protected void RadioButtonSeleccionado()  {

            if (RadioButtonRemoto.Checked == true) RadioButtonPresencial.Checked = false;
            else if (RadioButtonPresencial.Checked == true) RadioButtonRemoto.Checked = false;      

        }

        protected void RadioButtonPresencial_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonRemoto.Checked = false;
         //   if (RadioButtonRemoto.Checked == true) RadioButtonPresencial.Checked = false;
        //    else if (RadioButtonPresencial.Checked == true) RadioButtonRemoto.Checked = false;
        }

        protected void RadioButtonRemoto_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonPresencial.Checked = false;
        //if (RadioButtonRemoto.Checked == true) RadioButtonPresencial.Checked = false;
        //    else if (RadioButtonPresencial.Checked == true) RadioButtonRemoto.Checked = false;
        }
    }
}