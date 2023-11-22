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

public partial class RadicadosAdjuntar : System.Web.UI.Page
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
            }


            //SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_reporte"].ToString();
            //GridViewAdjuntos.DataSource = SqlDataSourceAdjuntos;
            //GridViewAdjuntos.DataSourceID = "GridViewAdjuntos";
            //GridViewAdjuntos.DataBind();

            SqlDataSourceAdjuntos.ConnectionString = settings.ConnectionString;
            SqlDataSourceAdjuntos.SelectCommand = "SELECT ID_ADJUNTO,ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_reporte"].ToString();

            GridViewAdjuntos.DataSourceID = "SqlDataSourceAdjuntos";
        }
    }

    protected void GridViewAdjuntos_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string item = e.Row.Cells[2].Text;
            foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Esta seguro que quiere borrar el adjunto ?')){ return false; };";
                }
            }
        }
    }

    

    protected void GridViewAdjuntos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            // get the categoryID of the clicked row
            int categoryID = Convert.ToInt32(e.CommandArgument);
            // Delete the record 
            eliminarAdjunto(categoryID);
            // Implement this on your own :) 
        }
    }

    private void eliminarAdjunto(int id_adjunto)
    {
        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);
            string nombre_archivo = cuenta.obtenerNombreAdjunto(id_adjunto);
            cuenta.insertarLOG(nombre_usuario, "Adjunto '" + nombre_archivo + "' eliminado" ,"Adjunto " + id_registro, "Adjuntos");

            try
            {
                File.Delete(MapPath("adj_cuentas" + "/" + nombre_archivo));
            }
            catch { }

        }
        catch
        {}

    }

    protected void GridViewAdjuntos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int categoryID = (int)GridViewAdjuntos.DataKeys[e.RowIndex].Value;
        eliminarAdjunto(categoryID);
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {

        HttpPostedFile uploadedFile;
        uploadedFile = fileUploadImage.PostedFile;
        int id_reporte = Utiles.validarNumeroToInt(ViewState["id_reporte"].ToString());

        if (uploadedFile != null)
        {
            if (uploadedFile.ContentLength > 0)
            {
                string resp = UploadFile(uploadedFile, id_reporte);
            }
        }

        //if (uploadedFile.ContentLength > 0)
        //{

        //    string fileName = null;
        //    int lastPos = uploadedFile.FileName.LastIndexOf('\\');


        //    fileName = uploadedFile.FileName.Substring(++lastPos);
        //    string nombreArchivo = id_reporte + "-" + fileName;

        //    string fileName = fileUploadImage.FileName;
        //    fileUploadImage.SaveAs("adj_cuentas/" + fileName);
        //    img.ImageUrl = "adj_cuentas/" + fileName;
        //}
    }

    protected string UploadFile(HttpPostedFile file, int id_reporte)
    {

        string nombreArchivo = "";
        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;

        try
        {
            string fileName = null;
            int lastPos = file.FileName.LastIndexOf('\\');


            fileName = file.FileName.Substring(++lastPos);
            nombreArchivo = id_reporte + "-" + fileName;


            file.SaveAs(MapPath("adj_cuentas" + "/" + nombreArchivo));

            Cuenta.insertarAdjuntoCuenta(id_reporte, nombreArchivo);

            Cuenta cuenta = new Cuenta(id_reporte);
            cuenta.insertarLOG(nombre_usuario,"Adjunto archivo '" + nombreArchivo + "' a cuenta:" + id_reporte , "Adjunto " + id_reporte, "Adjuntos");
            //Actividad.insertarAdjuntoEntrenamiento(id_reporte, nombreArchivo);
        }
        catch { }

        

        return nombreArchivo;

    }


    protected void btnProcessData_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        //lblMessage.Visible = true;
    }
}