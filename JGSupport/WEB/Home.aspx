<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            &nbsp;CRM&nbsp;
        </div>
        <div class="panel-body">
            <div id="lbBusq" runat="server">
                  <asp:Label ID="LabelBuscador" runat="server" Text="BUSCADOR:"></asp:Label>
            &nbsp;</div>
                    
              <div id="lbEst" runat="server">
                      <asp:Label ID="LabelEstado" runat="server" Text="Estado del pedido:"></asp:Label>
              </div>

            <div id ="CheckBoxAll" runat="server">  
                <asp:CheckBox ID="CheckBoxSinVer" runat="server" Text="Sin Ver" />
                <asp:CheckBox ID="CheckBoxPendiente" runat="server" Text="Pendiente" />
                <asp:CheckBox ID="CheckBoxCerrado" runat="server" Text=" Cerrado" />
            </div>
                   


            <div id ="lbFecha" runat="server">
                      <asp:Label ID="LabelFecha" runat="server" Text="Filtrar por fecha:"></asp:Label>

                          &nbsp;<br />  

                      <asp:Label ID="LabelDesde" runat="server" Text="Desde:"></asp:Label>

                      <asp:TextBox ID="TextBoxDesde" runat="server">2018/01/01</asp:TextBox>
             
                      <asp:Label ID="LabelHasta" runat="server" Text="Hasta:"></asp:Label>

                      <asp:TextBox ID="TextBoxHasta" runat="server">2018/12/31</asp:TextBox>
            &nbsp;Formato: YYYY/MM/DD</div>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesde" runat="server" ControlToValidate="TextBoxDesde" ErrorMessage="Ingrese una fecha"></asp:RequiredFieldValidator>
          
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorFechaDesde" runat="server" ControlToValidate="TextBoxDesde" ErrorMessage="Formato incorrecto" ValidationExpression="^\d{4}[\-\/\s]?((((0[13578])|(1[02]))[\-\/\s]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\-\/\s]?(([0-2][0-9])|(30)))|(02[\-\/\s]?[0-2][0-9]))$"></asp:RegularExpressionValidator>
          
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorHasta" runat="server" ControlToValidate="TextBoxHasta" ErrorMessage="Ingrese una fecha "></asp:RequiredFieldValidator>
                  
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorFechaHasta" runat="server" ControlToValidate="TextBoxHasta" ErrorMessage="Formato incorrecto" ValidationExpression="^\d{4}[\-\/\s]?((((0[13578])|(1[02]))[\-\/\s]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\-\/\s]?(([0-2][0-9])|(30)))|(02[\-\/\s]?[0-2][0-9]))$"></asp:RegularExpressionValidator>
          
              <br />  

                      <asp:Label ID="LabelCliente" runat="server" Text="CLIENTE:"></asp:Label>

            <asp:DropDownList ID="DropDownListClientes" runat="server" AutoPostBack="True" EnableTheming="True">
            </asp:DropDownList>

         
                      <asp:Button ID="ButtonFiltrar"  class="btn btn-primary" runat="server" OnClick="ButtonFiltrar_Click" Text="FILTRAR PEDIDOS" />
                      <br />
                      <br />

                          <div id="DivButton" runat="server">
                      <asp:Button ID="ButtonVisibleGrillaSolicitudes"  class="btn btn-primary" runat="server" OnClick="ButtonGrillaSolicitudes_Click" Text="Ocultar Grilla Solicitudes" Visible="False" />
                      </div>
                          <div id="DivGrillaSolicitud" runat="server">                  

                      <asp:GridView ID="GridViewClientePedidos" runat="server" AutoGenerateColumns="False">
                           <Columns>
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/AltaSolicitud.aspx?accion=modificar&id=" + Eval("SolicitudId")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:BoundField DataField="SolicitudId" HeaderText="SolicitudId" SortExpression="SolicitudId" />
                         <asp:BoundField DataField="FechaInicio" HeaderText="FechaInicio" SortExpression="FechaInicio" />
                         <asp:BoundField DataField="FechaFin" HeaderText="FechaFin" SortExpression="FechaFin" />                
                         <asp:BoundField DataField="nombreTecnico" HeaderText="nombreTecnico" SortExpression="nombreTecnico" />
                         <asp:BoundField DataField="clienteNombre" HeaderText="clienteNombre" SortExpression="clienteNombre" />
                         <asp:BoundField DataField="DescripcionTarea" HeaderText="DescripcionTarea" SortExpression="DescripcionTarea" />
                         <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                         <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" SortExpression="Prioridad" />
                         <asp:BoundField DataField="Complejidad" HeaderText="Complejidad" SortExpression="Complejidad" />
                              </Columns>
                      </asp:GridView>
                              </div>

                      <br />

                    <div id="lbPedido" runat="server">
                      <asp:Label ID="LabelPedido" runat="server" Text="Tareas del pedido:" Visible="False"></asp:Label>
                  

            <asp:DropDownList ID="DropDownListPedidos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPedidos_SelectedIndexChanged" Visible="False">
            </asp:DropDownList>
           </div>
           
                      <br />
            <div id="DivButtonOcultarTareas" runat="server">
                      <asp:Button ID="ButtonVisibleGrillaTareas"  class="btn btn-primary" runat="server" OnClick="ButtonMostrarGrillaTareas_Click" Text="Ocultar Grilla Tareas" Visible="False" />
                 </div>             
               <div id="DivGrillaTareas" runat="server">
                      <asp:GridView ID="GridViewSolicitudTareas" runat="server" AutoGenerateColumns="False">
                          <Columns>
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/AltaParte.aspx?accion=modificar&tarea=" + Eval("TareaId")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>   
                         <asp:BoundField DataField="TareaId" HeaderText="TareaId" SortExpression="TareaId" />
                                 <asp:BoundField DataField="SolicitudId" HeaderText="SolicitudId" SortExpression="SolicitudId" />
                         <asp:BoundField DataField="ModoSolucion" HeaderText="ModoSolucion" SortExpression="ModoSolucion" />
                         <asp:BoundField DataField="Reporte" HeaderText="Reporte" SortExpression="Reporte" />                
                         <asp:BoundField DataField="nombreTecnico" HeaderText="nombreTecnico" SortExpression="nombreTecnico" />
                         <asp:BoundField DataField="nombreCliente" HeaderText="nombreCliente" SortExpression="nombreCliente" />
                         <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                         <asp:BoundField DataField="HoraInicio" HeaderText="HoraInicio" SortExpression="HoraInicio" />
                         <asp:BoundField DataField="HoraFin" HeaderText="HoraFin" SortExpression="HoraFin" />              
                              </Columns>
                      </asp:GridView>
                </div>

           
              
                      <br />

             <asp:HyperLink ID="btnNuevoUsuario" class="btn btn-primary" runat="server" NavigateUrl="~/ListarUsuarios.aspx">NUEVO USUARIO</asp:HyperLink>
          
             <asp:HyperLink ID="btnNuevaSolicitud" class="btn btn-primary" runat="server" NavigateUrl="~/AltaSolicitud.aspx?accion=nuevo">NUEVA SOLICITUD</asp:HyperLink>
           
             <asp:HyperLink ID="btnNuevoParte" class="btn btn-primary" runat="server" NavigateUrl="~/AltaParte.aspx?accion=nuevo">NUEVO PARTE</asp:HyperLink>
    
             <asp:HyperLink ID="btnImprimir" class="btn btn-primary" runat="server" NavigateUrl="~/Imprimir.aspx">IMPRIMIR</asp:HyperLink>

        </div>
    </div>
</asp:Content>
