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
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Drawing;


public partial class CargarCuentasTesoreria : System.Web.UI.Page
{
    private int id_bodega = 0;
    private int id_proyecto = 0;
    private int id_usuario = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (Session["loginAdmin"] == null)
        {
            Response.Redirect("LoginAdmin.aspx");
            LiteralMenu.Visible = false;

        }
        else
        {
            LiteralMenu.Text = Session["menu"].ToString();
            LiteralMenu.Visible = true;
            id_usuario = Utiles.validarNumeroToInt(Session["id_usuario"].ToString());
        }*/

       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {




        Literal2.Text = "";
        GridView1.Visible = true;

        try
        {
            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\web_sites\Empleados.xlsx;Extended Properties=Excel 12.0 Xml;HDR=NO;IMEX=1");

            //OleDbDataAdapter da = new OleDbDataAdapter("select * from MyObject", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            //dt = GetDataTableFromCsv("C:\\web_sites\\Empleados.csv",false);
            // dt = Import("C:\\web_sites\\Empleados.xlsx");
            // GridView1.DataSource = dt;
            // GridView1.DataBind();

            HttpPostedFile uploadedFile = FileUpload1.PostedFile;

            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {

                //string nombreArchivo = uploadedFile.FileName;

                string fileName = null;
                int lastPos = uploadedFile.FileName.LastIndexOf('\\');

                fileName  = uploadedFile.FileName.Substring(++lastPos) + DateTime.Now.Second.ToString();
                //string nombreArchivo =  fileName;

                uploadedFile.SaveAs(MapPath("carga_info" + "/"  + fileName));

                string HDR = "NO";

                // https://www.microsoft.com/en-us/download/confirmation.aspx?id=23734
                string myConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MapPath("carga_info" + "/" + fileName) + ";Extended Properties=\"Excel 12.0 Xml;HDR=" + HDR + "\"";

                //string myConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MapPath("carga_info" + "/" + fileName) + ";Extended Properties= \"Excel 8.0;HDR=Yes;IMEX=1\";";

                OleDbConnection conn = new OleDbConnection(myConnection);


                conn.Open();


                System.Data.DataTable dtExcelSchema;

                dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                sheetName = "[" + sheetName.Replace("'", "") + "]";


                string strSQL = @"SELECT F1 AS NUMERO_DOCUMENTO,F2 AS FECHA_REGISTRO,F3 AS FECHA_PAGO,F4 AS ESTADO,F5 AS VALOR_BRUTO,F6 AS VALOR_DEDUCCIONES,F7 AS VALOR_NETO,F42 AS CUENTA_POR_PAGAR,F43 AS OBLIGACION,F11 AS IDENTIFICACION,
                                F12 AS RAZON_SOCIAL,F44 AS ORDEN_PAGO  FROM " + sheetName + "";
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);


                /*
                 *  cmd.Parameters.Add("@REPORTE_FECHA_CREACION", SqlDbType.DateTime).Value = REPORTE_FECHA_CREACION;
                cmd.Parameters.Add("@REPORTE_DEPENDENCIA", SqlDbType.VarChar).Value = REPORTE_DEPENDENCIA;
                cmd.Parameters.Add("@REPORTE_CDP", SqlDbType.VarChar).Value = REPORTE_CDP;
                cmd.Parameters.Add("@REPORTE_COMPROMISO", SqlDbType.VarChar).Value = REPORTE_COMPROMISO;
                cmd.Parameters.Add("@REPORTE_OBLIGACION", SqlDbType.VarChar).Value = REPORTE_OBLIGACION;
                
                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                 * */


                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }


                conn.Close();


                System.Data.DataTable dtregistros = new System.Data.DataTable();

                DataSet dataset = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dataset);

                System.Data.DataTable dtable = new System.Data.DataTable();
                adapter.Fill(dtregistros);

