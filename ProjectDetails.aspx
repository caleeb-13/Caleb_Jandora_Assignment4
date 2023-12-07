<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="Assignment4.ProjectDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    
       <h2><asp:Label ID="lblName" runat="server" Text="Project Name"></asp:Label></h2>
    <p><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></p>
    <p><asp:Label ID="lblProjectID" runat="server" Text="Project ID"></asp:Label></p>
    <p><asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label></p>
    <p><asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label></p>
    <p><asp:Label ID="lblCoordinator" runat="server" Text="Coordinator"></asp:Label></p>
    <p><asp:Label ID="lblResearchID" runat="server" Text="ResearchID"></asp:Label></p>
    <p><asp:Label ID="lblObsCount" runat="server" Text="Obs Count"></asp:Label></p>
    <asp:Button ID="btnCreateReport" runat="server" Text="Create a Report" OnClick="btnCreateReport_Click" CssClass="btn" />
    
</body>
</html>
    </asp:Content>