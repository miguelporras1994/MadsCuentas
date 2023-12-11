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

using ZedGraph;

using System.Collections.Generic;


public partial class ListarPendientesAsignacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["usuario"] == null)
            Response.Redirect("Login.aspx");

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

                string select = @"SELECT * FROM View_PENDIENTES_ASIGNACION";

                if (DropDownListEntidad.Text != "0")
                {
                    select += " WHERE ID_ENTIDAD = @DropDownListEntidad ";
                }


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@DropDownListEntidad", DropDownListEntidad.Text);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='dt_example'>
		                <div id='container'>
			                <div class='big full_width'><h3>Pendientes Asignaci&oacute;n</h3></div>
                			
			                <div id='demo'>
                <table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
                            <th>ID</th>
			                <th>Ver</th>
			                
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Valor Factura</th>
                            <th>Reasignar</th>
                            <th>Entidad</th>
                            <th>Dias transcurridos</th>
                            <th>Asignar:<p><label><input type='checkbox' id='checkAll'/>Todos</label></p></th>
                        </tr>
	                </thead>
                <tbody>";

                while (reader_sql.Read())
                {
                    //string nombre_id = reader_sql.GetName(1);
                    string imgRecCont = (reader_sql["RECIBIDO_CONTABILIDAD"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";
                    string imgRecTes = (reader_sql["RECIBIDO_TESORERIA"].ToString().Trim() == "1") ? "images/semV.jpg" : "images/semR.jpg";

                    int dias = Utiles.validarNumeroToInt(reader_sql["DIAS"].ToString());
                    string color = "";
                    string font_color = "";

                    if (dias >= 0 && dias < 5)
                    {

                        color = "green";
                        font_color = "white";
                    }
                    if (dias >= 4 && dias < 8)
                    {

                        color = "yellow";
                        font_color = "black";
                    }

                    if (dias > 7)
                    {

                        color = "red";
                        font_color = "white";
                    }

                    //Literal1.Text += "<tr class='gradeA'><td><a href='EditarCuenta.aspx?id=" + reader_sql["id_registro"] + "'>Editar</a>" + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td><img src='" + imgRecCont + "' border='0' />" + "</td><td><img src='" + imgRecTes + "' border='0' />" + "</td></tr>";
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td><a href='Reasignar.aspx?Formulario=ListarPendientesAsignacion.aspx&id=" + reader_sql["ID_REGISTRO"] + "'>Asignar</a></td><td>" + reader_sql["ENTIDAD"] + "</td><td bgcolor = '" + color + "'><font color='" + font_color + "'>" + reader_sql["DIAS"] + "</font></td><td><input type='checkbox' value='" + reader_sql["id_registro"] + "' name='chk_" + reader_sql["id_registro"] + "' id='chk_" + reader_sql["id_registro"] + "' /></td></tr>";

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


    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.ZedGraphWeb1.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph1);
        //this.ZedGraphWeb2.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph2);
    }
    #endregion


    private void OnRenderGraph1(ZedGraph.Web.ZedGraphWeb z, System.Drawing.Graphics g, ZedGraph.MasterPane masterPane)
    {
        // Get the GraphPane so we can work with it
        GraphPane myPane = masterPane[0];

        // Set the title and axis labels        
        myPane.XAxis.Title.Text = "Responsable";
        myPane.YAxis.Title.Text = "Asignada";
        myPane.XAxis.Scale.FontSpec.Angle = 90;

        List<string> list = new List<string>();
        List<double> list2 = new List<double>();



        try
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bd_con"];
            ConexionBD conBD = new ConexionBD("bd_con");


            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = @"CONSULTAR_CUENTAS_ASIGNADAS_USUARIO";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader_sql = cmd.ExecuteReader();



                while (reader_sql.Read())
                {
                    list.Add(reader_sql["USUARIO"].ToString());
                    list2.Add((double)PetroIMS.validarNumeroToInt(reader_sql["CUENTAS"].ToString()));
                    //labels[] = reader_sql["nombre"];
                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {
        }

        string[] labels = list.ToArray();
        double[] x2 = list2.ToArray();

        // Make up some data points
        //string[] labels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        double[] xAxis = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        double[] x = { 10, 60, 50, 60, 50, 90, 50, 90, 70 };

        /*
        double[] x = { 10, 60, 50, 60, 50, 90, 50, 90, 70 };
        double[] x2 = { 30, 40, 20, 30, 30, 60, 90, 90, 50 };
        double[] x3 = { 60, 60, 20, 20, 90, 30, 80, 60, 50 };
        double[] x4 = { 80, 50, 20, 20, 90, 80, 30, 50, 60 };
        double[] x6 = { 80, 50, 20, 20, 90, 80, 30, 50, 60 };
        double[] x5 = { 90, 10, 20, 20, 20, 20, 50, 30, 90 };
        */

        // Declare a BarItem:- Bar Item is used for creating a bar     
        BarItem myCurve;
        // Declare a LineItem:- LineItem is used for creating a line     
        LineItem oLineItem;




        // Generate a red bar with "Identified" in the legend
        myCurve = myPane.AddBar("Asignadas", null, x2, Color.Green);

        myCurve.Label.IsVisible = true;
        // Fill the bar with a red-white-red color gradient for a 3d look
        myCurve.Bar.Fill = new Fill(Color.CadetBlue, Color.White, Color.Aquamarine, 0f);

        // Set the XAxis labels
        myPane.XAxis.Scale.TextLabels = labels;
        // Set the XAxis to Text type
        myPane.XAxis.Type = AxisType.Text;

        // Make the bars Vertical by setting the BarBase to "X"
        myPane.BarSettings.Base = BarBase.X;

        // Set the bar type to stack, which stacks the bars by automatically accumulating the values
        myPane.BarSettings.Type = BarType.Cluster;

        // Fill the axis background with a color gradient
        myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 212, 212), 45.0F);

        BarItem.CreateBarLabels(myPane, false, "f2");

        for (int i = 0; i < myCurve.Points.Count; i++)
        {
            TextObj barLabel = new TextObj(myCurve.Points[i].Y.ToString(), myCurve.Points[i].X, myCurve.Points[i].Y + 5);
            barLabel.FontSpec.Border.IsVisible = false;
            myPane.GraphObjList.Add(barLabel);
        }

        myCurve.Label.IsVisible = true;

        masterPane.AxisChange(g);
    }


    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
    protected void ButtonBuscar_Click1(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }

    protected void ButtonAsignarCuentas_Click(object sender, EventArgs e)
    {
        if (DropDownListAsignado.Text == "0")
            return;

        if(Session["usuario"] == null)
            Response.Redirect("Login.aspx");

        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;
       

        //Request.Form
        foreach (string s in Request.Form.Keys)
        {
            if (s.Contains("chk_"))
            {

                int id_registro = Utiles.validarNumeroToInt(Request.Form[s].ToString());
                ViewState["id_registro"] = id_registro;
                Cuenta cuenta = new Cuenta(id_registro);

                int res = cuenta.reasignar(DropDownListAsignado.SelectedValue);


                cuenta.insertarLOG(usuario.Alias, "Cuenta asignada a: " + DropDownListAsignado.Text, "Asignacion", "");
                


                //Response.Write(s.ToString() + ":" + Request.Form[s] + "");
            }

        }

        Response.Redirect("ListarPendientesAsignacion.aspx");

    }
}