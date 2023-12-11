using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Data;

public partial class VerAdjuntos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {

                int id_registro = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                ViewState["id_registro"] = id_registro;
                Cuenta cuenta = new Cuenta(id_registro);

                DataTable dt = cuenta.consultarLOGEventos();

                //Adjuntos
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];

                //SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_reporte"].ToString();
                //GridViewAdjuntos.DataSource = SqlDataSourceAdjuntos;
                //GridViewAdjuntos.DataSourceID = "GridViewAdjuntos";
                //GridViewAdjuntos.DataBind();

                SqlDataSourceAdjuntos.ConnectionString = settings.ConnectionString;
                SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_registro"].ToString();

                GridViewAdjuntos.DataSourceID = "SqlDataSourceAdjuntos";

            }
        }

    }

}