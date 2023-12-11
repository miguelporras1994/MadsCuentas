<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarPendientesEliminarLiquidacion.aspx.cs" Inherits="ListarPendientesEliminarLiquidacion" MasterPageFile="~/MasterPage.master" %>

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
		                "zeroRecords": "Nothing found - sorry",
		                "info": "Showing page _PAGE_ of _PAGES_",
		                "infoEmpty": "No records available",
		                "infoFiltered": "(filtered from _MAX_ total records)"
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
                    <table style="width: 75%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
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
                                <label for="Correo Electronico">Entidad:</label>
                                <asp:DropDownList ID="DropDownListEntidad" CssClass="form-control" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD">
                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            </td>
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
                                <label for="Correo Electronico">Nombre:</label>
                                <asp:TextBox ID="TextBoxNombre" CssClass="form-control" runat="server" ></asp:TextBox>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="Correo Electronico">Cuenta por pagar:</label>
                                <asp:TextBox ID="TextBoxCuentaPorPagar" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td>
                                <label for="Correo Electronico">Correo:</label>
                                <asp:TextBox ID="TextBoxCorreo" CssClass="form-control" runat="server" ></asp:TextBox>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="Correo Electronico">No Radicado:</label>
                                <asp:TextBox ID="TextBoxOrdenPago" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td><label for="Correo Electronico">Tipo de Solicitud:</label>
                            <asp:DropDownList ID="DropDownListTipoDocumento" runat="server" class="form-control" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="NOMBRE" DataValueField="ID_TIPO_DOC">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [ID_TIPO_DOC], [NOMBRE], [ACTIVO] FROM [TIPO_DOCUMENTO] WHERE ([ACTIVO] = @ACTIVO) ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </td>
                            <td style="width: 26px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                
                            <label for="Correo Electronico">Fecha inicio radicación:</label>
                                <table><tr><td>
                                    <asp:TextBox ID="TextBoxFechaIniCierre" class="form-control" runat="server"  Style="position: static" Width="126px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" TargetControlID="TextBoxFechaIniCierre">
                                    </ajaxToolkit:CalendarExtender>
                                    </td><td>&nbsp;</td><td>
                                    &nbsp;</td>
                                    </tr>
                                    </table>

                            </td>
                            <td style="width: 70px">
                                &nbsp;</td>
                            <td>
                                 <label for="Correo Electronico">Fecha fin radicación:</label>
                                <table><tr><td>
                                    &nbsp;</td><td>&nbsp;</td><td>
                                    <asp:TextBox ID="TextBoxFechaFinCierre" runat="server" class="form-control"  Style="position: static" Width="126px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaFinCierre_CalendarExtender" runat="server" CssClass="MyCalendar" TargetControlID="TextBoxFechaFinCierre">
                                    </ajaxToolkit:CalendarExtender>
                                    </td>
                                    </tr>
                                </table>
                            </td>
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
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    
                   
                   <asp:GridView ID="GridView1" AllowPaging="True" AllowSorting="True" PageSize="40" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" GridLines="Vertical">
                   
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <Columns>
                <asp:BoundField DataField="ID_REGISTRO" HeaderText="ID RADICADO" />
                <asp:HyperLinkField DataNavigateUrlFields="ID_REGISTRO" Target="_blank" ControlStyle-CssClass="thickbox" DataNavigateUrlFormatString="DetalleCuenta.aspx?id={0}&keepThis=true&TB_iframe=true&height=450&width=700'" Text="Resumen" >
<ControlStyle CssClass="thickbox"></ControlStyle>
                        </asp:HyperLinkField>
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
                <asp:BoundField DataField="ENTIDAD" HeaderText="ENTIDAD" />
                
                <asp:HyperLinkField DataNavigateUrlFields="ID_REGISTRO" Target="_self" DataNavigateUrlFormatString="EliminarLiquidacion.aspx?id={0}" Text="Eliminar Liquidacion" />
                

            </Columns>
        </asp:GridView>



                    
                    
                    
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
