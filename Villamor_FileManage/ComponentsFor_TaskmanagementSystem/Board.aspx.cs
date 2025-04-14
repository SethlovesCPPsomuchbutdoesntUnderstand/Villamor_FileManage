using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Villamor_FileManage.ComponentsFor_TaskmanagementSystem
{
    public partial class Board : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddCardToDo_Click(object sender, EventArgs e)
        {
            // Logic for adding a card to the To-Do list
            Response.Write("Adding a card to To-Do list...");
        }

        protected void AddCardDoing_Click(object sender, EventArgs e)
        {
            // Logic for adding a card to the Doing list
            Response.Write("Adding a card to Doing list...");
        }

        protected void AddCardDone_Click(object sender, EventArgs e)
        {
            // Logic for adding a card to the Done list
            Response.Write("Adding a card to Done list...");
        }

        protected void AddListButton_Click(object sender, EventArgs e)
        {
            // Logic for adding a new list
            Response.Write("Adding a new list...");
        }
    }
}