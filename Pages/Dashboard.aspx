<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel6"
        runat="server">
        <ProgressTemplate>
            <img alt="Process....." src="../img/final_loading_big.gif" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    
   <%-- <script type="text/javascript">
        function sessionExpireAlert() {
            setTimeout(function () {
                window.location = "SessionExpired.aspx";
            }, 180000);
        }
    </script>--%>

  
</asp:Content>

