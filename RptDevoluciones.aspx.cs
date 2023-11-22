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
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Web.Configuration;

public partial class RptDevoluciones : System.Web.UI.Page
{

    string pNroPlanilla;
    private string FNameReporte;
    private string pathReporte;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FNameReporte = "Devoluciones";
            //paramLista.Add(new ReportParameter("P_ID_DETALLELQIMPU", "100", false));
            //paramLista.Add(new ReportParameter("ELABORO", "", false));

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.Visible = true;
            ReportViewer1.ShowParameterPrompts = true;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["URLServidorReportes"]);
            pathReporte = WebConfigurationManager.AppSettings["RutaReportes"];
            ReportViewer1.ServerReport.ReportServerCredentials = new MyReportServerCredentials();
            ReportViewer1.ServerReport.ReportPath = pathReporte + FNameReporte;
            //ReportViewer1.ServerReport.SetParameters(paramLista);
            ReportViewer1.ServerReport.Refresh();
        }
    }


    class MyReportServerCredentials : IReportServerCredentials
    {

        public MyReportServerCredentials()
        {
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // Use default identity.
            }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                return new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["UsuarioReportes"], WebConfigurationManager.AppSettings["PwdReportes"], WebConfigurationManager.AppSettings["Dominio"]);

            }
        }

        public bool GetFormsCredentials(out System.Net.Cookie authCookie,
                out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;  // Not use forms credentials to authenticate.
        }
    }
}