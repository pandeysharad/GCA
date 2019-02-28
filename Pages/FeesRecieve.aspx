<%@ Page Title="Fees Recieve" Language="C#" MasterPageFile="~/Pages/MasterPage.master"
    AutoEventWireup="true" CodeFile="FeesRecieve.aspx.cs" Inherits="Pages_FeesRecieve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">

        function MessageShow(msg) {
            alert(msg);
        }
    </script>
    <style>
        th
        {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel6"
        runat="server">
        <ProgressTemplate>
            <img alt="Process....." src="../img/final_loading_big.gif" />
            <%-- <img alt="Process....." src="../loader.gif" />--%>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <div class="row" style="margin-top: 10px; margin-bottom: 10px">
                <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                    color: White; height: 35px; margin-bottom: 2px">
                    <div class="col-sm-12" style="margin-left: 10px">
                        <div class="form-horizontal">
                            <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                                font-size: 22px; font-family: Maiandra GD">
                                FEES MANAGE / RECEIVE
                                <asp:TextBox ID="txtpayMonthTransportFee" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtTransportFeesDetails" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtpayMonthClassFee" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtclassFessDetails" runat="server" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="border: thin solid black;">
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -16px;
                        margin-right: -16px">
                        <div class="col-sm-10">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -11px">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="col-xs-2" id="divAdminNo" runat="server">
                                                <asp:TextBox ID="txtAdminNo" CssClass="form-control  input-sm" placeholder="Scholar No..."
                                                    runat="server" onkeyup="SetContextKey()" MaxLength="8" AutoPostBack="True" OnTextChanged="txtAdminNo_TextChanged"></asp:TextBox>
                                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4" ServicePath="~/AutoComplete.asmx"
                                                    ServiceMethod="GetAdmNo" MinimumPrefixLength="1" CompletionInterval="0" UseContextKey="true"
                                                    CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                                    Enabled="True" TargetControlID="txtAdminNo">
                                                </cc1:AutoCompleteExtender>
                                            </div>
                                            <div class="col-xs-2">
                                                <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" Width="100%"
                                                    OnClick="btnSearchDetails_Click">
                                   <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-xs-1">
                                                <asp:LinkButton ID="btnAllFeesRefresh" CssClass="btn btn-primary" runat="server"
                                                    Width="100%" OnClick="btnAllFeesRefresh_Click">
                        <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <%--Start Advance sarch--%>
                                            <div class="col-xs-3">
                                                <asp:CheckBox ID="cbAdvance" runat="server" OnCheckedChanged="cbAdvance_CheckedChanged"
                                                    Text="Advance Search" AutoPostBack="true" />
                                            </div>
                                            <panel runat="server" id="AdvanceSearch" visible="false">
                            <table style="">
                                <tr>
                                    <td style="width: 33%;">
                                        <div class="col-xs-12">
                                    <asp:DropDownList ID="ddlClassName" runat="server" Width="100%"
                                        CssClass="form-control  input-sm" 
                                        onselectedindexchanged="ddlClassName_SelectedIndexChanged" AutoPostBack="true" >
                                    </asp:DropDownList>
                                </div>
                                    </td>
                                    <td style="width: 33%;"><div class="col-xs-12">
                                    <asp:DropDownList ID="ddlSectionName" runat="server" 
                                        CssClass="form-control  input-sm" 
                                        onselectedindexchanged="ddlSectionName_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                    </asp:DropDownList>
                                </div></td>
                                <td style="width: 33%;"><div class="col-xs-12">
                                    <asp:DropDownList ID="ddlStudentName" runat="server" 
                                        CssClass="form-control  input-sm" 
                                        onselectedindexchanged="ddlStudentName_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                    </asp:DropDownList>
                                </div></td>
                                </tr>
                            </table>
                            
                           
                                
                                
                                
                            </panel>
                                            <%--End Advance sarch --%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-sm-2" >
            <div class="form-horizontal">   
                <div class="form-group" style="margin-top:-13px">            
                      
            </div>
            </div>
        </div>--%>
                    </div>
                    <div id="Div1" class="col-xs-2" runat="server" visible="false">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:Label ID="lbStudentId" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="lbFlag" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="lblPaymentId" runat="server" Text="0"></asp:Label>
                        <asp:Label ID="lblDelete" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="panel-body" style="border-bottom: thin solid blue; margin-left: -15px;
                        margin-right: -15px; padding-left: 0px; padding-right: 0px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <%--Asset Fine Start--%>
                                <div class="col-sm-12" runat="server" id="tableAssetFine" visible="false" style="padding: 2px;
                                    margin-bottom: 23px; border: 5px solid red">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridAssetFine" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="#">
                                                            <ItemTemplate>
                                                                <%= ++SrNoForAssetFine %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TABLEVALUE" HeaderText="Head" />
                                                        <asp:BoundField DataField="Fine" HeaderText="Amount" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text="Proceed to pay" ID="lnkAssetFine" ForeColor="Red" runat="server"
                                                                    OnClick="AssetFine_Click" CommandArgument='<%# Eval("id") %>' Visible="true"
                                                                    OnClientClick="return confirm('Proceed to pay??');" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Asset Fine end--%>
                                <div class="col-sm-5" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                Admi. No:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtAdmissionNo" CssClass="form-control  input-sm" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4" style="margin-top: -5px">
                                                Stud. Name:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtStudentName" CssClass="form-control  input-sm" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4" style="margin-top: -5px">
                                                Father Name:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtFatherName" CssClass="form-control  input-sm" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4" style="margin-top: -5px">
                                                Child Status:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtChildStatus" CssClass="form-control  input-sm" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                <table class="table table-bordered" width="100%">
                                                    <%= ChiledStatusDetails%>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <asp:Image ID="imgStudentImg" Height="150px" Width="140px" BorderWidth="1px" Style="border: thin solid black;
                                                margin-top: -10px;" runat="server"></asp:Image>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-5" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                <%= Session["ClassLableText"]%>/Section:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtCourse" CssClass="form-control  input-sm" Enabled="false" Style="text-transform: uppercase"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                <%= Session["ClassLableText"]%>
                                                Fees:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtCourseFees" CssClass="form-control  input-sm" Style="text-transform: uppercase"
                                                    runat="server" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                Transport Fees:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtTransportFees" CssClass="form-control  input-sm" Style="text-transform: uppercase"
                                                    runat="server" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                Payable Fees:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtTotalPayable" Style="text-transform: uppercase" Enabled="false"
                                                    CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px" runat="server" id="DivlblTransportArea"
                                            visible="false">
                                            <label for="message" class="col-xs-4">
                                                Tarns. Area :</label>
                                            <div class="col-xs-8">
                                                <asp:Label ID="lblTransportArea" runat="server" Text="" CssClass="form-control  input-sm"
                                                    ForeColor="Green"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                                Transport Status:</label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlTransportStaus" CssClass="form-control  input-sm" runat="server"
                                                    OnSelectedIndexChanged="ddlTransportStaus_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem>STATUS</asp:ListItem>
                                                    <asp:ListItem>START</asp:ListItem>
                                                    <asp:ListItem>STOP</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4" style="color: Green; font-weight: bold" runat="server"
                                                visible="false" id="lblToArea">
                                                To Area:</label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control  input-sm" AutoPostBack="true"
                                                    Visible="false" OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-top: -10px">
                                            <label for="message" class="col-xs-4">
                                            </label>
                                            <div class="col-xs-8">
                                                <table runat="server" visible="false" id="tblTransportStatusMonth">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnTransportStatus" runat="server" Text="" Style="padding: 20; margin: 20"
                                                                BackColor="#FF5050" BorderColor="#FF5050" Font-Bold="True" Font-Size="15" ForeColor="White"
                                                                OnClick="btnTransportStatus_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="margin-bottom: -20px; margin-top: 10px" id="Previous"
                                    runat="server" visible="false">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="message" class="col-xs-2">
                                                Previous Balance:</label>
                                            <div class="col-xs-2" style="margin-left: -33px">
                                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="true" CssClass="form-control  input-sm"
                                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                    <asp:ListItem>2018-19</asp:ListItem>
                                                    <asp:ListItem>2019-20</asp:ListItem>
                                                    <asp:ListItem>2020-21</asp:ListItem>
                                                    <asp:ListItem>2021-22</asp:ListItem>
                                                    <asp:ListItem>2022-23</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-xs-2">
                                                <asp:TextBox ID="txtOpening" CssClass="form-control  input-sm" placeholder="Previous Balance"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-1">
                                                <asp:Button ID="btnOpeningSave" runat="server" Text="Add" CssClass="btn btn-primary"
                                                    OnClick="btnOpeningSave_Click" OnClientClick="return confirm('Are you sure??');" />
                                            </div>
                                            <div class="col-xs-1">
                                            </div>
                                            <div class="col-xs-2" style="margin-left: -25px;">
                                                <asp:CheckBox ID="chkPreviouse" Text="Pay Prev Bal" runat="server" AutoPostBack="True"
                                                    OnCheckedChanged="chkPreviouse_CheckedChanged" />
                                            </div>
                                            <div class="col-xs-2" style="margin-left: -50px;">
                                                <asp:TextBox ID="txtPaidPreviousBalance" CssClass="form-control  input-sm" Enabled="false"
                                                    runat="server" AutoPostBack="True" OnTextChanged="txtPaidPreviousBalance_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Panel ID="PnlLabel" Style="margin-left: 15px; margin-right: 15px; background-color: Maroon;
                                            color: White; margin-top: 12px;" runat="server" Visible="false">
                                            <span><b>Previous Balance</b></span><br />
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" style="margin-top: 15px;">
                                        <asp:GridView ID="GridPreviousPaid" Width="100%" DataKeyNames="PaymentId" CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                            runat="server" ShowFooter="false" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SN." HeaderStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <%=++SrNo %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton Text="Edit" ID="lnkSelect" ForeColor="Red" runat="server" OnClick="Edit_Click"
                                                            CommandArgument='<%# Eval("PaymentId") %>' Visible="false" />
                                                        |<asp:LinkButton Text="Print" ID="lnkPrint" ForeColor="Blue" runat="server" OnClick="Print_Click"
                                                            CommandArgument='<%# Eval("PaymentId") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
                                                <asp:BoundField DataField="PaymentType" HeaderText="Payment Mode" />
                                                <asp:BoundField DataField="PreviousSession" HeaderText="Previous Session" />
                                                <asp:BoundField DataField="PreviousPaid" HeaderText="Previous Paid" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="margin-top: 30px;" id="IdInstallments" runat="server"
                                    visible="false">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -13px">
                                            <asp:GridView ID="GridInstallments" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
                                                ShowFooter="True" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Date" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtInstallmentId" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# Eval("InstallmentId") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" OnCheckedChanged="chk1_OnCheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtInstallmentDate" Width="100%" Height="30px" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "InstallmentDate")).ToShortDateString()%>' />
                                                            <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" CssClass="black"
                                                                PopupPosition="TopRight" Format="dd/MM/yyyy" TargetControlID="txtInstallmentDate">
                                                            </cc1:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCourseFees" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"CourseFees") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Fees">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportFees" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"TransportFees") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCoursePaid" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                AutoPostBack="true" OnTextChanged="txtCoursePaid_OnTextChanged" Text='<%# DataBinder.Eval(Container.DataItem,"CousePaid") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPayClassFees" ForeColor="White" BackColor="Green" BorderColor="Green"
                                                                runat="server" Width="100%" Height="30px" Enabled="false" AutoPostBack="true"
                                                                OnTextChanged="txtCoursePaid_OnTextChanged" Text="0"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Paid">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportPaid" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                AutoPostBack="true" OnTextChanged="txtTransportPaid_OnTextChanged" Text='<%# DataBinder.Eval(Container.DataItem,"TransportPaid") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay Transport Fee">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPayTransportFees" ForeColor="White" BackColor="Green" BorderColor="Green"
                                                                runat="server" Width="100%" Height="30px" Enabled="false" AutoPostBack="true"
                                                                OnTextChanged="txtTransportPaid_OnTextChanged" Text="0"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCourseBalance" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"CourseBalance") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Balance">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportBalance" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"TransportBalance") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" ControlStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="comPaymentMode" CssClass="form-control input-sm" AutoPostBack="true"
                                                                runat="server" OnSelectedIndexChanged="comPaymentMode_OnSelectedIndexChanged">
                                                                <asp:ListItem>PAID</asp:ListItem>
                                                                <asp:ListItem>BALANCE</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkTransport" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="margin-top: 30px;" id="IdMonthlyInstallments" runat="server"
                                    visible="false">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -13px">
                                            <asp:GridView ID="GridMonthlyInstallments" runat="server" AutoGenerateColumns="False"
                                                OnRowDataBound="Monthly_OnRowDataBound" ShowFooter="True" Width="100%" CellPadding="4"
                                                ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Date" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtMonthlyInstId" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# Eval("MonthlyInstId") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" OnCheckedChanged="chk1_MOnCheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Months">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtMonths" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# Eval("Months") %>' />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtInstallmentDate" Width="100%" Height="30px" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "InstallmentDate")).ToShortDateString()%>' />
                                                            <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" CssClass="black"
                                                                PopupPosition="TopRight" Format="dd/MM/yyyy" TargetControlID="txtInstallmentDate">
                                                            </cc1:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCourseFees" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"CourseFees") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Fees">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportFees" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"TransportFees") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCoursePaid" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                AutoPostBack="true" OnTextChanged="txtCoursePaid_MOnTextChanged" Text='<%# DataBinder.Eval(Container.DataItem,"CousePaid") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPayClassFees" ForeColor="White" BackColor="Green" BorderColor="Green"
                                                                runat="server" Width="100%" Height="30px" Enabled="false" AutoPostBack="true"
                                                                OnTextChanged="txtCoursePaid_MOnTextChanged1" Text="0"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Paid">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportPaid" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                AutoPostBack="true" OnTextChanged="txtTransportPaid_MOnTextChanged" Text='<%# DataBinder.Eval(Container.DataItem,"TransportPaid") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay Transport Fee">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPayTransportFees" ForeColor="White" BackColor="Green" BorderColor="Green"
                                                                runat="server" Width="100%" Height="30px" Enabled="false" AutoPostBack="true"
                                                                OnTextChanged="txtTransportPaid_MOnTextChanged" Text="0"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCourseBalance" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"CourseBalance") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Transport Balance">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTransportBalance" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"TransportBalance") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="comPaymentMode" CssClass="form-control  input-sm" AutoPostBack="true"
                                                                runat="server" OnSelectedIndexChanged="comPaymentMode_MOnSelectedIndexChanged">
                                                                <asp:ListItem>PAID</asp:ListItem>
                                                                <asp:ListItem>BALANCE</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="130px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkTransport" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="panel-body" runat="server" id="pnl1" style="margin-left: -15px; margin-right: -15px;
                        padding-left: 0px; padding-right: 0px; border-bottom: thin solid blue;">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="col-sm-2" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Fee Type
                                                <asp:DropDownList ID="ddlLateFeesType" CssClass="form-control  input-sm" runat="server"
                                                    OnSelectedIndexChanged="ddlLateFeesType_OnSelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Fees
                                                <asp:TextBox ID="txtAdmiFees" CssClass="form-control  input-sm" runat="server" AutoPostBack="True" Enabled="false"
                                                    OnTextChanged="txtAdmiFees_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Pay.Mode
                                                <asp:DropDownList ID="ddlPaymentMode" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                                    <asp:ListItem>CASH</asp:ListItem>
                                                    <asp:ListItem>RTGS</asp:ListItem>
                                                    <asp:ListItem>NEFT</asp:ListItem>
                                                    <asp:ListItem>CHEQUE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Receipt.No
                                                <asp:TextBox ID="txtReceiptNo" Enabled="false" CssClass="form-control  input-sm"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                <span style="margin-left: 5px;">
                                                    <%=Session["ClassLableText"]%>
                                                    Fees</span>
                                                <asp:TextBox ID="txtInstallCourseFees" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True" Enabled="False" OnTextChanged="txtInstallCourseFees_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Transport Fees
                                                <asp:TextBox ID="txtInstallTransportFees" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True" Enabled="False" OnTextChanged="txtInstallTransportFees_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Discount Type
                                                <asp:DropDownList ID="ddlDiscountType" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Transport Fee</asp:ListItem>
                                                    <asp:ListItem>Class Fee</asp:ListItem>
                                                    <asp:ListItem>Previous Session</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1" style="margin-bottom: -20px">
                                    <div class="form-horizontal">
                                        <div class="form-group" style="margin-top: -10px">
                                            <div class="col-xs-12">
                                                Discount
                                                <asp:TextBox ID="txtDiscount" CssClass="form-control  input-sm" Enabled="false" runat="server"
                                                    AutoPostBack="True" placeholder="Rs." OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" id="DivCheque" runat="server" visible="false" style="margin-top: 20px;
                                    margin-left: -15px;">
                                    <div class="col-sm-2" style="margin-bottom: -20px">
                                        <div class="form-horizontal">
                                            <div class="form-group" style="margin-top: -10px">
                                                <div class="col-xs-12">
                                                    Bank Name
                                                    <asp:TextBox ID="txtBankName" CssClass="form-control  input-sm" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2" style="margin-bottom: -20px">
                                        <div class="form-horizontal">
                                            <div class="form-group" style="margin-top: -10px">
                                                <div class="col-xs-12">
                                                    Cheque Number
                                                    <asp:TextBox ID="txtchequeNo" CssClass="form-control  input-sm" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2" style="margin-bottom: -20px">
                                        <div class="form-horizontal">
                                            <div class="form-group" style="margin-top: -10px">
                                                <div class="col-xs-12">
                                                    Cheque Date
                                                    <asp:TextBox ID="txtChequeDate" CssClass="form-control  input-sm" runat="server"
                                                        AutoPostBack="True"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" CssClass="black"
                                                        PopupPosition="TopRight" Format="dd/MM/yyyy" TargetControlID="txtChequeDate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="margin-top: 20px">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-xs-1">
                                                <asp:CheckBox ID="chkOtherFees" runat="server" Text="Other" Checked="true" OnCheckedChanged="chkOtherFees_CheckedChanged"
                                                    AutoPostBack="True" />
                                            </div>
                                            <div class="col-xs-2" style="display: none">
                                                <asp:DropDownList ID="comOtherFeesType" runat="server" AutoPostBack="true" Enabled="false"
                                                    CssClass="form-control  input-sm" OnSelectedIndexChanged="comOtherFeesType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-xs-1">
                                                <asp:TextBox ID="txtOtherFees" Enabled="false" CssClass="form-control  input-sm"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-1" style="margin-bottom: -20px">
                                                <div class="form-horizontal">
                                                    <div class="form-group" style="margin-top: -10px">
                                                        <div class="col-xs-12">
                                                            Miscell.
                                                            <asp:TextBox ID="txtLateFees" CssClass="form-control  input-sm" runat="server" AutoPostBack="True"
                                                                OnTextChanged="txtLateFees_TextChanged"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <label for="message" class="col-xs-1" style="text-align: right">
                                                Total:
                                            </label>
                                            <div class="col-xs-2">
                                                <asp:TextBox ID="txtTotal" Enabled="false" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <label for="message" class="col-xs-1" style="text-align: right">
                                                Rec.Date:
                                            </label>
                                            <div class="col-xs-2">
                                                <asp:TextBox ID="dtReceivedDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" CssClass="black"
                                                    PopupPosition="TopRight" Format="dd/MM/yyyy" TargetControlID="dtReceivedDate">
                                                </cc1:CalendarExtender>
                                            </div>
                                            <div class="col-xs-1">
                                                <asp:LinkButton ID="btnFeesReceipt" CssClass="btn btn-primary" runat="server" Width="100%"
                                                    OnClick="btnFeesReceipt_Click" OnClientClick="return confirm('Are you sure??');"
                                                    AccessKey="s">
                        <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-xs-1">
                                                <asp:LinkButton ID="btnFeesRefresh" CssClass="btn btn-primary" runat="server" Width="100%"
                                                    OnClick="btnFeesRefresh_Click">
                        <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="message" class="col-xs-1">
                                                Remarks:</label>
                                            <div class="col-xs-9">
                                                <asp:TextBox ID="txtRemarks" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--Other Fees--%>
                        <div class="col-sm-5">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridOtherFee" runat="server" AutoGenerateColumns="False" Visible="true"
                                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" ItemStyle-BackColor="Yellow">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkOtherFee" runat="server" AutoPostBack="true" OnCheckedChanged="chkOtherFeen_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fees Type">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtFeesType" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"FeesType") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fees">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtFees" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"Fees") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <%--Grid Discount Fee--%>
                        <div class="col-sm-5">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="UpdatePanelDiscount" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridDiscountFee" runat="server" AutoGenerateColumns="False" Visible="true"
                                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" ItemStyle-BackColor="Yellow">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkDiscountFee" runat="server" AutoPostBack="true" OnCheckedChanged="chkDiscountFees_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount Reason">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDiscountReason" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"CourseRemarks") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtDiscountAmount" runat="server" Width="100%" Height="30px" Enabled="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem,"DiscountAmount") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-bottom: 0px;">
                                    <div style="background-color: Yellow; text-align: center; font-weight: bold" runat="server"
                                        id="divOtherFeesPaidHead" visible="false">
                                        Other Fees Paid =
                                        <asp:Label ID="lblOtherFeesPaidHead" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" style="margin-left: -15px; margin-right: -15px; padding-left: 0px;
                        padding-right: 0px">
                        <div class="row" style="margin-top: 5px;">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="col-sm-12" style="margin-bottom: -30px;">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <div class="col-xs-12" style="margin-bottom: -15px; margin-top: -20px; margin-right: -15px">
                                                    <asp:GridView ID="GridStudentFees" runat="server" HeaderStyle-BackColor="#cce6ff"
                                                        AutoGenerateColumns="false" Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                                        HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                                        RowStyle-Font-Bold="true" ShowFooter="true" FooterStyle-BackColor="#66ccff" FooterStyle-Font-Bold="true"
                                                        EmptyDataRowStyle-HorizontalAlign="Center">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton Text="Print" ID="lnkPrint" ForeColor="Blue" runat="server" OnClick="Print_Click"
                                                                        CommandArgument='<%# Eval("PaymentId") %>' />
                                                                    <asp:LinkButton Text="Cancel" ID="lnkDelete" ForeColor="Red" runat="server" OnClick="Delete_Click"
                                                                        CommandArgument='<%# Eval("PaymentId") %>' Visible="true" OnClientClick="return confirm('Are you sure Delete this reciept??');" />
                                                                    <asp:LinkButton Text="Edit" ID="lnkSelect" ForeColor="Red" runat="server" OnClick="Edit_Click"
                                                                        CommandArgument='<%# Eval("PaymentId") %>' Visible="false" OnClientClick="return confirm('Are you sure edit ??');" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="PaymentDate" HeaderText="Payment Date"
                                                                DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField ItemStyle-Width="5%" DataField="ReceiptNo" HeaderText="Receipt No" />
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="PaymentType" HeaderText="Payment Mode" />
                                                            <asp:BoundField ItemStyle-Width="0" DataField="PreviousSession" HeaderText="" Visible="false" />
                                                            <asp:BoundField ItemStyle-Width="0" DataField="PreviousPaid" HeaderText="" Visible="false" />
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="LateFees" HeaderText="Miscella." />
                                                            <asp:BoundField ItemStyle-Width="7%" DataField="TABLEVALUE" HeaderText="Fee Type"
                                                                HeaderStyle-Width="5%" />
                                                             <asp:BoundField ItemStyle-Width="7%" DataField="AdmissionFees" HeaderText="Fee"
                                                                HeaderStyle-Width="5%" />
                                                            <asp:BoundField ItemStyle-Width="10%" DataField="OtherFeesType" HeaderText="Other-Fees-Type" />
                                                            <asp:BoundField ItemStyle-Width="10%" DataField="OtherFees" HeaderText="Other-Fees"
                                                                HeaderStyle-Width="5%" />
                                                            <asp:BoundField ItemStyle-Width="10%" DataField="CourseFees" HeaderText="Class-Fees" />
                                                            <asp:BoundField ItemStyle-Width="10%" DataField="TransportFees" HeaderText="Transport-Fees" />
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="Discount" HeaderText="Discount(Rs)" />
                                                            <asp:BoundField ItemStyle-Width="10%" DataField="TotalFees" HeaderText="Total-Fees" />
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="PayMonths" HeaderText="Month" />
                                                            <asp:BoundField ItemStyle-Width="8%" DataField="DiscountType" HeaderText="DiscountType"
                                                                Visible="true" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div class="form-group" style="text-align: center">
                                                        <asp:Label ID="lbMessage" Text="" runat="server" Visible="false"></asp:Label>
                                                        <table width="97%" border="1" style="margin: auto">
                                                            <tr>
                                                                <th colspan="3" style="text-align: center; background-color: Yellow">
                                                                    Fee Details
                                                                </th>
                                                            </tr>
                                                            <tr style="background-color: #FDEB73;">
                                                                <td>
                                                                    Total Fee:
                                                                    <asp:Label ID="lbltotFee" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Total Fee Rec.:
                                                                    <asp:Label ID="lbltotRec" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Total Fee bla.:
                                                                    <asp:Label ID="lbltotbla" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%=Session["ClassLableText"]%>
                                                                    Fee:
                                                                    <asp:Label ID="lbltotClassFee" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Transport Fee:
                                                                    <asp:Label ID="lbltotTransportFee" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Other Fee:
                                                                    <asp:Label ID="lbltotOtherFee" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%=Session["ClassLableText"]%>
                                                                    Fee Rec.:
                                                                    <asp:Label ID="lbltotClassFeeRec" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Transport Fee Rec.:
                                                                    <asp:Label ID="lbltotTransportFeeRec" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Other Fee Rec.:
                                                                    <asp:Label ID="lbltotOtherFeeRec" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%=Session["ClassLableText"]%>
                                                                    Fee Dis.:
                                                                    <asp:Label ID="lbltotClassFeeDis" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Transport Fee Dis.:
                                                                    <asp:Label ID="lbltotTransportFeeDis" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Other Fee Dis.:
                                                                    <asp:Label ID="lbltotOtherFeeDis" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%=Session["ClassLableText"]%>
                                                                    Fee bla.:
                                                                    <asp:Label ID="lbltotClassFeeBla" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Transport Fee bla.:
                                                                    <asp:Label ID="lbltotTransportFeeBla" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    Other Fee bla.:
                                                                    <asp:Label ID="lbltotOtherFeeBla" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
