<%@ Page Language="C#" UICulture="es" Culture="es-CO" AutoEventWireup="true" CodeFile="WebFormLiquidacion.aspx.cs" Inherits="WebFormLiquidacion" MasterPageFile="~/MasterPage.master" %>



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
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
   
    
      <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />
     <!-- <script language="javascript" type="text/javascript" src="js/thickbox.js"></script>  -->
    
        <style type="text/css">
.modalPopup
{
background-color: #696969;
filter: alpha(opacity=40);
opacity: 0.7;
xindex:-1;
}
</style>

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
        </style>
     

            <style type="text/css">
<!--
.visibleDiv, #topLeft, #topRight, #bottomLeft, #bottomRight
{
    position: fixed;
    width: 230px;
    border: solid 1px #e1e1e1;
    vertical-align: middle;
    background: #E6E6E6;
    text-align: left;
}

#topLeft
{
    top: 10px;
    left: 10px;
}

#topRight
{
    top: 260px;
    right: 10px;
}

#bottomLeft
{
    bottom: 10px;
    left: 10px;
}

#bottomRight
{
    bottom: 10px;
    right: 10px;
}
//-->
</style>


       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style13 {
               width: 76px;
           }
		   .auto-style18 {
               color: #FFFFFF;
               height: 43px;
               text-align: center;
           }
           .auto-style22 {
               width: 168px;
           }
           .auto-style24 {
               height: 17px;
           }
		   .auto-style25 {
               width: 148px;
           }
		   .auto-style30 {
               width: 135px;
           }
           .auto-style31 {
               width: 135px;
               height: 20px;
           }
           .auto-style32 {
               width: 67px;
               height: 20px;
           }
		   .auto-style33 {
               width: 67px;
           }
		   .auto-style34 {
               color: #FFFFFF;
               text-align: center;
           }
           .auto-style35 {
               color: #FFFFFF;
               width: 168px;
               text-align: center;
           }
		   .auto-style37 {
               font-size: x-small;
           }
		   .auto-style38 {
               font-weight: normal;
           }
		   .auto-style39 {
               width: 642px;
               height: 17px;
           }
		   .auto-style40 {
               font-size: large;
               color: #FFFF00;
           }
		   .auto-style41 {
               color: #FFFFCC;
               height: 30px;
               width: 201px;
               text-align: center;
           }
           .auto-style42 {
               color: #FFFFFF;
               height: 43px;
               text-align: center;
               width: 201px;
           }
           .auto-style43 {
               text-align: center;
               height: 30px;
               width: 201px;
           }
           .auto-style44 {
               color: #FFFFCC;
               height: 43px;
               width: 201px;
               text-align: center;
           }
           .auto-style45 {
               width: 201px;
               text-align: center;
           }
           .auto-style46 {
               color: #FFFFFF;
               width: 201px;
               text-align: center;
           }
           .auto-style47 {
               width: 201px;
           }
		   .auto-style48 {
               color: #FFFFCC;
               height: 43px;
               width: 226px;
               text-align: center;
           }
           .auto-style49 {
               width: 226px;
               text-align: center;
               height: 30px;
           }
           .auto-style50 {
               width: 226px;
               text-align: center;
           }
           .auto-style51 {
               color: #FFFFFF;
               height: 43px;
               text-align: center;
               width: 226px;
           }
           .auto-style52 {
               height: 30px;
               width: 226px;
           }
           .auto-style53 {
               width: 226px;
               text-align: center;
               height: 40px;
           }
           .auto-style54 {
               color: #FFFFFF;
               width: 226px;
               text-align: center;
           }
           .auto-style55 {
               width: 226px;
           }
           .auto-style56 {
               width: 187px;
           }
           .auto-style57 {
               text-align: center;
               width: 187px;
           }
           .auto-style58 {
               color: #FFFFFF;
               height: 43px;
               text-align: center;
               width: 187px;
           }
           .auto-style59 {
               text-align: center;
               height: 30px;
               width: 187px;
           }
		   .auto-style60 {
               color: #FF3300;
           }
		   </style>
		
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>

    <script type="text/javascript" language="javascript" src="js/json2.js"></script>
    
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 
    
    <script type="text/javascript" language="javascript" src="js/jquery.mask.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.date').mask('00/00/0000');
            $('.time').mask('00:00:00');
            $('.date_time').mask('00/00/0000 00:00:00');
            $('.cep').mask('00000-000');
            $('.phone').mask('0000-0000');
            $('.phone_with_ddd').mask('(00) 0000-0000');
            $('.phone_us').mask('(000) 000-0000');
            $('.mixed').mask('AAA 000-S0S');
            $('.ip_address').mask('099.099.099.099');
            $('.percent').mask('##0,00%', { reverse: true });
            $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
            $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
            $('.fallback').mask("00r00r0000", {
                translation: {
                    'r': {
                        pattern: /[\/]/,
                        fallback: '/'
                    },
                    placeholder: "__/__/____"
                }
            });

            $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });

            $('.cep_with_callback').mask('00000-000', {
                onComplete: function (cep) {
                    console.log('Mask is done!:', cep);
                },
                onKeyPress: function (cep, event, currentField, options) {
                    console.log('An key was pressed!:', cep, ' event: ', event, 'currentField: ', currentField.attr('class'), ' options: ', options);
                },
                onInvalid: function (val, e, field, invalid, options) {
                    var error = invalid[0];
                    console.log("Digit: ", error.v, " is invalid for the position: ", error.p, ". We expect something like: ", error.e);
                }
            });

            $('.crazy_cep').mask('00000-000', {
                onKeyPress: function (cep, e, field, options) {
                    var masks = ['00000-000', '0-00-00-00'];
                    mask = (cep.length > 7) ? masks[1] : masks[0];
                    $('.crazy_cep').mask(mask, options);
                }
            });

            $('.cpf').mask('000.000.000-00', { reverse: true });
            $('.money').mask('000.000.000.000.000,00', { reverse: true });

            var SPMaskBehavior = function (val) {
                return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
            },
            spOptions = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(SPMaskBehavior.apply({}, arguments), options);
                }
            };

            $('.sp_celphones').mask(SPMaskBehavior, spOptions);

            $(".bt-mask-it").click(function () {
                $(".mask-on-div").mask("000.000.000-00");
                $(".mask-on-div").fadeOut(500).fadeIn(500)
            })


        });
