<%@ Page Title="Addmision Form Print" Language="C#" AutoEventWireup="true" CodeFile="AddmisionFormPrint.aspx.cs" Inherits="Pages_AddmisionFormPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"><table width="100%" >
    <tr>
    <td height="20px"><b><span style="background-color:Black;color:White;">PARENT COPY:-</span></b></td>
    </tr>
<tr>
<td style="width:100%; border:thin solid black"><%=print%></td>
</tr>
<tr>
<td height="100px">----------------------------------------------------------------------------------------------------------------------------</td>
</tr>
<tr>
<td height="20px"><b><span style="background-color:Black;color:White;">SCHOOL COPY:-</span></b></td>
</tr>
<tr>
<td style="width:100%; border:thin solid black"><%=print%></td>
</tr>
</table>
    </form>
</body>
</html>
