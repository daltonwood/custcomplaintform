<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppComplaint.aspx.cs" Inherits="CustServForm.AppComplaint" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />
<asp:XmlDataSource ID="locData" runat="server" DataFile="~/Locations.xml"></asp:XmlDataSource>

<!-- Navbar -->
<ul>
    <li><a href="WebComplaint.aspx">Website</a></li>
    <li><a class="active" href="#!">App</a></li>
    <li><a href="KioskGate.aspx">Gate/Kiosk</a></li>
    <li><a href="POSComplaint.aspx">POS</a></li>
    <li><a href="Valet.aspx">Valet App</a></li>
    <li style="float: right"><a href="EditForm.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="mobilePanel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">
<asp:Table runat="server">
    <%-- Location Menu --%>
    <asp:TableRow>
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Facility/Location</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:dropdownlist runat="server" ID="locDDList" Width="170px" Height="25px">
        </asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>
    
    <%-- Customer Membership Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label runat="server">Is the Customer a member?</asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="fp_selectedIndexChanged"  AutoPostBack="true" ID="FP_Radio">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:RadioButtonList>
        </asp:TableCell>
        <asp:TableCell width="174px" HorizontalAlign="Left">
            <asp:DropDownList runat="server" Visible="false" ID="FPTier" Width="100px">
                <asp:ListItem Value="Member">Member</asp:ListItem>
                <asp:ListItem Value="Silver">Silver</asp:ListItem>
                <asp:ListItem Value="Gold">Gold</asp:ListItem>
                <asp:ListItem Value="Platinum">Platinum</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:TextBox runat="server" Visible="false" ID="FPIDTxtBox" Placeholder="Paste FP Number here."></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Acutal Incident Date Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow BorderColor="Transparent">
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label runat="server">Actual Incident Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:TextBox runat="server" ID="dateTextBox"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" Width="100px">
            <asp:ImageButton runat="server" src="calendarico.png" Width="25px" OnClick="showCal" AutoPostBack="true"/>
            <asp:Calendar runat="server" style="z-index: 100; position:absolute" BackColor="White" Visible="false" ID="calendar" AutoPostBack="true" OnSelectionChanged="dateChanged"></asp:Calendar>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Mobile Operating System Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="40px" HorizontalAlign="Left">
            <asp:Label runat="server">Mobile OS</asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" Width="174px" Height="25px">
            <asp:dropdownlist runat="server" ID="MobileOSList" Width="174px" Height="25px"></asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Origin of Complaint Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow Width="500px">
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label runat="server">Origin of Complaint</asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:dropdownlist runat="server" ID="Mobilelist1" Width="174px" Height="25px" OnSelectedIndexChanged="originChanged" AutoPostBack="true">
                <asp:listitem text="Listen 360" value="listen"></asp:listitem>
                <asp:listitem text="Email" value="email"></asp:listitem>
                <asp:listitem text="Social Media" value="smedia"></asp:listitem>
                <asp:ListItem Text="Phone" Value="phone"></asp:ListItem>
            </asp:dropdownlist>
        </asp:TableCell>
        <asp:TableCell Width="100%" ColumnSpan="2" HorizontalAlign="Left">
            <asp:TextBox runat="server" width="500px" AutoPostBack="true" Placeholder="Paste Listen 360 comment here." Visible="true" ID="originTxtBox"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Disposition Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:DropDownList runat="server" AutoPostBack="true" Width="174px" Height="25px" ID="dispList" OnSelectedIndexChanged="dispListChanged"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" Width="100px">
            <asp:DropDownList runat="server" AutoPostBack="true" Width="150px" Height="25px" ID="dispDetails">
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Comments Menu --%>
    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow BorderColor="Transparent">
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label runat="server">Comments</asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<textarea style="width:1200px; height:200px; padding-left:15px"></textarea>
<br />
<button id="mSubmitForm" onclick="submitForm">Submit</button>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>