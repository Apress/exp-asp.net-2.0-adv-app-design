using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class au_sorting : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid("au_id");
    }
    protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        BindGrid(e.SortExpression);
    }
    private void BindGrid(string SortExpr)
    {
        DataSet ds;

        ds = (DataSet)Cache["Authors"];
        
        if (ds == null)
        {
            string sql = "select * from authors";
            SqlConnection cn =
                new SqlConnection
                ("server=.;database=pubs;uid=sa;pwd=");

            SqlCommand cm = new SqlCommand(sql, cn);

            ds = new DataSet();
            new SqlDataAdapter(cm).Fill(ds);
            Cache.Insert("Authors",
                ds, null,
                DateTime.Now.AddMinutes(60),
                Cache.NoSlidingExpiration);
        }
        
        DataGrid1.DataSource =
            new DataView(
            ds.Tables[0], "",
            SortExpr,
            DataViewRowState.CurrentRows);

        DataGrid1.DataBind();
    }


    //protected void DataGrid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    DataGrid1.PageIndex = e.NewPageIndex;
    //    BindGrid("au_id");
    //}
    //protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    //{
    //    DataGrid1.CurrentPageIndex = e.NewPageIndex;
    //    BindGrid("au_id");
    //}
    protected void SortIt(object sender, GridViewSortEventArgs e)
    {
        BindGrid(e.SortExpression);
    }

}
