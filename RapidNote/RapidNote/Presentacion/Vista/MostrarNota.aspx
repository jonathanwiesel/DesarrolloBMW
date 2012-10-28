<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster/Site.Master" AutoEventWireup="true" CodeBehind="MostrarNota.aspx.cs" Inherits="RapidNote.Presentacion.Vista.MostrarNota" %>
<%@ Register Assembly="RapidNote" Namespace="RapidNote.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contenido">
        <br />
        <br />
        <br />
        <br />
        <br />
        <fieldset>
            <legend>Mostrar Nota</legend>
            <table align="center">                
                <cc1:semanticupdatepanel ID="SemanticUpdatePanel1" runat="server" 
                    RenderedElement="TBODY">
                <ContentTemplate>
                <tr>
                    <td>
                        <asp:Label ID="nombreNota" runat="server" Text="Titulo de la Nota"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="435px" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>                    
                <tr>
                    <td>
                        <asp:Label ID="content" runat="server" Text="Contenido"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="TextBoxContenido" runat="server" rows="20" TextMode="multiline" Width="430px" Height="240px" 
                        ReadOnly="true" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre de la libreta"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="TextBoxLibreta" runat="server" ReadOnly="true"
                            Width="430px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Fecha de creacion"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="TextBoxFechaC" runat="server" ReadOnly="true"
                            Width="430px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Fecha de modificacion"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="TextBoxFechaM" runat="server" ReadOnly="true"
                            Width="430px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Etiquetas"></asp:Label>
                    </td>
                    <td>                        
                        <asp:ListBox ID="ListBoxEtiquetas" Height="80px" runat="server" Width="430px" ReadOnly="true"></asp:ListBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Archivos"></asp:Label>
                    </td>
                    <td>                        
                        <asp:ListBox ID="ListBoxArchivos" Height="80px" runat="server" Width="430px" ReadOnly="true"></asp:ListBox>
                    </td>
                </tr>
                </ContentTemplate>
                </cc1:semanticupdatepanel>
                </table>                
        </fieldset>
        <br />
</asp:Content>
