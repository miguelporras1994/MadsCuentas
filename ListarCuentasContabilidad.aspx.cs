using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OfficeOpenXml;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;
using System.Data.Common;
using System.Text;
using System.Drawing;

public partial class ListarCuentasContabilidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

            if (usuario.Perfil == "Contabilidad")
            {
                try
                {
                    DropDownListAsignado.SelectedValue = nombre_usuario;

                }
                catch { }
            }


        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

        cargarDatosReporte();
    }





    private void cargarDatosReporte()
    {
        try
        {
            GridView1.DataSource = Reporte.ListarCuentasObligacion(Utiles.validarNumeroToInt(DropDownListEntidad.Text),TextBoxNumeroDoc.Text,TextBoxNombre.Text,TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text, Utiles.validarNumeroToInt( TextBoxIDRegistro.Text),DropDownListAsignado.Text,CheckBoxSinObligacion.Checked);
            GridView1.DataBind();
        }
        catch (SqlException ex)
        {
        }

    }


    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
    protected void ButtonBuscar_Click1(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
}