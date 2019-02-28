<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Backup.aspx.cs" Inherits="Pages_Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnBackUp" runat="server" Text="BackUp" 
        onclick="btnBackUp_Click" />
    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
</asp:Content>

