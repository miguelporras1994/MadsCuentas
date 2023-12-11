using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

public partial class DividirCuenta : System.Web.UI.Page
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


        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("RadicadosAdjuntar.aspx");
        }
        else
        {

            ViewState["id_reporte"] = Request.QueryString["id"].ToString();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];

            if (!IsPostBack)
            {
                //LLenar datos generales de la cuenta
                int id_registro = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                ViewState["id_registro"] = id_registro;
                Cuenta cuenta = new Cuenta(id_registro);

                if (cuenta.Dividida == 1)
                {
                    Response.Write("<script>alert('La cuenta ya se encuentra dividida');window.location.href='ListarCuentasDividirPago.aspx';</script>");
                    return;
                }
                /*
                LabelOrdenPago.Text = cuenta.OrdenPago;
                LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                LabelNumPago.Text = cuenta.NumeroPago;
                LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                //LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                //LabelNumObligacion.Text = cuenta.NumeroObligacion;
                LabelAsignadoA.Text = cuenta.AsignadoA;
                LabelObservaciones.Text = cuenta.Observaciones;
                 * */
            }
            


        }
    }



    protected void ButtonDividir_Click(object sender, EventArgs e)
    {

        try
        {
            mostrarControlesPagos();
        }
        catch { }

    }

    private void mostrarControlesPagos()
    {

        TableCell cellTitulo1 = new TableCell();
        cellTitulo1.BorderStyle = BorderStyle.Solid;
        cellTitulo1.BorderWidth = Unit.Pixel(1);
        cellTitulo1.Text = "Observaciones";


        TableCell cellTitulo2 = new TableCell();
        cellTitulo2.BorderStyle = BorderStyle.Solid;
        cellTitulo2.BorderWidth = Unit.Pixel(1);
        cellTitulo2.Text = "Monto";

        TableRow trTitulo = new TableRow();

        Table1.Rows.Add(trTitulo);

        trTitulo.Controls.Add(cellTitulo1);
        trTitulo.Controls.Add(cellTitulo2);

        int num_pagos = Utiles.validarNumeroToInt(TextBoxNumPagos.Text);

        if (num_pagos > 0)
        {

            for (int i = 1; i <= Utiles.validarNumeroToInt(TextBoxNumPagos.Text); i++)
            {

                TableCell cell1 = new TableCell();
                cell1.BorderStyle = BorderStyle.Solid;
                cell1.BorderWidth = Unit.Pixel(1);

                TextBox txt_observaciones = new TextBox();
                txt_observaciones.ID = "TextBoxObservaciones_" + i.ToString();
                txt_observaciones.Text = "PAGO DIVIDIDO DE CUENTA: " + ViewState["id_reporte"].ToString();
                txt_observaciones.Attributes.Add("Width", "100px");
                txt_observaciones.TextMode = TextBoxMode.MultiLine;

                Label label = new Label();
                label.ID = "label_" + i.ToString();
                label.Text = i.ToString();

                cell1.Controls.Add(label);
                cell1.Controls.Add(txt_observaciones);

                TableCell cell2 = new TableCell();
                cell2.BorderStyle = BorderStyle.Solid;
                cell2.BorderWidth = Unit.Pixel(1);




                TextBox txt_valor = new TextBox();
                txt_valor.ID = "TextBoxValor_" + i.ToString();
                txt_valor.CssClass = "money";
                txt_valor.Attributes.Add("Width", "60px");


                cell2.Controls.Add(txt_valor);

                TableRow tr = new TableRow();

                Table1.Rows.Add(tr);

                tr.Controls.Add(cell1);
                tr.Controls.Add(cell2);

            }
        }

    }

   

    protected void btnProcessData_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        //lblMessage.Visible = true;
    }
    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        
        string observacion = "";
        string valor_pago = "";
       

        string key = "";
        string valor = "";


        int loop1;

        int id_registro = Utiles.validarNumeroToInt( ViewState["id_registro"].ToString());
        Cuenta cuenta = new Cuenta(id_registro);
        double valor_factura = cuenta.ValorFactura;
        double valor_pagos = 0;
        List<Pago> ls = new List<Pago>();

        string nombre_usuario = "";

        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            nombre_usuario = usuario.Alias;

        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

        //Load Form variables into NameValueCollection variable.
        //coll = Request.Form.co;
        // Get names of all forms into a string array.
        //String[] arr1 = coll.AllKeys;
        try
        {
            for (loop1 = 0; loop1 < Request.Form.Count; loop1++)
            {
                key = Request.Form.GetKey(loop1);
                int pos = key.LastIndexOf("_");
                int longitud = key.Length;

                if (key.Contains("TextBoxObservaciones"))
                {
                    observacion = Request.Form[loop1];
                    valor_pago = Request.Form[loop1 + 1];

                    Pago pago = new Pago();

                    pago.Observacion = observacion;
                    pago.Valor = Utiles.validarNumeroToDouble(valor_pago);
                    ls.Add(pago);

                    valor_pagos = valor_pagos + Utiles.validarNumeroToDouble(valor_pago);
                    
                }
                /*
                if (key.Contains("TextBoxValor"))
                {
                    valor_pago = Request.Form[key];
                    valor = key.Substring(pos + 1, longitud - pos - 1);
                }*/

                

                

            }
            /*
            if (valor_pagos != cuenta.ValorFactura)
            {
                Response.Write("<script>alert('La suma de los valores ingresados debe ser igual al valor de la factura');</script>");


            }
            else
            {*/
                try
                {
                    //Marcar la cuenta principal como dividida
                    cuenta.Dividir();
                    cuenta.insertarLOG(nombre_usuario, "", "Dividida en " + TextBoxNumPagos.Text + " pagos", "Registro");

                    //crear cuentas clonadas por cada pago
                    foreach (Pago pago in ls)
                    {
                        cuenta.NumeroPago = pago.Observacion;
                        cuenta.ValorFactura = pago.Valor;
                        cuenta.IDCuentaPrincipal = id_registro;


                        cuenta.insertar();
                        cuenta.SetIDCuentaPrincipal();
                        cuenta.insertarLOG(nombre_usuario, "", "Pago dividido de Cuenta: " + id_registro.ToString(), "Registro");

                        
                    }
                    Response.Write("<script>alert('Informacion guardada exitosamente');window.location.href='ListarCuentasDividirPago.aspx';</script>");
                }
                catch
                {
                    throw new Exception();

                }
            }
        //}
        catch (Exception ex)
        {
            Response.Write("<script>alert('Se produjo un error al intentar guardar la informacion: " + ex.Message.Normalize() + "');window.location.href='" + Request.ServerVariables["SCRIPT_NAME"] + "';</script>");
        }

        

    }
}

public class Pago
{

    string observacion = "";
    double valor = 0;

    public double Valor
    {

        get{ return valor;}
        set{ valor = value;}
    }


    public string Observacion
    {

        get { return observacion; }
        set { observacion = value; }
    }


}