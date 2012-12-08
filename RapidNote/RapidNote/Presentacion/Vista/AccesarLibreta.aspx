<%@ Page Language="C#"  MasterPageFile="~/SiteMaster/Site.Master" AutoEventWireup="true" CodeBehind="AccesarLibreta.aspx.cs" Inherits="RapidNote.Presentacion.Vista.AccesarLibreta" %>
<%@ Register Assembly="RapidNote" Namespace="RapidNote.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Accesar Libreta
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
            <legend>Accesar Libreta</legend>
                <table align="center">                
                    <cc1:semanticupdatepanel ID="SemanticUpdatePanel1" runat="server" 
                        RenderedElement="TBODY">                        
                    <ContentTemplate>
                        <tr>
                            <td>
                                <asp:GridView ID="GridViewLibreta" runat="server" CellPadding="4" ForeColor="#333333"
                                    AutoGenerateColumns="False" GridLines="None" Width="450px" HorizontalAlign="Center"
                                    Style="text-align: center" AllowPaging="True" CssClass="leftCol" 
                                     OnRowDataBound="GridViewRowEventHandler" OnPageIndexChanging="GridViewNotas_PageIndexChanging" OnSorting="GridViewNotas_Sorting">
                                    <HeaderStyle BackColor="#AA2828" ForeColor="White" />
                                    <FooterStyle BackColor="#AA2828" ForeColor="White" />
                                    <PagerStyle BackColor="#AA2828" ForeColor="White" HorizontalAlign="Center"/>
                                    <Columns> 
                                        <asp:BoundField DataField="idLibreta" HeaderText="id"/>     
                                        <asp:BoundField DataField="nombreLibreta" HeaderText="titulo"/> 
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="button1" runat="server" OnClick="Details_Click" Text="Modificar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>      
                                    </Columns>            
                                </asp:GridView>
                            </td>                            
                        </tr>
                    </ContentTemplate>
                    </cc1:semanticupdatepanel>
                    <tr>
                        <td>
                         <asp:Label  ID="mensajeError" runat="server" Text="Mensaje error"  Visible="false" 
                     style="text-align: center; color: #CC0000; font-weight: 700; font-style: italic"></asp:Label>
                        </td>
                    </tr>
                </table>                
        </fieldset>
        <br />

</asp:Content>
