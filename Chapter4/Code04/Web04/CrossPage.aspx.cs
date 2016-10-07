using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CrossPage : System.Web.UI.Page
{
    public System.Drawing.Color outputColor
    { get { return System.Drawing.Color.FromName(txtTextColor.Text); } }

    public string SomeValue
    {
        get
        {
            if (ViewState["SomeValue"] == null)
                return "SomeValue not set. ";
            else
                return ViewState["SomeValue"].ToString();
        }
    }

    public object GetViewStateValue(string ViewStateEntryName)
    { return ViewState[ViewStateEntryName]; }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCrossPagePostBack
             && Request.QueryString["SomeValue"] != null)
            this.ViewState["SomeValue"] =
                Request.QueryString["SomeValue"].ToString();

    }
}
