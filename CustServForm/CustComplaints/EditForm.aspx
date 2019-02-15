<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditForm.aspx.cs" Inherits="CustServForm.CustComplaints.EditForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />
<asp:XmlDataSource ID="locData" runat="server" DataFile="~/Locations.xml"></asp:XmlDataSource>

<!-- Navbar -->
<ul>
    <li><a href="WebComplaint.aspx">Website</a></li>
    <li><a href="#!">Mobile</a></li>
    <li><a href="GCSComplaint.aspx">GCS/Kiosk</a></li>
    <li style="float: right"><a class="active" href="EditForm.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="mobilePanel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">
<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:TextBox runat="server" placeholder="Add Location" ID="locText"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell BorderWidth="15px" BorderColor="Transparent">
            <asp:Button runat="server" id="submitButton" Text="Submit" OnClick="addLoc"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="submit" AutoPostBack="true">Test</asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" AutoPostBack="true" Width="174px" Height="25px" ID="dispList">
                <asp:ListItem text="Accounts"></asp:ListItem>
                <asp:ListItem text="Discounts"></asp:ListItem>
                <asp:ListItem text="Rates"></asp:ListItem>
                <asp:ListItem text="Post Reservation"></asp:ListItem>
                <asp:ListItem text="Ease of Use"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="dispIssueText"></asp:TextBox>
        </asp:TableCell>
     </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="dispIssue" OnClick="addDispIssue"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>