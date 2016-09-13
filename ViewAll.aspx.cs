using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

public partial class ViewAll : System.Web.UI.Page
{
    // Plaintext admin password for demonstration purposes
    private const string PASS = "Fidelio";
    private const string ADDNEW = "<a href =\"/\">Add a new entry?</a>";
    IMongoCollection<BsonDocument> collection = Global.database.GetCollection<BsonDocument>("Tags");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var collection = Global.database.GetCollection<Tags>("Tags");

        var query =
            from tag in collection.AsQueryable()
            orderby tag.name descending
            select new { tag.name, tag.live, tag.psn, tag.steam, tag.wiiu, tag.games};

        var resultList = query.ToList(); //get list of items from mongodb
        GridView1.DataSource = resultList;
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
        var filter = Builders<BsonDocument>.Filter.Eq("name", Session.Contents[0]);
        var result = collection.DeleteOne(filter);

        // Upon successful deletion
        if (result.DeletedCount == 1)
            outputLabel.Text = "<br/>" + Session.Contents[0] + ", your gamertag(s) have been deleted! " + ADDNEW;
        
        // Clear the session
        Session.Clear();
    }

    protected void confirmButton_Click(object sender, EventArgs e)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("delKey", delInputBox.Text); ;
        
        // Prevent deleting entries that contain no password
        if (delInputBox.Text.Equals("") && passInputBox.Text.Equals(""))
        {
            outputLabel.Text = "<br/> Please provide a delete key/password. ";
            return;
        }

        // Remove row pertaining to provided deletion key
        if (delInputPanel.Visible && !delInputBox.Text.Equals(""))
            filter = Builders<BsonDocument>.Filter.Eq("delKey", delInputBox.Text);
        // Remove row pertaining to provided name with correct admin password
        else if (adminPanel.Visible && passInputBox.Text.Equals(PASS))
            filter = Builders<BsonDocument>.Filter.Eq("name", adminDelInputBox.Text);

        var result = collection.DeleteOne(filter);

        clearPanels();

        // Upon successful/unsuccessful deletion
        if (result.DeletedCount == 1)
            outputLabel.Text = "<br/> Your gamertag(s) have been deleted! ";
        else
            outputLabel.Text = "<br/> Incorrect key provided or name does not exist. ";

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