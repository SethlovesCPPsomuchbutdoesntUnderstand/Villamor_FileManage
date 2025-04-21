using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Board : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string boardId = Request.QueryString["BoardId"];
                if (!string.IsNullOrEmpty(boardId))
                {
                    LoadLists(boardId);
                }
                else
                {
                    Response.Write("Invalid Board ID.");
                }
            }
        }

        private void LoadLists(string boardId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WorkspacesdbConnectionString"].ConnectionString;

            string query = @"
                SELECT 
                    l.ListId, l.Name AS ListName, 
                    c.CardId, c.Name AS CardName, c.Assignee 
                FROM Lists l
                LEFT JOIN Cards c ON l.ListId = c.ListId
                WHERE l.BoardId = @BoardId AND l.IsActive = 1
                ORDER BY l.ListId, c.CreatedAt";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BoardId", boardId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, ListModel> lists = new Dictionary<int, ListModel>();

                while (reader.Read())
                {
                    int listId = Convert.ToInt32(reader["ListId"]);
                    string listName = reader["ListName"].ToString();

                    if (!lists.ContainsKey(listId))
                    {
                        lists[listId] = new ListModel
                        {
                            ListId = listId,
                            Name = listName,
                            Cards = new List<CardModel>()
                        };
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("CardId")))
                    {
                        lists[listId].Cards.Add(new CardModel
                        {
                            CardId = Convert.ToInt32(reader["CardId"]),
                            Name = reader["CardName"].ToString(),
                            Assignee = reader["Assignee"].ToString()
                        });
                    }
                }

                foreach (var list in lists.Values)
                {
                    GenerateListHtml(list);
                }

                reader.Close();
            }
        }

        private void GenerateListHtml(ListModel list)
        {
            HtmlGenericControl listDiv = new HtmlGenericControl("div");
            listDiv.Attributes["class"] = "list";
            listDiv.ID = $"list-{list.ListId}";

            HtmlGenericControl listHeader = new HtmlGenericControl("div");
            listHeader.InnerHtml = $"<h3>{list.Name}</h3>";
            listDiv.Controls.Add(listHeader);

            foreach (var card in list.Cards)
            {
                HtmlGenericControl cardDiv = new HtmlGenericControl("p");
                cardDiv.Attributes["draggable"] = "true";
                cardDiv.InnerHtml = $@"
                    <span class='drag-handle'>☰</span>
                    <input type='checkbox' title='Mark as done' />
                    {card.Name} 
                    <button class='assign-to-someone--btn'>Assign</button>";
                listDiv.Controls.Add(cardDiv);
            }

            HtmlGenericControl addCardDiv = new HtmlGenericControl("div");
            HtmlButton addCardButton = new HtmlButton
            {
                InnerText = "Add a card",
                ID = $"AddCardButton_{list.ListId}"
            };
            addCardButton.Attributes["class"] = "add-card-btn";
            addCardButton.ServerClick += (s, e) => AddCard(list.ListId);
            addCardDiv.Controls.Add(addCardButton);
            listDiv.Controls.Add(addCardDiv);

            listContainer.Controls.Add(listDiv);
        }

        protected void AddCard(int listId)
        {
            string cardName = Request.Form["newCardName"];
            if (string.IsNullOrEmpty(cardName))
            {
                Response.Write("Card name cannot be empty.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["WorkspacesdbConnectionString"].ConnectionString;

            string query = "INSERT INTO Cards (ListId, Name, CreatedAt, IsActive) VALUES (@ListId, @Name, GETDATE(), 1)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListId", listId);
                command.Parameters.AddWithValue("@Name", cardName);

                connection.Open();
                command.ExecuteNonQuery();
            }

            LoadLists(Request.QueryString["BoardId"]);
        }

        protected void AddListButton_Click(object sender, EventArgs e)
        {
            string listName = Request.Form["newListName"];
            if (string.IsNullOrEmpty(listName))
            {
                Response.Write("List name cannot be empty.");
                return;
            }

            string boardId = Request.QueryString["BoardId"];
            if (string.IsNullOrEmpty(boardId))
            {
                Response.Write("Invalid Board ID.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["WorkspacesdbConnectionString"].ConnectionString;

            string query = "INSERT INTO Lists (BoardId, Name, CreatedAt, IsActive) VALUES (@BoardId, @Name, GETDATE(), 1)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BoardId", boardId);
                command.Parameters.AddWithValue("@Name", listName);

                connection.Open();
                command.ExecuteNonQuery();
            }

            LoadLists(boardId);
        }
    }

    public class ListModel
    {
        public int ListId { get; set; }
        public string Name { get; set; }
        public List<CardModel> Cards { get; set; }
    }

    public class CardModel
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Assignee { get; set; }
    }
}