using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;

public partial class RegistrarObligacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;

        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {




                int id_registro = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                ViewState["id_registro"] = id_registro;
                Cuenta cuenta = new Cuenta(id_registro);
                cuenta.obtenerDatos();
               
                TextBoxObligacion.Text = cuenta.NumeroObligacion;
               

            }
        }

    }



    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {

        try
        {

            int id_registro = Utiles.validarNumeroToInt(ViewState["id_registro"].ToString());
            Cuenta cuenta = new Cuenta(id_registro);
            cuenta.ReporteObligacion = TextBoxObligacion.Text;
            //cuenta.IDEntidad = Utiles.validarNumeroToInt(DropDownListEntidad.Text);

            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;




            int resp = cuenta.actualizarObligacion();

            if (resp > 0)
            {


                cuenta.insertarLOG(usuario.Alias, "", "Actualizacion Obligacion: " + TextBoxObligacion.Text, "Registro");
                Response.Write("<script>alert('La informacion se actualizo correctamente');window.location.href='ListarCuentasContabilidad.aspx';</script>");

            }
            else
            {

                Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion');window.history.back();</script>");

            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Se genero un error al tratar de guardar la informacion:" + ex.Message.Normalize() + "');window.history.back();</script>");

        }


    }
}