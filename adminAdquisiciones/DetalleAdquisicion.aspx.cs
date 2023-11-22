using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetalleAdquisicion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["usuario"] == null)
                Response.Redirect("Login.aspx");

            Usuarios usuario = (Usuarios)Session["usuario"];
            string nombre_usuario = usuario.Alias;
        }
        catch
        {

            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {

            for (int i = 2013; i < (DateTime.Now.Year + 5); i++)
            {
                DropDownListA_o.Items.Add(new ListItem(i.ToString(), i.ToString()));
                //DropDownListA_o0.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }

            if (Request.QueryString["id"] != null)
            {

                int id_registro = Utiles.validarNumeroToInt(Request.QueryString["id"].ToString());
                ViewState["id_solicitud"] = id_registro;


                Solicitud solicitud = new Solicitud(id_registro);

                cargarControles();

            }
            else
            {

                Response.Redirect("Formularios.aspx");
            }
        }
    }


    private void cargarControles()
    {
        int id_solicitud = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());
        Solicitud solicitud = new Solicitud(id_solicitud);

        solicitud.obtenerDatos();

        TextBoxNumRegistro.Text = solicitud.NumeroRegistro;

        TextBoxCodigosUNSPSC.Text = solicitud.CodigosUNSPSC;
        TextBoxDescripcion.Text = solicitud.Descripcion;
        //TextBoxInicioSeleccion.Text = solicitud.FechaInicio.ToShortDateString();
        DropDownListModalidadSeleccion.SelectedValue = solicitud.IDModalidadSeleccion.ToString();
        TextBoxValorEstimado.Text = solicitud.ValorEstimado.ToString("#.#");
        //TextBoxValorEstimado.Text = "45.000";
        TextBoxValorEstimadoVigencia.Text = solicitud.ValorEstimadoVigenciaActual.ToString("#.#");
        CheckBoxVigenciasFuturas.Checked = (solicitud.VigenciasFuturas == 1) ? true : false;
        DropDownListEstado.SelectedValue = solicitud.IDEstadoSolicitud.ToString();
        TextBoxContactoResponsable.Text = solicitud.ContactoResponsable;
        TextBoxDuracion.Text = solicitud.DuracionContrato.ToString();
        //DropDownListDuracion.SelectedValue = solicitud.IDTipoDuracion.ToString();
        DropDownListArea.SelectedValue = solicitud.IDArea.ToString();
        DropDownListFuente0.SelectedValue = solicitud.IDFuenteRecursos.ToString();
        DropDownListMes.SelectedValue = solicitud.Mes.ToString();
        DropDownListA_o.SelectedValue = solicitud.A_o.ToString();

        



    }


   
}