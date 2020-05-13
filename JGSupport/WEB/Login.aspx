<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            LOGIN
        </div>
        <div class="panel-body">
                      Mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMail" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="Ingrese un mail"></asp:RequiredFieldValidator>
                      <br />
            <br />
            Contraseña:&nbsp;
            <asp:TextBox ID="TextBoxContraseña" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContraseña" runat="server" ControlToValidate="TextBoxContraseña" ErrorMessage="Ingrese una contraseña"></asp:RequiredFieldValidator>
                      <br />
                      <br />
                      <br />
                      <asp:Label ID="LabelRespuesta" runat="server"></asp:Label>
            <br />

           
                      <br />
                      <asp:Button ID="ButtonIngresar" class="btn btn-primary" runat="server" OnClick="ButtonIngresar_Click" Text="INGRESAR" />

        </div>
    </div>
</asp:Content>
