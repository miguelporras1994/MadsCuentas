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


public partial class Radicacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //Usuarios usuario = (Usuarios)Session["usuario"];
            //string nombre_usuario = usuario.Alias;

            calcularValoresLiquidacion();

        }
        catch(Exception ex)
        {

            Response.Redirect("Login.aspx");
        }

        string ButtonID = Request["__EVENTTARGET"];

        if (ButtonID != null)
        {
            if (ButtonID.Contains("TextBoxNumeroDocumento"))
            {

                if (TextBoxNumeroDocumento.Text.Trim() != "")
                {
                    //if (DropDownListTipoDocumento.Text == "2")
                    //{
                        Cuenta cuenta = new Cuenta();
                        cuenta.NumeroDocumentoBeneficiaro = TextBoxNumeroDocumento.Text;
                        cuenta.obtenerDatosPorDocumento();
                        TextBoxCorreo.Text = cuenta.CorreoCuenta;
                        TextBoxNombres.Text = cuenta.NombreBeneficiario;
                        //TextBoxNumeroContrato.Text = cuenta.NumeroContrato;
                        //TextBoxNumeroRP.Text = cuenta.NumeroRP;
                        DropDownListRiesgoLaboral.SelectedValue = (cuenta.IDRiesgoLaboral != 0) ? cuenta.IDRiesgoLaboral.ToString() : "1";
                        DropDownListDependencia.SelectedValue = cuenta.IDDependencia.ToString();

                        //Validar si tiene mas cuentas en el mes


                        //calcularValoresLiquidacion();
                    //}
                }
            }

            if (ButtonID.Contains("TextBoxValorFactura"))
            {
                calcularValoresLiquidacion();
                ViewState["valor_factura"] = TextBoxValorFactura.Text;
            }

            if (ButtonID.Contains("CheckBoxIVA"))
            {
                if (CheckBoxIVA.Checked)
                {
                    TextBoxValorIVA.Visible = true;
                    LabelIVA.Visible = true;
                    calcularValorIVA();

                }
                else
                {
                    TextBoxValorIVA.Visible = false;
                    LabelIVA.Visible = false;
                    //TextBoxValorIVA.Text = "";
                    devolverValorIVA();
                }
                calcularValoresLiquidacion();
            }

        }

        if (Request.QueryString["editar"] != null)
        {
            ButtonGuardar.Visible = false;
            ButtonEditar.Visible = true;
            

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ListarEditarCuentas.aspx");
            }
            else
            {
                int id_cuenta = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                LabelTitulo.Text = "Editar cuenta #" + Request.QueryString["id"].ToString();
                ViewState["id_cuenta"] = id_cuenta;
                if (!IsPostBack)
                {
                    llenarControles(id_cuenta);
                }
            }

        }
        else
        {
            LabelTitulo.Text = "Radicaci&oacute;n";
            ButtonGuardar.Visible = true;
            ButtonEditar.Visible = false;

        }

        if (IsPostBack)
        {
            //Si es edicion de cuenta
            if (ViewState["id_cuenta"] != null)
            {
                if (ViewState["ValorInicial"].ToString() != TextBoxValorFactura.Text)
                {
                    LiteralAlerta.Text = "<div class='alert alert-danger'>Si realiza un cambio en el valor de la factura tendra que ser liquidada de nuevo.</div>";
                }
                else
                {
                    LiteralAlerta.Text = "";
                }
            }
        }


    }

    private void calcularValorIVA()
    {
        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", "").Replace("$", ""));
        double valorIVA = conf.CalcularIVA(valorFactura);
        double valorFacturaConIVA = valorFactura - valorIVA;
        TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)valorFacturaConIVA).Replace("$ ", "").Replace("$", "");
        TextBoxValorIVA.Text = String.Format("{0:C}", (decimal)valorIVA).Replace("$ ", "").Replace("$", "");
    }

    private void devolverValorIVA()
    {
        //ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        //conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", "").Replace("$", ""));
        double valorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text.Replace("$ ", ""));
        double valorTotal = valorFactura + valorIVA;
        //TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)valorTotal).Replace("$ ", "");
        //if (ViewState["valor_factura"] != null)
        TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)valorTotal).Replace("$ ", "").Replace("$", "");
        //else
        //    TextBoxValorFactura.Text = "";

        TextBoxValorIVA.Text = "";
    }


    private void calcularValoresLiquidacion()
    {


        ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
        InteresVivienda interesV = new InteresVivienda(TextBoxNumeroDocumento.Text, DateTime.Now.Year);

        conf.obtenerDatos();
        double valorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text.Replace("$ ", "").Replace("$", ""));
        //double valorIBC = Math.Round( conf.CalcularIBC(valorFactura),System.MidpointRounding.AwayFromZero);
        double valorIBC = Math.Ceiling(conf.CalcularIBC(valorFactura));
        double valorSalud = conf.CalcularSalud(valorIBC);
        double valorPension = conf.CalcularPension(valorIBC, false, "", 0);
        double porcentajeRiesgoLaboral = ConfiguracionLiquidacion.obtenerPorcentajeRiesgoLaboral(Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text));
        double valorARL = conf.CalcularARL(valorIBC,porcentajeRiesgoLaboral);

        /*

        LabelValorTotal.Text = String.Format("{0:C}", (decimal)valorFactura).Replace("$ ", "$");
        LabelIBC.Text = String.Format("{0:C}", (decimal)valorIBC).Replace("$ ", "$");
        LabelSalud.Text = String.Format("{0:C}", (decimal)valorSalud).Replace("$ ", "$");
        LabelPension.Text = String.Format("{0:C}", (decimal)valorPension).Replace("$ ", "$");
        LabelARL.Text = String.Format("{0:C}", (decimal)valorARL).Replace("$ ", "$");

        */
    }



    private void llenarControles(int id_cuenta)
    {
        Cuenta cuenta = new Cuenta(id_cuenta);

       // DropDownListTipoSolicitud.SelectedValue = cuenta.IDTipoSolicitud.ToString();
        DropDownListTipoPersona.SelectedValue = cuenta.IDTipoPersona.ToString();
        DropDownListTipoDocumento.SelectedValue = cuenta.IDTipoDocumento.ToString();
        TextBoxNumeroDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
        TextBoxNombres.Text = cuenta.NombreBeneficiario;
        TextBoxCorreo.Text = cuenta.CorreoCuenta;
        TextBoxNumeroContrato.Text = cuenta.NumeroContrato;
        TextBoxValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura).Replace("$ ", "$").Replace("$", "");
        TextBoxNumeroRP.Text = cuenta.NumeroRP;
        TextBoxNumeroPago.Text = cuenta.NumeroPago;
        TextBoxNumFactura.Text = cuenta.NumeroFactura;
        DropDownListRiesgoLaboral.SelectedValue = (cuenta.IDRiesgoLaboral != 0) ? cuenta.IDRiesgoLaboral.ToString() : "1";
        DropDownListEntidad.SelectedValue = cuenta.IDEntidad.ToString();
        DropDownListEntidad.Enabled = false;
        DropDownListDependencia.SelectedValue = cuenta.IDDependencia.ToString();
        TextBoxCodigoCCP.Text = cuenta.CodigoCCP;


        if (cuenta.CuentaPorPagar != "")
        {
            LabelCuentaPorPagar.Text = "Cuenta Por Pagar # " + cuenta.CuentaPorPagar;
            LabelCuentaPorPagar.Visible = true;
        }
        else
        {
            LabelCuentaPorPagar.Text = "";
            LabelCuentaPorPagar.Visible = false;
        }


        if (cuenta.AplicaIVA == 1)
        {
            TextBoxValorIVA.Visible = true;
            TextBoxValorIVA.Text = String.Format("{0:C}", (decimal)cuenta.ValorIVA).Replace("$ ", "$").Replace("$", ""); 
            CheckBoxIVA.Checked = true;

        }
        else
        {
            double total = cuenta.ValorFactura + cuenta.ValorIVA;
            ViewState["valor_factura"] = String.Format("{0:C}", (decimal)total).Replace("$ ", "$").Replace("$", ""); 
        }

        ViewState["ValorInicial"] = TextBoxValorFactura.Text;
        ViewState["valor_factura"] = TextBoxValorFactura.Text;

    }


    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        Cuenta cuenta = new Cuenta();

        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;

        //cuenta.OrdenPago = TextBoxOrdenPago.Text;
        cuenta.IDTipoDocumento = Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text);
        cuenta.NumeroDocumentoBeneficiaro = TextBoxNumeroDocumento.Text;
        cuenta.NombreBeneficiario = TextBoxNombres.Text;
        cuenta.NumeroPago = TextBoxNumeroPago.Text;
        cuenta.ValorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text);
        //cuenta.CuentaPorPagar = TextBoxCuentaPorPagar.Text;
        cuenta.Observaciones = "";
        cuenta.AsignadoA = "";
        cuenta.Usuario = nombre_usuario;
        cuenta.CorreoCuenta = TextBoxCorreo.Text;
        //cuenta.IDTipoSolicitud = Utiles.validarNumeroToInt(DropDownListTipoSolicitud.Text);
        cuenta.NumeroContrato = TextBoxNumeroContrato.Text;
        cuenta.NumeroRP = TextBoxNumeroRP.Text;
        cuenta.NumeroFactura = TextBoxNumFactura.Text;
        cuenta.IDRiesgoLaboral = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
        cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);
        cuenta.IDDependencia = Utiles.validarNumeroToInt(DropDownListDependencia.Text);
        cuenta.IDTipoPersona = Utiles.validarNumeroToInt(DropDownListTipoPersona.Text);
        cuenta.CodigoCCP = TextBoxCodigoCCP.Text;

        if (CheckBoxIVA.Checked)
        {
            cuenta.ValorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text);
            cuenta.AplicaIVA = 1;
        }

        //cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);
        //cuenta.FechaRadicado = Utiles.validarStringToDate(TextBoxFechaInicio.Text);
        //cuenta.FechaRadicado = DateTime.Now;

        try
        {

            cuenta.insertar();

            if (cuenta.IDRegistro > 0)
            {

                cuenta.insertarLOG(nombre_usuario, "", "Radicacion cuenta:" + cuenta.IDRegistro, "Registro");
                //cuenta.correoInscripcion();

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Registro adicionado exitosamente. Numero de registro: " + cuenta.IDRegistro.ToString() + "');window.location.href='Radicacion.aspx';", true);
                //Response.Write("<script>alert('Registro adicionado exitosamente. Numero de registro: " + cuenta.IDRegistro.ToString() + "');window.location.href='Radicacion.aspx';</script>");               


            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('El registro no pudo ser adicionado.');window.history.back();", true);
                //Response.Write("<script>alert('El registro no pudo ser adicionado.');window.history.back();</script>");
            }
        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();", true);
            //Response.Write("<script>alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }
    }



    protected void ButtonEditar_Click(object sender, System.EventArgs e)
    {

        int id_cuenta = Utiles.validarNumeroToInt(ViewState["id_cuenta"].ToString());
        Cuenta cuenta = new Cuenta(id_cuenta);

        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;


       

        //cuenta.OrdenPago = TextBoxOrdenPago.Text;
        cuenta.IDTipoDocumento = Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text);
        cuenta.NumeroDocumentoBeneficiaro = TextBoxNumeroDocumento.Text;
        cuenta.NombreBeneficiario = TextBoxNombres.Text;
        cuenta.NumeroPago = TextBoxNumeroPago.Text;
        cuenta.ValorFactura = Utiles.validarNumeroToDouble(TextBoxValorFactura.Text);
        //cuenta.CuentaPorPagar = TextBoxCuentaPorPagar.Text;
        cuenta.Observaciones = "";
        cuenta.AsignadoA = "";
        cuenta.Usuario = nombre_usuario;
        cuenta.CorreoCuenta = TextBoxCorreo.Text;
        //cuenta.IDTipoSolicitud = Utiles.validarNumeroToInt(DropDownListTipoSolicitud.Text);
        cuenta.NumeroContrato = TextBoxNumeroContrato.Text;
        cuenta.NumeroRP = TextBoxNumeroRP.Text;
        cuenta.NumeroFactura = TextBoxNumFactura.Text;
        cuenta.IDRiesgoLaboral = Utiles.validarNumeroToInt(DropDownListRiesgoLaboral.Text);
        cuenta.IDDependencia = Utiles.validarNumeroToInt(DropDownListDependencia.Text);
        cuenta.IDTipoPersona = Utiles.validarNumeroToInt(DropDownListTipoPersona.Text);
        cuenta.CodigoCCP = TextBoxCodigoCCP.Text;
        //cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);

        if (!CheckBoxIVA.Checked)
        {
            cuenta.AplicaIVA = 0;
            cuenta.ValorIVA = 0;
        }
        else
        {
            cuenta.AplicaIVA = 1;
            cuenta.ValorIVA = Utiles.validarNumeroToDouble(TextBoxValorIVA.Text); ;
        }


        if (LiteralAlerta.Text != "")
        {
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.eliminar(id_cuenta);
            cuenta.insertarLOG(nombre_usuario, "Se realizo un cambio en el valor, requiere nueva liquidacion.", "Cambio de Valor", "Registro");
        }
        //cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);
        //cuenta.FechaRadicado = Utiles.validarStringToDate(TextBoxFechaInicio.Text);
        //cuenta.FechaRadicado = DateTime.Now;

        try
        {

            int resp = cuenta.editar();

            if (resp > 0)
            {
                cuenta.insertarLOG(nombre_usuario, "", "Cuenta editada", "Registro");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Registro actualizado exitosamente.');window.location.href='ListarEditarCuentas.aspx';", true);
                //Response.Write("<script>alert('Registro adicionado exitosamente. Numero de registro: " + cuenta.IDRegistro.ToString() + "');window.location.href='Radicacion.aspx';</script>");
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('La informacion no fue actualizada.');window.location.href='ListarEditarCuentas.aspx';", true);

            }

        }
        catch (Exception ex)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();", true);
            //Response.Write("<script>alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }
    }


    protected void ButtonRecalcular_Click(object sender, System.EventArgs e)
    {

    }
}