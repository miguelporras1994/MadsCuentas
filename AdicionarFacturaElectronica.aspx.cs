using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdicionarFacturaElectronica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
            Response.Redirect("Login.aspx");

        //repeater.DataSource = Reporte.ReporteGeneral();
        //repeater.DataBind();
        //GridView1.DataSource = Reporte.ReporteFacturaElectronica(TextBoxID.Text, TextBoxNumeroDoc.Text);
        //GridView1.DataBind();
    }

    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {

        GridView1.DataSource = Reporte.ReporteFacturaElectronica(TextBoxID.Text, TextBoxNumeroDoc.Text);
        GridView1.DataBind();


        /*
        this.GridView1.DataSource = null;
        GridView1.DataSource = Reporte.ReporteGeneral(Utiles.validarNumeroToInt(DropDownListAno.Text), Utiles.validarNumeroToInt(DropDownListEntidad.Text), TextBoxNumeroDoc.Text, TextBoxNombre.Text, TextBoxCuentaPorPagar.Text, TextBoxCorreo.Text, TextBoxOrdenPago.Text, Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text), TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text);
        GridView1.DataBind();
        */

    }


    protected void gridViewMaster_PreRender(object sender, EventArgs e)
    {

        Usuarios usuario = (Usuarios)Session["usuario"];

        if (usuario.Perfil == "Reportes")
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hl = (HyperLink)row.Cells[9].Controls[0]; // 5 is the hyperlink column index
                    HyperLink hl2 = (HyperLink)row.Cells[10].Controls[0]; // 5 is the hyperlink column index

                    hl.Enabled = false;
                    hl2.Enabled = false;
                    hl.Visible = false;
                    hl2.Visible = false;


                }
            }
        }
    }




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
    }
}