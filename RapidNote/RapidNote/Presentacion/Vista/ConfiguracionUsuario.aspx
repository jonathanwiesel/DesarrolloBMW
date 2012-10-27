<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfiguracionUsuario.aspx.cs" Inherits="RapidNote.Presentacion.Vista.WebForm1" MasterPageFile ="~/SiteMaster/SiteRegistrar.Master"%>


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
            <legend>Configuración de Usuario</legend>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lcorreo" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="correo" runat="server" Width="207px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lnombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nombre" runat="server" Width="208px"></asp:TextBox><span class="style1"> <strong>
                            *</strong></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lapellido" runat="server" Text="Apellido"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="apellido" runat="server" Width="207px"></asp:TextBox>
                        <span class="style1"><strong>*</strong></span>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="lpassword" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="password" TextMode="Password" runat="server" Width="208px"></asp:TextBox>
                        <span class="style1"><strong>*</strong></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lavatar" runat="server" Text="Avatar"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="Avatar" runat="server" Width="217px" />
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
                        <asp:Button ID="registrar" runat="server" Text="Registrar" OnClick="registrar_Click" />
                    </td>
                </tr>
               
            </table>
        </fieldset>
        <br />
    </div>
</asp:Content>
