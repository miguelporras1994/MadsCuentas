using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Web.Security;
using FormsAuth;
using System.Data.Common;

/// <summary>
/// Summary description for WebFormLogOn.
/// </summary>
public partial class WebFrmSeg : System.Web.UI.Page
{

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    #endregion

    protected void Login_Click(object sender, EventArgs e)
    {
        String adPath = ConfigurationSettings.AppSettings["dominioDA"];
        LdapAuthentication adAuth = new LdapAuthentication(adPath);
        Usuarios user;
        try
        {
            if (adAuth.IsAuthenticated(txtDomain.Text, txtUsername.Text, txtPassword.Text))
            {
                //String groups = adAuth.GetGroups();

                //Create the ticket, and add the groups.
                bool isCookiePersistent = true;
                //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text,7
                //DateTime.Now, DateTime.Now.AddMinutes(180), isCookiePersistent, groups);67
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(txtUsername.Text, true, 180);

                //Encrypt the ticket.
                String encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                //Create a cookie, and then add the encrypted ticket to the cookie as data.
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                if (true == isCookiePersistent)
                    authCookie.Expires = authTicket.Expiration;

                //Add the cookie to the outgoing cookies collection.
                Response.Cookies.Add(authCookie);
                user = new Usuarios(txtUsername.Text);
                Session.Add("usuario", user);
                Response.Redirect("Formularios.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Por favor verifique su usuario y contrase�a o contacte al administrador.');</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Por favor verifique su usuario y contrase�a o contacte al administrador.');", true);
                //System.IO.File.WriteAllText(@"D:\Users\Public\TestFolder\WriteText.txt", text);

            }


        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Error en login " + ex.Message.Normalize() + "');</script>");

        }
    }

    protected void salir_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
        }
        catch
        {
        }
        Response.Write("<script>alert('Sesi�n terminada');</script>");
    }
}