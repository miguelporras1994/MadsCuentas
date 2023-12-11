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

public partial class DetalleCuenta : System.Web.UI.Page
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

                GridViewEventos.DataSource = dt;
                GridViewEventos.DataBind();

                LabelOrdenPago.Text = cuenta.OrdenPago;
                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", ((decimal)cuenta.ValorFactura + (decimal)cuenta.ValorIVA)) + "  (" + String.Format("{0:C}", ((decimal)cuenta.ValorFactura)) + " + IVA " + String.Format("{0:C}", ((decimal)cuenta.ValorIVA)) + ")";
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                LabelNumObligacion.Text = cuenta.NumeroObligacion;
                LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();
                string adjunto = cuenta.obtenerNombreAdjunto();
                //LiteralAdjunto.Text = (adjunto.Trim() != "") ? ("<a href='adj_cuentas/" + adjunto + "'>" + adjunto + "</a>") : "";
                LabelNumFactura.Text = cuenta.NumeroFactura;
                LabelNumRP.Text = cuenta.NumeroRP;
                LabelNumContrato.Text = cuenta.NumeroContrato;

                if (cuenta.Devuelta)
                {
                    Panel1.Visible = true;
                    LOG log = new LOG();
                    int id_log = cuenta.obtenerIDDevolucion();
                    log.ID = id_log;
                    log.obtenerDatos();

                    LabelDevueltaFecha.Text = log.Fecha.ToLongDateString();
                    LabelDevueltaUsuario.Text = log.Usuario;
                    LabelDevueltaObservaciones.Text = log.Descripcion;

                }

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