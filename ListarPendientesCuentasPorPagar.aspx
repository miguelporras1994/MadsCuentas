﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarPendientesCuentasPorPagar.aspx.cs" Inherits="ListarPendientesCuentasPorPagar" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

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
                            <td class="auto-style1" style="height: 38px"></td>
                            <td style="height: 38px">

                            </td>
                            <td style="height: 38px"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td>

                            <label for="Asignado A:">Asignado A:</label>
                            <asp:DropDownList ID="DropDownListAsignado" Width="250" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="USUARIO">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT USUARIO, NOMBRE + ' (' + CAST(dbo.CuentasAsignadoas(USUARIO) AS VARCHAR(10)) + ')' AS NOMBRE FROM USUARIOS WHERE (PERFIL IN ('cuentasPorPagarLider', 'cuentasPorPagar')) ORDER BY NOMBRE">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="cuentasPorPagar" Name="PERFIL" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                                <asp:Button ID="ButtonBuscar" CssClass="btn-success btn-lg" runat="server" OnClick="ButtonBuscar_Click1" Text="Buscar" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                
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
                   <div style ="height:700px; width:1180px; overflow:auto;">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div></td>
            </tr>
            <tr>
                <td style ="height:200px;"" >
                    
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
