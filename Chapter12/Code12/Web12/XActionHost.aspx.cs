using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class XActionHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();        

        ht.Add(1, 5);
        ht.Add(2, 15);
        ht.Add(3, 10);
        PlaceOrder(1, DateTime.Now, ht);
        System.Configuration.ConfigurationManager.AppSettings
    }

    private void PlaceOrder(int CustomerID, 
        DateTime OrderDate, Hashtable OrderItems)
    {
        XAction dalTx = new XAction();
        int OrderId = GetNextOrderID();
        bool bSuccess = true;

        using (TransactionScope tx = new TransactionScope())
        {
            dalTx.AddOrder(OrderId, CustomerID, DateTime.Now);
            foreach(int ItemId in OrderItems.Keys)
            {
                if (!dalTx.AddOrderItem(OrderId,
                    ItemId,
                    Convert.ToInt32(OrderItems[ItemId])))
                {
                    bSuccess = false;
                    break;
                }
            }
            if (bSuccess) tx.Complete();                        
        }
        if (bSuccess) lblOutput.Text = "Success";
        else lblOutput.Text = "Rolled back";
    }

    private int GetNextOrderID()
    {
        return 4;
    }
}
