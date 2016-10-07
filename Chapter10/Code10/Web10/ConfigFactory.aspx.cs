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

using System.Configuration;
public partial class ConfigFactory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string EnvName =
            ConfigurationManager.AppSettings["EnvironmentName"].ToString();

        ConnectionStringSettings css =
            ConfigurationManager.ConnectionStrings[EnvName];

        DbProviderFactory factory =
            DbProviderFactories.GetFactory(css.ProviderName);
        DbConnection cn = factory.CreateConnection();
        cn.ConnectionString = css.ConnectionString;

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

        CommandBehavior.k
    }
}

