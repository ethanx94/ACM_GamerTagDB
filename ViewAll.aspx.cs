using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAll : System.Web.UI.Page
{
    // Plaintext admin password for demonstration purposes
    private const string PASS = "Fidelio";
    private const string ADDNEW = "<a href =\"./GamerTag.aspx\">Add a new entry?</a>";

    // String that will become SQL DeleteCommand
    private string deleteCommand = "DELETE FROM [dbo].[Table] WHERE";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // Only give user option to remove if there is an active session
        if (Session.Count != 0)
        {
            removeButton.Visible = true;
        }
    }

    // Remove row pertaining to user's name stored in current session
    protected void removeButton_Click(object sender, EventArgs e)
    {
        clearPanels();
        removeButton.Visible = false;

        // Access session's contents to create SQL deletion string
        deleteCommand += " name = '" + Session.Contents[0] + "'";
        SqlDataSource1.DeleteCommand = deleteCommand;

        // Upon successful deletion
        if (SqlDataSource1.Delete() == 1)
            outputLabel.Text = "<br />" + Session.Contents[0] + ", your gamertag(s) have been deleted! " + ADDNEW;
        
        // Clear the session
        Session.Clear();
    }

    protected void confirmButton_Click(object sender, EventArgs e)
    {
        // Prevent deleting entries that contain no password
        if (delInputBox.Text.Equals("") && passInputBox.Text.Equals("")) 
        {
            outputLabel.Text = "<br /> Please provide a delete key/password. ";
            return;
        }

        // Remove row pertaining to provided deletion key
        if(delInputPanel.Visible && !delInputBox.Text.Equals(""))
            deleteCommand += " delkey = '" + delInputBox.Text + "'";
        // Remove row pertaining to provided name with correct admin password
        else if (adminPanel.Visible && passInputBox.Text.Equals(PASS))
            deleteCommand += " name = '" + adminDelInputBox.Text + "'";

        SqlDataSource1.DeleteCommand = deleteCommand;

        clearPanels();

        // Upon successful/unsuccessful deletion
        if (SqlDataSource1.Delete() == 1)
            outputLabel.Text = "<br /> Your gamertag(s) have been deleted! ";
        else
            outputLabel.Text = "<br /> Incorrect key provided or name does not exist. ";

        outputLabel.Text += ADDNEW;
        
    }

    /*
     * Reveal Each TextBox's Panel
     */
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        delInputPanel.Visible = true;
        clearPanels(delInputPanel);
    }

    protected void adminLink_Click(object sender, EventArgs e)
    {
        adminPanel.Visible = true;
        clearPanels(adminPanel);
    }

    // Foundation for deletion logic in confirmButton_Click
    private void clearPanels(Panel curPanel = null)
    {
        if (curPanel == adminPanel)
            delInputPanel.Visible = false;
        else if (curPanel == delInputPanel)
            adminPanel.Visible = false;
        else
        { // No parameter provided (Remove Via Session)
            delInputPanel.Visible = false;
            adminPanel.Visible = false;
        }

        outputLabel.Text = "";
    }
}