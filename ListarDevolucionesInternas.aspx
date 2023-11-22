<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarDevolucionesInternas.aspx.cs" Inherits="ListarDevolucionesInternas" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

     <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style1 {
             width: 38px;
         }
		   .auto-style2 {
             width: 166px;
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
    
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style2">Grupo de devolucion:</td>
                            <td>
                                <asp:DropDownList ID="DropDownListGrupoDevolucion" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceGrupoDevolucion" DataTextField="NOMBRE" DataValueField="ID_GRUPO_DEVOLUCION">
                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceGrupoDevolucion" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [ID_GRUPO_DEVOLUCION], [NOMBRE] FROM [GRUPO_DEVOLUCION] WHERE ([ACTIVO] = @ACTIVO)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click1" Text="Buscar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    
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
