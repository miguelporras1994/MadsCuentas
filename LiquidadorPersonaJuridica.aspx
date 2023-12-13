<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiquidadorPersonaJuridica.aspx.cs" Inherits="LiquidadorPersonaJuridica" MasterPageFile="~/MasterPage.master" %>



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
		   .auto-style36 {
               width: 168px;
               text-align: center;
           }
		   .auto-style39 {
               width: 469px;
           }
		   </style>
		
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
			$(document).ready(function() {
				$('#example').dataTable();
			} );
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
            $('.percent').mask('##000.00', { reverse: true });
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
            <td class="style2">
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                <asp:Label ID="LabelTitulo" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td class="style2">
                <table >
                    <tr>
                        <td class="auto-style31">
                            &nbsp;</td>
                        <td class="auto-style32"></td>
                        <td class="auto-style13" rowspan="14">


                            <fieldset><legend>Liquidacion Personas Juridicas</legend>
                                <asp:Literal ID="LiteralAlerta"  runat="server"></asp:Literal>
                                <table class="auto-style39" >
                                    <tr>
                                        <td bgcolor="#c0c0c0" class="auto-style30">Beneficiario:</td>
                                        <td>
                                            <asp:Label ID="LabelBeneficiario" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#c0c0c0" class="auto-style30">Nit:</td>
                                        <td>
                                            <asp:Label ID="LabelNit" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style30" bgcolor="#c0c0c0">Cuenta por pagar:</td>
                                        <td>
                                            <asp:Label ID="LabelCuentaPorPagar" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style30" bgcolor="#c0c0c0">ID cuenta:</td>
                                        <td>
                                            <asp:Label ID="LabelCuentaID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>


                                <!-- traer cuentas anteriores -->
                            <h3>Cuentas radicadas en el año</h3>
                            <asp:Panel runat="server">
                                     <div style ="height:auto; width:917px; overflow:auto;">
                                    <asp:GridView BorderWidth="1px"  ID="GridViewCuentasAnteriores" DataKeyNames="ID_RADICACION" runat="server" CellSpacing="2"  AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceCuentasAnt" EnableModelValidation="True" ForeColor="#333333" Width="917px" >
                                        

                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                             <asp:BoundField DataField="ID_LIQUIDACION" Visible="false" >
                                                
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="ID_RADICACION" Target="_blank" DataNavigateUrlFields="ID_RADICACION" DataNavigateUrlFormatString="OrdenPagoMADS.aspx?id={0}" Text="Ver" />
                                            <asp:BoundField DataField="ID_RADICACION" Visible="false" HeaderText="ID" SortExpression="ID_RADICACION" InsertVisible="False" ReadOnly="True" >
                                                <ItemStyle Width="50px" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FECHA_RADICADO" DataFormatString="{0:MM/dd/yy}" HeaderText="FECHA" SortExpression="FECHA_RADICADO" >
                                            <ItemStyle Width="80px" Wrap="False" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" SortExpression="TIPO" >
                                                 <ItemStyle Width="80px" Wrap="True" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="NOTA" HeaderText="NOTA" SortExpression="NOTA" >

                                                <ItemStyle Width="400px" Wrap="True" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FACTURA" DataFormatString="{0:c}" HtmlEncode="False" HeaderText="FACTURA" SortExpression="FACTURA" >
                                                
                                            </asp:BoundField>

                                            <asp:BoundField DataField="VALOR_NETO" DataFormatString="{0:c}" HtmlEncode="False" HeaderText="VR NETO" SortExpression="VALOR_NETO" ReadOnly="True" >
                                               
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEDUCCIONES" DataFormatString="{0:c}" HtmlEncode="False" HeaderText="DEDUCCIONES" SortExpression="DEDUCCIONES" ReadOnly="True" >
                                                
                                            </asp:BoundField>
                                            
                                            
                                            
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" BorderWidth="1px" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />


                                    </asp:GridView>
                                         <asp:SqlDataSource ID="SqlDataSourceCuentasAnt" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SP_CUENTAS_CONTRATISTA" SelectCommandType="StoredProcedure">
                                             <SelectParameters>
                                                 <asp:SessionParameter DefaultValue="" Name="NUM_DOCUMENTO" SessionField="DOCUMENTO_CONSULTAR" Type="String" />
                                             </SelectParameters>
                                         </asp:SqlDataSource>
                                         <asp:SqlDataSource ID="SqlDataSource" runat="server"></asp:SqlDataSource>
                                         </div>
                                </asp:Panel><br />

                            <table border="0" style="width:650px;" >
                                <tr>
                                    <td class="auto-style36">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td bgcolor="#009933" class="auto-style18">&nbsp;</td>
                                    <td bgcolor="#009933" class="auto-style18">&nbsp;</td>
                                    <td bgcolor="#009933" class="auto-style18">SUBTOTAL</td>
                                    <td bgcolor="#009933" class="auto-style18">VALOR IVA</td>
                                    <td bgcolor="#009933" class="auto-style18">&nbsp;</td>
                                    <td bgcolor="#009933" class="auto-style18">TOTAL</td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid black;height:30px;" class="auto-style36">
                                        &nbsp;</td>
                                    <td style="border: 1px solid black;height:30px;" class="text-center">
                                        &nbsp;</td>
                                    <td style="border: 1px solid black;height:30px;" class="text-center">
                                        <asp:Label ID="LabelSubTotal" runat="server" Font-Size="Large"></asp:Label>
                                    </td>
                                    <td class="text-center" style="border: 1px solid black;height:30px;">
                                        <asp:Label ID="LabelValorIVA" runat="server" Font-Size="Large"></asp:Label>
                                    </td>
                                    <td class="text-center" style="border: 1px solid black;height:30px;">&nbsp;</td>
                                    <td class="text-center" style="border: 1px solid black;height:30px;">
                                        <asp:Label ID="LabelTotal" runat="server" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style36" style="height:40px;">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td >Base:</td>
                                    <td >
                                        <asp:TextBox ID="TextBoxValorBaseReteICA" Width="150px" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                    <td >Rete ICA (Por mil)</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxReteICA" Width="100px" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server"
                                            TargetControlID="TextBoxReteICA"         
                                            FilterType="Custom, Numbers"
                                            ValidChars="," />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorCalcReteICA" Width="150px" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td >
                                        Base:</td>
                                    <td >
                                        <asp:TextBox ID="TextBoxValorBaseReteFuente" Width="150px" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                    <td >Rete Fuente (Por ciento)</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxReteFuente" Width="100px" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="TextBoxReteFuente"         
                                            FilterType="Custom, Numbers"
                                            ValidChars="," />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorCalcReteFuente" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td >
                                        Base:</td>
                                    <td >
                                        <asp:TextBox ID="TextBoxValorBaseReteIVA" Width="150px" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                    <td >Rete IVA (Por ciento)</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxReteIVA" runat="server" Width="100px" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            TargetControlID="TextBoxReteIVA"         
                                            FilterType="Custom, Numbers"
                                            ValidChars="," />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorCalcReteIVA" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td colspan="6" bgcolor="#C0C0C0">Otros descuentos</td>
                                   
                                </tr>
                                <tr style="height:30px;">
                                    <td>Descripcion:</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TextBoxObservaciones" runat="server" TextMode="MultiLine" Height="58px" Width="372px"></asp:TextBox>
                                    </td>
                                    
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>Valor:</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorDescuentos" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>Total deducciones:</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorTotalDeducciones" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>Valor a pagar:</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxValorPagar" runat="server" AutoPostBack="True" CssClass="money form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr style="height:30px;">
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr style="height:30px;">
                                    <td>Observaciones:</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TextBoxObservacionesGenerales" runat="server" Height="58px" TextMode="MultiLine" Width="497px"></asp:TextBox>
                                    </td>
                                    
                                    <td>&nbsp;</td>
                                </tr>
                                
                            </table>
                                </fieldset>
                        </td>
                    </tr>



                    <tr>
                        <td class="auto-style30">
                            &nbsp;</td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            &nbsp;</td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            <div class="form-group">
                            &nbsp;</div>
            
                        </td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        
                        <td class="auto-style33">&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td >
                             &nbsp;</td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>

                        <td class="auto-style33">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                        <td class="auto-style33">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>

                        <td class="auto-style33">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="auto-style30">
                             &nbsp;</td>
                       
                        <td class="auto-style33">&nbsp;</td>
                       
                    </tr>
                    </table>

            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" CssClass="btn-success btn-lg" runat="server" Text="Registrar" OnClick="ButtonGuardar_Click"  />
                
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
      </ContentTemplate>
   </asp:UpdatePanel>
   </asp:Content>
