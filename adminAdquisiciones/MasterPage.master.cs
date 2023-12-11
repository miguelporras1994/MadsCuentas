using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        }

        try
        {
            if (Session["usuario"] != null)
            {

                DataSet ds = new DataSet();

                Usuarios user = (Usuarios)Session["usuario"];
                int id_usuario = user.IDUsuario;
                string perfil = user.Perfil;

                // perfil = "Coordinador";

                lbUsuario.Text = user.Nombre;


                //xmlDataSource.Data = ds.GetXml();
                if (perfil == "" || perfil == null)
                    throw new Exception();
                xmlDataSource.DataFile = "~/App_Data/" + perfil + ".xml";



                Menu1.Visible = true;
            }
            else
            {
                Menu1.Visible = false;
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Por favor verifique con el administrador que su usuario tiene acceso a la plataforma.');window.location.href='Login.aspx';</script>");
            Session["usuario"] = null;
        }

        //string usuario = Convert.ToString(Session["usuario"]);
        

        

    }
    /*
    protected void Page_Init(object sender, EventArgs e)
    {
        this.ID = "pagina";
    }*/


    protected void Page_PreInit(object sender, EventArgs e)
    {
        // This is necessary because Safari and Chrome browsers don't display the Menu control correctly.
        // All webpages displaying an ASP.NET menu control must inherit this class.
        if (Request.ServerVariables["http_user_agent"].IndexOf("Chrome", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";

        HtmlLink link = new HtmlLink();
        link.Href = "estilo.css";
        link.Attributes.Add("rel", "stylesheet");
        link.Attributes.Add("type", "text/css");
        Page.Header.Controls.Add(link);

    }
     

}
