<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadicarInformeMensualContratista.aspx.cs" Inherits="RadicarInformeMensualContratista" MasterPageFile="~/MasterPage.master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
   

     <script type="text/javascript" language="javascript" src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

    <link href=" https://cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

	<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>

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
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style1">MINISTERIO DE AMBIENTE Y DESARROLLO SOSTENIBLE</td>
                            <td>INFORME PERIODICO DE SUPERVISION E INFORME DE ACTIVIDADES DEL <BR />CONTRATISTA<BR />Proceso:Contrataci&oacute;n</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1" align="right">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>Codigo: F-A-CTR-04</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td>
                    INFORMACION BASICA DEL CONTRATISTA / EJECUTOR</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style1">Nombre / Razon Social</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="331px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1" align="right" style="height: 20px">
                                Identficacion</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 20px">&nbsp;</td>
                            <td style="height: 20px"></td>
                            <td style="height: 20px"></td>
                            <td style="height: 20px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Correo</td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                            <td>Celular:</td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                            <td>Extension:</td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                   </fieldset>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    INFORMACION DEL CONTRATO / CONVENIO</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style1">Contrato No.</td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" Height="16px" Width="331px"></asp:TextBox>
                            </td>
                            <td>CDP No.:</td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                            <td>Periodo a pagar:</td>
                            <td>
                                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1" align="right" style="height: 20px">
                                Fecha de suscripcion:</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 20px">No. RP.:</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 20px">&nbsp;</td>
                            <td style="height: 20px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Fecha de iniciacion:</td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                            <td>Fecha de terminacion:</td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                            </td>
                            <td>Plazo de Ejecucion:</td>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    INFORMACIÓN FINANCIERA DEL CONTRATO O CONVENIO</td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    <table style="width:69%;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Honorarios</td>
                            <td>
                                &nbsp;</td>
                            <td>Gastos de Desplazamiento:</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Valor Inicial:</td>
                            <td>
                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                            </td>
                            <td>Valor Inicial:</td>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                Adicion No.:</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 20px">Adicion No.:</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Valor Total:</td>
                            <td>
                                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                            </td>
                            <td>Valor Total:</td>
                            <td>
                                <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>Saldo Gastos de Desplazamiento:</td>
                            <td>
                                <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Total Pagado Honorarios:</td>
                            <td>
                                <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Total Pagado Desplazamiento:</td>
                            <td>
                                <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Saldo pendiente a pagar:</td>
                            <td>
                                <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="LabelNumPago" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    Pagos realizados</td>
                <td>
                    </td>
            </tr>
            <tr>
                <td style="height: 1px" class="style1">

                    <asp:GridView BorderWidth="1"  ID="GridViewLiquidaciones" runat="server" CellSpacing="2"  AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceLiquidaciones" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="1513px" >


                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            
                                            <asp:BoundField ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="30px" ItemStyle-Wrap="false" DataField="ID_RADICACION" HeaderText="RADICADO" SortExpression="ID_RADICACION" >
                                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                            <ItemStyle BorderWidth="1px" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="VALOR_TOTAL" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" ItemStyle-Wrap="false" DataFormatString="{0:c}"  HtmlEncode="False"  HeaderText="VALOR" SortExpression="VALOR_TOTAL" >
                                            <ItemStyle HorizontalAlign="Center" Width="120px" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IBC" ItemStyle-Width="120px" ItemStyle-Wrap="false" DataFormatString="{0:c}" HtmlEncode="False" HeaderText="IBC" SortExpression="IBC" >
                                            <ItemStyle Width="120px" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SALUD" HeaderText="SALUD" SortExpression="SALUD" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="PENSION" HeaderText="PENSION" SortExpression="PENSION" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="ARL" HeaderText="ARL" SortExpression="ARL" DataFormatString="{0:c}" HtmlEncode="False"/>
                                            <asp:BoundField DataField="AFC" HeaderText="AFC" SortExpression="AFC" DataFormatString="{0:c}" HtmlEncode="False"/>
                                            <asp:BoundField DataField="INT_VIVIENDA" HeaderText="INT. VIVIENDA" SortExpression="INT_VIVIENDA" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="PREPAGADA" HeaderText="PREPAGADA" SortExpression="PREPAGADA" DataFormatString="{0:c}" HtmlEncode="False" />

                                            
                                            <asp:BoundField DataField="DEPENDIENTES" HeaderText="DEPENDIENTES" SortExpression="DEPENDIENTES" DataFormatString="{0:c}" HtmlEncode="False"/>
                                            <asp:BoundField DataField="RENTA_EXENTA" HeaderText="RENTA EXENTA" SortExpression="RENTA_EXENTA" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="VALOR_RF_ART_383" HeaderText="RETE FTE 383" SortExpression="VALOR_RF_ART_383" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="VALOR_RF_ART_384" HeaderText="RETE FTE 384" SortExpression="VALOR_RF_ART_384" DataFormatString="{0:c}" HtmlEncode="False" />
                                            <asp:BoundField DataField="ICA" HeaderText="RETE ICA" SortExpression="ICA" DataFormatString="{0:c}" HtmlEncode="False" />
                                        

                                            
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" BorderWidth="1px" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />


                                    </asp:GridView>

                    </td>
                <td style="height: 1px" class="style1">
                    </td>
            </tr>
            <tr>
                <td style="height: 9px">
                    </td>
                <td style="height: 9px">
                    </td>
            </tr>
            <tr>
                <td style="height: 14px">
                    ACTIVIDADES DE EJECUCIÓN</td>
                <td style="height: 14px">
                    </td>
            </tr>
            <tr>
                <td style="height: 14px">
                    <table style="width:100%;">
                        <tr>
                            <td>OBJETO</td>
                            <td>
                                                    <asp:TextBox ID="TextBoxTema0" runat="server" Height="42px" TabIndex="5" TextMode="MultiLine" ValidationGroup="entrenamientos" Width="756px"></asp:TextBox>
                                                    </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                     <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>Obligacion:</td>
                                        <td>
                                                    <asp:TextBox ID="TextBoxTema1" runat="server" Height="42px" TabIndex="5" TextMode="MultiLine" ValidationGroup="entrenamientos" Width="756px"></asp:TextBox>
                                                    </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                                    <asp:GridView ID="gvEntrenamientos0" runat="server" AutoGenerateColumns="False" CssClass="Gridview" HeaderStyle-BackColor="OrangeRed" HeaderStyle-ForeColor="White" >
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="Tema" HeaderText="Tema" />
                                                            <asp:BoundField DataField="Duracion" HeaderText="Duración(Horas)" />
                                                            <asp:BoundField DataField="Participantes" HeaderText="Participantes" />
                                                            <asp:BoundField DataField="HHE" HeaderText="HHE" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="OrangeRed" ForeColor="White" />
                                                    </asp:GridView>
                                                </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td style="height: 14px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table class="style5" width="888">
                                           
                                            <tr>
                                                <td class="style3">Obligacion:</td>
                                                <td class="style7">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="801px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">Acciones:*</td>
                                                <td class="style7">
                                                    <asp:TextBox ID="TextBoxTema" runat="server" Height="60px" TabIndex="5" TextMode="MultiLine" ValidationGroup="entrenamientos" Width="641px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="TextBoxTema" Display="None" ErrorMessage="Por favor ingrese el tema" SetFocusOnError="True" ValidationGroup="entrenamientos"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtenderReportadoPor" runat="server" TargetControlID="RFV1">
                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style3">&nbsp;</td>
                                                <td class="style7">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style19"></td>
                                                <td class="style20">
                                                    <asp:Button ID="ButtonAdEntren0" runat="server" BackColor="#FF9900" Font-Size="Medium" Height="34px"  Text="Adicionar Accion" ValidationGroup="entrenamientos" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:GridView ID="gvEntrenamientos" runat="server" AutoGenerateColumns="False" CssClass="Gridview" HeaderStyle-BackColor="OrangeRed" HeaderStyle-ForeColor="White" >
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="Tema" HeaderText="Tema" />
                                                            <asp:BoundField DataField="Duracion" HeaderText="Duración(Horas)" />
                                                            <asp:BoundField DataField="Participantes" HeaderText="Participantes" />
                                                            <asp:BoundField DataField="HHE" HeaderText="HHE" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="OrangeRed" ForeColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td style="height: 153px">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td style="height: 153px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 153px">
                    &nbsp;</td>
                <td style="height: 153px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 153px">
                    &nbsp;</td>
                <td style="height: 153px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 153px">
                    &nbsp;</td>
                <td style="height: 153px">
                    &nbsp;</td>
            </tr>
        </table>

           
    
    </div>
</asp:Content>
