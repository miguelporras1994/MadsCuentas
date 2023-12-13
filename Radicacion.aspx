<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Radicacion.aspx.cs" Inherits="Radicacion" MasterPageFile="~/MasterPage.master" %>



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
               width: 176px;
           }
		   .auto-style30 {
               width: 135px;
           }
           .auto-style31 {
               width: 135px;
               height: 20px;
           }
           .auto-style32 {
               width: 123px;
               height: 20px;
           }
		   .auto-style34 {
               width: 123px;
           }
		   .auto-style35 {
               width: 133px;
               height: 20px;
           }
           .auto-style39 {
               width: 133px;
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
            <td class="style2">
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                <asp:Label ID="LabelTitulo" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td class="style2">
                <table align="center">
                    <tr>
                        <td class="auto-style31">
                            <asp:Label ID="LabelCuentaPorPagar" runat="server"></asp:Label>
                            </td>
                        <td class="auto-style35">
                            &nbsp;</td>
                        <td class="auto-style32">
                            <asp:Literal ID="LiteralAlerta" runat="server"></asp:Literal>
                        </td>
                        <td class="auto-style13" rowspan="11">
                            &nbsp;</td>
                    </tr>



                    <tr>
                        <td class="auto-style30">
                            
                            &nbsp;</td>
                       
                        <td class="auto-style39">

                           

                            &nbsp;</td>
                       
                        <td class="auto-style34"></td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="TipoSolicitud">Tipo Solicitud:*</label>
                            <asp:DropDownList ID="DropDownListTipoDocumento" runat="server" class="form-control" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="NOMBRE" DataValueField="ID_TIPO_DOC">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            </div>

                            <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="DropDownListTipoDocumento" Display="None" ErrorMessage="Por favor seleccione el tipo de documento" MaximumValue="99999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                            <ajaxToolkit:validatorcalloutextender ID="Validatorcalloutextender1" 
                runat="server" TargetControlID="RangeValidator18">            </ajaxToolkit:validatorcalloutextender>   
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [ID_TIPO_DOC], [NOMBRE], [ACTIVO] FROM [TIPO_DOCUMENTO] WHERE ([ACTIVO] = @ACTIVO) ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </td>
                       
                        <td class="auto-style39">&nbsp;</td>
                       
                        <td class="auto-style34">
                             <div class="form-group">
                            <label for="TipoSolicitud">Dependencia:*</label>
                            <asp:DropDownList ID="DropDownListDependencia" runat="server" class="form-control" Width="300px" AppendDataBoundItems="True" DataSourceID="SqlDataSourceDependencias" DataTextField="DESCRIPCION" DataValueField="ID_AREA">
                                <asp:ListItem Value="0">N / A</asp:ListItem>
                            </asp:DropDownList>
                                 <asp:RangeValidator ID="RangeValidator20" runat="server" ControlToValidate="DropDownListDependencia" Display="None" ErrorMessage="Por favor seleccione dependencia" MaximumValue="99999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                                 <ajaxToolkit:ValidatorCalloutExtender ID="RangeValidator20_validatorcalloutextender" runat="server" TargetControlID="RangeValidator20">
                                 </ajaxToolkit:ValidatorCalloutExtender>
                                 </div>
                            <asp:SqlDataSource ID="SqlDataSourceDependencias" runat="server" ConnectionString="<%$ ConnectionStrings:DBViaticos %>" SelectCommand="SELECT [ID_AREA], [DESCRIPCION] FROM [AREAS] WHERE ([ESTADO] = @ESTADO)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ESTADO" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">

                            <div class="form-group">
                            <label for="TipoPersona">Tipo Persona:*</label>
                             <asp:DropDownList ID="DropDownListTipoPersona" runat="server" class="form-control" AppendDataBoundItems="True" DataSourceID="SqlDataSourceTipoPersona" DataTextField="DESCRIPCION" DataValueField="ID_TIPO_PERSONA">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                
                            </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceTipoPersona" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [TIPO_PERSONA]"></asp:SqlDataSource>
                                <asp:RangeValidator ID="RangeValidator19" runat="server" ControlToValidate="DropDownListTipoPersona" Display="None" ErrorMessage="Por favor seleccione el tipo de persona" MaximumValue="99999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="RangeValidator19_validatorcalloutextender" runat="server" TargetControlID="RangeValidator19">
                                </ajaxToolkit:ValidatorCalloutExtender>
                            </div>

                        </td>
                        <td class="auto-style39">&nbsp;</td>
                        <td class="auto-style34">&nbsp;</td>
                    </tr>
                    <tr>

                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="NumeroDocumento">
                                Numero Documento:*</label>
                                <asp:TextBox ID="TextBoxNumeroDocumento" runat="server" AutoPostBack="True" class="form-control"></asp:TextBox>
                            </div>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxNumeroDocumento_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBoxNumeroDocumento">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RFV18" runat="server" ControlToValidate="TextBoxNumeroDocumento" Display="None" ErrorMessage="Por favor ingrese el numero de documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="RFV18_ValidatorCalloutExtender" runat="server" TargetControlID="RFV18">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </td>

                        <td class="auto-style39">

                            &nbsp;</td>

                        <td class="auto-style30">
                            
                            <div class="form-group">
                            <span class="glyphicon glyphicon-user"></span>
                            <label for="NombreBeneficiario">Nombre Beneficiario:*</label>
                            <asp:TextBox ID="TextBoxNombres" CssClass="form-control" runat="server" Width="277px"></asp:TextBox>
                </div>
            
               
                
            <asp:RequiredFieldValidator ID="RFV2" runat="server" 
                ControlToValidate="TextBoxNombres" Display="None" 
                ErrorMessage="Por favor ingrese Nombres" 
                SetFocusOnError="True" ></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV2_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV2">            </ajaxToolkit:ValidatorCalloutExtender>        

                            </td>
                        
                        
                        
                        
                        
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <span class="glyphicon glyphicon-envelope"></span>
                            <label for="Correo Electronico">Correo Electronico: *</label>
                            <asp:TextBox ID="TextBoxCorreo" class="form-control" runat="server" Width="270px"></asp:TextBox>
                            </div>
            
               
                
            <asp:RequiredFieldValidator ID="RFV21" runat="server" 
                ControlToValidate="TextBoxCorreo" Display="None" 
                ErrorMessage="Por favor ingrese el correo electronico" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV21_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV21">            </ajaxToolkit:ValidatorCalloutExtender>        
                        </td>
                        
                        <td class="auto-style39">

                            &nbsp;</td>
                        
                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="NombreBeneficiario">
                                Numero de contrato:</label>
                                <asp:TextBox ID="TextBoxNumeroContrato" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </td>
                        
                    </tr>
                    <tr>
                        <td >
                             <div class="form-group">
                            <label for="Entidad">Entidad:<asp:DropDownList ID="DropDownListEntidad" runat="server" AppendDataBoundItems="True" CssClass="form-control" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD" Width="180">
                                     <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                 </asp:DropDownList>
                                 </label>
                            <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            </div>
                        </td>
                        <td class="auto-style39">

                             &nbsp;</td>
                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="Riesgo Laboral">
                                Riesgo Laboral:</label>
                                <asp:DropDownList ID="DropDownListRiesgoLaboral" runat="server" AutoPostBack="True" CssClass="form-control" DataSourceID="SqlDataSourceRiesgoLaboral" DataTextField="NOMBRE" DataValueField="ID_RIESGO">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceRiesgoLaboral" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [RIESGOS_LABORALES] WHERE ([ACTIVO] = @ACTIVO)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <span class="glyphicon glyphicon-usd"></span>
                            <label for="Valor">Valor:*</label>
                            <asp:TextBox ID="TextBoxValorFactura" CssClass="money form-control"  runat="server" AutoPostBack="True" ></asp:TextBox>
                            </div>
           

                           
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV19" runat="server" 
                ControlToValidate="TextBoxValorFactura" Display="None" 
                ErrorMessage="Por favor ingrese el valor de la factura" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV19_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV19">            </ajaxToolkit:ValidatorCalloutExtender>        
                
            
               
                
                        </td>

                        <td class="auto-style39">

                            &nbsp;</td>

                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="NombreBeneficiario">
                                Aplica IVA:</label>
                                <asp:CheckBox ID="CheckBoxIVA" runat="server" AutoPostBack="True" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            &nbsp;<asp:Label ID="LabelIVA" runat="server" Text="IVA" Visible="False"></asp:Label>
                                 <asp:TextBox ID="TextBoxValorIVA" CssClass="money form-control" runat="server" AutoPostBack="True"  Visible="False"></asp:TextBox>
                            </div>
                        </td>
                        <td class="auto-style39">

                             &nbsp;</td>
                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="NumeroFactura">
                                Numero de Factura:</label>
                                <asp:TextBox ID="TextBoxNumFactura" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            
            
               
                
                        </td>
                       
                        <td class="auto-style39">&nbsp;</td>
                       
                        <td class="auto-style34">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td class="auto-style30">
                             <div class="form-group">
                            <label for="NumeroRP">Número RP:*</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxNumeroRP" runat="server"></asp:TextBox>
                                 </div>
                
            
               
                
                        </td>

                        <td class="auto-style39">


                             &nbsp;</td>

                        <td class="auto-style34">
                            <div class="form-group">
                                <label for="Numero Pago">
                                Numero Pago:</label>
                                <asp:TextBox ID="TextBoxNumeroPago" runat="server" CssClass="form-control" Width="277px"></asp:TextBox>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style30">
                             
                
            
               
                
                        </td>

                        <td class="auto-style39">


                             &nbsp;</td>

                        <td class="auto-style34">
                            <div class="form-group">
                            <label for="NumeroRP">Código CCP:</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxCodigoCCP" runat="server" Width="377px"></asp:TextBox>
                                 </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            

                        </td>
                       
                        <td class="auto-style39">&nbsp;</td>
                       
                        <td class="auto-style34">&nbsp;</td>
                       
                    </tr>
                    </table>

            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" CssClass="btn-success btn-lg" runat="server" Text="Registrar" OnClick="ButtonGuardar_Click" />
                <asp:Button ID="ButtonEditar" runat="server" CssClass="btn-success btn-lg" OnClick="ButtonEditar_Click" Text="Editar" />
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
