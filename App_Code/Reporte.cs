using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class Reporte
{


    public Reporte()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static DataTable ReporteFacturaElectronica(string id_registro, string numero_doc)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_FACTURACION_E WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = @reporte";
                }

                if (id_registro.Trim() != "")
                {

                    select += " AND ID_REGISTRO =  @id_registro ";
                }



                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@reporte", numero_doc);
                cmd.Parameters.AddWithValue("@id_registro", id_registro);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }




    public static DataTable ReporteGeneral(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin, string id_reporte)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_REPORTE_GENERAL WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = @numero_doc";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND REPORTE_ORDEN_PAGO = @orden_pago";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = @cxp";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%@nombre%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%@correo%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = @id_entidad ";
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = @tipo_solicitud ";


                }

                if (id_reporte != "")
                {

                    select += " AND ID_REGISTRO = @id_reporte";


                }


                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }

                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@numero_doc", numero_doc);
                cmd.Parameters.AddWithValue("@orden_pago", orden_pago.Trim());
                cmd.Parameters.AddWithValue("@cxp", cxp.Trim());
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                cmd.Parameters.AddWithValue("@correo", correo.Trim());
                cmd.Parameters.AddWithValue("@id_entidad", id_entidad);
                cmd.Parameters.AddWithValue("@tipo_solicitud", tipo_solicitud);
                cmd.Parameters.AddWithValue("@id_reporte", id_reporte);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public static DataTable RegistrarDevolucion(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_PARA_DEVOLUCION WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = @nombre";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO =  @orden_pago";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = @cxp ";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%@nombre.Trim()%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%@correo%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD =@id_entidad ";
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = @tipo_solicitud";


                }


                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }


                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);

                cmd.Parameters.AddWithValue("@numero_doc", numero_doc);
                cmd.Parameters.AddWithValue("@orden_pago", orden_pago.Trim());
                cmd.Parameters.AddWithValue("@cxp", cxp.Trim());
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                cmd.Parameters.AddWithValue("@correo", correo.Trim());
                cmd.Parameters.AddWithValue("@id_entidad", id_entidad);
                cmd.Parameters.AddWithValue("@tipo_solicitud", tipo_solicitud);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public static DataTable EditarCuentas(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_EDITAR_CUENTAS WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}

                select += " ORDER BY ID_REGISTRO DESC";


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }

    public static DataTable ListarCxP(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_CxP WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}


                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public static DataTable ListarCuentasObligacion(int id_entidad, string numero_doc, string nombre, string fecha_ini, string fecha_fin, int id_registro, string asignado_a, bool sin_obligacion)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_ASIGNADAS_CONTABILIDAD WHERE 1 = 1 ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (sin_obligacion)
                {

                    select += " AND REPORTE_OBLIGACION IS NULL ";
                }

                if (id_registro != 0)
                {

                    select += " AND ID_REGISTRO = " + id_registro.ToString();
                }

                if (asignado_a.Trim() != "0")
                {

                    select += " AND CONTABILIDAD_ASIGNADO_A LIKE '%" + asignado_a.Trim() + "%'";
                }



                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }


                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }


                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }



    public static DataTable ListarInformesContratistaPendientes(string aprobador)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"LISTAR_INFORMES_CONTRATISTAS_APROBADOR";


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@APROBADOR", SqlDbType.VarChar).Value = aprobador;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }

    public static DataTable ListarAccionesInformesContratista(int id_informe)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"LISTAR_INFORME_ACCIONES";


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_INFORME", SqlDbType.Int).Value = id_informe;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }



    public static DataTable EliminarLiquidacion(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_ELIMINAR_LIQUIDACION WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}

                select += " ORDER BY ID_REGISTRO DESC";


                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }

    public static DataTable EliminarCxP(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_ELIMINAR_CXP WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}

                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public static DataTable Adjuntar(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin, bool sin_adjuntos, bool radicados_hoy)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_CUENTAS_ADJUNTAR WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}

                if (radicados_hoy)
                {

                    select += " AND FECHA_RADICADO >= cast (GETDATE() as DATE)";
                }

                if (sin_adjuntos)
                {
                    select += " AND ID_REGISTRO NOT IN(SELECT ID_REPORTE FROM ADJUNTOS_CUENTAS)";
                }


                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }


    public static DataTable Liquidar(int ano, int id_entidad, string numero_doc, string nombre, string cxp, string correo, string orden_pago, int tipo_solicitud, string fecha_ini, string fecha_fin)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_PENDIENTES_LIQUIDACION WHERE 1 = 1  ";

                if (numero_doc != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + numero_doc + "'";
                }

                if (orden_pago.Trim() != "")
                {

                    select += " AND ID_REGISTRO = " + orden_pago.Trim() + "";
                }

                if (cxp.Trim() != "")
                {

                    select += " AND CUENTA_POR_PAGAR = '" + cxp.Trim() + "'";
                }

                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (correo.Trim() != "")
                {

                    select += " AND CORREO LIKE '%" + correo.Trim() + "%'";
                }

                if (id_entidad != 0)
                {

                    select += " AND ID_ENTIDAD = " + id_entidad.ToString();
                }

                if (tipo_solicitud != 0)
                {

                    select += " AND ID_TIPO_DOCUMENTO = " + tipo_solicitud.ToString();


                }

                //if (ano > 0)
                //{
                //    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                //}
                //else
                //{

                if (fecha_ini.ToString() != "" && fecha_fin.ToString() != "")
                {



                    select += " AND [FECHA_RADICADO] BETWEEN CAST('" + DateTime.ParseExact(fecha_ini.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 00:00:00' AS DATETIME)";
                    select += " AND CAST('" + DateTime.ParseExact(fecha_fin.ToString(), ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null).ToString(ConfigurationSettings.AppSettings["FormatoFechaQuery"]) + " 23:59:59' AS DATETIME)";


                }
                //    else
                //    {
                //        //select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                //    }
                //}

                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }



    public static DataTable ReporteCuentasEditar(int ano)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_EDITAR_CUENTAS WHERE 1 = 1";

                select += " and year(FECHA_RADICADO) = " + ano.ToString();

                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }

    public static DataTable ReporteCuentasAdjuntar(int ano, int id_radicado, string documento, string nombre)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT * FROM View_LISTAR_CUENTAS_ADJUNTAR WHERE 1 = 1";

                if (documento != "")
                {

                    select += " AND NUM_DOCUMENTO = '" + documento + "'";
                }



                if (nombre.Trim() != "")
                {

                    select += " AND NOMBRE_BENEFICIARIO LIKE '%" + nombre.Trim() + "%'";
                }

                if (ano > 0)
                {
                    select += " and year(FECHA_RADICADO) = " + ano.ToString();
                }
                else
                {
                    select += " and year(FECHA_RADICADO) = YEAR(GETDATE()) ";
                }

                select += " ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtregistros);

                conn.Close();
                da.Dispose();

            }
        }
        catch (SqlException ex)
        {


        }

        return dtregistros;
    }





}