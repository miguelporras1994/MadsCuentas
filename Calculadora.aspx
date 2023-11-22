<%@ Page Language="C#" UICulture="es" Culture="es-CO" AutoEventWireup="true" CodeFile="Calculadora.aspx.cs" Inherits="Calculadora"  %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
		   .auto-style39 {
               width: 642px;
               height: 17px;
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

   
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   




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
                &nbsp;</td>
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
                                 <br />
                                   <asp:Panel runat="server">
                                     <div style ="height:223px; width:851px; overflow:auto;background-image:url('images/cabecera_calculadora_2.jpg')" >
                                         </div>
                                </asp:Panel><br />

                            <table border="0" style="width:868px;" >
                                
                                <tr>
                                    <td class="auto-style49" style="border: 1px solid black;">
                                         <div class="form-group">
                            <br /><span class="glyphicon glyphicon-usd"></span>
                            <label for="Valor">Valor:</label>
                            <asp:TextBox ID="TextBoxValorFactura" CssClass="money form-control" style="width:150px;" runat="server"  ReadOnly="False" ></asp:TextBox>
                            </div>

                                        &nbsp;</td>
                                    <td  style="border: 1px solid black;" class="auto-style47">
                                        <div class="form-group">
                            <label for="Riesgo Laboral">Riesgo Laboral:<a href="https://www.positiva.gov.co/arl/paginas/default.aspx" target="_blank"><img src="images/Help.png" height="28px" width="28px" border="0" /></a> 
                                            </label>
                                            <br />
                            <asp:DropDownList ID="DropDownListRiesgoLaboral" CssClass="form-control" runat="server" DataSourceID="SqlDataSourceRiesgoLaboral" DataTextField="NOMBRE" DataValueField="ID_RIESGO">
                            </asp:DropDownList>
                                 <asp:SqlDataSource ID="SqlDataSourceRiesgoLaboral" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [RIESGOS_LABORALES] WHERE ([ACTIVO] = @ACTIVO)">
                                     <SelectParameters>
                                         <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                     </SelectParameters>
                                 </asp:SqlDataSource>
                            </div>
                                        </div>
                                    </td>
                                    <td class="auto-style55" style="border: 1px solid black;">
                                        Pensionado:<asp:CheckBox ID="CheckBoxPensionado" runat="server" />
                                    </td>
                                    <td class="auto-style56">
                                        <asp:Button ID="ButtonRecalcular" runat="server" CausesValidation="False" CssClass="btn-success btn-lg" OnClick="ButtonRecalcular_Click" Text="Calcular" />
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#0033CC" class="auto-style48">Valor TOTAL</td>
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
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="border: 1px solid black;text-align: center;" class="auto-style52" >
                                        <asp:Label ID="LabelSalud" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;" class="auto-style43">
                                        <asp:Label ID="LabelPension" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="border: 1px solid black;height:30px;" class="text-center">
                                        <asp:Label ID="LabelARL" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style53">&nbsp;</td>
                                    <td class="auto-style45">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="auto-style57">
                                        &nbsp;</td>
                                </tr>
                               
                                
                                
                                <tr>
                                    <td colspan="4">

                                        &nbsp;</td>
                                    
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
                        <td class="auto-style30">
                            
           

                           
                
            
               
                
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
                        <td class="auto-style30">
                             &nbsp;</td>
                       
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
    </form>
</body>
</html>
