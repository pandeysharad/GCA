<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchollWiseCollection.aspx.cs" Inherits="Reports_SchollWiseCollection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 3px;
        }
        .style2
        {
            width: 250px;
            height: 68px;
        }
    </style>
     
  </head>
<body>
    <form id="form1" runat="server">
    <div >
      <div style="width:100%">
           
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
           <div style="text-align:center">
           <table style="width:100%">
            <tr style="background-color:#EDEDED">
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;" colspan="3" align="center"><%=SchoolName%></td>
             </tr>
           <tr>
             <td  style="width:33%"></td>
             <td  style="width:33%">REPORT-INSTALLMENT RECEIVED/BALANCE SHEET</td>
             <td  style="width:33%">From:<%=From.ToShortDateString() %>&nbsp;&nbsp; To:&nbsp;&nbsp; <%=To.ToShortDateString() %></td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
       <div style="text-align:right;" class="SearchPanel">
           <table>
            <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;&nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 Width:</td>
             <td class="style1">
                 <asp:DropDownList ID="ddlWidth" runat="server" AutoPostBack="True" 
                  onselectedindexchanged="ddlWidth_SelectedIndexChanged">
                     <asp:ListItem Value="800"></asp:ListItem>
                     <asp:ListItem Value="900"></asp:ListItem>
                     <asp:ListItem Value="1000"></asp:ListItem>
                     <asp:ListItem Value="1100"></asp:ListItem>
                     <asp:ListItem Value="1200"></asp:ListItem>
                     <asp:ListItem Value="1300"></asp:ListItem>
                     <asp:ListItem Value="1400"></asp:ListItem>
                     <asp:ListItem Value="1500"></asp:ListItem>
                     <asp:ListItem Value="1600"></asp:ListItem>
                     <asp:ListItem Value="1700"></asp:ListItem>
                     <asp:ListItem Value="1800"></asp:ListItem>
                     <asp:ListItem>1900</asp:ListItem>
                     <asp:ListItem Value="2000"></asp:ListItem>
                     <asp:ListItem Value="2200"></asp:ListItem>
                     <asp:ListItem Value="2400"></asp:ListItem>
                     <asp:ListItem Value="2600"></asp:ListItem>
                     <asp:ListItem Value="2800"></asp:ListItem>
                 </asp:DropDownList>
                </td>
                  <td>
                 <asp:Button 
                     ID="btnSendSms" runat="server" Text="Send Payment Due SMS" Width="180px" 
                     />
                </td>
            </tr>
           </table>
         
       </div>
       <div style="margin-left:20px;">
        <asp:GridView ID="Grid" CssClass="GridViewStyle_List" Width="40%" DataKeyNames="CourseId" runat="server" ShowFooter="True" OnRowDataBound="Grid_RowDataBound" AutoGenerateColumns="false" >
       <%----%>
      
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
           <asp:BoundField HeaderText="" ItemStyle-VerticalAlign="Top" />
       </Columns>
       <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle Font-Bold="true" />
        </asp:GridView>      
       </div>
    </div>
    </form>
</body>
</html>