<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseWiseReports.aspx.cs" Inherits="Reports_CourseWiseReports" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
       <script type="text/javascript" language="javascript">
           function CheckHeader(source) {
               $("#Grid input[name$='ChkDelete']").each(function () {
                   $(this).attr('checked', source.checked);
               });
           }

           function CheckDelete() {
               if ($("#Grid input[name$='ChkDelete']").length == $("#Grid input[name$='ChkDelete']:checked").length) {
                   $("#Grid input[name$='ChkDeleteHeader']").first().attr('checked', true);
               }
               else {
                   $("#Grid input[name$='ChkDeleteHeader']").first().attr('checked', false);
               }
           }
    </script>
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
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;font-size:22px;font-weight:bold" colspan="3" align="center"><%=SchoolName%></td>
             </tr>
           <tr>
             <td  style="width:33%">
                 <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="ddlSession_SelectedIndexChanged">
                 </asp:DropDownList>
             </td>
             <td  style="width:33%;font-size:17px;font-weight:bold">REPORT-CLASS WISE</td>
             <td  style="width:33%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
       <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
       <div style="">
        <asp:GridView ID="GridCourseWiseData" style="text-align:right;padding:5px;font-weight:bold" CssClass="table table-striped table-bordered table-hover dataTable no-footer right" Width="100%" DataKeyNames="CourseId" runat="server" ShowFooter="false"  AutoGenerateColumns="false" >
       <%----%>
      
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField Visible="true" HeaderText="Class">
                            <ItemTemplate>
                            <asp:LinkButton Text='<%# Eval("CourseName")%>' ID="lnkPrint" ForeColor="#0487B2" runat="server" OnClick="Print_Click" CommandArgument='<%# Eval("CourseId") %>' />
                             <%-- <a href='StudentWiseData.aspx?CourseId=<%#DataBinder.Eval(Container.DataItem,"CourseId")%>' title=" Click To View Course Wise Details" style="visibility:inherit"  >
                              <%#DataBinder.Eval(Container.DataItem, "CourseName")%></a>--%>
                            </ItemTemplate>
          </asp:TemplateField>
          <%--<asp:BoundField DataField="CourseName" HeaderText="Class Name" />--%>
          <asp:BoundField DataField="CourseFees" HeaderText="Class Fees" DataFormatString="{0:###,###,###}" />
          <asp:BoundField DataField="CourseFeesRec" HeaderText="Recived" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="CourseDiscount" HeaderText="Discount" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="CourseFeesBla" HeaderText="Blance" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFees" HeaderText="Trans. Fees" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFeesRec" HeaderText="Recived" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportDiscount" HeaderText="Discount" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFeesBla" HeaderText="Blance" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="AdmissionFees" HeaderText="Admission Fees" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="LateFees" HeaderText="Miscel." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="OtherFees" HeaderText="Other Fee Rec." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="OtherFeeDiscount" HeaderText="Other Disc." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="PreviousPaid" HeaderText="Previous Paid" DataFormatString="{0:###,###,###}"/>
          <%--<asp:BoundField DataField="PaymentReciveingTimeDiscount" HeaderText="Pay. Rec. Time Discount" />--%>
          <%--<asp:BoundField DataField="CourseName" HeaderText="Class Name" />--%>
          
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
