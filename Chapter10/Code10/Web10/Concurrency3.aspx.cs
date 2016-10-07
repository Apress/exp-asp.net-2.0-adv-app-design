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

public partial class Concurrency3_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack) BindList();

	}

	private void BindList()
	{
		SqlConnection cn = new SqlConnection(
				ConfigurationManager.ConnectionStrings
				["localPubs"].ConnectionString);
		SqlCommand cm = new SqlCommand(
			"select au_fname + ' ' + au_lname AuthorName, "
			+ "au_id ID from authors_ts order by au_lname", cn);

		cn.Open();
		ddlAuthors.DataSource = cm.ExecuteReader();
		ddlAuthors.DataTextField = "AuthorName";
		ddlAuthors.DataValueField = "ID";
		ddlAuthors.DataBind();
		cn.Close();
		ddlAuthors.Items.Insert(0, "");
	}

	protected void BindToAuthor(object sender, EventArgs e)
	{
		SqlConnection cn = new SqlConnection(
				ConfigurationManager.ConnectionStrings
				["localPubs"].ConnectionString);
		SqlCommand cm = new SqlCommand(
			"select @fname = au_fname, @lname = au_lname, @ts = ts "
			+ "from authors_ts where au_id = @id", cn);

		cm.Parameters.Add("@id", SqlDbType.Char, 11)
			.Value = ddlAuthors.SelectedValue;
		cm.Parameters.Add("@fname", SqlDbType.VarChar,20)
			.Direction = ParameterDirection.Output;
		cm.Parameters.Add("@lname", SqlDbType.VarChar,40)
			.Direction = ParameterDirection.Output;
		cm.Parameters.Add("@ts", SqlDbType.Timestamp)
			.Direction = ParameterDirection.Output;

		cn.Open();
		cm.ExecuteNonQuery();
		cn.Close();

		txtFirstName.Text = cm.Parameters["@fname"].Value.ToString();
		txtLastName.Text = cm.Parameters["@lname"].Value.ToString();
		tsAuthor.TimestampValue = cm.Parameters["@ts"].Value;
		pnEdit.Visible = true;

	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
		SqlConnection cn = new SqlConnection(
				ConfigurationManager.ConnectionStrings
				["localPubs"].ConnectionString);
		SqlCommand cm = new SqlCommand(
			"update authors_ts set au_fname = @fname, "
			+ "au_lname = @lname where au_id = @id "
			+ "and ts = @ts", cn);
        SqlParameter pm;

        cm.Parameters.Add("@id", SqlDbType.Char, 11)
			.Value = ddlAuthors.SelectedValue;
		pm = cm.Parameters.Add("@ts", SqlDbType.Timestamp);
		pm.Value = tsAuthor.TimestampValue;
		cm.Parameters.Add("@fname", SqlDbType.VarChar, 20)
			.Value = txtFirstName.Text;
		cm.Parameters.Add("@lname", SqlDbType.VarChar, 40)
			.Value = txtLastName.Text;

		cn.Open();
		int i = cm.ExecuteNonQuery();
		cn.Close();

		if (i == 1)
			lblOutput.Text = "Data saved";
		else
			lblOutput.Text = "Concurrency error";

		pnEdit.Visible = false;
		BindList();

	}

}


