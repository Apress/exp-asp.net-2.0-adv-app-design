<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scripting1.aspx.cs" Inherits="Scripting1" %>
<html>
<head runat="server">
    <title>Pool Halls</title>
    <asp:PlaceHolder Runat=server ID=plScript />
    <script language=javascript>
        
        function populateListB()
        {
        
        itemarray = 
            listsB[document.all.ddlListA.selectedIndex];
        valuearray = 
            valuesB[document.all.ddlListA.selectedIndex];	
        ctlListB = 
            document.all.ddlListB;
        for (i=ctlListB.options.length; i>0; i--)
        {ctlListB.options[i] = null;}

        for (i=0; i<itemarray.length; i++)
        {ctlListB.options[i] = new Option(itemarray[i],valuearray[i]);}
          
        }  
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Pool Halls</h4>       
        <asp:DropDownList 
            Runat=server 
            ID=ddlListA 
            onchange='populateListB();'  />
        <br /><br />
        <asp:DropDownList 
            Runat=server 
            ID=ddlListB 
            onchange='alert(this.value);' />    
    </form>
</body>
</html>
