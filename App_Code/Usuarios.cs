using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;





/// <summary>
/// Manejo de usuarios del sistema
/// </summary>
public class Usuarios
{
    private string alias = "";
    private string nombre = "";
    private string perfil = "";
    private string clave = "";
    private string correo = "";
    private string estado = "";
    private int area = 0;
    private Int64 id = 0;
    private int nivel = 0;
    private int status = 0;
    private string mensaje = "";
    private int id_usuario;
    private int id_tipo_usuario = 0;
    private int aprobador_top = 0;
    private int requiere_aprobacion_top = 0;
    public int Mpio = 1;
    private int coordinador_area = 0;
    private int aprobador_local = 0;
    private int aprobador_general = 0;
    private int superintendente = 0;
    private int VoBoPDT = 0;
    private int es_persona = 1;
    private int actualizado = 0;

    public Usuarios()
    {

    }

    public Usuarios(int usuario)
    {
        this.id_usuario = usuario;

        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM usuarios WHERE id_usuario = '" + usuario +
                    "' AND Estado IN ('A','C','I')";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    this.perfil = reader["perfil"].ToString();
                    this.area = PetroIMS.validarNumeroToInt(reader["area"].ToString());
                    this.id = PetroIMS.validarNumeroToInt(reader["id"].ToString());
                    this.nombre = reader["nombre"].ToString();
                    this.estado = reader["estado"].ToString();
                    this.id_usuario = usuario;
                    this.alias = reader["Usuario"].ToString();
                    this.id_tipo_usuario = PetroIMS.validarNumeroToInt(reader["id_tipo_usuario"].ToString());
                    this.aprobador_top = (reader["aprobador_top"] != DBNull.Value) ? Convert.ToInt32(reader["aprobador_top"]) : 0;
                    this.requiere_aprobacion_top = (reader["requiere_aprobacion_top"] != DBNull.Value) ? Convert.ToInt32(reader["requiere_aprobacion_top"]) : 0;
                    this.coordinador_area = (reader["coordinador_area"] != DBNull.Value) ? Convert.ToInt32(reader["coordinador_area"]) : 0;
                    this.aprobador_local = (reader["aprobador_local"] != DBNull.Value) ? Convert.ToInt32(reader["aprobador_local"]) : 0;
                    this.aprobador_general = (reader["aprobador_general"] != DBNull.Value) ? Convert.ToInt32(reader["aprobador_general"]) : 0;
                    this.superintendente = (reader["superintendente"] != DBNull.Value) ? Convert.ToInt32(reader["superintendente"]) : 0;
                    this.correo = reader["correo"].ToString();
                    this.VoBoPDT = (reader["VoBoPDT"] != DBNull.Value) ? Convert.ToInt32(reader["VoBoPDT"]) : 0;
                    this.es_persona = (reader["es_persona"] != DBNull.Value) ? Convert.ToInt32(reader["es_persona"]) : 0;
                    this.actualizado = (reader["actualizado"] != DBNull.Value) ? Convert.ToInt32(reader["actualizado"]) : 0;
                    this.clave = reader["clave"].ToString();

                }
                select = "SELECT Nivel FROM perfiles WHERE Perfil='" + perfil + "' AND Estado = 'A'";
                cmd = new SqlCommand(select, (SqlConnection)conn);
                reader.Close();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    this.nivel = Convert.ToInt16(reader[0]);
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
        }



    }

    public Usuarios(string usuario)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM USUARIOS WHERE USUARIO='" + usuario +
                    "' AND ESTADO IN ('A','C')";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.perfil = reader["PERFIL"].ToString();
                    this.id = PetroIMS.validarNumeroToInt(reader["ID_USUARIO"].ToString());
                    this.nombre = reader["NOMBRE"].ToString();
                    this.estado = reader["ESTADO"].ToString();
                    this.alias = reader["USUARIO"].ToString();
                }

                reader.Close();

            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
        }
    }

    public Usuarios(string usuario, string clave)
    {
        ConexionBD conBD = new ConexionBD("bd_con");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM USUARIOS WHERE USUARIO='" + usuario + "' AND CLAVE = '" + clave +
                    "' AND ESTADO IN ('A','C')";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.perfil = reader["PERFIL"].ToString();
                    this.id = PetroIMS.validarNumeroToInt(reader["ID_USUARIO"].ToString());
                    this.nombre = reader["NOMBRE"].ToString();
                    this.estado = reader["ESTADO"].ToString();
                    this.alias = reader["USUARIO"].ToString();
                }

                reader.Close();

            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
        }
    }

    public int crear(string perfil, string nombre, string Correo, string Alias, string clave, int at, int rat, int ca, int al, int ag, int si, int VoBoPDT, int es_persona)
    {
        string sQuery = @"INSERT INTO usuarios (Usuario,Nombre,Perfil,Clave,Estado,correo,aprobador_top,requiere_aprobacion_top,coordinador_area,aprobador_local,aprobador_general,superintendente,Id,Area,VoBoPDT,es_persona) 
                        VALUES(@usuario,@nombre,@perfil,@clave,'A',@correo,@at,@rat,@ca,@al,@ag,@si,1,1,@VoBoPDT,@es_persona)";
        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();



                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);

                command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Alias;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                command.Parameters.Add("@correo", SqlDbType.VarChar).Value = Correo;
                command.Parameters.Add("@perfil", SqlDbType.VarChar).Value = perfil;
                command.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                command.Parameters.Add("@at", SqlDbType.SmallInt).Value = at;
                command.Parameters.Add("@rat", SqlDbType.SmallInt).Value = rat;
                command.Parameters.Add("@al", SqlDbType.SmallInt).Value = al;
                command.Parameters.Add("@ag", SqlDbType.SmallInt).Value = ag;
                command.Parameters.Add("@ca", SqlDbType.SmallInt).Value = ca;
                command.Parameters.Add("@si", SqlDbType.SmallInt).Value = si;
                command.Parameters.Add("@VoBoPDT", SqlDbType.SmallInt).Value = VoBoPDT;
                command.Parameters.Add("@es_persona", SqlDbType.SmallInt).Value = es_persona;




                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }


    public int crear(string Alias)
    {
        string sQuery = "INSERT INTO usuarios (Usuario,Nombre,Perfil,Clave,Estado,Id,Area,id_tipo_usuario) VALUES('" + Alias + "','" + nombre + "','" + perfil + "','" + clave + "','" + estado + "'," + id + "," + area + ",4)";
        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);
                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }



    public int eliminar()
    {
        string sQuery = @"DELETE FROM usuarios WHERE id_usuario = " + this.id_usuario.ToString();
        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();



                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);

                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }


    public static bool existe(string usuario)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT * FROM usuarios WHERE Usuario = '" + usuario + "'";

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





    public int actualizar()
    {
        string sQuery = @"UPDATE usuarios SET nombre=@nombre
            ,perfil=@perfil 
            ,estado=@estado 
            ,correo=@correo
            ,aprobador_top=@at
            ,requiere_aprobacion_top=@rat
            ,coordinador_area=@ca
            ,aprobador_local=@al
            ,aprobador_general=@ag
            ,superintendente=@si
            ,VoBoPDT=@VoBoPDT
            ,es_persona=@es_persona
             WHERE id_usuario=" + this.id_usuario;

        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);

                command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Alias;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                command.Parameters.Add("@perfil", SqlDbType.VarChar).Value = perfil;
                command.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
                command.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                command.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                command.Parameters.Add("@at", SqlDbType.SmallInt).Value = aprobador_top;
                command.Parameters.Add("@rat", SqlDbType.SmallInt).Value = requiere_aprobacion_top;
                command.Parameters.Add("@al", SqlDbType.SmallInt).Value = aprobador_local;
                command.Parameters.Add("@ag", SqlDbType.SmallInt).Value = aprobador_general;
                command.Parameters.Add("@ca", SqlDbType.SmallInt).Value = coordinador_area;
                command.Parameters.Add("@si", SqlDbType.SmallInt).Value = superintendente;
                command.Parameters.Add("@VoBoPDT", SqlDbType.SmallInt).Value = VoBoPDT;
                command.Parameters.Add("@es_persona", SqlDbType.SmallInt).Value = es_persona;

                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }


    public int actualizarClave(string clave)
    {
        string sQuery = "UPDATE usuarios SET Clave='" + clave + "' WHERE id_usuario = " + this.id_usuario.ToString();

        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);
                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }

    public XmlDocument lista()
    {
        XmlDocument documento = new XmlDocument();
        string xml = "<Root>";
        ConexionBD conBD = new ConexionBD("petrominerales");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM usuarios";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    xml += "<Usuario usuario='" + reader[0].ToString() +
                        "' nombre='" + reader[1].ToString() +
                        "' perfil='" + reader[2].ToString() +
                        "' id='" + reader[4].ToString() +
                        "' area='" + reader[5].ToString() +
                        "' estado='" + reader[6].ToString() + "'/>";
                }
                xml += "</Root>";
                documento.LoadXml(xml);
                conn.Close();

            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            xml += "<Error detalle='Error en la conexion'>";
            xml += "</Error></Root>";
            documento.LoadXml(xml);
            return documento;
        }
        return documento;
    }

    public XmlDocument lista(string filtro)
    {
        XmlDocument documento = new XmlDocument();
        string xml = "<Root>";
        ConexionBD conBD = new ConexionBD("petrominerales");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT * FROM usuarios " + filtro;

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    xml += "<Usuario usuario='" + reader[0].ToString() +
                        "' nombre='" + reader[1].ToString() +
                        "' perfil='" + reader[2].ToString() +
                        "' id='" + reader[4].ToString() +
                        "' area='" + reader[5].ToString() +
                        "' estado='" + reader[6].ToString() + "'/>";
                }
                xml += "</Root>";
                documento.LoadXml(xml);
                conn.Close();

            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            xml += "<Error detalle='Error en la conexion'>";
            xml += "</Error></Root>";
            documento.LoadXml(xml);
            return documento;
        }
        return documento;
    }


    public static XmlDocument listarAprobadoresTOP()
    {
        XmlDocument documento = new XmlDocument();
        string xml = "<Root>";
        ConexionBD conBD = new ConexionBD("petrominerales");

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT id_usuario,Nombre FROM usuarios WHERE aprobador_top = 1 AND estado = 'A' ";

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    xml += "<Usuario id='" + reader[0].ToString() + "' Nombre='" + reader[1].ToString() + "'/>";
                }
                xml += "</Root>";
                documento.LoadXml(xml);
                conn.Close();

            }
        }
        catch (SqlException ex)
        {

            xml += "<id='0' Nombre=''/>";
            documento.LoadXml(xml);
            return documento;

        }
        return documento;

    }



    public static List<Usuarios> UsuariosBackup(int usuario)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        List<Usuarios> li = new List<Usuarios>();

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                string select = "SELECT id_usuario FROM usuario_backup WHERE id_usuario_backup = " + usuario;

                SqlCommand cmd = new SqlCommand(select, (SqlConnection)conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    int id_usuario = PetroIMS.validarNumeroToInt(reader[0].ToString());
                    Usuarios usr = new Usuarios(id_usuario);

                    li.Add(usr);

                }

                reader.Close();

            }
        }
        catch (SqlException ex)
        {
            return li;
        }

        return li;

    }

    public int adicionarBackup(int id_usuario_backup)
    {
        string sQuery = @"INSERT INTO usuario_backup (id_usuario,id_usuario_backup) 
                        VALUES(@usuario,@usuario_backup)";
        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();



                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);

                command.Parameters.Add("@usuario", SqlDbType.Int).Value = this.id_usuario;
                command.Parameters.Add("@usuario_backup", SqlDbType.Int).Value = id_usuario_backup;

                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }


    public bool existeBackup(int usuario)
    {

        ConexionBD conBD = new ConexionBD("petrominerales");
        bool resp;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {

                conn.Open();

                string select2 = "SELECT * FROM usuario_backup WHERE id_usuario_backup = " + usuario.ToString() + " AND id_usuario = " + this.id_usuario.ToString();

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


    public int datosActualizados()
    {
        string sQuery = "UPDATE usuarios SET actualizado = 1 WHERE id_usuario = " + this.id_usuario.ToString();

        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);
                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            mensaje = ex.Message;
            status = ex.State;
            return rows;
        }
        return rows;
    }


    public int insertarBloqueContratista(int id_reporte, int id_bloque)
    {
        string sQuery = "INSERT INTO datos_contratista_bloques (id_reporte,id_bloque) VALUES(" + id_reporte + "," + id_bloque + ")";

        ConexionBD conBD = new ConexionBD("petrominerales");
        int rows = 0;
        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sQuery, (SqlConnection)conn);
                rows = command.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException ex)
        {
            return rows;
        }
        return rows;
    }


    public int insertarDatosContratista(string nombre_empresa, string nit, string nombre_gerente, string celular_gerente, string correo_gerente, string representante_hseq, string celular_rep_hseq, string correo_rep_hseq, string representante_hseq_2, string celular_rep_2_hseq, string correo_rep_2_hseq, int id_empresa)
    {
        ConexionBD conBD = new ConexionBD("petrominerales");
        int resp = 0;

        try
        {
            using (DbConnection conn = conBD.GetDatabaseConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("IngresarDatosContratista", (SqlConnection)conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = this.id_usuario;
                cmd.Parameters.Add("@nombre_empresa", SqlDbType.VarChar).Value = nombre_empresa;
                cmd.Parameters.Add("@nit", SqlDbType.VarChar).Value = nit;
                cmd.Parameters.Add("@nombre_gerente", SqlDbType.VarChar).Value = nombre_gerente;
                cmd.Parameters.Add("@celular_gerente", SqlDbType.VarChar).Value = celular_gerente;
                cmd.Parameters.Add("@correo_gerente", SqlDbType.VarChar).Value = correo_gerente;
                cmd.Parameters.Add("@representante_hseq", SqlDbType.VarChar).Value = representante_hseq;
                cmd.Parameters.Add("@celular_rep_hseq", SqlDbType.VarChar).Value = celular_rep_hseq;
                cmd.Parameters.Add("@correo_rep_hseq", SqlDbType.VarChar).Value = correo_rep_hseq;
                cmd.Parameters.Add("@representante_hseq_2", SqlDbType.VarChar).Value = representante_hseq_2;
                cmd.Parameters.Add("@celular_rep_2_hseq", SqlDbType.VarChar).Value = celular_rep_2_hseq;
                cmd.Parameters.Add("@correo_rep_2_hseq", SqlDbType.VarChar).Value = correo_rep_2_hseq;
                cmd.Parameters.Add("@id_empresa", SqlDbType.Int).Value = id_empresa;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                int rows = cmd.ExecuteNonQuery();
                resp = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                conn.Close();

                return resp;

            }
        }
        catch (SqlException ex)
        {
            return -1;
        }


    }





    public int Area
    {
        get
        {
            return area;
        }
        set
        {
            area = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }

    public string Clave
    {
        get
        {
            return clave;
        }
        set
        {
            clave = value;
        }
    }

    public string Perfil
    {
        get
        {
            return perfil;
        }
        set
        {
            perfil = value;
        }
    }

    public string Estado
    {
        get
        {
            return estado;
        }
        set
        {
            estado = value;
        }
    }

    public Int64 Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public int Status
    {
        get
        {
            return status;
        }
    }

    public int IDTipoUsuario
    {
        get
        {
            return id_tipo_usuario;
        }
    }

    public int IDUsuario
    {
        get
        {
            return id_usuario;
        }
    }

    public string Mensaje
    {
        get
        {
            return mensaje;
        }
    }

    public int Nivel
    {
        get
        {
            return nivel;
        }
    }

    public int AprobadorTOP
    {
        get
        {
            return aprobador_top;
        }
        set
        {
            aprobador_top = value;
        }
    }

    public int RequiereAprobacionTOP
    {
        get
        {
            return requiere_aprobacion_top;
        }
        set
        {
            requiere_aprobacion_top = value;
        }
    }

    public string Alias
    {
        get
        {
            return alias;
        }
        set
        {
            alias = value;
        }
    }


    public int CoordinadorArea
    {
        get
        {
            return coordinador_area;
        }
        set
        {
            coordinador_area = value;
        }
    }

    public int AprobadorGeneral
    {
        get
        {
            return aprobador_general;
        }
        set
        {
            aprobador_general = value;
        }
    }

    public int AprobadorLocal
    {
        get
        {
            return aprobador_local;
        }
        set
        {
            aprobador_local = value;
        }
    }

    public int Superintendente
    {
        get
        {
            return superintendente;
        }
        set
        {
            superintendente = value;
        }
    }

    public string Correo
    {
        get
        {
            return correo;
        }
        set
        {
            correo = value;
        }
    }

    public int VistoBuenoPDT
    {
        get
        {
            return VoBoPDT;
        }
        set
        {
            VoBoPDT = value;
        }
    }

    public int EsPersona
    {
        get
        {
            return es_persona;
        }
        set
        {
            es_persona = value;
        }
    }

    public int Actualizadoa
    {
        get
        {
            return actualizado;
        }
        set
        {
            actualizado = value;
        }
    }

}
