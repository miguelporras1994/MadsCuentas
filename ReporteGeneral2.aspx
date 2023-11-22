<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteGeneral2.aspx.cs" Inherits="ReporteGeneral2" MasterPageFile="~/MasterPage.master" %>

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
    <script  type="text/javascript" src="js/thickbox.js"></script> 
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

    
    <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

    <link href=" https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

	<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>

     


<script>


    function tb_init() {
        $(document).click(function (e) {
            e = e || window.event;
            var el = e.target || e.scrElement || null;
            if (el && el.parentNode && !el.className || !/thickbox/.test(el.className))
                el = el.parentNode;
            if (!el || !el.className || !/thickbox/.test(el.className))
                return;
            var t = el.title || el.name || null;
            var a = el.href || el.alt;
            var g = el.rel || false;
            tb_show(t, a, g);
            el.blur();
            return false;
        });
    };


    $(document).ready(function () {
        $("#ctl00_ContentPlaceHolder1_ButtonBuscar").click(getUserNames());
        
    });


    var getUserNames = function () {

        //alert($("#ctl00_ContentPlaceHolder1_TextBoxNumeroDoc").val());

        $("#example").dataTable({


            "language": {
                "lengthMenu": "Mostrando _MENU_ registros por pagina",
                "zeroRecords": "No se encontraron registros",
                "info": "Mostrando página _PAGE_ de _PAGES_",
                "infoEmpty": "Busqueda sin registros",
                "infoFiltered": "(filtrado de _MAX_ registros)",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                },
                "search": "Busqueda rápida"
            },
            
            "iDisplayLength": 50,
           
            
            "bServerSide": true,
            "bDestroy": true,
            "sAjaxSource": "WebService1.asmx/GetItemsReporteGeneral",
            
            "bDeferRender": true,
            "fnServerParams": function (aoData) {

                aoData.push({
                    "name": "documento", "value": $("#ctl00_ContentPlaceHolder1_TextBoxNumeroDoc").val()
                   
                });

                aoData.push({
                    
                    "name": "nombre", "value": $("#ctl00_ContentPlaceHolder1_TextBoxNombre").val()
                    
                });
                aoData.push({
                   
                    "name": "cuenta_por_pagar", "value": $("#ctl00_ContentPlaceHolder1_TextBoxCuentaPorPagar").val()
                });
                aoData.push({
                    
                    "name": "correo", "value": $("#ctl00_ContentPlaceHolder1_TextBoxCorreo").val()
                });
                aoData.push({
                   
                    "name": "orden_pago", "value": $("#ctl00_ContentPlaceHolder1_TextBoxOrdenPago").val()
                });
                aoData.push({
                    
                    "name": "tipo_solicitud", "value": $("#ctl00_ContentPlaceHolder1_DropDownListTipoDocumento").val()
                });
                aoData.push({
                    
                    "name": "entidad", "value": $("#ctl00_ContentPlaceHolder1_DropDownListEntidad").val()
                });


               
                if ($("#ctl00_ContentPlaceHolder1_CheckBoxSoloDevueltas").is(':checked')) {
                    aoData.push({

                        "name": "devuelta", "value": "SI"
                    });

                } else {
                    aoData.push({

                        "name": "devuelta", "value": "NO"
                    });
                }
               

                

            },
            "fnServerData": function (sSource, aoData, fnCallback) {
                $.ajax({
                    "dataType": 'json',
                    "contentType": "application/json; charset=utf-8",
                    "type": "GET",
                    "url": sSource,
                    "data": aoData,
                    "success":
                                function (msg) {

                                    var json = jQuery.parseJSON(msg.d);
                                    fnCallback(json);
                                    $("#example").show();
                                }
                });
            }
        });
    }
</script>


    <div>
    
        <table >
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset><legend>Filtro de Busqueda</legend>
                    <table style="width: 75%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/excel_icon.png" Width="60px" /><asp:Button ID="ButtonGenerarReporte" runat="server" CssClass="btn-success btn-lg" Text="Descargar Reporte" OnClick="ButtonGenerarReporte_Click" />
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="Devueltas">Devueltas:</label>
                                <asp:CheckBox ID="CheckBoxSoloDevueltas"  runat="server" />
                                </td>
                            <td style="width: 70px"></td>
                            <td>
                                <label for="Correo Electronico">Entidad:</label>
                                <asp:DropDownList ID="DropDownListEntidad" Width="150" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceEntidades" DataTextField="NOMBRE" DataValueField="ID_ENTIDAD">
                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT * FROM [ENTIDADES]"></asp:SqlDataSource>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <label for="Correo Electronico">Numero documento:</label>
                                <asp:TextBox ID="TextBoxNumeroDoc" Width="150" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td>
                                <label for="Correo Electronico">Nombre:</label>
                                <asp:TextBox ID="TextBoxNombre" Width="150" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="Correo Electronico">Cuenta por pagar:</label>
                                <asp:TextBox ID="TextBoxCuentaPorPagar" Width="150" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td>
                                <label for="Correo Electronico">Correo:</label>
                                <asp:TextBox ID="TextBoxCorreo" Width="150" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                            </td>
                            <td style="width: 26px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="Correo Electronico">Orden de Pago:</label>
                                <asp:TextBox ID="TextBoxOrdenPago"  Width="150" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 70px"></td>
                            <td><label for="Correo Electronico">Tipo de Solicitud:</label>
                            <asp:DropDownList ID="DropDownListTipoDocumento" runat="server" Width="150" class="form-control input-sm" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="NOMBRE" DataValueField="ID_TIPO_DOC">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bd_con %>" SelectCommand="SELECT [ID_TIPO_DOC], [NOMBRE], [ACTIVO] FROM [TIPO_DOCUMENTO] WHERE ([ACTIVO] = @ACTIVO) ORDER BY [NOMBRE]">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ACTIVO" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </td>
                            <td style="width: 26px">&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBuscar" runat="server" CssClass="btn-success btn-lg" Text="Buscar" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 70px">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 26px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                   </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
               
                <div style ="height:1200px; width:1310px; overflow:auto;">    

                <table width='80%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
                <thead>
                   <tr class='gradeA'>
                        <th>ID</th>
                        <th>DETALLE</th>
                        <th>BENEFICIARIO</th>
                        <th>DOCUMENTO</th>
                        <th>VALOR FACTURA</th>
                        <th>CTA POR PAGAR</th>
                        <th>REC. TESORERIA</th>
                        <th>ENTIDAD</th>
                        <th>ESTADO</th>
                        <th>DEVUELTA</th>
                        <th>LIQUIDACION</th>
                        <th>DEDUCCIONES</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
                    </div>
                    
                </td>
            </tr>
            <tr>
                <td style="height: 153px">
                </td>
            </tr>
        </table>

           
    
    </div>
</asp:Content>
