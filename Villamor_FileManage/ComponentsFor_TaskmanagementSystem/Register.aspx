<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <link rel="stylesheet" type="text/css" href="registration-stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <div class="logo">
                    <h1 class="logo">AssignIt</h1>
                </div>
                <h2>Sign up to continue</h2>
                <asp:TextBox ID="emailTextBox" runat="server" placeholder="Enter your email" CssClass="email-input" TextMode="Email" />
                <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Enter your password" CssClass="password-input" TextMode="Password" />
                <asp:TextBox ID="confirmpasswordTextBox" runat="server" placeholder="Confirm your password" CssClass="confirmpassword-input" TextMode="Password" />

                <p><asp:CheckBox ID="CheckBox1" runat="server" />By signing up, I accept the Atlassian Cloud Terms of Service and acknowledge the Privacy Policy.</p>
                <asp:Button ID="signUpButton" runat="server" Text="Sign up" CssClass="sign-up-button" OnClick="SignUpButton_Click" />
                
                <asp:Button ID="logInButton" runat="server" Text="Already have an AssignIt account? Log in" CssClass="link-button" OnClick="LogInButton_Click" />
                <div class="footer">
                    <p>One account for AssignIt, Jira, Confluence and more.</p>
                    <p>This site is protected by reCAPTCHA and the Google Privacy Policy and Terms of Service apply.</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>