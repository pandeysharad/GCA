<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentWiseData.aspx.cs" Inherits="Reports_StudentWiseData" EnableEventValidation="false"%>

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
        <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
      <div style="width:100%">
           
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
           <div style="text-align:center">
           <table style="width:100%">
            <tr style="background-color:#EDEDED">
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;font-size:22px;font-weight:bold" colspan="3" align="center"><%=SchoolName%></td>
             </tr>
           <tr>
             <td  style="width:33%; margin:auto" >
                 <asp:DropDownList ID="ddlSection" runat="server" Width="100px" style="margin:auto"
                                    CssClass="form-control  input-sm" aut AutoPostBack="true"
                     onselectedindexchanged="ddlSection_SelectedIndexChanged"  >
                     <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Not Assigned</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                </asp:DropDownList>
             </td>
             <td  style="width:33%;font-size:17px;font-weight:bold">REPORT-STUDENT DETAILS (<%=CourseName %>)</td>
             <td  style="width:33%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
       
       <div>
        <asp:GridView style="text-align:right;padding:5px;font-weight:bold" ID="GridStudentWiseData" CssClass="table table-striped table-bordered table-hover dataTable no-footer"
         Width="100%" DataKeyNames="AdmissionId" runat="server" ShowFooter="false"  AutoGenerateColumns="false" >
       <%----%>
      
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField Visible="true" HeaderText="Student Name">
                            <ItemTemplate>
                            <asp:LinkButton Text='<%# Eval("StudentName")%>' ID="lnkPrint" ForeColor="#0487B2" runat="server" OnClick="Print_Click" CommandArgument='<%# Eval("AdmissionId") %>' />
                              <%--<a   href='StudentFeesDetails.aspx?AdmissionId=<%#DataBinder.Eval(Container.DataItem,"AdmissionId")%>' target="_blank">
                             <%#DataBinder.Eval(Container.DataItem, "StudentName")%></a>--%>
                            </ItemTemplate>
          </asp:TemplateField>
          <%--<asp:BoundField DataField="CourseName" HeaderText="Class Name" />
          <asp:BoundField DataField="StudentName" HeaderText="Student Name" />--%>
          <asp:BoundField DataField="ContactNo" HeaderText="Contact No." />
          <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
          <asp:BoundField DataField="ParentContact" HeaderText="Parent Contact" />
          <asp:BoundField DataField="PaymentType" HeaderText="Fees Type" />
          <asp:BoundField DataField="CourseFees" HeaderText="Class Fees" DataFormatString="{0:###,###,###}" />
          <asp:BoundField DataField="CourseFeesRec" HeaderText="Class Fees Rec." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="CourseDiscount" HeaderText="Class Discount" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="CourseFeesBla" HeaderText="Class Fees Bla." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFees" HeaderText="Transport Fees" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFeesRec" HeaderText="Transport Fees Rec." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportDiscount" HeaderText="Transport Discount" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="TransportFeesBla" HeaderText="Transport Fees Bla." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="AdmissionFees" HeaderText="Admission Fees" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="LateFees" HeaderText="Miscel." DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="OtherFees" HeaderText="Other Fees" DataFormatString="{0:###,###,###}"/>
          <asp:BoundField DataField="PreviousPaid" HeaderText="Previous Paid" DataFormatString="{0:###,###,###}"/>
          <%--<asp:BoundField DataField="PaymentReciveingTimeDiscount" HeaderText="Pay Rec. Time Discount" />--%>

           
           <%--<asp:BoundField HeaderText="TOTAL CLASS FEES" DataField="TotalCourseFees" ItemStyle-VerticalAlign="Top"  DataFormatString="{0:##,##,##,###.00}"/>
           <asp:BoundField HeaderText="TOTAL TRANSPORT FEES" DataField="TotalTransportFees" ItemStyle-VerticalAlign="Top"  DataFormatString="{0:##,##,##,###.00}"/>--%>
           
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
