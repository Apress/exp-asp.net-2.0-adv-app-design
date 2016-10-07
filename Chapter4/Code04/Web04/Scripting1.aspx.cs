using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Scripting1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("PoolHalls.xml"));

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
        plScript.Controls.Add(
            new LiteralControl(sb.ToString()));
    }
}
