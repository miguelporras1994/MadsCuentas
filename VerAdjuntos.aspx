<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerAdjuntos.aspx.cs" Inherits="VerAdjuntos"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="estilo.css" rel="stylesheet" type="text/css" />
    <link href="css/Mensajes.css" rel="stylesheet" />
    <link href="calendario.css" rel="stylesheet" type="text/css" />
     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    
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
            width: 228px;
        }
        </style>
     
       <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style9 {
               width: 642px;
               height: 17px;
           }
		   .auto-style10 {
               width: 187px;
               text-align: right;
           }
		   .auto-style11 {
               height: 17px;
           }
		   .auto-style12 {
               width: 642px;
               height: 37px;
           }
		</style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>
    
    </head>
<body>
    
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width:60%;" align="center">
        <tr>
            <td><center>
                &nbsp;</center>
            </td>
        </tr>
        <tr>
            <td class="titulo1" align="center">
                Adjuntos</td>
        </tr>
        <tr>
            <td class="style2">
                            <asp:GridView ID="GridViewAdjuntos" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceAdjuntos" EnableModelValidation="True" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Columns>
               
                <asp:HyperLinkField DataNavigateUrlFields="ARCHIVO" Target="_blank" DataNavigateUrlFormatString="adj_cuentas/{0}" Text="Ver" />

                <asp:BoundField DataField="ARCHIVO" HeaderText="ARCHIVO" />


            </Columns>
        </asp:GridView>





        <asp:SqlDataSource ID="SqlDataSourceAdjuntos" runat="server"></asp:SqlDataSource>

            </td>
        </tr>
        <tr>
            <td class="auto-style12">

            </td>
        </tr>
        </table>
 </form>
</body>
</html>
