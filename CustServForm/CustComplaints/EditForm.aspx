<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditForm.aspx.cs" Inherits="CustServForm.CustComplaints.EditForm" %>

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
    <li style="float: right"><a class="active" href="EditForm.aspx">Edit Form</a></li>
</ul>
<!-- Main form content -->
<asp:UpdatePanel runat="server" ID="mobilePanel" UpdateMode="Conditional">
<ContentTemplate>
<div class="main-content">
<asp:Table runat="server">
    <%-- Add Location Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:TextBox runat="server" placeholder="Add Location" ID="locText"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Form To Edit Menu --%>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:RadioButtonList runat="server" OnSelectedIndexChanged="disp_selectedIndexChanged"  AutoPostBack="true" ID="Disp_Radio">
                <asp:ListItem Value="1">Website</asp:ListItem>
                <asp:ListItem Value="2">App</asp:ListItem>
                <asp:ListItem Value="3">Gate/Kiosk</asp:ListItem>
                <asp:ListItem Value="4">POS</asp:ListItem>
                <asp:ListItem Value="5">Valet</asp:ListItem>
            </asp:RadioButtonList>        
        </asp:TableCell>
    </asp:TableRow>

    <%-- Edit Disposition Categories Menu --%>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server" Visible="false" ID="DispLabel">Add New Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell BorderWidth="15px" BorderColor="Transparent">
            <asp:TextBox runat="server" Visible="false" ID="newDisp"></asp:TextBox>
        </asp:TableCell>
     </asp:TableRow>

    <%-- Edit Disposition Issues Menu --%>
    <asp:TableRow BorderWidth="10px" BorderColor="Transparent">
        <asp:TableCell>
            <asp:Label runat="server" Visible="false" ID="DispLabel2">Disposition</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList runat="server" autopostback="true" Width="174px" Height="25px" ID="dispList" Visible="false"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell BorderWidth="15px" BorderColor="Transparent">
            <asp:TextBox runat="server"  Visible="false" ID="dispIssueText" placeholder="Add Issue"></asp:TextBox>
        </asp:TableCell>
     </asp:TableRow>

    <%-- New Origin of Complaint Menu --%>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Visible="false">Add New Origin of Complaint</asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="15px"></asp:TableCell>
        <asp:TableCell style="vertical-align:bottom">
            <asp:TextBox runat="server" visible="false" id="originText"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell Width="15px"></asp:TableCell>
        <asp:TableCell style="vertical-align:bottom">
            <asp:TextBox runat="server" visible="false" id="originPHText" placeholder="Add Hint Here..."></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow Height="15px"></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="submitBtn" OnClick="submitData" Text="Add All Data"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>