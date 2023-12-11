<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecibidoTesoreria.aspx.cs" Inherits="RecibidoTesoreria" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link href="css/Mensajes.css" rel="stylesheet" />
    <link href="calendario.css" rel="stylesheet" type="text/css" />
     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    
    <style type="text/css">
        .style1
        {
            width: 219px;
        }
        .style2
        {
            width: 642px;
        }
        .style3
        {
            width: 607px;
        }
        .style4
        {
            width: 551px;
        }
        .style5
        {
            width: 284px;
        }
        .style8
        {
            width: 337px;
            height: 41px;
        }
        .style10
        {
            width: 625px;
        }
        .style11
        {
            height: 41px;
            width: 625px;
        }
        .style15
        {
            width: 125px;
        }
        .style16
        {
            width: 708px;
        }
        .style17
        {
            width: 337px;
        }
        .style18
        {
            width: 268px;
        }
        .style19
        {
            width: 693px;
        }
        .auto-style7 {
            width: 228px;
        }
        .auto-style8 {
            width: 235px;
        }
    </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style9 {
               width: 642px;
               height: 17px;
           }
		</style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
			$(document).ready(function() {
				$('#example').dataTable();
			} );
		</script>
    

    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width:56%;" align="center">
        <tr>
            <td><center>
                &nbsp;</center>
            </td>
        </tr>
        <tr>
            <td class="style2">
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                DATOS DE LA SOLICITUD</td>
        </tr>
        <tr>
            <td class="style2">
                <table style="width:73%; "1">
                    
                    <tr>
                        <td class="auto-style8">
                            Orden Pago:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelOrdenPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Tipo Documento:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelTipoDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Numero Documento:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Nombre beneficiario:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNombreBeneficiario" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Valor Factura:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelValorFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Numero pago:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Fecha radicado:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelFechaRadicado" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Fecha recibido contabilidad:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelFechaRecibidoContabilidad" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Numero obligacion:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumObligacion" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            &nbsp;</td>
                        <td class="auto-style7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Fecha orden de Pago:*</td>
                        <td class="auto-style7">
            <asp:TextBox ID="TextBoxFechaPago" runat="server" 
                TabIndex="1" Width="80" ValidationGroup="gv" ReadOnly="True"></asp:TextBox>
            
            <ajaxToolkit:CalendarExtender ID="TextBoxFechaPago_CalendarExtender" runat="server" 
                CssClass="MyCalendar" Format="MM/dd/yyyy" 
                TargetControlID="TextBoxFechaPago">            </ajaxToolkit:CalendarExtender>
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV19" runat="server" 
                ControlToValidate="TextBoxFechaPago" Display="None" 
                ErrorMessage="Por favor ingrese la fecha de pago" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV19_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV19">            </ajaxToolkit:ValidatorCalloutExtender>        
                
            
               
                
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" runat="server" Text="Registrar" OnClick="ButtonGuardar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
