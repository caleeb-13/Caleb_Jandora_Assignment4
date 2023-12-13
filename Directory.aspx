<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Directory.aspx.cs" Inherits="Assignment4.Directory" %>

<asp:Content ID ="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
  
    
      <h1>Volunteer Directory</h1>
            <asp:GridView ID="GridViewVolunteers" runat="server" AutoGenerateColumns="True"></asp:GridView>
    

    </asp:Content>