<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs"
 Inherits="RapidNote.Presentacion.Vista.Registrausuario" MasterPageFile ="~/SiteMaster/SiteRegistrar.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #error
        {
            text-align: center;
        }
        #faltandatos
        {
            text-align: center;
        }
        .style1
        {
            color: #CC0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenido">
        <br />
        
        <br />
        <fieldset>
            <legend>Agregar Usuario</legend>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lnombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nombre" runat="server" Width="208px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="rfvEmail" runat="server" Display="Dynamic" ControlToValidate="nombre" ErrorMessage="Falta Ingreso de Email" class="style1">*</asp:requiredfieldvalidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="**" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'])+$"
           ControlToValidate="nombre"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lapellido" runat="server" Text="Apellido"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="apellido" runat="server" Width="207px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="apellido" ErrorMessage="Falta Ingreso de Email" class="style1" >*</asp:requiredfieldvalidator>
                        <asp:RegularExpressionValidator ID="regExp" runat="server" ErrorMessage="**" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'])+$"
           ControlToValidate="apellido"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lcorreo" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="correo" runat="server" Width="207px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ControlToValidate="correo" ErrorMessage="Falta Ingreso de Email" class="style1" >*</asp:requiredfieldvalidator>
                        <asp:regularexpressionvalidator id="revEmail" runat="server" ControlToValidate="correo" ErrorMessage="Formato de correo no valido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" class="style1">**</asp:regularexpressionvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lpassword" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="password" TextMode="Password" runat="server" Width="208px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Display="Dynamic" ControlToValidate="password" ErrorMessage="Falta Ingreso de Email" class="style1" >*</asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lconfirpassword" runat="server" Text="Confirmar contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="confpassword" TextMode="Password" runat="server" Width="208px"></asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" Display="Dynamic" ControlToValidate="confpassword" ErrorMessage="Falta Ingreso de Email" class="style1" >*</asp:requiredfieldvalidator>
                        <asp:comparevalidator id="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="confpassword" ErrorMessage="Password No coincide" ControlToCompare="password" class="style1">***</asp:comparevalidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <div id="error" runat="server">
                            <asp:Label ID="mensajeError" runat="server" Text="Revisar Campos"
                                Visible="false" Style="text-align: center; color: #CC0000; font-weight: 700;
                                font-style: italic"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="registrar" runat="server" Text="Registrar" OnClick="Registrar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
    </div>
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="*: Campo obligatorio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="**: Formato invalido"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="***: No coinciden las claves"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>