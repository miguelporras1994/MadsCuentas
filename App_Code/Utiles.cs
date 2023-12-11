using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

/// <summary>
/// Descripción breve de PetroIMS
/// </summary>
public class Utiles
{
    public Utiles()
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

    public static string nombreMes(int mes)
    {

        string nombre_mes = "";

        switch (mes)
        {
            case 1: nombre_mes = "Enero"; break;
            case 2: nombre_mes = "Febrero"; break;
            case 3: nombre_mes = "Marzo"; break;
            case 4: nombre_mes = "Abril"; break;
            case 5: nombre_mes = "Mayo"; break;
            case 6: nombre_mes = "Junio"; break;
            case 7: nombre_mes = "Julio"; break;
            case 8: nombre_mes = "Agosto"; break;
            case 9: nombre_mes = "Septiembre"; break;
            case 10: nombre_mes = "Octubre"; break;
            case 11: nombre_mes = "Noviembre"; break;
            case 12: nombre_mes = "Diciembre"; break;
        }

        return nombre_mes;

    }

    public static bool existeItem(string tabla, string campo, string valor)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT * FROM " + tabla + " WHERE " + campo + " = '" + valor + "'";

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



    public static bool existeItem(string tabla, string item)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT * FROM " + tabla + " WHERE nombre='" + item + "'";

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


