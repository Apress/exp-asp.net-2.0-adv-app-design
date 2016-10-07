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

public partial class DatasetIE_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ddlPub.DataSource = GetSourceData().Tables["Publishers"];
			ddlPub.DataTextField = "pub_name";
			ddlPub.DataValueField = "pub_id";
			ddlPub.DataBind();
			ddlPub.Items.Insert(0, "");
		}
	}

	private DataSet GetSourceData()
	{
		DataSet ds;

		ds = (DataSet)Cache["Pub_Title"];

		if (ds == null)
		{
			ds = new DataSet();
			SqlConnection cn = new 
				SqlConnection(ConfigurationManager.ConnectionStrings
				["localPubs"].ToString());

			SqlCommand cm = new 
				SqlCommand
				("select * from publishers select * from titles", cn);

			SqlDataAdapter da = new SqlDataAdapter(cm);

			da.Fill(ds);

			ds.Tables[0].TableName = "Publishers";
			ds.Tables[1].TableName = "Titles";

			ds.Relations.Add(
				new DataRelation(
				"Pub_Title",
				ds.Tables["Publishers"].Columns["pub_id"],
				ds.Tables["Titles"].Columns["pub_id"]));

			ds.Tables["Publishers"].Columns.Add(
				new DataColumn(
					"AveragePrice",
					typeof(double), 
					"Avg(Child(pub_title).price)"));

			Cache["Pub_Title"] = ds;			

		}
		return ds;
	}

	protected void ddlPub_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataView dv = new DataView(
			GetSourceData().Tables["Publishers"], 
			string.Format("pub_id = '{0}'", 
			ddlPub.SelectedValue), "", 
			DataViewRowState.CurrentRows);

		if (dv.Count > 0)
		{
			if (dv[0]["AveragePrice"] != DBNull.Value)
				lblAvgPrice.Text = 
					Convert.ToDouble(dv[0]["AveragePrice"]).ToString("C");
			
			gvTitle.DataSource = dv[0].CreateChildView("Pub_Title");
			gvTitle.DataBind();
		}
	}



}
