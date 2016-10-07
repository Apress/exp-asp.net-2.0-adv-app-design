using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Web12
{
	/// <summary>
	/// Summary description for XActionIE.
	/// </summary>
	public partial class XActionIE : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			Hashtable ht = new Hashtable();
			ht.Add("a","abc123");
			ht.Add("b","def456");
			XActionIE.SingleDBUpdate(ht);

		}

		public static void SingleDBUpdate(Hashtable ht)
		{
			using (SqlConnection cnn = new SqlConnection(WebStatic.ConnectionString))
			{
				string sql;

				cnn.Open();
				SqlTransaction tx = cnn.BeginTransaction();				
				try
				{
					foreach(string key in ht.Keys)
					{
						sql = "INSERT INTO Tuples (keyValue, dataValue) " +
							  "VALUES ('{0}', '{1}') ";
						sql = string.Format(sql, key, ht[key]);
						SqlCommand insert = new SqlCommand(sql, cnn, tx);				
						insert.ExecuteNonQuery();						
					}	
					tx.Commit();
				}
				catch (Exception e)
				{
					tx.Rollback();
					HttpContext.Current.Response.Write(e.Message);
				}
				finally
				{
					cnn.Close();
				}
			}
		}
	}
	

	
	
}

