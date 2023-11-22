<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reasignar.aspx.cs" Inherits="Reasignar" MasterPageFile="~/MasterPage.master" %>



<%@ Register src="UserControls/WUC_ResumenCuenta.ascx" tagname="WUC_ResumenCuenta" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
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
        </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style9 {
               width: 175px;
               height: 28px;
           }
           .auto-style10 {
               width: 192px;
               height: 28px;
           }
           .auto-style11 {
               height: 23px;
           }
           .auto-style12 {
               height: 33px;
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
            <td class="auto-style12">
                </td>
        </tr>
        <tr>
            <td class="titulo1">
                Reasignar Cuenta</td>
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
                  <div class="panel-heading">Asignaci&oacute;n</div>
                  <div class="panel-body">
                <table style="width:100%;">
                    <tr>
                        <td >
                            </td>
                        <td >

                            <label for="ASignar a">Asignar a:</label>
                            <asp:DropDownList ID="DropDownListAsignado" CssClass="form-control" Width="250" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="USUARIO">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="CONSULTAR_USUARIOS_RADICACION" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    </table>
                      </div>
                    </div>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <asp:Button ID="ButtonGuardar" CssClass="btn-success btn-lg" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
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
