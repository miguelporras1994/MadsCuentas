<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitudCertIngresos.aspx.cs" Inherits="SolicitudCertIngresos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 72px;
        }
        .auto-style2 {
            width: 246px;
        }
        .auto-style3 {
            width: 246px;
            text-align: right;
        }
    </style>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="width: 39%;">
            <tr>
                <td class="auto-style2" colspan="3"><img src="images/ingresosup.jpg"</td>
                
            </tr>
            <tr>
                <td class="auto-style2" colspan="3"><div class="container">
  <div class="jumbotron">
    <h2>Certificado de Ingresos y Retenciones</h2>
    <p>Por medio de este servicio ud podrá solicitar su certificado de ingresos y retenciones. Una vez atendida la solicitud el certificado será enviado al correo electronico proporcionado en este formulario.</p>
  </div>
  
</div></tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Cedula:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxCedula" Width="277px" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV19" runat="server" ControlToValidate="TextBoxCedula" Display="None" ErrorMessage="Por favor ingrese el numero de documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="RFV19_ValidatorCalloutExtender" runat="server" TargetControlID="RFV19">
                            </ajaxToolkit:ValidatorCalloutExtender>
                     <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxNumeroDocumento_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBoxCedula">
                            </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Correo:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxCorreo" Width="277px" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV18" runat="server" ControlToValidate="TextBoxCorreo" Display="None" ErrorMessage="Por favor ingrese el correo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="RFV18_ValidatorCalloutExtender" runat="server" TargetControlID="RFV18">
                            </ajaxToolkit:ValidatorCalloutExtender>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Año del certificado:</td>
                <td class="auto-style1">
                    <asp:DropDownList CssClass="form-control" ID="DropDownListAno" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                       
                    </asp:DropDownList>

                            <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="DropDownListAno" Display="None" ErrorMessage="Por favor seleccione el Año" MaximumValue="99999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                            <ajaxToolkit:validatorcalloutextender ID="Validatorcalloutextender1" 
                runat="server" TargetControlID="RangeValidator18">            </ajaxToolkit:validatorcalloutextender>   
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" CssClass="btn-success btn-lg" OnClick="Button1_Click" Text="Enviar Solicitud" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
