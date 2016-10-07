<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SimpleSub.aspx.cs" Inherits="SimpleSub" %>
<%@ outputcache duration="15" varybyparam="none" %>
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border=1>
            <tr>
                <td colspan=2>
                    <h1>Header</h1>
                </td>
            </tr>        
            <tr>
                <td width=30%>
                <h3>Left Nav</h3>
                This page executed at:
                <asp:Label runat=server ID=lblRendered />                
                </td>
                <td>
                <h4>Main content area</h4>
                The current time is:
                <asp:Substitution runat=server ID=subTimestamp MethodName='GetStamp' />
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>
