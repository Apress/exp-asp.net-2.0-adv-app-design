<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeFile="PreRenderIE.aspx.cs" 
         Inherits="PreRenderIE" %>

<%@ Register TagPrefix="uc1" 
             TagName="RenderTextboxes" 
             Src="RenderTextboxes.ascx" %>

<HTML>
    <HEAD>
        <title>PreRenderIE</title>		
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:Label Runat=server ID=lblOutput>
            Change some fields and press the button
            </asp:Label>
            <br>
            <uc1:RenderTextboxes id="RenderTextboxes1" runat="server" />
            <br>
            <asp:Button Runat=server ID=btn Text='Postback' />
        </form>
    </body>
</HTML>
