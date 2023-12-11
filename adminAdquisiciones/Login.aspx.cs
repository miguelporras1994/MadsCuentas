using FormsAuth;
using System;
using System.Configuration;
using System.Web;
using System.Web.Security;

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
        String adPath = ConfigurationSettings.AppSettings["dominioDA"]; ; //Fully-qualified Domain Name
        LdapAuthentication adAuth = new LdapAuthentication(adPath);
        Usuarios user;
        try
        {
            if (adAuth.IsAuthenticated(txtDomain.Text, txtUsername.Text, txtPassword.Text))
            {
                String groups = adAuth.GetGroups();

                //Create the ticket, and add the groups.
                bool isCookiePersistent = true;
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text,
                DateTime.Now, DateTime.Now.AddMinutes(180), isCookiePersistent, groups);

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
                Response.Write("<script>alert('Por favor verifique su usuario y contraseña o contacte al administrador.');</script>");

            }


        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Por favor verifique su usuario y contraseña o contacte al administrador.');</script>");

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
        Response.Write("<script>alert('Sesión terminada');</script>");
    }
}