using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class Solicitud_2
{



    private string NUMERO_REGISTRO = "";
    private string CODIGOS_UNSPSC = "";
    private string DESCRIPCION = "";
    private DateTime FECHA_INICIO;
    private int DURACION_CONTRATO = 0;
    private string FUENTE_RECURSOS = "";
    private float VALOR_TOTAL_ESTIMADO = 0;
    private float VALOR_ESTIMADO_VIGENCIA_ACTUAL = 0;
    private int VIGENCIAS_FUTURAS = 0;
    private int ID_ESTADO_SOLICITUD_VIG_FUT = 0;
    private string CONTACTO_RESPONSABLE = "";
    private DateTime FECHA_REGISTRO;
    private int ID_TIPO_SOLICITUD = 0;
    private int ID_AREA = 0;
    private int ID_MODALIDAD_SELECCION = 0;
    private string NOMBRES_APELLIDOS = "";
    private string CARGO = "";
    private string CORREO = "";
    private string EXTENSION = "";
    private string TIPO_DURACION = "";
    private int id_registro = 0;
    private int MES = 0;
    private int A_O = 0;
    private int ID_FUENTE_RECURSOS = 0;
    private int ID_TIPO_DURACION = 0;
    private int ID_JUSTIFICACION = 0;
    private int ID_OPERACION = 0;
    private string JUSTIFICACION_DESCRIPCION = "";
    private string ACTIVIDAD_PRINCIPAL = "";
    private string ACTIVIDAD_DESAGREGADA = "";
    private int REQUIERE_CONTRATACION = 0;
    private int ID_ENLACE_JURIDICO = 0;
    private int ID_ENLACE_INVESTIGACION_MERCADO = 0;


    public Solicitud_2()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Solicitud_2(int id_registro)
    {

        this.id_registro = id_registro;
        obtenerDatos();

        //
        // TODO: Add constructor logic here
        //
    }



    public void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con_adq");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM SOLICITUD_2 WHERE ID_ADQUISICION = @id_registro";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@id_registro", this.id_registro);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NUMERO_REGISTRO = reader["NUMERO_REGISTRO"].ToString();
                    CODIGOS_UNSPSC = reader["CODIGOS_UNSPSC"].ToString();
                    DESCRIPCION = reader["DESCRIPCION"].ToString();
                    FECHA_INICIO = Convert.ToDateTime(reader["FECHA_INICIO"].ToString());
                    DURACION_CONTRATO = Utiles.validarNumeroToInt(reader["DURACION_CONTRATO"].ToString());
                    FUENTE_RECURSOS = reader["FUENTE_RECURSOS"].ToString();
                    VALOR_TOTAL_ESTIMADO = Utiles.validarNumeroToFloat(reader["VALOR_TOTAL_ESTIMADO"].ToString());
                    VALOR_ESTIMADO_VIGENCIA_ACTUAL = Utiles.validarNumeroToFloat(reader["VALOR_ESTIMADO_VIGENCIA_ACTUAL"].ToString());
                    VIGENCIAS_FUTURAS = Utiles.validarNumeroToInt(reader["VIGENCIAS_FUTURAS"].ToString());
                    ID_ESTADO_SOLICITUD_VIG_FUT = Utiles.validarNumeroToInt(reader["ID_ESTADO_SOLICITUD_VIG_FUT"].ToString());
                    CONTACTO_RESPONSABLE = reader["CONTACTO_RESPONSABLE"].ToString();
                    FECHA_REGISTRO = Utiles.validarStringToDate(reader["FECHA_REGISTRO"].ToString());
                    ID_TIPO_SOLICITUD = Utiles.validarNumeroToInt(reader["ID_TIPO_SOLICITUD"].ToString());
                    ID_AREA = Utiles.validarNumeroToInt(reader["ID_AREA"].ToString());
                    ID_MODALIDAD_SELECCION = Utiles.validarNumeroToInt(reader["ID_MODALIDAD_SELECCION"].ToString());
                    NOMBRES_APELLIDOS = reader["NOMBRES_APELLIDOS"].ToString();
                    CARGO = reader["CARGO"].ToString();
                    CORREO = reader["CORREO"].ToString();
                    EXTENSION = reader["EXTENSION"].ToString();
                    TIPO_DURACION = reader["TIPO_DURACION"].ToString();
                    id_registro = Utiles.validarNumeroToInt(reader["ID_ADQUISICION"].ToString());
                    MES = Utiles.validarNumeroToInt(reader["MES"].ToString());
                    A_O = Utiles.validarNumeroToInt(reader["ANO"].ToString());
                    ID_FUENTE_RECURSOS = Utiles.validarNumeroToInt(reader["ID_FUENTE_RECURSOS"].ToString());
                    ID_TIPO_DURACION = Utiles.validarNumeroToInt(reader["ID_TIPO_DURACION"].ToString());
                    ID_JUSTIFICACION = Utiles.validarNumeroToInt(reader["ID_JUSTIFICACION"].ToString());
                    ID_OPERACION = Utiles.validarNumeroToInt(reader["ID_OPERACION"].ToString());
                    JUSTIFICACION_DESCRIPCION = reader["JUSTIFICACION_DESCRIPCION"].ToString();
                    ACTIVIDAD_PRINCIPAL = reader["ACTIVIDAD_PRINCIPAL"].ToString();
                    ACTIVIDAD_DESAGREGADA = reader["ACTIVIDAD_DESAGREGADA"].ToString();
                    REQUIERE_CONTRATACION = Utiles.validarNumeroToInt(reader["REQUIERE_CONTRATACION"].ToString());
                    ID_ENLACE_JURIDICO = Utiles.validarNumeroToInt(reader["ID_ENLACE_JURIDICO"].ToString());
                    ID_ENLACE_INVESTIGACION_MERCADO = Utiles.validarNumeroToInt(reader["ID_ENLACE_INVESTIGACION_MERCADO"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }


    public void obtenerDatosPorNumRegistro()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con_adq");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM SOLICITUD_2 WHERE NUMERO_REGISTRO = @NUMERO_REGISTRO";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@NUMERO_REGISTRO", this.NUMERO_REGISTRO);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CODIGOS_UNSPSC = reader["CODIGOS_UNSPSC"].ToString();
                    DESCRIPCION = reader["DESCRIPCION"].ToString();
                    FECHA_INICIO = Convert.ToDateTime(reader["FECHA_INICIO"].ToString());
                    DURACION_CONTRATO = Utiles.validarNumeroToInt(reader["DURACION_CONTRATO"].ToString());
                    FUENTE_RECURSOS = reader["FUENTE_RECURSOS"].ToString();
                    VALOR_TOTAL_ESTIMADO = Utiles.validarNumeroToFloat(reader["VALOR_TOTAL_ESTIMADO"].ToString());
                    VALOR_ESTIMADO_VIGENCIA_ACTUAL = Utiles.validarNumeroToFloat(reader["VALOR_ESTIMADO_VIGENCIA_ACTUAL"].ToString());
                    VIGENCIAS_FUTURAS = Utiles.validarNumeroToInt(reader["VIGENCIAS_FUTURAS"].ToString());
                    ID_ESTADO_SOLICITUD_VIG_FUT = Utiles.validarNumeroToInt(reader["ID_ESTADO_SOLICITUD_VIG_FUT"].ToString());
                    CONTACTO_RESPONSABLE = reader["CONTACTO_RESPONSABLE"].ToString();
                    FECHA_REGISTRO = Utiles.validarStringToDate(reader["FECHA_REGISTRO"].ToString());
                    ID_TIPO_SOLICITUD = Utiles.validarNumeroToInt(reader["ID_TIPO_SOLICITUD"].ToString());
                    ID_AREA = Utiles.validarNumeroToInt(reader["ID_AREA"].ToString());
                    ID_MODALIDAD_SELECCION = Utiles.validarNumeroToInt(reader["ID_MODALIDAD_SELECCION"].ToString());
                    NOMBRES_APELLIDOS = reader["NOMBRES_APELLIDOS"].ToString();
                    CARGO = reader["CARGO"].ToString();
                    CORREO = reader["CORREO"].ToString();
                    EXTENSION = reader["EXTENSION"].ToString();
                    TIPO_DURACION = reader["TIPO_DURACION"].ToString();
                    id_registro = Utiles.validarNumeroToInt(reader["ID_ADQUISICION"].ToString());
                    MES = Utiles.validarNumeroToInt(reader["MES"].ToString());
                    A_O = Utiles.validarNumeroToInt(reader["ANO"].ToString());
                    ID_FUENTE_RECURSOS = Utiles.validarNumeroToInt(reader["ID_FUENTE_RECURSOS"].ToString());
                    ID_TIPO_DURACION = Utiles.validarNumeroToInt(reader["ID_TIPO_DURACION"].ToString());
                    ID_JUSTIFICACION = Utiles.validarNumeroToInt(reader["ID_JUSTIFICACION"].ToString());
                    ID_OPERACION = Utiles.validarNumeroToInt(reader["ID_OPERACION"].ToString());
                    JUSTIFICACION_DESCRIPCION = reader["JUSTIFICACION_DESCRIPCION"].ToString();
                    ACTIVIDAD_PRINCIPAL = reader["ACTIVIDAD_PRINCIPAL"].ToString();
                    ACTIVIDAD_DESAGREGADA = reader["ACTIVIDAD_DESAGREGADA"].ToString();
                    REQUIERE_CONTRATACION = Utiles.validarNumeroToInt(reader["REQUIERE_CONTRATACION"].ToString());
                    ID_ENLACE_JURIDICO = Utiles.validarNumeroToInt(reader["ID_ENLACE_JURIDICO"].ToString());
                    ID_ENLACE_INVESTIGACION_MERCADO = Utiles.validarNumeroToInt(reader["ID_ENLACE_INVESTIGACION_MERCADO"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }



    public int insertar()
    {
        ConexionBD conBD = new ConexionBD("bd_con_adq");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("INSERTAR_SOLICITUD_2", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NUMERO_REGISTRO", SqlDbType.VarChar).Value = NUMERO_REGISTRO;
                cmd.Parameters.Add("@CODIGOS_UNSPSC", SqlDbType.VarChar).Value = CODIGOS_UNSPSC;
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = DESCRIPCION;
                cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = FECHA_INICIO;
                cmd.Parameters.Add("@DURACION_CONTRATO", SqlDbType.Int).Value = DURACION_CONTRATO;
                cmd.Parameters.Add("@FUENTE_RECURSOS", SqlDbType.VarChar).Value = FUENTE_RECURSOS;
                cmd.Parameters.Add("@VALOR_TOTAL_ESTIMADO", SqlDbType.Decimal).Value = VALOR_TOTAL_ESTIMADO;
                cmd.Parameters.Add("@VALOR_ESTIMADO_VIGENCIA_ACTUAL", SqlDbType.Decimal).Value = VALOR_ESTIMADO_VIGENCIA_ACTUAL;
                cmd.Parameters.Add("@VIGENCIAS_FUTURAS", SqlDbType.Int).Value = VIGENCIAS_FUTURAS;
                cmd.Parameters.Add("@ID_ESTADO_SOLICITUD_VIG_FUT", SqlDbType.Int).Value = (ID_ESTADO_SOLICITUD_VIG_FUT == 0) ? 1 : ID_ESTADO_SOLICITUD_VIG_FUT;
                cmd.Parameters.Add("@CONTACTO_RESPONSABLE", SqlDbType.VarChar).Value = CONTACTO_RESPONSABLE;
                cmd.Parameters.Add("@FECHA_REGISTRO", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@ID_TIPO_SOLICITUD", SqlDbType.SmallInt).Value = ID_TIPO_SOLICITUD;
                cmd.Parameters.Add("@ID_AREA", SqlDbType.Int).Value = ID_AREA;
                cmd.Parameters.Add("@ID_MODALIDAD_SELECCION", SqlDbType.Int).Value = ID_MODALIDAD_SELECCION;
                cmd.Parameters.Add("@NOMBRES_APELLIDOS", SqlDbType.VarChar).Value = NOMBRES_APELLIDOS;
                cmd.Parameters.Add("@CARGO", SqlDbType.VarChar).Value = CARGO;
                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = CORREO;
                cmd.Parameters.Add("@EXTENSION", SqlDbType.VarChar).Value = EXTENSION;
                cmd.Parameters.Add("@TIPO_DURACION", SqlDbType.VarChar).Value = TIPO_DURACION;
                cmd.Parameters.Add("@MES", SqlDbType.Int).Value = MES;
                cmd.Parameters.Add("@A_O", SqlDbType.Int).Value = A_O;
                cmd.Parameters.Add("@ID_FUENTE_RECURSOS", SqlDbType.Int).Value = ID_FUENTE_RECURSOS;
                cmd.Parameters.Add("@ID_TIPO_DURACION", SqlDbType.Int).Value = ID_TIPO_DURACION;
                cmd.Parameters.Add("@ID_JUSTIFICACION", SqlDbType.Int).Value = ID_JUSTIFICACION;
                cmd.Parameters.Add("@ID_OPERACION", SqlDbType.Int).Value = ID_OPERACION;
                cmd.Parameters.Add("@JUSTIFICACION_DESCRIPCION", SqlDbType.VarChar).Value = JUSTIFICACION_DESCRIPCION;

                cmd.Parameters.Add("@ACTIVIDAD_PRINCIPAL", SqlDbType.VarChar).Value = ACTIVIDAD_PRINCIPAL;
                cmd.Parameters.Add("@ACTIVIDAD_DESAGREGADA", SqlDbType.VarChar).Value = ACTIVIDAD_DESAGREGADA;
                cmd.Parameters.Add("@REQUIERE_CONTRATACION", SqlDbType.SmallInt).Value = REQUIERE_CONTRATACION;
                cmd.Parameters.Add("@ID_ENLACE_JURIDICO", SqlDbType.Int).Value = ID_ENLACE_JURIDICO;
                cmd.Parameters.Add("@ID_ENLACE_INVESTIGACION_MERCADO", SqlDbType.Int).Value = ID_ENLACE_INVESTIGACION_MERCADO;

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


    public int aprobada(string observaciones)
    {
        ConexionBD conBD = new ConexionBD("bd_con_adq");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = "UPDATE SOLICITUD_2 SET ESTADO = 2, OBSERVACIONES_APROBACION = @OBSERVACIONES WHERE ID_ADQUISICION = @ID_ADQUISICION";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);


                cmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = observaciones;

                cmd.Parameters.Add("@ID_ADQUISICION", SqlDbType.Int).Value = this.id_registro;

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





    public int rechazada(string observaciones)
    {
        ConexionBD conBD = new ConexionBD("bd_con_adq");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = "UPDATE SOLICITUD_2 SET ESTADO = 3, OBSERVACIONES_APROBACION = @OBSERVACIONES WHERE ID_ADQUISICION = @ID_ADQUISICION";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);


                cmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = observaciones;

                cmd.Parameters.Add("@ID_ADQUISICION", SqlDbType.Int).Value = this.id_registro;

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



    public string NumeroRegistro
    {
        get
        {
            return NUMERO_REGISTRO;
        }
        set
        {
            NUMERO_REGISTRO = value;
        }

    }

    public string CodigosUNSPSC
    {
        get
        {
            return CODIGOS_UNSPSC;
        }
        set
        {
            CODIGOS_UNSPSC = value;
        }

    }

    public string Descripcion
    {
        get
        {
            return DESCRIPCION;
        }
        set
        {
            DESCRIPCION = value;
        }

    }

    public int DuracionContrato
    {
        get
        {
            return DURACION_CONTRATO;
        }
        set
        {
            DURACION_CONTRATO = value;
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



    public string TipoDuracion
    {
        get
        {
            return TIPO_DURACION;
        }
        set
        {
            TIPO_DURACION = value;
        }

    }

    public string FuenteRecursos
    {
        get
        {
            return FUENTE_RECURSOS;
        }
        set
        {
            FUENTE_RECURSOS = value;
        }

    }

    public float ValorEstimado
    {
        get
        {
            return VALOR_TOTAL_ESTIMADO;
        }
        set
        {
            VALOR_TOTAL_ESTIMADO = value;
        }

    }

    public float ValorEstimadoVigenciaActual
    {
        get
        {
            return VALOR_ESTIMADO_VIGENCIA_ACTUAL;
        }
        set
        {
            VALOR_ESTIMADO_VIGENCIA_ACTUAL = value;
        }

    }


    public int VigenciasFuturas
    {
        get
        {
            return VIGENCIAS_FUTURAS;
        }
        set
        {
            VIGENCIAS_FUTURAS = value;
        }

    }

    public int IDEstadoSolicitud
    {
        get
        {
            return ID_ESTADO_SOLICITUD_VIG_FUT;
        }
        set
        {
            ID_ESTADO_SOLICITUD_VIG_FUT = value;
        }

    }

    public string ContactoResponsable
    {
        get
        {
            return CONTACTO_RESPONSABLE;
        }
        set
        {
            CONTACTO_RESPONSABLE = value;
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

    public int IDArea
    {
        get
        {
            return ID_AREA;
        }
        set
        {
            ID_AREA = value;
        }

    }


    public int IDModalidadSeleccion
    {
        get
        {
            return ID_MODALIDAD_SELECCION;
        }
        set
        {
            ID_MODALIDAD_SELECCION = value;
        }

    }

    public string NombresApellidos
    {
        get
        {
            return NOMBRES_APELLIDOS;
        }
        set
        {
            NOMBRES_APELLIDOS = value;
        }

    }

    public string Cargo
    {
        get
        {
            return CARGO;
        }
        set
        {
            CARGO = value;
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

    public int Mes
    {
        get
        {
            return MES;
        }
        set
        {
            MES = value;
        }

    }

    public int A_o
    {
        get
        {
            return A_O;
        }
        set
        {
            A_O = value;
        }

    }

    public int IDFuenteRecursos
    {
        get
        {
            return ID_FUENTE_RECURSOS;
        }
        set
        {
            ID_FUENTE_RECURSOS = value;
        }

    }

    public int IDTipoDuracion
    {
        get
        {
            return ID_TIPO_DURACION;
        }
        set
        {
            ID_TIPO_DURACION = value;
        }

    }
    public int IDJustificacion
    {
        get
        {
            return ID_JUSTIFICACION;
        }
        set
        {
            ID_JUSTIFICACION = value;
        }

    }
    public int IDOperacion
    {
        get
        {
            return ID_OPERACION;
        }
        set
        {
            ID_OPERACION = value;
        }

    }
    public string JustificacionDescripcion
    {
        get
        {
            return JUSTIFICACION_DESCRIPCION;
        }
        set
        {
            JUSTIFICACION_DESCRIPCION = value;
        }

    }

    public DateTime FechaRegistro
    {
        get
        {
            return FECHA_REGISTRO;
        }


    }

    public string ActividadPrincipal
    {
        get
        {
            return ACTIVIDAD_PRINCIPAL;
        }
        set
        {
            ACTIVIDAD_PRINCIPAL = value;
        }

    }

    public string ActividadDesagregada
    {

        get
        {
            return ACTIVIDAD_DESAGREGADA;
        }
        set
        {
            ACTIVIDAD_DESAGREGADA = value;
        }

    }

    public int RequiereContratacion
    {
        get
        {
            return REQUIERE_CONTRATACION;
        }
        set
        {
            REQUIERE_CONTRATACION = value;
        }

    }

    public int IDEnlaceJuridico
    {
        get
        {
            return ID_ENLACE_JURIDICO;
        }
        set
        {
            ID_ENLACE_JURIDICO = value;
        }

    }

    public int IDEnlaceInvestigacionMercado
    {
        get
        {
            return ID_ENLACE_INVESTIGACION_MERCADO;
        }
        set
        {
            ID_ENLACE_INVESTIGACION_MERCADO = value;
        }

    }

}