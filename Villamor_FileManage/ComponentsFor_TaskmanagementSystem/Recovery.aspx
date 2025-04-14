<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recovery.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.Recovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recovery Form</title>
    <link rel="stylesheet" type="text/css" href="recoverystylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <div class="logo">
                    <h1>AssignIt</h1>
                </div>
                <h2>Can't log in?</h2>
                <p>We'll send a recovery link to</p>
                <asp:TextBox ID="emailTextBox" runat="server" placeholder="Enter email" CssClass="email-input" TextMode="Email" />
                <asp:Button ID="sendRecoveryLinkButton" runat="server" Text="Send recovery link" CssClass="send-recovery-link-button" />
                <asp:Button ID="returnToLoginButton" runat="server" Text="Return to log in" CssClass="link-button" OnClick="ReturnToLoginButton_Click" />
                <div class="footer">
                    <p>One account for AssignIt, Jira, Confluence and more.</p>
                    <p>Login help · Contact Support</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>