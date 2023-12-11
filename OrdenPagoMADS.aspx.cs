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




public partial class OrdenPagoMADS : System.Web.UI.Page
{

   

    protected void Page_Load(object sender, EventArgs e)
    {

        int id_registro = 0;

        if (Request.QueryString["id"] != null)
            id_registro = PetroIMS.validarNumeroToInt(Request.QueryString["id"].ToString());
        else
            Response.Redirect("Formularios.aspx");

        CreatePDFDocument(id_registro);
    }


    public void CreatePDFDocument(int id_registro)
    {



        Liquidacion liquidacion = new Liquidacion(id_registro);
        Cuenta cuenta = new Cuenta(id_registro);
        LOG log = new LOG();
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


        PdfPCell cabecera = new PdfPCell(new Phrase("LIQUIDACION DE DEDUCCIONES", font_col));
        cabecera.Colspan = 3;
        cabecera.HorizontalAlignment = 1;
        cabecera.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 0);
        table.AddCell(cabecera);



        PdfPCell ministerio = new PdfPCell(new Phrase("MINISTERIO DE AMBIENTE Y DESARROLLO SOSTENIBLE", font_col_2));
        //points.Colspan = 2;
        ministerio.Border = 1;
        ministerio.PaddingTop = 20f;
        //points.PaddingTop = 40f;
        ministerio.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

        //ministerio.BorderWidthBottom = 1f;
        ministerio.BorderWidthLeft = 1f;
        //ministerio.BorderWidthTop = 1f;
        ministerio.BorderWidthRight = 1f;

        PdfPCell centro = new PdfPCell(new Phrase("Proceso: Gestión Financiera", font_col_2));
        //points.Colspan = 2;
        centro.Border = 1;
        centro.PaddingTop = 20f;
        centro.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

        //centro.BorderWidthBottom = 1f;
        //centro.BorderWidthLeft = 1f;
        //centro.BorderWidthTop = 1f;
        centro.BorderWidthRight = 1f;

        // add a image
        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/madsig.jpg"));
        PdfPCell imageCell = new PdfPCell(jpg);
        imageCell.Colspan = 2; // either 1 if you need to insert one cell
        imageCell.Border = 1;
        imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
        imageCell.VerticalAlignment = Element.ALIGN_CENTER;
        imageCell.PaddingTop = 10f;

        //imageCell.BorderWidthBottom = 1f;
        //imageCell.BorderWidthLeft = 1f;
        //imageCell.BorderWidthTop = 1f;
        imageCell.BorderWidthRight = 1f;

        table.AddCell(ministerio);
        table.AddCell(centro);
        table.AddCell(imageCell);

        PdfPCell subtitulo1 = new PdfPCell(new Phrase("Versión:1"));
        //points.Colspan = 2;
        subtitulo1.Border = 0;
        subtitulo1.PaddingTop = 10f;
        subtitulo1.PaddingBottom = 8f;
        //points.PaddingTop = 40f;
        subtitulo1.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

        subtitulo1.BorderWidthBottom = 1f;
        subtitulo1.BorderWidthLeft = 1f;
        //subtitulo1.BorderWidthTop = 1f;
        subtitulo1.BorderWidthRight = 1f;

        PdfPCell subtitulo2 = new PdfPCell(new Phrase("Vigencia: 17/12/2015"));
        //points.Colspan = 2;
        subtitulo2.Border = 0;
        subtitulo2.PaddingTop = 10f;
        subtitulo2.PaddingBottom = 8f;
        //points.PaddingTop = 40f;
        subtitulo2.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

        subtitulo2.BorderWidthBottom = 1f;
        //subtitulo2.BorderWidthLeft = 1f;
        //subtitulo1.BorderWidthTop = 1f;
        subtitulo2.BorderWidthRight = 1f;

        PdfPCell subtitulo3 = new PdfPCell(new Phrase("Código: F-A-GFI-09"));
        //points.Colspan = 2;
        subtitulo3.Border = 0;
        subtitulo3.PaddingTop = 10f;
        subtitulo3.PaddingBottom = 8f;
        //points.PaddingTop = 40f;
        subtitulo3.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

        subtitulo3.BorderWidthBottom = 1f;
        //subtitulo2.BorderWidthLeft = 1f;
        //subtitulo1.BorderWidthTop = 1f;
        subtitulo3.BorderWidthRight = 1f;

        table.AddCell(subtitulo1);
        table.AddCell(subtitulo2);
        table.AddCell(subtitulo3);


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
<table width='90%' border='0' >

      <tr>
        <td width='150' height='70' align='center' ><strong></strong><p style='font-size:16px'>%TITULAR%</font></td>
      </tr>
      <tr>
        <td width='150' height='70' align='left' ><strong></strong><p style='font-size:16px'>%DEPENDENCIA%</font></td>
      </tr>
    </table><br/>

    <table width='80%' border='0'>
      <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>CUENTA POR PAGAR:</font> </strong></td><td border='1'><strong><p style='font-size:16px'>%CTA_POR_PAGAR%</p></strong></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>OBLIGACION:</font> </strong></td><td border='1'><strong><p style='font-size:16px'>%OBLIGACION%</p></strong></td>
      </tr>
    <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>RADICADO No:</font> </strong></td><td border='1'><strong><p style='font-size:16px'>%NO_RADICADO%</p></strong></td>
      </tr>
   
