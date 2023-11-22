using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

/// <summary>
/// Descripción breve de XmlSanitizedString
/// </summary>
public class XmlSanitizedString
{
    private readonly string value;

    public XmlSanitizedString(string s)
    {
        this.value = XmlSanitizedString.SanitizeXmlString(s);
    }

    /// <summary>
    /// Get the XML-santizied string.
    /// </summary>
    public override string ToString()
    {
        return this.value;
    }

    /// <summary>
    /// Remove illegal XML characters from a string.
    /// </summary>
    private static string SanitizeXmlString(string xml)
    {
        if (string.IsNullOrEmpty(xml))
        {
            return xml;
        }

        var buffer = new StringBuilder(xml.Length);

        foreach (char c in xml)
        {
            if (XmlSanitizedString.IsLegalXmlChar(c))
            {
                buffer.Append(c);
            }
        }

        return buffer.ToString();
    }

    /// <summary>
    /// Whether a given character is allowed by XML 1.0.
    /// </summary>
    private static bool IsLegalXmlChar(int character)
    {
        return
        (
             character == 0x9 /* == '\t' == 9   */        ||
             character == 0xA /* == '\n' == 10  */        ||
             character == 0xD /* == '\r' == 13  */        ||
            (character >= 0x20 && character <= 0xD7FF) ||
            (character >= 0xE000 && character <= 0xFFFD) ||
            (character >= 0x10000 && character <= 0x10FFFF)
        );
    }

}
