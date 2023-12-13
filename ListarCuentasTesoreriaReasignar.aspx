<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarCuentasTesoreriaReasignar.aspx.cs" Inherits="ListarCuentasTesoreriaReasignar" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                    <table style="width:60%;">
                        <tr>
                            <td class="auto-style1">Asignado a</td>
                            <td>


                            <asp:DropDownList ID="DropDownListAsignado" runat="server" CssClass="form-control"  Width="250" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="USUARIO">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="USUARIOS_TESORERIA" SelectCommandType="StoredProcedure">
                                
                            </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBuscar" runat="server" CssClass="btn-success btn-lg" OnClick="ButtonBuscar_Click1" Text="Buscar" />
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
                    <div style ="height:700px; width:1180px; overflow:auto;">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                </td>
            </tr>
            <tr>
                <td style="height: 168px">
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
