using System;
using System.Web;
using System.Web.Mail;

namespace HttpAppReuse
{   
        public abstract class GenericAbstractHttpApp : HttpApplication
        {
            public GenericAbstractHttpApp()
            {
                this.Error +=
                    new EventHandler(GenericAbstractHttpApp_Error);
                this.BeginRequest +=
                    new EventHandler(GenericAbstractHttpApp_BeginRequest);
            }

            public abstract bool RequiresSSL { get; }

            private void GenericAbstractHttpApp_Error(object sender, EventArgs e)
            {
                HttpContext ctx = HttpContext.Current;
                Exception ex = this.Server.GetLastError();
                MailMessage m = new MailMessage();
                string sBody;

                sBody = ex.Message + "\n";
                sBody += ex.StackTrace;

                Exception ie = ex.InnerException;
                Exception last = ex;
                while (ie != null)
                {
                    sBody += "\n\n--------------------------";
                    sBody += "\n" + ie.Message;
                    sBody += "\n" + ie.StackTrace;
                    last = ie;
                    ie = ie.InnerException;
                }

                m.To = "YourEmail@YourDomain.com";
                m.Subject = "Intertech Training Exception";
                m.Body = sBody;
                m.From = "Exception@IntertechTraining.com";

                SmtpMail.Send(m);
                Response.Redirect(String.Format
                    ("/ErrorOccurred.aspx?Message={0}",
                    Server.UrlEncode(last.Message)));

            }

            void GenericAbstractHttpApp_BeginRequest(object sender, EventArgs e)
            {
                HttpContext ctx = HttpContext.Current;

                if (this.RequiresSSL)
                    if (!ctx.Request.IsSecureConnection)
                        ctx.Response.Redirect(
                            Request.Url.ToString().Replace("http:", "https:"));
            }
        }

    
}
