<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Valet.aspx.cs" Inherits="CustServForm.CustComplaints.Valet" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />

<!-- Navbar -->
<ul>
    <li><a href="WebComplaint.aspx">Website</a></li>
    <li><a href="AppComplaint.aspx">App</a></li>
    <li><a href="KioskGate.aspx">Gate/Kiosk</a></li>
    <li><a href="POSComplaint.aspx">POS</a></li>
    <li><a class="active" href="#!">Valet App</a></li>
    <li style="float: right"><a href="EditForm.aspx">Add to Form</a></li>
    <li style="float: right"><a href="EditFormTable.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="panel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">
<asp:Table runat="server">

    <%-- Location Menu --%>
    <asp:TableRow>
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Facility/Location</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
            <asp:dropdownlist runat="server" ID="locDDList" Width="175px" Height="25px"></asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Customer Name--%>
    <asp:TableRow Height="15px">
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Customer Name</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:TextBox runat="server" ID="CustName" width="175px" Height="25px" placeholder ="Paste Customer Name"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Customer Email--%>
    <asp:TableRow Height="15px">
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Customer Email</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
            <asp:TextBox runat="server" ID="CustEmail" width="175px" Height="25px" placeholder ="Paste Customer Email"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Customer Membership Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server">Is the Customer a member?</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="fp_selectedIndexChanged"  AutoPostBack="true" ID="FP_Radio">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:RadioButtonList>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" Visible="false" ID="FPTier">
                <asp:ListItem Value="Member">Member</asp:ListItem>
                <asp:ListItem Value="Silver">Silver</asp:ListItem>
                <asp:ListItem Value="Gold">Gold</asp:ListItem>
                <asp:ListItem Value="Platinum">Platinum</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" Visible="false" ID="FPIDTxtBox" Placeholder="Paste FP Number here."></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Actual Incident Date Menu --%>
    <asp:TableRow Height="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Actual Incident Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server" ID="gcsDateTextBox"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
            <asp:ImageButton runat="server" src="calendarico.png" Width="25px" OnClick="showCal" AutoPostBack="true"/>
            <asp:Calendar runat="server" style="z-index: 100; position:absolute" BackColor="White" Visible="false" ID="calendar" AutoPostBack="true" OnSelectionChanged="dateChanged"></asp:Calendar>
        </asp:TableCell>
    </asp:TableRow>

   <%-- Origin of Complaint Menu --%>
    <asp:TableRow Height="10px" BorderColor="Transparent" Width="500px">
        <asp:TableCell>
            <asp:Label runat="server">Origin of Complaint</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:dropdownlist runat="server" ID="originList" width="175px" Height="25px" OnSelectedIndexChanged="originChanged" AutoPostBack="true">
                <asp:listitem text="Listen 360" value="listen"></asp:listitem>
                <asp:listitem text="Email" value="email"></asp:listitem>
                <asp:listitem text="Social Media" value="smedia"></asp:listitem>
                <asp:ListItem Text="Phone" Value="phone"></asp:ListItem>
                <asp:ListItem Text="Chat" Value="chat"></asp:ListItem>
            </asp:dropdownlist>
        </asp:TableCell>
        <asp:TableCell borderWidth="15px" BorderColor="Transparent">
            <asp:TextBox runat="server" width="500px" AutoPostBack="true" Placeholder="Paste Listen 360 comment here." Visible="true" ID="originTxtBox"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Disposition Menu --%>
    <asp:TableRow Height="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" AutoPostBack="true" width="175px" Height="25px" ID="dispList" OnSelectedIndexChanged="dispListChanged"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell borderWidth="15px" BorderColor="Transparent">
            <asp:DropDownList runat="server" AutoPostBack="true" Width="150px" Height="25px" ID="dispDetails">
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>

        <%-- Reservation Menu --%>
    <asp:TableRow Height="15px">
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Reservation Number</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:TextBox runat="server" ID="ReservationTextBox" width="175px" Height="25px" placeholder ="Paste Reservation Number"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

        <%-- Ticket Menu --%>
    <asp:TableRow Height="15px">
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Ticket Number</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:TextBox runat="server" ID="TicketTextBox" width="175px" Height="25px" placeholder ="Paste Ticket Number"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Type of Parking --%>
    <asp:TableRow Height="15px">
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Type of Parking</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:TextBox runat="server" ID="ParkTextBox" width="175px" Height="25px" placeholder ="Paste Parking Type"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Comments Menu --%>
    <asp:TableRow Height="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Comments</asp:Label>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell>
            <asp:TextBox TextMode="MultiLine" runat="server" id="commentBox" Height="200px" Width="400px" placeholder="Comment..." MaxLength="500"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="15px"></asp:TableRow>
</asp:Table>
    <button runat="server" id="mSubmitForm"  type="button" onserverclick="SubmitForm">Submit</button>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
