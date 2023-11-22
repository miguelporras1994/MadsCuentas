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
public class LOG
{
    private int id_registro = 0;
    private int ID_CUENTA = 0;
    private string OPERACION = "";
    private string FUENTE = "";
    private string DESCRIPCION = "";
    private DateTime FECHA = DateTime.Now; 
    private string USUARIO = "";
   




    public LOG(int id_registro)
    {
       this.id_registro = id_registro;
        obtenerDatos();
    }

    public LOG()
    {
     
    }
    
    public void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM LOG_EVENTOS WHERE ID_LOG = " + this.id_registro.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA = (reader["FECHA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA"].ToString()) : DateTime.Now;
                    OPERACION = reader["OPERACION"].ToString();
                    ID_CUENTA = Utiles.validarNumeroToInt(reader["ID_CUENTA"].ToString());
                    FUENTE = reader["FUENTE"].ToString();
                    DESCRIPCION = reader["DESCRIPCION"].ToString();
                    USUARIO = reader["USUARIO"].ToString();
                    

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }


    public void consultarLOG_Liquidacion()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        //DataTable dtregistros = new DataTable();
        string usuario = "";

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT *
                                FROM LOG_EVENTOS
                                WHERE ID_CUENTA = " + ID_CUENTA.ToString() + " AND OPERACION = 'Liquidacion cuenta' ORDER BY FECHA ASC";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    FECHA = (reader["FECHA"] != DBNull.Value) ? Convert.ToDateTime(reader["FECHA"].ToString()) : DateTime.Now;
                    OPERACION = reader["OPERACION"].ToString();
                    ID_CUENTA = Utiles.validarNumeroToInt(reader["ID_CUENTA"].ToString());
                    FUENTE = reader["FUENTE"].ToString();
                    DESCRIPCION = reader["DESCRIPCION"].ToString();
                    USUARIO = reader["USUARIO"].ToString();


                }

                conn.Close();
                

            }
        }
        catch (SqlException ex)
        {


        }

        
    }

    public DataTable consultarLOG_Cuenta()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {


                string select = @"SELECT *
                                FROM LOG_EVENTOS
                                WHERE ID_CUENTA = " + ID_CUENTA.ToString() + " ORDER BY FECHA ASC";

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


    
   

   
    public string Operacion
    {
        get
        {
            return OPERACION;
        }
        set
        {
            OPERACION = value;
        }

    }

    public string Fuente
    {
        get
        {
            return FUENTE;
        }
        set
        {
            FUENTE = value;
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

    public int IDCuenta
    {
        get
        {
            return ID_CUENTA;
        }
        set
        {
            ID_CUENTA = value;
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

    

}