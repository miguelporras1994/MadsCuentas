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

public partial class ListarDevolucionesContratistas : System.Web.UI.Page
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

                string select = @"SELECT ID_REGISTRO,ORDEN_PAGO,NUM_DOCUMENTO,NOMBRE_BENEFICIARIO,NUM_PAGO,VALOR_FACTURA,ASIGNADO_A,GD.NOMBRE AS GRUPO,RECIBIDO_CONTABILIDAD, RECIBIDO_TESORERIA FROM CUENTA CT 
                                LEFT JOIN GRUPO_DEVOLUCION GD ON CT.ID_GRUPO_DEVOLUCION = GD.ID_GRUPO_DEVOLUCION WHERE  (DEVUELTA = 1) ";

               

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='dt_example'>
		                <div id='container'>
			                <div class='big full_width'><em>Devoluciones Pendientes</em></div>
                			
			                <div id='demo'>
                <table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
                            <th>ID</th>
			                <th>Ver</th>
			                <th>Orden Pago</th>
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Valor Factura</th>
                            <th>Asignado</th>
                           <th></th>
                            
                            
		                </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {
                    //string nombre_id = reader_sql.GetName(1);
                    string imgRecCont = (reader_sql["RECIBIDO_CONTABILIDAD"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";
                    string imgRecTes = (reader_sql["RECIBIDO_TESORERIA"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";

                    //Literal1.Text += "<tr class='gradeA'><td><a href='EditarCuenta.aspx?id=" + reader_sql["id_registro"] + "'>Editar</a>" + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td><img src='" + imgRecCont + "' border='0' />" + "</td><td><img src='" + imgRecTes + "' border='0' />" + "</td></tr>";
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td style='width:270px;'>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td style='width:370px;'>" + reader_sql["NUM_PAGO"] + "</td><td style='width:230px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td>" + reader_sql["ASIGNADO_A"].ToString() + "</td><td><a href='ResolverDevolucion.aspx?id=" + reader_sql["ID_REGISTRO"] + "'>Resolver</a></td></tr>";

                }

                Literal1.Text += @"</tbody>
                <tfoot>
		                <tr>
                            <th></th>
			                <th></th>
			                <th></th>
                            <th></th>
			                <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                           <th></th>
                            
                            
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


    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
    protected void ButtonBuscar_Click1(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
}