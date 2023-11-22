using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.IO;
using System.ServiceModel;
using RestSharp;
using RestSharp.Authenticators;

/// <summary>
/// Descripción breve de DocumentoFirma
/// </summary>

public class DocumentoFirma
{

    public string ID_POLITICA { get; set; }
    public string PDF { get; set; }

    public DocumentoFirma()
    {

    }

    public bool SaveFileFromURL(string url, string destinationFileName, int timeoutInSeconds)
    {
        //try
        //{

        //    using (var client = new WebClient())
        //    {
        //        client.DownloadFile(url, destinationFileName);
        //    }

        //    return true;

        //}
        //catch(Exception ex)
        //{
        //    return false;
        //}


        //LOG log = new LOG();

        // Create a web request to the URL
        HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(url);
        MyRequest.Timeout = timeoutInSeconds * 1000;
        MyRequest.MaximumAutomaticRedirections = 10;
        MyRequest.AllowAutoRedirect = true;

        try
        {
            // Get the web response
            //HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();

            // Make sure the response is valid
            //if (HttpStatusCode.OK == MyResponse.StatusCode)
            //{
            MyRequest.CookieContainer = new CookieContainer();
            MyRequest.Method = "GET";
            using (WebResponse response = MyRequest.GetResponse())
            {
                // Open the response stream
                using (Stream MyResponseStream = response.GetResponseStream())
                {
                    // Open the destination file
                    using (FileStream MyFileStream = new FileStream(destinationFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        // Create a 4K buffer to chunk the file
                        byte[] MyBuffer = new byte[4096];
                        int BytesRead;
                        // Read the chunk of the web response into the buffer
                        while (0 < (BytesRead = MyResponseStream.Read(MyBuffer, 0, MyBuffer.Length)))
                        {   // Write the chunk from the buffer to the file  
                            MyFileStream.Write(MyBuffer, 0, BytesRead);
                        }
                    }
                }
            }
        }
        catch (Exception err)
        {
            //log.insertarLOG("app", "Error guardando documento firma: " + err.Message.Normalize(), "ErrorPDF", "ClassDocumento", 0);
            throw new Exception("Error saving file from URL:" + err.Message, err);
        }
        return true;

    }

    public string TomarConsecutivo(int id_entidad)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "TOMAR_CONSECUTIVO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@ID_ENTIDAD", SqlDbType.Int).Value = id_entidad;

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "0";
        }
    }

    public string TomarConsecutivo()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "TOMAR_CONSECUTIVO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "0";
        }
    }


    public static string ConsecutivoFacturaActual()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "OBTENER_CONSECUTIVO_FACTURA";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "";
        }
    }

    public static string ConsecutivoFacturaActual(int id_entidad)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "OBTENER_CONSECUTIVO_FACTURA";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@ID_ENTIDAD", SqlDbType.Int).Value = id_entidad;

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "";
        }
    }

    public string DevolverConsecutivo(int id_entidad)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "DEVOLVER_CONSECUTIVO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@ID_ENTIDAD", SqlDbType.Int).Value = id_entidad;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "0";
        }
    }

    public string DevolverConsecutivo()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "DEVOLVER_CONSECUTIVO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "0";
        }
    }

    public static string ObtenerRangoFacturaElectronica(int id_entidad)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_RANGO_FACTURA_E";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@ID_ENTIDAD", SqlDbType.Int).Value = id_entidad;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "0";
        }
    }

    public int ActualizarConsecutivoFactura(int id_registro, string consecutivo)
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"ACTUALIZAR_CONSECUTIVO_FACTURA";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@CONSECUTIVO", SqlDbType.VarChar).Value = consecutivo;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }

    public string GenerarDocFirmaFacturaElectronica(int id_registro)  //ERROR E1001  
    {
        Cuenta cuenta = new Cuenta(id_registro);
        LOG log = new LOG();
        DataTable dtFirma = new DataTable();

        string consecutivo = this.TomarConsecutivo();
        //string politica = ConfigurationSettings.AppSettings["politica_firma_factura_e"].ToString();
        string path = ConfigurationSettings.AppSettings["ruta_facturas_e"].ToString();

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string url = ConfigurationSettings.AppSettings["url_sitio"] + "/FacturaElectronicaPDF.aspx?id=" + id_registro.ToString() + "&consecutivo=" + consecutivo;


        string nombreArchivo = "DEQ_" + consecutivo + ".pdf";
        //string destinationFileName = "Adjuntos/" + nombreArchivo;
        string destinationFileName = path + "/" + nombreArchivo;
        int timeoutInSeconds = 10;



        //int id_informe = cuenta.IDInforme;


       

        try
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            // Use double the default value
            binding.MaxReceivedMessageSize = 65536 * 2;

            bool resp = SaveFileFromURL(url, destinationFileName, timeoutInSeconds);

            
            


           // ServiceReferenceFirma.WSDigitalPDFClient wsFirma = new ServiceReferenceFirma.WSDigitalPDFClient();



            //ServiceReferenceFirma.electronicSignature electronicSignature = new ServiceReferenceFirma.electronicSignature();


            //Byte[] bytes = File.ReadAllBytes(destinationFileName);
            ////Byte[] bytes = FileToByteArray(HttpContext.Current.Server.MapPath(destinationFileName));



            //String file = Convert.ToBase64String(bytes);


            //string id_cliente = ConfigurationSettings.AppSettings["usuario_ws_firma"];
            //string pass_cliente = ConfigurationSettings.AppSettings["clave_ws_firma"];
            //byte[] array = Encoding.ASCII.GetBytes(file);
            //string clave_cifrada = ConfigurationSettings.AppSettings["clave_ws_firma_cifrada"];
            //this.ID_POLITICA = politica;
            ////electronicSignature.arguments = clave_cifrada;

            //ServiceReferenceFirma.respuesta respuestaFirma = new ServiceReferenceFirma.respuesta();


            //respuestaFirma = wsFirma.procesarPDF(id_cliente, clave_cifrada, ID_POLITICA, bytes, nombreArchivo, "1", "", null, null);


            //ServiceReferenceFirma.respuestaObj respObj = respuestaFirma.respuestaObj;


            //Byte[] bytesRespuesta = respuestaFirma.documento;
            //String archivoRespuesta = Convert.ToBase64String(bytesRespuesta);
            //File.WriteAllBytes(destinationFileName, bytesRespuesta);

            Cuenta.insertarAdjuntoCuenta(cuenta.IDRegistro, nombreArchivo);
            cuenta.insertarLOG("paabs", "Adjunto archivo '" + nombreArchivo + "' a cuenta:" + cuenta.IDRegistro, "Adjunto " + cuenta.IDRegistro, "Adjuntos");


        }
        catch (Exception ex)
        {
            //log.insertarLOG("app", "Error firmando el documento: " + id_informe.ToString() + " " + ex.Message.Normalize(), "ErrorPDF", "ClassDocumento", id_informe);
            //throw new Exception("Error generando documento firmado  : " + ex.Message.Normalize());
            //Si se genera un error se devuelve en 1 el consecutivo
            DevolverConsecutivo();
            return "";
        }

        this.ActualizarConsecutivoFactura(id_registro, consecutivo);

        return consecutivo;


    }






    

    public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }

    public static string autenticarGSE()
    {

        try
        {
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);



            var client = new RestClient(ConfigurationSettings.AppSettings["cliente_autenticacion"]);

            //client.Authenticator = new SimpleAuthenticator("Usuario", "mintransporte", "Clave", "3RN3pKJcR1");

            RestRequest restRequest = new RestRequest("/Login", Method.POST);
            //request.Method = Method.POST;
            restRequest.AddHeader("Content-Type", "application/json");
            //restRequest.AddHeader("Connection", "keep-alive");
            restRequest.AddHeader("Accept", "*/*");
            restRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
            //request.Resource = "pro/authentication/api/Login";
            //request.Parameters.Clear();
            //string body = @" { ""Usuario"" : ""mintransporte"", ""Clave"" : ""3RN3pKJcR1"" } ";
            var body = new
            {

                Usuario = ConfigurationSettings.AppSettings["usuario_ws_firma_gse"],
                Clave = ConfigurationSettings.AppSettings["clave_ws_firma_gse"]
            };
            restRequest.AddJsonBody(body);


            //restRequest.AddParameter("application/json", body);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse restResponse = client.Execute(restRequest);
            var content = restResponse.Content; // raw content as string  
            DataTable dt = new DataTable();
            RespuestaAut resp = new RespuestaAut();
            resp = JsonConvert.DeserializeObject<RespuestaAut>(content);
            if (resp.codigoRespuesta == "RS1")
                return resp.token;
            else
                return "";
        }
        catch
        {

            return "";
        }


    }


}

public class RespuestaAut
{
    public string token { get; set; }
    public string expiracion { get; set; }
    public string httpStatus { get; set; }
    public string codigoRespuesta { get; set; }
    public string descripcionRespuesta { get; set; }
    public string detalleRespuesta { get; set; }
}

public class RespuestaFirma
{
    public string mensaje { get; set; }
    public string documentoFirmado { get; set; }
    public string httpStatus { get; set; }
    public string codigoRespuesta { get; set; }

}
