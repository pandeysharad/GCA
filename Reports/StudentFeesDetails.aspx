<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentFeesDetails.aspx.cs" Inherits="Reports_StudentFeesDetails" EnableEventValidation="false" %>

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
                
             </td>
             <td  style="width:33%;font-size:17px;font-weight:bold">REPORT-STUDENT FEES DETAILS </td>
             <td  style="width:33%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             </tr>
           </table>
           <table class="table table-striped table-bordered table-hover dataTable no-footer" width="100%" style="font-weight:bold">
                <tr>
                    <td>Student Name</td>                    
                    <td>Father Name</td>
                    <td>Mobile</td>
                    <td>Scoller No</td>
                    <td>Village</td>
                    <td>Class/Section</td>
                    <td>Payment Type</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblFatherName" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblMobileNumber" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblAdmissionNo" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblVillage" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblClassSection" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="lblPaymentType" runat="server" Text="Label"></asp:Label></td>
                </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
       
       <div >
        <asp:GridView ID="GridStudentWiseData" 
         Width="100%" DataKeyNames="AdmissionId" style="text-align:right;padding:5px;font-weight:bold" CssClass="table table-striped table-bordered table-hover dataTable no-footer" runat="server" ShowFooter="false"  AutoGenerateColumns="false" >
       <Columns>
       <asp:TemplateField HeaderText="SN." HeaderStyle-Width="20px">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
        <asp:BoundField DataField="ReceiptNo" HeaderText="R.No." />
        <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="TotalFees" HeaderText="Total Fee Rec." DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="PaymentType" HeaderText="Fee Type" />
        <asp:BoundField DataField="CourseFees" HeaderText="Class Fee Rec." DataFormatString="{0:###,###,###}"/>        
        <asp:BoundField DataField="PayMonthClass" HeaderText="Month / Installment" />
        <asp:BoundField DataField="TransportFees" HeaderText="Transport Fee" DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="PayMonthTransport" HeaderText="Month / Installment" />
        <asp:BoundField DataField="Discount" HeaderText="Discount" DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="DiscountType" HeaderText="Discount Type" />
        <asp:BoundField DataField="OtherFees" HeaderText="Other Fee" DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="PayOtherFeeDetails" HeaderText="Other Fee Type" />
        
        <asp:BoundField DataField="AdmissionFees" HeaderText="Admission Fee" DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="LateFees" HeaderText="Miscel." DataFormatString="{0:###,###,###}"/>
        <asp:BoundField DataField="PreviousPaid" HeaderText="Previous Paid" DataFormatString="{0:###,###,###}"/>
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