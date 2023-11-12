<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="Assignment4.ResearchAreas" %>

<asp:Content ID ="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Repeater ID="ResearchArea" runat="server">
            <ItemTemplate>
                <a href="Projects.aspx?ResearchID=<%# Eval("ResearchID")%>">
                    <%# Eval("ResearchName") %>
                </a>
                <br />
            </ItemTemplate>
            
        </asp:Repeater>
    </main>
</asp:Content>
        
            
