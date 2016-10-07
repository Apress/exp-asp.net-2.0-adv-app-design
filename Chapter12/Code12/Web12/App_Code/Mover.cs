using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.EnterpriseServices;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Mover
/// </summary>
//[Transaction(TransactionOption.Required)]
public class Mover : ServicedComponent
{
    private string Database1 = "";
    private string Database2 = "";
    private System.Collections.Hashtable hashTable = new System.Collections.Hashtable();

    [AutoComplete]
    public void Move()
    {
        using (SqlConnection cnnDB1 = new SqlConnection(Database1),
                  cnnDB2 = new SqlConnection(Database2))
        {
            SqlCommand cmdDeleteDB1 =
                new SqlCommand("DELETE ...", cnnDB1);
            SqlCommand cmdInsertDB2 =
                new SqlCommand("INSERT ...", cnnDB2);
            // ADO.NET connections automatically enlist into
            // the DTC transaction
            cnnDB1.Open();
            cnnDB2.Open();
            cmdDeleteDB1.ExecuteNonQuery();
            cmdInsertDB2.ExecuteNonQuery();
        }
    }

    [AutoComplete]
    public void Move2(object key)
    {
        object val = hashTable[key];
        hashTable.Remove(key);
        using (SqlConnection cnnDB2 = new SqlConnection(Database2))
        {
            // Insert value from hash table into DB
            SqlCommand cmdInsertDB2 =
                new SqlCommand("INSERT ...", cnnDB2);
            cnnDB2.Open();
            cmdInsertDB2.ExecuteNonQuery();
        }
    }
}