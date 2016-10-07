using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

public partial class SimpleSub : System.Web.UI.Page 
{
    public static string GetStamp(HttpContext context)
    {
        return DateTime.Now.ToLongTimeString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRendered.Text = DateTime.Now.ToLongTimeString();
    }
}