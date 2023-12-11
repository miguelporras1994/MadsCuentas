<%@ Page language="c#" Inherits="WebFrmSeg"  AutoEventWireup="true" CodeFile="Login.aspx.cs" Title= ".::MADS::." %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.::MADS::.</title>
     <link href="estilo.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 87px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="css/structure.css">
</head>

<body>

    <form id="form1" class="box login" runat="server">

        <fieldset class="boxBody">
            <asp:TextBox ID="txtDomain" Visible = "False" Runat="server"  Enabled="false">minambiente.gov.co</asp:TextBox>
	  <label>Usuario:</label>
	  
            <asp:TextBox ID="txtUsername" Runat="server" placeholder="Usuario" ></asp:TextBox></asp:TextBox>
	  <label>Clave:</label>
	  <asp:TextBox ID="txtPassword" Runat="server" TextMode="Password"></asp:TextBox>
	</fieldset>
	<footer>
	  
	  
        <asp:Button ID="btnLogin" Runat="server" class="btnLogin" Text="Ingresar" OnClick="Login_Click"></asp:Button>
	</footer>


   
    </form>
</body>
</html>
