using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

/// <summary>
/// Summary description for TransDOM
/// </summary>
public class TransactedXMLDocument : XmlDocument, IEnlistmentNotification
{
    private string orgXml;    

	public TransactedXMLDocument() : base()
	{ }    

    public void Enlist()
    {
        orgXml = this.InnerXml;
        Transaction.Current.EnlistVolatile(this, EnlistmentOptions.None);
    }

    public void Commit(Enlistment enlistment)
    {
        orgXml = "";
        enlistment.Done();
    }

    public void InDoubt(Enlistment enlistment)
    {
        this.LoadXml(orgXml);
        orgXml = "";
    }

    public void Prepare(PreparingEnlistment preparingEnlistment)
    {        
        preparingEnlistment.Prepared();
    }

    public void Rollback(Enlistment enlistment)
    {
        this.LoadXml(orgXml);
        orgXml = "";
    }   
}