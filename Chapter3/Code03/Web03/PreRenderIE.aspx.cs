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

public partial class PreRenderIE : System.Web.UI.Page
{
    private int ChangeCount = 0;

    override protected void OnInit(EventArgs e)
    {
        RenderTextboxes1.FieldChanged +=
            new EventHandler(RenderTextboxes1_FieldChanged);

        base.OnInit(e);
        this.PreRender += new EventHandler(PreRenderIE_PreRender);
    }

    private void RenderTextboxes1_FieldChanged(object sender, EventArgs e)
    {
        ChangeCount++;
    }

    private void PreRenderIE_PreRender(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            lblOutput.Text = string.Format(
                "You changed {0} fields on the User Control", 
                ChangeCount);

            this.Controls.Remove(this.Controls[0]);
            this.Controls.AddAt(0, new LiteralControl(string.Format(
                "<html><head><title>{0} Changes</title></head><body>",
                ChangeCount)));
        }
    }
}
