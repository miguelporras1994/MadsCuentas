<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReasignarCuentaContabilidad.aspx.cs" Inherits="ReasignarCuentaContabilidad" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                    <table style="width:49%;">
                        <tr>
                            <td class="auto-style2">Asignado a:</td>
                            <td>


                            <asp:DropDownList ID="DropDownListAsignado" CssClass="form-control" Width="250" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="USUARIO">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [USUARIO],NOMBRE + ' (' + CAST(dbo.CuentasAsignadoasContabilidad(USUARIO) AS VARCHAR(10)) + ')' AS NOMBRE FROM [USUARIOS] WHERE [PERFIL] IN ('Contabilidad','ContabilidadLider') ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="Contabilidad" Name="PERFIL" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Entidad:</td>
                            <td>
                                <asp:DropDownList ID="DropDownListEntidad"  CssClass="form-control"  Width="250" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD">
                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBuscar" CssClass="btn-success btn-lg" runat="server" OnClick="ButtonBuscar_Click1" Text="Buscar" />
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
                     <div style ="height:900px; width:1180px; overflow:auto;">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                     </div>
                </td>
            </tr>
             <tr><td style="height:200px;"></td></tr>
        </table>
    
    </div>
</asp:Content>
