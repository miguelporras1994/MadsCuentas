<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnularCuenta.aspx.cs" Inherits="AnularCuenta" MasterPageFile="~/MasterPage.master" %>

<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style8 {
               width: 175px;
           }
		   .auto-style9 {
               width: 175px;
               height: 28px;
           }
           .auto-style10 {
               width: 192px;
               height: 28px;
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="titulo1">
                CUENTA
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                 <uc1:WUC_ResumenCuenta ID="WUC_ResumenCuenta1" runat="server" />

            </td>
        </tr>
        <tr>
            <td class="style2">
                 <div class="panel panel-primary">
                  <div class="panel-heading">Dividir Pago</div>
                  <div class="panel-body">
                <table style="width:60%;">
                    <tr>
                        <td class="auto-style9">
                            &nbsp;</td>
                        <td class="auto-style10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            Observaciones*:</td>
                        <td class="auto-style7">


                            <asp:TextBox ID="TextBoxObservaciones" Columns="3" runat="server" Height="42px" TextMode="MultiLine" Width="292px"></asp:TextBox>
                
            
               
                
            <asp:RequiredFieldValidator ID="RFV22" runat="server" 
                ControlToValidate="TextBoxObservaciones" Display="None" 
                ErrorMessage="Por favor especifique el motivo de la deovolucion" 
                SetFocusOnError="True" ></asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender ID="RFV22_ValidatorCalloutExtender" 
                runat="server" TargetControlID="RFV22">            </ajaxToolkit:ValidatorCalloutExtender>        
                        </td>
                    </tr>
                    </table>
                      </div></div>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn-success btn-lg" Text="Registrar Anulación" OnClick="ButtonGuardar_Click" />
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
