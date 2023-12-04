using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Cuenta
/// </summary>
public class Contrato
{
    private int id_registro = 0;
    private string CEDULA = "";
    private string NOMBRE = "";
    private string CORREO = "";
    private string CELULAR = "";
    private string EXTENSION = "";
    private string NUMERO_CONTRATO = "";
    private string CDP = "";
    private DateTime FECHA_SUSCRIPCION;
    private string RP = "";
    private DateTime FECHA_INICIO;
    private DateTime FECHA_TERMINACION;
    private string PLAZO_EJECUCION = "";
    private double VALOR_INICIAL_HONORARIOS = 0;
    private double ADICION_HONORARIOS = 0;
    private double VALOR_INICIAL_DESPLAZAMIENTO = 0;
    private double ADICION_DESPLAZAMIENTO = 0;
    private string USUARIO_REGISTRO = "";
    private int NUMERO_PAGOS = 0;
    private string OBJETO = "";
    private string NUMERO_CUENTA = "";
    private string BANCO = "";
    private string TIPO_CUENTA = "";
    private string DEPENDENCIA = "";
    private int ID_CONTRATO = 0;


    public Contrato()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Contrato(int id_registro)
    {

        this.id_registro = id_registro;
        obtenerDatos();
    }

    public Contrato(string cedula)
    {

        this.CEDULA = cedula;

    }

