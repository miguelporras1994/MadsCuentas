using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReporteGeneral3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //repeater.DataSource = Reporte.ReporteGeneral();
        //repeater.DataBind();
        GridView1.DataSource = Reporte.ReporteGeneral(DateTime.Now.Year,0,"","", "","","",0,"", "","0");
        GridView1.DataBind();
    }
    protected void ButtonGenerarReporte_Click(object sender, EventArgs e)
    {

    }
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        this.GridView1.DataSource = null;
        GridView1.DataSource = Reporte.ReporteGeneral(Utiles.validarNumeroToInt(DropDownListAno.Text), Utiles.validarNumeroToInt(DropDownListEntidad.Text), TextBoxNumeroDoc.Text, TextBoxNombre.Text, TextBoxCuentaPorPagar.Text, TextBoxCorreo.Text, TextBoxOrdenPago.Text, Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text), TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text,"0");
        GridView1.DataBind();

    }
}