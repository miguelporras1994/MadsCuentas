﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecibidoTesoreria : System.Web.UI.Page
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

                LabelOrdenPago.Text = cuenta.OrdenPago;
                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                LabelNumObligacion.Text = cuenta.NumeroObligacion;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();

            }
        }

    }
    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {

        int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro"].ToString());
        Cuenta cuenta = new Cuenta(id_registro);

        cuenta.FechaOrdenPago = Utiles.validarStringToDate( TextBoxFechaPago.Text);

        int resp = cuenta.recibidoTesoreria();

        try
        {

            if (resp > 0)
            {

                Response.Write("<script>alert('Registro actualizado exitosamente.');window.location.href='PendientesTesoreria.aspx';</script>");
            }
            else
            {

                Response.Write("<script>alert('El registro no pudo ser actualizado.');window.history.back();</script>");
            }
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Se genero un error al tratar de guardar el registro:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }


    }
}