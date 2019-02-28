<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddmisionReportDataAllByChecked.aspx.cs" Inherits="Reports_AddmisionReportDataAllByChecked" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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
    <div style="width:100%">
     <asp:GridView ID="GridCourseWiseData" style="text-align:left;padding:5px;font-weight:bold" 
     CssClass="table table-striped table-bordered table-hover dataTable no-footer" 
     Width="100%" runat="server" ShowFooter="false"  AutoGenerateColumns="True" >
       <%----%>
      
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="#">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
       </Columns>
       <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle Font-Bold="true" />
        </asp:GridView> 
    </div>
    </form>
</body>
</html>
