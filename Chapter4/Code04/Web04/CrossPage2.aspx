<%@ Page Language="C#" 
         CodeFile="CrossPage2.aspx.cs" 
         Inherits="CrossPage2" %>
         
<%@ PreviousPageType VirtualPath="~/CrossPage.aspx" %>

<html>
<head id="Head1" runat="server">
    <title> Cross-Posted To (CrossPage2) </title>
</head>
<body runat=server id=body>
    <form id="form1" runat="server">
        <asp:Label Runat=server id=lblOutput />
    </form>
</body>
</html>
