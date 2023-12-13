<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarPendientesCertificados.aspx.cs" Inherits="ListarPendientesCertificados" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


     <meta name="viewport" content="width=device-width, initial-scale=1">

    <!--[if lt IE 11]>
        <script src="//cdnjs.cloudflare.com/ajax/libs/json3/3.3.2/json3.min.js"></script>
    <![endif]-->

   
     <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 11]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
<link rel="stylesheet" href="estilo.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

    <script type="text/javascript" language="javascript" src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

    <link href=" https://cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

	    <script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>

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
                            <td class="modal-sm" style="width: 383px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="modal-sm" style="width: 383px">
                                &nbsp;</td>
                            <td><h2>Solicitudes pendientes de envio de certificados de ingresos y retenciones</h2></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="modal-sm" style="width: 383px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                
                   
                   <asp:GridView ID="GridView1" EmptyDataText="No hay solicitudes pendientes" AllowPaging="true" AllowSorting="true" PageSize="40" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" GridLines="Vertical">
                   
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <Columns>
                <asp:BoundField DataField="ID_SOLICITUD" HeaderText="ID RADICADO" />
                
                <asp:BoundField DataField="FECHA" HeaderText="FECHA RADICACION" >
                    <ItemStyle Width="140px"></ItemStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="CEDULA" HeaderText="DOCUMENTO" />
                <asp:BoundField DataField="CORREO" HeaderText="CORREO" >

                    <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                        <asp:BoundField DataField="ANO" HeaderText="AÑO" />
                <asp:HyperLinkField DataNavigateUrlFields="ID_SOLICITUD" Target="_self" DataNavigateUrlFormatString="AtenderSolicitudCertificado.aspx?id_solicitud={0}" Text="Atender Solicitud" />

            </Columns>
        </asp:GridView>



                    
                    
                    
                   </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
           <tr>
                <td>
                <div style ="height:900px; width:1300px; overflow:auto;">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                     </div>
                </td>
            </tr>
            <tr>
                <td style="height: 153px">
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
