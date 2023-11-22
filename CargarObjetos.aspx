<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargarObjetos.aspx.cs" EnableEventValidation="false" Inherits="CargarObjetos" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    

<link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
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

    <style type="text/css">
     .hidden
     {
         display:none;
     }
    </style>
    
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
      .style3
    {
          width: 201px;
      }
      .style5
      {
          width: 888px;
      }
      .style6
      {
          width: 5px;
      }
      .style7
      {
          width: 33px;
      }
      .style9
      {
          width: 234px;
      }
      .style10
      {
          width: 148px;
      }
  </style>
  
    <link href="css/Mensajes.css" rel="stylesheet" />
   
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

    
    <table>
     <tr>
    <td>
    
    
    
                        <asp:Literal ID="LiteralMenu" runat="server"></asp:Literal>
                        </td>
    </tr>
     <tr>
    <td>
    
    
    
        &nbsp;</td>
    </tr>
     <tr>
    <td class="titulo1">
    
    
    
        Ingresar Registros</td>
    </tr>
    <tr>
    <td>
    
    <fieldset><legend>Datos Generales</legend>
    <table width="888" align="center" class="style5" >
      <tr>
        <td class="style6"  >&nbsp;</td>
        <td class="style3" align="right"   >
            &nbsp;</td>
        <td class="style7"  >
            &nbsp;</td>
        <td class="style10"  >
                                &nbsp;</td>
        <td class="style9"    >
            &nbsp;</td>
    </tr>
      <tr>
        <td class="style6"  >&nbsp;</td>
        <td class="style3"   >
            &nbsp;</td>
        <td class="style7"  >
            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="1"></asp:Label>
                                                        </td>
        <td class="style10"  >Seleccionar Archivo:</td>
        <td class="style9"    >
            <asp:FileUpload ID="FileUpload1" runat="server" />
          </td>
    </tr>
      <tr>
        <td class="style6"  >&nbsp;</td>
        <td class="style3"   >
            &nbsp;</td>
        <td class="style7"  >
            &nbsp;</td>
        <td class="style10"  >Entidad:</td>
        <td class="style9"    >
            <asp:DropDownList ID="DropDownListEntidad" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD">
                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            <asp:RangeValidator ID="RangeValidator19" runat="server" ControlToValidate="DropDownListEntidad" Display="None" ErrorMessage="Por favor seleccione la entidad" MaximumValue="99999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                            <ajaxToolkit:validatorcalloutextender ID="RangeValidator19_validatorcalloutextender" 
                runat="server" TargetControlID="RangeValidator19">            </ajaxToolkit:validatorcalloutextender>   
            </td>
    </tr>
    <tr>
        <td class="style6" >&nbsp;</td>
        <td  colspan="3">&nbsp;      
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
      <td class="style9">&nbsp;      </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td  colspan="4">
            <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
        </td>
      
    </tr>
    <tr>
        <td class="style6" >&nbsp;</td>
        <td  colspan="4">
            <asp:GridView AutoGenerateColumns ="False" 
                 ID="GridView1"
                 runat="server" 
                 BackColor="White" 
                 BorderColor="#E7E7FF" BorderStyle="None"
                 OnRowDataBound ="GridView1_RowDataBound"
                 BorderWidth="1px" CellPadding="3" 
                 EnableModelValidation="True" 
                 GridLines="Horizontal">

                 <AlternatingRowStyle BackColor="#F7F7F7" />
                 <Columns >
                     <asp:BoundField  DataField="RP" HeaderText="RP" Visible="true"  >
                     </asp:BoundField>
                     <asp:BoundField  DataField="OBJETO" HeaderText="OBJETO" Visible="true"  >                
                     </asp:BoundField>
                     
                 </Columns>

                 <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                 <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                 <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                 <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                 <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

            </asp:GridView>
        </td>
     
    </tr>
        </table>
    </fieldset>
    
    </td>
    </tr>
    <tr>
    <td>
    
    
    
                                <div align="center">
                                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="2"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Cargar Informacion" 
                onclick="Button1_Click" /> 
            
        </div></td>
    </tr>
    <tr>
    <td>
    
    <div align="center">
    
            <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="3"></asp:Label>
    
            <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar Informacion" onclick="ButtonGuardar_Click" 
                 /> 
            </div>
        </td>
    </tr>
    <tr>
    <td>
    
    
    
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                      
                            </td>
    </tr>
    <tr>
    <td>
    
    
    
                                &nbsp;</td>
    </tr>
    <tr>
    <td>
    
    
    
                                &nbsp;</td>
    </tr>
    </table>
    
    
         <div align="center">
    
    </div>
        
    
        <br />
        
    </div>
    
 </asp:Content>
