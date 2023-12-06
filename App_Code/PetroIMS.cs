using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Descripción breve de PetroIMS
/// </summary>
public class PetroIMS
{
    public PetroIMS()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    public static System.Boolean IsNumeric(System.Object Expression)
    {
        if (Expression == null || Expression is DateTime || Expression == DBNull.Value)
            return false;

        if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
            return true;

        try
        {
            if (Expression is string)
                Double.Parse(Expression as string);
            else
                Double.Parse(Expression.ToString());
            return true;
        }
        catch { } // just dismiss errors but return false
        return false;
    }

    public static int validarNumeroToInt(string numero)
    {

        if (PetroIMS.IsNumeric(numero))
            return Convert.ToInt32(numero);
        else
            return 0;

    }


    public static float validarNumeroToFloat(string numero)
    {

        if (PetroIMS.IsNumeric(numero))
            return float.Parse(numero);
        else
            return 0;

    }


    public static string formatearCaracteresXML(string text)
    {


        char[] chars = text.ToCharArray();
        StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

        foreach (char c in chars)
        {
            int value = Convert.ToInt32(c);
            if (value == 38 || value == 60 || value == 61 || value == 62 || value == 92 || value == 34 || value == 225 || value == 218 || value == 233 || value == 237 || value == 241 || value == 218 || value == 243 || value == 250)
                result.AppendFormat("&#{0};", value);
            else
                result.Append(c);
        }

        return result.ToString();
    }

    public static bool permisoUsuarioReporte(int id_usuario, string reporte)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = @"SELECT * FROM permisos_reportes 
                                   WHERE id_usuario = @id_usuario AND reporte = @reporte";


                SqlCommand cmd2 = new SqlCommand(select2, (SqlConnection)conn);
                cmd2.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd2.Parameters.AddWithValue("@reporte", reporte);

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

    public static string obtenerNombreItem(string tabla, string id_tabla, string valor)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT nombre FROM " + tabla + " WHERE " + id_tabla + " = '" + valor + "'";

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




    public static string obtenerNombreItem(string tabla, string columna, string id_tabla, string valor, bool es_entero)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        string resp;
        string select2;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();
                if (!es_entero)
                    select2 = "SELECT " + columna + " FROM " + tabla + " WHERE " + id_tabla + " = '" + valor + "'";
                else
                    select2 = "SELECT " + columna + " FROM " + tabla + " WHERE " + id_tabla + " = " + valor;

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

}
