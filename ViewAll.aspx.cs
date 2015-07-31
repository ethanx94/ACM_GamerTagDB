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
        outputLabel.Text = "";
        removeButton.Visible = false;

        // Remove row pertaining to current user's name stored in current session
        string deleteCommand = "DELETE FROM [dbo].[Table] WHERE name = '" + Session.Contents[0] + "'";
        SqlDataSource1.DeleteCommand = deleteCommand;
        SqlDataSource1.Delete();

        outputLabel.Text = "<br />" + Session.Contents[0] + ", your gamertag(s) have been deleted! <a href =\"./GamerTag.aspx\">Add a new entry?</a>";

        // Clear the session
        Session.Clear();
    }
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        outputLabel.Text = "";
        delInputPanel.Visible = true;
        removeButton.Visible = false;
    }

    protected void confirmButton_Click(object sender, EventArgs e)
    {
        delInputPanel.Visible = false;

        // Remove row pertaining to provided deletion key
        string deleteCommand = "DELETE FROM [dbo].[Table] WHERE delkey = '" + delInputBox.Text + "'";
        SqlDataSource1.DeleteCommand = deleteCommand;
        
        if (SqlDataSource1.Delete() == 1)
            outputLabel.Text = "<br /> Your gamertag(s) have been deleted! <a href =\"./GamerTag.aspx\">Add a new entry?</a>";
        else
            outputLabel.Text = "<br /> Incorrect key provided. <a href =\"./GamerTag.aspx\">Add a new entry?</a>";

    }
}