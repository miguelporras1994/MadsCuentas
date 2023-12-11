<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResolverDevolucion.aspx.cs" Inherits="ResolverDevolucion" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link href="css/Mensajes.css" rel="stylesheet" />
    <link href="calendario.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

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
            width: 192px;
        }
        </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style8 {
               width: 175px;
           }
		   .auto-style9 {
               width: 175px;
               height: 28px;
           }
           .auto-style10 {
               width: 192px;
               height: 28px;
           }
           .auto-style11 {
               width: 216px;
               height: 28px;
               text-align: right;
           }
           .auto-style12 {
               width: 192px;
               font-weight: normal;
           }
           </style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>
    

    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width:100%;" border="0" align="center">
        <tr>
            <td class="titulo1">
                CUENTA
            </td>
        </tr>
        <tr>
            <td class="style2">
                <table style="width:78%;" border="0">
                    
                    <tr>
                        <td class="auto-style11">
                            Orden Pago:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelOrdenPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Tipo Documento:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelTipoDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Numero Documento:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelNumDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Nombre beneficiario:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelNombreBeneficiario" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Valor Factura:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelValorFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Numero pago:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelNumPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Fecha radicado:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelFechaRadicado" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Fecha recibido contabilidad:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelFechaRecibidoContabilidad" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Numero obligacion:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelNumObligacion" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Cuenta por pagar:</td>
                        <td class="auto-style12">
                            <asp:Label ID="LabelCuentaPorPagar" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            Adjunto cuenta por pagar:</td>
                        <td class="auto-style12">
                            <asp:Literal ID="LiteralAdjunto" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    </table>
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                EVENTOS</td>
        </tr>
        <tr>
            <td >
                <asp:GridView ID="GridViewEventos" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="OPERACION" HeaderText="OPERACION" />
                        <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="GRUPO" HeaderText="GRUPO" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="titulo1">
                DATOS DE LA SOLICITUD</td>
        </tr>
        <tr>
            <td class="style2">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style9">
                            &nbsp;</td>
                        <td class="auto-style10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Observaciones*:</td>
                        <td class="auto-style7">


                            <asp:TextBox ID="TextBoxObservaciones" runat="server" Height="42px" TextMode="MultiLine" Width="292px"></asp:TextBox>
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV22" runat="server" 
                ControlToValidate="TextBoxObservaciones" Display="None" 
                ErrorMessage="Por favor especifique el motivo de la deovolucion" 
                SetFocusOnError="True" ></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV22_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV22">            </ajaxToolkit:ValidatorCalloutExtender>        
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" runat="server" Text="Resolver Devolucion" OnClick="ButtonGuardar_Click" />
                </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
        </table>
   </asp:Content>
