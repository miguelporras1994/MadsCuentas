using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LiquidadorPersonaJuridica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

            int id_registro = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id_registro = PetroIMS.validarNumeroToInt(Request.QueryString["id"].ToString());
                    ViewState["id_registro_cuenta"] = id_registro;
                }
                else
                    Response.Redirect("Formularios.aspx");
            }
            if (!IsPostBack)
                llenarControles(id_registro);
            calcularValoresLiquidacion();


        }
        catch
        {

            //Response.Redirect("Login.aspx");
        }



    }


    private void llenarControles(int id_cuenta)
    {
        Cuenta cuenta = new Cuenta(id_cuenta);

        //HyperLinkDetalle.NavigateUrl = "DetalleCuenta.aspx?id=" + id_cuenta + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'";

        //LabelNumeroCuenta.Text = id_cuenta.ToString();

        //DropDownListTipoSolicitud.SelectedValue = cuenta.IDTipoSolicitud.ToString();
        //DropDownListTipoDocumento.SelectedValue = cuenta.IDTipoDocumento.ToString();
        //TextBoxNumeroDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
        //TextBoxNombres.Text = cuenta.NombreBeneficiario;
        //TextBoxCorreo.Text = cuenta.CorreoCuenta;
        //TextBoxNumeroContrato.Text = cuenta.NumeroContrato;

        //Verificar si es natural re enviar al formato de liquidacion
        if (cuenta.IDTipoPersona == 1)
        {
            Response.Redirect("WebFormLiquidacion.aspx?id=" + id_cuenta.ToString());
        }

        LabelSubTotal.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura).Replace("$ ", "").Replace("$", "");
        LabelValorIVA.Text = String.Format("{0:C}", (decimal)cuenta.ValorIVA).Replace("$ ", "").Replace("$", "");
        double valorFacturaConIVA = cuenta.ValorFactura + cuenta.ValorIVA;
        LabelTotal.Text = String.Format("{0:C}", (decimal)valorFacturaConIVA).Replace("$ ", "").Replace("$", "");

        //calcularValorIVA();
        TextBoxValorBaseReteICA.Text = LabelSubTotal.Text;
        TextBoxValorBaseReteFuente.Text = LabelSubTotal.Text;
        TextBoxValorBaseReteIVA.Text = LabelValorIVA.Text;

        LabelBeneficiario.Text = cuenta.NombreBeneficiario;
        LabelNit.Text = cuenta.NumeroDocumentoBeneficiaro;
        LabelCuentaID.Text = id_cuenta.ToString();
        LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;

        TextBoxObservacionesGenerales.Text = "CONTRATO " + cuenta.NumeroContrato + " / " + cuenta.NumeroPago +" / CODIGO CCP: "+ cuenta.CodigoCCP;

        Session["DOCUMENTO_CONSULTAR"] = cuenta.NumeroDocumentoBeneficiaro;
        //TextBoxNumeroRP.Text = cuenta.NumeroRP;
        //TextBoxNumeroPago.Text = cuenta.NumeroPago;
        //TextBoxNumFactura.Text = cuenta.NumeroFactura;
        //DropDownListRiesgoLaboral.SelectedValue = (cuenta.IDRiesgoLaboral != 0) ? cuenta.IDRiesgoLaboral.ToString() : "1";
        //DropDownListEntidad.SelectedValue = cuenta.IDEntidad.ToString();
        //if (cuenta.IDEntidad == 0)
        //{
        //    DropDownListEntidad.Enabled = true;
        //}

    }


    private void calcularValorIVA()
    {
        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(LabelSubTotal.Text.Replace("$ ", ""));
        double valorIVA = conf.CalcularIVA(valorFactura);
        double valorFacturaConIVA = valorFactura - valorIVA;
        LabelTotal.Text = String.Format("{0:C}", (decimal)valorFacturaConIVA).Replace("$ ", "");
        LabelValorIVA.Text = String.Format("{0:C}", (decimal)valorIVA).Replace("$ ", "").Replace("$", "");
    }


    private void calcularValoresLiquidacion()
    {


        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
       
        int id_cuenta = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());

        Cuenta cuenta = new Cuenta(id_cuenta);

        conf.obtenerDatos();
        double valorBaseReteICA = Utiles.validarNumeroToDouble(TextBoxValorBaseReteICA.Text.Replace("$ ", "").Replace("$", ""));
        double valorBaseReteFuente = Utiles.validarNumeroToDouble(TextBoxValorBaseReteFuente.Text.Replace("$ ", "").Replace("$", ""));
        double valorBaseReteIVA = Utiles.validarNumeroToDouble(TextBoxValorBaseReteIVA.Text.Replace("$ ", "").Replace("$", ""));

        double valorFactorReteICA = Utiles.validarNumeroToDouble(TextBoxReteICA.Text.Replace("$ ", "").Replace("$", ""));
        double valorFactorReteFuente = Utiles.validarNumeroToDouble(TextBoxReteFuente.Text.Replace("$ ", "").Replace("$", ""));
        double valorFactorReteIVA = Utiles.validarNumeroToDouble(TextBoxReteIVA.Text.Replace("$ ", "").Replace("$", ""));

        double valorReteICA = ConfiguracionLiquidacion.calcularValorReteICAJuridica(valorFactorReteICA, valorBaseReteICA);
        double valorReteFuente = ConfiguracionLiquidacion.calcularValorReteFuenteJuridica(valorFactorReteFuente, valorBaseReteFuente);
        double valorReteIVA = ConfiguracionLiquidacion.calcularValorReteIVAJuridica(valorFactorReteIVA, valorBaseReteIVA);

        double valorOtrosDescuentos = Utiles.validarNumeroToDouble(TextBoxValorDescuentos.Text.Replace("$ ", "").Replace("$", ""));
        double valorTotalDescuentos = valorReteICA + valorReteFuente + valorReteIVA + valorOtrosDescuentos;

        TextBoxValorCalcReteICA.Text = String.Format("{0:C}", (decimal)valorReteICA).Replace("$ ", "").Replace("$", "");
        TextBoxValorCalcReteFuente.Text = String.Format("{0:C}", (decimal)valorReteFuente).Replace("$ ", "").Replace("$", "");
        TextBoxValorCalcReteIVA.Text = String.Format("{0:C}", (decimal)valorReteIVA).Replace("$ ", "").Replace("$", "");

        TextBoxValorTotalDeducciones.Text = String.Format("{0:C}", (decimal)valorTotalDescuentos).Replace("$ ", "").Replace("$", "");

        double valorFacturaConIVA = Utiles.validarNumeroToDouble(LabelTotal.Text.Replace("$ ", "").Replace("$", ""));
        double valorTotalPagar = valorFacturaConIVA - valorTotalDescuentos;

        TextBoxValorPagar.Text = String.Format("{0:C}", (decimal)valorTotalPagar).Replace("$ ", "");

    }


    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        int id_registro = 0;

        id_registro = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());

        Cuenta cuenta = new Cuenta(id_registro);
        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();

        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;




        try
        {


            cuenta.insertarLOG(nombre_usuario, "", "Radicacion cuenta:" + cuenta.IDRegistro, "Registro");
            //cuenta.correoInscripcion();

            Liquidacion liquidacion = new Liquidacion();
            liquidacion.IDRadicacion = cuenta.IDRegistro;
            liquidacion.ValorTotal = Utiles.validarNumeroToDouble(LabelTotal.Text.Replace("$", ""));
            //liquidacion.ValorIBC = Utiles.validarNumeroToDouble(LabelIBC.Text.Replace("$", ""));
            //liquidacion.ValorSalud = Utiles.validarNumeroToDouble(LabelSalud.Text.Replace("$", ""));
            //liquidacion.ValorPension = Utiles.validarNumeroToDouble(LabelPension.Text.Replace("$", ""));
            //liquidacion.ValorARL = Utiles.validarNumeroToDouble(LabelARL.Text.Replace("$", ""));

            

            //liquidacion.ValorIntVivienda = Utiles.validarNumeroToDouble(LabelIntViviendaTotal.Text.Replace("$", ""));
            //liquidacion.ValorPrepagada = Utiles.validarNumeroToDouble(LabelPrepagTotal.Text.Replace("$", ""));
            //liquidacion.ValorDependientes = Utiles.validarNumeroToDouble(LabelDependientesTotal.Text.Replace("$", ""));
            //liquidacion.ValorRentaExenta = Utiles.validarNumeroToDouble(LabelRenta.Text.Replace("$", ""));
            liquidacion.ValorBaseGravableRetefuente383 = Utiles.validarNumeroToDouble(TextBoxValorBaseReteFuente.Text.Replace("$", ""));
            //liquidacion.ValorBaseGravableRetefuente384 = Utiles.validarNumeroToDouble(LabelBaseGRetefuente384.Text.Replace("$", ""));

            //liquidacion.ValorRetefuenteUVT383 = Utiles.validarNumeroToDouble(LabelRetefuenteUVT.Text.Replace("$", ""));
            //liquidacion.ValorRetefuenteUVT384 = Utiles.validarNumeroToDouble(LabelRetefuenteUVT384.Text.Replace("$", ""));
            liquidacion.ValorRFArt383 = Utiles.validarNumeroToDouble(TextBoxValorCalcReteFuente.Text.Replace("$", ""));
            //liquidacion.ValorRFArt384 = Utiles.validarNumeroToDouble(LabelValorCobrarRetefuente384.Text.Replace("$", ""));
            liquidacion.ValorICA = Utiles.validarNumeroToDouble(TextBoxValorCalcReteICA.Text.Replace("$", ""));
            liquidacion.ValorReteIVA = Utiles.validarNumeroToDouble(TextBoxValorCalcReteIVA.Text.Replace("$", ""));
            liquidacion.ValorTotalPagar383 = Utiles.validarNumeroToDouble(TextBoxValorPagar.Text.Replace("$", ""));
            //liquidacion.ValorTotalPagar384 = Utiles.validarNumeroToDouble(LabelTotalPagar384.Text.Replace("$", ""));
            liquidacion.Nota = TextBoxObservacionesGenerales.Text;

            
            liquidacion.ValorFactorReteICA = Utiles.validarNumeroToDouble(TextBoxReteICA.Text);
            liquidacion.ValorFactorReteIVA = Utiles.validarNumeroToDouble(TextBoxReteIVA.Text);
            liquidacion.ValorFactorReteFuente = Utiles.validarNumeroToDouble(TextBoxReteFuente.Text);
            liquidacion.DescripcionOtrosDescuentos = TextBoxObservaciones.Text;
            liquidacion.ValorOtrosDescuentos = Utiles.validarNumeroToDouble(TextBoxValorDescuentos.Text);
            liquidacion.ValorBaseReteICA383 = Utiles.validarNumeroToDouble(TextBoxValorBaseReteICA.Text);
            liquidacion.ValorBaseReteIVA = Utiles.validarNumeroToDouble(TextBoxValorBaseReteIVA.Text);
            liquidacion.IDRadicacion = id_registro;
            

            liquidacion.insertar();
            //liquidacion.actualizarMetodo(RadioButtonListMetodo.SelectedValue);
            //A partir del 1 de enero de 2017, con la reforma tributaria articulo 384 quedo derogado
            liquidacion.actualizarMetodo("383");

            //cuenta.IDRiesgoLaboral = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
            //cuenta.actualizarRiesgo();

            cuenta.insertarLOG(nombre_usuario, TextBoxObservacionesGenerales.Text, "Liquidacion cuenta P. Juridica", "Registro");

            ButtonGuardar.Enabled = false;
           
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Registro adicionado exitosamente.');window.location.href='OrdenPagoMADS.aspx?id=" + id_registro.ToString() + "';", true);


            //Response.Write("<script>alert('Registro adicionado exitosamente. Numero de registro: " + cuenta.IDRegistro.ToString() + "');window.location.href='Radicacion.aspx';</script>");




        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();", true);
            //Response.Write("<script>alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }
    }
}