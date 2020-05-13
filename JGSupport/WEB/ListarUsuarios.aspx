<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="WEB.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Listado de usuarios del sistema
        </div>

         Seleccionar Categoria:

         <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSourceCategorias" DataTextField="privilegio_Desc" DataValueField="id_privilegio">
         </asp:DropDownList>


         <asp:ObjectDataSource ID="ObjectDataSourceCategorias" runat="server" SelectMethod="Listar" TypeName="BL.blCategoria"></asp:ObjectDataSource>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
  
                 <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceUsuarios">
                     <Columns>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/ABMUsuarios.aspx?accion=modificar&id=" + Eval("PersonalId")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <asp:BoundField DataField="PersonalId" HeaderText="PersonalId" SortExpression="PersonalId" />
                         <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                         <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                         <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
                         <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                         <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" SortExpression="Contraseña" />
                         <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
                     </Columns>
                 </asp:GridView>
                 <br />
                   <asp:HyperLink ID="btnNuevoUsuario" class="btn btn-primary" runat="server" NavigateUrl="~/ABMUsuarios.aspx?accion=nuevo">NUEVO USUARIO</asp:HyperLink>
                   &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">VOLVER</asp:HyperLink>
                   </ContentTemplate>
         </asp:UpdatePanel>


             <asp:ObjectDataSource ID="ObjectDataSourceUsuarios" runat="server" SelectMethod="ListarPorCategoria" TypeName="BL.blPersonal">
                     <SelectParameters>
                         <asp:ControlParameter ControlID="ddlCategorias" Name="id_privilegio" PropertyName="SelectedValue" Type="Int32" />
                     </SelectParameters>

                 </asp:ObjectDataSource>
      
    </div>
    </asp:Content>
