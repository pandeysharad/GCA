<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeDueReport.aspx.cs" EnableEventValidation="false"
    Inherits="Reports_FeeDueReport" %>

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
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div style="width: 100%">
            <hr style="color: Black; margin: 0px 0px 0px 0px" />
            <div style="text-align: center">
                <table style="width: 100%">
                    <tr style="background-color: #EDEDED">
                        <td style="width: 100%; font-weight: bold; font-family: Lucida Bright; color: #0487B2;
                            font-size: 22px; font-weight: bold" colspan="3" align="center">
                            <%=SchoolName%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 33%">
                            <asp:CheckBox ID="rbtDeuRpeot" runat="server" Text="Yearly" AutoPostBack="True" OnCheckedChanged="rbtDeuRpeot_CheckedChanged" />
                            <div runat="server" id="FilterDiv" style="display: inline">
                                <asp:DropDownList ID="ddlReportType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Month</asp:ListItem>
                                    <asp:ListItem>Installment</asp:ListItem>
                                    <asp:ListItem>Class Wise</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" Visible="false"
                                    OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtGraterTotalAmt" runat="server" OnTextChanged="ddlMonth_SelectedIndexChanged"
                                    Width="100px" placeholder="Min Bla" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                            </div>
                        </td>
                        <td style="width: 33%; font-size: 17px; font-weight: bold; text-transform: uppercase;">
                            current defaulter list
                        </td>
                        <td style="width: 33%">
                            Print DateTime:
                            <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
                            <asp:Button ID="btnSMS" runat="server" Text="Send SMS" OnClick="btnSMS_Click" OnClientClick="return confirm('Are you sure??');"
                                Visible="false" Width="169px" />
                        </td>
                    </tr>
                </table>
            </div>
            <hr style="color: Black; margin: 0px 0px 0px 0px" />
        </div>
        <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <%=Print%>
        <div class="loading" align="center">
            Loading. Please wait.<br />
            <br />
            <img src="../img/final_loading_big.gif" alt="" />
        </div>
        <div style="" runat="server" visible="true" id="MonthWiseData">
            <asp:GridView ID="GridDueReport" Style="padding: 5px; font-weight: bold" CssClass="table table-striped table-bordered table-hover dataTable no-footer right"
                Width="100%" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="GridDueReport_RowDataBound">
                <PagerStyle CssClass="PagerStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="SN.">
                        <ItemTemplate>
                            <%=SrNo++ %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CourseName" HeaderText="Class" />
                    <asp:BoundField DataField="AdmissionNo" HeaderText="ScholarNo" />
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                    <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                    <asp:BoundField DataField="EnrollmentNo" HeaderText="Area" />
                    <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                    <asp:BoundField DataField="CourseFees" HeaderText="Total Sch./Course Fee" />
                    <asp:BoundField DataField="TransportFees" HeaderText="Total Tran. Fee" />
                    <asp:BoundField DataField="CourseBalance" HeaderText="School/Course Due Fee" />
                    <asp:BoundField DataField="TransportBalance" HeaderText="Tran. Due" />
                    <asp:BoundField DataField="PreviousBalance" HeaderText="Prev. Due" />
                    <asp:BoundField DataField="OverAllFee" HeaderText="Total Amt to be collected overall" />
                    <asp:BoundField DataField="OverAllPaid" HeaderText="Amt Paid Till Date" />
                    <asp:BoundField DataField="OverAllBla" HeaderText="OverAll Bal Amt" />
                    <asp:BoundField DataField="StellBla" HeaderText="OverAll to be collected till date" />
                    <asp:BoundField DataField="StellBla1" HeaderText="Due Amt Till Date" />
                    <asp:BoundField DataField="CMT1T2" HeaderText="Other Fee" />
                    <asp:BoundField DataField="CMT1T2REC" HeaderText="Other Rec." />
                    <asp:BoundField DataField="CMT1T2BLA" HeaderText="Other Bal." />
                    <asp:BoundField DataField="TotBla" HeaderText="Overall Due Amount" />
                    <asp:BoundField DataField="LastPaymentDate" HeaderText="Last Payment Date" DataFormatString="{0:dd/MM/yyyy}" />
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
