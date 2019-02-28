<%@ Page Title="Update Fees" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="UpdaetFee.aspx.cs" Inherits="Pages_UpdaetFee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel6"
        runat="server">
        <ProgressTemplate>
            <img alt="Process....." src="../img/final_loading_big.gif" />
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
                                FEES MANAGE / GRID UPDATE
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
                                            <div class="col-xs-4" id="divAdminNo" runat="server">
                                                <asp:TextBox ID="txtAdminNo" CssClass="form-control  input-sm" placeholder="Enter Admission No"
                                                    runat="server" onkeyup="SetContextKey()" MaxLength="8" AutoPostBack="True" OnTextChanged="txtAdminNo_TextChanged"></asp:TextBox>
                                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4" ServicePath="~/AutoComplete.asmx"
                                                    ServiceMethod="GetAdmNo" MinimumPrefixLength="1" CompletionInterval="0" UseContextKey="true"
                                                    CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                                    Enabled="True" TargetControlID="txtAdminNo">
                                                </cc1:AutoCompleteExtender>
                                            </div>
                                            <div class="col-xs-2">
                                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" >
                                   <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                                </asp:LinkButton>
                                            </div>
                                            <div class="col-xs-2">
                                
                                <asp:LinkButton ID="btnUpdate" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnUpdate_Click" OnClientClick="return confirm('Are you sure??');">
                                   <span aria-hidden="true" class="glyphicon glyphicon-Edit"> Update</span>
                                </asp:LinkButton>
                            </div> 
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12" style="margin-top: 30px;" >
                            <table style="width:100%; color:Black">
                                <tr>
                                    <td>Name: <b><%=StudentName %></b></td>
                                    <td>Father Name:<b> <%=FatherName %></b></td>
                                    <td>Class/Section: <b><%=ClassSection %></b></td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-sm-12" style="margin-top: 30px;" id="IdMonthlyInstallments" runat="server"
                            visible="true">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -13px">
                                    <asp:GridView ID="GridMonthlyInstallments" runat="server" AutoGenerateColumns="False"
                                        ShowFooter="True" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtMonthlyInstId" Width="100%" Height="30px" Enabled="false"
                                                        Text='<%# Eval("MonthlyInstId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk1" runat="server"  AutoPostBack="true" OnCheckedChanged="chk1_MOnCheckedChanged"/>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Months">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtMonths" Width="100%" Height="30px" Text='<%# Eval("Months") %>' />
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
                                            <asp:TemplateField HeaderText="Class Fees">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCourseFees" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"CourseFees") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transport Fees">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTransportFees" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"TransportFees") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class Paid">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCoursePaid" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"CousePaid") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transport Paid">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTransportPaid" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"TransportPaid") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            <asp:TemplateField HeaderText="Class Balance">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCourseBalance" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"CourseBalance") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transport Balance">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTransportBalance" runat="server" Width="100%" Height="30px" Text='<%# DataBinder.Eval(Container.DataItem,"TransportBalance") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PaymentStatus" HeaderText="PaymentStatus" />
                                            <asp:TemplateField HeaderText="" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="comPaymentMode" CssClass="form-control  input-sm" runat="server">
                                                        <asp:ListItem>PAID</asp:ListItem>
                                                        <asp:ListItem>BALANCE</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="130px" />
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

