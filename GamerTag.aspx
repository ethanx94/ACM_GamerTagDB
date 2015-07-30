<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GamerTag.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACM GamerTag Database</title>
    <link rel="stylesheet" type="text/css" href="homeStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <header>
        ACM GamerTag Database
    </header>
 
        <nav>
        <h3> Actions: </h3>
            <ul>
                <li><a href ="./GamerTag.aspx">Add New Entry</a></li>
                <li><a href ="./ViewAll.aspx">View All Entries</a></li>
            </ul>
            <br />
            <a href="https://orgsync.com/22120/chapter"><img src="./Resources/acm.png" width="100" height="100" /></a>
            <a href="https://salukilan.com"><img src="./Resources/salukilan.png" width="84" height="110" /></a>
        </nav>
    
    <section>
        <article> 
        <p>
            Welcome To ACM&#39;s GamerTag Database
        </p>
        <p>
            <asp:ImageButton ID="liveImg" runat="server" ImageUrl="~/Resources/live.png" OnClick="liveImg_Click" />
            <asp:ImageButton ID="psnImg" runat="server" ImageUrl="~/Resources/psn.png" OnClick="psnImg_Click" />
            <asp:ImageButton ID="steamImg" runat="server" ImageUrl="~/Resources/steam.png" OnClick="steamImg_Click" />
            <asp:ImageButton ID="wiiuImg" runat="server" ImageUrl="~/Resources/wiiu.png" OnClick="wiiuImg_Click" />
        </p>
                Name:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="name" runat="server" BackColor="Black" CssClass="textbox" />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Games:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="games" runat="server" BackColor="Black" CssClass="textbox" />&nbsp;&nbsp; (Optional)
            <asp:Panel ID="livePanel" runat="server" Visible="False">
                Live:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="live" runat="server" BackColor="Black" CssClass="textbox" />
            </asp:Panel>
            <asp:Panel ID="psnPanel" runat="server" Visible="False">
                PSN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="psn" runat="server" BackColor="Black" CssClass="textbox" />
            </asp:Panel>
            <asp:Panel ID="steamPanel" runat="server" Visible="False">
                Steam:&nbsp;&nbsp;
                <asp:TextBox ID="steam" runat="server" BackColor="Black" CssClass="textbox" />
            </asp:Panel>
            <asp:Panel ID="wiiuPanel" runat="server" Visible="False">
                WiiU:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="wiiu" runat="server" BackColor="Black" CssClass="textbox" />
            </asp:Panel>
            <p>
                <asp:Button ID="verifyButton" runat="server" Text="Verify" BackColor="Black" OnClick="verifyButton_Click" />
                <asp:Button ID="clearButton" runat="server" Text="Clear All" BackColor="Black" OnClick="clearButton_Click" />
            </p>
            <p>
                <asp:Label ID="outputLabel" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="submitButton" runat="server" Text="Submit" BackColor="Black" OnClick="submitButton_Click" Visible="False" />
            </p>
            <p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GamerTagDBConnectionString %>" SelectCommand="SELECT [live], [name], [psn], [steam], [wiiu] FROM [Table]"></asp:SqlDataSource>
            </p>
            
        </article>
     </section>        
    <footer>
        <p><small>
        &copy; Copyright 2015 Ethan Richardson<br />
        </small></p>
    </footer>
    </form>
</body>
</html>
