<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyCollectionReciptWiseCollColumn.aspx.cs" Inherits="Reports_DailyCollectionReciptWiseCollColumn" %>

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
         
  </head>
<body>
    <form id="form1" runat="server">
    <div >
      <div style="width:100%">
           
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
           <div style="text-align:center; width:100%">
           <table style="width:100%">
            <tr style="background-color:#EDEDED">
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;font-size:22px;font-weight:bold" colspan="3" align="center"><%=SchoolName%></td>
             </tr>
           <tr>
             <td  style="width:20%">
                
             </td>
             <td  style="width:50%;font-size:17px;font-weight:bold">REPORT-DAILY COLLECTION (<%=FD.ToShortDateString() %> - <%= TD.ToShortDateString() %>)</td>
             <td  style="width:30%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
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
        <asp:GridView ID="GridCollectionReport" style="padding:5px;font-weight:bold" 
               CssClass="table table-striped table-bordered table-hover dataTable no-footer" 
               Width="100%" runat="server" ShowFooter="true"  AutoGenerateColumns="false" 
               onrowdatabound="GridCollectionReport_RowDataBound" >
               
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="ReceiptNo" HeaderText="Rec.No" />
          <asp:BoundField DataField="Class" HeaderText="Class" />
          <asp:BoundField DataField="AdmissionNo" HeaderText="ScholarNo" />
          <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
          <asp:BoundField DataField="StudentFeeType" HeaderText="Fee Type" />
          <asp:BoundField DataField="PreviousPaid" HeaderText="Pre. Session Coll."  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="AdmissionFees" HeaderText="Adm. Fee"  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="CourseFees" HeaderText="Sch. Fee Coll."  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="TransportFees" HeaderText="Tran. Fee Coll." ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="OtherFees" HeaderText="CM /T1 / T2" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="LateFees" HeaderText="Prev. CM / LF"  ItemStyle-CssClass="right" DataFormatString="{0:0}"/>
          <asp:BoundField DataField="DiscountType" HeaderText="Dis. Type" />          
          <asp:BoundField DataField="Discount" HeaderText="Dis." ItemStyle-CssClass="right" DataFormatString="{0:0}"/>          
          <asp:BoundField DataField="AssetFine" HeaderText="Asset Fine" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="TotalFees" HeaderText="T.Fee Coll" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          
          
          <asp:BoundField DataField="Remarks" HeaderText="RMRK" />
          
          <asp:BoundField DataField="PaymentDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"  />
          <asp:BoundField DataField="UserName" HeaderText="Coll. By" />
       </Columns>
       <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" Font-Size="17px" HorizontalAlign="Right"/>
       <FooterStyle Font-Bold="true" />
        </asp:GridView>      
       </div>
       <div style="padding:20px;font-weight:bold">Total Amount in word : <%= Globals.GetMoneyFigure(TotalFee.ToString())%></div>
    </div>
    <div style="padding:20px;">
        <asp:GridView ID="GridUserData" runat="server"  style="padding:5px;font-weight:bold" 
               CssClass="table table-striped table-bordered table-hover dataTable no-footer" >
        </asp:GridView>
    </div>
    

     <%--Cancel Start--%>
       <div style="border:5px solid red" runat="server" id="CancelReciepts" visible="false">
       <h3 style="width:100%;text-align:center;background-color:Yellow">Cancel Receipt</h3>
        <asp:GridView ID="GridCancel" style="padding:5px;font-weight:bold" 
               CssClass="table table-striped table-bordered table-hover dataTable no-footer" 
               Width="100%" runat="server" ShowFooter="false"  AutoGenerateColumns="false" >
               
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNoCancel++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="ReceiptNo" HeaderText="Rec.No" />
          <asp:BoundField DataField="Class" HeaderText="Class" />
          <asp:BoundField DataField="AdmissionNo" HeaderText="ScholarNo" />
          <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
          <asp:BoundField DataField="StudentFeeType" HeaderText="Fee Type" />
          <asp:BoundField DataField="PreviousPaid" HeaderText="Pre. Session Coll."  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="AdmissionFees" HeaderText="Adm. Fee"  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="CourseFees" HeaderText="Sch. Fee Coll."  ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="TransportFees" HeaderText="Tran. Fee Coll." ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="OtherFees" HeaderText="CM /T1 / T2" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="LateFees" HeaderText="Prev. CM / LF"  ItemStyle-CssClass="right" DataFormatString="{0:0}"/>
          <asp:BoundField DataField="DiscountType" HeaderText="Dis. Type" />          
          <asp:BoundField DataField="Discount" HeaderText="Dis." ItemStyle-CssClass="right" DataFormatString="{0:0}"/>          
          <asp:BoundField DataField="AssetFine" HeaderText="Asset Fine" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          <asp:BoundField DataField="TotalFees" HeaderText="T.Fee Coll" ItemStyle-CssClass="right" DataFormatString="{0:0}" />
          
          
          <asp:BoundField DataField="Remarks" HeaderText="RMRK" />
          
          <asp:BoundField DataField="PaymentDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"  />
          <asp:BoundField DataField="UserName" HeaderText="Coll. By" />
       </Columns>
       <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
        </asp:GridView>    
       </div>
       <%--Cancel END--%>


    <div style="padding:20px;"><B>Note:Shortcuts:</B>T Paid -Total Paid, T Bal.- Total Balance, CM/T1/T2- Caution Money/Term1/Term2, LF-Late Fee, M-Monthly, I-Installment, RMRK- Remark, CF-Class Fee, 
TF-Transport Fee, PSF-Previous Session Fee, DBD- Discount By Director, DBP- Discount By Principal, DBC- Discount By Chairmen, Coll- Collection
</div>
    
    </form>
</body>
</html>
