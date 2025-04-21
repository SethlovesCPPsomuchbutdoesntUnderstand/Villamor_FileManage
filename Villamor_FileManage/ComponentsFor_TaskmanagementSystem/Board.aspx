<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Board.aspx.cs" Inherits="Villamor_FileManage.ComponentsFor_TaskmanagementSystem.Board" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Board</title>
    <link href="board.css" rel="stylesheet" />
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            // Modal elements
            var cardModal = document.getElementById('new-card-modal');
            var listModal = document.getElementById('new-list-modal');
            var assignModal = document.getElementById('assign-to-someone-modal');
            var cardInput = document.getElementById('new-card-input');
            var listInput = document.getElementById('new-list-input');
            var assignInput = document.getElementById('assign-to-someone-input');
            var cardSubmit = document.getElementById('new-card-submit');
            var cardCancel = document.getElementById('new-card-cancel');
            var listSubmit = document.getElementById('new-list-submit');
            var listCancel = document.getElementById('new-list-cancel');
            var assignSubmit = document.getElementById('assign-to-someone-submit');
            var assignCancel = document.getElementById('assign-to-someone-cancel');

            // Variables to store current context
            var currentListId, currentListName, currentCardElement;

            // Add event listener for "Add another list" button
            document.getElementById('<%= AddListButton.ClientID %>').addEventListener('click', function (e) {
                e.preventDefault();
                showListModal();
            });

            // Add event listeners for existing "Assign" buttons
            document.querySelectorAll('.assign-to-someone--btn').forEach(function (btn) {
                btn.addEventListener('click', function (e) {
                    e.preventDefault();
                    showAssignModal(this.closest('p'));
                });
            });

            // Drag and Drop setup for existing cards
            setupDragAndDrop();

            // Show card modal
            function showCardModal(listId, listName) {
                currentListId = listId;
                currentListName = listName;
                cardModal.style.display = 'block';
                cardInput.value = '';
                cardInput.focus();
            }

            // Show list modal
            function showListModal() {
                listModal.style.display = 'block';
                listInput.value = '';
                listInput.focus();
            }

            // Show assign modal
            function showAssignModal(cardElement) {
                currentCardElement = cardElement;
                assignModal.style.display = 'block';
                assignInput.value = '';
                assignInput.focus();
            }

            // Hide modals
            function hideModals() {
                cardModal.style.display = 'none';
                listModal.style.display = 'none';
                assignModal.style.display = 'none';
            }

            // Drag and Drop functions
            function setupDragAndDrop() {
                document.querySelectorAll('.list p').forEach(function (card) {
                    setupDragAndDropForCard(card);
                });
                document.querySelectorAll('.list').forEach(function (list) {
                    setupDropZone(list);
                });
            }

            function setupDragAndDropForCard(card) {
                card.addEventListener('dragstart', function (e) {
                    e.dataTransfer.setData('text/plain', 'card'); // Dummy data
                    this.classList.add('dragging');
                    setTimeout(() => this.style.display = 'none', 0); // Hide during drag
                });

                card.addEventListener('dragend', function () {
                    this.classList.remove('dragging');
                    this.style.display = ''; // Show again
                });
            }

            function setupDropZone(list) {
                list.addEventListener('dragover', function (e) {
                    e.preventDefault(); // Allow drop
                    this.classList.add('drag-over');
                });

                list.addEventListener('dragleave', function () {
                    this.classList.remove('drag-over');
                });

                list.addEventListener('drop', function (e) {
                    e.preventDefault();
                    this.classList.remove('drag-over');
                    var card = document.querySelector('.dragging');
                    if (card) {
                        var addButtonDiv = this.querySelector('.add-card-btn').parentElement;
                        this.insertBefore(card.parentElement, addButtonDiv); // Move the card’s <div>
                    }
                });
            }

            // Modal button listeners
            cardSubmit.addEventListener('click', hideModals);
            cardCancel.addEventListener('click', hideModals);
            listSubmit.addEventListener('click', hideModals);
            listCancel.addEventListener('click', hideModals);
            assignSubmit.addEventListener('click', hideModals);
            assignCancel.addEventListener('click', hideModals);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <div class="nav1">
                <a class="active" href="dashboard.aspx#active">AssignIt</a>
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
                    <a class="active">AssignIt Workspace</a>
                </div>
                <hr />
                <div id="listContainer" runat="server" class="list-container">
                    <!-- Dynamic lists will be generated here by the backend -->
                </div>
                <asp:Button ID="AddListButton" runat="server" Text="Add another list" CssClass="add-list-btn" />
                <!-- New Card Modal -->
                <div class="modal" id="new-card-modal">
                    <div class="modal-content">
                        <h3>Add a New Card</h3>
                        <input type="text" id="new-card-input" placeholder="Enter card name" />
                        <div class="modal-buttons">
                            <button type="button" id="new-card-submit" class="modal-submit-btn">Add</button>
                            <button type="button" id="new-card-cancel" class="modal-cancel-btn">Cancel</button>
                        </div>
                    </div>
                </div>
                <!-- New List Modal -->
                <div class="modal" id="new-list-modal">
                    <div class="modal-content">
                        <h3>Add a New List</h3>
                        <input type="text" id="new-list-input" placeholder="Enter list name" />
                        <div class="modal-buttons">
                            <button type="button" id="new-list-submit" class="modal-submit-btn">Add</button>
                            <button type="button" id="new-list-cancel" class="modal-cancel-btn">Cancel</button>
                        </div>
                    </div>
                </div>
                <!-- Assign to Someone Modal -->
                <div class="modal" id="assign-to-someone-modal">
                    <div class="modal-content">
                        <h3>Assign Task</h3>
                        <input type="text" id="assign-to-someone-input" placeholder="Assign to example@email.com" />
                        <div class="modal-buttons">
                            <button type="button" id="assign-to-someone-submit" class="modal-submit-btn">Assign</button>
                            <button type="button" id="assign-to-someone-cancel" class="modal-cancel-btn">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>