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
/// Summary description for Liquidacion
/// </summary>
public class Liquidacion
{
           private int ID_RADICACION = 0;
           private int ID_REGISTRO = 0;
           private double VALOR_TOTAL  = 0;
           private double IBC  = 0;
           private double SALUD  = 0;
           private double PENSION  = 0;
           private double ARL  = 0;
           private double AFC  = 0;
           private double INT_VIVIENDA  = 0;
           private double PREPAGADA  = 0;
           private double DEPENDIENTES  = 0;
           private double RENTA_EXENTA  = 0;
           private double BASE_GRAVABLE_RETEFUENTE_383  = 0;
           private double BASE_GRAVABLE_RETEFUENTE_384 = 0;
           private double RETE_FUENTE_UVT_383  = 0;
           private double RETE_FUENTE_UVT_384 = 0;
           private double VALOR_RF_ART_383  = 0;
           private double VALOR_RF_ART_384  = 0;
           private double ICA  = 0;
           private double RETE_IVA  = 0;
           private double TOTAL_PAGAR_383  = 0;
           private double TOTAL_PAGAR_384  = 0;
           private double FACTOR_RETE_IVA = 0;
           private double FACTOR_RETE_ICA = 0;
           private double FACTOR_RETE_FUENTE = 0;
           private string NOTA = "";
           private double BASE_RETE_ICA_383 = 0;
           private double BASE_RETE_ICA_384 = 0;
            private string METODO = "";
            private string DESCRIPCION_OTROS_DESCUENTOS = "";
            private double VALOR_OTROS_DESCUENTOS = 0;
            private double BASE_RETE_IVA = 0;



