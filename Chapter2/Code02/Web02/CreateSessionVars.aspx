<%@ Page language="c#" 
         CodeFile="CreateSessionVars.aspx.cs" 
         Inherits="CreateSessionVars" %>
<HTML>
  <HEAD>
    <title>CreateSessionVars</title>    
  </HEAD>
  <body>	
    <form id="Form1" method="post" runat="server">
		How many variables? <asp:TextBox Runat=server id=txtCount text=0 />
		<asp:CompareValidator runat=server ControlToValidate=txtCount 
			Operator=DataTypeCheck 
			Type=Integer 
			ErrorMessage='Must be an integer' 
			Display=Dynamic />		
		<br><br>
		<asp:Button Runat=server ID=btnSubmit Text='Create them' /><br><br>
		<asp:Label Runat=server ID=lblOutput />
     </form>	
  </body>
</HTML>
