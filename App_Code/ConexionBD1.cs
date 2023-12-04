using System.Configuration;
using System.Data.Common;

//public class ConexionBD
//{
//    private string source;

//    public ConexionBD(string source)
//    {
//        this.source = source;
//    }


//    public DbConnection GetDatabaseConnection()
//    {

//        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[this.source];
//        DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);

//        DbConnection conn = factory.CreateConnection();
//        conn.ConnectionString = settings.ConnectionString;

//        return conn;

//    }
//}