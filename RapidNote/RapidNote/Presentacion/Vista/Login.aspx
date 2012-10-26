<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RapidNote.Presentacion.Vista.Login"
    MasterPageFile="~/SiteMaster/SiteLogin.Master" %>

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
        <br />
        <br />
        <br />
        <fieldset>
            <legend>Bienvenido a RapidNote</legend>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="correoUsuario" runat="server" Text="Correo de usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="correo" runat="server"></asp:TextBox><span class="style1"> <strong>
                            *</strong></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="claveUsuario" runat="server" Text="clave"></asp:Label>
                        <asp:Label ID="recuperarContrasena" runat="server" Style="text-align: right; color: Blue;
                            font-weight: 500;"><a href="RecuperarContrasena.aspx">[recuperar]</a></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="clave" TextMode="Password" runat="server"></asp:TextBox>
                        <span class="style1"><strong>*</strong></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <div id="error" runat="server">
                            <asp:Label ID="mensajeError" runat="server" Text="Usuario o Contraseña inválida"
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
                    <td colspan="2">
                        <asp:Label ID="excepcion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="iniciarsesion" runat="server" Text="Iniciar Sesión" OnClick="iniciarsesion_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
    </div>
</asp:Content>
