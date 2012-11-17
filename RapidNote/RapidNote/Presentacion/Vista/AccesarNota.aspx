<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster/Site.Master" AutoEventWireup="true" CodeBehind="AccesarNota.aspx.cs" Inherits="RapidNote.Presentacion.Vista.AccesarNota" %>
<%@ Register Assembly="RapidNote" Namespace="RapidNote.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Accesar Nota
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BuscadorMain" runat="server">
    <asp:TextBox ID="TextBoxBuscadorSiteM" runat="server" Width="250px"></asp:TextBox>
    <asp:Button ID="ButtonBuscadorSiteM" runat="server" Text="Buscar" OnClick="ClickBuscarNota"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="contenido">
        <br />
        <br />
        <br />
        <br />
        <br />
        <fieldset>
            <legend>Accesar Nota</legend>
                <table align="center">                
                    <cc1:semanticupdatepanel ID="SemanticUpdatePanel1" runat="server" 
                        RenderedElement="TBODY">                        
                    <ContentTemplate>
                        <tr>
                            <td>
                                <asp:GridView ID="GridViewNotas" runat="server" CellPadding="4" ForeColor="#333333"
                                    AutoGenerateColumns="False" GridLines="None" Width="450px" HorizontalAlign="Center"
                                    Style="text-align: center" AllowPaging="True" CssClass="leftCol" 
                                     OnRowDataBound="GridViewRowEventHandler">
                                    <HeaderStyle BackColor="#AA2828" ForeColor="White" />
                                    <FooterStyle BackColor="#AA2828" ForeColor="White" />
                                    <PagerStyle BackColor="#AA2828" ForeColor="White" HorizontalAlign="Center"/>
                                    <Columns> 
                                        <asp:BoundField DataField="idnota" HeaderText="id"/>     
                                        <asp:BoundField DataField="titulo" HeaderText="titulo"/>      
                                        <asp:BoundField DataField="fechacreacion" HeaderText="fecha de creacion"/>     
                                    </Columns>            
                                </asp:GridView>
                            </td>                            
                        </tr>
                    </ContentTemplate>
                    </cc1:semanticupdatepanel>
                </table>                
        </fieldset>
        <br />

</asp:Content>
