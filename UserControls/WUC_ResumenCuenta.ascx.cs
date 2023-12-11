using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class UserControls_WUC_ResumenCuenta : System.Web.UI.UserControl
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


                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", ((decimal)cuenta.ValorFactura + (decimal)cuenta.ValorIVA)) + "  (" + String.Format("{0:C}", ((decimal)cuenta.ValorFactura)) + " + IVA " + String.Format("{0:C}", ((decimal)cuenta.ValorIVA)) + ")";
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                //LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                //LabelNumObligacion.Text = cuenta.NumeroObligacion;
                LabelAsignadoA.Text = cuenta.AsignadoA;

                //LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();

            }
        }
    }
}