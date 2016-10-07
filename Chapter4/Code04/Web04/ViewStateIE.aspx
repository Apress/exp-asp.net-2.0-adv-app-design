<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeFile="ViewStateIE.aspx.cs" 
         Inherits="ViewStateIE" %>
<html>
<head runat="server">
    <title>ViewStateIE</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Runat=server ID=lblOutput /><br />
        <asp:TextBox Runat=server ID=txtDemo EnableViewState=true />        
    </form>
</body>
</html>
