<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAll.aspx.cs" Inherits="ViewAll" %> 

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
        <p style="text-decoration: none">
            Here are all current entries in the
            <a OnServerClick="adminLink_Click" runat="server" style="text-decoration: none">database:</a>
        </p>
        <p>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" HorizontalAlign="Center" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="live" HeaderText="Live" SortExpression="live" />
                    <asp:BoundField DataField="psn" HeaderText="PSN" SortExpression="psn" />
                    <asp:BoundField DataField="steam" HeaderText="Steam" SortExpression="steam" />
                    <asp:BoundField DataField="wiiu" HeaderText="WiiU" SortExpression="wiiu" />
                    <asp:BoundField DataField="games" HeaderText="Games" SortExpression="games" />
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GamerTagDBConnectionString %>" SelectCommand="SELECT [name], [live], [psn], [steam], [wiiu], [games] FROM [Table]"></asp:SqlDataSource>

        </p>
            <p>

                <asp:Button ID="deleteButton" runat="server" BackColor="Black" OnClick="deleteButton_Click" Text="Delete With Key" />
&nbsp;<asp:Button ID="removeButton" runat="server" BackColor="Black" Text="Remove Your Entry" Visible="False" OnClick="removeButton_Click" />

        </p>
            <asp:Panel ID="delInputPanel" runat="server" HorizontalAlign="Center" Visible="False">
                Enter Delete Key:&nbsp;&nbsp;
                <asp:TextBox ID="delInputBox" runat="server" BackColor="Black" TextMode="Password"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="confirmButton" runat="server" BackColor="Black" OnClick="confirmButton_Click" Text="Confirm" />
            </asp:Panel>
            <asp:Panel ID="adminPanel" runat="server" Visible="False">
                    Delete Name:
                    <asp:TextBox ID="adminDelInputBox" runat="server" BackColor="Black"></asp:TextBox>
                    &nbsp;Pass:
                    <asp:TextBox ID="passInputBox" runat="server" BackColor="Black" TextMode="Password"></asp:TextBox>
                    &nbsp;<asp:Button ID="adminConfirmButton" runat="server" BackColor="Black" OnClick="confirmButton_Click" Text="Confirm" />
            </asp:Panel>
        <p>
            <asp:Label ID="outputLabel" runat="server"></asp:Label>
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
