<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_ResumenCuenta.ascx.cs" Inherits="UserControls_WUC_ResumenCuenta" %>
<div class="panel panel-primary">
      <div class="panel-heading">Informací&oacute;n de la cuenta</div>
      <div class="panel-body">
                <table  class="table table-striped" style="width:65%;" border="0">
                    
                    <tr>
                        <td style="width:180px;text-align:right;" >
                          <strong>  Tipo Radicaci&oacuten:</strong></td>
                        <td >
                            <asp:Label ID="LabelTipoDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:180px;text-align:right;" >
                            <strong>Numero Documento:</strong></td>
                        <td >
                            <asp:Label ID="LabelNumDocumento" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:180px;text-align:right;" >
                            <strong>Nombre beneficiario:</strong></td>
                        <td  >
                            <asp:Label ID="LabelNombreBeneficiario" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  style="width:180px;text-align:right;" >
                            <strong>Valor Factura:</strong></td>
                        <td >
                            <asp:Label ID="LabelValorFactura" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:150px;text-align:right;">
                            <strong>Numero pago:</strong></td>
                        <td >
                            <asp:Label ID="LabelNumPago" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:180px;text-align:right;" >
                            <strong>Fecha radicado:</strong></td>
                        <td class="auto-style11">
                            <asp:Label ID="LabelFechaRadicado" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:180px;text-align:right;" >
                            <strong>Asignado:</strong></td>
                        <td >
                            <asp:Label ID="LabelAsignadoA" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </div>
    </div>
