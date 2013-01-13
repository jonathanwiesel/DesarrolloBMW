<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster/Site.Master" AutoEventWireup="true" CodeBehind="ImportarConfiguracion.aspx.cs" Inherits="RapidNote.Presentacion.Vista.ImportarConfiguracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Importar Configuracion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BuscadorMain" runat="server">
    <asp:TextBox ID="TextBoxBuscadorSiteM" runat="server" Width="250px"></asp:TextBox>
    <asp:Button ID="ButtonBuscadorSiteM" runat="server" Text="Buscar" OnClick="ClickBuscarNota"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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

    <div id="contenido">
        <br />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
        <fieldset>
            <legend>Importar Configuracion</legend>
            <table align="center">                
                <tr>
                    <td></td>
                    <td colspan="2" align="center">
                    <asp:Label  ID="mensajeError" runat="server" Text="Mensaje error"  Visible="false" 
                     style="text-align: center; color: #CC0000; font-weight: 700; font-style: italic"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Archivo Adjunto"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadArchivo" class="multi" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Guardar" 
                                onclick="Button1_Click" />
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
    </table>
</asp:Content>
