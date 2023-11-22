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

/// <summary>
/// Descripción breve de Correo
/// </summary>
public class Correo
{
	public Correo()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string enviar(string correoEnviar,string asunto,string cuerpo,string copia)
    {


        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["CorreoRemitente"]);
        
        //Adicionar los distintos correos que vienen separados por coma o punto y coma
       Tokens c = new Tokens(correoEnviar, new char[] { ',', ';' });
       foreach (string itemC in c)
       {
           correo.To.Add(itemC.ToString());
       }

       // correo.To.Add(correoEnviar);
        
        correo.Subject = asunto;
        correo.Body = cuerpo;
        correo.IsBodyHtml = false;
        string respuesta = "";
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        //Adicionar los distintos copias que vienen separados por coma o punto y coma
        if (copia.Trim() != "")
        {
            Tokens f = new Tokens(copia, new char[] { ',', ';' });
            foreach (string item in f)
            {
                correo.CC.Add(item.ToString());
            }
        }

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = ConfigurationSettings.AppSettings["DominioSMTP"];
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["UsuarioCorreo"], ConfigurationSettings.AppSettings["ClaveCorreo"]);
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(correo);
            respuesta = "Mensaje enviado satisfactoriamente";
        }
        catch (Exception ex)
        {
            respuesta = "ERROR: " + ex.Message;
        }
        return respuesta;
    }



    public static string enviarHTML(string correoEnviar, string asunto, string cuerpo, string copia)
    {


        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["CorreoRemitente"]);

        //Adicionar los distintos correos que vienen separados por coma o punto y coma
        Tokens c = new Tokens(correoEnviar, new char[] { ',', ';' });
        foreach (string itemC in c)
        {
            correo.To.Add(itemC.ToString());
        }

        // correo.To.Add(correoEnviar);

        correo.Subject = asunto;
        correo.Body = cuerpo;
        correo.IsBodyHtml = true;
        string respuesta = "";
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        //Adicionar los distintos copias que vienen separados por coma o punto y coma
        if (copia.Trim() != "")
        {
            Tokens f = new Tokens(copia, new char[] { ',', ';' });
            foreach (string item in f)
            {
                correo.CC.Add(item.ToString());
            }
        }

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = ConfigurationSettings.AppSettings["DominioSMTP"];
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["UsuarioCorreo"], ConfigurationSettings.AppSettings["ClaveCorreo"]);
        smtp.EnableSsl = false;
        try
        {
            smtp.Send(correo);
            respuesta = "Mensaje enviado satisfactoriamente";
        }
        catch (Exception ex)
        {
            respuesta = "ERROR: " + ex.Message;
        }
        return respuesta;
    }


    public static string enviar(string correoEnviar, string asunto, string cuerpo, string copia,string pathAtt)
    {


        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["CorreoRemitente"]);

        //Adicionar los distintos correos que vienen separados por coma o punto y coma
        Tokens c = new Tokens(correoEnviar, new char[] { ',', ';' });
        foreach (string itemC in c)
        {
            correo.To.Add(itemC.ToString());
        }

        // correo.To.Add(correoEnviar);

        correo.Subject = asunto;
        correo.Body = cuerpo;
        correo.IsBodyHtml = false;
        string respuesta = "";
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        //Adicionar los distintos copias que vienen separados por coma o punto y coma
        if (copia.Trim() != "")
        {
            Tokens f = new Tokens(copia, new char[] { ',', ';' });
            foreach (string item in f)
            {
                correo.CC.Add(item.ToString());
            }
        }

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = ConfigurationSettings.AppSettings["DominioSMTP"];
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["UsuarioCorreo"], ConfigurationSettings.AppSettings["ClaveCorreo"]);
        smtp.EnableSsl = false;
        System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(pathAtt);

        try
        {
            correo.Attachments.Add(att);
            smtp.Send(correo);
            respuesta = "Mensaje enviado satisfactoriamente";
        }
        catch (Exception ex)
        {
            respuesta = "ERROR: " + ex.Message;
        }
        return respuesta;
    }

    public static string enviarHTML(string correoEnviar, string asunto, string cuerpo, string copia, string pathAtt)
    {


        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["CorreoRemitente"]);

        //Adicionar los distintos correos que vienen separados por coma o punto y coma
        Tokens c = new Tokens(correoEnviar, new char[] { ',', ';' });
        foreach (string itemC in c)
        {
            correo.To.Add(itemC.ToString());
        }

        // correo.To.Add(correoEnviar);

        correo.Subject = asunto;
        correo.Body = cuerpo;
        correo.IsBodyHtml = true;
        string respuesta = "";
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        //Adicionar los distintos copias que vienen separados por coma o punto y coma
        if (copia.Trim() != "")
        {
            Tokens f = new Tokens(copia, new char[] { ',', ';' });
            foreach (string item in f)
            {
                correo.CC.Add(item.ToString());
            }
        }

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = ConfigurationSettings.AppSettings["DominioSMTP"];
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["UsuarioCorreo"], ConfigurationSettings.AppSettings["ClaveCorreo"]);
        smtp.EnableSsl = false;
        System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(pathAtt);

        try
        {
            correo.Attachments.Add(att);
            smtp.Send(correo);
            respuesta = "Mensaje enviado satisfactoriamente";
        }
        catch (Exception ex)
        {
            respuesta = "ERROR: " + ex.Message;
        }
        return respuesta;
    }
}
