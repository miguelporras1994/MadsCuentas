using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reasignar : System.Web.UI.Page
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
                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                */
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();
                string adjunto = cuenta.obtenerNombreAdjunto();
                

                ViewState["Formulario"] = "ListarPendientesCuentasPorPagar.aspx";

                if (Request.QueryString["Formulario"] != null)
                {
                    ViewState["Formulario"] = Request.QueryString["Formulario"];
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


        if (DropDownListAsignado.Text == "0")
        {
            Response.Write("<script>alert('Por favor seleccione a quien se desea asignar la cuenta.');</script>");
            return;
        }

        try
        {
            int res = cuenta.reasignar(DropDownListAsignado.SelectedValue);

            if (res > 0)
            {
                cuenta.insertarLOG(usuario.Alias, "Cuenta reasignada a: " + DropDownListAsignado.Text, "Reasignacion", ViewState["Fuente"].ToString());
                //cuenta.correoDevolucion(TextBoxObservaciones.Text);

                Response.Write("<script>alert('La cuenta fue reasingada con exito.');window.location.href='" + ViewState["Formulario"].ToString() + "';</script>");

            }
            else
            {
                Response.Write("<script>alert('La cuenta no se reasigno.');window.location.href='" + ViewState["Formulario"].ToString() + "';</script>");

            }
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Se genero un error al tratar de devolver la cuenta:" + ex.Message.Normalize() + "');window.history.back();</script>");
        }

    }
}