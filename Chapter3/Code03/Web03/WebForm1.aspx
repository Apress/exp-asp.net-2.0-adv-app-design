<%@ Page language="c#" 
         CodeFile="WebForm1.aspx.cs"          
         Inherits="WebDemo.WebForm1" %>
         
<HTML><HEAD><title>WebForm1</title></HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
    <asp:Label id="Label3" runat="server">User Name</asp:Label>
    <asp:TextBox id="TextBox1" runat="server" />
    <asp:Label id="Label2" runat="server">Password</asp:Label>    
    <asp:TextBox id="TextBox3" runat="server" />
    <asp:Button id="Button1" runat="server" Text="Login" />
    <asp:Label id="lblOutput" runat="server" />		
    </form>
  </body>
</HTML>
