<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="estilo.css" type="text/css"/>
    <title>.::Petrominerales::.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div>
                <div>
                    <table style="width: 664px; height: 1px" align="center">
                        <tr>
                            <td style="height: 109px; background-color: #efefef">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 28px; background-color: #f37622">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 4px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 98px">
                                <center>
                                    Su sesion ha terminado exitosamente</center>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px">
                                <center>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ir al inicio" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 36px">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
