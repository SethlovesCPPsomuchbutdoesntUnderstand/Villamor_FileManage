function addCard(listId, listName) {
    var cardTitle = prompt("Enter the title for the new card in " + listName + ":");
    if (cardTitle && cardTitle.trim() !== "") {
        var list = document.getElementById(listId);
        var newCard = document.createElement('div');
        newCard.innerHTML = '<p><input type="checkbox" title="Mark as done" /> ' + cardTitle + '</p>';
        var addButtonDiv = list.querySelector('.add-card-btn').parentElement;
        list.insertBefore(newCard, addButtonDiv);
    } else {
        alert("Bro, you gotta give me a card title!");
    }
}

function addList() {
    var listName = prompt("What’s the name of this new list, bro?");
    if (listName && listName.trim() !== "") {
        var container = document.querySelector('.list-container');
        var newListId = 'list-' + Date.now(); // Unique ID
        var newList = document.createElement('div');
        newList.className = 'list';
        newList.id = newListId;
        newList.innerHTML = `
                    <div><h3>${listName}</h3></div>
                    <div><button class="add-card-btn">Add a card</button></div>
                `;
        var addListButton = document.getElementById('<%= AddListButton.ClientID %>');
        // Insert directly before the "Add another list" button
        container.insertBefore(newList, addListButton);
        // Add event listener to the new "Add a card" button
        newList.querySelector('.add-card-btn').addEventListener('click', function (e) {
            e.preventDefault();
            addCard(newListId, listName);
        });
        console.log("Added list:", newListId); // Debug log
    } else {
        alert("C’mon, bro, name that list!");
    }
}