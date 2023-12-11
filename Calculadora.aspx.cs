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


public partial class Calculadora : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        llenarDatosValores();


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


    private void calcularValoresLiquidacion()
    {


        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();





        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", "").Replace("$", ""));
        double valorFacturaActual = valorFactura;

        double valorIBC = conf.CalcularIBC(valorFactura);

        double valorSalud = conf.CalcularSalud(valorIBC);

        //double valorPension = conf.CalcularPension(valorIBC, CheckBoxCuentasAnt.Checked, TextBoxNumeroDocumento.Text, valorFactura);
        //double valorPension = conf.CalcularPension(valorIBCActual, CheckBoxCuentasAnt.Checked, TextBoxNumeroDocumento.Text, valorFacturaActual);
        double valorPension = conf.valorPension(valorIBC);

        //double valorARL = conf.CalcularARL(valorIBC);
        int id_riesgo = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
        double porcentajeRiesgoLaboral = ConfiguracionLiquidacion.obtenerPorcentajeRiesgoLaboral(id_riesgo);
        double valorARL = conf.CalcularARL(valorIBC, porcentajeRiesgoLaboral);

        if (CheckBoxPensionado.Checked)
        {
            valorPension = 0;
        }

        LabelValorTotal.Text = String.Format("{0:C}", (decimal)valorFactura).Replace("$ ", "$");
        LabelIBC.Text = String.Format("{0:C}", (decimal)valorIBC).Replace("$ ", "$");
        LabelSalud.Text = String.Format("{0:C}", (decimal)valorSalud).Replace("$ ", "$");
        LabelPension.Text = String.Format("{0:C}", (decimal)valorPension).Replace("$ ", "$");
        LabelARL.Text = String.Format("{0:C}", (decimal)valorARL).Replace("$ ", "$");


    }


    protected void ButtonRecalcular_Click(object sender, System.EventArgs e)
    {
        calcularValoresLiquidacion();
    }
}