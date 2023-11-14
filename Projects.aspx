<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="Assignment4.Projects" %>

<asp:Content ID ="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Repeater ID="ProjectPage" runat="server">
            <ItemTemplate>
                <a href="ProjectDetails.aspx?ID=<%# Eval("ProjectID")%>"> 
                    <%# Eval("ProjectName") %>
                </a>
                <br />
            </ItemTemplate>
            
        </asp:Repeater>
    </main>
</asp:Content>
