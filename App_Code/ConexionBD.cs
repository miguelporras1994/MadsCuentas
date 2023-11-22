using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;

/// <summary>
/// Clase para conectarse a la base de datos
/// </summary>
public class ConexionBD
{
    private string source;

	public ConexionBD(string source)
	{
        this.source = source;
	}
    
 
    public DbConnection GetDatabaseConnection()
    {

        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[this.source];
        DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);

        DbConnection conn = factory.CreateConnection();
        conn.ConnectionString = settings.ConnectionString;

        return conn;

    }
}
