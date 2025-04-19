using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CantLoginButton_Click(object sender, EventArgs e)
        {
            // Redirect to the recovery page
            Response.Redirect("Recovery.aspx");
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            // Redirect to the registration page
            Response.Redirect("Register.aspx");
        }

        protected void continueButton_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Email and Password are required.');</script>");
                return;
            }

            // Hash the password (use the same hashing method as in registration)
            string passwordHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;

            // SQL query to check if the user exists
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash";

            try
            {
                // Connect to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        connection.Open();
                        int userExists = Convert.ToInt32(command.ExecuteScalar());

                        if (userExists > 0)
                        {
                            // Successful login
                            Response.Write("<script>alert('Login successful!');</script>");
                            // Redirect to the dashboard page
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            // Login failed
                            Response.Write("<script>alert('Invalid email or password.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and display error
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}