using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class Prepagada
{

    private int ID_REGISTRO = 0;
    private double VALOR_TOTAL = 0;
    private double VALOR_MES = 0;
    private int A_O = 0;
    private string DOCUMENTO = "";
    private DateTime FECHA_INGRESADO = DateTime.Now;
    private int MESES = 0;
    private int MES_VENCE = 0;
   

    public Prepagada(string documento, int a_o)
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

                string select = "SELECT TOP 1 * FROM PREPAGADA WHERE DOCUMENTO = '" + this.DOCUMENTO + "' AND A_O = " + this.A_O.ToString() + " AND MES_VENCE >= " + DateTime.Now.Month.ToString() + " ORDER BY ID_REGISTRO DESC";
                 
                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    FECHA_INGRESADO = (reader["FECHA_INGRESADO"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA_INGRESADO"].ToString()) : DateTime.Now;
                    ID_REGISTRO = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());
                    VALOR_TOTAL = Utiles.validarNumeroToDouble(reader["VALOR_TOTAL"].ToString());
                    VALOR_MES = Utiles.validarNumeroToDouble(reader["VALOR_MES"].ToString());
                    MESES = Utiles.validarNumeroToInt(reader["MESES"].ToString());
                    MES_VENCE = Utiles.validarNumeroToInt(reader["MES_VENCE"].ToString());

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

                string sql = @"INSERT INTO PREPAGADA
                                   ([VALOR_TOTAL]
                                   ,[VALOR_MES]
                                   ,[A_O]
                                    ,DOCUMENTO
                                   ,[FECHA_INGRESADO]
                                   ,MESES
                                   ,MES_VENCE
                                    )
                             VALUES
                                   (@VALOR_TOTAL
                                   ,@VALOR_MES
                                   ,@A_O
                                   ,@DOCUMENTO
                                   ,GETDATE()
                                   ,@MESES
                                   ,@MES_VENCE
                                    )";

                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VALOR_TOTAL", SqlDbType.Decimal).Value = VALOR_TOTAL;
                cmd.Parameters.Add("@VALOR_MES", SqlDbType.Decimal).Value = VALOR_MES;
                cmd.Parameters.Add("@A_O", SqlDbType.Int).Value = A_O;
                cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = DOCUMENTO;
                cmd.Parameters.Add("@MESES", SqlDbType.Int).Value = MESES;
                cmd.Parameters.Add("@MES_VENCE", SqlDbType.Int).Value = MES_VENCE;

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


    public int actualizar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE PREPAGADA
                                    SET [VALOR_TOTAL] = @VALOR_TOTAL
                                   ,[VALOR_MES] = @VALOR_MES
                                   ,[A_O] = @A_O
                                    ,DOCUMENTO = @DOCUMENTO
                                   ,[FECHA_INGRESADO] = GETDATE()
                                   ,MESES = @MESES
                                   ,MES_VENCE = @MES_VENCE
                                    WHERE ID_REGISTRO = @ID_REGISTRO
                                    ";

                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@VALOR_TOTAL", SqlDbType.Decimal).Value = VALOR_TOTAL;
                cmd.Parameters.Add("@VALOR_MES", SqlDbType.Decimal).Value = VALOR_MES;
                cmd.Parameters.Add("@A_O", SqlDbType.Int).Value = A_O;
                cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = DOCUMENTO;
                cmd.Parameters.Add("@MESES", SqlDbType.Int).Value = MESES;
                cmd.Parameters.Add("@MES_VENCE", SqlDbType.Int).Value = MES_VENCE;
                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = this.ID_REGISTRO;

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

    public int Meses
    {
        get
        {
            return MESES;
        }
        set
        {
            MESES = value;
        }

    }

    public int MesVence
    {
        get
        {
            return MES_VENCE;
        }
        set
        {
            MES_VENCE = value;
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