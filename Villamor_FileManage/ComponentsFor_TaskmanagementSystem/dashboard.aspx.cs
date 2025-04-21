using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Workspaces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string workspaceId = Request.QueryString["WorkspaceId"];
                if (!string.IsNullOrEmpty(workspaceId))
                {
                    LoadBoards(workspaceId); // Load boards for the given WorkspaceId
                }
                else
                {
                    LoadWorkspaces(); // Load all workspaces if WorkspaceId is not provided
                }
            }
        }

        private void LoadWorkspaces()
        {
            // Validate if the user is logged in
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["UserId"]);
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;

            // Query to fetch all active workspaces created by the logged-in user
            string query = "SELECT Id, Name, Description FROM Workspaces WHERE IsActive = 1 AND CreatedBy = @CreatedBy ORDER BY CreatedAt DESC";

            // Locate the workspace container
            HtmlGenericControl workspaceContainer = (HtmlGenericControl)FindControl("workspaceContainer");
            if (workspaceContainer == null)
            {
                throw new Exception("workspaceContainer could not be found in the page.");
            }

            workspaceContainer.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CreatedBy", userId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        // Display a message if no workspaces are found
                        HtmlGenericControl noWorkspacesMessage = new HtmlGenericControl("div");
                        noWorkspacesMessage.Attributes["class"] = "no-workspaces";
                        noWorkspacesMessage.InnerText = "No workspaces found.";
                        workspaceContainer.Controls.Add(noWorkspacesMessage);
                    }
                    else
                    {
                        // Dynamically generate workspace items
                        while (reader.Read())
                        {
                            int workspaceId = Convert.ToInt32(reader["Id"]);
                            string workspaceName = reader["Name"].ToString();
                            string workspaceDescription = reader["Description"].ToString();

                            HtmlGenericControl workspaceDiv = new HtmlGenericControl("div");
                            workspaceDiv.Attributes["class"] = "workspace-item";

                            HtmlGenericControl workspaceNameHeading = new HtmlGenericControl("h3");
                            workspaceNameHeading.Attributes["class"] = "workspace-name";
                            workspaceNameHeading.InnerText = workspaceName;
                            workspaceDiv.Controls.Add(workspaceNameHeading);

                            HtmlGenericControl workspaceDescriptionParagraph = new HtmlGenericControl("p");
                            workspaceDescriptionParagraph.Attributes["class"] = "workspace-description";
                            workspaceDescriptionParagraph.InnerText = string.IsNullOrEmpty(workspaceDescription) ? "No description available" : workspaceDescription;
                            workspaceDiv.Controls.Add(workspaceDescriptionParagraph);

                            HtmlGenericControl viewWorkspaceButton = new HtmlGenericControl("button");
                            viewWorkspaceButton.Attributes["class"] = "view-workspace-btn";
                            viewWorkspaceButton.InnerText = "View Workspace";
                            viewWorkspaceButton.Attributes["onclick"] = $"window.location.href='Board.aspx?WorkspaceId={workspaceId}'";
                            workspaceDiv.Controls.Add(viewWorkspaceButton);

                            workspaceContainer.Controls.Add(workspaceDiv);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log the error and display a user-friendly message
                    System.Diagnostics.Debug.WriteLine($"Error loading workspaces: {ex.Message}");
                    HtmlGenericControl errorMessage = new HtmlGenericControl("div");
                    errorMessage.Attributes["class"] = "error-message";
                    errorMessage.InnerText = "An error occurred while loading workspaces. Please try again later.";
                    workspaceContainer.Controls.Add(errorMessage);
                }
            }
        }

        private void LoadBoards(string workspaceId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;
            string query = "SELECT BoardId, Name FROM Boards WHERE WorkspaceId = @WorkspaceId AND IsActive = 1";

            HtmlGenericControl boardContainer = (HtmlGenericControl)FindControl("boardContainer");
            if (boardContainer == null)
            {
                throw new Exception("boardContainer could not be found in the page.");
            }

            boardContainer.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@WorkspaceId", workspaceId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int boardId = Convert.ToInt32(reader["BoardId"]);
                        string boardName = reader["Name"].ToString();

                        HtmlGenericControl boardDiv = new HtmlGenericControl("div");
                        boardDiv.Attributes["class"] = "board-item";

                        HtmlGenericControl boardNameHeading = new HtmlGenericControl("h3");
                        boardNameHeading.InnerText = boardName;
                        boardDiv.Controls.Add(boardNameHeading);

                        HtmlGenericControl viewBoardButton = new HtmlGenericControl("button");
                        viewBoardButton.Attributes["class"] = "view-board-btn";
                        viewBoardButton.InnerText = "Open Board";
                        viewBoardButton.Attributes["onclick"] = $"window.location.href='BoardDetails.aspx?BoardId={boardId}'";
                        boardDiv.Controls.Add(viewBoardButton);

                        boardContainer.Controls.Add(boardDiv);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log the error for debugging
                    System.Diagnostics.Debug.WriteLine($"Error loading boards: {ex.Message}");
                    throw;
                }
            }
        }

        protected void CreateWorkspaceButton_Click(object sender, EventArgs e)
        {
            string workspaceName = Request.Form["workspaceName"]?.Trim();
            string workspaceDescription = Request.Form["workspaceDescription"]?.Trim();

            if (string.IsNullOrEmpty(workspaceName))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please enter a workspace name!');", true);
                return;
            }

            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            int createdBy = Convert.ToInt32(Session["UserId"]);
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;

            string query = @"INSERT INTO Workspaces (Name, Description, CreatedBy, CreatedAt, IsActive) 
                             VALUES (@Name, @Description, @CreatedBy, @CreatedAt, @IsActive)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", workspaceName);
                command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(workspaceDescription) ? (object)DBNull.Value : workspaceDescription);
                command.Parameters.AddWithValue("@CreatedBy", createdBy);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                command.Parameters.AddWithValue("@IsActive", true);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error creating workspace: {ex.Message}");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to create workspace. Please try again.');", true);
                    return;
                }
            }

            LoadWorkspaces(); // Reload workspaces after creation
        }
    }
}