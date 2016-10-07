<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditBook.aspx.cs" Inherits="EditBook" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Books</title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ObjectDataSource ID="odsBookList" runat="server" 
             SelectMethod="GetBookList" 
             TypeName="BookBinding" />
             
        <asp:ListBox ID="lbBookList" runat="server" 
                     DataSourceID="odsBookList"                      
                     Width=600px
                     DataTextField="Title"
                     DataValueField="BookID"
                     Rows=12 AutoPostBack="True" />
        <br /><br />
        <asp:ObjectDataSource ID="odsBookDetail" runat="server" 
             DataObjectTypeName="BookDetails" 
             SelectMethod="GetBook"             
             UpdateMethod="UpdateBook"
             TypeName="BookBinding">            
            <SelectParameters>                
                <asp:ControlParameter ControlID="lbBookList" Name="BookId" 
                    PropertyName="SelectedValue"                     
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        <asp:DetailsView ID="dvEditBook" runat="server" DataKeyNames='BookID'   
            AutoGenerateRows="False" DataSourceID="odsBookDetail" Width=600px
            Height="50px" CellPadding="4" ForeColor="#333333" GridLines="None" 
            OnItemUpdated="dvEditBook_ItemUpdated" >
            <Fields>
                <asp:BoundField DataField=BookID Visible=false />
                <asp:BoundField DataField="Title" HeaderText="Title" 
                                ControlStyle-Width=420px />                
                <asp:BoundField DataField="Publisher" HeaderText="Publisher"
                                ControlStyle-Width=420px />                
                <asp:BoundField DataField="ListPrice" HeaderText="Price"
                                DataFormatString="{0:$#,###.##}"  />
                <asp:BoundField DataField="PageCount" HeaderText="Pages" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:BoundField DataField="PublicationDate" HeaderText="Published"
                                DataFormatString="{0:MM-dd-yyyy}" />
                <asp:BoundField DataField="ScanDate" HeaderText="Scanned"
                                DataFormatString="{0:MM-dd-yyyy}" />
                <asp:CommandField CancelText='x' UpdateText='ok' ShowEditButton="True"  />
            </Fields>
            
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor=CornflowerBlue />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
    </form>
</body>
</html>
