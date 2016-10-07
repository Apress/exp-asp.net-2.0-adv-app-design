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

    protected override void OnInit(EventArgs e)
    {
        gvAuthors.Sorting += new GridViewSortEventHandler(gvAuthors_Sorting);    
    }

	void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack) BindGrid("au_id");		
	}

	private DataSet GetAuthors()
	{
		DataSet ds;

		ds = (DataSet)Cache["AuthorData"];

        if (ds == null) 
        {
            Response.Write("From Database");
            ds = new DataSet();
            SqlConnection cn = new SqlConnection
                (WebStatic.PubsConnStr);

            SqlCommand cm = new
                SqlCommand("select * from authors", cn);

            new SqlDataAdapter(cm).Fill(ds);

            Cache.Insert("AuthorData", ds,
                new SqlCacheDependency("Publishers", "authors"));
        }
        else
            Response.Write("Data From Cache");
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

            Cache.Insert(sCacheEntry, dv,
                new SqlCacheDependency("Publishers", "authors"));
        }
        else
            Response.Write("View From Cache");
		gvAuthors.DataSource = dv;
		gvAuthors.DataBind();
	}
}
