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

public partial class Formularios : System.Web.UI.Page
{
    private int id_bodega = 0;
    Usuarios user = new Usuarios();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
        {

            Response.Redirect("Login.aspx");
        }

        user = (Usuarios)Session["usuario"];

        
    }

    

}
