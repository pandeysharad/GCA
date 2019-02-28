<%@ Page Title="Addmision Print" Language="C#" AutoEventWireup="true" CodeFile="AdmissionPrint.aspx.cs" Inherits="Pages_AdmissionPrint" %>

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
     <div style="width:100%">
           <div style="text-align:center">
           <table style="width:100%">
            <tr style="background-color:#EDEDED">
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;font-size:22px;font-weight:bold" colspan="3" align="center"><%=SchoolName%></td>
             </tr>
           <tr>
             <td  style="width:33%" align="right">
                  
             </td>
             <td  style="width:33%;font-size:17px;font-weight:bold">REPORT-Addmision Data</td>
             <td  style="width:33%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
     <table width="280px" style="font-weight: bold">
        <tr id="date" runat="server" visible="false">
            <td>FROM : <%=StartDate %> </td><td>TO :  <%=EndDate %></td>
        </tr>
    </table>
    <table id="EP" runat="server" width="100%" style="font-weight: bold">
        <tr>
            <td>
                <%=print%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
