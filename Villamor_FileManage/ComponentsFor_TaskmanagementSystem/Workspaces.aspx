<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Workspaces.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.Workspaces" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Workspaces</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">
    <link href="wpstylesheet.css" rel="stylesheet">
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
                <a href="#" onclick="openModal()">Create</a>
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
                <a>Workspaces</a>
                <div class="dropdown">
                    <a href="#" class="dropbtn">My Workspace</a>
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
                    <a class="active">AssignIt Workspace</a>
                </div>
                <hr />
            </div>
        </div>

        <!-- Modal -->
        <div class="modal1" id="modal1">
            <div class="modal-content">
                <div class="modal-header">
                    <h3>Create New Workspace</h3>
                    <span class="close-btn" onclick="closeModal()">×</span>
                </div>
                <div class="modal-body">
                    <!-- Workspace Name -->
                    <input type="text" id="workspaceName" class="input-field" placeholder="Enter workspace name" />
                    
                    <!-- Workspace Description -->
                    <textarea id="workspaceDescription" class="input-field" placeholder="Enter workspace description (optional)"></textarea>
                    
                    <!-- Hidden Field for CreatedBy -->
                    <input type="hidden" id="createdBy" value="User123" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="cancel-btn" onclick="closeModal()">Cancel</button>
                    <button type="button" class="create-btn" onclick="createWorkspace()">Create</button>
                </div>
            </div>
        </div>
    </form>

    <script>
        function openModal() {
            const modal = document.getElementById('modal1');
            modal.style.display = 'block';
            modal.classList.add('show');
            document.getElementById('workspaceName').focus();
        }

        function closeModal() {
            const modal = document.getElementById('modal1');
            modal.classList.remove('show');
            setTimeout(() => {
                modal.style.display = 'none';
                document.getElementById('workspaceName').value = '';
                document.getElementById('workspaceDescription').value = '';
            }, 200);
        }

        function createWorkspace() {
            const workspaceName = document.getElementById('workspaceName').value.trim();
            const workspaceDescription = document.getElementById('workspaceDescription').value.trim();
            const createdBy = document.getElementById('createdBy').value;

            if (!workspaceName) {
                alert('Please enter a workspace name!');
                return;
            }

            // Send data to the server (or process locally for now)
            fetch('Workspaces.aspx/CreateWorkspace', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    workspaceName: workspaceName,
                    workspaceDescription: workspaceDescription,
                    createdBy: createdBy
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.d) { // 'd' contains the response from the server
                        alert(data.d);
                        location.reload(); // Reload the page to reflect new workspace
                    }
                })
                .catch(error => console.error('Error:', error));
        }

        // Close modal when clicking outside
        window.onclick = function (event) {
            const modal = document.getElementById('modal1');
            if (event.target === modal) {
                closeModal();
            }
        };
    </script>
</body>
</html>