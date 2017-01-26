<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quiz._Default" %>

<html>
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Quiz - Home</title>
    </head>
	<body>
        <form id="form1" action="question" method="post" runat="server">
			Title :
			<asp:TextBox ID="Quiz_Title" runat="server"/><br/>
			Description :
			<asp:TextBox ID="Quiz_Description" runat="server"/><br/>
            Summary :
			<asp:TextBox ID="Quiz_Summary" runat="server"/><br/>
            <asp:Button ID="Validate" runat="server" Text="Validate" OnClick="Validate_Click" />
            <asp:HiddenField ID="Quiz_Id" runat="server" />
        </form>
	</body>
</html>

