<%@ Page Language="C#" 
         CodeFile="ParamIE.aspx.cs" 
         Inherits="ParamIE" %>
<html>
<head runat="server">
    <title>Param IE</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource Runat=server ID=sdsPublishers
        ConnectionString="<%$ ConnectionStrings:pubsConn %>"
        SelectCommand="select pub_id, pub_name from publishers" />

        <asp:DropDownList Runat=server ID=ddlPublishers
        DataSourceID='sdsPublishers'
        DataTextField='pub_name' 
        AutoPostBack=true
        DataValueField='pub_id' 
         />
 
        <asp:SqlDataSource Runat=server ID=sdsTitles
        ConnectionString="<%$ ConnectionStrings:pubsConn %>"
        SelectCommand="select * from titles where pub_id = @id">
        <SelectParameters>
            <asp:ControlParameter 
            ControlID=ddlPublishers 
            PropertyName=SelectedValue 
            Name="id" />
        </SelectParameters>
        </asp:SqlDataSource>
 
        <asp:GridView Runat=server ID=gvTitles 
        DataSourceID=sdsTitles />

    </form>
</body>
</html>
