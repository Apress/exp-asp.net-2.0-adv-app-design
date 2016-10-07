<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewSort.aspx.cs" Inherits="GridViewSort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat=server ID=gv1 EnableViewState=false AllowSorting=true DataSourceID=sdsAuthors />
        <asp:SqlDataSource runat=server ID=sdsAuthors
            SelectCommand='select * from authors' ConnectionString='server=.;database=pubs;uid=sa;pwd=123123' />    
    </div>
    </form>
</body>
</html>
