using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;





/// <summary>
/// Summary description for CreateSessionVars.
/// </summary>
public partial class CreateSessionVars : System.Web.UI.Page, ISessionCounter
{	

	private int _SessionVarCount;
	public int SessionVarCount 
	{
		get { return _SessionVarCount; }
		set { _SessionVarCount = value; }
	}
	private void Page_Load(object sender, System.EventArgs e)
	{
		// Put user code to initialize the page here
	}

	#region Web Form Designer generated code
	override protected void OnInit(EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//
		InitializeComponent();
		base.OnInit(e);
	}
	
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{    
		this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
		this.Load += new System.EventHandler(this.Page_Load);
		this.PreRender +=new EventHandler(CreateSessionVars_PreRender);

	}
	#endregion

	private void btnSubmit_Click(object sender, System.EventArgs e)
	{
		int Count = int.Parse(txtCount.Text) + Session.Keys.Count;

		for (int i = Session.Keys.Count; i < Count; i++)
		{
			Session[string.Format("sessionvar{0}",i)] = i;
		}										 
	}

	private void CreateSessionVars_PreRender(object sender, EventArgs e)
	{
		lblOutput.Text = string.Format(
			"Session count at start of request: {0}<br>" +
			"Session count at end of request: {1}<br>",
			this.SessionVarCount, Session.Keys.Count);
	}
}

