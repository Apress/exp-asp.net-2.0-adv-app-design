<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConnStrIE.aspx.cs" Inherits="ConnStrIE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:SqlDataSource Runat=server ID=sdsAuthors
 ConnectionString= '<%$ ConnectionStrings:localPubs %>'
 ProviderName='<%$ ConnectionStrings:localPubs.ProviderName %>'
 SelectCommand="select * from authors" />
<asp:GridView Runat=server ID=dvAuthors
 DataSourceID=sdsAuthors />


    </div>
    </form>
</body>
</html>
