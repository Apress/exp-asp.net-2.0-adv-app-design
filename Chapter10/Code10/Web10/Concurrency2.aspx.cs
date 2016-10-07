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

public partial class Concurrency2_aspx : System.Web.UI.Page
{
	private bool UpdateAuthors(DataSet ds)
	{
		string sql = "";
		string sqlBase = " update authors set {0} where au_id = '{1}'{2}";
		string sqlUpdate = "";
		string sqlWhere = "";

		SqlConnection cn = new SqlConnection(
			ConfigurationSettings
			.ConnectionStrings["localPubs"].ConnectionString);
		SqlCommand cm = new SqlCommand("", cn);				

		foreach (DataRow dr in ds.Tables[0].Rows)
		{
			sqlUpdate = "";
			sqlWhere = "";
			foreach(DataColumn dc in ds.Tables[0].Columns)
			{
				if (dr[dc, DataRowVersion.Current] != 
					dr[dc, DataRowVersion.Original])
				{
					sqlUpdate += string.Format("{0} = '{1}', ", 
						dc.ColumnName, dr[dc]);
					sqlWhere += string.Format(" and {0} = '{1}'", 
						dc.ColumnName, dr[dc, 
						DataRowVersion.Original]);
				}
			}
			if (sqlUpdate.Length > 0)
			{				
				sqlUpdate = sqlUpdate.Substring
					(0, sqlUpdate.Length - 2);
				sql += string.Format(sqlBase, sqlUpdate, 
					dr["au_id", DataRowVersion.Original], 
					sqlWhere); ;
			}
		}

		cm.CommandText = sql;
		cn.Open();
		int updates = cm.ExecuteNonQuery();
		cn.Close();

		if (updates != ds.Tables[0].GetChanges().Rows.Count)
			return false;
		else
		{
			ds.AcceptChanges();
			return true;
		}
		
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		DataSet ds = new DataSet();
		new SqlDataAdapter(
			new SqlCommand("select  au_id, au_lname, au_fname, phone, address, city, state, zip from authors",
			new SqlConnection(
			ConfigurationSettings
			.ConnectionStrings["localPubs"]
			.ConnectionString)))
		.Fill(ds);

		for (int indx = 1; indx < 6; indx++)
		{
			if (indx != 3) ds.Tables[0].Rows[indx][indx] += "1";
		}		

		UpdateAuthors(ds);

	}

}
