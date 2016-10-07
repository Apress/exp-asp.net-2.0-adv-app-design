<%@ Page Language="C#" 
    CodeFile="SetupSqlCache.aspx.cs" 
    Inherits="SetupSqlCache_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddlDatabase" Runat="server" 
            AutoPostBack=true 
            OnSelectedIndexChanged="ddlDatabase_SelectedIndexChanged" />
        <br /><br />
        <asp:GridView AutoGenerateColumns=false ID="gvTables" Runat="server" 
            BorderWidth="1px" BackColor="White" CellPadding="4" 
            BorderStyle="None" BorderColor="#3366CC">
            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
            <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC"></PagerStyle>
            <HeaderStyle ForeColor="#CCCCFF" Font-Bold="True" BackColor="#003399"></HeaderStyle>
            <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
            <RowStyle ForeColor="#003399" BackColor="White"></RowStyle>
            <AlternatingRowStyle ForeColor=White BackColor=DodgerBlue />
            <Columns>
                <asp:BoundField DataField='name' HeaderText='Table Name' />
                
                <asp:TemplateField HeaderText='Configured'>
                    <ItemTemplate>
                    <asp:checkbox  runat='server' 
                        TableName='<%# Eval("name") %>' 
                        Checked='<%# Convert.ToBoolean(Eval("Configured")) %>'  
                        OnCheckedChanged='FlipBit' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>            
        </asp:GridView>
        
        <asp:button Runat=server id=btnSave 
            Text='Save Changes' 
            OnClick="btnSave_Click" 
            Visible="False" /> 
               
        <asp:Button ID="Button1" Runat="server" 
            Text="Enable this Database" 
            OnClick="Button1_Click"
            Visible="False" />
    </form>
</body>
</html>