   <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>RP:</font> </strong></td><td border='1'><strong><p style='font-size:16px'>%RP%</p></strong></td>
    </tr>
  
     <tr>
        <td>&nbsp;</td><td></td><td></td><td></td><td></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td border='1'><p style='font-size:16px'>SUBTOTAL</font></td><td border='1' align='right'><p style='font-size:16px'>%SUBTOTAL%</font></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td border='1'><p style='font-size:16px'>VALOR IVA</font></td><td border='1' align='right'><p style='font-size:16px'>%VALOR_IVA%</font></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td border='1'><strong><p style='font-size:16px'>TOTAL</font></strong></td><td border='1' align='right'><strong><p style='font-size:16px'>%TOTAL%</font></strong></td>
      </tr>

      <tr>
        <td><strong><p style='font-size:16px'>Menos Deducciones</font></strong></td><td><p style='font-size:16px'>%ARTICULO_APLICADO%</font></td><td></td><td></td><td></td>
      </tr>
      <tr border='1'>
        <td ><p style='font-size:16px'>Base:</font></td><td><p style='font-size:16px'>%BASE_GRAVABLE_RETE_ICA%</font></td><td><p style='font-size:16px'>Rete ICA</font></td><td><p style='font-size:16px'>%FAC_RETE_ICA%</font></td><td align='right'><p style='font-size:16px'>%RETE_ICA%</font></td>
      </tr>
      <tr border='1'>
        <td><p style='font-size:16px'>Base:</font></td><td><p style='font-size:16px'>%BASE_GRAVABLE_RF%</p></td><td><p style='font-size:16px'>Rete Fuente</p></td><td><p style='font-size:16px'>%FAC_RETE_FUENTE%</p></td><td align='right'><p style='font-size:16px'>%RETE_FUENTE%</font></td>
      </tr>
     <tr border='1'>
        <td><p style='font-size:16px'>Base:</p></td><td><p style='font-size:16px'>%BASE_RETE_IVA%</p></td><td><p style='font-size:16px'>Rete IVA</p></td><td><p style='font-size:16px'>%FAC_RETE_IVA%</font></td><td align='right'><p style='font-size:16px'>%RETE_IVA%</font></td>
      </tr>
     <tr>
        <td colspan='3' border='1'><p style='font-size:16px'>%DETALLE_OTROS_DESCUENTOS%</P></td><td><p style='font-size:16px'>Valor Otros Descuentos</font></td><td border='1' align='right'><strong><p style='font-size:16px'>%VALOR_OTROS_DESCUENTOS%</p></strong></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td><strong><p style='font-size:16px'>Total Deducciones</font></strong></td><td border='1' align='right'><strong><p style='font-size:16px'>%DEDUCCIONES%</p></strong></td>
      </tr>
      <tr>
        <td></td><td></td><td></td><td><strong><p style='font-size:16px'>Valor a Pagar</font></strong></td><td border='1' align='right'><strong><p style='font-size:16px'>%VALOR_PAGAR%</p></strong></td>
      </tr>
      <tr border='1'>
        <td colspan='5' bgcolor='#C0C0C0'><strong><p style='font-size:16px'>%VALOR_LETRAS%</p></strong></td>
      </tr>
      <tr border='1'>
        <td colspan='5'><p style='font-size:16px'>%DESCRIPCION_NOTA%</p></td>
      </tr> 
      <tr border='1'>
        <td colspan='5'><p style='font-size:16px'>%OBJETO%</p></td>
      </tr>
    </table>

";

            //Verificar si el pago se realiza por art 383 o 384
            string articulo = "";
            double RF383 = liquidacion.ValorRFArt383;
            double RF384 = liquidacion.ValorRFArt384;
            double ValorReteFuenteAplicado = 0;
            double ValorTotalPagar = 0;

            if (liquidacion.Metodo == "383")
            {

                ValorReteFuenteAplicado = RF383;
                ValorTotalPagar = liquidacion.ValorTotalPagar383;
                articulo = "Art. 383";
            }
            else if (liquidacion.Metodo == "384")
            {
                ValorReteFuenteAplicado = RF384;
                ValorTotalPagar = liquidacion.ValorTotalPagar384;
                articulo = "Art. 384";

            }
            else
            {

                //Si no se selecciono ninguno se selecciona Auto que toma la mayor retencion
                if (RF383 >= RF384)
                {
                    ValorReteFuenteAplicado = RF383;
                    ValorTotalPagar = liquidacion.ValorTotalPagar383;
                    articulo = "Art. 383";
                }
                else
                {
                    ValorReteFuenteAplicado = RF384;
                    ValorTotalPagar = liquidacion.ValorTotalPagar384;
                    articulo = "Art. 384";
                }
            }

            double valor_base_rte_ica = 0;

