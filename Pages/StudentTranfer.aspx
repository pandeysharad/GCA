<%@ Page Title="Student Transfer" Language="C#" AutoEventWireup="true" CodeFile="StudentTranfer.aspx.cs" Inherits="Pages_StudentTranfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            font-family: Arial;
        }
        .modal
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .center
        {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        .center img
        {
            height: 128px;
            width: 128px;
        }
      
    </style>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                   <img src="../loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <br />
        <br />
        <div style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD;background-color:#42b3f4;margin-bottom:5px;">
        TRASNFER STUDENT
        </div>
        <div style="background-color:pink;margin-left:-80px;">
            <div align="center">
                <b>Session</b>
                <asp:DropDownList ID="ddlSession" Width="200px"
                        runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlSession_SelectedIndexChanged">
                    </asp:DropDownList><br />
                <div style="margin-left:38px; margin-top:5px;"><asp:Button ID="btnSave" runat="server" Width="200px" Visible="false"  onclick="btnSave_Click" /></div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