    public static int insertarItem(string tabla, string item)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = "INSERT INTO " + tabla;
                insert += " VALUES(@item,1)";

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);

                cmd.Parameters.Add("@item", SqlDbType.VarChar);

                cmd.Parameters["@item"].Value = item;

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


    public static int actualizarItem(string tabla, string nombre_id, int id, string nombre_item, int id_estado)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string insert = "UPDATE " + tabla;
                insert += " SET nombre = @item,id_estado = @ID_ESTADO WHERE " + nombre_id + " = " + id.ToString();

                SqlCommand cmd = new SqlCommand(insert, (SqlConnection)conn);

                cmd.Parameters.Add("@item", SqlDbType.VarChar);
                cmd.Parameters.Add("@id_estado", SqlDbType.SmallInt);

                cmd.Parameters["@item"].Value = nombre_item;
                cmd.Parameters["@id_estado"].Value = id_estado;

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


    public static int validarNumeroToInt(string numero)
    {

        if (PetroIMS.IsNumeric(numero))
            return Convert.ToInt32(numero);
        else
            return 0;

    }

    public static XmlDocument listarItems(string tabla, bool todos)  //ERROR E1001  
    {
        XmlDocument documento = new XmlDocument();
        string xml = "<Root>";
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM  " + tabla;
                if (!todos)
                    select += " WHERE id_estado = 1";
                select += " ORDER BY nombre";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    xml += "<Item id='" + reader[0].ToString() + "' Nombre='" + PetroIMS.formatearCaracteresXML(reader[1].ToString()) + "' idEstado='" + reader[2].ToString() + "'/>";
                }
                xml += "</Root>";
                documento.LoadXml(xml);
                conn.Close();

            }
        }
        catch (SqlException ex)
        {
            xml += "<Error detalle='Error en la conexion' />";
            xml += "</Root>";
            documento.LoadXml(xml);
            return documento;
        }
        return documento;
    }



    public static float validarNumeroToFloat(string numero)
    {

        //string num_cor = Utiles.formatearCadenaANumero(numero);

        //546.840,22 si
        //546,840.22 no



        if (PetroIMS.IsNumeric(numero))
            return float.Parse(numero);
        else
            return 0;

    }

    public static string formatearCadenaANumero(string numero)
    {
        int posComa = numero.IndexOf(",");
        int posPunto = numero.IndexOf(".");
        string num_cor = numero;


        //System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        //System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        {

            if (posPunto == -1 && posComa > 0)
            {

                num_cor = numero.Replace(",", "");
            }
            else if (posComa == -1 && posPunto > 0)
            {
                num_cor = numero.Replace(".", "");
            }
            else if (posPunto > 0 && posComa > 0)
            {
                if (posComa < posPunto)
                {
                    num_cor = numero.Replace(",", "").Replace(".", ",");
                }
                else
                {
                    num_cor = numero;
                }
            }
        }
        else
        {
            if (posComa == -1 && posPunto > 0)
            {
                num_cor = numero.Replace(".", "");
            }
            else if (posPunto == -1 && posComa > 0)
            {
                num_cor = numero.Replace(",", "");
            }
            else if (posPunto > 0 && posComa > 0)
            {
                if (posComa > posPunto)
                {
                    num_cor = numero.Replace(".", "").Replace(",", ".");
                }
                else
                {
                    num_cor = numero;
                }
            }

        }

        return num_cor;

    }

    public static double validarNumeroToDouble(string numero)
    {
        //string num_cor = Utiles.formatearCadenaANumero(numero);

        if (PetroIMS.IsNumeric(numero))
            return double.Parse(numero);
        else
            return 0;

    }


    public static DateTime validarStringToDate(string fecha)
    {
        DateTime resp = DateTime.Now;

        try
        {
            resp = DateTime.ParseExact(fecha, ConfigurationSettings.AppSettings["FormatoFechaQueryParseExact"], null);
        }
        catch { return resp; }

        return resp;

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

        ConexionBD conBD = new ConexionBD("bd_con");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = @"SELECT * FROM permisos_reportes 
                                   WHERE id_usuario = " + id_usuario.ToString() + " AND reporte = '" + reporte + "'";


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

    public static string obtenerNombreItem(string tabla, string id_tabla, string valor)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
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

    public static string obtenerNombreItem(string tabla, string id_tabla, string campo, string valor)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT " + campo + " FROM " + tabla + " WHERE " + id_tabla + " = '" + valor + "'";

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


    public static string obtenerEstadoItem(string tabla, string id_tabla, string valor)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        string resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT id_estado FROM " + tabla + " WHERE " + id_tabla + " = '" + valor + "'";

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

        ConexionBD conBD = new ConexionBD("bd_con");
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

    public static string obtenerNombreItemUlises(string tabla, string columna, string id_tabla, string valor, bool es_entero)
    {

        ConexionBD conBD = new ConexionBD("DBViaticos");
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


public class NumLetra
{
    private String[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
    private String[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};
    private String[] CENTENAS = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};

    private Regex r;

    public String Convertir(String numero, bool mayusculas)
    {

        String literal = "";
        String parte_decimal;
        //si el numero utiliza (.) en lugar de (,) -> se reemplaza
        numero = numero.Replace(".", ",");

        //si el numero no tiene parte decimal, se le agrega ,00
        if (numero.IndexOf(",") == -1)
        {
            numero = numero + ",00";
        }
        //se valida formato de entrada -> 0,00 y 999 999 999,00
        r = new Regex(@"\d{1,9},\d{1,2}");
        MatchCollection mc = r.Matches(numero);
        if (mc.Count > 0)
        {
            //se divide el numero 0000000,00 -> entero y decimal
            String[] Num = numero.Split(',');

            //de da formato al numero decimal
            parte_decimal = Num[1] + " PESOS MCTE";
            //se convierte el numero a literal
            if (Int64.Parse(Num[0]) == 0)
            {//si el valor es cero                
                literal = "cero ";
            }
            else if (Int64.Parse(Num[0]) > 999999999)
            {//si es millon
                literal = getMilesMillones(Num[0]);
            }
            else if (Int64.Parse(Num[0]) > 999999)
            {//si es millon
                literal = getMillones(Num[0]);
            }
            else if (int.Parse(Num[0]) > 999)
            {//si es miles
                literal = getMiles(Num[0]);
            }
            else if (Int64.Parse(Num[0]) > 99)
            {//si es centena
                literal = getCentenas(Num[0]);
            }
            else if (Int64.Parse(Num[0]) > 9)
            {//si es decena
                literal = getDecenas(Num[0]);
            }
            else
            {//sino unidades -> 9
                literal = getUnidades(Num[0]);
            }
            //devuelve el resultado en mayusculas o minusculas
            if (mayusculas)
            {
                return (literal + parte_decimal).ToUpper();
            }
            else
            {
                return (literal + parte_decimal);
            }
        }
        else
        {//error, no se puede convertir
            return literal = null;
        }
    }


    /* funciones para convertir los numeros a literales */

    private String getUnidades(String numero)
    {   // 1 - 9            
        //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
        String num = numero.Substring(numero.Length - 1);
        return UNIDADES[int.Parse(num)];
    }

    private String getDecenas(String num)
    {// 99                        
        int n = int.Parse(num);
        if (n < 10)
        {//para casos como -> 01 - 09
            return getUnidades(num);
        }
        else if (n > 19)
        {//para 20...99
            String u = getUnidades(num);
            if (u.Equals(""))
            { //para 20,30,40,50,60,70,80,90
                return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
            }
            else
            {
                return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
            }
        }
        else
        {//numeros entre 11 y 19
            return DECENAS[n - 10];
        }
    }

    private String getCentenas(String num)
    {// 999 o 099
        if (int.Parse(num) > 99)
        {//es centena
            if (int.Parse(num) == 100)
            {//caso especial
                return " cien ";
            }
            else
            {
                return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
            }
        }
        else
        {//por Ej. 099 
            //se quita el 0 antes de convertir a decenas
            return getDecenas(int.Parse(num) + "");
        }
    }

    private String getMiles(String numero)
    {// 999 999
        //obtiene las centenas
        String c = numero.Substring(numero.Length - 3);
        //obtiene los miles
        String m = numero.Substring(0, numero.Length - 3);
        String n = "";
        //se comprueba que miles tenga valor entero
        if (int.Parse(m) > 0)
        {
            n = getCentenas(m);
            return n + "mil " + getCentenas(c);
        }
        else
        {
            return "" + getCentenas(c);
        }

    }

    private String getMillones(String numero)
    { //000 000 000        
        //se obtiene los miles
        String miles = numero.Substring(numero.Length - 6);
        //se obtiene los millones
        String millon = numero.Substring(0, numero.Length - 6);
        String n = "";
        if (millon.Length > 1)
        {
            n = getCentenas(millon) + "millones ";
        }
        else
        {
            n = getUnidades(millon) + "millon ";
        }
        return n + getMiles(miles);
    }

    private String getMilesMillones(String numero)
    { //000 000 000


        String miles_millones = numero.Substring(0, (numero.Length - 6));
        //se obtiene los miles
        String miles = numero.Substring((numero.Length - 6), 6);
        //se obtiene los millones
        String millon = numero.Substring(0, numero.Length - 9);
        String n = "";
        if (millon.Length > 1)
        {
            n = getCentenas(millon) + "mil millones ";
        }
        else
        {
            n = getUnidades(millon) + "mil millones ";
        }
        return getMiles(miles_millones) + " millones " + getMiles(miles);
    }

}
