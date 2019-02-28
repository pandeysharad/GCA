<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompareGrid.aspx.cs" Inherits="Reports_CompareGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compare Data</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="width:100%;padding:15px; text-align:center;font-size:20;font-weight:bold;background-color:Yellow">
                                            Request Data
                                        </div>
    <asp:GridView ID="GridUpdateApprovals" runat="server" AutoGenerateColumns="false"
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black;
                                          text-align:justify; " >
                                        
                                        <Columns>
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="ClassFees" HeaderText="ClassFees" />
                                        <asp:BoundField DataField="TransportFees" HeaderText="Transport Fees" />
                                        <asp:BoundField DataField="ClassPaid" HeaderText="Class Paid" />
                                        <asp:BoundField DataField="TransportPaid" HeaderText="Transport Paid" />
                                        <asp:BoundField DataField="ClassBalance" HeaderText="Class Balance" />
                                        <asp:BoundField DataField="TransportBalance" HeaderText="Transport Balance" />
                                        <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />
                                        <asp:BoundField DataField="R2" HeaderText="Student Name" />
                                        </Columns>
                                        </asp:GridView>
                                        <div style="width:100%;padding:15px; text-align:center;font-size:20;font-weight:bold;background-color:Yellow">
                                            Real Data
                                        </div>
                                        <asp:GridView ID="GridLiveData" runat="server" AutoGenerateColumns="false"
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                                        <Columns>
                                        <asp:BoundField DataField="InstallmentDate" HeaderText="Date" />
                                        <asp:BoundField DataField="CourseFees" HeaderText="ClassFees" />
                                        <asp:BoundField DataField="TransportFees" HeaderText="Transport Fees" />
                                        <asp:BoundField DataField="CousePaid" HeaderText="Class Paid" />
                                        <asp:BoundField DataField="TransportPaid" HeaderText="Transport Paid" />
                                        <asp:BoundField DataField="CourseBalance" HeaderText="Class Balance" />
                                        <asp:BoundField DataField="TransportBalance" HeaderText="Transport Balance" />
                                        <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />
                                        </Columns>
                                        </asp:GridView>
    </div>
    </form>
</body>
</html>
