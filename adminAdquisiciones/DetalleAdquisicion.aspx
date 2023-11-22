<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetalleAdquisicion.aspx.cs" Inherits="DetalleAdquisicion"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.::MADS::.</title>



    <link href="/estilo.css" rel="stylesheet" type="text/css" />
    <link href="/css/Mensajes.css" rel="stylesheet" />
    <link href="/calendario.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/thickbox.css" type="text/css" media="screen" />

     <script src='/js/jquery1.4.4.js' type='text/javascript'></script>
    <script language="javascript" type="text/javascript" src="../js/thickbox.js"></script> 

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
			@import url('/');
			@import "/js/DataTables-1.7.6/media/css/demo_table.css";
		   .auto-style8 {
               width: 175px;
           }
		   .auto-style10 {
               width: 192px;
               height: 28px;
           }
           .auto-style20 {
               font-family: Verdana, Arial, Helvetica, sans-serif;
               font-size: 11px;
               color: #666666;
           }
           .auto-style21 {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 11px;
        color: #666666;
        height: 22px;
    }
           </style>
		<script type="text/javascript" language="javascript" src="/js/DataTables-1.7.6/media/js/jquery.js"></script>
		<script type="text/javascript" language="javascript" src="/js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
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
    <table style="width:100%;" align="center">
        <tr>
            <td >
                
                <table style="width:100%;" __designer:mapid="201" >
                    <tr __designer:mapid="202">
                        <td bgcolor="#CCCCCC" colspan="5" class="auto-style21" align="center" __designer:mapid="203">
                            <asp:Label ID="LabelPanelExistente" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                        
                        
                        
                    </tr>
                    <tr __designer:mapid="205">
                        <td __designer:mapid="206" >Numero de Registro</td>
                        <td __designer:mapid="207" >
                            <asp:TextBox ID="TextBoxNumRegistro" runat="server" ReadOnly="True"></asp:TextBox>
                
            
                
                        </td>
                        <td __designer:mapid="20c">
                            &nbsp;</td>
                        <td __designer:mapid="20d">
                            &nbsp;</td>
                        <td __designer:mapid="20f">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="210">
                        <td class="auto-style7" __designer:mapid="211" >Area</td>
                        <td colspan="3" >
                            <asp:DropDownList ID="DropDownListArea" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="DESCRIPCION" DataValueField="ID_AREA" Width="400px">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        
                        <td class="auto-style7" __designer:mapid="215">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VIATICOS_PRUEBASConnectionString %>" SelectCommand="SELECT [ID_AREA], [DESCRIPCION], [ESTADO] FROM [AREAS] WHERE ([ESTADO] = @ESTADO) ORDER BY [DESCRIPCION]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ESTADO" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </td>
                    </tr>
                    <tr __designer:mapid="216">
                        <td __designer:mapid="217" >Descripción</td>
                        <td colspan="4" __designer:mapid="218">
                            <asp:TextBox ID="TextBoxDescripcion" runat="server" Height="130px" ReadOnly="true" TextMode="MultiLine" Width="654px"></asp:TextBox>
                
            
               
                
                        </td>
                        
                    </tr>
                    <tr __designer:mapid="21a">
                        <td class="auto-style20" __designer:mapid="21b">&nbsp;</td>
                        <td class="auto-style10" __designer:mapid="21c">
                            &nbsp;</td>
                        <td class="auto-style7" __designer:mapid="21d">&nbsp;</td>
                        <td class="auto-style7" __designer:mapid="21e">&nbsp;</td>
                        <td class="auto-style7" __designer:mapid="21f">&nbsp;</td>
                    </tr>
                    <tr __designer:mapid="220">
                        <td class="auto-style20" __designer:mapid="221">Códigos UNSPSC</td>
                        <td class="auto-style10" __designer:mapid="222">
                            <asp:TextBox ID="TextBoxCodigosUNSPSC" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style7" __designer:mapid="224"></td>
                        <td class="auto-style7" __designer:mapid="225"></td>
                        <td class="auto-style7" __designer:mapid="226"></td>
                    </tr>
                    <tr __designer:mapid="227">
                        <td class="auto-style20" __designer:mapid="228">Fecha estimada de inicio de proceso de selección</td>
                        <td class="auto-style8" __designer:mapid="229">
                            <asp:DropDownList ID="DropDownListMes" runat="server" Enabled="False">
                                <asp:ListItem Value="1">Enero</asp:ListItem>
                                <asp:ListItem Value="2">Febrero</asp:ListItem>
                                <asp:ListItem Value="3">Marzo</asp:ListItem>
                                <asp:ListItem Value="4">Abril</asp:ListItem>
                                <asp:ListItem Value="5">Mayo</asp:ListItem>
                                <asp:ListItem Value="6">Junio</asp:ListItem>
                                <asp:ListItem Value="7">Julio</asp:ListItem>
                                <asp:ListItem Value="8">Agosto</asp:ListItem>
                                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListA_o" runat="server" Enabled="False">
                            </asp:DropDownList>
                
            
               
                
                        </td>
                        <td __designer:mapid="238">&nbsp;</td>
                        <td __designer:mapid="239">Duración estimada del contrato</td>
                        <td __designer:mapid="23a">
                            <asp:TextBox ID="TextBoxDuracion" runat="server"  Width="65px" Enabled="False"></asp:TextBox>
                
            <ajaxToolkit:FilteredTextBoxExtender
                        ID="TextBoxHHContratistaOnShore_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" TargetControlID="TextBoxDuracion" 
                            FilterType="Numbers">
               </ajaxToolkit:FilteredTextBoxExtender>
                
                            <asp:DropDownList ID="DropDownListDuracion" runat="server" Enabled="True" DataSourceID="SqlDataSource7" DataTextField="NOMBRE" DataValueField="ID_DURACION">
                                <asp:ListItem Selected="True">--Seleccionar--</asp:ListItem>
                                <asp:ListItem>Dias</asp:ListItem>
                                <asp:ListItem>Semanas</asp:ListItem>
                                <asp:ListItem>Meses</asp:ListItem>
                                <asp:ListItem>Años</asp:ListItem>
                            </asp:DropDownList>
                
            
               
                
                            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con_adq %>" SelectCommand="SELECT [ID_DURACION], [NOMBRE] FROM [TIPO_DURACION] WHERE ([ACTIVO] = @ACTIVO)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                
            
               
                
                        </td>
                    </tr>
                    <tr __designer:mapid="243">
                        <td class="auto-style20" __designer:mapid="244">&nbsp;</td>
                        <td class="auto-style8" __designer:mapid="245">
                            &nbsp;</td>
                        <td __designer:mapid="246">&nbsp;</td>
                        <td __designer:mapid="247">&nbsp;</td>
                        <td __designer:mapid="248">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="249">
                        <td class="auto-style20" __designer:mapid="24a">Fuente de los recursos</td>
                        <td class="auto-style8" __designer:mapid="24b">
                            <asp:DropDownList ID="DropDownListFuente0" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource6" DataTextField="NOMBRE" DataValueField="ID_FUENTE" Enabled="False">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con_adq %>" SelectCommand="SELECT [ID_FUENTE], [NOMBRE] FROM [FUENTES_RECURSOS] WHERE ([ACTIVO] = @ACTIVO)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <br __designer:mapid="251" />
                            <br __designer:mapid="252" />
                            Cual:<asp:TextBox ID="TextBoxFuenteRecursos" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td __designer:mapid="254">&nbsp;</td>
                        <td __designer:mapid="255">Modalidad de selección</td>
                        <td __designer:mapid="256">
                            <asp:DropDownList ID="DropDownListModalidadSeleccion" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="NOMBRE" DataValueField="ID_MODALIDAD_SELECCION" Enabled="False">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con_adq %>" SelectCommand="SELECT [NOMBRE], [ID_MODALIDAD_SELECCION] FROM [MODALIDADES_SELECCION] WHERE ([ESTADO] = @ESTADO) ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ESTADO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr __designer:mapid="25c">
                        <td class="auto-style20" __designer:mapid="25d">Valor total estimado</td>
                        <td class="auto-style10" __designer:mapid="25e">
                            <asp:TextBox ID="TextBoxValorEstimado" class="money" runat="server" Enabled="False"></asp:TextBox>
                            
                
            
               
                
                        </td>
                        <td class="auto-style7" __designer:mapid="260"></td>
                        <td class="auto-style7" __designer:mapid="261">Valor estimado en la vigencia actual</td>
                        <td class="auto-style7" __designer:mapid="262">
                            <asp:TextBox ID="TextBoxValorEstimadoVigencia" class="money" runat="server" Enabled="False"></asp:TextBox>
                            
                
            
               
                
                        </td>
                    </tr>
                    <tr __designer:mapid="264">
                        <td class="auto-style20" __designer:mapid="265">¿Se requieren vigencias futuras?</td>
                        <td class="auto-style8" __designer:mapid="266">
                            <asp:CheckBox ID="CheckBoxVigenciasFuturas" runat="server" Enabled="False" />
                        </td>
                        <td __designer:mapid="268">&nbsp;</td>
                        <td __designer:mapid="269">Estado de solicitud de vigencias futuras</td>
                        <td __designer:mapid="26a">
                
            
               
                
                        <span __designer:mapid="26b">
                            <asp:DropDownList ID="DropDownListEstado" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="NOMBRE" DataValueField="ID_ESTADO" Enabled="False">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con_adq %>" SelectCommand="SELECT [NOMBRE], [ID_ESTADO] FROM [ESTADO_SOLICITUD] WHERE ([ESTADO] = @ESTADO) ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ESTADO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                
            
               
                
        </span>
                
            
               
                
                        </td>
                    </tr>
                    <tr __designer:mapid="271">
                        <td class="auto-style20" __designer:mapid="272">Datos de contacto del responsable</td>
                        <td colspan="4" __designer:mapid="273">
                            <asp:TextBox ID="TextBoxContactoResponsable" ReadOnly="true" runat="server" Height="61px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                
            
               
                
                        </td>
                        
                    </tr>
                    <tr __designer:mapid="275">
                        <td class="auto-style20" __designer:mapid="276">&nbsp;</td>
                        <td class="auto-style8" __designer:mapid="277">
                            &nbsp;</td>
                        <td __designer:mapid="278">&nbsp;</td>
                        <td __designer:mapid="279">&nbsp;</td>
                        <td __designer:mapid="27a">&nbsp;</td>
                    </tr>
                    </table>
                 
            </td>
        </tr>
        </table>
       </form>
</body>
</html>
