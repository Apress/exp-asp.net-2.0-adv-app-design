using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MyImpl
/// </summary>
public class MyImpl : HttpAppReuse.GenericAbstractHttpApp
{
    public static string SomeStaic = "This is a static variable";

    public static DataSet StateList;

    static MyImpl()
    {
        StateList = new DataSet();
        StateList.ReadXml("http://www.Domware.com/StateList.xml");
    }

    public MyImpl()
    {
        this.PreRequestHandlerExecute += new
            EventHandler(MyImpl_PreRequestHandlerExecute);
    }

    void Application_OnBeginRequest(object sender, EventArgs e)
    {
        Response.Write("Entering BeginRequest<BR>");
    }

    void MyImpl_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        Response.Write("Entering PreRequestHandlerExecute<BR>");
    }

    public override bool RequiresSSL
    {
        get { return false; }
    }

}

