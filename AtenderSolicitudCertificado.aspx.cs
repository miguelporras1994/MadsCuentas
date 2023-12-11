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
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


public partial class AtenderSolicitudCertificado : System.Web.UI.Page
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


        if (Request.QueryString["id_solicitud"] == null)
        {
            Response.Redirect("RadicadosAdjuntar.aspx");
        }
        else
        {

            ViewState["id_solicitud"] = Request.QueryString["id_solicitud"].ToString();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];

            if (!IsPostBack)
            {
                //LLenar datos generales de la cuenta
                int id_solicitud = Utiles.validarNumeroToInt(Request.QueryString["id_solicitud"].ToString());
                ViewState["id_solicitud"] = id_solicitud;
                CertificadoRetenciones cert = new CertificadoRetenciones();
                DataTable datos = cert.consultarSolicitud(id_solicitud);
                LabelCedula.Text = datos.Rows[0]["CEDULA"].ToString();
                LabelCorreo.Text = datos.Rows[0]["CORREO"].ToString();
                LabelAno.Text = datos.Rows[0]["ANO"].ToString();
                LabelFecha.Text = datos.Rows[0]["FECHA"].ToString();
                //cert.correoCertificado(id_solicitud);

               
            }


            //SqlDataSourceAdjuntos.SelectCommand = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_REPORTE = " + ViewState["id_reporte"].ToString();
            //GridViewAdjuntos.DataSource = SqlDataSourceAdjuntos;
            //GridViewAdjuntos.DataSourceID = "GridViewAdjuntos";
            //GridViewAdjuntos.DataBind();

            
        }
    }





    protected void btnUpload_Click(object sender, EventArgs e)
    {

        HttpPostedFile uploadedFile;
        uploadedFile = fileUploadImage.PostedFile;
        bool enviado = true;
        int id_reporte = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());
        string mensaje_error = "";

        try
        {
            if (uploadedFile != null)
            {
                if (uploadedFile.ContentLength > 0)
                {
                    string resp = UploadFile(uploadedFile, id_reporte);
                }
            }
        }
        catch
        {
            enviado = false;
        }

        CertificadoRetenciones cert = new CertificadoRetenciones();
        int id_solicitud = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());

        try
        {
            cert.correoCertificado(id_solicitud);
        }
        catch(Exception ex)
        {
            mensaje_error = ex.Message.Normalize();
            enviado = false;
        }

        if (!enviado)
        {
            cert.dejarPendiente(id_solicitud);
            Response.Write("<script>alert('Se genero un error al enviar el certificado:" + mensaje_error + "');location.href='listarPendientesCertificados.aspx';</script>");
            
        }
        else
        {
            Response.Write("<script>alert('El certificado se envio correctamente');location.href='listarPendientesCertificados.aspx';</script>");
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


            file.SaveAs(MapPath("Certificados" + "/" + nombreArchivo));

            CertificadoRetenciones cert = new CertificadoRetenciones();
            cert.atender(id_reporte, nombre_usuario, nombreArchivo);

            
        }
        catch { }



        return nombreArchivo;

    }


    protected void btnProcessData_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        //lblMessage.Visible = true;
    }
    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;
        bool enviado = true;
        string mensaje_error = "";

        CertificadoRetenciones cert = new CertificadoRetenciones();
        int id_solicitud = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());

        try
        {
            cert.correoCertificadoSinAdjunto(id_solicitud,TextBoxObservaciones.Text);
        }
        catch (Exception ex)
        {
            mensaje_error = ex.Message.Normalize();
            enviado = false;
        }

        try
        {
            cert.atenderSinAdjunto(id_solicitud, nombre_usuario, TextBoxObservaciones.Text);
        }
        catch (Exception ex)
        {
            mensaje_error = ex.Message.Normalize();
            enviado = false;
        }

        if (!enviado)
        {
            cert.dejarPendiente(id_solicitud);
            Response.Write("<script>alert('Se generó un error al enviar la notificación:" + mensaje_error + "');location.href='listarPendientesCertificados.aspx';</script>");

        }
        else
        {
            Response.Write("<script>alert('La notificación se envió correctamente');location.href='listarPendientesCertificados.aspx';</script>");
        }
    }
}