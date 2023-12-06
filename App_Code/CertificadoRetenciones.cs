using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
/// <summary>
/// Summary description for CertificadoRetenciones
/// </summary>
public class CertificadoRetenciones
{
    public CertificadoRetenciones()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int insertar(string cedula, string correo, int ano)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        int id_solicitud = 0;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("INSERTAR_SOLICITUD_CERTIFICADO_RET", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = cedula;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = correo;
                cmd.Parameters.Add("@ANO", SqlDbType.Int).Value = ano;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                int rows = cmd.ExecuteNonQuery();

                id_solicitud = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conn.Close();

                return id_solicitud;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public DataTable consultarSolicitud(int id_solicitud)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM [SOLICITUDES_CERTIFICADO_RET]
                              WHERE ID_SOLICITUD = @id_solicitud";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public DataTable consultarSolicitudesSinAtender()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"CONSULTAR_SOLICITUD_CERTIFICADO_SIN_ATENDER";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }

    public DataTable consultarSolicitudesAtendidas()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"CONSULTAR_SOLICITUD_CERTIFICADO_ATENDIDAS";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public int atender(int id_solicitud, string usuario, string certificado)
    {
        ConexionBD conBD = new ConexionBD("bd_con");


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("ATENDER_SOLICITUD_CERTIFICADO_RET", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int).Value = id_solicitud;
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@CERTIFICADO", SqlDbType.VarChar).Value = certificado;

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


    public int atenderSinAdjunto(int id_solicitud, string usuario, string observaciones)
    {
        ConexionBD conBD = new ConexionBD("bd_con");


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("ATENDER_SOLICITUD_SIN_CERTIFICADO_RET", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int).Value = id_solicitud;
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = observaciones;

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


    public int dejarPendiente(int id_solicitud)
    {
        ConexionBD conBD = new ConexionBD("bd_con");


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("PENDIENTE_SOLICITUD_CERTIFICADO_RET", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int).Value = id_solicitud;

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

    public int solicitudPreviamenteEnviada(string cedula, int ano)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        int resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT ID_SOLICITUD FROM SOLICITUDES_CERTIFICADO_RET WHERE ATENDIDA = 1 AND CEDULA = '" + cedula + "' AND ANO = " + ano;

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = Utiles.validarNumeroToInt(o.ToString());

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return 0;
        }
    }

    public void correoCertificado(int id_solicitud)
    {

        try
        {
            Correo correo = new Correo();
            DataTable datos = this.consultarSolicitud(id_solicitud);

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
            <head>
            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

            <style type='text/css'>
            <!--
            .Estilo4 {font-family: 'Times New Roman', Times, serif}
            -->
            </style>
            </head>

            <body>";

            cuerpo_correo = "Estimado usuario<br /><br />";
            cuerpo_correo += "En respuesta a la solicitud radicada por ud, se realiza el envio del certificado de retenciones " + datos.Rows[0]["ANO"].ToString();

            //Este mensaje es una notificaci&oacute;n autom&aacute;tica, por lo tanto le solicitamos no responder a esta direcci&oacute;n de correo

            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'></span>.</p>
           
            </body>
            </html>
            ";

            Correo.enviarHTML(datos.Rows[0]["CORREO"].ToString(), "Certificado de retenciones", cuerpo_correo, ConfigurationSettings.AppSettings["CorreoCopia"], HttpContext.Current.Server.MapPath("~/Certificados/") + datos.Rows[0]["CERTIFICADO"].ToString());
        }
        catch (Exception ex)
        {

            throw new Exception("Error al enviar el correo: " + ex.Message.Normalize());
        }

    }


    public void correoCertificadoSinAdjunto(int id_solicitud, string observaciones)
    {

        try
        {
            Correo correo = new Correo();
            DataTable datos = this.consultarSolicitud(id_solicitud);

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
            <head>
            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

            <style type='text/css'>
            <!--
            .Estilo4 {font-family: 'Times New Roman', Times, serif}
            -->
            </style>
            </head>

            <body>";

            cuerpo_correo = "Estimado usuario<br /><br />";
            cuerpo_correo += "En respuesta a la solicitud radicada por ud del certificado de retenciones " + datos.Rows[0]["ANO"].ToString() + ", se le informa que: " + observaciones;

            //Este mensaje es una notificaci&oacute;n autom&aacute;tica, por lo tanto le solicitamos no responder a esta direcci&oacute;n de correo

            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'></span>.</p>
           
            </body>
            </html>
            ";

            Correo.enviarHTML(datos.Rows[0]["CORREO"].ToString(), "Certificado de retenciones", cuerpo_correo, ConfigurationSettings.AppSettings["CorreoCopia"]);
        }
        catch (Exception ex)
        {

            throw new Exception("Error al enviar el correo: " + ex.Message.Normalize());
        }

    }

    public void correoCertificado(int id_solicitud, string correo_enviar)
    {

        try
        {
            Correo correo = new Correo();
            DataTable datos = this.consultarSolicitud(id_solicitud);

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
            <head>
            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

            <style type='text/css'>
            <!--
            .Estilo4 {font-family: 'Times New Roman', Times, serif}
            -->
            </style>
            </head>

            <body>";

            cuerpo_correo = "Estimado usuario<br /><br />";
            cuerpo_correo += "En respuesta a la solicitud radicada por ud, se realiza el envio del certificado de retenciones " + datos.Rows[0]["ANO"].ToString();

            //Este mensaje es una notificaci&oacute;n autom&aacute;tica, por lo tanto le solicitamos no responder a esta direcci&oacute;n de correo

            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'></span>.</p>
           
            </body>
            </html>
            ";

            Correo.enviarHTML(correo_enviar, "Certificado de retenciones", cuerpo_correo, ConfigurationSettings.AppSettings["CorreoCopia"], HttpContext.Current.Server.MapPath("~/Certificados/") + datos.Rows[0]["CERTIFICADO"].ToString());
        }
        catch (Exception ex)
        {

            throw new Exception("Error al enviar el correo: " + ex.Message.Normalize());
        }

    }


}