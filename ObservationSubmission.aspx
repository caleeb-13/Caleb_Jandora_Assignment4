<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ObservationSubmission.aspx.cs" Inherits="Assignment4.ObservationSubmission" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Panel ID="ObservationSubmissionID" runat="server" Visible="false">
            <h2> Submit an Observation!</h2>
            Notes: <asp:TextBox ID="NotesBox" runat="server"></asp:TextBox><br />
            Value: <asp:TextBox ID="ValueBox" runat="server"></asp:TextBox><br />
            Tool ID: <asp:TextBox ID="ToolBox" runat="server"></asp:TextBox><br />
            Latitude: <asp:TextBox ID="LatBox" runat="server"></asp:TextBox><br />
            Longitude: <asp:TextBox ID="LongBox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
        </asp:Panel>
        
        <asp:Panel runat="server" ID="CreateObs" Visible="false">
            <asp:LoginView runat="server" ID="LoginView1">
     
            </asp:LoginView>
        </asp:Panel>
    </main>
</asp:Content>