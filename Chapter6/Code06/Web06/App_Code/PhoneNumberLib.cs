using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using NumberLib;
using System.Collections;
using System.Web.Services;

[WebService(Namespace = "http://www.IntertechTraining.com/WSDemo/PhoneNumberLib")]
public class PhoneNumberLib
{
    [WebMethod()]
    public PhoneNumber GetNumber()
    {
        return new PhoneNumber();
    }
    [WebMethod()]
    public bool SaveNumber(PhoneNumber number) { return true; }

    [WebMethod()]
    public ArrayList PhoneNumberList(string criteria) { return new ArrayList(); }

}