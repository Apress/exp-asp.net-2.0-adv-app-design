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

public partial class Filtering_aspx : System.Web.UI.Page
{
	private DataView GetAuthors()
	{
		DataSet ds;
		DataView dv;

		dv = (DataView)Cache["AuthorView"];

		if (dv == null)
		{
			ds = new DataSet();
			SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                ["localPubs"].ToString());

			SqlCommand cm = new
				SqlCommand("select * from authors", cn);

			new SqlDataAdapter(cm).Fill(ds);

			dv = 
				new DataView
				(ds.Tables[0], "", 
				"state", 
				DataViewRowState.CurrentRows);

			Cache.Insert("AuthorView", dv);

		}
		return dv;

	}
	protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataView dv = GetAuthors();

		dv.RowFilter = 
			string.Format("state = '{0}'", ddlState.SelectedValue);

		gvAuthors.DataSource = dv;
		gvAuthors.DataBind();

	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                ["localPubs"].ToString());

			string sql = 
			"select state from authors group by state order by state";
			SqlCommand cm = new
				SqlCommand(sql, cn);

			cn.Open();
			ddlState.DataSource = cm.ExecuteReader();
			ddlState.DataTextField = "state";
			ddlState.DataBind();
			cn.Close();
			ddlState.Items.Insert(0, "");
		}
	}
	


}
