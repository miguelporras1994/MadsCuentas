using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class Cuenta_2
{
    private int id_registro = 0;
    private string ORDEN_PAGO = "";
    private int ID_TIPO_DOCUMENTO = 0;
    private string NUM_DOCUMENTO = "";
    private string NOMBRE_BENEFICIARIO = "";
    private string NUM_PAGo = "";
    private double VALOR_FACTURA = 0;
    private DateTime FECHA_RADICADO = DateTime.Now;
    private int ID_ESTADO = 0;
    private string NUM_OBLIGACION = "";
    private DateTime FECHA_RECIBIDO_CONTABILIDAD;
    private DateTime FECHA_RECIBIDO_TESORERIA;
    private DateTime FECHA_ORDEN_PAGO;
    private string OBSERVACIONES = "";
    private string CUENTA_POR_PAGAR = "";
    private int ASIGNADO = 0;
    private string ASIGNADO_A = "";
    private string USUARIO = "";
    private string ESTADO = "";
    private bool DEVUELTA = false;
    private string CORREO = "";
    private float VALOR_BRUTO = 0;
    private float VALOR_NETO = 0;
    private int ID_TIPO_SOLICITUD = 0;
    private string NUMERO_FACTURA = "";
    private string NUMERO_RP = "";
    private string NUMERO_CONTRATO = "";

    private DateTime REPORTE_FECHA_CREACION;
    private string REPORTE_DEPENDENCIA = "";
    private string REPORTE_CDP = "";
    private string REPORTE_COMPROMISO = "";
    private string REPORTE_OBLIGACION = "";
    private string REPORTE_ESTADO = "";
    private float REPORTE_VALOR_BRUTO = 0;
    private float REPORTE_VALOR_NETO = 0;
    private float REPORTE_VALOR_DEDUCCION = 0;
    private string REPORTE_ORDEN_PAGO = "";
    private string REPORTE_NUMERO_DOCUMENTO_CONTABILIDAD = "";
    private string REPORTE_NUMERO_DOCUMENTO_TESORERIA = "";
    private DateTime REPORTE_FECHA_REGISTRO_CONTABILIDAD = DateTime.Now;
    private DateTime REPORTE_FECHA_CREACION_CONTABILIDAD = DateTime.Now;
    private DateTime REPORTE_FECHA_REGISTRO_TESORERIA = DateTime.Now;
    private DateTime REPORTE_FECHA_PAGO_TESORERIA = DateTime.Now;
    private int ID_CTA_PRINCIPAL = 0;
    private int DIVIDIDA = 0;


    private int NO_PRESUPUESTAL = 0;

    public Cuenta_2()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Cuenta_2(int id_registro)
    {

        this.id_registro = id_registro;
        obtenerDatos();
    }

    private void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM CUENTA_2 WHERE ID_REGISTRO = " + this.id_registro.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA_RADICADO = (reader["FECHA_RADICADO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RADICADO"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_CONTABILIDAD = (reader["FECHA_RECIBIDO_CONTABILIDAD"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_CONTABILIDAD"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_TESORERIA = (reader["FECHA_RECIBIDO_TESORERIA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_TESORERIA"].ToString()) : DateTime.Now;
                    FECHA_ORDEN_PAGO = (reader["FECHA_ORDEN_PAGO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_ORDEN_PAGO"].ToString()) : DateTime.Now;
                    ORDEN_PAGO = reader["ORDEN_PAGO"].ToString();
                    ID_TIPO_DOCUMENTO = Utiles.validarNumeroToInt(reader["ID_TIPO_DOCUMENTO"].ToString());
                    NUM_DOCUMENTO = reader["NUM_DOCUMENTO"].ToString();
                    NOMBRE_BENEFICIARIO = reader["NOMBRE_BENEFICIARIO"].ToString();
                    NUM_PAGo = reader["NUM_PAGO"].ToString();
                    VALOR_FACTURA = Utiles.validarNumeroToDouble(reader["VALOR_FACTURA"].ToString());
                    ID_ESTADO = Utiles.validarNumeroToInt(reader["ID_ESTADO"].ToString());
                    NUM_OBLIGACION = reader["NUM_OBLIGACION"].ToString();
                    OBSERVACIONES = reader["OBSERVACIONES"].ToString();
                    CUENTA_POR_PAGAR = reader["CUENTA_POR_PAGAR"].ToString();
                    ASIGNADO = Utiles.validarNumeroToInt(reader["ASIGNADO"].ToString());
                    ASIGNADO_A = reader["ASIGNADO_A"].ToString();
                    USUARIO = reader["USUARIO"].ToString();
                    ESTADO = reader["ESTADO"].ToString();
                    DEVUELTA = (reader["DEVUELTA"] != DBNull.Value) ? true : false;
                    CORREO = reader["CORREO"].ToString();

                    NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString();
                    NUMERO_RP = reader["NUMERO_RP"].ToString();
                    NUMERO_FACTURA = reader["NUMERO_FACTURA"].ToString();
                    ID_TIPO_SOLICITUD = Utiles.validarNumeroToInt(reader["ID_TIPO_SOLICITUD"].ToString());

                    ID_CTA_PRINCIPAL = Utiles.validarNumeroToInt(reader["ID_CTA_PRINCIPAL"].ToString());
                    DIVIDIDA = Utiles.validarNumeroToInt(reader["DIVIDIDA"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }


    public void obtenerDatosPorCuentaPorPagar()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM CUENTA_2 WHERE CUENTA_POR_PAGAR = '" + this.CUENTA_POR_PAGAR.ToString() + "'";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA_RADICADO = (reader["FECHA_RADICADO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RADICADO"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_CONTABILIDAD = (reader["FECHA_RECIBIDO_CONTABILIDAD"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_CONTABILIDAD"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_TESORERIA = (reader["FECHA_RECIBIDO_TESORERIA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_TESORERIA"].ToString()) : DateTime.Now;
                    FECHA_ORDEN_PAGO = (reader["FECHA_ORDEN_PAGO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_ORDEN_PAGO"].ToString()) : DateTime.Now;
                    ORDEN_PAGO = reader["ORDEN_PAGO"].ToString();
                    ID_TIPO_DOCUMENTO = Utiles.validarNumeroToInt(reader["ID_TIPO_DOCUMENTO"].ToString());
                    NUM_DOCUMENTO = reader["NUM_DOCUMENTO"].ToString();
                    NOMBRE_BENEFICIARIO = reader["NOMBRE_BENEFICIARIO"].ToString();
                    NUM_PAGo = reader["NUM_PAGO"].ToString();
                    VALOR_FACTURA = Utiles.validarNumeroToDouble(reader["VALOR_FACTURA"].ToString());
                    ID_ESTADO = Utiles.validarNumeroToInt(reader["ID_ESTADO"].ToString());
                    NUM_OBLIGACION = reader["NUM_OBLIGACION"].ToString();
                    OBSERVACIONES = reader["OBSERVACIONES"].ToString();
                    CUENTA_POR_PAGAR = reader["CUENTA_POR_PAGAR"].ToString();
                    ASIGNADO = Utiles.validarNumeroToInt(reader["ASIGNADO"].ToString());
                    ASIGNADO_A = reader["ASIGNADO_A"].ToString();
                    USUARIO = reader["USUARIO"].ToString();
                    ESTADO = reader["ESTADO"].ToString();
                    DEVUELTA = (reader["DEVUELTA"] != DBNull.Value) ? true : false;
                    CORREO = reader["CORREO"].ToString();

                    NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString();
                    NUMERO_RP = reader["NUMERO_RP"].ToString();
                    NUMERO_FACTURA = reader["NUMERO_FACTURA"].ToString();
                    ID_TIPO_SOLICITUD = Utiles.validarNumeroToInt(reader["ID_TIPO_SOLICITUD"].ToString());
                    id_registro = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());

                    ID_CTA_PRINCIPAL = Utiles.validarNumeroToInt(reader["ID_CTA_PRINCIPAL"].ToString());
                    DIVIDIDA = Utiles.validarNumeroToInt(reader["DIVIDIDA"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }


    public void obtenerDatosPorDocumento()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT TOP 1 * FROM CUENTA_2 WHERE NUM_DOCUMENTO = '" + this.NUM_DOCUMENTO + "' ORDER BY ID_REGISTRO DESC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA_RADICADO = (reader["FECHA_RADICADO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RADICADO"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_CONTABILIDAD = (reader["FECHA_RECIBIDO_CONTABILIDAD"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_CONTABILIDAD"].ToString()) : DateTime.Now;
                    FECHA_RECIBIDO_TESORERIA = (reader["FECHA_RECIBIDO_TESORERIA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_RECIBIDO_TESORERIA"].ToString()) : DateTime.Now;
                    FECHA_ORDEN_PAGO = (reader["FECHA_ORDEN_PAGO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_ORDEN_PAGO"].ToString()) : DateTime.Now;
                    ORDEN_PAGO = reader["ORDEN_PAGO"].ToString();
                    ID_TIPO_DOCUMENTO = Utiles.validarNumeroToInt(reader["ID_TIPO_DOCUMENTO"].ToString());
                    NUM_DOCUMENTO = reader["NUM_DOCUMENTO"].ToString();
                    NOMBRE_BENEFICIARIO = reader["NOMBRE_BENEFICIARIO"].ToString();
                    NUM_PAGo = reader["NUM_PAGO"].ToString();
                    VALOR_FACTURA = Utiles.validarNumeroToDouble(reader["VALOR_FACTURA"].ToString());
                    ID_ESTADO = Utiles.validarNumeroToInt(reader["ID_ESTADO"].ToString());
                    NUM_OBLIGACION = reader["NUM_OBLIGACION"].ToString();
                    OBSERVACIONES = reader["OBSERVACIONES"].ToString();
                    CUENTA_POR_PAGAR = reader["CUENTA_POR_PAGAR"].ToString();
                    ASIGNADO = Utiles.validarNumeroToInt(reader["ASIGNADO"].ToString());
                    ASIGNADO_A = reader["ASIGNADO_A"].ToString();
                    USUARIO = reader["USUARIO"].ToString();
                    ESTADO = reader["ESTADO"].ToString();
                    DEVUELTA = (reader["DEVUELTA"] != DBNull.Value) ? true : false;
                    CORREO = reader["CORREO"].ToString();

                    NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString();
                    NUMERO_RP = reader["NUMERO_RP"].ToString();
                    NUMERO_FACTURA = reader["NUMERO_FACTURA"].ToString();
                    ID_TIPO_SOLICITUD = Utiles.validarNumeroToInt(reader["ID_TIPO_SOLICITUD"].ToString());
                    id_registro = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }









    public DataTable consultarCuentasPendientesContabilidad()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT *
                                FROM CUENTA
                                WHERE RECIBIDO_CONTABILIDAD IS NULL AND CUENTA_POR_PAGAR IS NOT NULL AND CUENTA_POR_PAGAR <> ''";

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



    public string obtenerNombreAdjunto()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS_POR_PAGAR WHERE ID_REPORTE = " + this.id_registro.ToString();

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "";
        }
    }

    public bool Pagada()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT OPERACION FROM LOG_EVENTOS WHERE OPERACION = 'Pagada' AND ID_CUENTA = " + this.id_registro.ToString();

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = false;
                else
                    resp = true;

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return false;
        }
    }



    public string obtenerNombreAdjunto(int id_adjunto)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT ARCHIVO FROM ADJUNTOS_CUENTAS WHERE ID_ADJUNTO = " + id_adjunto.ToString();

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = "";
                else
                    resp = o.ToString();

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return "";
        }
    }

    public bool cuentaPorPagarExiste()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT * FROM CUENTA WHERE CUENTA_POR_PAGAR = '" + this.CUENTA_POR_PAGAR + "'";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = false;
                else
                    resp = true;

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return false;
        }
    }

    public DataTable consultarCuentasPendientesTesoreria()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT *
                                FROM CUENTA
                                WHERE RECIBIDO_TESORERIA IS NULL AND CUENTA_POR_PAGAR IS NOT NULL AND CUENTA_POR_PAGAR <> '' AND DEVUELTA <> 1";

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

    public int recibidoContabilidad()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET REPORTE_FECHA_CREACION = @REPORTE_FECHA_CREACION,REPORTE_DEPENDENCIA = @REPORTE_DEPENDENCIA,REPORTE_CDP = @REPORTE_CDP,
                                REPORTE_COMPROMISO = @REPORTE_COMPROMISO,REPORTE_OBLIGACION = @REPORTE_OBLIGACION,FECHA_RECIBIDO_CONTABILIDAD = GETDATE(),RECIBIDO_CONTABILIDAD = 1,
                                REPORTE_FECHA_REGISTRO_CONTABILIDAD = @REPORTE_FECHA_REGISTRO_CONTABILIDAD,
                                REPORTE_FECHA_CREACION_CONTABILIDAD = @REPORTE_FECHA_CREACION_CONTABILIDAD
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@REPORTE_FECHA_CREACION", SqlDbType.DateTime).Value = REPORTE_FECHA_CREACION;
                cmd.Parameters.Add("@REPORTE_DEPENDENCIA", SqlDbType.VarChar).Value = REPORTE_DEPENDENCIA;
                cmd.Parameters.Add("@REPORTE_CDP", SqlDbType.VarChar).Value = REPORTE_CDP;
                cmd.Parameters.Add("@REPORTE_COMPROMISO", SqlDbType.VarChar).Value = REPORTE_COMPROMISO;
                cmd.Parameters.Add("@REPORTE_OBLIGACION", SqlDbType.VarChar).Value = REPORTE_OBLIGACION;
                cmd.Parameters.Add("@REPORTE_NUMERO_DOCUMENTO_CONTABILIDAD", SqlDbType.VarChar).Value = REPORTE_NUMERO_DOCUMENTO_CONTABILIDAD;
                cmd.Parameters.Add("@REPORTE_FECHA_REGISTRO_CONTABILIDAD", SqlDbType.DateTime).Value = REPORTE_FECHA_REGISTRO_CONTABILIDAD;
                cmd.Parameters.Add("@REPORTE_FECHA_CREACION_CONTABILIDAD", SqlDbType.DateTime).Value = REPORTE_FECHA_CREACION_CONTABILIDAD;
                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }


    public int actualizarEstado()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET ESTADO = @ESTADO
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO;
                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int Dividir()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET DIVIDIDA = 1, CUENTA_POR_PAGAR = 'DIVIDIDA' WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int SetIDCuentaPrincipal()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET ID_CTA_PRINCIPAL = @ID_CTA_PRINCIPAL
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_CTA_PRINCIPAL", SqlDbType.Int).Value = ID_CTA_PRINCIPAL;
                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }


    public int sinCruce()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET SIN_CRUCE = 1
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int noPresupuestal()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET NO_PRESUPUESTAL = 1
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int recibidoTesoreria()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET REPORTE_ESTADO = @REPORTE_ESTADO,FECHA_RECIBIDO_TESORERIA = GETDATE(),RECIBIDO_TESORERIA = 1,
                              REPORTE_VALOR_BRUTO = @REPORTE_VALOR_BRUTO, REPORTE_VALOR_NETO = @REPORTE_VALOR_NETO,REPORTE_VALOR_DEDUCCION = @REPORTE_VALOR_DEDUCCION,
                              REPORTE_ORDEN_PAGO = @REPORTE_ORDEN_PAGO,REPORTE_FECHA_REGISTRO_TESORERIA = @REPORTE_FECHA_REGISTRO_TESORERIA,REPORTE_FECHA_PAGO_TESORERIA = @REPORTE_FECHA_PAGO_TESORERIA,
                              REPORTE_NUMERO_DOCUMENTO_TESORERIA = @REPORTE_NUMERO_DOCUMENTO_TESORERIA,
                              REPORTE_OBLIGACION = @REPORTE_OBLIGACION
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@REPORTE_VALOR_BRUTO", SqlDbType.Decimal).Value = REPORTE_VALOR_BRUTO;
                cmd.Parameters.Add("@REPORTE_VALOR_NETO", SqlDbType.Decimal).Value = REPORTE_VALOR_NETO;
                cmd.Parameters.Add("@REPORTE_VALOR_DEDUCCION", SqlDbType.Decimal).Value = REPORTE_VALOR_DEDUCCION;
                cmd.Parameters.Add("@REPORTE_ESTADO", SqlDbType.VarChar).Value = REPORTE_ESTADO;
                cmd.Parameters.Add("@REPORTE_ORDEN_PAGO", SqlDbType.VarChar).Value = REPORTE_ORDEN_PAGO;
                cmd.Parameters.Add("@REPORTE_NUMERO_DOCUMENTO_TESORERIA", SqlDbType.VarChar).Value = REPORTE_NUMERO_DOCUMENTO_TESORERIA;
                cmd.Parameters.Add("@REPORTE_FECHA_REGISTRO_TESORERIA", SqlDbType.DateTime).Value = REPORTE_FECHA_REGISTRO_TESORERIA;
                cmd.Parameters.Add("@REPORTE_FECHA_PAGO_TESORERIA", SqlDbType.DateTime).Value = REPORTE_FECHA_PAGO_TESORERIA;
                cmd.Parameters.Add("@REPORTE_OBLIGACION", SqlDbType.VarChar).Value = REPORTE_OBLIGACION;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }




    public int actualizarCuentaPorPagar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET CUENTA_POR_PAGAR = @CUENTA_POR_PAGAR
                              WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@CUENTA_POR_PAGAR", SqlDbType.VarChar).Value = CUENTA_POR_PAGAR;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }




    public int devolver()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET DEVUELTA = 1 WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }


    public int devolverInterna(int ID_GRUPO_DEVOLUCION)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET DEVUELTA = 2 , ID_GRUPO_DEVOLUCION = @ID_GRUPO_DEVOLUCION WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@ID_GRUPO_DEVOLUCION", SqlDbType.Int).Value = ID_GRUPO_DEVOLUCION;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int reasignar(string ASIGNADO_A)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET ASIGNADO_A = @ASIGNADO_A WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@ASIGNADO_A", SqlDbType.VarChar).Value = ASIGNADO_A;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int reasignarContabilidad(string ASIGNADO_A)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET CONTABILIDAD_ASIGNADO_A = @ASIGNADO_A WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@ASIGNADO_A", SqlDbType.VarChar).Value = ASIGNADO_A;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int reasignarTesoreria(string ASIGNADO_A)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET TESORERIA_ASIGNADO_A = @ASIGNADO_A WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@ASIGNADO_A", SqlDbType.VarChar).Value = ASIGNADO_A;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }


    public int resolverDevolucion()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE CUENTA SET DEVUELTA = NULL WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }


    public void correoDevolucion(string motivo)
    {

        try
        {
            Correo correo = new Correo();

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
            <head>
            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

            <style type='text/css'>
            <!--
            .Estilo4 {font-family: 'Times New Roman', Times, serif}
            -->
            </style>
            </head>

            <body>";

            cuerpo_correo = "Señor(a) " + this.NOMBRE_BENEFICIARIO + "<br /><br />";
            cuerpo_correo += "La cuenta con n&uacute;mero de radicaci&oacute;n No." + this.id_registro + "inscrita a su nombre ha sido devuelta por la siguiente raz&oacute;n:<br /><br />";
            cuerpo_correo += motivo + "<br /><br /><br /><br />";

            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'></span>.</p>
           
            </body>
            </html>
            ";

            Correo.enviarHTML(CORREO, "Devolucion de cuenta " + this.id_registro.ToString(), cuerpo_correo, ConfigurationSettings.AppSettings["CorreoRemitente"]);
        }
        catch { }

    }

    public void correoInscripcion()
    {

        try
        {
            Correo correo = new Correo();

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
                <head>
                <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

                <style type='text/css'>
                <!--
                .Estilo4 {font-family: 'Times New Roman', Times, serif}
                -->
                </style>
                </head>

                <body>";

            cuerpo_correo += "Señor(a) " + this.NOMBRE_BENEFICIARIO + "<br /><br />";
            cuerpo_correo += "Se ha registrado una cuenta por pagar a su nombre por un valor de " + String.Format("{0:C}", Utiles.validarNumeroToDouble(this.VALOR_FACTURA.ToString())) + ", con n&uacute;mero de radicaci&oacute;n " + this.id_registro + " .Cualquier novedad ser&aacute; notificada por este medio<br /><br />";


            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'>Este mensaje es una notificaci&oacute;n autom&aacute;tica, por lo tanto le solicitamos no responder a esta direcci&oacute;n de correo</span>.</p>
           
            </body>
            </html>
            ";

            //Correo.enviarHTML(CORREO, "Radicacion de cuenta " + this.id_registro.ToString(), cuerpo_correo, "");
        }
        catch { }

    }

    public void correoPago()
    {

        try
        {
            Correo correo = new Correo();

            string cuerpo_correo = @"<html xmlns='http://www.w3.org/1999/xhtml\'>
            <head>
            <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />

            <style type='text/css'>
            <!--
            .Estilo4 {font-family: 'Times New Roman', Times, serif}
            -->
            </style>
            </head>

            <body>";

            cuerpo_correo = "Señor(a) " + this.NOMBRE_BENEFICIARIO + "<br /><br />";
            cuerpo_correo += "Se ha registrado el pago de la cuenta con n&uacute;mero de radicaci&oacute;n " + this.id_registro;

            //Este mensaje es una notificaci&oacute;n autom&aacute;tica, por lo tanto le solicitamos no responder a esta direcci&oacute;n de correo

            cuerpo_correo += @"<br /><br /><p class='Estilo4'>&nbsp;</p>
            <p class='Estilo4'><span lang='ES-CO' xml:lang='ES-CO'></span>.</p>
           
            </body>
            </html>
            ";

            Correo.enviarHTML(CORREO, "Registro de pago cuenta " + this.id_registro.ToString(), cuerpo_correo, ConfigurationSettings.AppSettings["CorreoRemitente"]);
        }
        catch { }

    }


    public static int insertarAdjuntoCuentaPorPagar(int id_reporte, string nombre)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = @"INSERT INTO ADJUNTOS_CUENTAS_POR_PAGAR (ID_REPORTE,ARCHIVO) VALUES(@ID_REPORTE,@ARCHIVO)";

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);

                cmd.Parameters.Add("@ID_REPORTE", SqlDbType.Int).Value = id_reporte;
                cmd.Parameters.Add("@ARCHIVO", SqlDbType.VarChar).Value = nombre;

                int resp = cmd.ExecuteNonQuery();

                conn.Close();

                return resp;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }


    }

    public static int insertarAdjuntoCuenta(int id_reporte, string nombre)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = @"INSERT INTO ADJUNTOS_CUENTAS (ID_REPORTE,ARCHIVO) VALUES(@ID_REPORTE,@ARCHIVO)";

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);

                cmd.Parameters.Add("@ID_REPORTE", SqlDbType.Int).Value = id_reporte;
                cmd.Parameters.Add("@ARCHIVO", SqlDbType.VarChar).Value = nombre;

                int resp = cmd.ExecuteNonQuery();

                conn.Close();

                return resp;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }


    }





    public int insertar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("INSERTAR_CUENTA_2", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ORDEN_PAGO", SqlDbType.VarChar).Value = ORDEN_PAGO;
                cmd.Parameters.Add("@ID_TIPO_DOCUMENTO", SqlDbType.Int).Value = ID_TIPO_DOCUMENTO;
                cmd.Parameters.Add("@NUM_DOCUMENTO", SqlDbType.VarChar).Value = NUM_DOCUMENTO;
                cmd.Parameters.Add("@NOMBRE_BENEFICIARIO", SqlDbType.VarChar).Value = NOMBRE_BENEFICIARIO;
                cmd.Parameters.Add("@NUM_PAGo", SqlDbType.VarChar).Value = NUM_PAGo;
                cmd.Parameters.Add("@VALOR_FACTURA", SqlDbType.Decimal).Value = VALOR_FACTURA;
                cmd.Parameters.Add("@FECHA_RADICADO", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@ID_ESTADO", SqlDbType.Int).Value = ID_ESTADO;
                cmd.Parameters.Add("@NUM_OBLIGACION", SqlDbType.VarChar).Value = NUM_OBLIGACION;
                //cmd.Parameters.Add("@FECHA_RECIBIDO_CONTABILIDAD", SqlDbType.DateTime).Value = FECHA_RECIBIDO_CONTABILIDAD;
                //cmd.Parameters.Add("@FECHA_RECIBIDO_TESORERIA", SqlDbType.DateTime).Value = FECHA_RECIBIDO_TESORERIA;
                //cmd.Parameters.Add("@FECHA_ORDEN_PAGO", SqlDbType.DateTime).Value = FECHA_ORDEN_PAGO;
                cmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = OBSERVACIONES;
                cmd.Parameters.Add("@CUENTA_POR_PAGAR", SqlDbType.VarChar).Value = CUENTA_POR_PAGAR;
                cmd.Parameters.Add("@ASIGNADO", SqlDbType.Int).Value = ASIGNADO;
                cmd.Parameters.Add("@ASIGNADO_A", SqlDbType.VarChar).Value = ASIGNADO_A;
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USUARIO;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = CORREO;
                cmd.Parameters.Add("@NUMERO_CONTRATO", SqlDbType.VarChar).Value = NUMERO_CONTRATO;
                cmd.Parameters.Add("@NUMERO_RP", SqlDbType.VarChar).Value = NUMERO_RP;
                cmd.Parameters.Add("@NUMERO_FACTURA", SqlDbType.VarChar).Value = NUMERO_FACTURA;
                cmd.Parameters.Add("@ID_TIPO_SOLICITUD", SqlDbType.Int).Value = ID_TIPO_SOLICITUD;


                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                int rows = cmd.ExecuteNonQuery();

                this.id_registro = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    public int obtenerIDDevolucion()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        int resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT ID_LOG FROM LOG_EVENTOS WHERE OPERACION = 'Devolucion' AND ID_CUENTA = " + this.id_registro;

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);

                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = (int)o;

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return 0;
        }
    }


    /*
 * 
 * (@ORDEN_PAGO varchar(50)
       ,@ID_TIPO_DOCUMENTO int
       ,@NUM_DOCUMENTO varchar(50)
       ,@NOMBRE_BENEFICIARIO varchar(350)
       ,@NUM_PAGo varchar(50)
       ,@VALOR_FACTURA float
       ,@FECHA_RADICADO datetime
       ,@ID_ESTADO smallint
       ,@NUM_OBLIGACION varchar(50)
       ,@FECHA_RECIBIDO_CONTABILIDAD datetime
       ,@FECHA_RECIBIDO_TESORERIA datetime
       ,@FECHA_ORDEN_PAGO datetime
       ,@OBSERVACIONES varchar(max)
       ,@ASIGNADO int
 * */

    public int Asignado
    {
        get
        {
            return ASIGNADO;
        }
        set
        {
            ASIGNADO = value;
        }

    }

    public string AsignadoA
    {
        get
        {
            return ASIGNADO_A;
        }
        set
        {
            ASIGNADO_A = value;
        }

    }

    public string Observaciones
    {
        get
        {
            return OBSERVACIONES;
        }
        set
        {
            OBSERVACIONES = value;
        }

    }

    public string CuentaPorPagar
    {
        get
        {
            return CUENTA_POR_PAGAR;
        }
        set
        {
            CUENTA_POR_PAGAR = value;
        }

    }

    public DateTime FechaOrdenPago
    {
        get
        {
            return FECHA_ORDEN_PAGO;
        }
        set
        {
            FECHA_ORDEN_PAGO = value;
        }

    }

    public DateTime FechaRecibidoTesoreria
    {
        get
        {
            return FECHA_RECIBIDO_TESORERIA;
        }
        set
        {
            FECHA_RECIBIDO_TESORERIA = value;
        }

    }
    public DateTime FechaRecibidoContabilidad
    {
        get
        {
            return FECHA_RECIBIDO_CONTABILIDAD;
        }
        set
        {
            FECHA_RECIBIDO_CONTABILIDAD = value;
        }

    }

    public DateTime ReporteFechaCreacion
    {
        get
        {
            return REPORTE_FECHA_CREACION;
        }
        set
        {
            REPORTE_FECHA_CREACION = value;
        }

    }

    public string ReporteDependencia
    {
        get
        {
            return REPORTE_DEPENDENCIA;
        }
        set
        {
            REPORTE_DEPENDENCIA = value;
        }

    }

    public string ReporteCDP
    {
        get
        {
            return REPORTE_CDP;
        }
        set
        {
            REPORTE_CDP = value;
        }

    }

    public string ReporteCompromiso
    {
        get
        {
            return REPORTE_COMPROMISO;
        }
        set
        {
            REPORTE_COMPROMISO = value;
        }

    }

    public string ReporteObligacion
    {
        get
        {
            return REPORTE_OBLIGACION;
        }
        set
        {
            REPORTE_OBLIGACION = value;
        }

    }

    public string ReporteEstado
    {
        get
        {
            return REPORTE_ESTADO;
        }
        set
        {
            REPORTE_ESTADO = value;
        }

    }

    public float ReporteValorBruto
    {
        get
        {
            return REPORTE_VALOR_BRUTO;
        }
        set
        {
            REPORTE_VALOR_BRUTO = value;
        }

    }

    public float ReporteValorNeto
    {
        get
        {
            return REPORTE_VALOR_NETO;
        }
        set
        {
            REPORTE_VALOR_NETO = value;
        }

    }

    public float ReporteValorDeduccion
    {
        get
        {
            return REPORTE_VALOR_DEDUCCION;
        }
        set
        {
            REPORTE_VALOR_DEDUCCION = value;
        }

    }

    public string ReporteOrdenPago
    {
        get
        {
            return REPORTE_ORDEN_PAGO;
        }
        set
        {
            REPORTE_ORDEN_PAGO = value;
        }

    }


    public string NumeroObligacion
    {
        get
        {
            return NUM_OBLIGACION;
        }
        set
        {
            NUM_OBLIGACION = value;
        }

    }

    public int IDEstado
    {
        get
        {
            return ID_ESTADO;
        }
        set
        {
            ID_ESTADO = value;
        }

    }

    public int IDRegistro
    {
        get
        {
            return id_registro;
        }
        set
        {
            id_registro = value;
        }

    }

    public DateTime FechaRadicado
    {
        get
        {
            return FECHA_RADICADO;
        }
        set
        {
            FECHA_RADICADO = value;
        }

    }



    public string OrdenPago
    {
        get
        {
            return ORDEN_PAGO;
        }
        set
        {
            ORDEN_PAGO = value;
        }

    }

    public int IDTipoDocumento
    {
        get
        {
            return ID_TIPO_DOCUMENTO;
        }
        set
        {
            ID_TIPO_DOCUMENTO = value;
        }

    }

    public int IDTipoSolicitud
    {
        get
        {
            return ID_TIPO_SOLICITUD;
        }
        set
        {
            ID_TIPO_SOLICITUD = value;
        }

    }

    public int IDCuentaPrincipal
    {
        get
        {
            return ID_CTA_PRINCIPAL;
        }
        set
        {
            ID_CTA_PRINCIPAL = value;
        }

    }

    public int Dividida
    {
        get
        {
            return DIVIDIDA;
        }
        set
        {
            DIVIDIDA = value;
        }

    }


    public string NumeroFactura
    {
        get
        {
            return NUMERO_FACTURA;
        }
        set
        {
            NUMERO_FACTURA = value;
        }

    }

    public string NumeroRP
    {
        get
        {
            return NUMERO_RP;
        }
        set
        {
            NUMERO_RP = value;
        }

    }

    public string NumeroContrato
    {
        get
        {
            return NUMERO_CONTRATO;
        }
        set
        {
            NUMERO_CONTRATO = value;
        }

    }


    public string NumeroDocumentoBeneficiaro
    {
        get
        {
            return NUM_DOCUMENTO;
        }
        set
        {
            NUM_DOCUMENTO = value;
        }

    }

    public string NumeroDocumentoContabilidad
    {
        get
        {
            return REPORTE_NUMERO_DOCUMENTO_CONTABILIDAD;
        }
        set
        {
            REPORTE_NUMERO_DOCUMENTO_CONTABILIDAD = value;
        }

    }

    public string NumeroDocumentoTesoreria
    {
        get
        {
            return REPORTE_NUMERO_DOCUMENTO_TESORERIA;
        }
        set
        {
            REPORTE_NUMERO_DOCUMENTO_TESORERIA = value;
        }

    }

    public string NombreBeneficiario
    {
        get
        {
            return NOMBRE_BENEFICIARIO;
        }
        set
        {
            NOMBRE_BENEFICIARIO = value;
        }

    }

    public string NumeroPago
    {
        get
        {
            return NUM_PAGo;
        }
        set
        {
            NUM_PAGo = value;
        }

    }

    public string Estado
    {
        get
        {
            return ESTADO;
        }
        set
        {
            ESTADO = value;
        }

    }

    public string Usuario
    {
        get
        {
            return USUARIO;
        }
        set
        {
            USUARIO = value;
        }

    }

    public string CorreoCuenta
    {
        get
        {
            return CORREO;
        }
        set
        {
            CORREO = value;
        }

    }


    public double ValorFactura
    {
        get
        {
            return VALOR_FACTURA;
        }
        set
        {
            VALOR_FACTURA = value;
        }

    }

    public bool Devuelta
    {
        get
        {
            return DEVUELTA;
        }
        set
        {
            DEVUELTA = value;
        }

    }

    public float ValorBruto
    {
        get
        {
            return VALOR_BRUTO;
        }
        set
        {
            VALOR_BRUTO = value;
        }

    }

    public float ValorNeto
    {
        get
        {
            return VALOR_NETO;
        }
        set
        {
            VALOR_NETO = value;
        }

    }

    public DateTime FechaRegistroContabilidad
    {
        get
        {
            return REPORTE_FECHA_REGISTRO_CONTABILIDAD;
        }
        set
        {
            REPORTE_FECHA_REGISTRO_CONTABILIDAD = value;
        }

    }

    public DateTime FechaCreacionContabilidad
    {
        get
        {
            return REPORTE_FECHA_CREACION_CONTABILIDAD;
        }
        set
        {
            REPORTE_FECHA_CREACION_CONTABILIDAD = value;
        }

    }

    public DateTime FechaRegistroTesoreria
    {
        get
        {
            return REPORTE_FECHA_REGISTRO_TESORERIA;
        }
        set
        {
            REPORTE_FECHA_REGISTRO_TESORERIA = value;
        }

    }

    public DateTime FechaPagoTesoreria
    {
        get
        {
            return REPORTE_FECHA_PAGO_TESORERIA;
        }
        set
        {
            REPORTE_FECHA_PAGO_TESORERIA = value;
        }

    }

}