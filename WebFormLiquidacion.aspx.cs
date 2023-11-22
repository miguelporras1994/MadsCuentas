using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;


public partial class WebFormLiquidacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //Usuarios usuario = (Usuarios)Session["usuario"];
            //string nombre_usuario = usuario.Alias;

            int id_registro = 0;

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id_registro = PetroIMS.validarNumeroToInt(Request.QueryString["id"].ToString());
                    ViewState["id_registro_cuenta"] = id_registro;

                    //if (!validarObjeto())
                    //{
                    //    string codigo_js = "alert('El RP no tiene un objeto asociado.');window.location.href='ListarPendientesLiquidar.aspx';";
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js + "</script>");
                    //}
                }
                else
                    Response.Redirect("Formularios.aspx");

                //llenar meses Prepagada
                if (DateTime.Now.Month == 12)
                {
                    DropDownListMesesPrepagada.Items.Add(new ListItem("1", "1"));
                }
                else
                {
                    for (int i = 1; i <= (13 - DateTime.Now.Month); i++)
                    {
                        DropDownListMesesPrepagada.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
            }
            if(!IsPostBack)
                llenarDatos();
            calcularValoresLiquidacion();
        }
        catch
        {

            //Response.Redirect("Login.aspx");
        }

        string ButtonID = Request["__EVENTTARGET"];



        if (ButtonID != null)
        {

            if (ButtonID.Contains("CheckBoxDependientes"))
            {

                calcularValoresLiquidacion();
            }

            if (ButtonID.Contains("CheckBoxSinRetencion"))
            {
                if(!CheckBoxSinRetencion.Checked)
                    llenarDatos();
            }

            if (ButtonID.Contains("CheckBoxNoSalud"))
            {
               
                    //llenarDatos();
                    calcularValoresLiquidacion();
            }

            if (ButtonID.Contains("CheckBoxSinARL"))
            {

                llenarDatos();
                calcularValoresLiquidacion();
            }

            if (ButtonID.Contains("CheckBoxAFC"))
            {

                calcularValoresLiquidacion();
                if (CheckBoxAFC.Checked)
                {
                    ButtonIngresarAFC.Visible = true;
                }
                else
                {
                    ButtonIngresarAFC.Visible = false;
                    LabelAFCEditado.Text = "";
                    PanelAFC.Visible = false;
                }
            }
        }

        llenarDatosValores();


    }

    private bool validarObjeto()
    {
        bool resp = true;
        if (ViewState["id_registro_cuenta"] != null)
        {
            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);

            //verificar que la cuenta tenga objeto
            if (cuenta.obtenerObjetoRP().Trim() == "" && cuenta.IDTipoDocumento == 2)
            {

                resp = false;

            }
            else
            {
                TextBoxObjeto.Text = HttpUtility.HtmlDecode( cuenta.obtenerObjetoRP().Trim());
            }
        }
        else
        {
            resp = false;
        }

        return resp;

    }


    private void llenarDatosValores()
    {

        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();

        LiteralInfoValores.Text = "<table>";
        LiteralInfoValores.Text += "<tr><td>UVT:</td><td align='right'>" + String.Format("{0:C}", (decimal)conf.ValorUVT).Replace("$ ", "") + "</td></tr>";
        LiteralInfoValores.Text += "<tr><td>Minimo:</td><td align='right'>" + String.Format("{0:C}", (decimal)conf.ValorSalarioMinimo).Replace("$ ", "") + "</td></tr>";
        LiteralInfoValores.Text += "<tr><td>Rete ICA:</td><td align='right'>" + String.Format("{0:C}", (decimal)conf.ValorReteICA).Replace("$ ", "") + "</td></tr>";

        LiteralInfoValores.Text += "</table>";
    }


    private void llenarDatos()
    {
        if (ViewState["id_registro_cuenta"] != null)
        {
            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);

            //verificar que la cuenta tenga objeto
            //if (cuenta.obtenerObjetoRP().Trim() == "" && cuenta.IDTipoDocumento == 2)
            //{

            //    string codigo_js = "alert('El RP " + cuenta.NumeroRP + " no tiene un objeto asociado.');window.location.href='ListarPendientesLiquidar.aspx';";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js + "</script>");
            //    return;
            //}


	    //Verificar si es juridica re enviar al formato de liquidacion
            if(cuenta.IDTipoPersona == 2)
            {
                Response.Redirect("LiquidadorPersonaJuridica.aspx?id=" + id_registro.ToString());
            }


            LabelNumeroCuenta.Text = id_registro.ToString();
            HyperLinkDetalle.NavigateUrl = "DetalleCuenta.aspx?id=" + id_registro + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'";
            HyperLinkEditar.NavigateUrl = "Radicacion.aspx?editar=true&id=" + id_registro.ToString();
            TextBoxNumeroDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
            TextBoxNombres.Text = cuenta.NombreBeneficiario;
            TextBoxCorreo.Text = cuenta.CorreoCuenta;
            TextBoxNumeroContrato.Text = cuenta.NumeroContrato;
            TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura).Replace("$ ", "");
            TextBoxValorIVA.Text = String.Format("{0:C}", (decimal)cuenta.ValorIVA).Replace("$ ", "");
            TextBoxNumFactura.Text = cuenta.NumeroFactura;
            TextBoxNumeroRP.Text = cuenta.NumeroRP;
            TextBoxNumeroPago.Text = cuenta.NumeroPago;
            DropDownListRiesgoLaboral.SelectedValue = (cuenta.IDRiesgoLaboral != 0) ? cuenta.IDRiesgoLaboral.ToString() : "1";
            Session["DOCUMENTO_CONSULTAR"] = cuenta.NumeroDocumentoBeneficiaro;
            DropDownListEntidad.SelectedValue = cuenta.IDEntidad.ToString();
            TextBoxNota.Text = "CONTRATO " + cuenta.NumeroContrato + " / " + cuenta.NumeroPago;
            if (cuenta.CodigoCCP != "")
                TextBoxNota.Text = TextBoxNota.Text + " / CODIGO CCP: " + cuenta.CodigoCCP;

            if (cuenta.IDEntidad == 0)
            {
                DropDownListEntidad.Enabled = true;
            }

            //Validar si tiene mas cuentas en el mes

            int cuentasPorMes = Cuenta.cuentasPorMes(TextBoxNumeroDocumento.Text);

            //if (cuentasPorMes > 1)
            //{

            //    LiteralAlerta.Text = "<div class='alert alert-danger'>El numero de documento tiene " + cuentasPorMes.ToString() + " cuenta(s) registrada(s) en el mes actual</div>";

            //    CheckBoxCuentasAnt.Enabled = true;
            //}
            //else
            //{
            //    LiteralAlerta.Text = "";
            //    CheckBoxCuentasAnt.Checked = false;
            //    CheckBoxCuentasAnt.Enabled = false;
            //}

            if (cuenta.CuentaPorPagar != "")
            {
                TextBoxCuentaPorPagar.ReadOnly = true;
                TextBoxCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                ButtonActualizarCXP.Visible = false;
            }
            else
            {
                TextBoxCuentaPorPagar.ReadOnly = false;
                ButtonActualizarCXP.Visible = true;
            }


            InteresVivienda interesV = new InteresVivienda(TextBoxNumeroDocumento.Text, DateTime.Now.Year);
            Prepagada prep = new Prepagada(TextBoxNumeroDocumento.Text, DateTime.Now.Year);

            double valorIntViv = interesV.ValorMes;
            double valorPrep = prep.ValorMes;
            LabelIntVivivenda.Text = "[" + String.Format("{0:C}", (decimal)interesV.ValorMes).Replace("$ ", "$") + "]";
            
            LabelPrepag.Text = "[" + String.Format("{0:C}", (decimal)prep.ValorMes).Replace("$ ", "$") + "]";
            
            if (valorPrep > 0)
            {
                //LabelPrepagIngresado.Text = "Total:" + String.Format("{0:C}", (decimal)prep.ValorTotal).Replace("$ ", "$");
                LabelPrepagPeriodo.Text = "<div align='left'><strong>Registrado:</strong> " + prep.FechaIngreso.ToShortDateString() + "<br /><strong>Vence:</strong> " + prep.MesVence.ToString() + "/" + prep.A_o + "<br/><strong>Periodo:</strong> " + prep.Meses.ToString() + " Meses<br/><strong>Valor:</strong>" + String.Format("{0:C}", (decimal)prep.ValorTotal).Replace("$ ", "$") + "</div>";  
            }
            if (valorIntViv > 0)
            {
                //LabelIntViviendaIngresado.Text = "Total:" + String.Format("{0:C}", (decimal)interesV.ValorTotal).Replace("$ ", "$");
                LabelIntViviendaPeriodo.Text = "<div align='left'><strong>Registrado:</strong> " + interesV.FechaIngreso.ToShortDateString() + "<br /><strong>Vence:</strong> 12/" + prep.A_o + "<br/><strong>Periodo:</strong> 12 Meses<br/><strong>Valor:</strong>" + String.Format("{0:C}", (decimal)interesV.ValorTotal).Replace("$ ", "$") + "</div>";  
            }

            if (Liquidacion.TieneDependientes(TextBoxNumeroDocumento.Text))
            {
                CheckBoxDependientes.Checked = true;
            }

            calcularValoresLiquidacion();


        }
    }

    private void actualizarValoresPrepagada()
    {
        
        Prepagada prep = new Prepagada(TextBoxNumeroDocumento.Text, DateTime.Now.Year);

        
        double valorPrep = prep.ValorMes;
       

        LabelPrepag.Text = "[" + String.Format("{0:C}", (decimal)prep.ValorMes).Replace("$ ", "$") + "]";

        if (valorPrep > 0)
        {
            //LabelPrepagIngresado.Text = "Total:" + String.Format("{0:C}", (decimal)prep.ValorTotal).Replace("$ ", "$");
            LabelPrepagPeriodo.Text = "<div align='left'><strong>Registrado:</strong> " + prep.FechaIngreso.ToShortDateString() + "<br /><strong>Vence:</strong> " + prep.MesVence.ToString() + "/" + prep.A_o + "<br/><strong>Periodo:</strong> " + prep.Meses.ToString() + " Meses<br/><strong>Valor:</strong>" + String.Format("{0:C}", (decimal)prep.ValorTotal).Replace("$ ", "$") + "</div>";
        }
        

        
    }

    private void calcularValorIVA()
    {
        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", ""));
        double valorIVA = conf.CalcularIVA(valorFactura);
        double valorFacturaConIVA = valorFactura - valorIVA;
        TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)valorFacturaConIVA).Replace("$ ", "");
        TextBoxValorIVA.Text = String.Format("{0:C}", (decimal)valorIVA).Replace("$ ", "").Replace("$", "");
    }

    private void devolverValorIVA()
    {
        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        //conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", ""));
        double valorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text.Replace("$ ", ""));
        double valorTotal = valorFactura + valorIVA;
        //TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)valorTotal).Replace("$ ", "");
        if (ViewState["valor_factura"] != null)
            TextBoxValorFactura.Text = String.Format("{0:C}", ViewState["valor_factura"].ToString()).Replace("$ ", "");
        else
            TextBoxValorFactura.Text = "";

        TextBoxValorIVA.Text = "";
    }


    private void calcularValoresLiquidacion()
    {


        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        InteresVivienda interesV = new InteresVivienda(TextBoxNumeroDocumento.Text, DateTime.Now.Year);
        Prepagada prep = new Prepagada(TextBoxNumeroDocumento.Text, DateTime.Now.Year);

        int id_cuenta = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());
        Cuenta cuenta = new Cuenta(id_cuenta);

        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", "").Replace("$", ""));
        double valorFacturaActual = valorFactura;

        double valoresAnt = 0;

        if (CheckBoxSinRetencion.Checked == false)
        {

            //if (CheckBoxCuentasAnt.Enabled == true)
            //{
            //    if (CheckBoxCuentasAnt.Checked)
            //    {
            //        valorFactura = Cuenta.ValorCuentasPorMes(TextBoxNumeroDocumento.Text);
            //    }
            //    else
            //    {
            //        valoresAnt = 0;
            //    }

            //}
            //else
            //{
            //    valoresAnt = 0;
            //}

            //double valorIBC = Math.Round( conf.CalcularIBC(valorFactura),System.MidpointRounding.AwayFromZero);
            double valorIBC = conf.CalcularIBC(valorFactura);
            double valorIBCActual = conf.CalcularIBC(valorFacturaActual);
            double valorSalud = Math.Round(conf.CalcularSalud(valorIBC),0);
            double valorSaludActual = Math.Round(conf.CalcularSalud(valorIBCActual),0);


            if (CheckBoxNoSalud.Checked)
            {
                valorSalud = 0;
                valorSaludActual = 0;
            }

            

            //double valorPension = conf.CalcularPension(valorIBC, CheckBoxCuentasAnt.Checked, TextBoxNumeroDocumento.Text, valorFactura);
            //double valorPension = conf.CalcularPension(valorIBCActual, CheckBoxCuentasAnt.Checked, TextBoxNumeroDocumento.Text, valorFacturaActual);
            double valorPension = Math.Round(conf.CalcularPension(valorIBCActual, false, TextBoxNumeroDocumento.Text, valorFacturaActual),0);
            double valorPensionActual = Math.Round(conf.CalcularPension(valorIBCActual, false, TextBoxNumeroDocumento.Text, valorFacturaActual),0);


            if (CheckBoxNoPension.Checked)
            {
                valorPension = 0;
                valorPensionActual = 0;
            }

            //double valorARL = conf.CalcularARL(valorIBC);
            int id_riesgo = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
            double porcentajeRiesgoLaboral = ConfiguracionLiquidacion.obtenerPorcentajeRiesgoLaboral(id_riesgo);
            double valorARL = Math.Round(conf.CalcularARL(valorIBC, porcentajeRiesgoLaboral),0);
            double valorARLActual = Math.Round(conf.CalcularARL(valorIBCActual, porcentajeRiesgoLaboral),0);

            if (CheckBoxSinARL.Checked)
            {
                valorARL = 0;
                valorARLActual = 0;
            }


            //double valorBaseICA = ConfiguracionLiquidacion.CalcularBaseGravableReteICA(valorFacturaActual, valorSaludActual, valorPensionActual, valorARLActual);

            double valorDependientes = conf.CalcularValorDependientes(valorFactura);
            double valorDependientesActual = conf.CalcularValorDependientes(valorFacturaActual);

            //double valorAFC = Utiles.validarNumeroToDouble(LabelAFC.Text.Replace("$", ""));
            double valorAFC = 0;
            double valorAFCDef = 0;
            double valorIntViv = conf.CalcularValorInteresesVivienda(interesV.ValorMes);
            double valorPrepag = conf.CalcularValorPrepagada(prep.ValorMes);
            //double valorPrepag = prep.ValorMes;

            if (CheckBoxDependientes.Checked)
                LabelDependientes.Text = "[" + String.Format("{0:C}", (decimal)valorDependientes).Replace("$ ", "$") + "]";
            else
            {
                LabelDependientes.Text = "";
                LabelDependientesTotal.Text = "";
                valorDependientes = 0;
            }

            if (CheckBoxAFC.Checked)
            {
                valorAFCDef = conf.CalcularAFC(valorFactura, valorPension);

                if (LabelAFCEditado.Text.Trim() != "")
                {
                    valorAFC = Utiles.validarNumeroToDouble(LabelAFCEditado.Text.Replace("$ ", "").Replace("$", ""));
                }
                else
                {
                    valorAFC = valorAFCDef;
                }

                LabelAFC.Text = String.Format("{0:C}", (decimal)valorAFCDef).Replace("$ ", "$");
            }
            else
            {

                LabelAFC.Text = "";
                LabelAFCEditado.Text = "";
                valorAFC = 0;
                valorAFCDef = 0;
            }

            //double valorRentasExentas = conf.CalcularValorRentasExentas(valorPrepag, valorIntViv, valorDependientes);

            double valorTotalIncrngo = conf.CalcularValorTotalIncrngo(valorSalud, valorPension, valorARL);
            //double valorRentaLiquidaCedular = conf.CalcularValorRentaLiquidaCedular(valorFactura, valorSalud, valorPension);
            double valorRentaLiquidaCedular = conf.CalcularValorRentaLiquidaCedular(valorFactura, valorSalud, valorPension,valorARL);
            double valorRentasExentas = valorAFC;
            double valorTotalDeducciones = conf.CalcularValorTotalDeducciones(valorPrepag, valorIntViv, valorDependientes);
            double valorBaseBrutaGravable = conf.CalcularValorBaseBrutaGravable(valorFactura, valorTotalIncrngo, valorRentasExentas, valorTotalDeducciones);
            double valorRentaExenta = conf.CalcularValorRentaExenta(valorBaseBrutaGravable);
            double valorTotalDeduccionesValidacion = conf.CalcularValorTotalDeduccionesValidacion(valorRentasExentas, valorTotalDeducciones, valorRentaExenta);
            double valorLimiteH = conf.CalcularLimiteIngresoHonorarios(valorRentaLiquidaCedular);
            //double valorDeducciones 


            LabelIntViviendaTotal.Text = String.Format("{0:C}", (decimal)valorIntViv).Replace("$ ", "$");
            LabelPrepagTotal.Text = String.Format("{0:C}", (decimal)valorPrepag).Replace("$ ", "$");
            LabelDependientesTotal.Text = String.Format("{0:C}", (decimal)valorDependientes).Replace("$ ", "$");
            LabelValorTotal.Text = String.Format("{0:C}", (decimal)valorFactura).Replace("$ ", "$");
            LabelIBC.Text = String.Format("{0:C}", (decimal)valorIBC).Replace("$ ", "$");
            LabelSalud.Text = String.Format("{0:C}", (decimal)valorSalud).Replace("$ ", "$");
            LabelPension.Text = String.Format("{0:C}", (decimal)valorPension).Replace("$ ", "$");
            LabelARL.Text = String.Format("{0:C}", (decimal)valorARL).Replace("$ ", "$");

            if (TextBoxSalud.Text == "") TextBoxSalud.Text = valorSalud.ToString();
            if (TextBoxPension.Text == "") TextBoxPension.Text = valorPension.ToString();
            if (TextBoxARL.Text == "") TextBoxARL.Text = valorARL.ToString();

            valorSalud = Utiles.validarNumeroToDouble(TextBoxSalud.Text);
            valorSaludActual = Utiles.validarNumeroToDouble(TextBoxSalud.Text);
            valorPension = Utiles.validarNumeroToDouble(TextBoxPension.Text);
            valorPensionActual = Utiles.validarNumeroToDouble(TextBoxPension.Text);
            valorARL = Utiles.validarNumeroToDouble(TextBoxARL.Text);
            valorARLActual = Utiles.validarNumeroToDouble(TextBoxARL.Text);

            //TextBoxPension.Text = valorPension.ToString();
            //TextBoxARL.Text = valorARL.ToString();
            
            LabelIntVivivenda.Text = "[" + String.Format("{0:C}", (decimal)interesV.ValorMes).Replace("$ ", "$") + "]";
            LabelRentaLCedular.Text = String.Format("{0:C}", (decimal)valorRentaLiquidaCedular).Replace("$ ", "$");
            LabelLimIngHonorarios.Text = String.Format("{0:C}", (decimal)valorLimiteH).Replace("$ ", "$");
            LabelDeducciones.Text = String.Format("{0:C}", (decimal)valorTotalDeduccionesValidacion).Replace("$ ", "$");
            LabelINCRGO.Text = String.Format("{0:C}", (decimal)valorTotalIncrngo).Replace("$ ", "$");
            LabelTotalRentasExentas.Text = String.Format("{0:C}", (decimal)valorRentasExentas).Replace("$ ", "$");
            LabelTotalDeducciones.Text = String.Format("{0:C}", (decimal)valorTotalDeducciones).Replace("$ ", "$");
            LabelBaseBruta.Text = String.Format("{0:C}", (decimal)valorBaseBrutaGravable).Replace("$ ", "$");
            LabelRentaExenta.Text = String.Format("{0:C}", (decimal)valorRentaExenta).Replace("$ ", "$");

            if (valorTotalDeduccionesValidacion > valorLimiteH)
                LabelLimIngHonorarios.ForeColor = System.Drawing.Color.Red;
            else
                LabelLimIngHonorarios.ForeColor = System.Drawing.Color.Green;

            double valorDep = Utiles.validarNumeroToDouble(LabelDependientesTotal.Text.Replace("$", ""));

            //Art 383
            double baseGravableRetefuente_pre383 = conf.CalcularPreliquidacionBaseGravableRetefuente(valorFactura, valorSalud, valorPension, valorARL, valorAFC, valorIntViv, valorPrepag, valorDep);
            double baseGravableRetefuente_pre383Actual = conf.CalcularPreliquidacionBaseGravableRetefuente(valorFacturaActual, valorSaludActual, valorPensionActual, valorARLActual, valorAFC, valorIntViv, valorPrepag, valorDep);
            //double valorRentaExenta = conf.CalcularRentaExenta(baseGravableRetefuente_pre383);
            double valorRentaExentaActual = conf.CalcularRentaExenta(baseGravableRetefuente_pre383Actual);
            double baseGravableRetefuente383 = conf.CalcularBaseGravableRetefuente383(baseGravableRetefuente_pre383, valorRentaExenta);
            double baseGravableRetefuente383Actual = conf.CalcularBaseGravableRetefuente383(baseGravableRetefuente_pre383Actual, valorRentaExentaActual);


            double limiteIngresoHonorarios = conf.CalcularLimiteIngresoHonorarios(valorRentaLiquidaCedular);

            double baseGravable = conf.calcularBaseGravable(valorRentasExentas, valorTotalDeducciones, valorRentaExenta, limiteIngresoHonorarios, valorFactura, valorTotalIncrngo);
            double valorReteFuenteUVT383 = conf.CalcularRetefuenteUVT(baseGravable);
            double valorICA = 0;
            double valorICAActual = 0;
            double valorBaseICA = 0;




            valorICA = (TextBoxICA.Text.Trim() == "") ? conf.CalcularICA(valorFactura, valorSalud, valorPension, valorARL, 0) : conf.CalcularICA(valorFactura, valorSalud, valorPension, valorARL, Utiles.validarNumeroToDouble(TextBoxICA.Text));
            valorICAActual = (TextBoxICA.Text.Trim() == "") ? conf.CalcularICA(valorFacturaActual, valorSaludActual, valorPensionActual, valorARLActual, 0) : conf.CalcularICA(valorFacturaActual, valorSaludActual, valorPensionActual, valorARLActual, Utiles.validarNumeroToDouble(TextBoxICA.Text));

            //calcular base del ICA
            valorBaseICA = ConfiguracionLiquidacion.CalcularBaseGravableReteICA(((TextBoxICA.Text.Trim() == "") ? 0 : Utiles.validarNumeroToDouble(TextBoxICA.Text)), valorICAActual);
            LabelBaseICA.Text = String.Format("{0:C}", (decimal)valorBaseICA).Replace("$ ", "$");


            double retefuenteUVT383 = conf.CalcularValorReteFuenteArt383(valorReteFuenteUVT383);
            double valorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text.Replace("$", ""));
            double valorReteIVA = conf.CalcularReteIVA(valorIVA);
            double totalPagar383 = Math.Round((valorFacturaActual - retefuenteUVT383 - valorICAActual - valorReteIVA), 0);
            double totalPagarConIva383 = totalPagar383 + valorIVA;



            LabelBaseGRetefuente383.Text = String.Format("{0:C}", (decimal)baseGravable).Replace("$ ", "$");
            LabelRetefuenteUVT.Text = String.Format("{0:C}", (decimal)valorReteFuenteUVT383).Replace("$ ", "");
            LabelRenta.Text = String.Format("{0:C}", (decimal)valorRentaExenta).Replace("$ ", "$");
            LabelICA.Text = String.Format("{0:C}", (decimal)valorICAActual).Replace("$ ", "$");
            LabelReteIVA.Text = String.Format("{0:C}", (decimal)valorReteIVA).Replace("$ ", "$");
            LabelValorCobrarRetefuente.Text = String.Format("{0:C}", (decimal)retefuenteUVT383).Replace("$ ", "$");
            LabelTotalPagar383.Text = String.Format("{0:C}", (decimal)totalPagarConIva383).Replace("$ ", "$");

        }
        else
        {
            double valorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text.Replace("$", ""));
            LabelTotalPagar383.Text = String.Format("{0:C}", ((decimal)valorFactura + (decimal)valorIVA)).Replace("$ ", "$");
            resetearValoresLiquidacion();
        }


        
        


    }


    private void resetearValoresLiquidacion(){

            LabelIntViviendaTotal.Text = "0";
            LabelPrepagTotal.Text = "0";
            LabelDependientes.Text = "0";
            LabelPrepag.Text = "0";
            LabelDependientesTotal.Text = "0";
            //LabelValorTotal.Text = "0";
            //LabelIBC.Text = "0";
            //LabelSalud.Text = "0";
            //LabelPension.Text = "0";
            //LabelARL.Text = "0";
            LabelIntVivivenda.Text = "0";
            LabelRentaLCedular.Text = "0";
            LabelLimIngHonorarios.Text = "0";
            LabelDeducciones.Text = "0";
            LabelINCRGO.Text = "0";
            LabelTotalRentasExentas.Text = "0";
            LabelTotalDeducciones.Text = "0";
            LabelBaseBruta.Text = "0";
            LabelRentaExenta.Text = "0";

            LabelBaseGRetefuente383.Text = "0";
            LabelRetefuenteUVT.Text = "0";
            LabelRenta.Text = "0";
            LabelICA.Text = "0";
            LabelReteIVA.Text = "0";
            LabelValorCobrarRetefuente.Text = "0";

            LabelBaseICA.Text = "0";
            LabelPrepagPeriodo.Text = "";
            LabelIntViviendaPeriodo.Text = "";
           

    }



    private void llenarControles(int id_cuenta)
    {
        Cuenta cuenta = new Cuenta(id_cuenta);

        HyperLinkDetalle.NavigateUrl = "DetalleCuenta.aspx?id=" + id_cuenta + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'";

        LabelNumeroCuenta.Text = id_cuenta.ToString();

        //DropDownListTipoSolicitud.SelectedValue = cuenta.IDTipoSolicitud.ToString();
        //DropDownListTipoDocumento.SelectedValue = cuenta.IDTipoDocumento.ToString();
        TextBoxNumeroDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
        TextBoxNombres.Text = cuenta.NombreBeneficiario;
        TextBoxCorreo.Text = cuenta.CorreoCuenta;
        TextBoxNumeroContrato.Text = cuenta.NumeroContrato;
        TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
        TextBoxNumeroRP.Text = cuenta.NumeroRP;
        TextBoxNumeroPago.Text = cuenta.NumeroPago;
        TextBoxNumFactura.Text = cuenta.NumeroFactura;
        DropDownListRiesgoLaboral.SelectedValue = (cuenta.IDRiesgoLaboral != 0) ? cuenta.IDRiesgoLaboral.ToString() : "1";
        DropDownListEntidad.SelectedValue = cuenta.IDEntidad.ToString();
        if (cuenta.IDEntidad == 0)
        {
            DropDownListEntidad.Enabled = true;
        }

        TextBoxObjeto.Text = cuenta.obtenerObjetoRP().Trim();
        
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
            liquidacion.ValorTotal = Utiles.validarNumeroToDouble(LabelValorTotal.Text.Replace("$", ""));
            liquidacion.ValorIBC = Utiles.validarNumeroToDouble(LabelIBC.Text.Replace("$", ""));
            liquidacion.ValorSalud = Utiles.validarNumeroToDouble(LabelSalud.Text.Replace("$", ""));
            liquidacion.ValorPension = Utiles.validarNumeroToDouble(LabelPension.Text.Replace("$", ""));
            liquidacion.ValorARL = Utiles.validarNumeroToDouble(LabelARL.Text.Replace("$", ""));

            if (LabelAFCEditado.Text.Trim() != "")
            {
                liquidacion.ValorAFC = Utiles.validarNumeroToDouble(LabelAFCEditado.Text.Replace("$", ""));
            }
            else
            {
                liquidacion.ValorAFC = Utiles.validarNumeroToDouble(LabelAFC.Text.Replace("$", ""));
            }

            liquidacion.ValorIntVivienda = Utiles.validarNumeroToDouble(LabelIntViviendaTotal.Text.Replace("$", ""));
            liquidacion.ValorPrepagada = Utiles.validarNumeroToDouble(LabelPrepagTotal.Text.Replace("$", ""));
            liquidacion.ValorDependientes = Utiles.validarNumeroToDouble(LabelDependientesTotal.Text.Replace("$", ""));
            liquidacion.ValorRentaExenta = Utiles.validarNumeroToDouble(LabelRenta.Text.Replace("$", ""));
            liquidacion.ValorBaseGravableRetefuente383 = Utiles.validarNumeroToDouble(LabelBaseGRetefuente383.Text.Replace("$", ""));
            //liquidacion.ValorBaseGravableRetefuente384 = Utiles.validarNumeroToDouble(LabelBaseGRetefuente384.Text.Replace("$", ""));

            liquidacion.ValorRetefuenteUVT383 = Utiles.validarNumeroToDouble(LabelRetefuenteUVT.Text.Replace("$", ""));
            //liquidacion.ValorRetefuenteUVT384 = Utiles.validarNumeroToDouble(LabelRetefuenteUVT384.Text.Replace("$", ""));
            liquidacion.ValorRFArt383 = Utiles.validarNumeroToDouble(LabelValorCobrarRetefuente.Text.Replace("$", ""));
            //liquidacion.ValorRFArt384 = Utiles.validarNumeroToDouble(LabelValorCobrarRetefuente384.Text.Replace("$", ""));
            liquidacion.ValorICA = Utiles.validarNumeroToDouble(LabelICA.Text.Replace("$", ""));
            liquidacion.ValorReteIVA = Utiles.validarNumeroToDouble(LabelReteIVA.Text.Replace("$", ""));
            liquidacion.ValorTotalPagar383 = Utiles.validarNumeroToDouble(LabelTotalPagar383.Text.Replace("$", ""));
            //liquidacion.ValorTotalPagar384 = Utiles.validarNumeroToDouble(LabelTotalPagar384.Text.Replace("$", ""));
            liquidacion.Nota = TextBoxNota.Text;
            liquidacion.ValorBaseReteICA383 = Utiles.validarNumeroToDouble(LabelBaseICA.Text.Replace("$", ""));

            double valorICA = (TextBoxICA.Text.Trim() != "") ? Utiles.validarNumeroToDouble(TextBoxICA.Text) : conf.ValorReteICA;
            liquidacion.ValorFactorReteICA = valorICA;
            liquidacion.ValorFactorReteIVA = conf.ValorReteIVA;
            liquidacion.IDRadicacion = id_registro;

            liquidacion.insertar();

            cuenta.IDRiesgoLaboral = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
            cuenta.actualizarRiesgo();

            cuenta.insertarLOG(nombre_usuario, "", "Liquidacion cuenta", "Registro");

            ButtonGuardar.Enabled = false;
            ButtonGuardarAFC.Enabled = false;
            ButtonRecalcular.Enabled = false;
            ButtonIngresarAFC.Enabled = false;
            ButtonIngresarIntViv.Enabled = false;
            ButtonIngresarPrepag.Enabled = false;
            TextBoxICA.Enabled = false;
            CheckBoxAFC.Enabled = false;
            //CheckBoxCuentasAnt.Enabled = false;
            CheckBoxNoPension.Enabled = false;
            CheckBoxDependientes.Enabled = false;
            TextBoxNota.Enabled = false;
            TextBoxCuentaPorPagar.Enabled = false;
            DropDownListEntidad.Enabled = false;
            ButtonActualizarCXP.Enabled = false;
            DropDownListRiesgoLaboral.Enabled = false;

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Registro adicionado exitosamente.');window.location.href='OrdenPagoMADS.aspx?id=" + id_registro.ToString() + "';", true);
            


            //Response.Write("<script>alert('Registro adicionado exitosamente. Numero de registro: " + cuenta.IDRegistro.ToString() + "');window.location.href='Radicacion.aspx';</script>");




        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();", true);
            //Response.Write("<script>alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }
    }





    protected void ButtonIngresarIntViv_Click(object sender, System.EventArgs e)
    {
        PanelIntVivienda.Visible = true;
        PanelAFC.Visible = false;
        PanelPrepag.Visible = false;
        PanelAFC.Visible = false;
    }

    protected void ButtonGuardarIntViv_Click(object sender, System.EventArgs e)
    {

        if (TextBoxNumeroDocumento.Text.Trim() == "")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Por favor ingrese el numero de documento');", true);
            return;
        }



        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();
        double valorTotalIntViv = Utiles.validarNumeroToDouble(TextBoxValorIntViv.Text.Replace("$ ", ""));
        double valorMesIntViv = conf.CalcularInteresVivienda(valorTotalIntViv);
        InteresVivienda interesV = new InteresVivienda(TextBoxNumeroDocumento.Text, DateTime.Now.Year);
        interesV.ValorTotal = valorTotalIntViv;
        interesV.ValorMes = valorMesIntViv;
        int resp = interesV.insertar();

        if (resp > 0)
        {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Valor ingresado correctamente');", true);
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro');", true);

        }

        TextBoxValorIntViv.Text = "";

        PanelIntVivienda.Visible = false;

        calcularValoresLiquidacion();

    }
    protected void ButtonCancelIntViv_Click(object sender, System.EventArgs e)
    {
        PanelIntVivienda.Visible = false;
        TextBoxValorIntViv.Text = "";
    }
    protected void ButtonIngresarAFC_Click(object sender, System.EventArgs e)
    {
        PanelAFC.Visible = true;
        PanelIntVivienda.Visible = false;
        PanelPrepag.Visible = false;
        //TextBoxValorAFC.Text = (LabelAFC.Text.Trim() != "") ? LabelAFC.Text.Replace("$", "") : "";

    }
    protected void ButtonCancelarAFC_Click(object sender, System.EventArgs e)
    {
        PanelAFC.Visible = false;
        TextBoxValorAFC.Text = "";
        LabelAFCEditado.Text = "";
    }
    protected void ButtonGuardarAFC_Click(object sender, System.EventArgs e)
    {
        LabelAFC.Text = "[" + LabelAFC.Text + "]";
        LabelAFCEditado.Text = String.Format("{0:C}", (decimal)Utiles.validarNumeroToDouble(TextBoxValorAFC.Text)).Replace("$ ", "$");
        calcularValoresLiquidacion();
        TextBoxValorAFC.Text = "";
        PanelAFC.Visible = false;
    }
    protected void ButtonGuardarPrepag_Click(object sender, System.EventArgs e)
    {
        /*
        LabelPrepag.Text = "[" + String.Format("{0:C}", (decimal)Utiles.validarNumeroToDouble(TextBoxValorPrepagada.Text)).Replace("$ ", "$") + "]";
        calcularValoresLiquidacion();
        TextBoxValorPrepagada.Text = "";
        PanelPrepag.Visible = false;
        */



        if (TextBoxNumeroDocumento.Text.Trim() == "")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Por favor ingrese el numero de documento');", true);
            return;
        }



        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();
        double valorTotalPrep = Utiles.validarNumeroToDouble(TextBoxValorPrepagada.Text.Replace("$ ", ""));
        double valorMesPrep = conf.CalcularInteresPrepagada(valorTotalPrep,Utiles.validarNumeroToInt(DropDownListMesesPrepagada.Text));
        Prepagada prep = new Prepagada(TextBoxNumeroDocumento.Text, DateTime.Now.Year);
        prep.ValorTotal = valorTotalPrep;
        prep.ValorMes = valorMesPrep;
        prep.Meses = Utiles.validarNumeroToInt( DropDownListMesesPrepagada.Text);
        prep.MesVence = (DateTime.Now.Month - 1) + Utiles.validarNumeroToInt(DropDownListMesesPrepagada.Text);

        int resp = prep.insertar();

        if (resp > 0)
        {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Valor ingresado correctamente');", true);
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro');", true);

        }

        TextBoxValorPrepagada.Text = "";

        PanelPrepag.Visible = false;

        actualizarValoresPrepagada();

        calcularValoresLiquidacion();



    }
    protected void ButtonIngresarPrepag_Click(object sender, System.EventArgs e)
    {
        PanelPrepag.Visible = true;
        PanelIntVivienda.Visible = false;
        PanelAFC.Visible = false;
        //TextBoxValorPrepagada.Text = (LabelPrepag.Text.Trim() != "") ? LabelPrepag.Text.Replace("$", "") : "";
        TextBoxValorPrepagada.Text = "";
        Prepagada prep = new Prepagada(TextBoxNumeroDocumento.Text, DateTime.Now.Year);
        if (prep.ValorMes > 0)
        {

            LiteralAlertaPrepagada.Text = "<div class='alert alert-danger'>Ya existe un registro de Prepagada, si guarda la informaci&oacute;n se tomar&aacute; la ultima informaci&oacute;n</div>";
        }

        
    }

    protected void ButtonCancelarPrepag_Click(object sender, System.EventArgs e)
    {
        PanelPrepag.Visible = false;
        TextBoxValorPrepagada.Text = "";
    }
    protected void ButtonRecalcular_Click(object sender, System.EventArgs e)
    {

    }
    protected void ButtonActualizarCXP_Click(object sender, System.EventArgs e)
    {
        try
        {

            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro_cuenta"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);
            cuenta.CuentaPorPagar = TextBoxCuentaPorPagar.Text;
            cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);

            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

            if (TextBoxCuentaPorPagar.Text.Trim() == "" || DropDownListEntidad.Text == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Debe ingresar los datos de la cuenta por pagar: Numero de cuenta y Entidad');", true);
                return;
            }


            if (!cuenta.cuentaPorPagarExiste())
            {

                int resp = cuenta.actualizarCuentaPorPagar();

                if (resp > 0)
                {
                   
                    cuenta.insertarLOG(usuario.Alias, "", "Registro cuenta por pagar: " + TextBoxCuentaPorPagar.Text, "Registro");
                    //Response.Write("<script>alert('La informacion se actualizo correctamente');window.location.href='ListarPendientesCuentasPorPagar.aspx';</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('La informacion se actualizo correctamente');", true);

                }
                else
                {

                    //Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion');window.history.back();</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar la informacion');", true);
                    return;

                }
            }
            else
            {

                //Response.Write("<script>alert('La cuenta por pagar ya se encuentra registrada');window.history.back();</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('La cuenta por pagar ya se encuentra registrada');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            //Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion:" + ex.Message.Normalize() + "');window.history.back();</script>");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar la informacion:" + ex.Message.Normalize() + "');", true);

        }
        

    }
    protected void ButtonVolverListado_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("ListarPendientesLiquidar.aspx");
    }
}