</script>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
                if (popup != null) {
                    popup.hide();
                }
            }
</script>
    
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
    Por favor espere...<br />
<asp:Image ID="Image1" ImageUrl="images/loadingAnimation.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />

 <asp:UpdatePanel ID="UpdatePanelControles" runat="server">
 <ContentTemplate>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server"></asp:UpdateProgress>
   




    <table style="width:100%;" align="center">
        <tr>
            <td><center>
                &nbsp;</center>
            </td>
        </tr>
        <tr>
            <td class="auto-style39">
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                Liquidación cuenta #
                    <asp:Label ID="LabelNumeroCuenta" runat="server" ForeColor="White"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style2">
                <table >
                    <tr>
                        <td class="auto-style31">
                            </td>
                        <td class="auto-style32"></td>
                        <td class="auto-style13" rowspan="13">
                                                       
                            
                                 <br />
                                <asp:HyperLink ToolTip="Consultar Detalle" CssClass="thickbox" ID="HyperLinkDetalle" runat="server" ImageUrl="~/images/magnifier.png">Ver Detalle</asp:HyperLink>||<asp:HyperLink ToolTip="Editar" ID="HyperLinkEditar" runat="server" ImageUrl="~/images/edit-document.png">Editar</asp:HyperLink>
                                 <asp:Literal ID="LiteralAlerta"  runat="server"></asp:Literal> <br />
                                   <asp:Panel runat="server">
                                     <div style ="height:100px; width:917px; overflow:auto;">
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
                                         </div>
                                    <asp:SqlDataSource ID="SqlDataSourceLiquidaciones"  runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [ID_RADICACION], [VALOR_TOTAL], [IBC], [SALUD], [PENSION], [ARL], [AFC], [INT_VIVIENDA], [PREPAGADA], [DEPENDIENTES], [RENTA_EXENTA], [BASE_GRAVABLE_RETEFUENTE_383], [BASE_GRAVABLE_RETEFUENTE_384], [RETE_FUENTE_UVT_383], [RETE_FUENTE_UVT_384], [VALOR_RF_ART_383], [VALOR_RF_ART_384], [ICA], [RETE_IVA], [TOTAL_PAGAR_383], [TOTAL_PAGAR_384] FROM [LIQUIDACIONES] INNER JOIN CUENTA ON LIQUIDACIONES.ID_RADICACION = CUENTA.ID_REGISTRO WHERE NUM_DOCUMENTO = @DOCUMENTO AND (dbo.CUENTA.FECHA_RADICADO >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)) AND (dbo.CUENTA.FECHA_RADICADO < DATEADD(month, 1 + DATEDIFF(month, 0, GETDATE()), 0))">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="DOCUMENTO" SessionField="DOCUMENTO_CONSULTAR" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </asp:Panel><br />

                            <table border="0" style="width:732px;" >
                                <tr>
                                    <td bgcolor="#0033CC" class="auto-style48">&nbsp;</td>
                                    <td bgcolor="#0033CC" class="auto-style44">Calcular con ICA:</td>
                                    <td >
                                        &nbsp;</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style49" style="border: 1px solid black;">
                                        &nbsp;</td>
                                    <td  class="auto-style41"  style="border: 1px solid black;">
                                        <div class="form-group">
                                        <label for="Numero Pago">Valor:</label>
                                        <asp:TextBox CssClass="form-control" ID="TextBoxICA" runat="server" Width="100px" ></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonRecalcular" runat="server" CausesValidation="False" CssClass="btn-success btn-lg" OnClick="ButtonRecalcular_Click" Text="Recalcular" />
                                    </td>
                                    <td class="auto-style56">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#0033CC" class="auto-style48"><strong><span class="auto-style40">A</span></strong> Valor TOTAL</td>
                                    <td bgcolor="#0033CC" class="auto-style44">IBC</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style56"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style49" style="border: 1px solid black;">
                                        <asp:Label ID="LabelValorTotal" runat="server"  Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelIBC" runat="server"  Font-Size="Small"></asp:Label>
                                    </td>
                                    <td >
                                        &nbsp;</td>
                                    <td class="auto-style56" >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style50">&nbsp;</td>
                                    <td class="auto-style45">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="auto-style57">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#009933" class="auto-style51">Salud</td>
                                    <td bgcolor="#009933" class="auto-style42">Pension</td>
                                    <td bgcolor="#009933" class="auto-style18">ARL</td>
                                    <td bgcolor="#009933" class="auto-style58">AFC y /o<br /> Ahorro voluntario</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid black;text-align: center;" class="auto-style52" >
                                        <asp:Label ID="LabelSalud" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:TextBox ID="TextBoxSalud" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style43">
                                        <asp:Label ID="LabelPension" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:TextBox ID="TextBoxPension" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td style="border: 1px solid black;height:30px;" class="text-center">
                                        <asp:Label ID="LabelARL" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:TextBox ID="TextBoxARL" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style59">
                                        <asp:Label ID="LabelAFC" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelAFCEditado" runat="server" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style53">Sin Salud:&nbsp; <asp:CheckBox ID="CheckBoxNoSalud" runat="server" AutoPostBack="True" /></td>
                                    <td class="auto-style45">Sin Pensión:&nbsp; <asp:CheckBox ID="CheckBoxNoPension" runat="server" AutoPostBack="True" />
                                    </td>
                                    <td class="text-center">Sin ARL:&nbsp; <asp:CheckBox ID="CheckBoxSinARL" runat="server" AutoPostBack="True" /></td>
                                    <td class="auto-style57">
                                        <asp:Button ID="ButtonIngresarAFC" runat="server" CausesValidation="False" CssClass="btn-primary" OnClick="ButtonIngresarAFC_Click" Text="Editar" Visible="False" />
                                        Aplica:&nbsp; <asp:CheckBox ID="CheckBoxAFC" runat="server" AutoPostBack="True" style="text-align: center" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">

                                <asp:Panel ID="PanelAFC"  Visible="false" runat="server" Width="210px">
                                 <div class="container">
                                <div class="jumbotron" style="width: 50%;">
                                <table style="width: 110%;">
                                <tr>
                                    <td colspan="3" class="auto-style24"></td>
                                    
                                </tr>
                                <tr>
                                    <td></td>
                                    <td class="auto-style25">
                                    
                                        <div class="form-group">
                                        <label for="ValorAFC">Valor AFC</label>
                                        <asp:TextBox ID="TextBoxValorAFC" runat="server" CssClass="money form-control"  ValidationGroup="AFC"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonGuardarAFC" CssClass="btn-success" runat="server" Text="Guardar" ValidationGroup="AFC" OnClick="ButtonGuardarAFC_Click"  />
                                        <asp:Button ID="ButtonCancelarAFC" CssClass="btn-danger" runat="server" CausesValidation="False" Text="Cancelar" OnClick="ButtonCancelarAFC_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                            </table>
                           </div>
                          </div>
                         </asp:Panel>


                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td bgcolor="#990000" class="auto-style54">Intereses Vivienda <span class="auto-style37">
                                        <br />

                                        <span class="auto-style38">(Hasta 100 UVT )</span></span></td>
                                    <td bgcolor="#990000" class="auto-style46">Prepagada <span class="auto-style37">
                                        <br />
                                        (hasta 16 UVT )</span> </td>
                                    <td bgcolor="#990000" class="auto-style34">Depend.10% <span class="auto-style37">
                                        <br />
                                        (hasta 32 UVT )</span></td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="auto-style50" style="border: 1px solid black;">
                                        <asp:Label ID="LabelIntViviendaPeriodo" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelIntViviendaIngresado" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelIntVivivenda" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelIntViviendaTotal" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelPrepagPeriodo" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelPrepagIngresado" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelPrepag" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelPrepagTotal" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="text-center">
                                        <asp:Label ID="LabelDependientes" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelDependientesTotal" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style57">
                                        <asp:Label ID="LabelRenta" runat="server" Visible="false" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style53">
                                        <asp:Button ID="ButtonIngresarIntViv" CssClass="btn-primary" runat="server" Text="Ingresar" CausesValidation="False" OnClick="ButtonIngresarIntViv_Click" />
                                    </td>
                                    <td class="auto-style45">
                                        <asp:Button ID="ButtonIngresarPrepag" CssClass="btn-primary" runat="server"  Text="Ingresar" CausesValidation="False" OnClick="ButtonIngresarPrepag_Click" />
                                    </td>
                                    <td class="text-center">
                                        Aplica:&nbsp; <asp:CheckBox ID="CheckBoxDependientes" runat="server" AutoPostBack="True" style="text-align: center" />
                                    </td>
                                    <td class="auto-style57">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4">

                               <asp:Panel ID="PanelIntVivienda" Visible="false" runat="server" Width="205px">
                                <div class="container">
                                <div class="jumbotron" style="width: 50%;">
                                 <table style="width: 100%;">
                               <tr>
                                    <td colspan="3" class="auto-style24"></td>
                                    
                                </tr>
                                <tr>
                                    <td></td>
                                     <td class="auto-style25">
                                        <div class="form-group" >
                                        <label for="ValorIntViv">Valor Int. Vivienda</label>
                                        <asp:TextBox ID="TextBoxValorIntViv" CssClass="money form-control"  runat="server"  ValidationGroup="IntVivienda"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonGuardarIntViv" CssClass="btn-success" runat="server" Text="Guardar" ValidationGroup="IntVivienda" OnClick="ButtonGuardarIntViv_Click" />
                                        <asp:Button ID="ButtonCancelIntViv" CssClass="btn-danger" runat="server" CausesValidation="False" OnClick="ButtonCancelIntViv_Click" Text="Cancelar" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                            </table>
                          </asp:Panel>




                            <asp:Panel ID="PanelPrepag" Visible="false" runat="server" Width="205px">
                                <div class="container">
                                <div class="jumbotron" style="width: 50%;">
                                    <asp:Literal ID="LiteralAlertaPrepagada"  runat="server"></asp:Literal>
                                <table style="width: 100%;">
                                <tr>
                                    <td colspan="3" class="auto-style24"></td>
                                    
                                </tr>
                                <tr>
                                    <td></td>
                                    <td class="auto-style25">
                                        
                                        <div class="form-group">
                                        <label for="ValorPrepagada">Valor Prepagada</label>
                                        <asp:TextBox ID="TextBoxValorPrepagada" CssClass="money form-control" runat="server"  ValidationGroup="Prepagada"></asp:TextBox>
                                            <label for="ValorPrepagada">Meses</label><asp:DropDownList ID="DropDownListMesesPrepagada" runat="server">

                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style25">
                                        <asp:Button ID="ButtonGuardarPrepag" CssClass="btn-success" runat="server" Text="Guardar" ValidationGroup="Prepagada" OnClick="ButtonGuardarPrepag_Click"   />
                                        <asp:Button ID="ButtonCancelarPrepag" CssClass="btn-danger" runat="server" CausesValidation="False" Text="Cancelar" OnClick="ButtonCancelarPrepag_Click"   />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="auto-style25">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                            </table>
                           </div>
                          </div>
                         </asp:Panel>
 


                                    </td>
                                    
                                </tr>
                                

                                <tr>
                                    <td bgcolor="Blue" class="auto-style54"><strong><span class="auto-style40">B</span></strong> Total INCRNGO (S+P+F)</td>
                                    <td bgcolor="Blue" class="auto-style46">Renta Liquida Cedular (A-B)</td>
                                    <td bgcolor="Blue" class="auto-style34"><strong><span class="auto-style40">C</span></strong> Otras Rentas Exentas</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>

                                <tr style="height:30px;">
                                    <td class="auto-style50" style="border: 1px solid black;">
                                        <asp:Label ID="LabelINCRGO" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelRentaLCedular" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="text-center">
                                        <asp:Label ID="LabelTotalRentasExentas" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td class="auto-style56" >
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td bgcolor="Blue" class="auto-style54"><strong><span class="auto-style40">D</span></strong> Deducciones </td>
                                    <td bgcolor="Blue" class="auto-style46"><strong><span class="auto-style40">E</span></strong> Base Bruta Gravable(A-B-C-D)</td>
                                    <td bgcolor="Blue" class="auto-style34"><strong><span class="auto-style40">F</span></strong> Renta Exenta 25%</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>

                                <tr style="height:30px;">
                                    <td class="auto-style50" style="border: 1px solid black;">
                                        <asp:Label ID="LabelTotalDeducciones" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelBaseBruta" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="text-center">
                                        <asp:Label ID="LabelRentaExenta" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td class="auto-style56" >
                                        &nbsp;</td>
                                </tr>

                                <tr style="height:30px;">
                                    <td bgcolor="Blue" class="auto-style54" style="border: 1px solid black;">TOTAL DEDUCCIONES (C+D+F)</td>
                                    <td bgcolor="Blue" class="auto-style46" style="border: 1px solid black;">&nbsp;<span class="auto-style40"><strong>G </strong></span>LIMITE INGRESO HONORARIO (A-B)x40%</td>
                                    <td bgcolor="Blue" class="auto-style35" style="border: 1px solid black;">&nbsp;</td>
                                    <td class="auto-style56">&nbsp;</td>
                                </tr>



                                <tr style="height:30px;">
                                    <td class="auto-style50" style="border: 1px solid black;">
                                        <asp:Label ID="LabelDeducciones" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelLimIngHonorarios" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="text-center">
                                        &nbsp;</td>
                                    <td class="auto-style56" >
                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td bgcolor="Blue" class="auto-style54">Base Gravable
                                        <br />
                                        (A-B-G)</td>
                                    <td bgcolor="Blue" class="auto-style46">Rte Fuente en UVT</td>
                                    <td bgcolor="Blue" class="auto-style34">Valor a Cobrar
                                        <br />
                                        de Retefuente </td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>

                                <tr style="height:30px;">
                                    <td class="auto-style50" style="border: 1px solid black;">
                                        <asp:Label ID="LabelBaseGRetefuente383" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style45">
                                        <asp:Label ID="LabelRetefuenteUVT" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="text-center">
                                        <asp:Label ID="LabelValorCobrarRetefuente" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td class="auto-style56" >
                                        &nbsp;</td>
                                </tr>

                                <tr style="height:30px;">
                                    <td bgcolor="Blue" class="auto-style54" style="border: 1px solid black;">ICA</td>
                                    <td bgcolor="Blue" class="auto-style46" style="border: 1px solid black;">Rete IVA:</td>
                                    <td bgcolor="Blue" class="auto-style35" style="border: 1px solid black;">TOTAL A PAGAR:</td>
                                    <td class="auto-style56">&nbsp;</td>
                                </tr>



                                <tr style="height:30px;">
                                    <td class="auto-style55" style="border: 1px solid black; text-align: center;">
                                        Base:<asp:Label ID="LabelBaseICA" runat="server" Font-Size="Small"></asp:Label><br />
                                        <asp:Label ID="LabelICA" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td class="auto-style47" style="border: 1px solid black; text-align: center;">
                                        <asp:Label ID="LabelReteIVA" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td class="auto-style22" style="border: 1px solid black;">
                                        <asp:Label ID="LabelTotalPagar383" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Blue" Font-Underline="True"></asp:Label>
                                    </td>
                                    <td class="auto-style56" style="border: 1px solid black;">
                                        <span class="auto-style60">Sin retenciones</span>
                                        <asp:CheckBox ID="CheckBoxSinRetencion" runat="server" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="auto-style55" >&nbsp;</td>
                                    <td class="auto-style47" >&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="auto-style55" >
                                        &nbsp;</td>
                                    <td class="auto-style47" >&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="auto-style55" >
                                        &nbsp;</td>
                                    <td class="auto-style47" >&nbsp;</td>
                                    <td >&nbsp;</td>
                                    <td class="auto-style56" >&nbsp;</td>
                                </tr>
                                
                            </table>
                                
                        </td>
                    </tr>



                    <tr>
                        <td class="auto-style30">
                            &nbsp;</td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            
                            <table style="width: 100%;">
                                <tr>
                                    <td> <div class="form-group">
                            <label for="CuentaPorPagar">Cuenta por pagar:</label>
                            <asp:TextBox ID="TextBoxCuentaPorPagar" class="form-control" ValidationGroup="CXP" runat="server" ></asp:TextBox>
                            </div></td>
                                    <td>
                                        <asp:Button ID="ButtonActualizarCXP" ValidationGroup="CXP" runat="server" CausesValidation="False" CssClass="btn-success btn-lg" Text="Ingresar" OnClick="ButtonActualizarCXP_Click" />
                                        <asp:RequiredFieldValidator ID="RFV18" runat="server" ValidationGroup="CXP" ControlToValidate="TextBoxCuentaPorPagar" Display="None" ErrorMessage="Por favor ingrese el numero de cuenta" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="RFV18_ValidatorCalloutExtender" runat="server" TargetControlID="RFV18">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </td>
                                   
                                </tr>
                                
                            </table>
                        </td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td >
                             <div class="form-group">
                            <label for="Entidad">Entidad:<asp:DropDownList ID="DropDownListEntidad" runat="server" AppendDataBoundItems="True" CssClass="form-control" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD" Width="180" Enabled="False">
                                     <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                 </asp:DropDownList>
                                 </label>
                            <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            </div>
                        </td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            <div class="form-group">
                            <label for="NumeroDocumento">Numero Documento:</label>
                            <asp:TextBox ID="TextBoxNumeroDocumento" class="form-control"  runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                            </div>
            
                            <ajaxToolkit:FilteredTextBoxExtender
                        ID="TextBoxNumeroDocumento_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" TargetControlID="TextBoxNumeroDocumento" FilterType="Numbers">
                      </ajaxToolkit:FilteredTextBoxExtender>
               
                
                        </td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <span class="glyphicon glyphicon-user"></span>
                            <label for="NombreBeneficiario">Nombre Beneficiario:</label>
                            <asp:TextBox ID="TextBoxNombres" CssClass="form-control" runat="server" Width="277px" ReadOnly="True"></asp:TextBox>
                </div>
            
               
                
                        </td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <span class="glyphicon glyphicon-envelope"></span>
                            <label for="Correo Electronico">Correo Electronico: *</label>
                            <asp:TextBox ID="TextBoxCorreo" class="form-control" runat="server" Width="270px" ReadOnly="True"></asp:TextBox>
                            </div>
            
               
                
                        </td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="NombreBeneficiario">Numero de contrato:</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxNumeroContrato" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
            
               
                
                        </td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>

                     

                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="Riesgo Laboral">Riesgo Laboral:</label>
                            <asp:DropDownList ID="DropDownListRiesgoLaboral" CssClass="form-control" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceRiesgoLaboral" DataTextField="NOMBRE" DataValueField="ID_RIESGO">
                            </asp:DropDownList>
                                 <asp:SqlDataSource ID="SqlDataSourceRiesgoLaboral" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [RIESGOS_LABORALES] WHERE ([ACTIVO] = @ACTIVO)">
                                     <SelectParameters>
                                         <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                     </SelectParameters>
                                 </asp:SqlDataSource>
                            </div>
                        </td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>

                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <span class="glyphicon glyphicon-usd"></span>
                            <label for="Valor">Valor:</label>
                            <asp:TextBox ID="TextBoxValorFactura" CssClass="money form-control"  runat="server" AutoPostBack="True" ReadOnly="True" ></asp:TextBox>
                            </div>
           

                           
                
            
               
                
                        </td>

                        <td class="auto-style33">&nbsp;</td>

                    </tr>
                   
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            &nbsp;<asp:Label ID="LabelIVA" runat="server" Text="IVA" Visible="true"></asp:Label>
                                 <asp:TextBox ID="TextBoxValorIVA" CssClass="money form-control" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                            </div>
                        </td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="NumeroFactura">Numero de Factura:</label>
                            <asp:TextBox ID="TextBoxNumFactura" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
            
               
                
                        </td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="NumeroRP">Número RP:</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxNumeroRP" runat="server" ReadOnly="True"></asp:TextBox>
                                 </div>
                
            
               
                
                        </td>

                        <td class="auto-style33">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="Numero Pago">Numero Pago:</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxNumeroPago" runat="server" Width="277px" ReadOnly="True"></asp:TextBox>
                            </div>
            
               
                
                        </td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    </table>

            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style2">
                 <div class="form-group">
                    <label for="Nota">
                    Objeto:</label>
                    <asp:TextBox ID="TextBoxObjeto" ReadOnly="true" runat="server" CssClass="form-control" Height="65px" TextMode="MultiLine" Width="621px"></asp:TextBox>
                </div>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style2">
                <div class="form-group">
                    <label for="Nota">
                    Nota (Se vera reflejada en el documento de deducciones):</label>
                    <asp:TextBox ID="TextBoxNota" runat="server" CssClass="form-control" Height="44px" TextMode="MultiLine" Width="391px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="style2">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style2">
                <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn-success btn-lg" OnClick="ButtonGuardar_Click" Text="Registrar" />
                <asp:Button ID="ButtonVolverListado" runat="server" CssClass="btn-success btn-lg"  Text="Volver a Listado"  OnClick="ButtonVolverListado_Click" />
            </td>
        </tr>
        <tr>
            <td >
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
        </table>


        <div id="topRight">
        <asp:Literal ID="LiteralInfoValores" runat="server"></asp:Literal>
        </div>

      </ContentTemplate>
   </asp:UpdatePanel>
   </asp:Content>
