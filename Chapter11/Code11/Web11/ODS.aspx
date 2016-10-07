<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ODS.aspx.cs" Inherits="ODS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="au_id" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="au_id" HeaderText="au_id" ReadOnly="True" SortExpression="au_id" />
                <asp:BoundField DataField="au_lname" HeaderText="au_lname" SortExpression="au_lname" />
                <asp:BoundField DataField="au_fname" HeaderText="au_fname" SortExpression="au_fname" />
                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                <asp:BoundField DataField="zip" HeaderText="zip" SortExpression="zip" />
                <asp:CheckBoxField DataField="contract" HeaderText="contract" SortExpression="contract" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAuthorsTable" TypeName="AuthorsBOTableAdapters.usp_GetAuthorsTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_au_id" Type="String" />
                <asp:Parameter Name="Original_au_lname" Type="String" />
                <asp:Parameter Name="Original_au_fname" Type="String" />
                <asp:Parameter Name="Original_phone" Type="String" />
                <asp:Parameter Name="Original_address" Type="String" />
                <asp:Parameter Name="Original_city" Type="String" />
                <asp:Parameter Name="Original_state" Type="String" />
                <asp:Parameter Name="Original_zip" Type="String" />
                <asp:Parameter Name="Original_contract" Type="Boolean" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="au_id" Type="String" />
                <asp:Parameter Name="au_lname" Type="String" />
                <asp:Parameter Name="au_fname" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="state" Type="String" />
                <asp:Parameter Name="zip" Type="String" />
                <asp:Parameter Name="contract" Type="Boolean" />
                <asp:Parameter Name="Original_au_id" Type="String" />
                <asp:Parameter Name="Original_au_lname" Type="String" />
                <asp:Parameter Name="Original_au_fname" Type="String" />
                <asp:Parameter Name="Original_phone" Type="String" />
                <asp:Parameter Name="Original_address" Type="String" />
                <asp:Parameter Name="Original_city" Type="String" />
                <asp:Parameter Name="Original_state" Type="String" />
                <asp:Parameter Name="Original_zip" Type="String" />
                <asp:Parameter Name="Original_contract" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="au_id" Type="String" />
                <asp:Parameter Name="au_lname" Type="String" />
                <asp:Parameter Name="au_fname" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="state" Type="String" />
                <asp:Parameter Name="zip" Type="String" />
                <asp:Parameter Name="contract" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp;
    </div>
    </form>
</body>
</html>
