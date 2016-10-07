using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SetupSqlCache_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			string sql = 
				"SELECT name FROM sysdatabases ORDER BY name";
			SqlConnection cn = new SqlConnection
				(BuildConnStr("master"));
			SqlCommand cm = new SqlCommand(sql, cn);

			cn.Open();
			ddlDatabase.DataSource = cm.ExecuteReader();
			ddlDatabase.DataTextField = "name";
			ddlDatabase.DataBind();
			cn.Close();
			ddlDatabase.Items.Insert(0, "");
		}
	}
    protected void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
	{
		BindGrid();
	}

	protected void FlipBit(Object sender, EventArgs e)
	{
		CheckBox c = (CheckBox)sender;
		string sConn = BuildConnStr(ddlDatabase.SelectedValue);
		string tableName = c.Attributes["TableName"];

		if (c.Checked)
			SqlCacheDependencyAdmin.EnableTableForNotifications
				(sConn, tableName);
		else
			SqlCacheDependencyAdmin.DisableTableForNotifications
				(sConn, tableName);

       

	}

	private string BuildConnStr(string Database)
	{
		return string.Format
			("server=.;database={0};uid=sa;pwd=", Database);
	}

    protected void BindGrid()
	{
		string sql = "SELECT sysobjects.name, " +
			"sysobjects.type, case coalesce " +
			"(AspNet_SqlCacheTablesForChangeNotification.tableName ,'0') " +
			"when '0' then 'false' else 'true' end AS Configured " +
			"FROM sysobjects LEFT OUTER JOIN " +
			"AspNet_SqlCacheTablesForChangeNotification " +
			"ON sysobjects.name = " +
			"AspNet_SqlCacheTablesForChangeNotification.tableName " +
			"WHERE (sysobjects.type = 'U') " +
			"ORDER BY sysobjects.name";
		
		SqlConnection cn = new SqlConnection(
			BuildConnStr(ddlDatabase.SelectedValue));

		SqlCommand cm = new SqlCommand(sql, cn);

		try
		{
			cn.Open();
			gvTables.DataSource = cm.ExecuteReader();
			gvTables.DataBind();
			btnSave.Visible = true;
		}
		catch
		{
			gvTables.Visible = false;
			btnSave.Visible = false;
			Button1.Visible = true;
		}
		finally
		{
			cn.Close();
		}
	}

    protected void Button1_Click(object sender, EventArgs e)
	{
		string sConn = BuildConnStr(ddlDatabase.SelectedValue);
		SqlCacheDependencyAdmin.EnableNotifications(sConn);
		Button1.Visible = false;
		gvTables.Visible = true;
		btnSave.Visible = true;
		BindGrid();
	}
    protected void btnSave_Click(object sender, EventArgs e)
	{
		BindGrid();
	}


}
