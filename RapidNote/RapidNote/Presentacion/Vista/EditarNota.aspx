<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarNota.aspx.cs" Inherits="RapidNote.Presentacion.Vista.EditarNota" MasterPageFile="~/SiteMaster/Site.Master" %>
<%@ Register Assembly="RapidNote" Namespace="RapidNote.Controles" TagPrefix="cc1" %>

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
            <legend>Editar Nota</legend>
            <table align="center">                
                <cc1:semanticupdatepanel ID="SemanticUpdatePanel1" runat="server" 
                    RenderedElement="TBODY">
                <ContentTemplate>
                <script src="../../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
                <tr>
                    <td>
                        <asp:Label ID="nombreNota" runat="server" Text="Titulo de la Nota"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="TextBoxTitulo" runat="server" 
                            Width="430px"></asp:TextBox>
                            <asp:requiredfieldvalidator id="rfvEmail" runat="server" 
                            Display="Dynamic" ControlToValidate="TextBoxTitulo" ErrorMessage="falta titulo">*</asp:requiredfieldvalidator>
                    </td>
                </tr>                    
                <tr>
                    <td>
                        <asp:Label ID="content" runat="server" Text="Contenido"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="TextBoxContenido" runat="server" rows="20" TextMode="multiline" Width="430px" Height="240px" >
                        </asp:TextBox>
                        <asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" 
                            Display="Dynamic" ControlToValidate="TextBoxContenido" ErrorMessage="falta contenido">*</asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="nombreEtiqueta" runat="server" Text="Etiquetas"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEtiqueta" runat="server" Width="430px"></asp:TextBox>
                        <asp:regularexpressionvalidator id="revEtiqueta" runat="server" ControlToValidate="TextBoxEtiqueta" ErrorMessage="Formato de etiqueta no valido" ValidationExpression="^[A-Za-z0-9 _]*$" class="style1">**</asp:regularexpressionvalidator>
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="Agregar Etiqueta" 
                                onclick="Button4_Click" />
                    </td>
                </tr>
                <tr>
                     <td>   
                    </td>
                    <td>
                        <asp:ListBox ID="ListBoxEtiquetas" Height="80px" runat="server" Width="430px" ReadOnly="true"></asp:ListBox>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Quitar Etiqueta" 
                                onclick="Button3_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre de la libreta"></asp:Label>
                    </td>
                    <td>                        
                        <asp:DropDownList ID="DropDownListLibretas" runat="server" Width="430px" Enabled="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Archivos Adjuntos"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadArchivo" class="multi" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:ListBox ID="ListBoxArchivos" Height="80px" runat="server" Width="430px" ReadOnly="true"></asp:ListBox>
                    </td>
                </tr>  
                 
                <tr>
                    <td>
                        <asp:Label ID="LabelResultado" runat="server" Text="" Visible="false" 
                     style="text-align: center; color: #CC0000; font-weight: 700; font-style: italic"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Guardar" 
                                onclick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Eliminar" 
                                onclick="Button2_Click" />
                    </td>
                </tr>        
                </ContentTemplate>
                </cc1:semanticupdatepanel>
                </table>  
                <table align="center">
                    <tr>
                        <td>
                            
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