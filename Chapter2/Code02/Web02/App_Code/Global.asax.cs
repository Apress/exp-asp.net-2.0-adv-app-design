using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;


/// <summary>
/// Summary description for Global.
/// </summary>
public class Global : HttpApplication
{
    public Global()
    {
        //this.AcquireRequestState += new EventHandler(Global_AcquireRequestState);
        //this.PreRequestHandlerExecute += new EventHandler(Global_PreRequestHandlerExecute);
    }

	private void Global_AcquireRequestState(object sender, EventArgs e)
    {
        HttpContext ctx = HttpContext.Current;
        if (ctx.Handler is ISessionCounter)
            ((ISessionCounter)ctx.Handler).SessionVarCount = ctx.Session.Keys.Count;
    }

    private void Global_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        this.Context.Handler = new Dummy();
    }

}
public interface ISessionCounter
{
    int SessionVarCount { get; set; }
}



