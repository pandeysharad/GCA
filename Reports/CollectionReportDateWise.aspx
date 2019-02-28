<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CollectionReportDateWise.aspx.cs" EnableEventValidation = "false"  Inherits="Reports_CollectionReportDateWise" %>

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
           <tr style="font-size:17px;font-weight:bold">
             <td  style="width:25%">
                <b>TOTAL RECIVED : <%= (totClass + totTrans + totOther + totprev + totAdm + totLateFee ) %></b>
             </td>
             <td  style="width:50%"><b>COLLECTION REPORT (Date: <%= FD.ToLongDateString() + " - " + TD.ToLongDateString()%>)</b></td>
             <td  style="width:25%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
       <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
       <div style="margin-left:20px;">
        <asp:GridView ID="GridData" style="text-align:right;padding:5px;font-weight:bold"
               CssClass="table table-striped table-bordered table-hover dataTable no-footer right" 
               Width="100%" runat="server" ShowFooter="true"  AutoGenerateColumns="false" 
               onrowdatabound="GridData_RowDataBound" >
       <%----%>
      
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
         <%-- <asp:TemplateField Visible="true">
                            <ItemTemplate>
                              <a   href='StudentWiseData.aspx?CourseId=<%#DataBinder.Eval(Container.DataItem,"CourseId")%>' title=" Click To View Course Wise Details" >
                              <%#DataBinder.Eval(Container.DataItem, "CourseName")%></a>
                            </ItemTemplate>
          </asp:TemplateField>--%>
          <asp:BoundField DataField="Class" HeaderText="Class Name" />
          <asp:BoundField DataField="CourseFees" HeaderText="Class Fee" />
          <asp:BoundField DataField="ClassFeeDiscount" HeaderText="Disc." />
          <asp:BoundField DataField="ClassFeeAfterDiscount" HeaderText="Recived" />
          <asp:BoundField DataField="TransportFees" HeaderText="Tran.Fee" />
          <asp:BoundField DataField="TransportFeesDiscount" HeaderText="Disc."/>
          <asp:BoundField DataField="TransportFeesAfterDiscount" HeaderText="Recived" />
          <asp:BoundField DataField="OtherFees" HeaderText="OtherFee" />
          <asp:BoundField DataField="OtherFeesDiscount" HeaderText="Disc." />
          <asp:BoundField DataField="OtherFeesAfterDiscount" HeaderText="Recived" />
          <asp:BoundField DataField="PreviousPaid" HeaderText="Prev. Paid" />
          <asp:BoundField DataField="AdmissionFees" HeaderText="Adm. Fee" />
          <asp:BoundField DataField="LateFees" HeaderText="Miscel." />
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

