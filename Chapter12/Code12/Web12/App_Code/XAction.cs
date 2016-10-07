using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for XAction
/// </summary>
public class XAction
{
    public XAction()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int GetNextOrderID()
    {
        string sql = "SELECT MAX(OrderID) + 1 AS NextOrderID FROM [Order]";
        int i;
        using (TransactionScope tx =
            new TransactionScope(TransactionScopeOption.Required))
        {

            SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
            SqlCommand cm = new SqlCommand(sql, cn);
            cn.Open();
            i = Convert.ToInt32(cm.ExecuteScalar());
            cn.Close();
            tx.Complete();
        }
        return i;

    }

    public void AddOrder(int orderId, int customerID, DateTime orderDate)
    {
        using (TransactionScope tx = 
            new TransactionScope(TransactionScopeOption.Required))
        {
            string sql = "INSERT INTO [Order](OrderID, CustomerID, OrderDate) "
                       + "VALUES (@orderID, @customerID, @orderDate)";

            SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
            SqlCommand cm = new SqlCommand(sql, cn);

            cm.Parameters.Add(new 
                SqlParameter("@orderId", SqlDbType.Int)).Value = orderId;
            cm.Parameters.Add(new 
                SqlParameter("@customerID", SqlDbType.Int)).Value = customerID;
            cm.Parameters.Add(new 
                SqlParameter("@orderDate", SqlDbType.DateTime)).Value = orderDate;
            
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            tx.Complete();            
        }
    }

    public bool AddOrderItem(int orderId, int itemId, int quantity)
    {
        using (TransactionScope tx = 
            new TransactionScope(TransactionScopeOption.Required))
        {
            if (UpdateQuantity(itemId, quantity))
            {
                string sql = "INSERT INTO OrderItem(OrderID, InventoryID, Quantity) "
                        + "VALUES (@OrderID, @InventoryID, @Quantity)";

                SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
                SqlCommand cm = new SqlCommand(sql, cn);

                cm.Parameters.Add(new
                        SqlParameter("@OrderID", SqlDbType.Int)).Value = orderId;
                cm.Parameters.Add(new
                        SqlParameter("@InventoryID", SqlDbType.Int)).Value = itemId;
                cm.Parameters.Add(new
                        SqlParameter("@Quantity", SqlDbType.Int)).Value = quantity;

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

                tx.Complete();
                return true;
            }
            else return false;
        }
    }

    public bool UpdateQuantity(int itemId, int quantity)
    {
        using (TransactionScope tx = 
            new TransactionScope(TransactionScopeOption.Required))
        {
            AuditItemUpdate(itemId, quantity);

            string sql = "UPDATE Inventory SET OnHand = OnHand - @quantity "
                       + "WHERE InventoryID = @inventoryID and "
                       + "OnHand - @quantity >= 0";

            SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
            SqlCommand cm = new SqlCommand(sql, cn);

            cm.Parameters.Add(new
                SqlParameter("@quantity", SqlDbType.Int)).Value = quantity;
            cm.Parameters.Add(new
                SqlParameter("@inventoryID", SqlDbType.Int)).Value = itemId;            
            
            cn.Open();
            int i = cm.ExecuteNonQuery();
            cn.Close();
            if (i==1) tx.Complete();
            return Convert.ToBoolean(i);
        }        
    }

    public void AuditItemUpdate(int itemId, int quantity)
    {
        using (TransactionScope tx = 
            new TransactionScope(TransactionScopeOption.RequiresNew))
        {
            string sql = "INSERT INTO InventoryAudit(InventoryID, Quantity, AttemptDate) "
                       + "VALUES (@InventoryID, @Quantity, @AttemptDate)";

            SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
            SqlCommand cm = new SqlCommand(sql, cn);
                        
            cm.Parameters.Add(new
                SqlParameter("@InventoryID", SqlDbType.Int)).Value = itemId;
            cm.Parameters.Add(new
                SqlParameter("@Quantity", SqlDbType.Int)).Value = quantity;
            cm.Parameters.Add(new
                SqlParameter("@AttemptDate", SqlDbType.DateTime)).Value = DateTime.Now;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
            tx.Complete();  
        }
    }
}
