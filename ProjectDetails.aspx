<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="Assignment4.ProjectDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h2><asp:Label ID="lblName" runat="server" Text="Project Name"></asp:Label></h2>
    <p><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></p>
    <p><asp:Label ID="lblProjectID" runat="server" Text="Project ID"></asp:Label></p>
    <p><asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label></p>
    <p><asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label></p>
    <p><asp:Label ID="lblCoordinator" runat="server" Text="Coordinator"></asp:Label></p>
    <p><asp:Label ID="lblResearchID" runat="server" Text="ResearchID"></asp:Label></p>
    <p><asp:Label ID="lblObsCount" runat="server" Text="Obs Count"></asp:Label></p>
    </form>
</body>
</html>
