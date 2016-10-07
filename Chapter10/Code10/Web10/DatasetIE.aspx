<%@ Page Language="C#" 
CodeFile="DatasetIE.aspx.cs" 
Inherits="DatasetIE_aspx" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DataSet IE</title>
</head>
<body>
    <form id="form1" runat="server">    
        <asp:DropDownList Runat=server ID=ddlPub 
            AutoPostBack=true 
            OnSelectedIndexChanged="ddlPub_SelectedIndexChanged" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        Average Price:&nbsp;&nbsp;<asp:Label Runat=server ID=lblAvgPrice EnableViewState=false />
        <br /><br />            
        <asp:GridView Runat=server ID=gvTitle 
            enableviewstate=false
            BorderWidth="1px" 
            BackColor="White" 
            GridLines="Vertical" 
            CellPadding="4" 
            BorderStyle="None" 
            BorderColor="#DEDFDE" 
            ForeColor="Black">
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle ForeColor="Black" 
                HorizontalAlign="Right" 
                BackColor="#F7F7DE" />                
            <HeaderStyle ForeColor="White" 
                Font-Bold="True" 
                BackColor="#6B696B" />                
            <AlternatingRowStyle BackColor="White" />
            <SelectedRowStyle ForeColor="White" 
                Font-Bold="True" 
                BackColor="#CE5D5A" />                
            <RowStyle BackColor="#F7F7DE" />            
        </asp:GridView>
    </form>
</body>
</html>

