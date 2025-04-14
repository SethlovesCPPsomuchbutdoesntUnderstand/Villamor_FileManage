<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member</title>
    <link href="memberstylesheet.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <div class="nav1">
                <a class="active" href="dashboard.aspx">AssignIt</a>
                <a href="#">Workspaces</a>
                <a href="#">Recent</a>
                <a href="#">Starred</a>
                <a href="#">Template</a>
                <a href="#">Create</a>
            </div>
            <div class="nav2">
                <input type="text" placeholder="Search..." />
                <a href="#">Notification</a>
                <a href="#">Settings</a>
                <a href="#">Account</a>
            </div>
        </div>

        <div class="parent">
            <div class="div1">
                <a href="#">Boards</a>
                <a href="#">Templates</a>
                <a href="#">Home</a>
                <hr />
                <div class="dropdown">
                    <a href="#" class="dropbtn">Workspaces</a>
                    <div class="dropdown-content">
                        <a href="#">Getting Started</a>
                        <a href="#">Boards</a>
                        <a href="#">Views</a>
                        <a href="#">Members</a>
                        <a href="#">Settings</a>
                    </div>
                </div>
            </div>
            <div class="div2">
                <div class="logosec">
                    <a class="active" >AssignIt Workspace</a>
                </div><hr />
                <div class="conts">
                     <div class="div21">
                         <div class="div11">
                             <header>
                                 <h3>Collaborators (#)</h3>
                             </header>
                         </div>
                         <div class="div11">
                             <div class="div121">
                                 <ul class="collabs" style="list-style: none;">
                                     <li class="collab"><a>Workspace Members (#)</a></li>
                                     <li class="collab"><a>Guest</a></li><hr />
                                     <li class="collab"><a>Join Requests</a></li>
                                 </ul>
                             </div>
                         </div>
                         
 
                     <div class="div21">
                         <div class="div22">
                             <div class="div131">
                                 <h3>Workspace Members (#)</h3>
                                 <p>Workspace members can view and join all Workspace visible boards and create new boards in the Workspace. Adding new members will automatically update your billing.</p>
                             </div>
                             <div class="div131">
                                 <h3>Invite members to Join you </h3>
                                 <p>Anyone with an invite link can join this paid Workspace. You’ll be billed for each member that joins. You can also disable and create a new invite link for this Workspace at any time.</p>
                             </div>
         
                         </div>
                     </div>
                         <!-- Your HTML remains unchanged; only CSS is updated -->
                        <div class="members">
                            <input placeholder="Filter by name" /><hr />
                            <div class="user">
                                <p>Renie Joshua V.</p>
                            </div>
                            <div class="user">
                                <p>Seth Andrew L.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
