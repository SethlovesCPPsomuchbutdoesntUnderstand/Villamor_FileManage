using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Workspaces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWorkspaces();
            }
        }

        private void LoadWorkspaces()
        {
            // Connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;

            // SQL query to fetch all workspaces
            string query = "SELECT Name FROM Workspaces WHERE IsActive = 1 ORDER BY CreatedAt DESC";

            // Locate the div1 container
            HtmlGenericControl div1 = (HtmlGenericControl)FindControl("div1");

            // Connect to the database to fetch workspaces
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Dynamically generate dropdowns for each workspace
                while (reader.Read())
                {
                    string workspaceName = reader["Name"].ToString();

                    // Create new dropdown container
                    HtmlGenericControl dropdown = new HtmlGenericControl("div");
                    dropdown.Attributes["class"] = "dropdown";

                    // Add the main dropdown button
                    HtmlAnchor dropbtn = new HtmlAnchor
                    {
                        HRef = "#",
                        InnerText = workspaceName
                    };
                    dropbtn.Attributes["class"] = "dropbtn";

                    // Create the dropdown content container
                    HtmlGenericControl dropdownContent = new HtmlGenericControl("div");
                    dropdownContent.Attributes["class"] = "dropdown-content";

                    // Add links to the dropdown content
                    string[] links = { "Getting Started", "Boards", "Views", "Members", "Settings" };
                    foreach (string linkText in links)
                    {
                        HtmlAnchor link = new HtmlAnchor
                        {
                            HRef = "#",
                            InnerText = linkText
                        };
                        dropdownContent.Controls.Add(link);
                    }

                    // Add the dropdown button and content to the dropdown container
                    dropdown.Controls.Add(dropbtn);
                    dropdown.Controls.Add(dropdownContent);

                    // Add the dropdown to the div1 container
                    div1.Controls.Add(dropdown);
                }
            }
        }
    }
}