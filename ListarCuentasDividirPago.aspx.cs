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

public partial class ListarCuentasDividirPago : System.Web.UI.Page
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

                    string sql = @"SELECT * FROM View_LISTAR_CUENTAS_DIVIDIR";

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

                string select = @"SELECT * FROM  View_LISTAR_CUENTAS_DIVIDIR WHERE 1 = 1";

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
                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + TextBoxNombre.Text + "%'";
                }

                if (DropDownListEntidad.Text != "0")
                {
                    select += " AND ID_ENTIDAD = " + DropDownListEntidad.Text;
                }


                if (DropDownListAsignado.Text != "0")
                {
                    select += " AND ASIGNADO_A = '" + DropDownListAsignado.Text + "'";
                }

                if (CheckBoxRadicadosHoy.Checked)
                {

                    select += " AND FECHA_RADICADO >= cast (GETDATE() as DATE)";
                }


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='dt_example'>
		                <div id='container'>
			                <div class='big full_width' align='center'><h3>Registros</h3></div>
                			
			                <div id='demo'>
                <table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
                            <th>ID</th>
			                <th>Ver</th>
                            <th>Fecha Radicado</th>
                            <th>Numero Documento</th>
                            <th>Contrato</th>
                            <th>Beneficiario</th>
                            
                            <th>Numero de Pago</th>
                            <th>Numero Factura</th>
                            <th>SUBTOTAL</th>
                            <th>IVA</th>
                            <th>TOTAL</th>
                            <th>Entidad</th>
                            
                            <th>Dividir</th>
                            
                            
		                </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {


                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["FECHA_RADICADO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NUMERO_CONTRATO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + reader_sql["NUMERO_FACTURA"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())).Replace(" ", "") + "</td><td style='width:250px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_IVA"].ToString())).Replace(" ", "") + "</td><td style='width:200px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_TOTAL"].ToString())).Replace(" ", "") + "</td><td>" + reader_sql["ENTIDAD"] + "</td><td><a href='DividirCuenta.aspx?id=" + reader_sql["id_registro"] + "'>Dividir</a></td></tr>";

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