                GridView1.DataSource = dataset;
                GridView1.DataBind();
                //GridView1.Sort("RAZON_SOCIAL", SortDirection.Ascending);
                //if (CheckBox1.Checked == false)
                Label1.Text = "Total registros: " + GridView1.Rows.Count;
                // else
                //    Label1.Text = "Total registros: " + (GridView1.Rows.Count - 1);
            }

           // Button1.Enabled = false;
           // ButtonGuardar.Enabled = true;

            //da.Fill(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Normalize());
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int columna_cuenta_por_pagar = 8;
        int columna_obligacion = 7;
        int columna_nivel_prob = 15;
        int columna_identificacion = 1;

        bool sin_cruce = false;

        System.Web.UI.WebControls.Image imageCruce = new System.Web.UI.WebControls.Image();
        System.Web.UI.WebControls.CheckBox chkAprobar = new System.Web.UI.WebControls.CheckBox();

        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //Dim ddlValores As DropDownList = DirectCast(e.Row.FindControl("DropDownListValores"), DropDownList)
                chkAprobar = (System.Web.UI.WebControls.CheckBox)(e.Row.FindControl("CheckBoxNoPresupuestal"));
                imageCruce = (System.Web.UI.WebControls.Image)(e.Row.FindControl("ImageCruce"));
            }
        }
        catch { }



        try
        {


            if (e.Row.Cells[columna_cuenta_por_pagar].Text != "" && e.Row.Cells[columna_cuenta_por_pagar].Text != "&nbsp;")
            {

                string cuenta_por_pagar = e.Row.Cells[columna_cuenta_por_pagar].Text;
                string identificacion = e.Row.Cells[columna_identificacion].Text;

                Cuenta cuenta = new Cuenta();
                cuenta.CuentaPorPagar = cuenta_por_pagar;
                cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);
                cuenta.obtenerDatosPorCuentaPorPagar();
                if (cuenta.IDRegistro > 0)
                {
                    //e.Row.Cells[columna_obligacion].Text = "Encontrado";
                    imageCruce.ImageUrl = "images/semV.jpg";
                    chkAprobar.Visible = false;

                }
                else
                {
                    //e.Row.Cells[columna_obligacion].Text = "No Encontrado";
                    imageCruce.ImageUrl = "images/semR.jpg";
                    sin_cruce = true;
                    if (identificacion == "830115395")
                    {
                        chkAprobar.Checked = true;
                    }
                }
                //e.Row.Cells[columna_obligacion].BackColor = Color.Green;

            }
        }
        catch { }

        if (sin_cruce)
            LiteralMensaje.Text = "<div class='warning'>Se encontraron cuentas que no cruazaron, por favor seleccione si se trata de una cuenta 'No presupuestal' o de lo contrario quedar&aacute; en estado de devoluci&oacute;n al grupo de contabilidad.</div>";
        else
            LiteralMensaje.Text = "";

    }


    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {



        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
           


            foreach (GridViewRow row in GridView1.Rows)
            {
                System.Web.UI.WebControls.CheckBox chkAprobar = new System.Web.UI.WebControls.CheckBox();
                
                //System.Data.DataTable dtregistros = cuenta.consultarCuentasPendientesContabilidad();

                try
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        //Dim ddlValores As DropDownList = DirectCast(e.Row.FindControl("DropDownListValores"), DropDownList)
                        chkAprobar = (System.Web.UI.WebControls.CheckBox)(row.FindControl("CheckBoxNoPresupuestal"));

                    }
                }
                catch { }

                try
                {

                    
                    //Si esta el checbox visible no cruzo
                    if (chkAprobar.Visible == true)
                    {

                        Cuenta_2 cuenta = new Cuenta_2();

                        cuenta.ReporteEstado = GridView1.Rows[row.RowIndex].Cells[3].Text;
                        cuenta.ReporteValorDeduccion = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[5].Text);
                        cuenta.ReporteValorBruto = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[4].Text);
                        cuenta.ReporteValorNeto = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[6].Text);
                        cuenta.ReporteObligacion = GridView1.Rows[row.RowIndex].Cells[7].Text;
                        cuenta.ReporteOrdenPago = GridView1.Rows[row.RowIndex].Cells[9].Text;
                        cuenta.CuentaPorPagar = GridView1.Rows[row.RowIndex].Cells[8].Text;

                        try
                        {
                            cuenta.FechaRegistroTesoreria = Convert.ToDateTime(GridView1.Rows[row.RowIndex].Cells[10].Text);
                        }
                        catch { }

                        try
                        {
                            cuenta.FechaPagoTesoreria = Convert.ToDateTime(GridView1.Rows[row.RowIndex].Cells[11].Text);
                        }
                        catch { }

                        if (!cuenta.cuentaPorPagarExiste())
                        {
                            //cuenta.ReporteFechaCreacion = Utiles.validarStringToDate(GridView1.Rows[row.RowIndex].Cells[1].Text);
                            cuenta.NumeroDocumentoBeneficiaro = GridView1.Rows[row.RowIndex].Cells[1].Text;
                            cuenta.NombreBeneficiario = GridView1.Rows[row.RowIndex].Cells[2].Text;


                            cuenta.ValorFactura = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[4].Text);

                            cuenta.insertar();

                            if (chkAprobar.Checked == true)
                            {
                                cuenta.noPresupuestal();
                                
                            }
                            
                            cuenta.recibidoTesoreria();
                            cuenta.sinCruce();
                        }
                         
                    }
                    else
                    {
                        Cuenta cuenta = new Cuenta();

                        cuenta.ReporteEstado = GridView1.Rows[row.RowIndex].Cells[3].Text;
                        cuenta.ReporteValorDeduccion = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[5].Text);
                        cuenta.ReporteValorBruto = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[4].Text);
                        cuenta.ReporteValorNeto = Utiles.validarNumeroToFloat(GridView1.Rows[row.RowIndex].Cells[6].Text);
                        cuenta.ReporteObligacion = GridView1.Rows[row.RowIndex].Cells[7].Text;
                        cuenta.ReporteOrdenPago = GridView1.Rows[row.RowIndex].Cells[9].Text;
                        cuenta.CuentaPorPagar = GridView1.Rows[row.RowIndex].Cells[8].Text;
                        cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);

                        try
                        {
                            cuenta.FechaRegistroTesoreria = Convert.ToDateTime(GridView1.Rows[row.RowIndex].Cells[10].Text);
                        }
                        catch { }

                        try
                        {
                            cuenta.FechaPagoTesoreria = Convert.ToDateTime(GridView1.Rows[row.RowIndex].Cells[11].Text);
                        }
                        catch { }


                        if (GridView1.Rows[row.RowIndex].Cells[8].Text.Trim() != "")
                        {
                            cuenta.CuentaPorPagar = GridView1.Rows[row.RowIndex].Cells[8].Text;

                            cuenta.obtenerDatosPorCuentaPorPagar();
                            bool cuentaPagada = cuenta.Pagada();

                            if (!cuentaPagada)
                            {
                                cuenta.insertarLOG(usuario.Alias, "", "Recibido Tesoreria", "Registro");
                                cuenta.recibidoTesoreria();

                                cuenta.insertarLOG(usuario.Alias, "", cuenta.ReporteEstado, "Registro");

                                if (cuenta.ReporteEstado == "Pagada")
                                {

                                    int id_cta_ppal = cuenta.IDCuentaPrincipal;
                                    if (id_cta_ppal > 0)
                                    {
                                        if (cuenta.cuentasDivididasPagas(id_cta_ppal))
                                        {
                                            if (CheckBoxNotificacion.Checked)
                                            {
                                                cuenta.correoPago(id_cta_ppal);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (CheckBoxNotificacion.Checked)
                                        {
                                            cuenta.correoPago();
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
                catch { }


            }




        }
        catch (Exception ex) {

            string codigo_js_error = "alert('Se genero un error:" + ex.Message.Normalize() + "');window.location.href='CargarCuentasTesoreria.aspx';";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js_error + "</script>");
        }

        string codigo_js = "alert('Proceso terminado');window.location.href='CargarCuentasTesoreria.aspx';";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js + "</script>");

        //string codigo_js = "$('html,body').animate({scrollTop: $('#example').offset().top},2000);";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js + "</script>");

    }


    private string[] validarDatos(string cuenta_pagar)
    {

        string[] resp = new string[7];

        foreach (GridViewRow row in GridView1.Rows)
        {

            string cuenta = row.Cells[5].Text;

            if (cuenta.Trim() == cuenta_pagar.Trim())
            {

                resp[0] = row.Cells[0].Text;
                resp[1] = row.Cells[1].Text;
                resp[2] = row.Cells[2].Text;
                resp[3] = row.Cells[3].Text;
                resp[4] = row.Cells[4].Text;
                resp[5] = row.Cells[5].Text;
                resp[6] = row.Cells[6].Text;
            }


        }

        return resp;
    }


    private string validarCuentaObligacion(string cuenta_pagar)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {
            string estado = row.Cells[2].Text;
            string cuenta = row.Cells[6].Text;
            string obligacion = row.Cells[7].Text;
            if (cuenta.Trim() == cuenta_pagar.Trim())
                return obligacion;
        }

        return "";
    }

    private string validarCuentaEstado(string cuenta_pagar)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {
            string estado = row.Cells[2].Text;
            string cuenta = row.Cells[6].Text;
            string obligacion = row.Cells[7].Text;
            if (cuenta.Trim() == cuenta_pagar.Trim())
                return estado;
        }

        return "";
    }

    private string validarCuentaValorBruto(string cuenta_pagar)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {
            string valor_bruto = row.Cells[3].Text;
            string cuenta = row.Cells[6].Text;
            string obligacion = row.Cells[7].Text;
            if (cuenta.Trim() == cuenta_pagar.Trim())
                return valor_bruto;
        }

        return "0";
    }

    private string validarCuentaValorNeto(string cuenta_pagar)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {
            string valor_neto = row.Cells[4].Text;
            string cuenta = row.Cells[6].Text;
            string obligacion = row.Cells[7].Text;
            if (cuenta.Trim() == cuenta_pagar.Trim())
                return valor_neto;
        }

        return "0";
    }


}
