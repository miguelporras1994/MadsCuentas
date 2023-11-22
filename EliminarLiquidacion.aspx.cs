﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Data;

public partial class EliminarLiquidacion : System.Web.UI.Page
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
                /*
                LabelOrdenPago.Text = cuenta.OrdenPago;
                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                LabelNumObligacion.Text = cuenta.NumeroObligacion;
                LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();
                string adjunto = cuenta.obtenerNombreAdjunto();
                LiteralAdjunto.Text = (adjunto.Trim() != "") ? ("<a href='adj_cuentas/" + adjunto + "'>" + adjunto + "</a>") : "";
                 * */

                if (Request.QueryString["Formulario"] == null)
                {

                    ViewState["Formulario"] = "Formularios.aspx";
                }
                else
                {
                    ViewState["Formulario"] = Request.QueryString["Formulario"].ToString();

                }

                if (Request.QueryString["Fuente"] == null)
                {

                    ViewState["Fuente"] = "";
                }
                else
                {
                    ViewState["Fuente"] = Request.QueryString["Fuente"].ToString();

                }

            }
            else
            {

                Response.Redirect("Formularios.aspx");
            }
        }
    }
    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;
        int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro"].ToString());
        Cuenta cuenta = new Cuenta(id_registro);
        Liquidacion liquidacion = new Liquidacion(id_registro);

        try
        {
            int res = 0;
            string tipo_devolucion = "";

            int resp = liquidacion.eliminar(id_registro);

            if (resp > 0)
            {
                cuenta.insertarLOG(usuario.Alias, TextBoxObservaciones.Text, "Liquidacion eliminada", ViewState["Fuente"].ToString());
                Response.Write("<script>alert('La liquidacion fue eliminada con exito.');window.location.href='" + ViewState["Formulario"].ToString() + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('La liquidacion no pudo ser eliminada.');window.location.href='" + ViewState["Formulario"].ToString() + "';</script>");

            }
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Se genero un error al tratar de eliminar la liquidacion:" + ex.Message.Normalize() + "');window.history.back();</script>");
        }

    }
}