using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BookService
/// </summary>
public class BookService
{
    public BookService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [WebMethod()]
    public BookDetails GetBook(int BookId)
    {
        return new BookDetails();
    }
}
