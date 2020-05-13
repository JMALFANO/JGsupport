<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaSolicitud.aspx.cs" Inherits="WEB.AltaSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Alta de nueva solicitud
        </div>
        <div class="panel-body">


            <div style="margin-bottom: 10px">
            <asp:Label ID="LabelFechaHoy" runat="server" Text="Fecha:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelFecha" runat="server"></asp:Label>
            </div>

            <div style="margin-bottom: 10px" >
            <asp:Label ID="LabelCliente" runat="server" Text="Cliente:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListCliente" runat="server" AutoPostBack="True" DataTextField="Nombre" DataValueField="PersonalId">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListCliente" ErrorMessage="Seleccione un cliente"></asp:RequiredFieldValidator>
            </div>
            
            <div style="margin-bottom: 10px">
            <asp:Label ID="LabelPrioridad" runat="server" Text="Prioridad"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListPrioridad" runat="server">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrioridad" runat="server" ControlToValidate="DropDownListPrioridad" ErrorMessage="Seleccione una opción"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-bottom: 10px">
            <asp:Label ID="LabelTecnico" runat="server" Text="Tecnico asignado: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListTecnico" runat="server" AutoPostBack="True" DataTextField="Nombre" DataValueField="PersonalId">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTecnico" runat="server" ControlToValidate="DropDownListTecnico" ErrorMessage="Seleccione un tecnico"></asp:RequiredFieldValidator>
            </div>       
    
            <div style="margin-bottom: 10px">    
            <asp:Label ID="LabelComplejidad" runat="server" Text="Complejidad"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListComplejidad" runat="server">
            </asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorComplejidad" runat="server" ControlToValidate="DropDownListComplejidad" ErrorMessage="Seleccione una opción"></asp:RequiredFieldValidator>
            </div>
                 
            <div style="margin-bottom: 10px">   
            <asp:Label ID="LabelEstado" runat="server" Text="Estado:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListEstado" runat="server">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEstado" runat="server" ControlToValidate="DropDownListEstado" ErrorMessage="Seleccione una opción"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-bottom: 10px">
            <asp:Label ID="LabelProblema" runat="server" Text="PROBLEMA:"></asp:Label>
            </div>

            <div style="margin-bottom: 10px">                      
            <asp:TextBox ID="TextBoxProblema" runat="server" Height="92px" Width="336px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProblema" runat="server" ControlToValidate="TextBoxProblema" ErrorMessage="Ingrese una descripcion"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-bottom: 10px">
            <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" OnClick="btnGuardar_Click" Text="Asentar Solictud" />

            &nbsp;<asp:HyperLink ID="btnVerTareas" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Ver Tareas</asp:HyperLink>
          
            &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
