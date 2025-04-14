using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CantLoginButton_Click(object sender, EventArgs e)
        {
            // Add your logic for "Can't log in?" button click here
            Response.Redirect("Recovery.aspx");
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            // Add your logic for "Create an account" button click here
            Response.Redirect("Register.aspx");
        }

        protected void continueButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}