using System;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

public abstract class DB_ViewState : System.Web.UI.Page
{
	protected override void SavePageStateToPersistenceMedium(object state)
	{
		HtmlInputHidden vsk = 
			(HtmlInputHidden)this.FindControl
			("__VIEWSTATE_KEY");

		if (vsk == null)
		{
			vsk = new HtmlInputHidden();
			vsk.ID = "__VIEWSTATE_KEY";
			vsk.Value = Guid.NewGuid().ToString();
			this.Page.FindControl("Form1").Controls.AddAt(0, vsk);
		}

		LosFormatter bf = new LosFormatter();
		MemoryStream ms = new MemoryStream();
		bf.Serialize(ms, state);

		SqlConnection cn = new SqlConnection
			("server=.;database=VS_Persist;uid=sa;pwd=123123");
		SqlCommand cm = new SqlCommand("usp_SaveState", cn);

		cm.CommandType = CommandType.StoredProcedure;
		
		cm.Parameters.Add(
			"@PageName", 
			SqlDbType.VarChar, 400).Value = 
			Request.Url.AbsoluteUri;
		
		cm.Parameters.Add(
			"@SessionID", 
			SqlDbType.VarChar, 50).Value = vsk.Value;
		
		cm.Parameters.Add(
			"@StateData", 
			SqlDbType.Image).Value = ms.ToArray();

		cn.Open();
		cm.ExecuteNonQuery();
		cn.Close();
	}

	protected override object LoadPageStateFromPersistenceMedium()
	{
		if (Request.Params["__VIEWSTATE_KEY"] == null) 
			return null;

		string viewstatekey = 
			Request.Params["__VIEWSTATE_KEY"].ToString();

		SqlConnection cn = new SqlConnection
			("server=.;database=VS_Persist;uid=sa;pwd=123123");
		SqlCommand cm = new SqlCommand("usp_LoadState", cn);
		SqlDataReader dr = null;

		cm.CommandType = CommandType.StoredProcedure;

		cm.Parameters.Add(
			"@PageName", 
			SqlDbType.VarChar, 400).Value = 
			Request.Url.AbsoluteUri;

		cm.Parameters.Add(
			"@SessionID", 
			SqlDbType.VarChar, 50).Value = viewstatekey;

		try
		{
			cn.Open();
			dr = cm.ExecuteReader();
			if (dr.Read())
			{
				LosFormatter bf = new LosFormatter();
				object data = bf.Deserialize
					(new MemoryStream((byte[])dr[0]));
				return data;
			}
			else
				return null;
		}
		finally
		{
			if (dr != null) dr.Close();
			cn.Close();
		}
	}
}