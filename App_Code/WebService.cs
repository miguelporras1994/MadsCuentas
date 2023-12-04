using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    // Member variables
    private static XmlDocument _document;
    private static object _lock = new object();

    public WebService()
    {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    public static string[] Hierarchy
    {
        get
        {

            return new string[] { "Categoria", "Subcategoria" };
        }
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCategoria(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_categoria, nombre FROM TO_categoria",
              (SqlConnection)conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["nombre"].ToString(),
                      dr["id_categoria"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetSubCategoria(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int IDFamilia;

        if (!kv.ContainsKey("Categoria") || !Int32.TryParse(kv["Categoria"], out IDFamilia))
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_detalle, nombre FROM TO_categoria_detalle WHERE id_categoria = @IDFamilia",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@IDFamilia", IDFamilia);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["nombre"].ToString(),
                      dr["id_detalle"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetReporte(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_reporte, nombre_reporte FROM arp_actividad_reporte ORDER BY fecha DESC",
              (SqlConnection)conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["nombre_reporte"].ToString(),
                      dr["id_reporte"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }



    [WebMethod]
    public CascadingDropDownNameValue[] GetActividad(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int idReporte;

        if (!kv.ContainsKey("Reporte") || !Int32.TryParse(kv["Reporte"], out idReporte))
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_actividad, descripcion FROM arp_actividad WHERE id_reporte = @nombre_reporte AND id_calificacion IS NULL",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@nombre_reporte", idReporte);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["descripcion"].ToString(),
                      dr["id_actividad"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetEstado(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_estado, descripcion FROM arp_actividad_estado WHERE id_estado != '1'",
              (SqlConnection)conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["descripcion"].ToString(),
                      dr["id_estado"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }
    ///


    [WebMethod]
    public CascadingDropDownNameValue[] GetCalificacion(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int idEstado;

        if (!kv.ContainsKey("Estado") || !Int32.TryParse(kv["Estado"], out idEstado))
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_calificacion, descripcion FROM arp_actividad_calificacion WHERE id_estado_actividad = @estado",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@estado", idEstado);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["descripcion"].ToString(),
                      dr["id_calificacion"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetActividadContrato(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int idReporte;

        if (!kv.ContainsKey("Reporte") || !Int32.TryParse(kv["Reporte"], out idReporte))
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT DISTINCT (id_contrato) FROM arp_actividad WHERE id_reporte = @nombre_reporte",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@nombre_reporte", idReporte);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    String nombre_contrato = obtenerDatosContrato(Convert.ToInt32(dr["id_contrato"]));
                    l.Add(new CascadingDropDownNameValue(
                      nombre_contrato,
                      dr["id_contrato"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }


    [WebMethod]
    public CascadingDropDownNameValue[] GetReporteResiduos(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_reporte, nombre_reporte FROM residuos_reporte ORDER BY fecha DESC",
              (SqlConnection)conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["nombre_reporte"].ToString(),
                      dr["id_reporte"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }


    [WebMethod]
    public CascadingDropDownNameValue[] GetResiduosContrato(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int idReporte;

        if (!kv.ContainsKey("Reporte") || !Int32.TryParse(kv["Reporte"], out idReporte))
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT DISTINCT (id_contrato) FROM residuos_detalle_reporte WHERE id_reporte = @nombre_reporte",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@nombre_reporte", idReporte);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    String nombre_contrato = obtenerDatosContrato(Convert.ToInt32(dr["id_contrato"]));
                    l.Add(new CascadingDropDownNameValue(
                      nombre_contrato,
                      dr["id_contrato"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }

    public String obtenerDatosContrato(int id_contrato)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        String nombre_contrato = "";

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM contrato WHERE id_contrato = " + id_contrato;

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nombre_contrato = reader["nombre"].ToString();
                }
                conn.Close();
            }
        }
        catch (SqlException ex)
        {

        }
        return nombre_contrato;
    }



    [WebMethod]
    public CascadingDropDownNameValue[] GetTipoExamen(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_tipo, descripcion FROM examen_medico_tipo_examen ORDER BY id_tipo DESC",
              (SqlConnection)conn);
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["descripcion"].ToString(),
                      dr["id_tipo"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue("", "0"));
            return l.ToArray();
        }

    }



    [WebMethod]
    public CascadingDropDownNameValue[] GetExamenes(string knownCategoryValues, string category)
    {
        ConexionBD conBD = new ConexionBD("bd_con");
        List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        int idTipoExamen;

        if (!kv.ContainsKey("TipoExamen") || !Int32.TryParse(kv["TipoExamen"], out idTipoExamen))
        {
            l.Add(new CascadingDropDownNameValue("Err categoria", "0"));
            return l.ToArray();

        };

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
              "SELECT id_examen, nombre FROM examen_medico_examenes WHERE id_tipo_examen = @tipo_examen",
              (SqlConnection)conn);
                comm.Parameters.AddWithValue("@tipo_examen", idTipoExamen);
                SqlDataReader dr = comm.ExecuteReader();



                while (dr.Read())
                {
                    l.Add(new CascadingDropDownNameValue(
                      dr["nombre"].ToString(),
                      dr["id_examen"].ToString()));
                }
                conn.Close();
                return l.ToArray();
            }
        }
        catch (Exception ex)
        {
            l.Add(new CascadingDropDownNameValue(ex.Message, "0"));
            return l.ToArray();
        }

    }


}

