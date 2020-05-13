<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaParte.aspx.cs" Inherits="WEB.AltaParte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Alta de nuevo parte
        </div>
        <div class="panel-body">
                      Fecha:
                      <asp:Label ID="LabelFecha" runat="server"></asp:Label>
                      <br />
                      <br />
                      Cliente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:DropDownList ID="DropDownListClientes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListClientes_SelectedIndexChanged">
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorCliente" runat="server" ControlToValidate="DropDownListClientes" ErrorMessage="Seleccionar un cliente"></asp:RequiredFieldValidator>
                      <br />
                      <br />
                      Pedido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:DropDownList ID="DropDownListPedidos" runat="server" AutoPostBack="True">
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorPedido" runat="server" ControlToValidate="DropDownListPedidos" ErrorMessage="Seleccionar un pedido"></asp:RequiredFieldValidator>
                      <br />
                      <br />
                      Tecnico asignado:
                      <asp:DropDownList ID="DropDownListTecnico" runat="server" AutoPostBack="True">
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorTecnico" runat="server" ControlToValidate="DropDownListTecnico" ErrorMessage="Seleccionar un Tecnico"></asp:RequiredFieldValidator>
                      <br />

            <br />
                      Hora Inicio:&nbsp; <asp:TextBox ID="TextBoxHoraInicio" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorHoraInicio" runat="server" ControlToValidate="TextBoxHoraInicio" ErrorMessage="Ingrese una hora"></asp:RequiredFieldValidator>
                      &nbsp;Hora Fin:
            <asp:TextBox ID="TextBoxHoraFin" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorHoraFin" runat="server" ControlToValidate="TextBoxHoraFin" ErrorMessage="Ingrese una hora"></asp:RequiredFieldValidator>
                      &nbsp;<br />
                      <br />
                      Solución:
                      <asp:RadioButton ID="RadioButtonPresencial" runat="server" Text="Presencial" OnCheckedChanged="RadioButtonPresencial_CheckedChanged" AutoPostBack="True" />
&nbsp;
                      <asp:RadioButton ID="RadioButtonRemoto" runat="server" Text="Remota " OnCheckedChanged="RadioButtonRemoto_CheckedChanged" AutoPostBack="True" />
                      <br />
                      <br />
                      Reporte:<br />
                      <asp:TextBox ID="TextBoxReporte" runat="server" Height="82px" Width="336px" TextMode="MultiLine"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorReporte" runat="server" ErrorMessage="Ingrese un mensaje" ControlToValidate="TextBoxReporte"></asp:RequiredFieldValidator>
                      <br />
                      <br />
                      Solicitud Finalizada:
                      <asp:CheckBox ID="CheckBoxFinalizado" runat="server" />
                      <br />
            <br />

           
        &nbsp;<asp:Button ID="ButtonGuardar" class="btn btn-primary" runat="server" OnClick="ButtonGuardar_Click" Text="Asentar Parte" />
&nbsp;<asp:HyperLink ID="btnIngresar0" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Imprimir Parte</asp:HyperLink>

        &nbsp;

           
             <asp:HyperLink ID="btnIngresar1" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>

        </div>
    </div>
</asp:Content>
