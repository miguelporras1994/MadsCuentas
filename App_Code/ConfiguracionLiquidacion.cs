using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



/// <summary>
/// Summary description for Cuenta
/// </summary>
public class ConfiguracionLiquidacion
{
    private int ID_FACTOR = 0;
    private double IBC = 0;
    private double SALUD = 0;
    private double PENSION = 0;
    private double ARL = 0;
    private double AFC = 0;
    private double RENTA_EXTERNA = 0;
    private double IVA = 0;
    private double BASE_PAGO_FSP = 0;
    private double PENSION_1 = 0;
    private double PENSION_2 = 0;
    private double DEPENDIENTES = 0;
    private double VALOR_UVT = 0;
    private double ICA = 0;
    private int MAX_UVT_INT_VIVIENDA = 0;
    private int MAX_UVT_PREPAGADA = 0;
    private int MAX_UVT_DEPEND = 0;
    private double RETE_IVA = 0;
    private double SALARIO_MINIMO = 0;
    private double FACTOR_PAGO_FSP = 0;
    private double PORC_LIMITE_INGRESO_HONORARIOS = 0;





    public void obtenerDatos()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM CONFIGURACION_LIQUIDACION";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    IBC = Utiles.validarNumeroToDouble(reader["IBC"].ToString());
                    IVA = Utiles.validarNumeroToDouble(reader["IVA"].ToString());
                    SALUD = Utiles.validarNumeroToDouble(reader["SALUD"].ToString());

                    ARL = Utiles.validarNumeroToDouble(reader["ARL"].ToString());
                    AFC = Utiles.validarNumeroToDouble(reader["AFC"].ToString());
                    RENTA_EXTERNA = Utiles.validarNumeroToDouble(reader["RENTA_EXTERNA"].ToString());
                    BASE_PAGO_FSP = Utiles.validarNumeroToDouble(reader["BASE_PAGO_FSP"].ToString());
                    PENSION_1 = Utiles.validarNumeroToDouble(reader["PENSION_1"].ToString());
                    PENSION_2 = Utiles.validarNumeroToDouble(reader["PENSION_2"].ToString());
                    DEPENDIENTES = Utiles.validarNumeroToDouble(reader["DEPENDIENTES"].ToString());
                    VALOR_UVT = Utiles.validarNumeroToDouble(reader["VALOR_UVT"].ToString());
                    ICA = Utiles.validarNumeroToDouble(reader["ICA"].ToString());

