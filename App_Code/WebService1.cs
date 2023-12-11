using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebService1
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService1 : System.Web.Services.WebService
{

    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]

    public string GetItemsReporteGeneral()
    {
        int sEcho = ToInt(HttpContext.Current.Request.Params["sEcho"]);
        int iDisplayLength = ToInt(HttpContext.Current.Request.Params["iDisplayLength"]);
        int iDisplayStart = ToInt(HttpContext.Current.Request.Params["iDisplayStart"]);
        string rawSearch = HttpContext.Current.Request.Params["sSearch"];

        string documento = HttpContext.Current.Request.Params["documento"];
        string nombre = HttpContext.Current.Request.Params["nombre"];
        string cuenta_por_pagar = HttpContext.Current.Request.Params["cuenta_por_pagar"];
        string correo = HttpContext.Current.Request.Params["correo"];
        string orden_pago = HttpContext.Current.Request.Params["orden_pago"];
        string tipo_solicitud = HttpContext.Current.Request.Params["tipo_solicitud"];
        string entidad = HttpContext.Current.Request.Params["entidad"];
        string devuelta = HttpContext.Current.Request.Params["devuelta"];

        var sb = new StringBuilder();

        var whereClause = string.Empty;
        if (documento.Length > 0)
        {
            sb.Append(" Where NUM_DOCUMENTO like ");
            sb.Append("'%" + documento + "%'");
            whereClause = sb.ToString();
        }

        if (documento.Length > 0)
        {
            sb.Append(" NUM_DOCUMENTO like ");
            sb.Append("'%" + documento + "%'");

        }

        if (nombre.Length > 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND NOMBRE_BENEFICIARIO like ");
            else
                sb.Append(" NOMBRE_BENEFICIARIO like ");
            sb.Append("'%" + nombre + "%'");
        }

        if (cuenta_por_pagar.Length > 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND CUENTA_POR_PAGAR like ");
            else
                sb.Append(" CUENTA_POR_PAGAR like ");
            sb.Append("'%" + cuenta_por_pagar + "%'");
        }

        if (correo.Length > 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND CORREO like ");
            else
                sb.Append(" CORREO like ");
            sb.Append("'%" + correo + "%'");
        }

        if (orden_pago.Length > 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND REPORTE_ORDEN_PAGO like ");
            else
                sb.Append(" REPORTE_ORDEN_PAGO like ");
            sb.Append("'%" + orden_pago + "%'");
        }

        if (tipo_solicitud.ToString().CompareTo("0") != 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND CUENTA.ID_TIPO_DOCUMENTO = " + tipo_solicitud);
            else
                sb.Append(" CUENTA.ID_TIPO_DOCUMENTO = " + tipo_solicitud);

        }

        if (entidad.ToString().CompareTo("0") != 0)
        {
            if (sb.Length > 0)
                sb.Append(" AND CUENTA.ID_ENTIDAD = " + entidad);
            else
                sb.Append(" CUENTA.ID_ENTIDAD = " + entidad);

        }

        if (devuelta == "SI")
        {
            if (sb.Length > 0)
                sb.Append(" AND  CUENTA.DEVUELTA IS NOT NULL ");
            else
                sb.Append(" CUENTA.DEVUELTA IS NOT NULL ");
        }


        if (sb.Length > 0)
        {
            whereClause = sb.ToString();
            whereClause = " WHERE " + whereClause;
        }


        sb.Length = 0;

        var filteredWhere = string.Empty;

        var wrappedSearch = "'%" + rawSearch + "%'";

        if (rawSearch.Length > 0)
        {
            sb.Append(" WHERE ID LIKE ");
            sb.Append(wrappedSearch);
            sb.Append(" OR DOCUMENTO LIKE ");
            sb.Append(wrappedSearch);
            sb.Append(" OR CUENTA_POR_PAGAR LIKE ");
            sb.Append(wrappedSearch);
            sb.Append(" OR NOMBRE_BENEFICIARIO LIKE ");
            sb.Append(wrappedSearch);
            filteredWhere = sb.ToString();
        }


        //ORDERING

        sb.Length = 0;

        string orderByClause = string.Empty;
        sb.Append(ToInt(HttpContext.Current.Request.Params["iSortCol_0"]));

        sb.Append(" ");

        sb.Append(HttpContext.Current.Request.Params["sSortDir_0"]);

        orderByClause = sb.ToString();

        if (!String.IsNullOrEmpty(orderByClause))
        {

            orderByClause = orderByClause.Replace("0", ", ID ");
            orderByClause = orderByClause.Replace("1", ", UserName ");


            orderByClause = orderByClause.Remove(0, 1);
        }
        else
        {
            orderByClause = "ID ASC";
        }
        orderByClause = "ORDER BY " + orderByClause;

        sb.Length = 0;

        var numberOfRowsToReturn = "";
        numberOfRowsToReturn = iDisplayLength == -1 ? "TotalRows" : (iDisplayStart + iDisplayLength).ToString();



        string query = @" 
                             
                            declare @MA TABLE(  ID INT,  RESUMEN VARCHAR(350), NOMBRE_BENEFICIARIO VARCHAR(350), DOCUMENTO VARCHAR(50), VALOR_FACTURA DECIMAL(20,2),CUENTA_POR_PAGAR VARCHAR(150),
                                                RECIBIDO_TESORERIA VARCHAR(2),ENTIDAD VARCHAR(50),
                                                ESTADO VARCHAR(50) , DEVUELTA INT,LIQUIDACION VARCHAR(250), DEDUCCIONES VARCHAR(250))
                            INSERT
                            INTO
	                            @MA ( ID ,  RESUMEN , NOMBRE_BENEFICIARIO , DOCUMENTO , VALOR_FACTURA ,CUENTA_POR_PAGAR ,RECIBIDO_TESORERIA ,ENTIDAD ,
                                                ESTADO , DEVUELTA ,LIQUIDACION , DEDUCCIONES)


	                               SELECT       dbo.CUENTA.ID_REGISTRO AS ID,'<a class=''thickbox'' href=''DetalleCuenta.aspx?id='  + CAST(dbo.CUENTA.ID_REGISTRO AS VARCHAR(10)) +  '&keepThis=true&TB_iframe=true&height=450&width=700''>Ver</a>' AS RESUMEN, NOMBRE_BENEFICIARIO,
                                                dbo.CUENTA.NUM_DOCUMENTO AS DOCUMENTO, dbo.CUENTA.VALOR_FACTURA + ISNULL(dbo.CUENTA.VALOR_IVA, 0) AS VALOR_FACTURA,
                                                dbo.CUENTA.CUENTA_POR_PAGAR,CASE ISNULL(dbo.CUENTA.RECIBIDO_TESORERIA,0) WHEN 1 THEN 'SI' ELSE 'NO' END ,dbo.ENTIDADES.NOMBRE AS ENTIDAD,
                                                CASE ID_ESTADO WHEN 1 THEN 'ANULADA' ELSE 'ACTIVA' END AS ESTADO,ISNULL(dbo.CUENTA.DEVUELTA,0) AS DEVUELTA,CASE ID_TIPO_DOCUMENTO WHEN 2 THEN '<a href=''LiquidacionPDF.aspx?id=' +  CAST(dbo.CUENTA.ID_REGISTRO AS VARCHAR(10)) + '''>Liquidacion</a>' ELSE 'N/A' END ,CASE ID_TIPO_DOCUMENTO WHEN 2 THEN '<a href=''OrdenPagoMADS.aspx?id=' +  CAST(dbo.CUENTA.ID_REGISTRO AS VARCHAR(10)) + '''>Deducciones</a>' ELSE 'N/A' END
                                    FROM CUENTA  LEFT OUTER JOIN
                         dbo.ENTIDADES ON dbo.CUENTA.ID_ENTIDAD = dbo.ENTIDADES.ID_ENTIDAD

	                                {4}                   

                            SELECT ID ,  RESUMEN , NOMBRE_BENEFICIARIO , DOCUMENTO , VALOR_FACTURA ,CUENTA_POR_PAGAR ,RECIBIDO_TESORERIA ,ENTIDAD ,
                                                ESTADO , DEVUELTA ,LIQUIDACION , DEDUCCIONES , TotalRows , TotalDisplayRows
                            FROM
	                            (SELECT row_number() OVER ({0}) AS RowNumber
		                              , *
	                             FROM
		                             (SELECT (SELECT count([@MA].ID)
				                              FROM
					                              @MA) AS TotalRows
			                               , ( SELECT  count( [@MA].ID) FROM @MA {1}) AS TotalDisplayRows			   
			                                ,[@MA].ID
										   ,[@MA].RESUMEN
                                           ,[@MA].NOMBRE_BENEFICIARIO
			                               ,[@MA].DOCUMENTO
										   ,[@MA].VALOR_FACTURA
										   ,[@MA].CUENTA_POR_PAGAR
										   ,[@MA].RECIBIDO_TESORERIA
										   ,[@MA].ENTIDAD
										   ,[@MA].ESTADO
										   ,[@MA].DEVUELTA
										   ,[@MA].LIQUIDACION
										   ,[@MA].DEDUCCIONES     
		                              FROM
			                              @MA {1}) RawResults) Results
                            WHERE
	                            RowNumber BETWEEN {2} AND {3}";

        query = String.Format(query, orderByClause, filteredWhere, iDisplayStart + 1, numberOfRowsToReturn, whereClause);

        var connectionString = ConfigurationManager.ConnectionStrings["bd_con"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        var DB = new SqlCommand();
        DB.Connection = conn;
        DB.CommandText = query;



        var totalDisplayRecords = "";
        var totalRecords = "";
        string outputJson = string.Empty;

        var rowClass = "";
        var count = 0;

        try
        {
            var data = DB.ExecuteReader();

            while (data.Read())
            {

                if (totalRecords.Length == 0)
                {
                    totalRecords = data["TotalRows"].ToString();
                    totalDisplayRecords = data["TotalDisplayRows"].ToString();
                }
                sb.Append("{");
                sb.AppendFormat(@"""DT_RowId"": ""{0}""", count++);
                sb.Append(",");
                sb.AppendFormat(@"""DT_RowClass"": ""{0}""", rowClass);
                sb.Append(",");
                sb.AppendFormat(@"""0"": ""{0}""", data["ID"]);
                sb.Append(",");
                sb.AppendFormat(@"""1"": ""{0}""", data["RESUMEN"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""2"": ""{0}""", data["NOMBRE_BENEFICIARIO"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""3"": ""{0}""", data["DOCUMENTO"]);
                sb.Append(",");
                sb.AppendFormat(@"""4"": ""{0}""", data["VALOR_FACTURA"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""5"": ""{0}""", data["CUENTA_POR_PAGAR"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""6"": ""{0}""", data["RECIBIDO_TESORERIA"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""7"": ""{0}""", data["ENTIDAD"].ToString().Replace(",", "."));
                sb.Append(",");
                sb.AppendFormat(@"""8"": ""{0}""", data["ESTADO"]);
                sb.Append(",");
                sb.AppendFormat(@"""9"": ""{0}""", data["DEVUELTA"]);
                sb.Append(",");
                sb.AppendFormat(@"""10"": ""{0}""", data["LIQUIDACION"]);
                sb.Append(",");
                sb.AppendFormat(@"""11"": ""{0}""", data["DEDUCCIONES"].ToString().Replace(",", "."));

                sb.Append("},");
            }

            // handles zero records
            if (totalRecords.Length == 0)
            {
                sb.Append("{");
                sb.Append(@"""sEcho"": ");
                sb.AppendFormat(@"""{0}""", sEcho);
                sb.Append(",");
                sb.Append(@"""iTotalRecords"": 0");
                sb.Append(",");
                sb.Append(@"""iTotalDisplayRecords"": 0");
                sb.Append(", ");
                sb.Append(@"""aaData"": [ ");
                sb.Append("]}");
                outputJson = sb.ToString();

                return outputJson;
            }
            outputJson = sb.Remove(sb.Length - 1, 1).ToString();
            sb.Length = 0;

            sb.Append("{");
            sb.Append(@"""sEcho"": ");
            sb.AppendFormat(@"""{0}""", sEcho);
            sb.Append(",");
            sb.Append(@"""iTotalRecords"": ");
            sb.Append(totalRecords);
            sb.Append(",");
            sb.Append(@"""iTotalDisplayRecords"": ");
            sb.Append(totalDisplayRecords);
            sb.Append(", ");
            sb.Append(@"""aaData"": [ ");
            sb.Append(outputJson);
            sb.Append("]}");
            outputJson = sb.ToString();
        }
        catch { }

        return outputJson;
    }

    public static int ToInt(string toParse)
    {
        int result;
        if (int.TryParse(toParse, out result)) return result;

        return result;
    }


}
