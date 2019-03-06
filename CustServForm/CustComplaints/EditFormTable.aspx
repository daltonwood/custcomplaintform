﻿<%@ Page Title="Edit Form" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditFormTable.aspx.cs" Inherits="CustServForm.CustComplaints.EditFormTable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link rel="stylesheet" href="styles.css" type="text/css" />
<asp:XmlDataSource ID="locData" runat="server" DataFile="~/Locations.xml"></asp:XmlDataSource>

<!-- Navbar -->
<ul>
    <li><a href="WebComplaint.aspx">Website</a></li>
    <li><a href="AppComplaint.aspx">App</a></li>
    <li><a href="KioskGate.aspx">Gate/Kiosk</a></li>
    <li><a href="POSComplaint.aspx">POS</a></li>
    <li><a href="Valet.aspx">Valet App</a></li>
    <a href="#" class="pull-left">
        <img src="png/PNF Logo.png" style="padding:5px" height="50px" width="275px"/>
    </a>
    <li style="float: right"><a href="EditForm.aspx">Add to Form</a></li>
    <li style="float: right"><a class="active" href="EditFormTable.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="mobilePanel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">

 <asp:dropdownlist runat="server" ID="EditList" width="175px" Height="25px" OnSelectedIndexChanged="changeEditor" AutoPostBack="true" >
                <asp:listitem text="App Disposition" value="App"></asp:listitem>
                <asp:listitem text="Kiosk Disposition" value="Kiosk"></asp:listitem>
                <asp:listitem text="Location" value="Location"></asp:listitem>
                <asp:ListItem Text="Origin of Complaint" Value="Origin"></asp:ListItem>
                <asp:ListItem Text="POS Disposition" Value="POS"></asp:ListItem>
                <asp:ListItem Text="Valet Disposition" Value="Valet"></asp:ListItem>
                <asp:ListItem Text="Website Disposition" Value="Web"></asp:ListItem>
            </asp:dropdownlist>

<asp:Table runat="server">
    <%-- Add Location Menu --%>
    <asp:TableRow Height="20px"></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="locTable" AutoGenerateColumns="false" Visible="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteLocation" OnRowEditing="EditLocation" OnRowUpdating="UpdateLocation" OnRowCancelingEdit="CancelEditLocation" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"/>

                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>

     <%-- Add App Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="appTable" AutoGenerateColumns="false" Visible="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteApp" OnRowEditing="EditApp" OnRowUpdating="UpdateApp" OnRowCancelingEdit="CancelEditApp" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="DispType" HeaderText="Disposition Type" SortExpression=""/>
                    <asp:BoundField DataField="issue" HeaderText="Disposition Issue" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>

     <%-- Add Kiosk Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="kioskTable" AutoGenerateColumns="false" Visible="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteKiosk" OnRowEditing="EditKiosk" OnRowUpdating="UpdateKiosk" OnRowCancelingEdit="CancelEditKiosk" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="DispType" HeaderText="Disposition Type" SortExpression=""/>
                    <asp:BoundField DataField="issue" HeaderText="Disposition Issue" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>
    
    <%-- Add Origin Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="originTable" AutoGenerateColumns="false" Visible="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteOrigin" OnRowEditing="EditOrigin" OnRowUpdating="UpdateOrigin" OnRowCancelingEdit="CancelEditOrigin" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="OriginType" HeaderText="Origin Type" SortExpression=""/>
                    <asp:BoundField DataField="Hint" HeaderText="Hint" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>

     <%-- Add POS Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="posTable" AutoGenerateColumns="false" Visible="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeletePOS" OnRowEditing="EditPOS" OnRowUpdating="UpdatePOS" OnRowCancelingEdit="CancelEditPOS" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="DispType" HeaderText="Disposition Type" SortExpression=""/>
                    <asp:BoundField DataField="issue" HeaderText="Disposition Issue" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>
     <%-- Add Valet Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="valetTable" AutoGenerateColumns="false" Visible="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteValet" OnRowEditing="EditValet" OnRowUpdating="UpdateValet" OnRowCancelingEdit="CancelEditValet" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="DispType" HeaderText="Disposition Type" SortExpression=""/>
                    <asp:BoundField DataField="issue" HeaderText="Disposition Issue" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>
     <%-- Add Web Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView runat="server" ID="webTable" AutoGenerateColumns="false" Visible="false" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" 
                OnRowDeleting="DeleteWeb" OnRowEditing="EditWeb" OnRowUpdating="UpdateWeb" OnRowCancelingEdit="CancelEditWeb" EnableViewState="false">
                <Columns>
                    <asp:BoundField DataField="DispType" HeaderText="Disposition Type" SortExpression=""/>
                    <asp:BoundField DataField="issue" HeaderText="Disposition Issue" SortExpression=""/>
                </Columns>
            </asp:GridView>
        </asp:TableCell>
    </asp:TableRow>

</asp:Table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>