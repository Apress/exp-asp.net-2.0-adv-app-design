using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

public class DomHandler : IHttpHandler
{
    public DomHandler()
    { }

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        string s;
        Bitmap bm;

        s = context.Request.Url.AbsolutePath;
        int iPos = s.LastIndexOf("/");
        s = s.Substring(iPos + 1, s.Length - 5 - iPos);
        bm = new Bitmap(30 + s.Length * 13, 50);

        Graphics g = Graphics.FromImage(bm);

        g.FillRectangle(Brushes.Goldenrod, 0, 0, bm.Width, bm.Height);
        s = context.Server.UrlDecode(s);
        g.DrawString(s,
            new Font("Verdana", 18, FontStyle.Bold),
            Brushes.Blue, 20, 10);

        bm.Save(context.Response.OutputStream, ImageFormat.Jpeg);
    }
}
