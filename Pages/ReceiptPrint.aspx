<%@ Page Title="Fees Reciept" Language="C#" AutoEventWireup="true" CodeFile="ReceiptPrint.aspx.cs" Inherits="Pages_ReceiptPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #meta th
        {
            background: #eee;
        }
        #meta
        {
            border-collapse: collapse;
        }
        #meta td, table th
        {
            border: 1px solid black;
            padding: 3px;
        }
        #meta1 td, table th
        { 
            padding: 5px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
<asp:DropDownList ID="DropDownList1" Visible="False" runat="server"></asp:DropDownList>
<table width="100%" style="background-image:url(../img/bg.png);    background-repeat-x: no-repeat;" >
<tr><td>Office Copy</td></tr>
<tr>
<td style="width:100%; border:thin solid black"><%=print%></td>
</tr>
<tr>
<td height="20px"></td>
</tr>
<tr><td>Student Copy</td></tr>
<tr>
<td style="width:100%; border:thin solid black"><%=print%></td>
</tr>
</table>
    </form>
</body>
</html>
