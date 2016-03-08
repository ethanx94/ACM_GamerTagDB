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
    private const string ADDNEW = "<a href =\"/\">Add a new entry?</a>";

    // String that will become SQL DeleteCommand
    private string deleteCommand = "DELETE FROM [dbo].[Tags] WHERE";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Set up Gridview, SELECT Statment
        GamerTagDBDataContext dbContext = new GamerTagDBDataContext();
        GridView1.DataSource = from tag in dbContext.Tags
                               orderby tag.name descending
                               select tag;

        GridView1.DataBind();

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
        
        // Session Deletion
        using (GamerTagDBDataContext dbContext = new GamerTagDBDataContext())
        {
            Tag tag = dbContext.Tags.SingleOrDefault(x => x.name == (String)Session.Contents[0]);
            dbContext.Tags.DeleteOnSubmit(tag);
            dbContext.SubmitChanges();
            outputLabel.Text = "<br />" + Session.Contents[0] + ", your gamertag(s) have been deleted! " + ADDNEW;
        }

        // Clear the session
        Session.Clear();
    }

    protected void confirmButton_Click(object sender, EventArgs e)
    {
        using (GamerTagDBDataContext dbContext = new GamerTagDBDataContext())
        {
            Tag tag = null;

            // Prevent deleting entries that contain no password
            if (delInputBox.Text.Equals("") && passInputBox.Text.Equals(""))
            {
                outputLabel.Text = "<br /> Please provide a delete key/password. ";
                return;
            }

            // DelKey Deletion
            if (delInputPanel.Visible && !delInputBox.Text.Equals(""))
                tag = dbContext.Tags.SingleOrDefault(x => x.delkey == delInputBox.Text);
            // Admin Deletion
            else if (adminPanel.Visible && passInputBox.Text.Equals(PASS)) // Need to check empty name
                tag = dbContext.Tags.SingleOrDefault(x => x.name == adminDelInputBox.Text);

            // Excecute Deletion
            if (tag != null)
            {
                dbContext.Tags.DeleteOnSubmit(tag);
                dbContext.SubmitChanges();

                clearPanels();

                // Upon successful/unsuccessful deletion
                outputLabel.Text = "<br />" + adminDelInputBox.Text + ", your gamertag(s) have been deleted! " + ADDNEW;

                
            }
            else
                outputLabel.Text = "<br /> Incorrect key provided or name does not exist. ";

        }
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