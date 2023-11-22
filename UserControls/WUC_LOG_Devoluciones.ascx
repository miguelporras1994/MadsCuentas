<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_LOG_Devoluciones.ascx.cs" Inherits="UserControls_WUC_LOG_Devoluciones" %>

<div class="panel panel-primary">
      <div class="panel-heading">Historial de devoluciones</div>
      <div class="panel-body">

 <asp:GridView ID="GridViewEventos" EmptyDataText="No hay devoluciones.." runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
           </div>
    </div>