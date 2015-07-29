using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAll : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // Only give user option to remove if there is an active session
        if (Session.Count != 0)
        {
            removeButton.Visible = true;
        }
    }

    protected void removeButton_Click(object sender, EventArgs e)
    {
        removeButton.Visible = false;

        // Remove row pertaining to current user's name stored in current session
        string deleteCommand = "DELETE FROM [dbo].[Table] WHERE name = '" + Session.Contents[0] + "'";
        SqlDataSource1.DeleteCommand = deleteCommand;
        SqlDataSource1.Delete();

        outputLabel.Text += "<br />" + Session.Contents[0] + ", your gamertag(s) have been deleted! <a href =\"./GamerTag.aspx\">Add a new entry?</a>";
    }
}