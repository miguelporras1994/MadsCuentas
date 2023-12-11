 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formularios.aspx.cs" EnableEventValidation="false" Inherits="Formularios" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    

  <script src='js/jquery1.4.4.js' type='text/javascript'></script>

  <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />
 
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 
    
    <style type="text/css" title="currentStyle">
			@import "js/DataTables-1.7.6/media/css/demo_page.css";
			@import "js/DataTables-1.7.6/media/css/demo_table.css";
		</style>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {

		        $('#example').dataTable();

		    });


		</script>

    
    <link rel="stylesheet" href="calendario.css" type="text/css"/>
    <link rel="stylesheet" href="estilo.css" type="text/css"/>
    <link rel="stylesheet" href="css/default.css" type="text/css"/>
  
  <style type="text/css">
  .texthidden {display:inline}.show {display:block}

strong {font-weight:bold;}
.Estilo5 {
	font-size: 10px;
	font-weight: bold;
}
.Estilo6 {font-size: 10px}
  .Estilo7 {font-size: 9px; font-weight: bold; }
      .style15
      {
          width: 968px;
      }
      .style17
      {
          width: 104px;
      }
    </style>
  
    
   
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
   <div style="position: relative; top: -51px; left: 148px; width: 770px; height: 29px;">
       <asp:Literal ID="LiteraMenuArriba" runat="server"></asp:Literal>
		    <!--<a href="ListadoEmpleados.aspx" border='0' ><img style="margin-right: 5px" src="images/menu/Empleados_FC.png" width="97" height="31"  border='0' /></a><a href="CatalogoHerramientas.aspx" border='0' ><img style="margin-right: 5px" src="images/menu/Herramientas_FC.png" width="97" height="31" border='0' /></a><a href="ListadoResguardos.aspx" border='0' ><img style="margin-right: 5px" src="images/menu/Resguardos_FC.png" width="97" height="31" border='0' /></a><a href="Devoluciones.aspx" border='0'><img style="margin-right: 5px" src="images/menu/Devoluciones_FC.png" width="97" height="31" border='0' /></a><a href="MovimientosAlmacen.aspx" border='0'><img style="margin-right: 5px" src="images/menu/MovimientosAlmacen_FC.png" width="97" height="31" border='0' /></a><a href="HistorialHerramientas.aspx" border='0'><img style="margin-right: 5px" src="images/menu/Historiales_FC.png" width="97" height="31" border='0' /></a><a href="ingresarItemSite.aspx" border='0'><img style="margin-right: 5px" src="images/menu/Administrar_FC.png" width="97" height="31" border='0'  /></a>-->
             </div>
      
   
   
   <div align="center" >


                <img alt="" src="images/BANNER_FINANZAS.jpg" />

    </div>

    
    
    
  
    
 </asp:Content>
