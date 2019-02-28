<%@ Page Title="Asset Fine" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="AssetFine.aspx.cs" Inherits="Pages_AssetFine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                Event & Activities
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
                    </div>
                    <div class="panel-body" style="border-bottom: thin solid blue; margin-left: -15px;
                        margin-right: -15px; padding-left: 0px; padding-right: 0px">
                        <div class="col-sm-12" >
                            <table style="width:100%; color:White;font-weight:bold; background-color:Black;padding:10px;" runat="server" visible="false" id="tableStudentDetails">
                                <tr>
                                    <td> &nbsp;&nbsp;&nbsp;Name: <b><%=StudentName %></b></td>
                                    <td>Father Name:<b> <%=FatherName %></b></td>
                                    <td>Class/Section: <b><%=ClassSection %></b></td>
                                </tr>
                            </table>
                        </div>
                        <table style="width:100%; text-align: center;font-weight:bold" runat="server" id="tableAddAssetFine" visible="false">
                            <tr>
                                <td>Event</td>
                                <td>
                                    <asp:DropDownList ID="ddlFineType" runat="server" Width="100%"
                                        CssClass="form-control  input-sm" >
                                    </asp:DropDownList>
                                </td>
                                <td>Amount</td>
                                <td>
                                    <asp:TextBox ID="txtFineAmount" CssClass="form-control  input-sm" placeholder="0.00..." 
                                                    runat="server" ></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender TargetControlID="txtFineAmount" ID="FilteredtxtFineAmount" runat="server" Enabled="True"  ValidChars="1234567890."> </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>Remarks</td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control  input-sm" placeholder="Remarks..."
                                                    runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                        Width="100%" Text="Save" onclick="btnSave_Click" OnClientClick="return confirm('Are you sure??');">
                                                </asp:LinkButton>
                                </td>
                            </tr>
                        </table>

                        <table style="width:100%; text-align: center;font-weight:bold" runat="server" id="tablePaidFine" visible="false">
                            <tr>
                                <td>Event</td>
                                <td>
                                    <asp:DropDownList ID="ddlFineTpePaid" runat="server" Width="100%"
                                        CssClass="form-control  input-sm" >
                                    </asp:DropDownList>
                                </td>
                                <td>Amount</td>
                                <td>
                                    <asp:TextBox ID="txtFineAmountPaid" CssClass="form-control  input-sm" placeholder="0.00..." 
                                                    runat="server" ></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender TargetControlID="txtFineAmountPaid" ID="FilteredTextBoxExtender1" runat="server" Enabled="True"  ValidChars="1234567890."> </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>Remarks</td>
                                <td>
                                    <asp:TextBox ID="txtRemarksPaid" CssClass="form-control  input-sm" placeholder="Remarks..."
                                                    runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Receipt No</td>
                                <td>
                                    <asp:TextBox ID="txtReceiptNo" Enabled="false" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                </td>
                                <td>ReceivedDate</td>
                                <td>
                                    <asp:TextBox ID="dtReceivedDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" CssClass="black" PopupPosition="TopRight"
                                                                  Format="dd/MM/yyyy" TargetControlID="dtReceivedDate">
                                  </cc1:CalendarExtender> 
                                </td>
                                <td>Pay Mode</td>
                                <td>
                                    <asp:DropDownList ID="ddlPaymentMode" CssClass="form-control  input-sm"  
                                        runat="server" AutoPostBack="true"
                                        onselectedindexchanged="ddlPaymentMode_SelectedIndexChanged">
                                    <asp:ListItem>CASH</asp:ListItem>  
                                    <asp:ListItem>RTGS</asp:ListItem>                     
                                    <asp:ListItem>NEFT</asp:ListItem>                      
                                    <asp:ListItem>CHEQUE</asp:ListItem>                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr id="DivCheque" runat="server" visible="false"  >
                                <td>Bank Name</td>
                                <td>
                                    <asp:TextBox ID="txtBankName" CssClass="form-control  input-sm"  
                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td>Cheque Number</td>
                                <td>
                                    <asp:TextBox ID="txtchequeNo" CssClass="form-control  input-sm"  
                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td>Cheque Date</td>
                                <td>
                                    <asp:TextBox ID="txtChequeDate" CssClass="form-control  input-sm"  
                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" CssClass="black" PopupPosition="TopRight"
                                                                                  Format="dd/MM/yyyy" TargetControlID="txtChequeDate">
                                                  </cc1:CalendarExtender> 
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr style="margin-top:10px !important">
                            <td colspan="5"></td>
                                <td>
                                    <asp:LinkButton ID="btnSavePaid" CssClass="btn btn-primary" runat="server" 
                                        Width="100%" Text="Pay Amount" 
                                        OnClientClick="return confirm('Proceed to pay??');" 
                                        onclick="btnSavePaid_Click" >
                                                </asp:LinkButton>
                                </td>
                            </tr>
                        </table>

                        <div style="border:1px solid black; padding:10px; margin:10px;">
                <asp:GridView ID="GridStudentList" CssClass="GridViewStyle_List" Width="100%" PageSize="15"
                DataKeyNames="AdmissionId" runat="server" AutoGenerateColumns="false">
                <PagerStyle CssClass="PagerStyle" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkall" AutoPostBack="true" Text="All" runat="server" OnCheckedChanged="chckchanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SN.">
                        <ItemTemplate>
                            <%=SrNo++ %>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:BoundField HeaderText="ADMISSION NO." DataField="AdmissionNo" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField HeaderText="STUDENT NAME" DataField="StudentName" />
                </Columns>
                <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                <FooterStyle Font-Bold="true" />
            </asp:GridView>
            </div>
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
