<%@ Page Title="Fees Dashboard" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="FeeDashboard.aspx.cs" Inherits="Pages_FeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridData" runat="server" 
                                         Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                        </Columns>
                                        </asp:GridView>
</asp:Content>

