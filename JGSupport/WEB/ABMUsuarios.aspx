<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="WEB.ABMUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            ABM Usuarios
        </div>
        <div class="panel-body">
          Nombre:&nbsp;
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="Ingrese un nombre"></asp:RequiredFieldValidator>
            <br />
            Apellido:&nbsp;
            <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ControlToValidate="TextBoxApellido" ErrorMessage="Ingrese un Apellido"></asp:RequiredFieldValidator>
            <br />
            Mail:<asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMail" runat="server" ControlToValidate="TextBoxMail" ErrorMessage="Ingrese un mail"></asp:RequiredFieldValidator>
            <br />
            Telefono:<asp:TextBox ID="TextBoxTelefono" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="Ingrese un telefono"></asp:RequiredFieldValidator>
            <br />
            Contraseña: <asp:TextBox ID="TextBoxContraseña" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContraseña" runat="server" ControlToValidate="TextBoxContraseña" ErrorMessage="Ingrese una contraseña"></asp:RequiredFieldValidator>
            <br />
            <div id="divActivoPrivileigio" runat="server">
            Activo:&nbsp;&nbsp; &nbsp;&nbsp;<asp:ListBox ID="ListBoxAcitvo" runat="server" Height="38px">
           <asp:ListItem Text="Activo" Value="True" Selected="True" />
           <asp:ListItem Text="Inactivo" Value="False" />
            </asp:ListBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorActivo" runat="server" ControlToValidate="ListBoxAcitvo" ErrorMessage="Seleccione un valor"></asp:RequiredFieldValidator>
            <br />
            Privilegio:&nbsp;
            <asp:DropDownList ID="DropDownListCategorias" runat="server" DataTextField="CategoriaDesc" DataValueField="CategoriaId">
            </asp:DropDownList>
              
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEquipo" runat="server" ControlToValidate="DropDownListCategorias" ErrorMessage="Seleccione un privilegio"></asp:RequiredFieldValidator>
              </div>
            <br />
            <br />
            <asp:Button ID="btnGuardarUsuario" class="btn btn-primary"  runat="server" OnClick="btnGuardarUsuario_Click" Text="Guardar Usuario" />
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>
