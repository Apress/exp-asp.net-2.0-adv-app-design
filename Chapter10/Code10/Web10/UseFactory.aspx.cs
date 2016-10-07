using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UseFactory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DbProviderFactory factory = 
            DbProviderFactories.GetFactory("System.Data.SqlClient");
        DbConnection cn = factory.CreateConnection();
        cn.ConnectionString =
            ConfigurationManager.ConnectionStrings
            ["localPubs"].ToString();
        

        DbCommand cm = factory.CreateCommand();
        cm.Connection = cn;
        cm.CommandText = "select * from authors where [state] = @state";
        DbParameter pm = factory.CreateParameter();            
        pm.ParameterName = "@state";
        pm.Value = "CA";
        cm.Parameters.Add(pm);

        GridView gv = new GridView();
        cn.Open();
        gv.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection);
        gv.DataBind();
        form1.Controls.Add(gv);       
    }
}
