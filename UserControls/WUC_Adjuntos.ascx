<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Adjuntos.ascx.cs" Inherits="UserControls_WUC_Adjuntos" %>

<div class="panel panel-primary">
<div class="panel-heading">Adjuntos</div>
      <div class="panel-body">
<asp:GridView ID="GridViewAdjuntos" EmptyDataText="No hay adjuntos" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSourceAdjuntos" EnableModelValidation="True" GridLines="Vertical">
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
          </div>
    </div>