using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Configuration;
using System.Data;

public partial class FacturaElectronicaPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int id_registro = 0;
        string consecutivo = "";

        if (Request.QueryString["id"] != null)
            id_registro = PetroIMS.validarNumeroToInt(Request.QueryString["id"].ToString());

        if (Request.QueryString["consecutivo"] != null)
            consecutivo = Request.QueryString["consecutivo"].ToString();

        CreatePDFDocument(id_registro, consecutivo);
    }


    public void CreatePDFDocument(int id_registro, string consecutivo)
    {


        Liquidacion liquidacion = new Liquidacion(id_registro);
        Cuenta cuenta = new Cuenta(id_registro);
        DataTable dtContrato = Contrato.consultarPorCedula(cuenta.NumeroDocumentoBeneficiaro);
        //InformeContratista informe = new InformeContratista(cuenta.IDInforme);
        int id_entidad = cuenta.IDEntidad;
        //string rango_factura_e = DocumentoFirma.ObtenerRangoFacturaElectronica(id_entidad);



        LOG log = new LOG();
        log.IDCuenta = id_registro;
        log.consultarLOG_Liquidacion();

        PdfPTable table = new PdfPTable(3);

        //table.TotalWidth = 570f;
        //table.LockedWidth = true;
        table.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

        //BaseFont bf = BaseFont.CreateFont(
        //BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);


        Font font_col = FontFactory.GetFont("Verdana", 16f, Font.BOLD);
        font_col.Color = iTextSharp.text.BaseColor.WHITE;

        Font font_col_2 = FontFactory.GetFont("Verdana", 14f);
        font_col_2.Color = iTextSharp.text.BaseColor.BLACK;




        //PdfPCell cabecera = new PdfPCell(new Phrase("LIQUIDACION DE DEDUCCIONES", font_col));
        //cabecera.Colspan = 3;
        //cabecera.HorizontalAlignment = 1;
        //cabecera.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 0);
        //table.AddCell(cabecera);


        // add a image
        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/logo_entidad.jpg"));
        //jpg.ScaleAbsolute(159f, 209f);
        PdfPCell imageCell = new PdfPCell(jpg);
        //imageCell.Colspan = 2; // either 1 if you need to insert one cell
        imageCell.Rowspan = 4;
        imageCell.Border = 0;
        imageCell.HorizontalAlignment = Element.ALIGN_LEFT;
        imageCell.VerticalAlignment = Element.ALIGN_CENTER;
        imageCell.PaddingTop = 20f;
        imageCell.BorderWidthLeft = 0f;
        imageCell.HorizontalAlignment = 1;
        //ministerio.BorderWidthTop = 1f;
        //imageCell.BorderWidthBottom = 0f;
        //imageCell.BorderWidthBottom = 1f;
        //imageCell.BorderWidthLeft = 1f;
        //imageCell.BorderWidthTop = 1f;
        //imageCell.BorderWidthRight = 1f;



        PdfPTable table_codigo = new PdfPTable(4);


        //table.TotalWidth = 570f;
        //table.LockedWidth = true;
        table_codigo.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right


        PdfPCell titulo = new PdfPCell(new Phrase("MINISTERIO DE AMBIENTE Y DESRROLLO SOSTENIBLE", font_col_2));
        titulo.Colspan = 4;
        titulo.Border = 1;
        titulo.PaddingTop = 20f;
        titulo.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
        titulo.BorderWidthBottom = 1f;
        titulo.BorderWidthLeft = 1f;
        titulo.BorderWidthTop = 1f;
        titulo.BorderWidthRight = 1f;

        PdfPCell titulo2 = new PdfPCell(new Phrase("PROCESO GESTIÓN SUBDIRECCION ADMINISTRATIVA FINANCIERA – GRUPO CUENTAS Y CONTABILIDAD", font_col_2));
        titulo2.Colspan = 4;
        titulo2.Border = 1;
        titulo2.PaddingTop = 20f;
        titulo2.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
        titulo2.BorderWidthBottom = 1f;
        titulo2.BorderWidthLeft = 1f;
        titulo2.BorderWidthTop = 1f;
        titulo2.BorderWidthRight = 1f;

        PdfPCell titulo3 = new PdfPCell();
        titulo3.AddElement(new Phrase("                  DOCUMENTO SOPORTE EN ADQUISICIONES EFECTUADAS CON \n\t\t                                              NO OBLIGADOS A FACTURAR", font_col_2));
        titulo3.AddElement(new Phrase("                                                   (Articulo 1.6.1.4.12 Decreto 1625 de 2016)"));
        titulo3.Colspan = 4;
        titulo3.Border = 1;
        titulo3.PaddingTop = 20f;
        titulo3.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
        titulo3.BorderWidthBottom = 1f;
        titulo3.BorderWidthLeft = 1f;
        titulo3.BorderWidthTop = 1f;
        titulo3.BorderWidthRight = 1f;

        PdfPCell titulo4 = new PdfPCell(new Phrase("Código: F-A-CTR-XX", font_col_2));
        titulo4.Colspan = 2;
        titulo4.Border = 1;
        titulo4.PaddingTop = 20f;
        titulo4.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
        titulo4.BorderWidthBottom = 1f;
        titulo4.BorderWidthLeft = 1f;
        titulo4.BorderWidthTop = 1f;
        titulo4.BorderWidthRight = 1f;

        PdfPCell titulo5 = new PdfPCell(new Phrase("Versión: 01", font_col_2));
        titulo5.Colspan = 2;
        titulo5.Border = 1;
        titulo5.PaddingTop = 20f;
        titulo5.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right
        titulo5.BorderWidthBottom = 1f;
        titulo5.BorderWidthLeft = 1f;
        titulo5.BorderWidthTop = 1f;
        titulo5.BorderWidthRight = 1f;

        PdfPCell tituloT = new PdfPCell(table_codigo);
        tituloT.Colspan = 2;
        tituloT.Border = 0;
        tituloT.PaddingTop = 20f;
        tituloT.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right


        table_codigo.AddCell(titulo);
        table_codigo.AddCell(titulo2);
        table_codigo.AddCell(titulo3);
        table_codigo.AddCell(titulo4);
        table_codigo.AddCell(titulo5);




        table.AddCell(imageCell);
        table.AddCell(tituloT);




        MemoryStream MStream = new MemoryStream();
        Document document = new Document(PageSize.A2);
        try
        {
            /*
             *  <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>FECHA:</font> </strong></td><td border='1'><strong><p style='font-size:16px'>%FECHA_ELABORO%</p></strong></td>
    </tr>

            */

            string html = @"<html>
<head>
<style type='text/css'>
<!--
.Estilo2 {font-family: Arial, Helvetica, sans-serif}
.Estilo9 {font-family: Arial, Helvetica, sans-serif; font-size: 8px; font-weight: bold; }
.Estilo11 {font-size: 6px}
.Estilo12 {
	font-size: 8px;
	font-weight: bold;
}
.Estilo25 {font-size: 8px; }
.Estilo28 {font-family: Arial, Helvetica, sans-serif; font-size: 8px; font-weight: bold; }
.Estilo29 {font-family: Arial, Helvetica, sans-serif; font-size: 8px; }
-->
</style>
</head>

<body>
  <br/><br/>
  <table width='90%' border='0' >
      <tr>
        <td width='150' height='70' align='center' ><strong><p style='font-size:16px'>Fecha Documento</p></td><td width='120'></td>
        <td width='150' height='70' align='center' ><strong><p style='font-size:16px'>No Consecutivo</p></strong></td><td width='120'></td>
      </tr>
      <tr>
        <td width='150' height='70' align='center' bgcolor='#EFF8FB' ><p style='font-size:16px'>%FECHA_DOCUMENTO% </p></td><td width='120'></td>
        <td width='150' height='70' align='center' bgcolor='#EFF8FB' ><p style='font-size:16px'>%NUM_CONSECUTIVO% </p></td><td width='120'></td>
      </tr>
    </table><br/>  


<table width='90%' border='0' >

      <tr>
        <td width='150' height='70' align='left' ><p style='font-size:14px'><strong>Adquiriente</strong><br /></p>
                                                   <p style='font-size:16px'><strong> Ministerio de Ambiente y Desarrollo Sostenible</strong><br /></p>
                                                   <p style='font-size:16px'><strong> - NIT  899.999.055-4 </strong><br /></p>
                                                   <p style='font-size:12px'>Calle 37 # 8 - 40 Bogotá</p><br /><p style='font-size:12px'>Telefono (+57 601) 3323400</p></td>
                                                   
        <td bgcolor='#F2F5A9'>
            <div ><p style='font-size:10px;font-style: italic;'>
            Rangos autorizados %RANGO_FACTURA_E% <br />Vigencia desde 10 de Agosto de 2022 hasta el 09 de Agosto de 2023<br />
                    Rango de Numeración autorizada por la DIAN, mediante formulario 18764033277294 del 10 de Agosto de 2022
                </p>
            </div>
        </td>
    </tr>
   
    </table><br/>

<table width='80%' border='0'>
      <tr>
        <td border='1'><strong><p style='font-size:16px'>Proveedor y/o Contratista</font> </strong></td><td border='1' colspan='2' ><strong><p style='font-size:16px'></p></strong></td>
      </tr>
   <tr>
        <td border='1'><strong><p style='font-size:16px'>Nombre Completo y/o Razón Social:</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%TITULAR%</p></td>
    </tr>
   
   <tr>
        <td border='1'><strong><p style='font-size:16px'>ID (NIT o C.C.):</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%CEDULA%</p></td>
    </tr>
 <tr>
        <td border='1'><strong><p style='font-size:16px'>N° Contrato:</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%NUM_CONTRATO%</p></td>
    </tr>
   <tr>
        <td border='1'><strong><p style='font-size:16px'>Nº Radicado Trámite de Pago:</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%NUM_RADICADO_PAGO%</p></td>
    </tr>
    <tr>
        <td border='1'><strong><p style='font-size:16px'>Nº Pago:</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%NUM_PAGO%</p></td>
    </tr>
    <tr>
         <td border='1'><strong><p style='font-size:16px'>CODIGO DE USO PROYECTO CCP:</font> </strong></td><td border='1' colspan='2' bgcolor='#EFF8FB'><p style='font-size:16px'>%CODIGO_CCP%</p></td>
    </tr>
</table><br />
    <table width='90%' border='0' >
      <tr>
        <td width='150' height='70' align='left' ><strong><p style='font-size:16px'>Concepto del Bien o Servicio</P></strong></td>
      </tr>
     <tr>
        <td width='150' height='70' align='left' bgcolor='#EFF8FB' ><p style='font-size:14px' bgcolor='#EFF8FB'>%OBJETO%</P></td>
      </tr>
    </table><br/>

  <table width='90%' border='0' >
      <tr>
        <td width='150' height='70' align='left' ><strong><p style='font-size:16px'>Valor</p></strong></td><td width='50'></td><td width='150' height='70' align='center' ><strong><p style='font-size:16px'>Valor en letras</p></strong></td>
      </tr>
     <tr>
        <td width='150' height='70' align='left' bgcolor='#EFF8FB'><strong><p style='font-size:16px' >%TOTAL%</p></strong></td><td width='50'></td><td width='150' height='70' align='center' ><strong><p style='font-size:16px'>%VALOR_LETRAS%</p></strong></td>
      </tr>
    </table><br/>

<table width='90%' border='0' >
     
     <tr>
        <td width='150' height='70' align='left' ><strong><p style='font-size:16px' >Firma</p></strong></td><td width='50'></td><td></td>
      </tr>
    
        <tr>
        <td width='150' height='70' align='left' ><strong><p style='font-size:16px' >%FIRMANTE% <br />%CC_FIRMANTE%</p></strong></td><td width='50'></td><td><img  src='%URL_SITIO%/images/logo_entidad.jpg'></td>
      </tr>
    </table><br/>

   

     

";

            /*
             * <tr>
        <td width='150' height='70' align='left' ><img width='300' height='200' src='%URL_SITIO%/images/FirmaFacturaElectronica/%CC_FIRMANTE%.jpg'></td><td width='50'></td><td width='150' height='70' align='center' ></td>
      </tr>*/

            html = html.Replace("%RANGO_FACTURA_E%", "1 aL 10.000");

            html = html.Replace("%NOMBRE_ENTIDAD%", ConfigurationSettings.AppSettings["Entidad"]);

            html = html.Replace("%FIRMANTE%", ConfigurationSettings.AppSettings["firmante_factura_e"]);

            html = html.Replace("%CC_FIRMANTE%", ConfigurationSettings.AppSettings["cedula_firmante_factura_e"]);

            html = html.Replace("%URL_SITIO%", ConfigurationSettings.AppSettings["url_sitio"]);


            html = html.Replace("%FECHA_DOCUMENTO%", DateTime.Now.ToShortDateString());


            html = html.Replace("%NUM_CONSECUTIVO%", consecutivo);



            html = html.Replace("%TITULAR%", cuenta.NombreBeneficiario);
            html = html.Replace("%CODIGO_CCP%", cuenta.CodigoCCP);


            html = html.Replace("%CEDULA%", cuenta.NumeroDocumentoBeneficiaro);

            //html = html.Replace("%NUM_CONTRATO%", cuenta.NumeroContrato + "-" + Convert.ToDateTime(dtContrato.Rows[0]["FECHA_CONTRATO"].ToString()).Year.ToString());
            html = html.Replace("%NUM_CONTRATO%", cuenta.NumeroContrato);

            html = html.Replace("%NUM_RADICADO_PAGO%", cuenta.IDRegistro.ToString());
            html = html.Replace("%NUM_PAGO%", cuenta.NumeroPago);

            //html = html.Replace("%OBJETO%", dtContrato.Rows[0]["OBJETO"].ToString() + "<br /><br /> PERIODO PAGO: " + informe.PeriodoPagar);
            html = html.Replace("%OBJETO%", dtContrato.Rows[0]["OBJETO"].ToString());

            html = html.Replace("%TOTAL%", String.Format("{0:C}", (decimal)cuenta.ValorFactura).Replace("$ ", ""));


            NumLetra nl = new NumLetra();


            html = html.Replace("%VALOR_LETRAS%", nl.Convertir(cuenta.ValorFactura.ToString(), true).Replace("00 PESOS", " PESOS"));



            string lineas = "";

            PdfWriter writer = PdfWriter.GetInstance(document, MStream);

            writer.PageEvent = new PDFFooterFE();

            document.Open();

            document.Add(table);


            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                document.Add(E);


            document.Close();



            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=orden_pago" + ".pdf");
            HttpContext.Current.Response.BinaryWrite(MStream.GetBuffer());
            HttpContext.Current.Response.End();
        }
        catch (SqlException ex)
        {
        }



    }

}


