using System;
using System.Data.SqlClient; // Required for SQL operations
using System.Configuration; // Required to fetch connection string
using System.Web.UI;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            // Redirect to Login page
            Response.Redirect("Login.aspx");
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string confirmPassword = confirmpasswordTextBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                Response.Write("<script>alert('All fields are required.');</script>");
                return;
            }

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match.');</script>");
                return;
            }

            // Hash the password (use a secure hashing library in production)
            string passwordHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["AssignItConnectionString"].ConnectionString;

            // SQL query to insert user data
            string query = "INSERT INTO Users (Email, PasswordHash, CreatedAt) VALUES (@Email, @PasswordHash, GETDATE())";

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
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Registration successful!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Registration failed. Please try again.');</script>");
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