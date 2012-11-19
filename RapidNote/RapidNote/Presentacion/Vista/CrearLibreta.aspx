<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearLibreta.aspx.cs" Inherits="RapidNote.Presentacion.Vista.CrearLibreta" MasterPageFile="~/SiteMaster/Site.Master" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
            <legend>Agregar Libreta</legend>
            <table align="center">
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
                    <td colspan="2">
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="registrar" runat="server" Text="Registrar" 
                            onclick="registrar_Click"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
    </div>
</asp:Content>