    public void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM CONTRATOS WHERE ID_CONTRATO = " + this.id_registro.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA_SUSCRIPCION = (reader["FECHA_SUSCRIPCION"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_SUSCRIPCION"].ToString()) : DateTime.Now;
                    FECHA_INICIO = (reader["FECHA_INICIO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_INICIO"].ToString()) : DateTime.Now;
                    FECHA_TERMINACION = (reader["FECHA_TERMINACION"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_TERMINACION"].ToString()) : DateTime.Now;


                    CORREO = reader["CORREO"].ToString();
                    CEDULA = reader["CEDULA"].ToString();
                    NOMBRE = reader["NOMBRE"].ToString();
                    CELULAR = reader["CELULAR"].ToString();
                    EXTENSION = reader["EXTENSION"].ToString();
                    NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString();
                    CDP = reader["CDP"].ToString();
                    RP = reader["RP"].ToString();
                    PLAZO_EJECUCION = reader["PLAZO_EJECUCION"].ToString();
                    NUMERO_PAGOS = Utiles.validarNumeroToInt(reader["NUMERO_PAGOS"].ToString());
                    VALOR_INICIAL_HONORARIOS = Utiles.validarNumeroToDouble(reader["VALOR_INICIAL_HONORARIOS"].ToString());
                    ADICION_HONORARIOS = Utiles.validarNumeroToDouble(reader["ADICION_HONORARIOS"].ToString());
                    VALOR_INICIAL_DESPLAZAMIENTO = Utiles.validarNumeroToDouble(reader["VALOR_INICIAL_DESPLAZAMIENTO"].ToString());
                    ADICION_DESPLAZAMIENTO = Utiles.validarNumeroToDouble(reader["ADICION_DESPLAZAMIENTO"].ToString());
                    USUARIO_REGISTRO = reader["USUARIO_REGISTRO"].ToString();
                    OBJETO = reader["OBJETO"].ToString();
                    NUMERO_CUENTA = reader["NUMERO_CUENTA"].ToString();
                    BANCO = reader["BANCO"].ToString();
                    TIPO_CUENTA = reader["TIPO_CUENTA"].ToString();
                    DEPENDENCIA = reader["DEPENDENCIA"].ToString();
                    ID_CONTRATO = Convert.ToInt32(reader["ID_CONTRATO"].ToString());


                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }



    public DataTable consultarDatosBancarios()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("DBViaticos");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"CONSULTAR_DATOS_BANCARIOS";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = CEDULA;

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

    public void obtenerDatosPorUsuario()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM CONTRATOS WHERE ISNULL(NUMERO_PAGOS,0) <> ISNULL(PAGOS_REALIZADOS,0) AND USUARIO_REGISTRO = '" + this.UsuarioRegistro + "'";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA_SUSCRIPCION = (reader["FECHA_SUSCRIPCION"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_SUSCRIPCION"].ToString()) : DateTime.Now;
                    FECHA_INICIO = (reader["FECHA_INICIO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_INICIO"].ToString()) : DateTime.Now;
                    FECHA_TERMINACION = (reader["FECHA_TERMINACION"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_TERMINACION"].ToString()) : DateTime.Now;


                    CORREO = reader["CORREO"].ToString();
                    CEDULA = reader["CEDULA"].ToString();
                    NOMBRE = reader["NOMBRE"].ToString();
                    CELULAR = reader["CELULAR"].ToString();
                    EXTENSION = reader["EXTENSION"].ToString();
                    NUMERO_CONTRATO = reader["NUMERO_CONTRATO"].ToString();
                    CDP = reader["CDP"].ToString();
                    RP = reader["RP"].ToString();
                    PLAZO_EJECUCION = reader["PLAZO_EJECUCION"].ToString();
                    NUMERO_PAGOS = Utiles.validarNumeroToInt(reader["NUMERO_PAGOS"].ToString());
                    VALOR_INICIAL_HONORARIOS = Utiles.validarNumeroToDouble(reader["VALOR_INICIAL_HONORARIOS"].ToString());
                    ADICION_HONORARIOS = Utiles.validarNumeroToDouble(reader["ADICION_HONORARIOS"].ToString());
                    VALOR_INICIAL_DESPLAZAMIENTO = Utiles.validarNumeroToDouble(reader["VALOR_INICIAL_DESPLAZAMIENTO"].ToString());
                    ADICION_DESPLAZAMIENTO = Utiles.validarNumeroToDouble(reader["ADICION_DESPLAZAMIENTO"].ToString());
                    id_registro = Utiles.validarNumeroToInt(reader["ID_CONTRATO"].ToString());
                    OBJETO = reader["OBJETO"].ToString();
                    NUMERO_CUENTA = reader["NUMERO_CUENTA"].ToString();
                    BANCO = reader["BANCO"].ToString();
                    TIPO_CUENTA = reader["TIPO_CUENTA"].ToString();
                    DEPENDENCIA = reader["DEPENDENCIA"].ToString();
                    ID_CONTRATO = Convert.ToInt32(reader["ID_CONTRATO"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }


    public static object Deserialize(string content)
    {
        return new System.Web.Script.Serialization.JavaScriptSerializer().DeserializeObject(content);
    }



    public static DataTable consultarPorCedula(string cedula)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("DBViaticos");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SP_CONTRATOS_WS";



                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@identificacion", SqlDbType.VarChar).Value = cedula;
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









    public int insertar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = @"INSERTAR_CONTRATO";

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = CEDULA;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = CORREO;
                cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar).Value = CELULAR;
                cmd.Parameters.Add("@EXTENSION", SqlDbType.VarChar).Value = EXTENSION;
                cmd.Parameters.Add("@NUMERO_CONTRATO", SqlDbType.VarChar).Value = NUMERO_CONTRATO;
                cmd.Parameters.Add("@CDP", SqlDbType.VarChar).Value = CDP;
                cmd.Parameters.Add("@FECHA_SUSCRIPCION", SqlDbType.Date).Value = FECHA_SUSCRIPCION;
                cmd.Parameters.Add("@RP", SqlDbType.VarChar).Value = RP;
                cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = FECHA_INICIO;
                cmd.Parameters.Add("@FECHA_TERMINACION", SqlDbType.Date).Value = FECHA_TERMINACION;
                cmd.Parameters.Add("@PLAZO_EJECUCION", SqlDbType.VarChar).Value = PLAZO_EJECUCION;
                cmd.Parameters.Add("@VALOR_INICIAL_HONORARIOS", SqlDbType.Decimal).Value = VALOR_INICIAL_HONORARIOS;
                cmd.Parameters.Add("@ADICION_HONORARIOS", SqlDbType.Decimal).Value = ADICION_HONORARIOS;
                cmd.Parameters.Add("@VALOR_INICIAL_DESPLAZAMIENTO", SqlDbType.Decimal).Value = VALOR_INICIAL_DESPLAZAMIENTO;
                cmd.Parameters.Add("@ADICION_DESPLAZAMIENTO", SqlDbType.Decimal).Value = ADICION_DESPLAZAMIENTO;
                cmd.Parameters.Add("@USUARIO_REGISTRO", SqlDbType.VarChar).Value = USUARIO_REGISTRO;
                cmd.Parameters.Add("@NUMERO_PAGOS", SqlDbType.Int).Value = NUMERO_PAGOS;
                cmd.Parameters.Add("@NUMERO_CUENTA", SqlDbType.VarChar).Value = NUMERO_CUENTA;
                cmd.Parameters.Add("@BANCO", SqlDbType.VarChar).Value = BANCO;
                cmd.Parameters.Add("@TIPO_CUENTA", SqlDbType.VarChar).Value = TIPO_CUENTA;
                cmd.Parameters.Add("@DEPENDENCIA", SqlDbType.VarChar).Value = DEPENDENCIA;


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

    public int editar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = @"EDITAR_CONTRATO";

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CEDULA", SqlDbType.VarChar).Value = CEDULA;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = CORREO;
                cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar).Value = CELULAR;
                cmd.Parameters.Add("@EXTENSION", SqlDbType.VarChar).Value = EXTENSION;
                cmd.Parameters.Add("@NUMERO_CONTRATO", SqlDbType.VarChar).Value = NUMERO_CONTRATO;
                cmd.Parameters.Add("@CDP", SqlDbType.VarChar).Value = CDP;
                cmd.Parameters.Add("@FECHA_SUSCRIPCION", SqlDbType.Date).Value = FECHA_SUSCRIPCION;
                cmd.Parameters.Add("@RP", SqlDbType.VarChar).Value = RP;
                cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.Date).Value = FECHA_INICIO;
                cmd.Parameters.Add("@FECHA_TERMINACION", SqlDbType.Date).Value = FECHA_TERMINACION;
                cmd.Parameters.Add("@PLAZO_EJECUCION", SqlDbType.VarChar).Value = PLAZO_EJECUCION;
                cmd.Parameters.Add("@VALOR_INICIAL_HONORARIOS", SqlDbType.Decimal).Value = VALOR_INICIAL_HONORARIOS;
                cmd.Parameters.Add("@ADICION_HONORARIOS", SqlDbType.Decimal).Value = ADICION_HONORARIOS;
                cmd.Parameters.Add("@VALOR_INICIAL_DESPLAZAMIENTO", SqlDbType.Decimal).Value = VALOR_INICIAL_DESPLAZAMIENTO;
                cmd.Parameters.Add("@ADICION_DESPLAZAMIENTO", SqlDbType.Decimal).Value = ADICION_DESPLAZAMIENTO;

                cmd.Parameters.Add("@NUMERO_PAGOS", SqlDbType.Int).Value = NUMERO_PAGOS;
                cmd.Parameters.Add("@NUMERO_CUENTA", SqlDbType.VarChar).Value = NUMERO_CUENTA;
                cmd.Parameters.Add("@BANCO", SqlDbType.VarChar).Value = BANCO;
                cmd.Parameters.Add("@TIPO_CUENTA", SqlDbType.VarChar).Value = TIPO_CUENTA;
                cmd.Parameters.Add("@DEPENDENCIA", SqlDbType.VarChar).Value = DEPENDENCIA;
                cmd.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;
                cmd.Parameters.Add("@OBJETO", SqlDbType.VarChar).Value = OBJETO;


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


    public int obtenerPagosRealizados()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        int resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_PAGOS_CONTRATISTA";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;


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

    public double obtenerValorSaldo()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        double resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_VALOR_SALDO_CONTRATO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = Utiles.validarNumeroToDouble(o.ToString());

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return 0;
        }
    }

    public double obtenerValorUltimoPago()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        double resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_ULTIMO_VALOR_PAGO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = Utiles.validarNumeroToDouble(o.ToString());

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return 0;
        }
    }

    public double obtenerValorPagado()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        double resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_VALOR_PAGOS_CONTRATO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;


                object o = cmd2.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = Utiles.validarNumeroToDouble(o.ToString());

                conn.Close();
                return resp;
            }
        }
        catch (SqlException ex)
        {
            return 0;
        }
    }



    public int obtenerPagosContrato()
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        int resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "CONSULTAR_PAGOS_CONTRATO";

                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@ID_CONTRATO", SqlDbType.Int).Value = id_registro;

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








    public string Cedula
    {
        get
        {
            return CEDULA;
        }
        set
        {
            CEDULA = value;
        }

    }

    public string Nombre
    {
        get
        {
            return NOMBRE;
        }
        set
        {
            NOMBRE = value;
        }

    }

    public string Celular
    {
        get
        {
            return CELULAR;
        }
        set
        {
            CELULAR = value;
        }

    }

    public string Extension
    {
        get
        {
            return EXTENSION;
        }
        set
        {
            EXTENSION = value;
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


    public string Cdp
    {
        get
        {
            return CDP;
        }
        set
        {
            CDP = value;
        }

    }

    public DateTime FechaSuscripcion
    {
        get
        {
            return FECHA_SUSCRIPCION;
        }
        set
        {
            FECHA_SUSCRIPCION = value;
        }

    }

    public string Rp
    {
        get
        {
            return RP;
        }
        set
        {
            RP = value;
        }

    }

    public DateTime FechaInicio
    {
        get
        {
            return FECHA_INICIO;
        }
        set
        {
            FECHA_INICIO = value;
        }

    }
    public DateTime FechaTerminacion
    {
        get
        {
            return FECHA_TERMINACION;
        }
        set
        {
            FECHA_TERMINACION = value;
        }

    }

    public string PlazoEjecucion
    {
        get
        {
            return PLAZO_EJECUCION;
        }
        set
        {
            PLAZO_EJECUCION = value;
        }

    }

    public string Objeto
    {
        get
        {
            return OBJETO;
        }
        set
        {
            OBJETO = value;
        }

    }

    public double ValorInicialHonorarios
    {
        get
        {
            return VALOR_INICIAL_HONORARIOS;
        }
        set
        {
            VALOR_INICIAL_HONORARIOS = value;
        }

    }

    public double ValorTotallHonorarios
    {
        get
        {
            return VALOR_INICIAL_HONORARIOS + ADICION_HONORARIOS;
        }


    }

    public double AdicionHonorarios
    {
        get
        {
            return ADICION_HONORARIOS;
        }
        set
        {
            ADICION_HONORARIOS = value;
        }

    }

    public string Correo
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

    public double ValorInicialDesplazamiento
    {
        get
        {
            return VALOR_INICIAL_DESPLAZAMIENTO;
        }
        set
        {
            VALOR_INICIAL_DESPLAZAMIENTO = value;
        }

    }

    public double AdicionDesplazamiento
    {
        get
        {
            return ADICION_DESPLAZAMIENTO;
        }
        set
        {
            ADICION_DESPLAZAMIENTO = value;
        }

    }

    public string UsuarioRegistro
    {
        get
        {
            return USUARIO_REGISTRO;
        }
        set
        {
            USUARIO_REGISTRO = value;
        }

    }

    public int NumeroPagos
    {
        get
        {
            return NUMERO_PAGOS;
        }
        set
        {
            NUMERO_PAGOS = value;
        }

    }


    public int ID
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


    public string NumeroCuenta
    {
        get
        {
            return NUMERO_CUENTA;
        }
        set
        {
            NUMERO_CUENTA = value;
        }

    }

    public string Banco
    {
        get
        {
            return BANCO;
        }
        set
        {
            BANCO = value;
        }

    }

    public string TipoCuenta
    {
        get
        {
            return TIPO_CUENTA;
        }
        set
        {
            TIPO_CUENTA = value;
        }

    }

    public string Dependencia
    {
        get
        {
            return DEPENDENCIA;
        }
        set
        {
            DEPENDENCIA = value;
        }

    }


}