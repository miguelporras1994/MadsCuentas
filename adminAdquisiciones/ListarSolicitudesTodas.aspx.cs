using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

public partial class ListarSolicitudesTodas : System.Web.UI.Page
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
            ConexionBD conBD = new ConexionBD("bd_con_adq");

            //string sql = @"SELECT * FROM " + tabla;

            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = @"SELECT ID_ADQUISICION, NUMERO_REGISTRO ,FECHA_REGISTRO,ESTADO.NOMBRE ESTADO,TIPO_SOLICITUD.NOMBRE TIPO,ID_TIPO_SOLICITUD
                                    FROM SOLICITUD INNER JOIN ESTADO ON SOLICITUD.ESTADO = ESTADO.ID_ESTADO 
                                    INNER JOIN TIPO_SOLICITUD ON SOLICITUD.ID_TIPO_SOLICITUD = TIPO_SOLICITUD.ID_TIPO 

";



                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader_sql = cmd.ExecuteReader();


                //Literal1.Text = @"<body id='dt_example'>
		              //  <div id='container'>
			             //   <div class='big full_width'><em>Solicitudes</em></div>
                			
			             //   <div id='demo'>
                //<table width='100%' cellpadding='0' cellspacing='0' border='0' class='display' id='example'>
	               // <thead>
		              //  <tr>
                //            <th>ID</th>
                //            <th></th>
			             //   <th>Numero Registro</th>
			             //   <th>Tipo de Solicitud</th>
                //            <th>Fecha de Registro</th>
                //            <th>Estado</th>
                            
                            
                            
		              //  </tr>
	               // </thead>
                //<tbody>";

                while (reader_sql.Read())
                {

                    //Literal1.Text += "<tr class='gradeU'><td>" + reader_sql["ID_ADQUISICION"] + "</td><td>" + "<a href='DetalleAdquisicion.aspx?id=" + reader_sql["ID_ADQUISICION"] + "&keepThis=true&TB_iframe=true&height=600&width=800' title='Consultar Detalle' class='thickbox'>Ver</a>  " + "</td><td>" + reader_sql["NUMERO_REGISTRO"] + "</td><td>" + reader_sql["TIPO"] + "</td><td style='width:370px;'>" + reader_sql["FECHA_REGISTRO"] + "</td><td>" + reader_sql["ESTADO"] + "</td></tr>";

                }

                //Literal1.Text += @"</tbody>
                //<tfoot>
		              //  <tr>
                //            <th></th>
                //            <th></th>
			             //   <th></th>
			             //   <th></th>
                //            <th></th>
                //            <th></th>
			                
		              //  </tr>
	               // </tfoot>
                //</table>

                //";

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
}