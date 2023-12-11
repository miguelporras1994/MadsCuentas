using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.Common;
using System.Collections.Generic;
using System.Configuration;

public partial class ResolverSolicitud : System.Web.UI.Page
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

        Adquisicion adquisicion = new Adquisicion();

        adquisicion.NumeroRegistro = solicitud.NumeroRegistro;
        adquisicion.obtenerDatosPorNumRegistro();


        solicitud.obtenerDatos();

        TextBoxNumRegistro.Text = solicitud.NumeroRegistro;

        if (solicitud.NumeroRegistro == "")
        {

            TextBoxNumRegistro.ReadOnly = false;
            LabelError.Visible = true;
        }
        else
        {

            TextBoxNumRegistro.ReadOnly = true;
            LabelError.Visible = false;
        }



        if (solicitud.CodigosUNSPSC != "")
        {
            TextBoxCodigosUNSPSC.Text = solicitud.CodigosUNSPSC;
            TextBoxCodigosUNSPSC.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxCodigosUNSPSC.Text = adquisicion.CodigosUNSPSC;
        }

        if (solicitud.Descripcion.Trim() != "")
        {
            TextBoxDescripcion.Text = solicitud.Descripcion;
            TextBoxDescripcion.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxDescripcion.Text = adquisicion.Descripcion;
        }


        if (solicitud.IDFuenteRecursos > 0)
        {
            DropDownListFuente0.SelectedValue = solicitud.IDFuenteRecursos.ToString();
            DropDownListFuente0.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListFuente0.SelectedValue = adquisicion.IDFuenteRecursos.ToString();
        }

        if (solicitud.IDModalidadSeleccion > 0)
        {
            DropDownListModalidadSeleccion.SelectedValue = solicitud.IDModalidadSeleccion.ToString();
            DropDownListModalidadSeleccion.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListModalidadSeleccion.SelectedValue = adquisicion.IDModalidadSeleccion.ToString();
        }

        if (solicitud.ValorEstimado > 0)
        {
            TextBoxValorEstimado.Text = solicitud.ValorEstimado.ToString("#.#");
            TextBoxValorEstimado.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxValorEstimado.Text = adquisicion.ValorEstimado.ToString("#.#");
        }

        if (solicitud.ValorEstimadoVigenciaActual > 0)
        {
            TextBoxValorEstimadoVigencia.Text = solicitud.ValorEstimadoVigenciaActual.ToString("#.#");
            TextBoxValorEstimadoVigencia.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxValorEstimadoVigencia.Text = adquisicion.ValorEstimadoVigenciaActual.ToString("#.#");
        }

        if (solicitud.VigenciasFuturas != adquisicion.VigenciasFuturas)
        {
            CheckBoxVigenciasFuturas.Checked = (solicitud.VigenciasFuturas == 1) ? true : false;
        }
        else
        {
            CheckBoxVigenciasFuturas.Checked = (adquisicion.VigenciasFuturas == 1) ? true : false;
        }

        if (solicitud.IDEstadoSolicitud != adquisicion.IDEstadoSolicitud)
        {
            DropDownListEstado.SelectedValue = solicitud.IDEstadoSolicitud.ToString();
            DropDownListEstado.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListEstado.SelectedValue = adquisicion.IDEstadoSolicitud.ToString();
        }

        if (solicitud.ContactoResponsable.Trim() != "")
        {
            TextBoxContactoResponsable.Text = solicitud.ContactoResponsable;
            TextBoxContactoResponsable.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxContactoResponsable.Text = adquisicion.ContactoResponsable;
        }

        if (solicitud.DuracionContrato > 0)
        {
            TextBoxDuracion.Text = solicitud.DuracionContrato.ToString("");
            TextBoxDuracion.BackColor = Color.Yellow;
        }
        else
        {
            TextBoxDuracion.Text = adquisicion.DuracionContrato.ToString("");
        }

        if (solicitud.Mes > 0)
        {
            DropDownListMes.SelectedValue = solicitud.Mes.ToString();
            DropDownListMes.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListMes.SelectedValue = adquisicion.Mes.ToString();
        }

        if (solicitud.A_o != adquisicion.A_o)
        {
            DropDownListA_o.SelectedValue = solicitud.A_o.ToString();
            DropDownListA_o.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListA_o.SelectedValue = adquisicion.A_o.ToString();
        }

        if ((solicitud.IDTipoDuracion != adquisicion.IDTipoDuracion) && solicitud.IDTipoDuracion > 0)
        {
            DropDownListDuracion.SelectedValue = solicitud.IDTipoDuracion.ToString();
            DropDownListDuracion.BackColor = Color.Yellow;

        }
        else
        {

            DropDownListDuracion.SelectedValue = adquisicion.IDTipoDuracion.ToString();
        }

        //TextBoxCodigosUNSPSC.Text = (solicitud.CodigosUNSPSC != "") ? solicitud.CodigosUNSPSC : adquisicion.CodigosUNSPSC;
        //TextBoxDescripcion.Text = solicitud.Descripcion;
        //TextBoxInicioSeleccion.Text = solicitud.FechaInicio.ToShortDateString();
        //DropDownListModalidadSeleccion.SelectedValue = solicitud.IDModalidadSeleccion.ToString();
        //TextBoxValorEstimado.Text = solicitud.ValorEstimado.ToString("#.#");
        //TextBoxValorEstimado.Text = "45.000";
        //TextBoxValorEstimadoVigencia.Text = solicitud.ValorEstimadoVigenciaActual.ToString("#.#");
        //CheckBoxVigenciasFuturas.Checked = (solicitud.VigenciasFuturas == 1) ? true : false;
        //DropDownListEstado.SelectedValue = solicitud.IDEstadoSolicitud.ToString();
        //TextBoxContactoResponsable.Text = solicitud.ContactoResponsable;
        //TextBoxDuracion.Text = solicitud.DuracionContrato.ToString();
        //DropDownListDuracion.SelectedValue = solicitud.IDTipoDuracion.ToString();
        DropDownListArea.SelectedValue = solicitud.IDArea.ToString();
        //DropDownListFuente0.SelectedValue = solicitud.IDFuenteRecursos.ToString();
        //DropDownListMes.SelectedValue = solicitud.Mes.ToString();
        //DropDownListA_o.SelectedValue = solicitud.A_o.ToString();

        int id_tipo_solicitud = solicitud.IDTipoSolicitud;
        switch (id_tipo_solicitud)
        {
            case 1:
                LabelPanelExistente.Text = "ADICION";
                ViewState["operacion"] = "ADICION";
                break;
            case 2:
                LabelPanelExistente.Text = "MODIFICACION";
                ViewState["operacion"] = "MODIFICACION";
                break;
            case 3:
                LabelPanelExistente.Text = "ELIMINACION";
                ViewState["operacion"] = "ELIMINACION";
                break;
        }



    }

    public void enviarCorreoAdmin(string tipo,string detalle,string correo,string operacion)
    {




        //Enviar correo

        String cuerpo_correo = "";
        int id_registro = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());
        Solicitud solicitud = new Solicitud(id_registro);

        cuerpo_correo = "";

        if(tipo != "adicion")
            cuerpo_correo += "<br /><b>Numero de Radicación:</b>" + id_registro.ToString();
        cuerpo_correo += "<br /><br />Su solicitud de " + tipo + " fué " + operacion + ": <br /><br />" + detalle;

       

        cuerpo_correo += "</body></html>";


        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        String csname1 = "PopupScript";


        string correo_para = ConfigurationSettings.AppSettings["CorreoParaAdquisiciones"];
        string correo_copia = ConfigurationSettings.AppSettings["CorreoCopiaAdquisciones"];

        try
        {
            Correo.enviarHTML(correo, "Respuesta Solicitud " + id_registro.ToString(), cuerpo_correo, correo_copia);
        }
        catch { }


    }



    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {
        Usuarios usuario = (Usuarios)Session["usuario"];
        string nombre_usuario = usuario.Alias;
        int id_registro = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());
        Solicitud solicitud = new Solicitud(id_registro);
        Adquisicion adquisicion = new Adquisicion();

        int res = 0;

        if (ViewState["operacion"].ToString() == "ADICION")
        {
            if (DropDownListAprobacion.Text == "2")
            {
                if (TextBoxNumRegistro.Text == "")
                {
                    Response.Write("<script>alert('Por favor ingrese el numero de registro');</script>");
                    return;
                }
            }
        }


        try
        {

            if (ViewState["operacion"].ToString() == "ADICION")
            {
                //Solamente si es adicion
                if (DropDownListAprobacion.Text == "2")
                {

                    if (Adquisicion.numeroRegistroExiste(TextBoxNumRegistro.Text))
                    {
                        Response.Write("<script>alert('El numero de registro ingresado ya se encuentra registrado');</script>");
                        return;
                    }
                }
               

                adquisicion.NumeroRegistro = TextBoxNumRegistro.Text;
                adquisicion.CodigosUNSPSC = solicitud.CodigosUNSPSC;
                adquisicion.Descripcion = solicitud.Descripcion;
                adquisicion.FechaInicio = solicitud.FechaInicio;
                adquisicion.DuracionContrato = solicitud.DuracionContrato;
                adquisicion.FuenteRecursos = solicitud.FuenteRecursos;
                adquisicion.ValorEstimado = solicitud.ValorEstimado;
                adquisicion.ValorEstimadoVigenciaActual = solicitud.ValorEstimadoVigenciaActual;
                adquisicion.VigenciasFuturas = solicitud.VigenciasFuturas;
                adquisicion.ContactoResponsable = solicitud.ContactoResponsable;
                adquisicion.IDArea = solicitud.IDArea;
                adquisicion.IDModalidadSeleccion = solicitud.IDModalidadSeleccion;
                adquisicion.NombresApellidos = solicitud.NombresApellidos;
                adquisicion.Cargo = solicitud.Cargo;
                adquisicion.Correo = solicitud.Correo;
                adquisicion.Extension = solicitud.Extension;
                adquisicion.IDTipoDuracion = solicitud.IDTipoDuracion;
                adquisicion.Mes = solicitud.Mes;
                adquisicion.A_o = solicitud.A_o;
                adquisicion.IDFuenteRecursos = solicitud.IDFuenteRecursos;

                
                if (DropDownListAprobacion.Text == "2")
                {
                    res = adquisicion.insertar();
                    if (res > 0)
                    {

                        Response.Write("<script>alert('La adquisicion fue adicionada con exito.');window.location.href='ListarSolicitudes.aspx';</script>");
                        solicitud.aprobada(TextBoxObservaciones.Text);
                        enviarCorreoAdmin("adquisicion",TextBoxObservaciones.Text,adquisicion.Correo,"aprobada");
                    }
                    else
                    {
                        Response.Write("<script>alert('La adquisicion no pudo ser adicionada.');window.history.back();</script>");

                    }
                    
                }
                else if (DropDownListAprobacion.Text == "3")
                {
                    res = solicitud.rechazada(TextBoxObservaciones.Text);
                    if (res > 0)
                    {
                        Response.Write("<script>alert('La solicitud fue rechazada.');window.location.href='ListarSolicitudes.aspx';</script>");
                        enviarCorreoAdmin("adquisicion", TextBoxObservaciones.Text, adquisicion.Correo, "rechazada");
                    }
                    else
                    {
                        Response.Write("<script>alert('La solicitud no pudo ser rechazada.');window.history.back();</script>");
                    }
                    
                }

            }
            if (ViewState["operacion"].ToString() == "MODIFICACION")
            {
                adquisicion.NumeroRegistro = TextBoxNumRegistro.Text;
                adquisicion.obtenerDatosPorNumRegistro();

                adquisicion.NumeroRegistro = solicitud.NumeroRegistro;
                adquisicion.CodigosUNSPSC = solicitud.CodigosUNSPSC;
                adquisicion.Descripcion = solicitud.Descripcion;
                adquisicion.FechaInicio = solicitud.FechaInicio;
                adquisicion.DuracionContrato = solicitud.DuracionContrato;
                adquisicion.FuenteRecursos = solicitud.FuenteRecursos;
                adquisicion.ValorEstimado = solicitud.ValorEstimado;
                adquisicion.ValorEstimadoVigenciaActual = solicitud.ValorEstimadoVigenciaActual;
                adquisicion.VigenciasFuturas = solicitud.VigenciasFuturas;
                adquisicion.ContactoResponsable = solicitud.ContactoResponsable;
                adquisicion.IDArea = solicitud.IDArea;
                adquisicion.IDModalidadSeleccion = solicitud.IDModalidadSeleccion;
                adquisicion.NombresApellidos = solicitud.NombresApellidos;
                adquisicion.Cargo = solicitud.Cargo;
                adquisicion.Correo = solicitud.Correo;
                adquisicion.Extension = solicitud.Extension;
                adquisicion.TipoDuracion = solicitud.TipoDuracion;
                adquisicion.Mes = solicitud.Mes;
                adquisicion.A_o = solicitud.A_o;
                adquisicion.IDFuenteRecursos = solicitud.IDFuenteRecursos;

                if (DropDownListAprobacion.Text == "2")
                {
                    res = adquisicion.actualizar();
                    if (res > 0)
                    {

                        Response.Write("<script>alert('La adquisicion fue modificada con exito.');window.location.href='ListarSolicitudes.aspx';</script>");
                        solicitud.aprobada(TextBoxObservaciones.Text);
                        //enviarCorreoAdmin("modificación", TextBoxObservaciones.Text, adquisicion.Correo, "aprobada");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se realizo ninguna modificacion');window.location.href='ListarSolicitudes.aspx;</script>");
                        solicitud.aprobada(TextBoxObservaciones.Text);

                    }
                }
                else if (DropDownListAprobacion.Text == "3")
                {

                    res = solicitud.rechazada(TextBoxObservaciones.Text);
                    if (res > 0)
                    {
                        Response.Write("<script>alert('La solicitud fue rechazada.');window.location.href='ListarSolicitudes.aspx';</script>");
                        //enviarCorreoAdmin("modificación", TextBoxObservaciones.Text, adquisicion.Correo, "rechazada");
                    }
                    else
                    {
                        Response.Write("<script>alert('La solicitud no pudo ser rechazada.');window.history.back();</script>");
                    }

                }

            }

            if (ViewState["operacion"].ToString() == "ELIMINACION")
            {
                adquisicion.NumeroRegistro = TextBoxNumRegistro.Text;
                adquisicion.obtenerDatosPorNumRegistro();

                if (DropDownListAprobacion.Text == "2")
                {
                    res = adquisicion.eliminar();
                    if (res > 0)
                    {

                        Response.Write("<script>alert('La adquisicion fue eliminada con exito.');window.location.href='ListarSolicitudes.aspx';</script>");
                        solicitud.aprobada(TextBoxObservaciones.Text);
                        //enviarCorreoAdmin("eliminación", TextBoxObservaciones.Text, adquisicion.Correo, "aprobada");
                    }
                    else
                    {
                        Response.Write("<script>alert('La adquisicion no pudo ser eliminada.');window.history.back();</script>");

                    }
                }
                else if (DropDownListAprobacion.Text == "3")
                {

                    res = solicitud.rechazada(TextBoxObservaciones.Text);
                    if (res > 0)
                    {
                        Response.Write("<script>alert('La solicitud fue rechazada.');window.location.href='ListarSolicitudes.aspx';</script>");
                        //enviarCorreoAdmin("eliminación", TextBoxObservaciones.Text, adquisicion.Correo, "rechazada");
                    }
                    else
                    {
                        Response.Write("<script>alert('La solicitud no pudo ser rechazada.');window.history.back();</script>");
                    }

                }
            
            }

           
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('Se genero un error:" + ex.Message.Normalize() + "');window.history.back();</script>");
        }

        enviarCorreo(TextBoxObservaciones.Text);

    }



    private void enviarCorreo(string observaciones)
    {
        int id_registro = Utiles.validarNumeroToInt(ViewState["id_solicitud"].ToString());
        Solicitud solicitud = new Solicitud(id_registro);
        string operacion = ViewState["operacion"].ToString();


        //Enviar correo

        String cuerpo_correo = @"
                <br /><br />
                Señor(a) " + solicitud.NombresApellidos + ": <br /> ";

        string tipo_solicitud = "";

        switch (solicitud.IDTipoSolicitud){

            case 1:
                tipo_solicitud = "Adici&oacute;n";
                break;
            case 2:
                tipo_solicitud = "Modificaci&oacute;n";
                break;
            case 3:
                tipo_solicitud = "Eliminaci&oacute;n";
                break;

        }

        cuerpo_correo += "<br />En respuesta a su solicitud de " + tipo_solicitud + " con n&uacute;mero de radicaci&oacute;n " + solicitud.ID +  " radicada la fecha de  " + solicitud.FechaRegistro.ToShortDateString();
        cuerpo_correo += "<br />se informa que esta fue " + ((DropDownListAprobacion.Text == "2") ? "Aprobada" : "Rechazada");
        cuerpo_correo += "<br /><br />" + observaciones;
       

        cuerpo_correo += "</body></html>";

        string correo_para = ConfigurationSettings.AppSettings["CorreoParaAdquisiciones"];
        string correo_copia = ConfigurationSettings.AppSettings["CorreoCopiaAdquisiciones"];

        try
        {
            Correo.enviarHTML(solicitud.Correo, "Respuesta Solicitud " + solicitud.ID.ToString(), cuerpo_correo, "");
        }
        catch { }



    }
}