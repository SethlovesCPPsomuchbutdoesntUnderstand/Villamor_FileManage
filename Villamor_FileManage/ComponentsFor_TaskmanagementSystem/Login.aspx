<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link rel="stylesheet" type="text/css" href="loginstylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <div class="logo">
                    <h1>AssignIt</h1>
                </div>
                <h2>Log in to continue</h2>
                <asp:TextBox ID="emailTextBox" runat="server" placeholder="Enter your email" CssClass="email-input" TextMode="Email" />
                <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Enter your password" CssClass="password-input" TextMode="Password" />
                <div class="remember-me">
                    <asp:CheckBox ID="rememberMeCheckBox" runat="server" Text="Remember me" />
                </div>
                <asp:Button ID="continueButton" runat="server" Text="Continue" CssClass="continue-button" OnClick="continueButton_Click" />
                
                <div class="action-buttons">
                    <asp:Button ID="cantLoginButton" runat="server" Text="Can't log in?" CssClass="link-button" OnClick="CantLoginButton_Click" />
                    <asp:Button ID="createAccountButton" runat="server" Text="Create an account" CssClass="link-button" OnClick="CreateAccountButton_Click" />
                </div>
                <div class="footer">
                    <p>One account for AssignIt, Jira, Confluence and more.</p>
                    <p>Privacy Policy · User Notice</p>
                    <p>This site is protected by reCAPTCHA and the Google Privacy Policy and Terms of Service apply.</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>