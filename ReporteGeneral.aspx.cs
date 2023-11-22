﻿using System;
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
using System.Globalization;

public partial class ReporteGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //repeater.DataSource = Reporte.ReporteGeneral();
        //repeater.DataBind();
        GridView1.DataSource = Reporte.ReporteGeneral(DateTime.Now.Year, Utiles.validarNumeroToInt(DropDownListEntidad.Text), TextBoxNumeroDoc.Text, TextBoxNombre.Text, TextBoxCuentaPorPagar.Text, TextBoxCorreo.Text, "", Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text), TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text,TextBoxRadicado.Text);
        GridView1.DataBind();
    }
   
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        /*
        this.GridView1.DataSource = null;
        GridView1.DataSource = Reporte.ReporteGeneral(Utiles.validarNumeroToInt(DropDownListAno.Text), Utiles.validarNumeroToInt(DropDownListEntidad.Text), TextBoxNumeroDoc.Text, TextBoxNombre.Text, TextBoxCuentaPorPagar.Text, TextBoxCorreo.Text, TextBoxOrdenPago.Text, Utiles.validarNumeroToInt(DropDownListTipoDocumento.Text), TextBoxFechaIniCierre.Text, TextBoxFechaFinCierre.Text);
        GridView1.DataBind();
        */

    }

    protected void ButtonGenerarReporte_Click(object sender, EventArgs e)
    {
        generarReporte();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
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

                    string sql = @"SELECT  * FROM View_REPORTE_GENERAL_EXCEL WHERE 1 = 1 ";

                    if (TextBoxFechaIniCierre.Text != "" && TextBoxFechaFinCierre.Text != "")
                    {

                        sql += " AND [Fecha Radicado] BETWEEN CAST('" + DateTime.ParseExact(TextBoxFechaIniCierre.Text, ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], CultureInfo.InvariantCulture).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                        sql += " AND CAST('" + DateTime.ParseExact(TextBoxFechaFinCierre.Text, ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], CultureInfo.InvariantCulture).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                    }

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

            //Fecha radicado

            try
            {
                //Columnas 6 fecha
                //using (ExcelRange col = ws21.Cells[2, 7, 1 + dt.Rows.Count, 8])
                using (ExcelRange col = ws21.Cells["I2:I" + (dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }

            try
            {
                //Columnas 6 fecha
                //using (ExcelRange col = ws21.Cells[2, 7, 1 + dt.Rows.Count, 8])
                using (ExcelRange col = ws21.Cells["L2:L" + (dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }


            try
            {
                //Columnas 6 fecha
                //using (ExcelRange col = ws21.Cells[2, 7, 1 + dt.Rows.Count, 8])
                using (ExcelRange col = ws21.Cells["O2:O" + (dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }

            try
            {
                //Columnas 6 fecha
                //using (ExcelRange col = ws21.Cells[2, 7, 1 + dt.Rows.Count, 8])
                using (ExcelRange col = ws21.Cells["P2:P" + (dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }

            try
            {
                //Columnas 6 fecha
                //using (ExcelRange col = ws21.Cells[2, 7, 1 + dt.Rows.Count, 8])
                using (ExcelRange col = ws21.Cells["Q2:Q" + (dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }



            try
            {
                //Columnas 10,11 fecha obligacion siif fecha cargue contabilidad
                using (ExcelRange col = ws21.Cells[2, 10, 1 + dt.Rows.Count, 11])
                //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }

            try
            {
                //Columnas 13,14,15  fechas tesoreria
                using (ExcelRange col = ws21.Cells[2, 13, 1 + dt.Rows.Count, 15])
                //using (ExcelRange col = ws21.Cells["H8:H" + (7 + dt.Rows.Count).ToString()])
                {
                    col.Style.Numberformat.Format = "dd/mm/yyyy";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }
            }
            catch { }

            ws21.Cells["A1:S1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws21.Cells["A1:S1"].Style.Font.Color.SetColor(Color.White);
            ws21.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
            ws21.Cells["J1:K1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
            ws21.Cells["L1:M1"].Style.Fill.BackgroundColor.SetColor(Color.Green);
            ws21.Cells["N1:S1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));

            var cell = ws21.Cells[1, 1, 1 + dt.Rows.Count, dt.Columns.Count];

            var border = cell.Style.Border;
            border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            using (ExcelRange col = ws21.Cells["F2:F" + (2 + dt.Rows.Count).ToString()])
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
            Response.AddHeader("content-disposition", "attachment;  filename=reporte_general.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();


        }


    }
}