public class PDFFooterFE : PdfPageEventHelper
{
    // write on top of document
    public override void OnOpenDocument(PdfWriter writer, Document document)
    {
        base.OnOpenDocument(writer, document);
        /*
        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        tabFot.SpacingAfter = 10F;
        PdfPCell cell;
        tabFot.TotalWidth = 300F;
        cell = new PdfPCell(new Phrase("Header"));
        tabFot.AddCell(cell);
        tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
         * */
    }

    // write on start of each page
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
    }

    // write on end of each page
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        base.OnEndPage(writer, document);
        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        PdfPCell cell, cell2, cell3;
        tabFot.TotalWidth = 530F;

        int pagina = document.PageNumber;

        BaseFont bf = BaseFont.CreateFont(
        BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        Font font_col = new Font(bf);

        font_col.Size = 12;
        //int total = document.PageCount;
        cell = new PdfPCell(new Phrase("Fecha de generación " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), font_col));
        cell.Border = 0;
        tabFot.AddCell(cell);
        //cell2 = new PdfPCell(new Phrase("PROCESO:GESTION QHS VERSION 3 (22/11/2013)"));

        tabFot.WriteSelectedRows(0, 1, 30, document.Bottom, writer.DirectContent);
    }

    //write on close of document
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        base.OnCloseDocument(writer, document);
    }
}