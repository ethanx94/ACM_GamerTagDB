using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear the last session for adding additional entries
        Session.Clear();
    }

    protected void clearButton_Click(object sender, EventArgs e)
    {
        // Clear all TextBoxes
        name.Text = String.Empty;
        games.Text = String.Empty;

        live.Text = String.Empty;
        psn.Text = String.Empty;
        steam.Text = String.Empty;
        wiiu.Text = String.Empty;

        // Hide Panels
        livePanel.Visible = false;
        psnPanel.Visible = false;
        steamPanel.Visible = false;
        wiiuPanel.Visible = false;
        delPanel.Visible = false;

        // Reset outputLabel
        outputLabel.Text = String.Empty;
        delete.Visible = false;
        submitButton.Visible = false;
    }

    protected void verifyButton_Click(object sender, EventArgs e)
    {
        // Validation
        if (name.Text == "" || !name.Text.Contains(" "))
            outputLabel.Text = "You must provide your full name";
        else if (live.Text == "" && psn.Text == "" && steam.Text == "" && wiiu.Text == "")
            outputLabel.Text = "You must provide at least a single tag";
        else if (live.Text.Contains(" ") || psn.Text.Contains(" ") || steam.Text.Contains(" ") || wiiu.Text.Contains(" "))
            outputLabel.Text = "Tags may not contain whitespace";
        else
        {
            // Display output for each TextBox that contains data
            outputLabel.Text = String.Format("{0} Name: {1}",
                                          "<br />",
                                          name.Text);
            if (games.Text != "")
                outputLabel.Text += "<br /> Games: " + games.Text;
            if(live.Text != "")
                outputLabel.Text += "<br /> Live: " + live.Text;
            if (psn.Text != "")
                outputLabel.Text += "<br /> PSN: " + psn.Text;
            if (steam.Text != "")
                outputLabel.Text += "<br /> Steam: " + steam.Text;
            if (wiiu.Text != "")
                outputLabel.Text += "<br /> WiiU: " + wiiu.Text;

            outputLabel.Text += "<br />";

            delete.Visible = true;
            delPanel.Visible = true;
            submitButton.Visible = true;
        }
        
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        delPanel.Visible = false;
        submitButton.Visible = false;

        // Cancel game names that contain apostrophe
        string gamesList = games.Text.Replace("'", "''");

        // Retrieves info from textboxes
        string insertCommand = "Insert into [dbo].[Table] ([name],[live],[psn],[steam],[wiiu],[games],[delkey]) Values('" + name.Text + "', '" + live.Text + "', '" + psn.Text + "', '" + steam.Text + "', '" + wiiu.Text + "', '" + gamesList + "', '" + delete.Text + "');";
        
        // Start a session, allowing for deletion from database
        Session.Add("Name", name.Text);

        SqlDataSource1.InsertCommand = insertCommand;

        // Upon successful insertion
        if(SqlDataSource1.Insert() == 1)
            outputLabel.Text += "<br />" + Session.Contents[0] + ", your gamertag(s) have been added! <br /> <a href=\"./ViewAll.aspx\"> Click Here To View All Entries </a>";
    }

    /*
     * Reveal Each TextBox's Panel
     */
    protected void liveImg_Click(object sender, ImageClickEventArgs e)
    {
        livePanel.Visible = true;
    }
    protected void psnImg_Click(object sender, ImageClickEventArgs e)
    {
        psnPanel.Visible = true;
    }
    protected void steamImg_Click(object sender, ImageClickEventArgs e)
    {
        steamPanel.Visible = true;
    }
    protected void wiiuImg_Click(object sender, ImageClickEventArgs e)
    {
        wiiuPanel.Visible = true;
    }
}