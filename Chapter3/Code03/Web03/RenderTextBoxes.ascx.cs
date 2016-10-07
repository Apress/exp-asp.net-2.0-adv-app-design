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

public partial class RenderTextBoxes : System.Web.UI.UserControl
{
    public event System.EventHandler FieldChanged;

    override protected void OnInit(EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            TextBox t = new TextBox();
            this.Controls.Add(t);
            t.TextChanged += new EventHandler(t_TextChanged);
        }
        base.OnInit(e);
    }

    private void t_TextChanged(object sender, EventArgs e)
    {
        if (FieldChanged != null)
        {
            FieldChanged(this, new EventArgs());
        }
    }

}
