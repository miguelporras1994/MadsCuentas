using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SolicitudCertIngresos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            for (int i = 2010; i <= DateTime.Now.Year; i++)
            {
                DropDownListAno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CertificadoRetenciones sol = new CertificadoRetenciones();

        int id_solicitud = sol.solicitudPreviamenteEnviada(TextBoxCedula.Text, Utiles.validarNumeroToInt(DropDownListAno.Text));
        //Si la solicitud ya existe envia el certificado ya generado
        if (id_solicitud > 0)
        {
            sol.correoCertificado(id_solicitud, TextBoxCorreo.Text);
            Response.Write("<script>alert('Usted tiene una solicitud previamente registrada con el año seleccionado. El certificado será enviado al correo ingresado');window.location.href='SolicitudCertIngresos.aspx';</script>");
        }
        else
        {

            int id_resultado = sol.insertar(TextBoxCedula.Text, TextBoxCorreo.Text, Utiles.validarNumeroToInt(DropDownListAno.Text));
            if (id_resultado > 0)
            {
                Response.Write("<script>alert('Solicitid registrada correctamente');window.location.href='SolicitudCertIngresos.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Se genero un error al registrar la solicitud');window.location.href='SolicitudCertIngresos.aspx';</script>");
            }
        }
    }
}