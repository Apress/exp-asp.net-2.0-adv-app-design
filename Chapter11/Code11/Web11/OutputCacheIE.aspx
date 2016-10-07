<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutputCacheIE.aspx.cs" Inherits="OutputCacheIE" %>
<%@ OutputCache SqlDependency="Publishers:authors" 
    Duration="9999" VaryByParam="none" %>
<html>
<head runat="server">
    <title>Output Caching</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource Runat=server ID=sdsAuthors
         ConnectionString= '<%$ ConnectionStrings:pubsConn %>'
         SelectCommand="select * from authors" />
        <asp:GridView Runat=server ID=dvAuthors
         DataSourceID=sdsAuthors />
    </form>
</body>
</html>
