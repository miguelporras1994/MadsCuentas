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



public partial class LiquidacionPDF : System.Web.UI.Page
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

        MemoryStream MStream = new MemoryStream();
        Document document = new Document(PageSize.A2);

       

        

        try
        {


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
<table width='100%' border='0'>
      <tr>
        <td width='150' height='70' bgcolor='green' align='center'><strong><p style='font-size:12px'><font color='white'>%NOMBRE_ENTIDAD%</font></p></strong></td>
      </tr>
      <tr>
        <td width='150' height='70' align='center'></td>
      </tr>
      <tr>
        <td width='150' height='70' align='center' ><strong>LIQUIDACION</strong><BR/> %TITULAR%</td>
      </tr>
    </table><br/>

    <table width='100%' border='0'>
      <tr>
        <td></td> <td></td><td></td><td></td><td border='1' bgcolor='#C0C0C0'><strong>RADICACION: </strong></td><td border='1'><strong>%RADICACION%</strong></td><td></td> <td></td> 
      </tr>
      <tr>
        <td></td> <td></td><td></td><td></td><td border='1' bgcolor='#C0C0C0'><strong>CUENTA POR PAGAR: </strong></td><td border='1'><strong>%CTA_POR_PAGAR%</strong></td><td></td> <td></td> 
      </tr>
     <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>
      
      <tr>
        <td></td><td></td><td></td><td></td><td border='1' bgcolor='#C0C0C0'>ICA</td><td border='1'>%ICA%</td> <td></td> <td></td>
      </tr>
      
      <tr>
        <td><strong>Detalle</strong></td><td></td><td></td><td></td><td></td><td></td> <td></td> <td></td>
      </tr>

      <tr >
        <td border='1' bgcolor='#C0C0C0'><strong>VALOR TOTAL</strong></td><td border='1'>%VALOR_TOTAL%</td><td border='1' bgcolor='#C0C0C0'>IBC</td><td td border='1'>%VALOR_IBC%</td><td></td> <td></td> <td></td> <td></td>
      </tr>
  <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

      <tr border='1'>
        <td bgcolor='#C0C0C0'>SALUD</td><td>%VALOR_SALUD%</td><td bgcolor='#C0C0C0'>PENSION</td><td>%VALOR_PENSION%</td><td bgcolor='#C0C0C0'>ARL</td> <td>%VALOR_ARL%</td> <td bgcolor='#C0C0C0'>AFC:</td> <td>%VALOR_AFC%</td>
      </tr>

   <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

     <tr border='1'>
        <td bgcolor='#C0C0C0'>INTERESES VIVIENDA</td><td>%INT_VIVIENDA%</td><td bgcolor='#C0C0C0'>PREPAGADA</td><td>%VALOR_PREPAGADA%</td><td bgcolor='#C0C0C0'>DEPENDIENTES</td> <td>%VALOR_DEPENDIENTES%</td> <td  bgcolor='#C0C0C0'>RENTA EXENTA</td> <td>%VALOR_RENTA_EXENTA%</td>
      </tr>

    <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

      <tr >
        <td border='1' bgcolor='#C0C0C0'>BASE GRAVABLE RTE FTE.</td><td border='1'>%VALOR_RTE_FTE_383%</td><td border='1' bgcolor='#C0C0C0'>RTE FTE EN UVT</td><td border='1'>%VALOR_RTE_FTE_UVT_383%</td><td border='1' bgcolor='#C0C0C0'>VALOR RTE FTE.</td> <td border='1'>%VALOR_COBRAR_RTE_FTE_383%</td> <td></td> <td></td>
      </tr>

    <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

     <tr>
        <td border='1' bgcolor='#C0C0C0'>BASE GRAVABLE ICA</td><td border='1' >%BASE_RTE_ICA%</td><td border='1' bgcolor='#C0C0C0'>VALOR ICA</td><td border='1'>%VALOR_ICA%</td><td border='1' bgcolor='#C0C0C0'></td> <td border='1'></td> <td></td> <td></td>
      </tr>
    <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

     <tr>
        <td>&nbsp;</td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>
      </tr>

     <tr border='1'>
        <td bgcolor='#C0C0C0'>BASE GRAVABLE IVA</td><td>%VALOR_BASE_IVA%</td><td bgcolor='#C0C0C0'>VALOR IVA</td><td>%VALOR_IVA%</td><td bgcolor='#C0C0C0'>VALOR A PAGAR</td> <td>%VALOR_PAGAR_383%</td> <td border='0'></td> <td border='0'></td>
      </tr>
      
    </table><BR /><BR />
  
";
            
            html = html.Replace("%RADICACION%", id_registro.ToString());

            if (liquidacion.ValorTotal == 0)
            {
                html = html.Replace("%CTA_POR_PAGAR%", "SIN LIQUIDACION");
            }
            else
            {
                html = html.Replace("%CTA_POR_PAGAR%", cuenta.CuentaPorPagar);
            }
            
            html = html.Replace("%TITULAR%", cuenta.NombreBeneficiario + " - " + cuenta.NumeroDocumentoBeneficiaro);

            html = html.Replace("%ICA%", String.Format("{0:C}", (decimal)liquidacion.ValorFactorReteICA).Replace("$ ", ""));
            html = html.Replace("%VALOR_TOTAL%", String.Format("{0:C}", (decimal)liquidacion.ValorTotal).Replace("$ ", ""));
            
            html = html.Replace("%VALOR_IBC%", String.Format("{0:C}", (decimal)liquidacion.ValorIBC).Replace("$ ", ""));

            html = html.Replace("%VALOR_SALUD%", String.Format("{0:C}", (decimal)liquidacion.ValorSalud).Replace("$ ", ""));
            html = html.Replace("%VALOR_PENSION%", String.Format("{0:C}", (decimal)liquidacion.ValorPension).Replace("$ ", ""));
            html = html.Replace("%VALOR_ARL%", String.Format("{0:C}", (decimal)liquidacion.ValorARL).Replace("$ ", ""));
            html = html.Replace("%VALOR_AFC%", String.Format("{0:C}", (decimal)liquidacion.ValorAFC).Replace("$ ", ""));

            html = html.Replace("%INT_VIVIENDA%", String.Format("{0:C}", (decimal)liquidacion.ValorIntVivienda).Replace("$ ", ""));
            html = html.Replace("%VALOR_PREPAGADA%", String.Format("{0:C}", (decimal)liquidacion.ValorPrepagada).Replace("$ ", ""));
            html = html.Replace("%VALOR_DEPENDIENTES%", String.Format("{0:C}", (decimal)liquidacion.ValorDependientes).Replace("$ ", ""));
            html = html.Replace("%VALOR_RENTA_EXENTA%", String.Format("{0:C}", (decimal)liquidacion.ValorRentaExenta).Replace("$ ", ""));

            html = html.Replace("%VALOR_RTE_FTE_383%", String.Format("{0:C}", (decimal)liquidacion.ValorBaseGravableRetefuente383).Replace("$ ", ""));
            html = html.Replace("%VALOR_RTE_FTE_UVT_383%", String.Format("{0:C}", (decimal)liquidacion.ValorRetefuenteUVT383).Replace("$ ", ""));
            html = html.Replace("%VALOR_COBRAR_RTE_FTE_383%", String.Format("{0:C}", (decimal)liquidacion.ValorRFArt383).Replace("$ ", ""));


            html = html.Replace("%BASE_RTE_ICA%", String.Format("{0:C}", (decimal)liquidacion.ValorBaseReteICA383).Replace("$ ", ""));
            html = html.Replace("%VALOR_RTE_FTE_UVT_384%", String.Format("{0:C}", (decimal)liquidacion.ValorRetefuenteUVT384).Replace("$ ", ""));
            html = html.Replace("%VALOR_COBRAR_RTE_FTE_384%", String.Format("{0:C}", (decimal)liquidacion.ValorRetefuenteUVT384).Replace("$ ", ""));

            html = html.Replace("%VALOR_ICA%", String.Format("{0:C}", (decimal)liquidacion.ValorICA).Replace("$ ", ""));
            html = html.Replace("%VALOR_BASE_IVA%", String.Format("{0:C}", (decimal)liquidacion.ValorBaseReteIVA).Replace("$ ", ""));
            html = html.Replace("%VALOR_RETE_IVA%", String.Format("{0:C}", (decimal)liquidacion.ValorReteIVA).Replace("$ ", ""));
            html = html.Replace("%VALOR_IVA%", String.Format("{0:C}", (decimal)cuenta.ValorIVA).Replace("$ ", ""));
            html = html.Replace("%VALOR_PAGAR_383%", String.Format("{0:C}", (decimal)liquidacion.ValorTotalPagar383).Replace("$ ", ""));
            html = html.Replace("%VALOR_PAGAR_384%", String.Format("{0:C}", (decimal)liquidacion.ValorRFArt384).Replace("$ ", ""));

            html = html.Replace("%NOMBRE_ENTIDAD%", ConfigurationSettings.AppSettings["Entidad"]);

            
            //html = html.Replace("%fecha%", ma.Fecha.ToString("dd/MM/yyyy"));
            //html = html.Replace("%fecha%", ma.FechaString).Replace("0:00:00", "");


            //html = html.Replace("%referencia%", ma.Referencia);
            //html = html.Replace("%tipo_movimiento%", Utiles.obtenerNombreItem("tipo_movimiento_almacen", "id_tipo", ma.IDConcepto.ToString()));



            string lineas = "";


            //html = html.Replace("%tabla_items%", lineas);

            /*
            html = html.Replace("%empresa%", PetroIMS.obtenerNombreItem("empresa", "id_empresa", pc.id_empresa.ToString()));
            html = html.Replace("%bloque%", PetroIMS.obtenerNombreItem("bloque", "id_bloque", pc.id_bloque.ToString()));
            html = html.Replace("%pozo%", PetroIMS.obtenerNombreItem("pozo", "id_pozo", pc.id_pozo.ToString()));
            html = html.Replace("%lugar%", pc.lugar);
            html = html.Replace("%actividad%", pc.actividad);
            html = html.Replace("%equipo%", pc.equipo_intervenir);
           */



            PdfWriter writer = PdfWriter.GetInstance(document, MStream);

            writer.PageEvent = new PDFFooterM();

            document.Open();

            


            //Imagen cabecera

            //PdfPTable table = new PdfPTable(3);
            // string cuerpo_pdf = "";
            //PCaliente pc = new PCaliente(id_permiso);


            PdfPTable tabla_cabecera = new PdfPTable(1);

            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("images/Logo.jpg"));
            //iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("uploaded_images/" + imagen));
            //logo.ScaleToFit(50, 50);
            //tabla_cabecera.AddCell(logo);

            Paragraph paragraphTable1 = new Paragraph();
            paragraphTable1.SpacingAfter = 15f;

            document.Add(paragraphTable1);

           
            //tabla_cabecera.AddCell(new Paragraph("Comprobante de Resguardo", FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)));
            //tabla_cabecera.AddCell(new Paragraph(pc.ID, FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)));

            //tabla_cabecera.se

            //document.Add(tabla_cabecera);

            //png.ScaleAbsolute(530, 100);
            // png.SetAbsolutePosition(2,2);
            //document.Add(png);


            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                document.Add(E);

            tabla_cabecera.TotalWidth = 200;

            //document.Add(tabla_cabecera);

            document.Close();



            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=liquidacion" + ".pdf");
            HttpContext.Current.Response.BinaryWrite(MStream.GetBuffer());
            HttpContext.Current.Response.End();
        }
        catch (SqlException ex)
        {
        }



    }

}


public class PDFFooterM : PdfPageEventHelper
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

        font_col.Size = 6;
        //int total = document.PageCount;
        cell = new PdfPCell(new Phrase("Fecha de generación " + DateTime.Now.ToShortDateString() + "                                                                                                        Pagina " + pagina + " de 1", font_col));

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