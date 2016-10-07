using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for WebStatic
/// </summary>
public class WebStatic
{
    public static DataSet GetXmlDoc(string fileName)
    {
        HttpContext ctx = HttpContext.Current;
        DataSet ds;

        ds = (DataSet)ctx.Cache[fileName];
        if (ds == null)
        {
            ds = new DataSet();
            ds.ReadXml(fileName);
            ctx.Cache.Insert(fileName, ds, new CacheDependency(fileName));
        }
        return ds;
    }
}
