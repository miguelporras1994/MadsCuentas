<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadicadosAdjuntar.aspx.cs" Inherits="RadicadosAdjuntar" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="estilo.css" rel="stylesheet" type="text/css" />

    <link href="calendario.css" rel="stylesheet" type="text/css" />


     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    
            <style type="text/css">
                .modalPopup
                {
                background-color: #696969;
                filter: alpha(opacity=40);
                opacity: 0.7;
                xindex:-1;
                }
            .auto-style1 {
        text-align: left;
        font-weight: normal;
    }
    .auto-style2 {
        text-align: right;
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
    <br /><br /><br /><br /><br />
    <div align="center">
    


                <table  style="width:49%; "1" border="0">
                    
                    <tr>
                        <td colspan="2" class="titulo1">
                            Datos de la cuenta</td>
                       
                    </tr>
                    
                    <tr>
                        <td class="auto-style2">
                            Orden Pago:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelOrdenPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Tipo Documento:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelTipoDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Numero Documento:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelNumDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Nombre beneficiario:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelNombreBeneficiario" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Valor Factura:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelValorFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Numero pago:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelNumPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Fecha radicado:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelFechaRadicado" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Asignado:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelAsignadoA" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            Observaciones:</td>
                        <td class="auto-style1">
                            <asp:Label ID="LabelObservaciones" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    </table>

    </div>
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
    <br />
    <br />
    <br />
    <br />

            <asp:FileUpload ID="fileUploadImage" runat="server"></asp:FileUpload>
            <asp:Button ID="btnUpload" runat="server" Text="Adjuntar" OnClick="btnUpload_Click" />
        <br />
        <br />
        <table border="0">
            <tr>
                <td>
                            <asp:GridView ID="GridViewAdjuntos" DataKeyNames="ID_ADJUNTO,ARCHIVO" AutoGenerateColumns="False" 
                               OnRowDataBound="GridViewAdjuntos_RowDataBound"
                                OnRowDeleting="GridViewAdjuntos_RowDeleting"
                                runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" DataSourceID="SqlDataSourceAdjuntos" 
                                EnableModelValidation="True" GridLines="Vertical" AutoGenerateDeleteButton="True">
            
                                <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <Columns>
               
                <asp:HyperLinkField DataNavigateUrlFields="ARCHIVO" Target="_blank" DataNavigateUrlFormatString="adj_cuentas/{0}" Text="Ver" />
                 <asp:BoundField DataField="ID_ADJUNTO" Visible="false" />
                <asp:BoundField DataField="ARCHIVO" HeaderText="ARCHIVO" />

                
            </Columns>
        </asp:GridView>

                </td>
            </tr>

        </table>





        <asp:SqlDataSource ID="SqlDataSourceAdjuntos" DeleteCommand="DELETE FROM ADJUNTOS_CUENTAS WHERE ID_ADJUNTO = @ID_ADJUNTO" runat="server" ConnectionString="<%$ ConnectionStrings:DBViaticos %>" >
     </asp:SqlDataSource>

 

     </div>
    <br /><br /><br /><br /><br />

</asp:Content>
