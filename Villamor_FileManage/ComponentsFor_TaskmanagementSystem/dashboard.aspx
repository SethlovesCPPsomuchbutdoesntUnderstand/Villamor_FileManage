<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">
    <link href="dashboardstylesheet.css" rel="stylesheet">
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
                    <a class="active1">AssignIt Workspace</a>
                </div>
                <hr />
                <div>
                    <h3>Boards</h3>
                    <h4>My Boards</h4>
                    <div class="boardcontainer" id="boardContainer">
                        <!-- Dynamic Boards will appear here -->
                    </div>
                </div>
                <!-- Modal -->
                <div class="modal1" id="modal1">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3>Create New Board</h3>
                            <span class="close-btn" onclick="closeModal()">×</span>
                        </div>
                        <div class="modal-body">
                            <input type="text" id="boardName" class="input-field" placeholder="Enter board name" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="cancel-btn" onclick="closeModal()">Cancel</button>
                            <button type="button" class="create-btn" onclick="createBoard()">Create</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        const boardContainer = document.getElementById('boardContainer');
        const boardModal = document.getElementById('modal1');
        const boardNameInput = document.getElementById('boardName');

        function openModal() {
            boardModal.style.display = 'block';
            boardModal.classList.add('show');
            boardNameInput.focus();
        }

        function closeModal() {
            boardModal.classList.remove('show');
            setTimeout(() => {
                boardModal.style.display = 'none';
                boardNameInput.value = '';
            }, 200);
        }

        function createBoard() {
            const boardName = boardNameInput.value.trim();
            if (!boardName) {
                alert('Please enter a board name!');
                return;
            }

            // Create board element
            const board = document.createElement('div');
            board.className = 'board1';

            const boardTitle = document.createElement('h3');
            boardTitle.textContent = boardName;
            boardTitle.style.color = '#fff';

            const addListButton = document.createElement('button');
            addListButton.textContent = 'Add List';
            addListButton.className = 'add-card-btn';
            addListButton.onclick = function () {
                const listName = prompt('Enter list name:');
                if (listName) {
                    createList(board, listName);
                }
            };

            board.appendChild(boardTitle);
            board.appendChild(addListButton);
            boardContainer.appendChild(board);

            closeModal();
        }

        function createList(board, listName) {
            // Create list element
            const list = document.createElement('div');
            list.className = 'list';

            const listTitle = document.createElement('h4');
            listTitle.textContent = listName;

            const addCardButton = document.createElement('button');
            addCardButton.textContent = 'Add Card';
            addCardButton.className = 'add-card-btn';
            addCardButton.onclick = function () {
                const cardName = prompt('Enter card name:');
                if (cardName) {
                    createCard(list, cardName);
                }
            };

            list.appendChild(listTitle);
            list.appendChild(addCardButton);
            board.appendChild(list);
        }

        function createCard(list, cardName) {
            // Create card element
            const card = document.createElement('div');
            card.className = 'card';
            card.textContent = cardName;
            list.appendChild(card);
        }

        // Close modal when clicking outside
        window.onclick = function (event) {
            if (event.target === boardModal) {
                closeModal();
            }
        };
    </script>
</body>
</html>