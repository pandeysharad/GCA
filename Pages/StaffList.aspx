<%@ Page Title="Staff List" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="StaffList.aspx.cs" Inherits="Pages_StaffList" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../lib/datatables/extras/TableTools/media/css/TableTools.css">
    <script language="javascript" type="text/javascript">
        function ShowProcessImage() {
            var autocomplete = document.getElementById('txtSearchByStaffId');
            autocomplete.style.backgroundImage = 'url(../images/ld.gif)';
            autocomplete.style.backgroundRepeat = 'no-repeat';
            autocomplete.style.backgroundPosition = 'right';
        }
        function HideProcessImage() {
            var autocomplete = document.getElementById('txtSearchByStaffId');
            autocomplete.style.backgroundImage = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 10px; margin-bottom: 10px">
        <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
            color: White; height: 35px; margin-bottom: 2px">
            <div class="col-sm-12" style="margin-left: 10px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        STAFF LIST
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="border: thin solid black;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="panel-body" style="background-color: #05BBF7; height: 38px; margin: -15px">
                        <div class="col-sm-12" style="margin-top: -10px">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-bottom: 3px">
                                    <label for="message" class="col-xs-2" style="text-align: right; margin-top: 3px">
                                        Search By:</label>
                                    <div class="col-xs-3">
                                        <asp:DropDownList ID="comSearchBy" CssClass="form-control  input-sm" onchange="divvisible()"
                                            runat="server">
                                            <asp:ListItem>BOTH</asp:ListItem>
                                            <asp:ListItem>ACTIVE</asp:ListItem>
                                            <asp:ListItem>INACTIVE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                       <asp:TextBox ID="txtSearchByStaffId" CssClass="form-control  input-sm" runat="server" placeholder="Search by Staff Id" ClientIDMode="Static"></asp:TextBox>
                                        <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4" ServicePath="~/AutoComplete.asmx"
                                            ServiceMethod="GetStaffId" MinimumPrefixLength="1" CompletionInterval="0" CompletionSetCount="20"
                                            CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" OnClientPopulating="ShowProcessImage" OnClientPopulated="HideProcessImage"
                                            TargetControlID="txtSearchByStaffId">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnSearchDetails_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:LinkButton ID="btnPrint" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnPrint_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-print"> Print</span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divPrint" class="panel-body" style="margin: -31px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                        <asp:GridView CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" ID="GridStaffDetails"
                            runat="server" AllowPaging="True" PageSize="8" AllowSorting="True" ShowFooter="True"
                            DataKeyNames="StaffPId" AutoGenerateSelectButton="true" OnSelectedIndexChanging="GridStaffDetails_SelectedIndexChanging"
                            OnPageIndexChanging="GridStaffDetails_PageIndexChanging">
                            <RowStyle CssClass="RowStyle" />
                            <Columns>
                                <asp:BoundField DataField="StaffId" HeaderText="STAFF ID" />
                                <asp:BoundField DataField="StaffType" HeaderText="STAFF TYPE" />
                                <asp:BoundField DataField="JoinDate" HeaderText="JOIN-DATE" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="StaffName" HeaderText="NAME" />
                                <asp:BoundField DataField="ContactNo" HeaderText="CONTACT" />
                                <asp:BoundField DataField="WhatsAppNo" HeaderText="WHATSAPP" />
                                <asp:BoundField DataField="EmailId" HeaderText="EMAIL" />
                                <asp:BoundField DataField="ParentContact" HeaderText="PARENT-CONATCT" />
                                <asp:BoundField DataField="DOB" HeaderText="DOB" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Gender" HeaderText="GENDER" />
                                <asp:BoundField DataField="Qualification" HeaderText="QUALIFICATION" />
                                <asp:BoundField DataField="Category" HeaderText="CAST" />
                                <asp:BoundField DataField="Status" HeaderText="STATUS" />
                            </Columns>
                            <PagerStyle CssClass="PagerStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                             <SelectedRowStyle BackColor="Black" ForeColor="White" />
                        </asp:GridView>
                        <b>
                            <asp:Label ID="lblAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
</asp:Content>