    public Liquidacion()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Liquidacion(int id_registro)
    {

        this.ID_RADICACION = id_registro;
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

                string select = "SELECT * FROM LIQUIDACIONES WHERE ID_RADICACION = " + this.ID_RADICACION.ToString();

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    VALOR_TOTAL = Utiles.validarNumeroToDouble(reader["VALOR_TOTAL"].ToString());
                    IBC = Utiles.validarNumeroToDouble(reader["IBC"].ToString());
                    SALUD = Utiles.validarNumeroToDouble(reader["SALUD"].ToString());
                    PENSION = Utiles.validarNumeroToDouble(reader["PENSION"].ToString());
                    ARL = Utiles.validarNumeroToDouble(reader["ARL"].ToString());
                    AFC = Utiles.validarNumeroToDouble(reader["AFC"].ToString());
                    INT_VIVIENDA = Utiles.validarNumeroToDouble(reader["INT_VIVIENDA"].ToString());
                    PREPAGADA = Utiles.validarNumeroToDouble(reader["PREPAGADA"].ToString());
                    DEPENDIENTES = Utiles.validarNumeroToDouble(reader["DEPENDIENTES"].ToString());
                    RENTA_EXENTA = Utiles.validarNumeroToDouble(reader["RENTA_EXENTA"].ToString());
                    BASE_GRAVABLE_RETEFUENTE_383 = Utiles.validarNumeroToDouble(reader["BASE_GRAVABLE_RETEFUENTE_383"].ToString());
                    BASE_GRAVABLE_RETEFUENTE_384 = Utiles.validarNumeroToDouble(reader["BASE_GRAVABLE_RETEFUENTE_384"].ToString());
                    RETE_FUENTE_UVT_383 = Utiles.validarNumeroToDouble(reader["RETE_FUENTE_UVT_383"].ToString());
                    RETE_FUENTE_UVT_384 = Utiles.validarNumeroToDouble(reader["RETE_FUENTE_UVT_384"].ToString());
                    VALOR_RF_ART_383 = Utiles.validarNumeroToDouble(reader["VALOR_RF_ART_383"].ToString());
                    VALOR_RF_ART_384 = Utiles.validarNumeroToDouble(reader["VALOR_RF_ART_384"].ToString());
                    ICA = Utiles.validarNumeroToDouble(reader["ICA"].ToString());
                    RETE_IVA = Utiles.validarNumeroToDouble(reader["RETE_IVA"].ToString());
                    TOTAL_PAGAR_383 = Utiles.validarNumeroToDouble(reader["TOTAL_PAGAR_383"].ToString());
                    TOTAL_PAGAR_384 = Utiles.validarNumeroToDouble(reader["TOTAL_PAGAR_384"].ToString());
                    ID_REGISTRO = Utiles.validarNumeroToInt(reader["ID_REGISTRO"].ToString());

                    FACTOR_RETE_FUENTE = Utiles.validarNumeroToDouble(reader["FACTOR_RETEFUENTE"].ToString());
                    FACTOR_RETE_IVA = Utiles.validarNumeroToDouble(reader["FACTOR_RETE_IVA"].ToString());
                    FACTOR_RETE_ICA = Utiles.validarNumeroToDouble(reader["FACTOR_RETE_ICA"].ToString());

                    BASE_RETE_ICA_383 = Utiles.validarNumeroToDouble(reader["BASE_RETE_ICA_383"].ToString());
                    BASE_RETE_ICA_384 = Utiles.validarNumeroToDouble(reader["BASE_RETE_ICA_384"].ToString());

                    NOTA = reader["NOTA"].ToString();
                    METODO = reader["METODO"].ToString();

                    DESCRIPCION_OTROS_DESCUENTOS = reader["DESCRIPCION_OTROS_DESCUENTOS"].ToString();
                    VALOR_OTROS_DESCUENTOS = Utiles.validarNumeroToDouble(reader["VALOR_OTROS_DESCUENTOS"].ToString());
                    BASE_RETE_IVA = Utiles.validarNumeroToDouble(reader["BASE_RETE_IVA"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }

    public static bool TieneDependientes(string cedula)
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = @"select top 1 DEPENDIENTES from CUENTA inner join LIQUIDACIONES on CUENTA.ID_REGISTRO = LIQUIDACIONES.ID_RADICACION 
                                   where DEPENDIENTES > 0 AND NUM_DOCUMENTO = '" + cedula + "' and YEAR(fecha_radicado) = " + DateTime.Now.Year.ToString() + " order by LIQUIDACIONES.ID_REGISTRO desc";

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

    public int eliminar(int id_radicacion)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"ELIMINAR_LIQUIDACION";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_RADICACION", SqlDbType.Int).Value = id_radicacion;

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


    public int actualizarMetodo(string metodo)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string sql = @"UPDATE LIQUIDACIONES SET METODO = @METODO WHERE ID_REGISTRO = @ID_REGISTRO";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = this.ID_REGISTRO;
                cmd.Parameters.Add("@METODO", SqlDbType.VarChar).Value = metodo;

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




    public int insertar()
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("INSERTAR_LIQUIDACION", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@VALOR_TOTAL", SqlDbType.Decimal).Value = VALOR_TOTAL;
                cmd.Parameters.Add("@IBC", SqlDbType.Decimal).Value = IBC;
                cmd.Parameters.Add("@SALUD", SqlDbType.Decimal).Value = SALUD;
                cmd.Parameters.Add("@PENSION", SqlDbType.Decimal).Value = PENSION;
                cmd.Parameters.Add("@ARL", SqlDbType.Decimal).Value = ARL;
                cmd.Parameters.Add("@AFC", SqlDbType.Decimal).Value = AFC;
                cmd.Parameters.Add("@INT_VIVIENDA", SqlDbType.Decimal).Value = INT_VIVIENDA;
                cmd.Parameters.Add("@PREPAGADA", SqlDbType.Decimal).Value = PREPAGADA;
                cmd.Parameters.Add("@DEPENDIENTES", SqlDbType.Decimal).Value = DEPENDIENTES;
                cmd.Parameters.Add("@RENTA_EXENTA", SqlDbType.Decimal).Value = RENTA_EXENTA;
                cmd.Parameters.Add("@BASE_GRAVABLE_RETEFUENTE_383", SqlDbType.Decimal).Value = BASE_GRAVABLE_RETEFUENTE_383;
                cmd.Parameters.Add("@BASE_GRAVABLE_RETEFUENTE_384", SqlDbType.Decimal).Value = BASE_GRAVABLE_RETEFUENTE_384;
                cmd.Parameters.Add("@RETE_FUENTE_UVT_383", SqlDbType.Decimal).Value = RETE_FUENTE_UVT_383;
                cmd.Parameters.Add("@RETE_FUENTE_UVT_384", SqlDbType.Decimal).Value = RETE_FUENTE_UVT_384;
                cmd.Parameters.Add("@VALOR_RF_ART_383", SqlDbType.Decimal).Value = VALOR_RF_ART_383;
                cmd.Parameters.Add("@VALOR_RF_ART_384", SqlDbType.Decimal).Value = VALOR_RF_ART_384;
                cmd.Parameters.Add("@ICA", SqlDbType.Decimal).Value = ICA;
                cmd.Parameters.Add("@RETE_IVA", SqlDbType.Decimal).Value = RETE_IVA;
                cmd.Parameters.Add("@TOTAL_PAGAR_383", SqlDbType.Decimal).Value = TOTAL_PAGAR_383;
                cmd.Parameters.Add("@TOTAL_PAGAR_384", SqlDbType.Decimal).Value = TOTAL_PAGAR_384;
                cmd.Parameters.Add("@ID_RADICACION", SqlDbType.Int).Value = ID_RADICACION;

                cmd.Parameters.Add("@FACTOR_RETE_IVA", SqlDbType.Decimal).Value = FACTOR_RETE_IVA;
                cmd.Parameters.Add("@FACTOR_RETE_FUENTE", SqlDbType.Decimal).Value = FACTOR_RETE_FUENTE;
                cmd.Parameters.Add("@FACTOR_RETEICA", SqlDbType.Decimal).Value = FACTOR_RETE_ICA;

                cmd.Parameters.Add("@BASE_RETE_ICA_383", SqlDbType.Decimal).Value = BASE_RETE_ICA_383;
                cmd.Parameters.Add("@BASE_RETE_ICA_384", SqlDbType.Decimal).Value = BASE_RETE_ICA_384;

                cmd.Parameters.Add("@VALOR_OTROS_DESCUENTOS", SqlDbType.Decimal).Value = VALOR_OTROS_DESCUENTOS;

                cmd.Parameters.Add("@DESCRIPCION_OTROS_DESCUENTOS", SqlDbType.VarChar).Value = DESCRIPCION_OTROS_DESCUENTOS;

                cmd.Parameters.Add("@BASE_RETE_IVA", SqlDbType.Decimal).Value = BASE_RETE_IVA;

                cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = NOTA;
               

                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                int rows = cmd.ExecuteNonQuery();

                this.ID_REGISTRO = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conn.Close();

                return rows;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }

    }

    //public int editar()
    //{
    //    ConexionBD conBD = new ConexionBD("bd_con");

    //    try
    //    {
    //        using (DbConnection conn = conBD.GetDatabaseConnection())
    //        {
    //            conn.Open();


    //            SqlCommand cmd = new SqlCommand("EDITAR_CUENTA", (SqlConnection)conn);
    //            cmd.CommandType = CommandType.StoredProcedure;


    //            cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.Int).Value = id_registro;
    //            cmd.Parameters.Add("@ID_TIPO_DOCUMENTO", SqlDbType.Int).Value = ID_TIPO_DOCUMENTO;
    //            cmd.Parameters.Add("@NUM_DOCUMENTO", SqlDbType.VarChar).Value = NUM_DOCUMENTO;
    //            cmd.Parameters.Add("@NOMBRE_BENEFICIARIO", SqlDbType.VarChar).Value = NOMBRE_BENEFICIARIO;
    //            cmd.Parameters.Add("@NUM_PAGo", SqlDbType.VarChar).Value = NUM_PAGo;
    //            cmd.Parameters.Add("@VALOR_FACTURA", SqlDbType.Decimal).Value = VALOR_FACTURA;
    //            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = CORREO;
    //            cmd.Parameters.Add("@NUMERO_CONTRATO", SqlDbType.VarChar).Value = NUMERO_CONTRATO;
    //            cmd.Parameters.Add("@NUMERO_RP", SqlDbType.VarChar).Value = NUMERO_RP;
    //            cmd.Parameters.Add("@NUMERO_FACTURA", SqlDbType.VarChar).Value = NUMERO_FACTURA;
    //            cmd.Parameters.Add("@ID_TIPO_SOLICITUD", SqlDbType.Int).Value = ID_TIPO_SOLICITUD;
    //            cmd.Parameters.Add("@ID_ENTIDAD", SqlDbType.Int).Value = ID_ENTIDAD;

    //            int rows = cmd.ExecuteNonQuery();

    //            conn.Close();

    //            return rows;

    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        return -1;
    //    }

    //}


   




    public int IDRadicacion
    {
        get
        {
            return ID_RADICACION;
        }
        set
        {
            ID_RADICACION = value;
        }

    }

    public string Nota
    {
        get
        {
            return NOTA;
        }
        set
        {
            NOTA = value;
        }

    }

    public string DescripcionOtrosDescuentos
    {
        get
        {
            return DESCRIPCION_OTROS_DESCUENTOS;
        }
        set
        {
            DESCRIPCION_OTROS_DESCUENTOS = value;
        }

    }

    public double ValorOtrosDescuentos
    {
        get
        {
            return VALOR_OTROS_DESCUENTOS;
        }
        set
        {
            VALOR_OTROS_DESCUENTOS = value;
        }

    }

    public double ValorBaseReteIVA
    {
        get
        {
            return BASE_RETE_IVA;
        }
        set
        {
            BASE_RETE_IVA = value;
        }

    }

    public string Metodo
    {
        get
        {
            return METODO;
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
    public double ValorIBC
    {
        get
        {
            return IBC;
        }
        set
        {
            IBC = value;
        }

    }

    public double ValorSalud
    {
        get
        {
            return SALUD;
        }
        set
        {
            SALUD = value;
        }

    }

    public double ValorPension
    {
        get
        {
            return PENSION;
        }
        set
        {
            PENSION = value;
        }

    }

    public double ValorARL
    {
        get
        {
            return ARL;
        }
        set
        {
            ARL = value;
        }

    }

    public double ValorAFC
    {
        get
        {
            return AFC;
        }
        set
        {
            AFC = value;
        }

    }

    public double ValorIntVivienda
    {
        get
        {
            return INT_VIVIENDA;
        }
        set
        {
            INT_VIVIENDA = value;
        }

    }

    public double ValorPrepagada
    {
        get
        {
            return PREPAGADA;
        }
        set
        {
            PREPAGADA = value;
        }

    }

    public double ValorDependientes
    {
        get
        {
            return DEPENDIENTES;
        }
        set
        {
            DEPENDIENTES = value;
        }

    }

    public double ValorRentaExenta
    {
        get
        {
            return RENTA_EXENTA;
        }
        set
        {
            RENTA_EXENTA = value;
        }

    }

    public double ValorBaseGravableRetefuente383
    {
        get
        {
            return BASE_GRAVABLE_RETEFUENTE_383;
        }
        set
        {
            BASE_GRAVABLE_RETEFUENTE_383 = value;
        }

    }

    public double ValorBaseGravableRetefuente384
    {
        get
        {
            return BASE_GRAVABLE_RETEFUENTE_384;
        }
        set
        {
            BASE_GRAVABLE_RETEFUENTE_384 = value;
        }

    }

    public double ValorBaseReteICA383
    {
        get
        {
            return BASE_RETE_ICA_383;
        }
        set
        {
            BASE_RETE_ICA_383 = value;
        }

    }

    public double ValorBaseReteICA384
    {
        get
        {
            return BASE_RETE_ICA_384;
        }
        set
        {
            BASE_RETE_ICA_384 = value;
        }

    }

    public double ValorRetefuenteUVT383
    {
        get
        {
            return RETE_FUENTE_UVT_383;
        }
        set
        {
            RETE_FUENTE_UVT_383 = value;
        }

    }

    public double ValorRetefuenteUVT384
    {
        get
        {
            return RETE_FUENTE_UVT_384;
        }
        set
        {
            RETE_FUENTE_UVT_384 = value;
        }

    }

    public double ValorRFArt383
    {
        get
        {
            return VALOR_RF_ART_383;
        }
        set
        {
            VALOR_RF_ART_383 = value;
        }

    }

    public double ValorRFArt384
    {
        get
        {
            return VALOR_RF_ART_384;
        }
        set
        {
            VALOR_RF_ART_384 = value;
        }

    }

    public double ValorICA
    {
        get
        {
            return ICA;
        }
        set
        {
            ICA = value;
        }

    }

    public double ValorReteIVA
    {
        get
        {
            return RETE_IVA;
        }
        set
        {
            RETE_IVA = value;
        }

    }

    public double ValorTotalPagar383
    {
        get
        {
            return TOTAL_PAGAR_383;
        }
        set
        {
            TOTAL_PAGAR_383 = value;
        }

    }

    public double ValorTotalPagar384
    {
        get
        {
            return TOTAL_PAGAR_384;
        }
        set
        {
            TOTAL_PAGAR_384 = value;
        }

    }

    public double ValorFactorReteIVA
    {
        get
        {
            return FACTOR_RETE_IVA;
        }
        set
        {
            FACTOR_RETE_IVA = value;
        }

    }

    public double ValorFactorReteFuente
    {
        get
        {
            return FACTOR_RETE_FUENTE;
        }
        set
        {
            FACTOR_RETE_FUENTE = value;
        }

    }

    public double ValorFactorReteICA
    {
        get
        {
            return FACTOR_RETE_ICA;
        }
        set
        {
            FACTOR_RETE_ICA = value;
        }

    }

}