using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OfficeOpenXml;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;
using System.Data.Common;
using System.Text;
using System.Drawing;

public partial class ListarPendientesCertificados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CertificadoRetenciones cert = new CertificadoRetenciones();
        DataTable registros = cert.consultarSolicitudesSinAtender();
        GridView1.DataSource = registros;
        GridView1.DataBind();

       
    }




}