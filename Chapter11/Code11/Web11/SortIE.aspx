<%@ Page Language="C#" CodeFile="SortIE.aspx.cs" Inherits="SortIE_aspx" %>

<html>
<head runat="server">
    <title>Sort IE</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView Runat=server ID=gvAuthors 
            AllowSorting=True             
            BorderWidth="1px" 
            BackColor="White" 
            GridLines="Vertical" 
            CellPadding="3" 
            BorderStyle="Solid" 
            BorderColor="#999999" 
            ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle ForeColor="Black" 
                HorizontalAlign="Center" 
                BackColor="#999999" />
            <HeaderStyle ForeColor="White" 
                Font-Bold="True" 
                BackColor="Black" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <SelectedRowStyle ForeColor="White" 
                Font-Bold="True" 
                BackColor="#000099" />
        </asp:GridView>
    </form>
</body>
</html>
