<%@ Page Language="C#" 
         CodeFile="CrossPage.aspx.cs" 
         Inherits="CrossPage" %>
<html>
<head runat="server">
    <title>Cross Poster</title>
</head>
<body>
    <form id="form1" runat="server">    
        Make a page that has:<br />
        Background: <asp:TextBox Runat=server ID=txtBgcolor />
        <br />
        And displays: <asp:TextBox Runat=server ID=txtText />
        <br />
        In the color of:<asp:TextBox Runat=server ID=txtTextColor />
        <br />    
        <asp:Button Runat=server ID=btn1 Text=Submit PostBackUrl="~/CrossPage2.aspx" />
    </form>
</body>
</html>
