using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;

public partial class PendientesTesoreria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }

    private void cargarDatosReporte()
    {
        try
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];
            ConexionBD conBD = new ConexionBD("bd_con");

            //string sql = @"SELECT * FROM " + tabla;

            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = @"SELECT * FROM CUENTA WHERE RECIBIDO_TESORERIA IS NULL";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='dt_example'>
		                <div id='container'>
			                <div class='big full_width'><em>Registros</em></div>
                			
			                <div id='demo'>
                <table cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
			                <th>ID</th>
			                <th>Orden Pago</th>
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Valor Factura</th>
                            
		                </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {
                    //string nombre_id = reader_sql.GetName(1);

                    Literal1.Text += "<tr class='gradeA'><td><a href='RecibidoTesoreria.aspx?id=" + reader_sql["id_registro"] + "'>Registrar recibido</a>" + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td></tr>";

                }

                Literal1.Text += @"</tbody>
                <tfoot>
		                <tr>
			                <th>ID</th>
			                <th>Orden Pago</th>
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Valor Factura</th>
                            
		                </tr>
	                </tfoot>
                </table>

                ";

                conn.Close();

            }
        }
        catch (SqlException ex)
        {
        }

    }
}