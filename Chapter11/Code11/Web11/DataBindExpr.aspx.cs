using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DataBindExpr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) BindGrid();
	}

	protected DataTable GetBookTypes()
	{
		string sql = 
			"select type from titles group by type order by type";

		SqlConnection cn = new SqlConnection(WebStatic.PubsConnStr);
			
		SqlCommand cm = new SqlCommand(sql,cn);
		DataSet ds = new DataSet();

		new SqlDataAdapter(cm).Fill(ds);
		return ds.Tables[0];
	}

	protected DataTable GetPubList()
	{
		string sql = "select pub_id, pub_name from publishers "
			+ "order by pub_name";

		SqlConnection cn = new SqlConnection(WebStatic.PubsConnStr);
				
		SqlCommand cm = new SqlCommand(sql,cn);
		DataSet ds = new DataSet();

		new SqlDataAdapter(cm).Fill(ds);
		return ds.Tables[0];
	}

	private void BindGrid()
	{
		string sql = "SELECT titles.title_id, titles.title, titles.type, "
			+ "titles.pub_id, titles.price, titles.advance, publishers.pub_name "
			+ " FROM titles INNER JOIN "
			+ " publishers ON titles.pub_id = publishers.pub_id";

        SqlConnection cn = new SqlConnection(WebStatic.PubsConnStr);
		SqlCommand cm = new SqlCommand(sql,cn);
		DataSet ds = new DataSet();

		new SqlDataAdapter(cm).Fill(ds);
		dgTitles.DataSource = ds.Tables[0];
		dgTitles.DataBind();
		
	}

	#region Web Form Designer generated code
	override protected void OnInit(EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//
		InitializeComponent();
		base.OnInit(e);
	}
	
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{    
		this.dgTitles.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTitles_CancelCommand);
		this.dgTitles.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTitles_EditCommand);
		this.dgTitles.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTitles_UpdateCommand);
		this.dgTitles.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTitles_ItemDataBound);
		this.Load += new System.EventHandler(this.Page_Load);

	}
	#endregion

	private void dgTitles_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
	{
		dgTitles.EditItemIndex = e.Item.ItemIndex;
		BindGrid();		
	}

	private void dgTitles_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
	{
		dgTitles.EditItemIndex = -1;
		BindGrid();	

		string title_id = dgTitles.DataKeys[e.Item.ItemIndex].ToString();
		string title = ((TextBox)e.Item.FindControl("txtTitle")).Text;
		string type = ((DropDownList)e.Item.FindControl("ddlType")).SelectedValue;
		string pub_id = ((DropDownList)e.Item.FindControl("ddlPub")).SelectedValue;
		double price = Convert.ToDouble(((TextBox)e.Item.FindControl("txtPrice")).Text);
		
	}

	private void dgTitles_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
	{
		dgTitles.EditItemIndex = -1;
		BindGrid();		
	}

	private void dgTitles_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.EditItem)
		{
			DataRowView drv = (DataRowView)e.Item.DataItem;
			DropDownList ddl = (DropDownList)e.Item.FindControl("ddlPub");
			ddl.SelectedValue = drv["pub_id"].ToString();

			ddl = (DropDownList)e.Item.FindControl("ddlType");
			ddl.SelectedIndex = -1;
			ddl.Items.FindByText(drv["type"].ToString()).Selected = true;
		}
	}
}
