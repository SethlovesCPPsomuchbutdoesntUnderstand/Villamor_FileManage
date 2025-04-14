using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Recovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnToLoginButton_Click(object sender, EventArgs e)
        {
            // Add your logic for "Return to log in" button click here
            Response.Redirect("Login.aspx");
        }
    }
}