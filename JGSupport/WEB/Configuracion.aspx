<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="WEB.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            CONFIGURACION</div>
        <div class="panel-body">

                <ul>
                <li>
                    <asp:HyperLink ID="HyperLinkMiCuenta" runat="server" NavigateUrl="~/ABMUsuarios.aspx?accion=micuenta">Modificar datos de mi cuenta</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLinkAyuda" runat="server" NavigateUrl="~/Ayuda.aspx">Ponerse en contacto con un administrador</asp:HyperLink>
                </li>
            </ul>

         <asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">VOLVER</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>
