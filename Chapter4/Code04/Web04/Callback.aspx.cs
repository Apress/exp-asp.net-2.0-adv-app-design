using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Callback : System.Web.UI.Page, ICallbackEventHandler
{
    private string GetAddressInvocation()
    {
        return Page.ClientScript.GetCallbackEventReference
            (this,
            "document.all.ddlListB.value",
            "DisplayAddress",
            "\"context\"");
    }

    public string RaiseCallbackEvent(string eventArgument)
    {
        DataSet ds = GetPoolHallDoc();
        string result = "";
        try
        {
            DataRow dr =
            ds.Tables[2].Select(
            string.Format("id = '{0}'", eventArgument))[0];

            result += dr["Address"].ToString() + "<BR>";
            result += dr["Phone"].ToString() + "<BR>";
        }
        catch
        {
            result = "Address not found.";
        }
        return result;
    }

    private DataSet GetPoolHallDoc()
    {
        DataSet ds;

        ds = (DataSet)Cache["PoolHalls"];

        if (ds == null)
        {
            string sFileName = Server.MapPath("PoolHalls.xml");
            ds = new DataSet();
            ds.ReadXml(sFileName);
            Cache.Insert("PoolHalls", ds, new CacheDependency(sFileName));
        }
        return ds;
    }


    void Page_Load(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock
            (this.GetType(),
            "Callback",
            "function GetAddress() { " + GetAddressInvocation() + " }",
            true);

        this.ClientScript.RegisterStartupScript
            (this.GetType(),
            "PopList",
            "populateListB();GetAddress();",
            true);

        this.ClientScript.RegisterClientScriptInclude
            ("Interdepends",
            "Interdepends.js");

        DataSet ds = GetPoolHallDoc();

        ddlListA.DataTextField = "City_text";
        ddlListA.DataSource = ds.Tables[1];
        ddlListA.DataBind();

        StringBuilder sb = new StringBuilder();
        sb.Append("<SCRIPT LANGUAGE='JavaScript'>\n");
        sb.Append("listsB = new Array;\n");
        sb.Append("valuesB = new Array;\n");

        int i = 0;
        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            sb.Append(
            string.Format(
            "listsB[{0}] = new Array;\n", i));

            sb.Append(
            string.Format(
            "valuesB[{0}] = new Array;\n", i));

            DataView dv = new DataView(
            ds.Tables[2],
            string.Format("City = '{0}'", dr[0]),
            "", DataViewRowState.CurrentRows);

            int j = 0;
            foreach (DataRowView drv in dv)
            {
                sb.Append(
                string.Format(
                "listsB[{0}][{1}] = \"{2}\";\n",
                i, j, drv["Name"]));

                sb.Append(
                string.Format(
                "valuesB[{0}][{1}] = \"{2}\";\n",
                i, j, drv["id"]));

                j++;
            }
            i++;
        }
        sb.Append("</script>");

        this.ClientScript.RegisterClientScriptBlock
            (this.GetType(),
            "InterArrays",
            sb.ToString());
    }
}
