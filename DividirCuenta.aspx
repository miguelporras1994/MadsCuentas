<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DividirCuenta.aspx.cs" Inherits="DividirCuenta" MasterPageFile="~/MasterPage.master" %>



<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
   
    <link href="estilo.css" rel="stylesheet" type="text/css" />

    <link href="calendario.css" rel="stylesheet" type="text/css" />


     <script type="text/javascript" language="javascript" src="js/json2.js"></script>
     <script type="text/javascript" language="javascript" src="js/jquery-latest.min.js"></script>



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
    
            <style type="text/css">
                .modalPopup
                {
                background-color: #696969;
                filter: alpha(opacity=40);
                opacity: 0.7;
                xindex:-1;
                }
            </style>

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
    <table style="width:1180px;"><tr><td></td></tr><tr><td class="titulo1">Dividir Pago</td></tr><tr><td></td></tr></table>
    <br /><br />
    <uc1:WUC_ResumenCuenta ID="WUC_ResumenCuenta1" runat="server" />
    <br /><br /><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

 <div align="center">

    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
    Por favor espere...<br />
<asp:Image ID="Image1" ImageUrl="images/loadingAnimation.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />

     <div class="panel panel-primary">
      <div class="panel-heading">Dividir Pago</div>
      <div class="panel-body">
     <table style="width: 34%;">
         <tr>
             <td>Numero de pagos:</td>
             <td>
                 <asp:TextBox ID="TextBoxNumPagos" CssClass="form-control" runat="server" Style="position: static" Width="60px"></asp:TextBox>
                 <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxNumPagos_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TextBoxNumPagos">
                 </ajaxToolkit:FilteredTextBoxExtender>
             </td>
             <td>
            <asp:Button ID="ButtonDividir" runat="server" Text="Dividir" CssClass="btn-success btn-lg" OnClick="ButtonDividir_Click" />
             </td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
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
    <br />
    <br />

        <br />
        <br />
        <table border="0">
            <tr>
                <td>
                            <asp:Table ID="Table1" runat="server">
                            </asp:Table>

                </td>
            </tr>

            <tr><td>
                <asp:Button ID="ButtonGuardar" CssClass="btn-success btn-lg" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" 
                TargetControlID="ButtonGuardar" runat="server" 
                
        ConfirmText="Por favor verifique los valores, desea continuar y realizar la division del pago ?">
            </ajaxToolkit:ConfirmButtonExtender>
            </td></tr>

        </table>





     </div>
    <br /><br /><br /><br /><br />

</asp:Content>
