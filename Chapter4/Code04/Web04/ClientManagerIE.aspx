<%@ Page Language="C#" 
         CodeFile="ClientManagerIE.aspx.cs" 
         Inherits="ClientManagerIE" %>
<html>
<head runat="server">
    <title>Client Manager</title>
</head>
<body>
    <form id="form1" runat="server">
    <h4>Pool Halls</h4>       
    <asp:DropDownList 
        Runat=server 
        ID=ddlListA 
        onchange='populateListB();'  />        
    <br /><br />    
    <select id=ddlListB onchange='alert(this.value);' /> 
    </form>
</body>
</html>
