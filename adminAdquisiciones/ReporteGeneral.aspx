<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteGeneral.aspx.cs" Inherits="ReporteGeneral" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="/estilo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/css/thickbox.css" type="text/css" media="screen" />

     <script src='/js/jquery1.4.4.js' type='text/javascript'></script>
    <script language="javascript" type="text/javascript" src="/js/thickbox.js"></script> 

     <style type="text/css" title="currentStyle">
			@import "/js/DataTables-1.7.6/media/css/demo_page.css";
			@import "/js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style1 {
             width: 38px;
         }
		   </style>
		<script type="text/javascript" language="javascript" src="/js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="/js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/excel_icon.png" Width="30px" /></td>
                            <td><asp:Button ID="ButtonGenerarReporte" runat="server" OnClick="ButtonGenerarReporte_Click" Text="Generar Reporte" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset><legend>Filtro de Busqueda</legend>
                    <table style="width: 39%;">
                        <tr>
                            <td>Sin recibo contabilidad:</td>
                            <td>
                                <asp:CheckBox ID="CheckBoxSinRCont" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Sin recibo tesoreria:</td>
                            <td>
                                <asp:CheckBox ID="CheckBoxSinRTes" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Incluir devueltas:</td>
                            <td>
                                <asp:CheckBox ID="CheckBoxDevueltas" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Solo devueltas:</td>
                            <td>
                                <asp:CheckBox ID="CheckBoxSoloDevueltas" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                   </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
