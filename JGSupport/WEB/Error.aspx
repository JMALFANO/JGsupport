<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WEB.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger">

        <div class="panel-heading">Se ha producido un error</div>

        <div class="panel-body">
            <asp:label id="errorLabel" runat="server" text="Error"></asp:label>
        </div>

    </div>
</asp:Content>

