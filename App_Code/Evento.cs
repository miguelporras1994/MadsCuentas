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
public class Evento
{
    private int ID_EVENTO = 0;
    private int ID_REGISTRO = 0;
    private string USUARIO = "";
    private string EVENTO = "";
    private DateTime FECHA = DateTime.Now;
    

    public Evento()
    {

    }

    public Evento(int id_evento)
    {

        this.ID_EVENTO = id_evento;
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

                string select = "SELECT * FROM LOG_EVENTOS WHERE ID_EVENTO = " + this.ID_EVENTO.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    FECHA = (reader["FECHA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA"].ToString()) : DateTime.Now;
                    ID_REGISTRO = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());
                    USUARIO  = reader["USUARIO"].ToString();
                    EVENTO = reader["EVENTO"].ToString();

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }

    public DataTable consultarEntrenamientosActividad()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = "SELECT * FROM LOG_EVENTOS WHERE ID_EVENTO = " + this.ID_EVENTO;

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


    

    

    public int insertar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO [LOG_EVENTOS]
                                   ([ID_REGISTRO]
                                   ,[USUARIO]
                                   ,[EVENTO]
                                   ,[FECHA])
                             VALUES
                                   (@ID_REGISTRO
                                   ,@USUARIO
                                   ,@EVENTO
                                   ,@FECHA)";

                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.VarChar).Value = ID_REGISTRO ;
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar ).Value = USUARIO;
                cmd.Parameters.Add("@EVENTO", SqlDbType.VarChar).Value = EVENTO;
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA;

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

    

    public int IDEvento
    {
        get
        {
            return ID_EVENTO;
        }
        set
        {
            ID_EVENTO = value;
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

    public string DescripcionEvento
    {
        get
        {
            return EVENTO;
        }
        set
        {
            EVENTO = value;
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

    public DateTime Fecha
    {
        get
        {
            return FECHA;
        }
        set
        {
            FECHA = value;
        }

    }

    

}