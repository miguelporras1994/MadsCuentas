using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class InteresVivienda
{

    private int ID_REGISTRO = 0;
    private double VALOR_TOTAL = 0;
    private double VALOR_MES = 0;
    private int A_O = 0;
    private string DOCUMENTO = "";
    private DateTime FECHA_INGRESADO = DateTime.Now;

    public InteresVivienda(string documento, int a_o)
    {
        this.DOCUMENTO = documento;
        this.A_O = a_o;
        obtenerDatos();

    }


    public void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM INTERESES_VIVIENDA WHERE DOCUMENTO = '" + this.DOCUMENTO + "' AND A_O = " + this.A_O.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    FECHA_INGRESADO = (reader["FECHA_INGRESADO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_INGRESADO"].ToString()) : DateTime.Now;
                    ID_REGISTRO = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());
                    VALOR_TOTAL = Utiles.validarNumeroToDouble(reader["VALOR_TOTAL"].ToString());
                    VALOR_MES = Utiles.validarNumeroToDouble(reader["VALOR_MES"].ToString());

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
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO INTERESES_VIVIENDA
                                   ([VALOR_TOTAL]
                                   ,[VALOR_MES]
                                   ,[A_O]
                                    ,DOCUMENTO
                                   ,[FECHA_INGRESADO])
                             VALUES
                                   (@VALOR_TOTAL
                                   ,@VALOR_MES
                                   ,@A_O
                                   ,@DOCUMENTO
                                   ,GETDATE())";

                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VALOR_TOTAL", SqlDbType.Decimal).Value = VALOR_TOTAL;
                cmd.Parameters.Add("@VALOR_MES", SqlDbType.Decimal).Value = VALOR_MES;
                cmd.Parameters.Add("@A_O", SqlDbType.Int).Value = A_O;
                cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = DOCUMENTO;

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





    public int IDRegistro
    {
        get
        {
            return ID_REGISTRO;
        }
        set
        {
            ID_REGISTRO = value;
        }

    }

    public string Documento
    {
        get
        {
            return DOCUMENTO;
        }
        set
        {
            DOCUMENTO = value;
        }

    }

    public double ValorTotal
    {
        get
        {
            return VALOR_TOTAL;
        }
        set
        {
            VALOR_TOTAL = value;
        }

    }

    public double ValorMes
    {
        get
        {
            return VALOR_MES;
        }
        set
        {
            VALOR_MES = value;
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

    public DateTime FechaIngreso
    {
        get
        {
            return FECHA_INGRESADO;
        }
        set
        {
            FECHA_INGRESADO = value;
        }

    }



}