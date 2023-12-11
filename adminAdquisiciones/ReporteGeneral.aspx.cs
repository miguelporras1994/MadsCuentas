using OfficeOpenXml;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;

public partial class ReporteGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
            Response.Redirect("Login.aspx");
        generarReporte();
    }




    private void generarReporte()
    {


        DataTable dt = new DataTable();


        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["db_con"];

        ConexionBD conBD = new ConexionBD("bd_con_adq");

        using (ExcelPackage pck = new ExcelPackage())
        {



            try
            {


                using (DbConnection conn = conBD.GetDatabaseConnection())
                {
                    conn.Open();

                    string sql = @"SELECT * FROM View_SOLICITUDES";

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


            try
            {

                ExcelWorksheet ws21 = pck.Workbook.Worksheets.Add("SOLICITUDES");

                ws21.Cells["A1"].LoadFromDataTable(dt, true);

                //Columnas 8 fecha
                using (ExcelRange col = ws21.Cells[2, 2, 1 + dt.Rows.Count, 2])
                //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }

                //Columnas 11,12,13 fecha
                using (ExcelRange col = ws21.Cells[2, 8, 1 + dt.Rows.Count, 8])
                //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }

                //using (ExcelRange col = ws21.Cells[2, 13, 1 + dt.Rows.Count, 13])

                //{
                //    col.Style.Numberformat.Format = "dd/mm/yyyy";
                //    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                //}

                ws21.Cells["A1:X1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws21.Cells["A1:X1"].Style.Font.Color.SetColor(Color.White);
                ws21.Cells["A1:X1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));


                var cell = ws21.Cells[1, 1, 1 + dt.Rows.Count, dt.Columns.Count];

                var border = cell.Style.Border;
                border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                using (ExcelRange col = ws21.Cells["K2:L" + (2 + dt.Rows.Count).ToString()])
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



                ws21.Cells[ws21.Dimension.Address].AutoFitColumns(19, 150);
                //ws21.r [ws21.Dimension.Address].AutoFitColumns(19, 150);

            }
            catch { }


            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;  filename=solicitudes.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();


        }


    }



    protected void ButtonGenerarReporte_Click(object sender, EventArgs e)
    {
        generarReporte();
    }
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        //cargarDatosReporte();
    }
}