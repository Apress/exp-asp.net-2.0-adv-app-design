<%@ Page Language="C#" 
         CodeFile="Callback.aspx.cs" 
         Inherits="Callback" %>
<html>
<head runat="server">
    <title>Pool Halls</title>
    <script language=javascript>
        function DisplayAddress(address, context) 
        {
            document.all.dAddress.innerHTML = address;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Pool Hall Lookup</h4>       
        <asp:DropDownList Runat=server ID=ddlListA 
                          onchange='populateListB();' />        
        <br /><br />    
        <select  id=ddlListB onchange='GetAddress();'>
        </select>
        <br /><br />
        <div id=dAddress style="font-family:Verdana;color:Navy;"></div>    
    </form>
</body>
</html>
