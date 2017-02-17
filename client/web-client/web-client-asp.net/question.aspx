<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="Quiz.question" %>

<!DOCTYPE html>

<html>
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Quiz - Question</title>
    </head>
	<body>
		<form id="form1" runat="server">
			Title :
			<asp:TextBox ID="Question_Title" runat="server"/><br/>
			Picture (optional) :
			<asp:FileUpload ID="Question_Picture" runat="server"/>
            <br/><br/>
			<fieldset>
				<legend>Answer 1</legend>
				Title :<br/>
				<asp:TextBox ID="Answer_Title_1" runat="server" /><br/>		
				Correct :
                <br/>
				<asp:RadioButton ID="Answer_True_1" runat="server" Text="True" GroupName="Answer_Correct_1"/>
                <br/>	
				<asp:RadioButton ID="Answer_False_1" runat="server" Text="False" Checked="true" GroupName="Answer_Correct_1"/>
                <br/>
				Picture (optional) :
				<asp:FileUpload ID="Answer_Picture_1" runat="server"/><br/><br/>
			</fieldset>
			<fieldset>
				<legend>Answer 2</legend>
				Title :<br/>
				<asp:TextBox ID="Answer_Title_2" runat="server"/><br/>
				Correct :
                <br/>
				<asp:RadioButton ID="Answer_True_2" runat="server" Text="True" GroupName="Answer_Correct_2"/>
                <br/>	
				<asp:RadioButton ID="Answer_False_2" runat="server" Text="False" Checked="true" GroupName="Answer_Correct_2"/>
                <br/>
				Picture (optional) :
				<asp:FileUpload ID="Answer_Picture_2" runat="server"/><br/><br/>
			</fieldset>
			<fieldset>
				<legend>Answer 3</legend>
				Title :<br/>
				<asp:TextBox ID="Answer_Title_3" runat="server"/><br/>
				Correct :
                <br/>
				<asp:RadioButton ID="Answer_True_3" runat="server" Text="True" GroupName="Answer_Correct_3"/>
                <br/>	
				<asp:RadioButton ID="Answer_False_3" runat="server" Text="False" Checked="true" GroupName="Answer_Correct_3"/>
                <br/>
				Picture (optional) :
				<asp:FileUpload ID="Answer_Picture_3" runat="server"/><br/><br/>
			</fieldset>
			<fieldset>
				<legend>Answer 4</legend>
				Title :<br/>
				<asp:TextBox ID="Answer_Title_4" runat="server"/><br/>	
				Correct :
                <br/>
				<asp:RadioButton ID="Answer_True_4" runat="server" Text="True" GroupName="Answer_Correct_4"/>
                <br/>	
				<asp:RadioButton ID="Answer_False_4" runat="server" Text="False" Checked="true" GroupName="Answer_Correct_4"/>
                <br/>
				Picture (optional) :
				<asp:FileUpload ID="Answer_Picture_4" runat="server"/><br/><br/>
			</fieldset>
            <asp:Button ID="Validate" runat="server" Text="Validate" OnClick="Validate_Click" />
        </form>
	</body>
</html>
