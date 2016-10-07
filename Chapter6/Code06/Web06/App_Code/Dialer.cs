using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using NumberLib;

/// <summary>
/// Summary description for Dialer.
/// </summary>
[WebServiceBinding()]
[WebService(Namespace = "http://www.IntertechTraining.com/WSDemo/Dialer")]
public class Dialer : System.Web.Services.WebService 
{
    [WebMethod]
    public bool SendSMS(PhoneNumber Number, string Message)
    {

        return true;
    }

    
}

