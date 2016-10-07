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

public partial class SortIE_aspx : System.Web.UI.Page
{
    protected void gvAuthors_Sorting(object sender, GridViewSortEventArgs e)
	{
		BindGrid(e.SortExpression);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		BindGrid("au_id");		
	}

	private void GenSprocs()
	{
		SqlConnection cn = new
				SqlConnection
				("server=.;database=pubs;uid=sa;pwd=");

		SqlCommand cm = new
			SqlCommand("select * from authors", cn);

		DataSet ds = new DataSet();

		cn.Open();
		SqlDataAdapter da = new SqlDataAdapter(cm);

		da.Fill(ds);

		foreach (DataColumn dc in ds.Tables[0].Columns)
		{
			string sql = "create procedure usp_SortAuthors_{0} as "
				+ "select * from authors order by {0}";
			sql = string.Format(sql, dc.ColumnName);
			cm = new SqlCommand(sql, cn);
			
			cm.ExecuteNonQuery();

		}
		cn.Close();

	}

	private DataSet GetAuthors()
	{
		DataSet ds;

		ds = (DataSet)Cache["AuthorData"];

		if (ds == null)
		{
			ds = new DataSet();
			SqlConnection cn = new SqlConnection					
				("server=.;database=pubs;uid=sa;pwd=");

			SqlCommand cm = new
				SqlCommand("select * from authors", cn);

			new SqlDataAdapter(cm).Fill(ds);

            Cache.Insert("AuthorData", ds);
            //, new SqlCacheDependency("Publishers", "authors"));

		}
		return ds;

	}

	//This method caches each unique dataview
	private void BindGrid(string sortExpr)
	{
		DataView dv;
		string sCacheEntry =
			string.Format("Author_Sort_{0}", sortExpr);

		dv = (DataView)Cache[sCacheEntry];

		if (dv == null)
		{
			dv = new DataView(
				GetAuthors().Tables[0], "",
				sortExpr,
				DataViewRowState.CurrentRows);

            Cache.Insert(sCacheEntry, dv);//, 
				//new SqlCacheDependency("Publishers", "authors"));

		}



		gvAuthors.DataSource = dv;
		gvAuthors.DataBind();
	}

	//This method uses cache for data but creates dataviews
//	private void BindGrid(string sortExpr)
//	{
//		gvAuthors.DataSource = new DataView(
//			GetAuthors().Tables[0], "",
//			sortExpr,
//			DataViewRowState.CurrentRows);
//		gvAuthors.DataBind();
//	}

	//This method uses a sproc per sort
//	private void BindGrid(string sortExpr)
//	{
//		SqlConnection cn = new
//				SqlConnection
//				("server=.;database=pubs;uid=sa;pwd=");
//
//		SqlCommand cm = new
//			SqlCommand(string.Format("usp_SortAuthors_{0}", sortExpr), cn);
//
//		cm.CommandType = CommandType.StoredProcedure;
//		cn.Open();
//		gvAuthors.DataSource = cm.ExecuteReader();
//		gvAuthors.DataBind();
//		cn.Close();
//	}

	//This method uses a sproc that gens sql
//	private void BindGrid(string sortExpr)
//	{
//		SqlConnection cn = new
//				SqlConnection
//				("server=.;database=pubs;uid=sa;pwd=");
//
//		SqlCommand cm = new
//			SqlCommand("usp_SortAuthors", cn);
//
//		cm.CommandType = CommandType.StoredProcedure;
//		cm.Parameters.Add(
//			new SqlParameter(
//				"@sortExpr",
//				SqlDbType.VarChar,
//				25)).Value = sortExpr;
//
//		cn.Open();
//		gvAuthors.DataSource = cm.ExecuteReader();
//		gvAuthors.DataBind();
//		cn.Close();
//	}

	//THis method gens sql
//	private void BindGrid(string sortExpr)
//	{
//		SqlConnection cn = new
//				SqlConnection
//				("server=.;database=pubs;uid=sa;pwd=");
//
//		SqlCommand cm = new
//			SqlCommand
//			(string.Format(
//				"select * from authors order by {0}",
//				sortExpr),
//			cn);
//
//		cn.Open();
//		gvAuthors.DataSource = cm.ExecuteReader();
//		gvAuthors.DataBind();
//		cn.Close();
//	}

}
