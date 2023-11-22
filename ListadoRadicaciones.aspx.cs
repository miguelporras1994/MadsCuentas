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

public partial class ListadoRadicaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        cargarDatosReporte();
    }




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

                    /*
                    MemoryStream ms = GetExcel.DataTableToExcelXlsx(dt, "Sheet1");
                    ms.WriteTo(context.Response.OutputStream);
                    context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    context.Response.AddHeader("Content-Disposition", "attachment;filename=EasyEditCmsGridData.xlsx");
                    context.Response.StatusCode = 200;
                    context.Response.End();
                     * */
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

            /*
             * 
             * 
             ws21.Cells[6, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
             //Set Pattern for the background to Solid
             ws21.Cells[6, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));

             //Set color to dark blue
             ws21.Cells[6, 1].Style.Font.Color.SetColor(Color.White);

             //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
             ws21.Cells["A7"].LoadFromDataTable(dt, true);
             //Colocar el borde de los datos desde la fila 7
             var cell21 = ws21.Cells[7, 1, 7 + dt.Rows.Count, dt.Columns.Count];
             var border21 = cell21.Style.Border;
             border21.Top.Style = border21.Left.Style = border21.Bottom.Style = border21.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

             //Format the header for column 1-3
             using (ExcelRange rng = ws21.Cells["A7:M7"])
             {
                 rng.Style.Font.Bold = true;
                 rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                 //Set Pattern for the background to Solid
                 rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));

                 //Set color to dark blue
                 rng.Style.Font.Color.SetColor(Color.White);
             }

             //Columnas 7,8 fecha
             using (ExcelRange col = ws21.Cells[7, 7, 7 + dt.Rows.Count, 8])
             //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
             {
                 col.Style.Numberformat.Format = "mmm-dd-yyyy";
                 col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
             }

             using (ExcelRange col = ws21.Cells[7, 7, 8 + dt.Rows.Count, 9])
             //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
             {
                 col.Style.Numberformat.Format = "mmm-dd-yyyy";
                 col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
             }
             /*
             using (ExcelRange col = ws21.Cells["I8:I" + (7 + dt.Rows.Count).ToString()])
             {
                 col.Style.Numberformat.Format = "mmm-dd-yyyy";
                 col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
             }


             using (ExcelRange col = ws21.Cells["J8:J" + (7 + dt.Rows.Count).ToString()])
             {
                 col.Style.Numberformat.Format = "#0";
                 col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
             }

             using (ExcelRange col = ws21.Cells["K8:K" + (7 + dt.Rows.Count).ToString()])
             {
                 col.Style.Numberformat.Format = "#0";
                 col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
             }
             */



            ws21.Cells[ws21.Dimension.Address].AutoFitColumns();


            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;  filename=reporte_mensual.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();


        }


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

                string select = @"SELECT * FROM CUENTA WHERE 1 = 1";

                if (CheckBoxSinRCont.Checked == true)
                {

                    select += " AND RECIBIDO_CONTABILIDAD IS NULL";
                }

                if (CheckBoxSinRTes.Checked == true)
                {

                    select += " AND RECIBIDO_TESORERIA IS NULL";
                }

                if (CheckBoxSoloDevueltas.Checked == true)
                {

                    //CheckBoxDevueltas.Checked = false;
                    select += " AND DEVUELTA = 1";
                }
                else
                {

                    if (CheckBoxDevueltas.Checked == true)
                    {

                        select += " AND (DEVUELTA = 1 OR DEVUELTA IS NULL) ";
                    }
                    else
                    {
                        select += " AND DEVUELTA IS NULL";

                    }
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
			                <th>Orden Pago</th>
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Valor Factura</th>
                            <th>Cuenta por pagar</th>
                            <th>Recibido contabilidad</th>
                            <th>Recibido tesoreria</th>
                            
		                </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {
                    //string nombre_id = reader_sql.GetName(1);
                    string imgRecCont = (reader_sql["RECIBIDO_CONTABILIDAD"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";
                    string imgRecTes = (reader_sql["RECIBIDO_TESORERIA"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";

                    //Literal1.Text += "<tr class='gradeA'><td><a href='EditarCuenta.aspx?id=" + reader_sql["id_registro"] + "'>Editar</a>" + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td><img src='" + imgRecCont + "' border='0' />" + "</td><td><img src='" + imgRecTes + "' border='0' />" + "</td></tr>";
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td style='width:270px;'>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td style='width:370px;'>" + reader_sql["NUM_PAGO"] + "</td><td style='width:230px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td>" + reader_sql["CUENTA_POR_PAGAR"] + "</td><td><img src='" + imgRecCont + "' border='0' />" + "</td><td><img src='" + imgRecTes + "' border='0' />" + "</td></tr>";

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

    protected void ButtonGenerarReporte_Click(object sender, EventArgs e)
    {
        generarReporte();
    }
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
}