<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBindExpr.aspx.cs" Inherits="DataBindExpr" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:datagrid id="dgTitles" Runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
		BackColor="White" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataKeyField='title_id'>
		<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
		<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
		<EditItemStyle ForeColor="Black" BackColor="#999999" />
		<Columns>
			<asp:EditCommandColumn ButtonType="LinkButton" UpdateText='ok' EditText='edit' CancelText='x' />
			<asp:BoundColumn ReadOnly="true" DataField='title_id' HeaderText='Id' />
			<asp:TemplateColumn HeaderText='Title'>
				<ItemTemplate>
					<%# Eval("title") %>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox Runat=server ID=txtTitle 
					Columns=50 
					text='<%# Eval("title") %>' />
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText='Publisher'>
				<ItemTemplate>
					<%# Eval("pub_name") %>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList Runat=server ID=ddlPub 
						DataSource='<%# GetPubList() %>' 
						DataTextField='pub_name' 
						DataValueField='pub_id' />
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText='Type'>
				<ItemTemplate>
					<%# Eval("type") %>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList Runat=server ID="ddlType" 
						DataSource='<%# GetBookTypes() %>' 
						DataTextField='type' />							
				</EditItemTemplate>
			</asp:TemplateColumn>
			
			<asp:TemplateColumn HeaderText='Price'>
				<ItemTemplate>
				<%# string.Format("{0:c}",Eval("price")) %>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox Runat=server id=txtPrice 
						Text='<%# string.Format("{0:#.00}",Eval("PRICE")) %>' />
					<asp:CompareValidator ID="CompareValidator1" runat=server 
						Operator=DataTypeCheck 
						Type=Currency 
						ControlToValidate='txtPrice' 
						Display=Dynamic 
						ErrorMessage='<BR>Please enter price' />
				</EditItemTemplate>
			</asp:TemplateColumn>
			
		</Columns>
	    </asp:datagrid>
    </form>
</body>
</html>
