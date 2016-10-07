<%@ Page Language="C#" CodeFile="Filtering.aspx.cs" Inherits="Filtering_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList Runat=server ID=ddlState 
            AutoPostBack="True" 
            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" />
        <asp:GridView Runat=server ID=gvAuthors 
            EnableViewState=False 
            BorderWidth="1px" 
            BackColor="LightGoldenrodYellow" 
            GridLines="None" 
            CellPadding="2" 
            BorderColor="Tan" 
            ForeColor="Black">
            <FooterStyle BackColor="Tan" />
            <PagerStyle ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" 
                BackColor="PaleGoldenrod" />
            <HeaderStyle Font-Bold="True" 
                BackColor="Tan" />  
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <SelectedRowStyle ForeColor="GhostWhite" 
                BackColor="DarkSlateBlue" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
