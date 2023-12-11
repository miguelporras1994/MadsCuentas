<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptDevoluciones.aspx.cs" Inherits="RptDevoluciones" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <link href="/estilo.css" rel="stylesheet" type="text/css" />
    <div id="contenido">
        <div style ="height:1400px; width:1080px; overflow:auto;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="494px" 
            ProcessingMode="Remote" Width="1000px">
        </rsweb:ReportViewer>
        </div>
    </div>   
</asp:Content>
