<%@ Page Language="C#" CodeFile="Concurrency3.aspx.cs" Inherits="Concurrency3_aspx" %>
<%@ Register TagPrefix="uc1" 
TagName="Timestamp" 
Src="Timestamp.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Author</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList Runat=server ID=ddlAuthors
            AutoPostBack=true 
            OnSelectedIndexChanged="BindToAuthor" />
        <asp:Panel Runat=server ID=pnEdit Visible=false>
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox Runat=server ID=txtFirstName />
                    </td>            
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox Runat=server ID=txtLastName />
                     </td>            
                </tr>
                <tr><td colspan=2 align=center>
                    <asp:Button Runat=server ID=btnSave 
                        Text='Save' 
                        OnClick="btnSave_Click" />
                </td></tr>
            </table>
            <uc1:Timestamp ID="tsAuthor" Runat="server" />
        </asp:Panel>
        <br /><br /><asp:Label Runat=server ID=lblOutput />
        
    </form>
</body>
</html>
