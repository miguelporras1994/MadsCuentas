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

public partial class ListarPendientesAdjuntosRadicados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        GridView1.DataSource = Reporte.Adjuntar(DateTime.Now.Year, Utiles.validarNumeroToInt(DropDownListEntidad.Text), TextBoxNumeroDoc.Text, TextBoxNombre.Text, TextBoxCuentaPorPagar.Text, TextBoxCorreo.Text, TextBoxOrdenPago.Text, Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text), TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text,CheckBoxSinAdjuntos.Checked,CheckBoxRadicadosHoy.Checked);
        GridView1.DataBind();

    }


    /*

    private void generarReporte()
    {


        DataTable dt = new DataTable();


        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["db_con"];

        ConexionBD conBD = new ConexionBD("bd_con");

        using (ExcelPackage pck = new ExcelPackage())
        {



            try
            {


                using (DbConnection conn = conBD.GetDatabaseConnection())
                {
                    conn.Open();

                    string sql = @"SELECT  [ID_REGISTRO] 'No.Radicación'
                                      ,[ORDEN_PAGO] 'Orden Pago'
                                      ,[ID_TIPO_DOCUMENTO] 'Tipo_Docto'
                                      ,[NUM_DOCUMENTO] 'Número_Doc'
                                      ,[NOMBRE_BENEFICIARIO] 'Nombre_beneficiario'
                                      ,[NUM_PAGO] ' No.Pago'
                                      ,[VALOR_FACTURA] 'Valor_Factura'
                                      ,[FECHA_RADICADO] 'Fecha Radicado'
                                      ,LTRIM(RIGHT(CONVERT(VARCHAR(20),FECHA_RADICADO, 100), 7)) 'Hora Radicado'
                                      ,[NUM_OBLIGACION] 'No. Obligación'
                                      ,[FECHA_RECIBIDO_CONTABILIDAD] 'Fecha Recibido Contabilidad'
                                      ,[FECHA_RECIBIDO_TESORERIA] 'Fecha Recibido Tesoreria'
                                      ,[FECHA_ORDEN_PAGO] 'Fecha de Orden de Pago'
                                      ,[OBSERVACIONES] 'Observaciones'
                                      ,[ASIGNADO_A] 'Asignado'
                                      ,[CUENTA_POR_PAGAR] 'Cuenta por Pagar'
                                     
                                  FROM [dbo].[CUENTA]";

                    SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);

                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);

                    dt.Clear();

                    sqa.Fill(dt);

   
                }
            }
            catch (Exception ex) { }



            ExcelWorksheet ws21 = pck.Workbook.Worksheets.Add("Radicaciones");

            ws21.Cells["A1"].LoadFromDataTable(dt, true);

            //Columnas 8 fecha
            using (ExcelRange col = ws21.Cells[2, 8, 1 + dt.Rows.Count, 8])
            //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
            {
                col.Style.Numberformat.Format = "dd/mm/yyyy";
                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            }

            //Columnas 11,12,13 fecha
            using (ExcelRange col = ws21.Cells[2, 11, 1 + dt.Rows.Count, 13])
            //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
            {
                col.Style.Numberformat.Format = "dd/mm/yyyy";
                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            }

            ws21.Cells["A1:P1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws21.Cells["A1:P1"].Style.Font.Color.SetColor(Color.White);
            ws21.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
            ws21.Cells["J1:K1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
            ws21.Cells["L1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Green);
            ws21.Cells["N1:P1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));

            var cell = ws21.Cells[1, 1, 1 + dt.Rows.Count, dt.Columns.Count];

            var border = cell.Style.Border;
            border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            using (ExcelRange col = ws21.Cells["G2:J" + (2 + dt.Rows.Count).ToString()])
            {
                col.Style.Numberformat.Format = "#,##0.00";
                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            }





            ws21.Cells[ws21.Dimension.Address].AutoFitColumns();


            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;  filename=reporte_mensual.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();


        }


    }

	*/

        /*
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

                string select = @"SELECT * FROM CUENTA WHERE (DEVUELTA <> 1 OR DEVUELTA IS NULL) ";

                if(DropDownListAno.Text != "0")
                {
                    select += " AND YEAR(FECHA_RADICADO) = " + DropDownListAno.Text + " ";
                }

                if (DropDownListMes.Text != "0")
                {
                    select += " AND MONTH(FECHA_RADICADO) = " + DropDownListMes.Text + " ";
                }

                if (TextBoxDocumento.Text != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + TextBoxDocumento.Text + "'";
                }

                if (TextBoxID.Text != "")
                {

                    select += " AND ID_REGISTRO = '" + TextBoxID.Text + "'";
                }

                if (TextBoxNombre.Text != "")
                {

                    //CheckBoxDevueltas.Checked = false;
                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" +  TextBoxNombre.Text + "%'";
                }


                if (DropDownListAsignado.Text != "0")
                {
                    select += " AND ASIGNADO_A = '" + DropDownListAsignado.Text + "'";
                }

               


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='dt_example'>
		                <div id='container'>
			                <div class='big full_width'><em>Registros</em></div>
                			
			                <div id='demo'>
                <table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
                            <th>ID</th>
			                <th>Ver</th>
                            <th>Fecha Radicado</th>
                            <th>Numero Documento</th>
                            <th>Beneficiario</th>
                            <th>Correo</th>
                            <th>Numero de Pago</th>
                            <th>Numero Factura</th>
                            <th>Valor</th>
                            
                            <th>Adjuntos</th>
                            
                            
		                </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {

                   
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["FECHA_RADICADO"] + "</td><td>" +  reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td style='width:270px;'>" + reader_sql["CORREO"] + "</td><td>" + reader_sql["NUM_PAGO"]  + "</td><td>" + reader_sql["NUMERO_FACTURA"] + "</td><td style='width:230px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td>" + "<a href='RadicadosAdjuntar.aspx?id=" + reader_sql["id_registro"] + "'>Adjuntar</a></td></tr>";

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
    */
    protected void ButtonGenerarReporte_Click(object sender, EventArgs e)
    {
        //generarReporte();
    }
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        //cargarDatosReporte();
    }
}