<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetalleCuenta.aspx.cs" Inherits="DetalleCuenta"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
        </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style9 {
               width: 642px;
               height: 17px;
           }
		   .auto-style10 {
               width: 187px;
               text-align: right;
           }
		   .auto-style11 {
               height: 17px;
           }
		   .auto-style12 {
               width: 642px;
               height: 43px;
           }
		</style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>
    
    </head>
<body>
    
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width:60%; height: 681px;" align="center">
        <tr>
            <td><center>
                &nbsp;</center>
            </td>
        </tr>
        <tr>
            <td class="titulo1">
                 EVENTOS</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:GridView ID="GridViewEventos" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" Width="672px">
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
                <table style="width:100%; "1" border="0">
                    
                    <tr>
                        <td class="auto-style10">
                            Orden Pago:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelOrdenPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Tipo Documento:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelTipoDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Numero Documento:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Nombre beneficiario:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNombreBeneficiario" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Valor Factura:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelValorFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Numero pago:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Fecha radicado:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelFechaRadicado" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Fecha recibido contabilidad:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelFechaRecibidoContabilidad" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Numero obligacion:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumObligacion" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            # Factura:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            # RP:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumRP" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            # Contrato:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelNumContrato" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            Cuenta por pagar:</td>
                        <td class="auto-style7">
                            <asp:Label ID="LabelCuentaPorPagar" runat="server" Text="Label" Font-Underline="True"></asp:Label>
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
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <table style="width:100%;">
                        <tr>
                            <td bgcolor="#CCCCCC">&nbsp;</td>
                            <td bgcolor="#CCCCCC">Detalle de la devolucion de la cuenta</td>
                        </tr>
                        <tr>
                            <td class="auto-style11">Fecha:</td>
                            <td class="auto-style11">
                                <asp:Label ID="LabelDevueltaFecha" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11">Usuario:</td>
                            <td class="auto-style11">
                                <asp:Label ID="LabelDevueltaUsuario" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Detalle:</td>
                            <td>
                                <asp:Label ID="LabelDevueltaObservaciones" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td class="titulo1" align="center">
                Adjuntos</td>
        </tr>
        <tr>
            <td class="style2">
                            <asp:GridView ID="GridViewAdjuntos" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceAdjuntos" EnableModelValidation="True" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Columns>
               
                <asp:HyperLinkField DataNavigateUrlFields="ARCHIVO" Target="_blank" DataNavigateUrlFormatString="adj_cuentas/{0}" Text="Ver" />

                <asp:BoundField DataField="ARCHIVO" HeaderText="ARCHIVO" />


            </Columns>
        </asp:GridView>





        <asp:SqlDataSource ID="SqlDataSourceAdjuntos" runat="server"></asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td class="auto-style12">

            </td>
        </tr>
        </table>
 </form>
</body>
</html>
