<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdicionarFacturaElectronica.aspx.cs" Inherits="AdicionarFacturaElectronica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!--[if lt IE 11]>
        <script src="//cdnjs.cloudflare.com/ajax/libs/json3/3.3.2/json3.min.js"></script>
    <![endif]-->

   
     <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 11]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
<link rel="stylesheet" href="estilo.css">
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>


    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link href="calendario.css" rel="stylesheet" type="text/css" />
   

     <script type="text/javascript" language="javascript" src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

    <link href=" https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

	<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>

     <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {





		        $('#example').dataTable({
		            "aaSorting": [[0, "desc"]],
		            "language": {
		                "lengthMenu": "Mostrando _MENU_ registros por pagina",
		                "zeroRecords": "No se encontraron registros",
		                "info": "Mostrando página _PAGE_ de _PAGES_",
		                "infoEmpty": "Busqueda sin registros",
		                "infoFiltered": "(filtrado de _MAX_ registros)",
		                "paginate": {
		                    "first": "Primero",
		                    "last": "Ultimo",
		                    "next": "Siguiente",
		                    "previous": "Anterior"
		                },
		                "search": "Busqueda rápida"
		            }

		        });

		        var table = $('#example').DataTable();

		        $('#example tbody').on('click', 'tr', function () {
		            $(this).toggleClass('selected');
		        });

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
                            <td class="auto-style1" align="right">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                            <td>&nbsp;</td>
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
                    <table style="width: 75%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px"></td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <label for="Correo Electronico">Numero documento:</label>
                                <asp:TextBox ID="TextBoxNumeroDoc" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td>
                                <label for="ID">ID Cuenta:</label>
                                <asp:TextBox ID="TextBoxID" CssClass="form-control" runat="server" ></asp:TextBox>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px"></td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px"></td>
                            <td>&nbsp;</td>
                            <td style="width: 26px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                
                                &nbsp;</td>
                            <td style="width: 70px">
                                &nbsp;</td>
                            <td>
                                 &nbsp;</td>
                            </td>
                            <td style="width: 26px">
                                <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" CssClass="btn-success btn-lg" Text="Buscar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 26px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                   </fieldset>
                </td>
            </tr>
            <tr>
                <td style="height: 17px">
                    </td>
            </tr>
            <tr>
                <td>
                
                
                   
                   <asp:GridView ID="GridView1" AllowPaging="true" OnPreRender="gridViewMaster_PreRender" AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="40" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" GridLines="Vertical">
                   
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <Columns>
                <asp:BoundField DataField="ID_REGISTRO" HeaderText="ID RADICADO" />
                <asp:HyperLinkField DataNavigateUrlFields="ID_REGISTRO" Target="_blank" ControlStyle-CssClass="thickbox" DataNavigateUrlFormatString="DetalleCuenta.aspx?id={0}&keepThis=true&TB_iframe=true&height=450&width=700'" Text="Resumen" />
                <asp:BoundField DataField="FECHA_RADICADO" HeaderText="FECHA RADICACION" >
                    <ItemStyle Width="140px"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="NUM_DOCUMENTO" HeaderText="DOCUMENTO" />
                <asp:BoundField DataField="NOMBRE_BENEFICIARIO" HeaderText="BENEFICIARIO" >
                    <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="VALOR_FACTURA" DataFormatString="{0:c}" HeaderText="VR. FACTURA" >
                    <ItemStyle Width="140px"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="CUENTA_POR_PAGAR" HeaderText="C X P" />
                <asp:BoundField DataField="NUM_PAGO" HeaderText="NUM_PAGO" >
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>   
                
                <asp:HyperLinkField DataNavigateUrlFields="ID_REGISTRO" Target="_self" DataNavigateUrlFormatString="GenerarFacturaElectronica.aspx?id={0}&Formulario=AdicionarFacturaElectronica.aspx" Text="Generar Factura" />
            </Columns>
        </asp:GridView>



                    
                    
                    
               
                </td>
            </tr>
            <tr>
                <td style="height: 153px">
                </td>
            </tr>
        </table>

           
    
    </div>
</asp:Content>

