<%@ Page Language="C#" 
         CodeFile="au_sorting.aspx.cs" 
         Inherits="au_sorting" %>
<html>
  <head>
    <title>au_sorting</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
        <asp:GridView Runat=server
             ID=DataGrid1 
             EnableViewState=false
             AllowSorting=True OnSorting="SortIt" OnSortCommand="SortIt"   />
                    
        <!--OnPageIndexChanging="DataGrid1_PageIndexChanging" 
        AllowPaging=true PageSize=4 OnPageIndexChanged="DataGrid1_PageIndexChanged" />-->
     </form>
  </body>
</html>



