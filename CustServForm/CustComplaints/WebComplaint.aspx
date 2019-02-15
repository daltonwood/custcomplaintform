<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebComplaint.aspx.cs" Inherits="CustServForm.WebComplaint" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />

<!-- Navbar -->
<ul>
    <li><a class="active" href="#!">Website</a></li>
    <li><a href="MobileComplaint.aspx">Mobile</a></li>
    <li><a href="GCSComplaint.aspx">GCS/Kiosk</a></li>
    <li style="float: right"><a href="EditForm.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="webPanel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">
<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Facility/Location</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:dropdownlist runat="server" ID="locDDList" Width="170px" Height="25px"></asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Date/Time of Incident</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="dateTextBox"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:ImageButton runat="server" src="calendarico.png" Width="25px" OnClick="showCal" AutoPostBack="true"/>
            <asp:Calendar runat="server" Visible="false" ID="calendar" AutoPostBack="true" OnSelectionChanged="dateChanged"></asp:Calendar>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent" Width="500px">
        <asp:TableCell>
            <asp:Label runat="server">Origin of Complaint</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:dropdownlist runat="server" ID="Mobilelist1" Width="174px" Height="25px" OnSelectedIndexChanged="originChanged" AutoPostBack="true">
                <asp:listitem text="Listen 360" value="listen"></asp:listitem>
                <asp:listitem text="Email" value="email"></asp:listitem>
                <asp:listitem text="Social Media" value="smedia"></asp:listitem>
                <asp:ListItem Text="Phone" Value="phone"></asp:ListItem>
            </asp:dropdownlist>
        </asp:TableCell>
        <asp:TableCell Width="1000px">
            <asp:TextBox runat="server" width="1000px" AutoPostBack="true" Placeholder="Paste Listen 360 comment here." Visible="true" ID="originTxtBox"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" AutoPostBack="true" Width="174px" Height="25px" ID="dispList" OnSelectedIndexChanged="dispListChanged">
                <asp:ListItem text="Accounts"></asp:ListItem>
                <asp:ListItem text="Discounts"></asp:ListItem>
                <asp:ListItem text="Rates"></asp:ListItem>
                <asp:ListItem text="Post Reservation"></asp:ListItem>
                <asp:ListItem text="Ease of Use"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" AutoPostBack="true" Width="150px" Height="25px" ID="dispDetails">
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Comments</asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
    <textarea style="width:1200px; height:200px; padding-left:15px"></textarea>
    <br />
    <button id="mSubmitForm" onclick="submitForm()">Submit</button>
</div>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>