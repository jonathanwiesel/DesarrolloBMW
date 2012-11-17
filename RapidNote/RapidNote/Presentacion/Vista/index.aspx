<%@ Page Language="C#" MasterPageFile="~/SiteMaster/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sistema_Totem.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BuscadorMain" runat="server"> 
    <asp:TextBox ID="TextBoxBuscadorSiteM" runat="server" Width="250px"></asp:TextBox>
    <asp:Button ID="ButtonBuscadorSiteM" runat="server" Text="Buscar" OnClick="ClickBuscarNota"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <p>
        <!--To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.-->
        
    </p>
</asp:Content>