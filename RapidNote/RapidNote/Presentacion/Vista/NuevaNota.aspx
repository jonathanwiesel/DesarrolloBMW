<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaNota.aspx.cs" Inherits="RapidNote.Presentacion.Vista.NuevaNota" MasterPageFile="~/SiteMaster/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Nota
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contenido">
        <br />
        <br />
        <br />
        <br />
        <br />
        <fieldset>
            <legend>Nota</legend>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="nombreNota" runat="server" Text="Titulo de Nota"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nota_title" runat="server"></asp:TextBox><span class="style1"> <strong>
                            *</strong></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="content" runat="server" Text="Contenido"></asp:Label>
                    </td>
                    <td>
                        <span class="style1"><strong>
                        <textarea id="TextArea1" name="S1" style="height: 239px; width: 443px"></textarea></strong></span>
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Adjuntar archivo"></asp:Label>
                </td>
                    <td>
                        
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>

                </tr>
                </table>
                <table align="center" width="550px">
                <tr>
                    <td align="right">
                         <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="cancelar_Click" align= "right"/>          

                        <asp:Button ID="guardar" runat="server" Text="Guardar" OnClick="guardar_Click" align="right" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
    </div>
</asp:Content>