            valor_base_rte_ica = (liquidacion.ValorBaseReteICA383 == 0) ? ConfiguracionLiquidacion.CalcularBaseGravableReteICA(cuenta.ValorFactura, liquidacion.ValorSalud, liquidacion.ValorPension, liquidacion.ValorARL) : liquidacion.ValorBaseReteICA383;

            if(cuenta.CuentaSinRetenciones == 1)
            {
                valor_base_rte_ica = 0;
            }

            html = html.Replace("%NOMBRE_ENTIDAD%", ConfigurationSettings.AppSettings["Entidad"]);

            html = html.Replace("%CTA_POR_PAGAR%", cuenta.CuentaPorPagar);
            html = html.Replace("%OBLIGACION%", cuenta.NumeroObligacion);
            html = html.Replace("%NO_RADICADO%", cuenta.IDRegistro.ToString());
            
            html = html.Replace("%FECHA_ELABORO%", log.Fecha.ToShortDateString());
            html = html.Replace("%RP%", cuenta.NumeroRP);
           
            html = html.Replace("%FECHA_ELABORO%", log.Fecha.ToShortDateString());

            html = html.Replace("%TITULAR%", cuenta.NombreBeneficiario + " - " + cuenta.NumeroDocumentoBeneficiaro);
            html = html.Replace("%DEPENDENCIA%", Utiles.obtenerNombreItemUlises("AREAS", "DESCRIPCION", "ID_AREA", cuenta.IDDependencia.ToString(), true));
            
            html = html.Replace("%SUBTOTAL%", String.Format("{0:C}", (decimal)cuenta.ValorFactura).Replace("$ ", ""));
            html = html.Replace("%VALOR_IVA%", String.Format("{0:C}", (decimal)cuenta.ValorIVA).Replace("$ ", ""));
            double total = cuenta.ValorFactura + cuenta.ValorIVA;
            html = html.Replace("%TOTAL%", String.Format("{0:C}", (decimal)total).Replace("$ ", ""));

            html = html.Replace("%RETE_ICA%", String.Format("{0:C}", (decimal)liquidacion.ValorICA).Replace("$ ", ""));
            html = html.Replace("%RETE_FUENTE%", String.Format("{0:C}", (decimal)ValorReteFuenteAplicado).Replace("$ ", ""));
            html = html.Replace("%RETE_IVA%", String.Format("{0:C}", (decimal)liquidacion.ValorReteIVA).Replace("$ ", ""));

            html = html.Replace("%BASE_RETE_IVA%", (liquidacion.ValorBaseReteIVA != 0) ? String.Format("{0:C}", (decimal)liquidacion.ValorBaseReteIVA).Replace("$ ", "") : "");

            html = html.Replace("%FAC_RETE_IVA%", (liquidacion.ValorFactorReteIVA != 0) ? liquidacion.ValorFactorReteIVA.ToString() : "");
            html = html.Replace("%FAC_RETE_ICA%", (liquidacion.ValorFactorReteICA != 0) ? liquidacion.ValorFactorReteICA.ToString() : "");
            html = html.Replace("%FAC_RETE_FUENTE%", (liquidacion.ValorFactorReteFuente != 0) ? liquidacion.ValorFactorReteFuente.ToString() : "");

            double total_deducciones = liquidacion.ValorICA + ValorReteFuenteAplicado + liquidacion.ValorReteIVA + liquidacion.ValorOtrosDescuentos;

            html = html.Replace("%DEDUCCIONES%", String.Format("{0:C}", (decimal)total_deducciones).Replace("$ ", ""));
            html = html.Replace("%VALOR_PAGAR%", String.Format("{0:C}", (decimal)ValorTotalPagar).Replace("$ ", ""));
            html = html.Replace("%BASE_GRAVABLE_RF%", String.Format("{0:C}", (decimal)liquidacion.ValorBaseGravableRetefuente383).Replace("$ ", ""));
            html = html.Replace("%BASE_GRAVABLE_RETE_ICA%", String.Format("{0:C}", (decimal)valor_base_rte_ica).Replace("$ ", ""));
            html = html.Replace("%VALOR_OTROS_DESCUENTOS%", String.Format("{0:C}", (decimal)liquidacion.ValorOtrosDescuentos).Replace("$ ", ""));
            html = html.Replace("%DETALLE_OTROS_DESCUENTOS%", liquidacion.DescripcionOtrosDescuentos);

            NumLetra nl = new NumLetra();

            
            html = html.Replace("%VALOR_LETRAS%", nl.Convertir(ValorTotalPagar.ToString(),true));
            html = html.Replace("%ARTICULO_APLICADO%", articulo);
            html = html.Replace("%DESCRIPCION_NOTA%", (liquidacion.Nota.Trim() != "") ? "NOTA: " + liquidacion.Nota : "");
            html = html.Replace("%OBJETO%", (cuenta.obtenerObjetoRP().Trim() != "") ? "OBJETO: " +  HttpUtility.HtmlDecode(  cuenta.obtenerObjetoRP().Trim()) : "");
           

            string lineas = "";

            PdfWriter writer = PdfWriter.GetInstance(document, MStream);

            writer.PageEvent = new PDFFooterOP();

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


public class PDFFooterOP : PdfPageEventHelper
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