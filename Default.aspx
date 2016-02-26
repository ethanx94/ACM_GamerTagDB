<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <article> 
        <p style="color: greenyellow">
            Welcome To The Gamer-Tag Database! <br />
            Click on a logo to add your gamer-tag for that specific platform.
        </p>
        <p>
            <asp:ImageButton ID="liveImg" runat="server" ImageUrl="~/Resources/live.png" OnClick="liveImg_Click" />
            <asp:ImageButton ID="psnImg" runat="server" ImageUrl="~/Resources/psn.png" OnClick="psnImg_Click" />
            <asp:ImageButton ID="steamImg" runat="server" ImageUrl="~/Resources/steam.png" OnClick="steamImg_Click" />
            <asp:ImageButton ID="wiiuImg" runat="server" ImageUrl="~/Resources/wiiu.png" OnClick="wiiuImg_Click" />
        </p>
            <table align="center">
                <tr>
                    <td>
                        Name:&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="name" runat="server" BackColor="Black" CssClass="textbox" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Games:&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="games" runat="server" BackColor="Black" CssClass="textbox" />
                    </td>
                </tr>
                <tr>
                    <!-- ASP panel for Live ID -->
                    <asp:Panel ID="livePanel" runat="server" Visible="False" HorizontalAlign="Center">
                        <td>
                            Live:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="live" runat="server" BackColor="Black" CssClass="textbox" />
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                     <asp:Panel ID="psnPanel" runat="server" Visible="False" HorizontalAlign="Center">
                         <td>
                             PSN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         </td>
                         <td>
                             <asp:TextBox ID="psn" runat="server" BackColor="Black" CssClass="textbox" />
                         </td>
                     </asp:Panel>
                </tr>
                <tr>
                    <asp:Panel ID="steamPanel" runat="server" Visible="False" HorizontalAlign="Center">
                        <td>
                             Steam:&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="steam" runat="server" BackColor="Black" CssClass="textbox" />
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <asp:Panel ID="wiiuPanel" runat="server" Visible="False" HorizontalAlign="Center">
                        <td>
                            WiiU:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="wiiu" runat="server" BackColor="Black" CssClass="textbox" />
                        </td>
                    </asp:Panel>
                </tr>
            </table>   
            <p>
                <asp:Button ID="verifyButton" runat="server" Text="Verify" BackColor="Black" OnClick="verifyButton_Click" />
                <asp:Button ID="clearButton" runat="server" Text="Clear All" BackColor="Black" OnClick="clearButton_Click" />
            </p>
            <p>
                <asp:Label ID="outputLabel" runat="server"></asp:Label>
            </p>
            <asp:Panel ID="delPanel" runat="server" Visible ="False" HorizontalAlign="Center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Delete Key:&nbsp;&nbsp;
                <asp:TextBox ID="delete" runat="server" BackColor="Black" CssClass="textbox" MaxLength="6" TextMode="Password" />
                &nbsp;&nbsp;(Optional 6 chars)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
            <p>
                <asp:Button ID="submitButton" runat="server" Text="Submit" BackColor="Black" OnClick="submitButton_Click" Visible="False" />
            </p>
            <p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GamerTagDBConnectionString %>" SelectCommand="SELECT [live], [name], [psn], [steam], [wiiu] FROM [Table]"></asp:SqlDataSource>
            </p>
        </article>
     </section>
</asp:Content>

