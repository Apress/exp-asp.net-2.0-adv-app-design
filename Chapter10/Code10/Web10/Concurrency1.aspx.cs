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

public partial class Concurrency1_aspx : System.Web.UI.Page
{

	private bool UpdateAuthors(DataSet ds)
	{
		string sql = "update authors set " +
		"au_lname = @au_lname, " +
		"au_fname = @au_fname, " +
		"phone = @phone, " +
		"address = @address, " +
		"city = @city, " +
		"state = @state, " +
		"zip = @zip, " +
		"contract = @contract " +
		"WHERE au_id = @org_au_id and " +
		"au_lname = @org_au_lname and " +
		"au_fname = @org_au_fname and " +
		"phone = @org_phone and " +
		"(address = @org_address or " +
		"(address is null and @org_address is null)) and " +
		"(city = @org_city  or " +
		"(city is null and @org_city is null)) and " +
		"(state = @org_state or " +
		"(state is null and @org_state is null)) and " +
		"(zip = @org_zip or " +
		"(zip is null and @org_zip is null)) and " +
		"contract = @org_contract";

		SqlConnection cn = new SqlConnection(
			ConfigurationManager.ConnectionStrings
            ["localPubs"].ConnectionString);
		SqlCommand cm = new SqlCommand(sql, cn);
		SqlDataAdapter da = new SqlDataAdapter
			(new SqlCommand("select * from authors",cn));
		SqlParameter pm;

		pm = new SqlParameter
			("@au_lname", SqlDbType.VarChar, 40);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "au_lname";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@au_fname", SqlDbType.VarChar, 10);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "au_fname";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@phone", SqlDbType.Char, 12);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "phone";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@address", SqlDbType.VarChar, 40);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "address";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@city", SqlDbType.VarChar, 20);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "city";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@state", SqlDbType.Char, 2);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "state";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@zip", SqlDbType.Char, 5);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "zip";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@contract", SqlDbType.Bit);
		pm.SourceVersion = DataRowVersion.Current;
		pm.SourceColumn = "contract";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_au_id", SqlDbType.VarChar, 11);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "au_id";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_au_lname", SqlDbType.VarChar, 40);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "au_lname";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_au_fname", SqlDbType.VarChar, 20);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "au_fname";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_phone", SqlDbType.Char, 12);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "phone";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_address", SqlDbType.VarChar, 40);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "address";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_city", SqlDbType.VarChar, 20);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "city";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_state", SqlDbType.Char, 2);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "state";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_zip", SqlDbType.Char, 5);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "zip";
		cm.Parameters.Add(pm);
		pm = new SqlParameter
			("@org_contract", SqlDbType.Bit);
		pm.SourceVersion = DataRowVersion.Original;
		pm.SourceColumn = "contract";
		cm.Parameters.Add(pm);

		da.UpdateCommand = cm;
		da.Update(ds);

		return true;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		DataSet ds = new DataSet();
		new SqlDataAdapter(
			new SqlCommand("select * from authors", 
			new SqlConnection(
			ConfigurationManager
			.ConnectionStrings["localPubs"]
			.ConnectionString)))
		.Fill(ds);

		ds.Tables[0].Rows[0]["au_fname"] = "test";

		UpdateAuthors(ds);


	}
}

