<%@ WebHandler Language="C#" Class="MyHandler" %>

using System;
using System.Web;
using System.Web.Caching;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class MyHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

        byte[] b;
        object id = context.Request.QueryString["BookId"];
        b = (byte[])context.Cache[string.Format("Book{0}", id)];
        if (b == null)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.
                ConnectionStrings["Library_local"].ConnectionString);
            string sql = "select CoverImage from BookCoverImage";
            sql += " where bookid = @BookID";
            SqlCommand cm = new SqlCommand(sql, cn);

            cm.Parameters.Add("@BookId", SqlDbType.Int).Value = id;

            cn.Open();
            SqlDataReader dr = cm.ExecuteReader();
            if (!dr.Read())
                context.Response.End();
            b = (byte[])dr[0];
            context.Cache.Insert(string.Format("Book{0}", id),
                b,
                null,
                DateTime.Now.AddSeconds(60),
                Cache.NoSlidingExpiration);
            dr.Close();
            cn.Close();
        }
        context.Response.OutputStream.Write(b, 0, b.Length - 1);
    }

    public bool IsReusable
    {
        get { return true; }
    }
} 
