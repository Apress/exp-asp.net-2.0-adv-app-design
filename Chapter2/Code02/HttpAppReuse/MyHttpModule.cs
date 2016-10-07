using System;
using System.Web;

namespace HttpAppReuse
{
    class MyHttpModule : IHttpModule
    {
        private HttpApplication app;

        public MyHttpModule()
        { }

        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            app = context;
            app.BeginRequest += new EventHandler(app_BeginRequest);
        }

        void app_BeginRequest(object sender, EventArgs e)
        {
            string s = app.Request.Path;
            if (s.IndexOf(".aspx") == -1)
                if (s.Substring(s.LastIndexOf(".") + 1, 3) == "cfm")
                    app.Context.RewritePath(s.Substring(0, s.Length - 3) + "aspx");
        }

    }
}
