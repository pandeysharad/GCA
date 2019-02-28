<%@ Page Title="Class Print" Language="C#" AutoEventWireup="true" CodeFile="CoursePrint.aspx.cs" Inherits="Pages_CoursePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<style type="text/css">
#customers {
    font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

#customers td, #customers th {
    border: 1px solid #ddd;
    padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers th {
    padding-top: 12px;
    padding-bottom: 12px;
    text-align: left;
    background-color: #4CAF50;
    color: white;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <table width="280px" style="font-weight: bold">
     <tr>
     <td>CLASS/DISCOUNT INFORMATION SHEET:-</td>
    </table>
    <table width="100%" style="font-weight: bold">
        <tr>
            <td>
                <%=print%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
