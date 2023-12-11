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

public partial class ReasignarCuentas : System.Web.UI.Page
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

                string select = @"SELECT * FROM View_PENDIENTES_CUENTA_CxP WHERE 1 = 1";

                if (DropDownListAsignado.Text != "0")
                {
                    select += " AND ASIGNADO_A = @DropDownListAsignado";
                }

                if (DropDownListEntidad.Text != "0")
                {
                    select += " AND ID_ENTIDAD = " + DropDownListEntidad.Text;
                }

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@DropDownListAsignado", DropDownListAsignado.SelectedValue);
                cmd.Parameters.AddWithValue("@DropDownListAsignado", DropDownListAsignado.SelectedValue);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='wide comments example'>
		                <div id='container'>
			                
                			
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
                            <th>Asignado</th>
                            <th>Entidad</th>
                            <th>Devolver</th>
                            <th>Reasignar</th>
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
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td style='width:170px;'>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td style='width:170px;'>" + reader_sql["NUM_PAGO"] + "</td><td style='width:150px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())).Replace("$ ","$") + "</td><td>" + reader_sql["ASIGNADO_A"].ToString() + "</td><td>" + reader_sql["ENTIDAD"] + "</td><td><a href='DevolverCuenta.aspx?id=" + reader_sql["ID_REGISTRO"] + "&Fuente=IngresoCuentePorPagar&Formulario=" + "ListarPendientesCuentasPorPagar.aspx" + "'>Devolver</a></td><td><a href='Reasignar.aspx?id=" + reader_sql["ID_REGISTRO"] + "'>Reasignar</a></td><td bgcolor = '" + color + "'><font color='" + font_color + "'>" + reader_sql["DIAS"] + "</font></td><td><input type='checkbox' value='" + reader_sql["id_registro"] + "' name='chk_" + reader_sql["id_registro"] + "' id='chk_" + reader_sql["id_registro"] + "' /></td></tr>";

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

    protected void ButtonAsignarCuentas_Click(object sender, EventArgs e)
    {
        if (DropDownListAsignar.Text == "0")
            return;

        if (Session["usuario"] == null)
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

                int res = cuenta.reasignar(DropDownListAsignar.SelectedValue);


                cuenta.insertarLOG(usuario.Alias, "Cuenta asignada a: " + DropDownListAsignar.Text, "Asignacion", "");



                //Response.Write(s.ToString() + ":" + Request.Form[s] + "");
            }

        }

        Response.Redirect("ReasignarCuentas.aspx");

    }

}