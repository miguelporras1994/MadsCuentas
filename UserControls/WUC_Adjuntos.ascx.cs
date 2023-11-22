using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class UserControls_WUC_Adjuntos : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {




                int id_registro = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                ViewState["id_registro"] = id_registro;
                Cuenta cuenta = new Cuenta(id_registro);


                //LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                //LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                //LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                //LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                //LabelNumPago.Text = cuenta.NumeroPago;
                //LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                ////LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                ////LabelNumObligacion.Text = cuenta.NumeroObligacion;
                //LabelAsignadoA.Text = cuenta.AsignadoA;

                //LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();

                

                //Adjuntos

                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];

                SqlDataSourceAdjuntos.ConnectionString = settings.ConnectionString;
                SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_registro"].ToString();

                GridViewAdjuntos.DataSourceID = "SqlDataSourceAdjuntos";


            }
        }
    }
}