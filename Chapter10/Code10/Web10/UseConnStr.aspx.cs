using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UseConnStr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string sConn = ConfigurationManager.ConnectionStrings["localPubs"].ToString();
        //SqlConnection cn = new SqlConnection(sConn);
        //SqlCommand cm = new SqlCommand("select * from authors", cn);
        //GridView gv = new GridView();

        //cn.Open();
        //gv.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection);
        //gv.DataBind();
        //this.form1.Controls.Add(gv);

        string sEnvironment = ConfigurationManager.AppSettings["EnvironmentName"].ToString();
        string sConn = ConfigurationManager.ConnectionStrings[sEnvironment].ToString();
        SqlConnection cn = new SqlConnection(sConn);
        SqlCommand cm = new SqlCommand("select * from authors", cn);
        GridView gv = new GridView();

        cn.Open();
        gv.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection);
        gv.DataBind();
        this.form1.Controls.Add(gv);
    }
}

