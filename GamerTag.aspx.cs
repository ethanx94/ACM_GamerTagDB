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

        live.Text = String.Empty;
        psn.Text = String.Empty;
        steam.Text = String.Empty;
        wiiu.Text = String.Empty;

        // Hide Panels
        livePanel.Visible = false;
        psnPanel.Visible = false;
        steamPanel.Visible = false;
        wiiuPanel.Visible = false;

        // Reset outputLabel
        outputLabel.Text = String.Empty;
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
            //Display output only if user entered information
            outputLabel.Text = String.Format("{0} Name: {1}",
                                          "<br />",
                                          name.Text);
            if(live.Text != "")
                outputLabel.Text += "<br /> Live: " + live.Text;
            if (psn.Text != "")
                outputLabel.Text += "<br /> PSN: " + psn.Text;
            if (steam.Text != "")
                outputLabel.Text += "<br /> Steam: " + steam.Text;
            if (wiiu.Text != "")
                outputLabel.Text += "<br /> WiiU: " + wiiu.Text;

            outputLabel.Text += "<br />";
            submitButton.Visible = true;
        }
        
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        submitButton.Visible = false;

        // Retrieves info from textboxes
        string insertCommand = "Insert into [dbo].[Table] ([name],[live],[psn],[steam],[wiiu]) Values('" + name.Text + "', '"+ live.Text + "', '"+ psn.Text + "', '"+ steam.Text + "', '" + wiiu.Text + "');";

        SqlDataSource1.InsertCommand = insertCommand;
        SqlDataSource1.Insert();

        // Start a session, allowing for deletion from database
        Session.Add(name.Text, name.Text);

        outputLabel.Text += "<br />Your gamertag(s) have been added! <br /> <a href=\"./ViewAll.aspx\"> Click Here To View All Entries </a>";
    }
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