<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminarCuentaPorPagar.aspx.cs" Inherits="EliminarCuentaPorPagar" MasterPageFile="~/MasterPage.master" %>



<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>

<%@ Register src="UserControls/WUC_Adjuntos.ascx" tagname="WUC_Adjuntos" tagprefix="uc1" %>



<%@ Register src="UserControls/WUC_LOG_Devoluciones.ascx" tagname="WUC_LOG_Devoluciones" tagprefix="uc2" %>



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


    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link href="css/Mensajes.css" rel="stylesheet" />
    <link href="calendario.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 

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
        .auto-style7 {
            width: 192px;
        }
        </style>
     
        <style type="text/css">
            .modalPopup
            {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex:-1;
            }
         </style>

        <%--<script type="text/javascript">
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
         </script>--%>
    

    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>






 <ContentTemplate>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server"></asp:UpdateProgress>
   



    <table style="width:100%;" align="center">
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="titulo1">
                Eliminar Cuenta por Pagar</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <uc1:WUC_ResumenCuenta ID="WUC_ResumenCuenta1" runat="server" />
                 </td>
        </tr>
         <tr>
            <td class="style2">
                <uc1:WUC_Adjuntos ID="WUC_Adjuntos1" runat="server" />
                 </td>
        </tr>
        <tr>
            <td>
                <uc2:WUC_LOG_Devoluciones ID="WUC_LOG_Devoluciones1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <div class="panel panel-primary">
      <div class="panel-heading">Datos de la devoluci&oacute;n</div>
      <div class="panel-body">
                <table style="width:60%;">
                    <tr>
                        <td class="auto-style9">
                           </td>
                        <td class="auto-style10">

                            <label for="Cuenta por pagar">Cuenta por pagar:
                            <asp:Label ID="LabelCuenta" runat="server"></asp:Label>
                            </label>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            </td>
                        <td class="auto-style7">
                            <label for="Observaciones">Observaciones*:</label>

                            <asp:TextBox ID="TextBoxObservaciones" CssClass="form-control" Rows="3" runat="server" Height="42px" TextMode="MultiLine" Width="292px"></asp:TextBox>
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV22" runat="server" 
                ControlToValidate="TextBoxObservaciones" Display="None" 
                ErrorMessage="Por favor especifique el motivo de la deovolucion" 
                SetFocusOnError="True" ></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV22_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV22">            </ajaxToolkit:ValidatorCalloutExtender>        
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            &nbsp;</td>
                        <td class="auto-style7">
                            &nbsp;</td>
                    </tr>
                    </table>
                </div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn-success btn-lg" Text="Eliminar Cuenta por Pagar" OnClick="ButtonGuardar_Click" />
                </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
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

   </asp:Content>
