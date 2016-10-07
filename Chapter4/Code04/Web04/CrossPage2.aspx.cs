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

public partial class CrossPage2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Straight reference to textbox would break if
        //posting page does not have a textbox named txtText
        string output =
        string.Format("<h1>{0}</h1>",
        ((TextBox)this.PreviousPage.FindControl
        ("txtText")).Text);

        //This is safer code, that accounts for txtBgcolor
        //not being present and sets a default value
        TextBox txt = (TextBox)this.PreviousPage.FindControl("txtBgcolor");
        string bodyColor;
        if (txt == null)
            bodyColor = "Lime";
        else
            bodyColor = txt.Text;
        body.Attributes.Add("bgcolor", bodyColor);

        //Strong typed reference to previous page type
        //can leverage a public property
        lblOutput.ForeColor = PreviousPage.outputColor;
        lblOutput.Text = output;

        //ViewState is exposed via strong type property as well
        lblOutput.Text +=
            "<BR>Value from ViewState: "
            + this.PreviousPage.SomeValue;
        
    }
}
