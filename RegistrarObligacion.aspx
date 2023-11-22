<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrarObligacion.aspx.cs" Inherits="RegistrarObligacion" MasterPageFile="~/MasterPage.master" %>



<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>



<%@ Register src="UserControls/WUC_Adjuntos.ascx" tagname="WUC_Adjuntos" tagprefix="uc2" %>



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
        .auto-style4 {
            width: 177px;
        }
        .auto-style7 {
            width: 192px;
        }
        </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style8 {
               width: 175px;
           }
		   .auto-style11 {
               width: 192px;
               font-weight: normal;
           }
		   .auto-style13 {
               width: 175px;
               text-align: right;
           }
           .auto-style14 {
               width: 192px;
               text-align: left;
           }
		</style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>
    

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
            <td class="style2">
                 </td>
        </tr>
        <tr>
            <td class="titulo1">
                Registrar cuenta por pagar</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                
                <uc1:WUC_ResumenCuenta ID="WUC_ResumenCuenta1" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td class="style2">
                            





                <uc2:WUC_Adjuntos ID="WUC_Adjuntos1" runat="server" />





            </td>
        </tr>
       
        <tr>
            

            <td >
                <div class="panel panel-primary">
<div class="panel-heading">Obligacion</div>
      <div class="panel-body">
                <div class="well well-sm">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style13">
                           </td>
                        <td >
                            <label for="Cuenta por pagar">Obligacion*:</label>
                            <asp:TextBox CssClass="form-control" ID="TextBoxObligacion" Width="150" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxObligacion_FilteredTextBoxExtender" 
                    runat="server" FilterType="Numbers" TargetControlID="TextBoxObligacion"/>
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV20" runat="server" 
                ControlToValidate="TextBoxObligacion" Display="None" 
                ErrorMessage="Por favor ingrese el numero de obligacion" 
                SetFocusOnError="True" ></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV20_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV20">            </ajaxToolkit:ValidatorCalloutExtender>        
                        </td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style14">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            &nbsp;</td>
                        <td class="auto-style7">


                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                    </tr>
                    
                    </table>
                     </div>
                    </div>
                    </div>
                </td>
          
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn-success btn-lg" Text="Registrar" OnClick="ButtonGuardar_Click" />
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

   </asp:Content>
