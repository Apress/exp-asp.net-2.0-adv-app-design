using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Transactions;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class XactedDomTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WithATran();
    }
    private void WithATran()
    {
        TransactedXMLDocument dom = new TransactedXMLDocument();
        dom.Load(Server.MapPath("Orders.xml"));
        XmlNode orderElem;
        XmlNode ordersElem = dom.SelectSingleNode("//Orders");
        int orderCount = ordersElem.ChildNodes.Count;

        for (int i = orderCount - 1; i >= 0; i--)
        {
            orderElem = ordersElem.ChildNodes[i];
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    dom.Enlist();
                    orderElem.ParentNode.RemoveChild(orderElem);
                    AddOrder(orderElem);
                    tx.Complete();
                }
                Response.Write("The transaction was written<BR>");
            }
            catch (TransactionAbortedException tex)
            {
                Response.Write("The transaction did not succeed<BR>");
            }
        }
        dom.Save(Server.MapPath("UnprocessedOrders.xml"));
    }

    private bool AddOrder(XmlNode orderElem)
    {
        DateTime orderDate = 
            Convert.ToDateTime(orderElem.Attributes["OrderDate"].Value);
        int customerId = 
            Convert.ToInt32(orderElem.Attributes["CustomerID"].Value);
        XAction dal = new XAction();
        int orderID = XAction.GetNextOrderID();
        dal.AddOrder(orderID, customerId, orderDate);
        bool bSuccess = true;

        foreach(XmlNode orderItem in orderElem.ChildNodes)
        {            
            int itemID = 
                Convert.ToInt32(orderItem.Attributes["ItemId"].Value);
            int quantity = 
                Convert.ToInt32(orderItem.Attributes["Quantity"].Value);
            bSuccess = dal.AddOrderItem(orderID, itemID, quantity);
            if (!bSuccess) break;
        }
        return bSuccess;
    }

    private void WOATx()
    {
        XmlDocument dom = new XmlDocument();
        dom.Load(Server.MapPath("Orders.xml"));
        XmlNode orderElem;
        XmlNode ordersElem = dom.SelectSingleNode("//Orders");
        int orderCount = ordersElem.ChildNodes.Count;

        for (int i = orderCount - 1; i >= 0; i--)
        {
            orderElem = ordersElem.ChildNodes[i];
            orderElem.ParentNode.RemoveChild(orderElem);
            AddOrder(orderElem);            
        }
        dom.Save(Server.MapPath("ProcessedOrders.xml"));
    }
}
