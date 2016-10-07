using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Book
/// </summary>
public class BookBinding
{
    public BookBinding()
    {}

    public SqlDataReader GetBookList()
    {
        String sql = "select BookId, Title From Book order by Title";
        SqlConnection cn = new SqlConnection(WebStatic.ConnectionString);
        SqlCommand cm = new SqlCommand(sql,cn);

        cn.Open();
        return cm.ExecuteReader(CommandBehavior.CloseConnection);        
    }

    public List<BookDetails> GetBook(int BookId)
    {
        List<BookDetails> bookList = new List<BookDetails>();
        bookList.Add(new BookDetails(BookId));
        return bookList;        
    }

    public void UpdateBook(BookDetails b)
    {        
        b.Save();
    } 
}
