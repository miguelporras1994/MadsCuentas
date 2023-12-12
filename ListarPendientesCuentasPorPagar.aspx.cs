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

public partial class ListarPendientesCuentasPorPagar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

            if (usuario.Perfil == "cuentasPorPagar")
            {
                try
                {
                    DropDownListAsignado.SelectedValue = nombre_usuario;
                    ViewState["usuario"] = nombre_usuario;
                    DropDownListAsignado.Enabled = false;
                    ButtonBuscar.Visible = false;

                }
                catch { }
            }


        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

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

                string select = @"SELECT * FROM View_PENDIENTES_CUENTA_CxP WHERE 1 = 1 ";

                

                if (ViewState["usuario"] != null)
                {
                    select += " AND ASIGNADO_A = @usuario";

                }
                else
                {
                    if (DropDownListAsignado.Text != "0")
                    {
                        select += " AND ASIGNADO_A = @DropDownListAsignado";
                    }
                }

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);

                if (ViewState["usuario"] != null)
                {
                    cmd.Parameters.AddWithValue("@usuario", ViewState["usuario"].ToString());

                }
                else
                {
                    if (DropDownListAsignado.Text != "0")
                    {
                        cmd.Parameters.AddWithValue("@DropDownListAsignado", DropDownListAsignado.SelectedValue);
                    }
                }
              
               
                SqlDataReader reader_sql = cmd.ExecuteReader();


                Literal1.Text = @"<body id='wide comments example'>
		                <div id='container'>
			                <div class='big full_width' align='center'><h3>Pendientes por ingreso de cuenta por pagar</h3></div>
                			
			                <div id='demo'>
                <table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	                <thead>
		                <tr>
                            <th>ID</th>
			                <th>Ver</th>
			                
                            <th>Numero Documento</th>
			                <th>Beneficiario</th>
                            <th>Numero de Pago</th>
                            <th>Contrato</th>
                            <th>SUBTOTAL</th>
                            <th>IVA</th>
                            <th>TOTAL</th>
                            <th>Asignado</th>
                            <th>Cuenta por pagar</th>
                            <th>Devolver</th>
                            
                            <th>Dias</th>
                            
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

                    if (dias >= 0 && dias < 5 ){

                        color = "green";
                        font_color = "white";
                    }
                    if (dias >= 4 && dias < 8 ){

                        color = "yellow";
                        font_color = "black";
                    }
                    
                    if (dias > 7 ){

                        color = "red";
                        font_color = "white";
                    }

                    //Literal1.Text += "<tr class='gradeA'><td><a href='EditarCuenta.aspx?id=" + reader_sql["id_registro"] + "'>Editar</a>" + "</td><td>" + reader_sql["ORDEN_PAGO"] + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td>" + reader_sql["NUM_PAGO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())) + "</td><td><img src='" + imgRecCont + "' border='0' />" + "</td><td><img src='" + imgRecTes + "' border='0' />" + "</td></tr>";
                    Literal1.Text += "<tr class='gradeA'><td>" + reader_sql["id_registro"] + "</td><td>" + "<a href='DetalleCuenta.aspx?id=" + reader_sql["id_registro"] + "&keepThis=true&TB_iframe=true&height=450&width=700' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["NUM_DOCUMENTO"] + "</td><td>" + reader_sql["NOMBRE_BENEFICIARIO"] + "</td><td >" + reader_sql["NUM_PAGO"] + "</td><td>" + reader_sql["NUMERO_CONTRATO"] + "</td><td>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_FACTURA"].ToString())).Replace("$ ", "$") + "</td><td style='width:100px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_IVA"].ToString())).Replace(" ", "") + "</td><td style='width:100px;'>" + String.Format("{0:C}", Utiles.validarNumeroToDouble(reader_sql["VALOR_TOTAL"].ToString())).Replace(" ", "") + "</td><td>" + reader_sql["ASIGNADO_A"].ToString() + "</td><td><a href='CuentaPorPagar.aspx?id=" + reader_sql["ID_REGISTRO"] + "'>CxP</a></td><td><a href='DevolverCuenta.aspx?id=" + reader_sql["ID_REGISTRO"] + "&Fuente=IngresoCuentePorPagar&Formulario=" + "ListarPendientesCuentasPorPagar.aspx" + "'>Devolver</a></td><td bgcolor = '" + color + "'><font color='" + font_color + "'>" + reader_sql["DIAS"] + "</font></td></tr>";

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

    
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
    protected void ButtonBuscar_Click1(object sender, EventArgs e)
    {
        cargarDatosReporte();
    }
}