<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustComplaints.aspx.cs" Inherits="CustServForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />
<link rel="stylesheet" href="styles.css" type="text/css" />

<!-- Navbar -->
<ul>
    <li><img src="logo.png" /></li>
    <li><a>Website</a></li>
    <li><a>Mobile</a></li>
</ul>
<!-- Main form content -->
<section class="main-content">

<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell Width="40px">
            <asp:Label runat="server">Facility/Location</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="10px" BorderColor="Transparent">
        <asp:dropdownlist runat="server" ID="locations" Width="150px" Height="25px">
            <asp:listitem text="ATL" value="ATL"></asp:listitem>
            <asp:listitem text="PLUS" value="PLUS"></asp:listitem>
            <asp:listitem text="BNA" value="BNA"></asp:listitem>
            <asp:listitem text="CLE" value="CLE"></asp:listitem>
            <asp:listitem text="DFW" value="DFW"></asp:listitem>
            <asp:listitem text="FLL" value="FLL"></asp:listitem>
            <asp:listitem text="IAH" value="IAH"></asp:listitem>
            <asp:listitem text="LAX" value="LAX"></asp:listitem>
            <asp:listitem text="MIA" value="MIA"></asp:listitem>
            <asp:listitem text="MSP" value="MSP"></asp:listitem>
            <asp:listitem text="MSY" value="MSY"></asp:listitem>
            <asp:listitem text="OAK" value="OAK"></asp:listitem>
            <asp:listitem text="ONT" value="ONT"></asp:listitem>
            <asp:listitem text="SAN" value="SAN"></asp:listitem>
            <asp:listitem text="SFO" value="SFO"></asp:listitem>
        </asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Date/Time of Incident</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
        <input id="datePicker" type="text" />
        <asp:Calendar runat="server"></asp:Calendar>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Time of Issue</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Origin of Complaint</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:dropdownlist runat="server" ID="Dropdownlist1" Width="150px" Height="25px">
                <asp:listitem text="Listen 360" value="listen"></asp:listitem>
                <asp:listitem text="Email" value="email"></asp:listitem>
                <asp:listitem text="Social Media" value="smedia"></asp:listitem>
            </asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:dropdownlist runat="server" ID="Dropdownlist2" Width="150px" Height="25px">
                <asp:listitem text="Discount" value="discount"></asp:listitem>
                <asp:listitem text="Access" value="access"></asp:listitem>
                <asp:listitem text="Payment" value="payment"></asp:listitem>
            </asp:dropdownlist>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow BorderWidth="15px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server">Comments</asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
    <textarea style="width:1200px; height:200px; padding-left:15px"></textarea>
</section>
</asp:Content>
