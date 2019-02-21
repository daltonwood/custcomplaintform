<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GCSComplaint.aspx.cs" Inherits="CustServForm.CustComplaints.GCSComplaint" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />

<!-- Navbar -->
<ul>
    <li><a href="WebComplaint.aspx">Website</a></li>
    <li><a href="AppComplaint.aspx">App</a></li>
    <li><a class="active" href="#">Gate/Kiosk</a></li>
    <li><a href="POSComplaint.aspx">POS</a></li>
    <li><a href="Valet.aspx">Valet App</a></li>
    <li style="float: right"><a href="EditForm.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="panel" UpdateMode="Conditional">
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

    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server">Is the Customer a member?</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButtonList runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Date/Time of Incident</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="gcsDateTextBox"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:ImageButton runat="server" src="calendarico.png" Width="25px" OnClick="showCal" AutoPostBack="true"/>
            <asp:Calendar runat="server" style="z-index: 100; position:absolute" BackColor="White" Visible="false" ID="calendar" AutoPostBack="true" OnSelectionChanged="dateChanged"></asp:Calendar>
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
            <asp:TextBox runat="server" width="500px" AutoPostBack="true" Placeholder="Paste Listen 360 comment here." Visible="true" ID="originTxtBox"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:dropdownlist runat="server" ID="Mobilelist2" Width="174px" Height="25px">
                <asp:listitem text="Scanning" value="discount"></asp:listitem>
            </asp:dropdownlist>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" Width="150px" Height="25px">
                <asp:ListItem text="App"></asp:ListItem>
                <asp:ListItem text="Physical Card"></asp:ListItem>
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
