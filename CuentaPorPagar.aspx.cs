using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;

public partial class CuentaPorPagar : System.Web.UI.Page
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
                DropDownListEntidad.SelectedValue = cuenta.IDEntidad.ToString();
                
                //LabelTipoDocumento.Text = Utiles.obtenerNombreItem("TIPO_DOCUMENTO", "ID_TIPO_DOC", "NOMBRE", cuenta.IDTipoDocumento.ToString());
                //LabelNumDocumento.Text = cuenta.NumeroDocumentoBeneficiaro;
                //LabelNombreBeneficiario.Text = cuenta.NombreBeneficiario;
                //LabelValorFactura.Text = String.Format("{0:C}", (decimal)cuenta.ValorFactura);
                //LabelNumPago.Text = cuenta.NumeroPago;
                //LabelFechaRadicado.Text = cuenta.FechaRadicado.ToShortDateString() + " " + cuenta.FechaRadicado.ToLongTimeString();
                ////LabelFechaRecibidoContabilidad.Text = cuenta.FechaRecibidoContabilidad.ToShortDateString() + " " + cuenta.FechaRecibidoContabilidad.ToLongTimeString();
                ////LabelNumObligacion.Text = cuenta.NumeroObligacion;
                //LabelAsignadoA.Text = cuenta.AsignadoA;
                
                //LabelCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                //LabelFechaRecibido.Text = DateTime.Now.ToShortDateString();

                if (Request.QueryString["editar"] != null)
                {
                    TextBoxCuentaPorPagar.Text = cuenta.CuentaPorPagar;
                    string adjunto = cuenta.obtenerNombreAdjunto();
                    LiteralAdjunto.Text = (adjunto.Trim() != "") ? ("Si desea actualizar el adjunto actual: <a href='adj_cuentas/" + adjunto + "'>" + adjunto + "</a> ,seleccione un nuevo archivo") : "";
                    ButtonGuardar.Text = "Actualizar";
                }

                ////Adjuntos

                //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];

                //SqlDataSourceAdjuntos.ConnectionString = settings.ConnectionString;
                //SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_registro"].ToString();

                //GridViewAdjuntos.DataSourceID = "SqlDataSourceAdjuntos";


            }
        }

    }

    protected string UploadFile(HttpPostedFile file, int id_reporte)
    {
        string fileName = null;
        int lastPos = file.FileName.LastIndexOf('\\');


        fileName = file.FileName.Substring(++lastPos);
        string nombreArchivo = id_reporte + "-" + fileName;
        file.SaveAs(MapPath("adj_cuentas" + "/" + nombreArchivo));
        Cuenta.insertarAdjuntoCuentaPorPagar(id_reporte, nombreArchivo);
        
           
        return nombreArchivo;

    }

    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {

        try
        {

            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);
            cuenta.CuentaPorPagar = TextBoxCuentaPorPagar.Text;
            cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);

            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;


            if (!cuenta.cuentaPorPagarExiste())
            {

                int resp = cuenta.actualizarCuentaPorPagar();

                if (resp > 0)
                {

                    if (ButtonGuardar.Text == "Actualizar")
                    {
                        cuenta.insertarLOG(usuario.Alias, "", "Actualizacion cuenta por pagar: " + TextBoxCuentaPorPagar.Text, "Registro");
                        Response.Write("<script>alert('La informacion se actualizo correctamente');window.location.href='ListarCuentasPorPagar.aspx';</script>");
                    }
                    else
                    {
                        cuenta.insertarLOG(usuario.Alias, "", "Registro cuenta por pagar: " + TextBoxCuentaPorPagar.Text, "Registro");
                        Response.Write("<script>alert('La informacion se actualizo correctamente');window.location.href='ListarPendientesCuentasPorPagar.aspx';</script>");

                    }

                    HttpPostedFile uploadedFile;
                    uploadedFile = FileUploadAdj.PostedFile;

                    if (uploadedFile.ContentLength > 0)
                    {
                        UploadFile(uploadedFile, id_registro);
                    }
                }
                else
                {

                    Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion');window.history.back();</script>");

                }
            }
            else
            {

                Response.Write("<script>alert('La cuenta por pagar ya se encuentra registrada');window.history.back();</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }
        
    
    }
}