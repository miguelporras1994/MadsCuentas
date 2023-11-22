<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtenderSolicitudCertificado.aspx.cs" Inherits="AtenderSolicitudCertificado" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="estilo.css" rel="stylesheet" type="text/css" />

    <link href="calendario.css" rel="stylesheet" type="text/css" />


     <script src='js/jquery1.4.4.js' type='text/javascript'></script>
    
            <style type="text/css">
                .modalPopup
                {
                background-color: #696969;
                filter: alpha(opacity=40);
                opacity: 0.7;
                xindex:-1;
                }
                .auto-style1 {
                    height: 18px;
                }
                .auto-style2 {
                    text-align: left;
                }
            </style>


    <br /><br /><br /><br /><br />

 <div align="center">



    <br />
    <br />
    <br />
    <br />

            <asp:FileUpload ID="fileUploadImage" runat="server"></asp:FileUpload>
            <asp:Button ID="btnUpload" runat="server" Text="Adjuntar Certificado" OnClick="btnUpload_Click" />
        <br />
        <br />
     <table><tr><td class="auto-style2" bgcolor="#c0c0c0" >


                En caso de no poder realizar el envio del certificado por favor especificar el motivo.
                <br />
                Se enviara un correo al solicitante explicando las razones.</td><td>


                &nbsp;</td></tr><tr><td>


                <asp:TextBox ID="TextBoxObservaciones" runat="server" Height="43px" TextMode="MultiLine" Width="269px"></asp:TextBox>
                <asp:Button ID="ButtonGuardar" runat="server" Text="Enviar" OnClick="ButtonGuardar_Click" />
                </td><td>


                 &nbsp;</td></tr></table>
     <table style="width: 33%;">
         <tr>
             <td colspan="2" style="background-color: lightblue;text-align:center;">Datos de la solicitud</td>
            
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>Fecha solicitud:</td>
             <td>
                 <asp:Label ID="LabelFecha" runat="server"></asp:Label>
             </td>
         </tr>
         <tr>
             <td>Cedula:</td>
             <td>
                 <asp:Label ID="LabelCedula" runat="server"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style1">Correo:</td>
             <td class="auto-style1">
                 <asp:Label ID="LabelCorreo" runat="server"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style1">Año:</td>
             <td class="auto-style1">
                 <asp:Label ID="LabelAno" runat="server"></asp:Label>
             </td>
         </tr>
     </table>
        <table border="0">
            <tr>
                <td>
                            &nbsp;</td>
            </tr>

        </table>





     </div>
    <br /><br /><br /><br /><br />

</asp:Content>
