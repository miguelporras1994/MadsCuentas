<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GenerarFacturaElectronica.aspx.cs" Inherits="GenerarFacturaElectronica" %>

<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="estilo.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <script type="text/javascript">
 
  var isSubmitted = false;
 
  function preventMultipleSubmissions() {
 
  if (!isSubmitted) {
 
     $('#<%=ButtonBuscar.ClientID %>').val('Por favor espere..');
 
    isSubmitted = true;
 
    return true;
 
  }
 
  else {
 
    return false;
 
  }
 
}
 
</script>

    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td><uc1:WUC_ResumenCuenta ID="WUC_ResumenCuenta1" runat="server" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    
                <asp:Label ID="LabelConsecutivo" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 17px"></td>
            <td style="height: 17px">    </td>
            <td style="height: 17px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width:900px">    <strong>Objeto:</strong><asp:Literal  ID="LiteralObjeto" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    
                <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">[HyperLink1]</asp:HyperLink>
                            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    <asp:Button ID="ButtonBuscar"  CssClass="btn-success btn-lg" runat="server"  Text="Generar Factura" OnClick="ButtonBuscar_Click" />
                            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>


