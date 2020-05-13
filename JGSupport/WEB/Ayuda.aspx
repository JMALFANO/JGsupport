<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="WEB.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Acerca de..</div>
        <div class="panel-body">
<center>
<div><u>JG Support</u></div>
    <br />

    <div> -ALFANO, Juan Martin.</div>
    
<div> -CALLEGARI, Gabriel. </div>
              

    

            <div> ISTEA - Proyecto Final Integrador </div>

                  <br />
       <div> CONTACTO: soporte@JGSupport.com</div>
    </center>
              <br />
              <br />

            <asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">VOLVER</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>