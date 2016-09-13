<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAll.aspx.cs" Inherits="ViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <article> 
        <p style="text-decoration: none">
            Here are all current entries in the
            <a OnServerClick="adminLink_Click" runat="server" style="text-decoration: none">database:</a>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
            </asp:GridView>
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
</asp:Content>

