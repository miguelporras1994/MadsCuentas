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


public partial class CargarObjetos : System.Web.UI.Page
{
    private int id_bodega = 0;
    private int id_proyecto = 0;
    private int id_usuario = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
        {
            Response.Redirect("Formularios.aspx");
        }
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

                fileName = DateTime.Now.Second.ToString() + "_" + uploadedFile.FileName.Substring(++lastPos);
                //string nombreArchivo =  fileName;

                uploadedFile.SaveAs(MapPath("carga_info" + "/" + fileName));

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


                string strSQL = @"SELECT F1 AS RP,F2 AS OBJETO  FROM " + sheetName + "";
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);

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

                //if (CheckBox1.Checked == false)
                Label1.Text = "Total registros: " + GridView1.Rows.Count;
                // else
                //    Label1.Text = "Total registros: " + (GridView1.Rows.Count - 1);
            }

            Button1.Enabled = false;
            ButtonGuardar.Enabled = true;

            //da.Fill(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Normalize());
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int columna_rp = 0;
        int columna_objeto = 1;

        try
        {


            if (e.Row.Cells[columna_rp].Text != "" && e.Row.Cells[columna_objeto].Text != "&nbsp;")
            {

                string rp = e.Row.Cells[columna_rp].Text;
                string objeto = e.Row.Cells[columna_objeto].Text;

  
            }
        }
        catch { }

       
    }


    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {


        Usuarios usuario = (Usuarios)Session["usuario"];
        foreach (GridViewRow row in GridView1.Rows)
        {

            try
            {
                string rp = GridView1.Rows[row.RowIndex].Cells[0].Text;
                string objeto = GridView1.Rows[row.RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                Cuenta.insertarRPObjeto(rp, objeto,Utiles.validarNumeroToInt(DropDownListEntidad.Text));

            }
            catch { }


        }


        string codigo_js = "alert('Proceso terminado');window.location.href='CargarObjetos.aspx';";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>" + codigo_js + "</script>");

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
