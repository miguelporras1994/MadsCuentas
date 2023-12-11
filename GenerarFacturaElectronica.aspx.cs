using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class GenerarFacturaElectronica : System.Web.UI.Page
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

                DataTable dtContrato = Contrato.consultarPorCedula(cuenta.NumeroDocumentoBeneficiaro);
                try
                {
                    LiteralObjeto.Text = dtContrato.Rows[0]["OBJETO"].ToString();
                }catch{}

                string consecutivo_actual = DocumentoFirma.ConsecutivoFacturaActual();
                if (consecutivo_actual != "")
                    LabelConsecutivo.Text = "Consecutivo Actual: " + consecutivo_actual;
                else
                {
                    LabelConsecutivo.Text = "Verifique la sub unidad !";
                    ButtonBuscar.Enabled = false;
                }
                    

                if (cuenta.ConsecutivoFactura.Trim() != "")
                {

                    string path = ConfigurationSettings.AppSettings["ruta_facturas_e"].ToString();

                    HyperLink1.Visible = true;
                    HyperLink1.Text = "Ver Factura";
                    HyperLink1.NavigateUrl = "downloading.aspx?file=" + path + "/DEQ_" + cuenta.ConsecutivoFactura + ".pdf";
                    HyperLink1.Target = "_blank";

                    ButtonBuscar.Enabled = false;
                }

                if (Request.QueryString["formulario"] != null)
                {
                    ViewState["formulario"] = Request.QueryString["formulario"];
                }
                else
                {
                    ViewState["formulario"] = "Formularios.aspx";
                }



            }
            else
            {

                Response.Redirect("Formularios.aspx");
            }
        }
    }

    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        ButtonBuscar.Enabled = false;
        //ButtonBuscar.Attributes.Add("onclick", "javascript:Disable()");

        DocumentoFirma doc = new DocumentoFirma();

        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;
        Cuenta cuenta = new Cuenta(Utiles.validarNumeroToInt(ViewState["id_registro"].ToString()));

        string consecutivo = doc.GenerarDocFirmaFacturaElectronica(Utiles.validarNumeroToInt(ViewState["id_registro"].ToString()));

        string path = ConfigurationSettings.AppSettings["ruta_facturas_e"].ToString();

        if (consecutivo.Trim() != "")
        {
            HyperLink1.Visible = true;
            HyperLink1.Text = "Ver Factura";
            HyperLink1.NavigateUrl = "downloading.aspx?file=" + path + "/DEQ_" + consecutivo + ".pdf";
            HyperLink1.Target = "_blank";

            ButtonBuscar.Enabled = false;

            
            cuenta.insertarLOG(nombre_usuario, "Factura " + consecutivo + " generada", "Factura electronica " + consecutivo, "FacturaElectronica");

        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al generar la factura.');window.location.href='" + ViewState["formulario"].ToString() + "';", true);
        }

        
        string consecutivo_actual = DocumentoFirma.ConsecutivoFacturaActual();
        if (consecutivo_actual != "")
            LabelConsecutivo.Text = "Consecutivo Actual: " + consecutivo_actual;
        

    }
}