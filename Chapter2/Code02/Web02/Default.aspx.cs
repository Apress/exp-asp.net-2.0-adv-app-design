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

public partial class _Default : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Load += new EventHandler(Default_aspx_Load);
        this.PreRender += new EventHandler(Default_aspx_PreRender);
    }

    void Default_aspx_Load(object sender, EventArgs e)
    {
        Response.Write(MyImpl.SomeStaic + "<BR>");
        DataGrid dg = new DataGrid();
        dg.DataSource = MyImpl.StateList.Tables[0];
        dg.DataBind();
        Controls.Add(dg);
    }

    void Default_aspx_PreRender(object sender, EventArgs e)
    {
        Response.Write("<b>Page Handler Fired</b><BR>");
    }

}
