using BL;
using System;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Home : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sessionActiva"] == null) Response.Redirect("~/Login.aspx");

            if (!(bool)Session["sessionActiva"] == true) Response.Redirect("~/Login.aspx");

            if (!Page.IsPostBack)
            {
                CargarClientes();
            }

          /*  TextBoxDesde.Text = DateTime.Today.ToShortDateString();
            TextBoxHasta.Text = DateTime.Today.ToShortDateString();
            */

            switch ((int)Session["PrivilegioUsuario"])
            {
                case 1: //CLIENTE
                    MostrarFormularioCliente();
                    break;
                case 2: //TECNICO
                    MostrarFormularioTecnico();
                    break;
                case 3: //COORDINADOR
                    MostrarFormularioCoordinador();
                    break;
                case 4: //ADMINISTRADOR
                    MostarFormularioAdministrador();
                    break;
            }

        


            /* if ((bool)Session["sessionActiva"] == true)          
             {

             }*/




        }

        private void MostarFormularioAdministrador()
        {
        }

        private void MostrarFormularioCoordinador()
        {
        }

        private void MostrarFormularioTecnico()
        {
            btnNuevoUsuario.Visible = false;
        }

        private void MostrarFormularioCliente()
        {
            this.DropDownListClientes.SelectedIndex = DropDownListClientes.Items.IndexOf(DropDownListClientes.Items.FindByValue(Session["IdUsuario"].ToString()));
            this.DropDownListClientes.Enabled = false;
            btnNuevoUsuario.Visible = false;
            btnNuevaSolicitud.Visible = false;
            btnNuevoParte.Visible = false;

        }

        protected void CargarClientes()
        {

            this.DropDownListClientes.DataSource = new blPersonal().ListarClientes();
            this.DropDownListClientes.DataTextField = "Nombre";
            this.DropDownListClientes.DataValueField = "PersonalId";
            this.DropDownListClientes.DataBind();

            this.DropDownListClientes.Items.Insert(0, new ListItem("* TODOS *", "0"));
        }     
     
         protected void CargarDropDownPedidos(int pedido)
        {
            this.DropDownListPedidos.DataSource = new blSolicitud().ListarPorCliente(pedido);
            this.DropDownListPedidos.DataTextField = "DescripcionTarea";
            this.DropDownListPedidos.DataValueField = "SolicitudId";
            this.DropDownListPedidos.DataBind();

            this.LabelPedido.Visible = true;
            this.DropDownListPedidos.Visible = true;

        }


        protected void CargarListaTareas(int tareas)
        {
            this.GridViewSolicitudTareas.DataSource = new blTarea().ObtenerPorSolicitudId(tareas);
            this.GridViewSolicitudTareas.DataBind();
            this.ButtonVisibleGrillaTareas.Visible = true;
        }

        protected void CargarListaSolicitudes()
        {
            //      this.GridViewClientePedidos.DataSource = new blSolicitud().ObtenerListaPorId(solicitudes);

            LabelFecha.Text = DateTime.Today.ToShortDateString();

            DateTime fechaDesde = Convert.ToDateTime(this.TextBoxDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(this.TextBoxHasta.Text);

            String FD = fechaDesde.ToShortDateString();
            String FH = fechaHasta.ToShortDateString();
            int ClienteSeleccionado = int.Parse(DropDownListClientes.SelectedValue);


            int filtrado = 0;

            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == true) filtrado = 111;
            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == true) filtrado = 101;
            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == false) filtrado = 100;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == true) filtrado = 011;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == false) filtrado = 010;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == true) filtrado = 001;


         //   if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == false) filtrado = 001;


            this.GridViewClientePedidos.DataSource = new blSolicitud().ObtenerPorFormulario(FD, FH, ClienteSeleccionado, filtrado);
            this.GridViewClientePedidos.DataBind();
            this.ButtonVisibleGrillaSolicitudes.Visible = true;
          
            
        }

      /*  private int AsignarFiltro()
        {
            int filtrado = 0;
            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == true) filtrado = 111;
            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == true) filtrado = 101;
            if (CheckBoxSinVer.Checked == true && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == false) filtrado = 100;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == true) filtrado = 011;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == true && CheckBoxCerrado.Checked == false) filtrado = 010;
            if (CheckBoxSinVer.Checked == false && CheckBoxPendiente.Checked == false && CheckBoxCerrado.Checked == true) filtrado = 001;
            return filtro;
        }*/


        /* protected void DropDownListClientes_SelectedIndexChanged(object sender, EventArgs e)
         {      
             CargarDropDownPedidos(Convert.ToInt32(DropDownListClientes.SelectedValue));
             CargarListaSolicitudes(Convert.ToInt32(DropDownListClientes.SelectedValue));
         }*/

        protected void DropDownListPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListaTareas(Convert.ToInt32(DropDownListPedidos.SelectedValue));
        }

        protected void OcultarBusqueda()
        {
            lbFecha.Style.Add("display", "none");
            CheckBoxAll.Style.Add("display", "none");
            lbEst.Style.Add("display", "none");
            lbBusq.Style.Add("display", "none");

            DivButtonOcultarTareas.Style.Remove("display");
            DivGrillaTareas.Style.Remove("display");
            lbPedido.Style.Remove("display");
            DivGrillaSolicitud.Style.Remove("display");
            DivButton.Style.Remove("display");
      
            DropDownListClientes.Enabled = false;

            ButtonFiltrar.Text = "NUEVA BUSQUEDA";

        }

        protected void MostrarBusqueda()
        {
            lbFecha.Style.Remove("display");
            CheckBoxAll.Style.Remove("display");
            lbEst.Style.Remove("display");
            lbBusq.Style.Remove("display");

            DivButtonOcultarTareas.Style.Add("display", "none");
            DivGrillaTareas.Style.Add("display", "none");
            lbPedido.Style.Add("display", "none");
            DivGrillaSolicitud.Style.Add("display", "none");
            DivButton.Style.Add("display", "none");

            DropDownListClientes.Enabled = true;

            ButtonFiltrar.Text = "FILTRAR PEDIDOS";
        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {

            if (ButtonFiltrar.Text == "FILTRAR PEDIDOS")
            {

                OcultarBusqueda();


              int ClienteSeleccionado = int.Parse(DropDownListClientes.SelectedValue);

              if (ClienteSeleccionado != 0) CargarDropDownPedidos(ClienteSeleccionado);             

              CargarListaSolicitudes(); //Convert.ToInt32(DropDownListClientes.SelectedValue));

            }
            else
            {
                MostrarBusqueda();

                GridViewClientePedidos.DataSource = null;
                GridViewClientePedidos.DataBind();

                GridViewSolicitudTareas.DataSource = null;
                GridViewSolicitudTareas.DataBind();

            }

        }

        protected void ButtonMostrarGrillaTareas_Click(object sender, EventArgs e)
        {
            if (GridViewSolicitudTareas.Visible == true)
            {    
                GridViewSolicitudTareas.Visible = false;
                this.ButtonVisibleGrillaTareas.Text = "Mostrar Grilla Tareas";
            }
            else
            {
                GridViewSolicitudTareas.Visible = true;
                this.ButtonVisibleGrillaTareas.Text = "Ocultar Grilla Tareas";
            }
        }
    
        protected void ButtonGrillaSolicitudes_Click(object sender, EventArgs e)
        {
            if (GridViewClientePedidos.Visible == true)
                {
                GridViewClientePedidos.Visible = false;
                this.ButtonVisibleGrillaSolicitudes.Text = "Mostrar Grilla Solicitudes";
                }
            else
                {
                GridViewClientePedidos.Visible = true;
                this.ButtonVisibleGrillaSolicitudes.Text = "Ocultar Grilla Solicitudes";
            }
        }
    }
}