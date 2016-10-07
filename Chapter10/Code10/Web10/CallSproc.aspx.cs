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

public partial class CallSproc_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		bool bDone = false;
		SqlDataReader dr;

        
        string pubid;
        if (Request.QueryString["pubid"] == null)
            pubid = "0736";
        else
            pubid = Request.QueryString["pubid"].ToString();
 
		SqlCommand cm =
			new SqlCommand(
			"usp_GetPublisherDetails",
			new SqlConnection(ConfigurationManager.
            ConnectionStrings["localPubs"].ToString())
		);

		cm.CommandType = CommandType.StoredProcedure;

		cm.Parameters.Add(
				new SqlParameter(
				"@pubid",
				SqlDbType.Char, 4)
			).Value = pubid;

		cm.Connection.Open();
		dr = cm.ExecuteReader();

		while (!bDone)
		{
			GridView gv = new GridView();
			gv.DataSource = dr;
			gv.DataBind();
			form1.Controls.Add(gv);
			bDone = !dr.NextResult();
		}
		dr.Close();
		cm.Connection.Close();
	}
}