                    MAX_UVT_DEPEND = Utiles.validarNumeroToInt(reader["MAX_UVT_DEPEND"].ToString());
                    MAX_UVT_PREPAGADA = Utiles.validarNumeroToInt(reader["MAX_UVT_PREPAGADA"].ToString());
                    MAX_UVT_INT_VIVIENDA = Utiles.validarNumeroToInt(reader["MAX_UVT_INT_VIVIENDA"].ToString());
                    RETE_IVA = Utiles.validarNumeroToDouble(reader["RETE_IVA"].ToString());
                    SALARIO_MINIMO = Utiles.validarNumeroToDouble(reader["SALARIO_MINIMO"].ToString());
                    FACTOR_PAGO_FSP = Utiles.validarNumeroToInt(reader["FACTOR_PAGO_FSP"].ToString());
                    PORC_LIMITE_INGRESO_HONORARIOS = Utiles.validarNumeroToDouble(reader["PORC_LIMITE_INGRESO_HONORARIOS"].ToString());

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {


        }

    }

    #region funciones personas juridicas
    public static double calcularValorReteICAJuridica(double factor, double base_calc)
    {

        return Math.Round((factor * base_calc) / 1000, 0);
    }

    public static double calcularValorReteFuenteJuridica(double factor, double base_calc)
    {

        return Math.Round((factor * base_calc) / 100, 0);
    }

    public static double calcularValorReteIVAJuridica(double factor, double base_calc)
    {

        return Math.Round((factor * base_calc) / 100, 0);
    }

    #endregion

    public double obtenerValorRetefuenteTabla384(double uvt)  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        double retencion = 0;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT RETENCION FROM TARIFA_RETENCION_ART_384 WHERE " + uvt.ToString().Replace(",", ".") + " BETWEEN DESDE  AND HASTA ";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    retencion = (reader["RETENCION"] != DBNull.Value) ? Utiles.validarNumeroToDouble(reader["RETENCION"].ToString()) : 0;

                }

                conn.Close();

            }
        }
        catch (SqlException ex)
        {

            return 0;

        }

        return Math.Round((retencion * VALOR_UVT), 0); ;

    }


    public static double obtenerPorcentajeRiesgoLaboral(int id_riesgo)  //ERROR E1001  
    {


        ConexionBD conBD = new ConexionBD("bd_con");
        double resp = 0;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT PORCENTAJE FROM RIESGOS_LABORALES WHERE ID_RIESGO = @id_riesgo";

                // Retornar el riesgo laboral por defecto
                if (id_riesgo == 0)
                    select = "SELECT PORCENTAJE FROM RIESGOS_LABORALES WHERE ID_RIESGO = 1";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                cmd.Parameters.AddWithValue("@id_riesgo", id_riesgo);
                //SqlDataReader reader = cmd.ExecuteReader();
                object o = cmd.ExecuteScalar();
                if (o == null)
                    resp = 0;
                else
                    resp = (double)o;

                conn.Close();

            }
        }
        catch (SqlException ex)
        {

            return 0;

        }

        return resp;

    }



    public double CalcularRetefuenteUVT(double bgReteFte)
    {

        return (bgReteFte) / VALOR_UVT;
    }



    public double CalcularReteIVA(double valorIVA)
    {

        return Math.Round((valorIVA * RETE_IVA), 0);
    }


    public double CalcularICA(double total, double salud, double pension, double arl, double ica)
    {
        if (ica == 0)
            return Math.Round((((total - salud - pension - arl) * ICA) / 1000),0);
            //return Math.Round((((total - salud - pension) * ICA) / 1000), 0);
        else
            return Math.Round((((total - salud - pension - arl) * ica) / 1000), 0);
            //return Math.Round((((total - salud - pension - arl) * ica) / 1000), 0);
    }

    public double CalcularAFC(double total, double pension)
    {

        return Math.Round(((total * AFC) - pension), 0);
    }



    public double CalcularValorReteFuenteArt383(double retefuenteUVT)
    {
        double resp = 0;

        if (retefuenteUVT <= 95)
            resp = 0;
        else if (retefuenteUVT <= 150)
            resp = (retefuenteUVT - 95) * 0.19 * VALOR_UVT;
        else if (retefuenteUVT <= 360)
            resp = (retefuenteUVT - 150) * 0.28 * VALOR_UVT + (10 * VALOR_UVT);
        else if (retefuenteUVT > 360)
            resp = (retefuenteUVT - 360) * 0.33 * VALOR_UVT + (69 * VALOR_UVT);

        return Math.Round(resp, 0);
    }


    //double baseGravableRetefuente = Math.Round((valorFactura - valorSalud - valorPension - valorARL - valorAFC - valorIntViv - valorPrepag - valorDep), 0);

    public double CalcularPreliquidacionBaseGravableRetefuente(double valorFactura, double valorSalud, double valorPension, double valorARL, double valorAFC, double valorIntViv, double valorPrepag, double valorDep)
    {

        return Math.Round((valorFactura - valorSalud - valorPension - valorARL - valorAFC - valorIntViv - valorPrepag - valorDep), 0);
    }

    public static double CalcularBaseGravableReteICA(double valorFactura, double valorSalud, double valorPension, double valorARL)
    {
        if (valorPension == 0 && valorSalud == 0 && valorARL == 0)
            return 0;
        return Math.Round((valorFactura - valorSalud - valorPension - valorARL), 0);
    }

    public static double CalcularBaseGravableReteICA(double factor_ica, double valorICA)
    {
        //if (valorPension == 0 && valorSalud == 0 && valorARL == 0)
        if (factor_ica == 0)
        {
            ConfiguracionLiquidacion conf = new ConfiguracionLiquidacion();
            conf.obtenerDatos();
            factor_ica = conf.ValorReteICA;
        }
        return valorICA / (factor_ica / 1000);
        //return Math.Round((valorFactura - valorSalud - valorPension - valorARL), 0);
    }

    public double CalcularBaseGravableRetefuente384(double valorFactura, double valorSalud, double valorPension, double valorARL)
    {

        return Math.Round((valorFactura - valorSalud - valorPension - valorARL), 0);
    }

    public double CalcularBaseGravableRetefuente383(double preBaseG, double rentaExenta)
    {
        return preBaseG - rentaExenta;
    }

    public double CalcularIBC(double valor)
    {
        if (valor == 0)
            return 0;
        double result = Math.Ceiling(valor * this.IBC);
        if (result < this.SALARIO_MINIMO)
            return this.SALARIO_MINIMO;
        else
            return result;

    }

    public double CalcularIVA(double valor)
    {

        double aux = valor / (this.IVA + 1);
        return valor - Math.Round(aux, 0);

    }

    public double CalcularSalud(double valor)
    {

        return valor * this.SALUD;

    }

    public double CalcularInteresVivienda(double valor)
    {

        return valor / 12;

    }

    public double CalcularInteresPrepagada(double valor, int meses)
    {

        return valor / meses;

    }

    public double CalcularPension(double valorIBC, bool combinadas, string documento, double valorFacturaNueva)
    {

        double basePagoFSP = SALARIO_MINIMO * FACTOR_PAGO_FSP;

        if (!combinadas)
        {
            return valorPension(valorIBC);
        }
        else
        {

            double valorIBCFactNueva = this.CalcularIBC(valorFacturaNueva);
            double valorPensionActual = valorPension(valorIBCFactNueva);

            return Cuenta.ValorPensionPorMes(documento) + valorPensionActual;

        }

    }

    public double valorPension(double valorIBC)
    {
        double basePagoFSP = SALARIO_MINIMO * FACTOR_PAGO_FSP;
        double valorPensionActual = 0;

        if (valorIBC >= basePagoFSP)
            valorPensionActual = Math.Round((valorIBC * PENSION_2), 0);
        else
            valorPensionActual = Math.Round((valorIBC * PENSION_1), 0);

        return valorPensionActual;

    }

    public double CalcularARL(double valor)
    {

        return Math.Round(((valor * this.ARL) / 100), 0);

    }

    public double CalcularARL(double valor, double porcentajeRiesgoLaboral)
    {
        if (porcentajeRiesgoLaboral == 0)
            return 0;
        return Math.Round(((valor * porcentajeRiesgoLaboral) / 100), 0);

    }

    public double CalcularRentaExenta(double valor)
    {

        return Math.Round((valor * this.RENTA_EXTERNA), 0);

    }

    public double CalcularValorDependientes(double valor)
    {

        double res = Math.Round((valor * this.DEPENDIENTES), 0);
        double max = VALOR_UVT * MAX_UVT_DEPEND;

        if (res > max)
            return max;
        else
            return res;

    }

    public double CalcularValorPrepagada(double valor)
    {

        //double res = Math.Round((valor * this.DEPENDIENTES), 0);
        double max = VALOR_UVT * MAX_UVT_PREPAGADA;

        if (valor > max)
            return max;
        else
            return valor;

    }

    public double CalcularValorInteresesVivienda(double valor)
    {

        //double res = Math.Round((valor * this.DEPENDIENTES), 0);
        double max = VALOR_UVT * MAX_UVT_INT_VIVIENDA;

        if (valor > max)
            return max;
        else
            return valor;

    }


    public double CalcularValorRentaLiquidaCedular(double valorTotal, double vrSalud, double vrPension)
    {

        return valorTotal - vrSalud - vrPension;

    }

    public double CalcularValorRentaLiquidaCedular(double valorTotal, double vrSalud, double vrPension, double vrARL)
    {

        return valorTotal - vrSalud - vrPension - vrARL;

    }

    public double CalcularValorRentasExentas(double valorMedPrep, double valorIntVivienda, double valorDependientes)
    {

        return valorMedPrep + valorIntVivienda + valorDependientes;

    }

    public double CalcularValorBaseBrutaGravable(double valorTotal, double valorIncrngo, double valorRentasExentas, double valorDeducciones)
    {

        return valorTotal - valorIncrngo - valorRentasExentas - valorDeducciones;

    }


    public double CalcularValorTotalIncrngo(double valorSalud, double valorPension, double valorFsp)
    {

        return valorSalud + valorPension + valorFsp;

    }

    public double CalcularValorRentaExenta(double valorBaseGravableBruta)
    {

        return valorBaseGravableBruta * 0.25;

    }

    public double CalcularValorTotalDeducciones(double valorMedPrep, double valorIntVivienda, double valorDependientes)
    {

        return valorMedPrep + valorIntVivienda + valorDependientes;

    }

    public double CalcularValorTotalDeduccionesValidacion(double valorRentasExentas, double valorDeducciones, double valorRentaExenta25)
    {

        return valorRentasExentas + valorDeducciones + valorRentaExenta25;

    }

    /*

    public double validarTotalDeducciones(double valorRentasExentas, double valorDeducciones, double valorRentaExenta,double valorLimiteIngHon)
    {

        double totalD = valorRentaExenta + valorDeducciones + valorRentasExentas;

        return valorMedPrep + valorIntVivienda + valorDependientes;

    }*/

    public double calcularBaseGravable(double valorRentasExentas, double valorDeducciones, double valorRentaExenta, double valorLimiteIngHon, double valorTotal, double valorIncrngo)
    {
        this.obtenerDatos();

        double totalD = valorRentaExenta + valorDeducciones + valorRentasExentas;
        //double valorLimiteIngHonor = (valorTotal - valorIncrngo) * this.ValorLimiteIngresoHonorarios;

        double dedux = 0.0;
        if (totalD > valorLimiteIngHon)
            dedux = valorLimiteIngHon;
        else
            dedux = totalD;

        return valorTotal - valorIncrngo - dedux;

    }


    public double CalcularLimiteIngresoHonorarios(double valorRentaLCedular)
    {
        this.obtenerDatos();
        double limiteIngHon = this.ValorLimiteIngresoHonorarios;
        return limiteIngHon * valorRentaLCedular;

    }

    public double OtenerLimiteIngresoHonorarios(double valorLimite, double valorDeducciones)
    {

        if (valorDeducciones > valorLimite)
            return valorLimite;
        else
            return valorDeducciones;

    }

    public DataTable consultarEntrenamientosActividad()  //ERROR E1001  
    {

        ConexionBD conBD = new ConexionBD("bd_con");
        DataTable dtregistros = new DataTable();


        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

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

                //cmd.Parameters.Add("@ID_REGISTRO", SqlDbType.VarChar).Value = ID_REGISTRO;
                //cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USUARIO;
                //cmd.Parameters.Add("@EVENTO", SqlDbType.VarChar).Value = EVENTO;
                //cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA;

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


    public double ValorUVT
    {
        get
        {
            return VALOR_UVT;
        }
    }


    public double ValorReteIVA
    {
        get
        {
            return RETE_IVA;
        }
    }

    public double ValorReteICA
    {
        get
        {
            return ICA;
        }

    }

    public double ValorLimiteIngresoHonorarios
    {
        get
        {
            return PORC_LIMITE_INGRESO_HONORARIOS;
        }

    }




    public double ValorSalarioMinimo
    {
        get
        {
            return SALARIO_MINIMO;
        }
    }

}