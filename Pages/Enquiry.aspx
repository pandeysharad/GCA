<%@ Page Title="Enquiry" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Enquiry.aspx.cs" Inherits="Pages_Enquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">

        function UpdatePanel() {
            __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
        }
        function Visibility() {
            if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Student") {
                document.getElementById("<%=divStudent.ClientID%>").style.display = "block";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divPreviousSchool.ClientID%>").style.display = "none";
                document.getElementById("<%=divVillage.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByPreviousSchool.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByVillage.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Contact No") {
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "block";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divPreviousSchool.ClientID%>").style.display = "none";
                document.getElementById("<%=divVillage.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByPreviousSchool.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByVillage.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Date") {
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "block";
                document.getElementById("<%=divTo.ClientID%>").style.display = "block";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "block";
                document.getElementById("<%=divPreviousSchool.ClientID%>").style.display = "none";
                document.getElementById("<%=divVillage.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByPreviousSchool.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByVillage.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Previous School") {
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divPreviousSchool.ClientID%>").style.display = "Block";
                document.getElementById("<%=divVillage.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByVillage.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByPreviousSchool.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Area") {
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divPreviousSchool.ClientID%>").style.display = "none";
                document.getElementById("<%=divVillage.ClientID%>").style.display = "Block";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByVillage.ClientID%>").focus();
            }
        }

        function MessageShow(msg) {
            alert(msg);
        }

        function toUpper(obj) {
            var mystring = obj.value;
            var sp = mystring.split(' ');
            var wl = 0;
            var f, r;
            var word = new Array();
            for (i = 0; i < sp.length; i++) {
                f = sp[i].substring(0, 1).toUpperCase();
                r = sp[i].substring(1);
                word[i] = f + r;
            }
            newstring = word.join(' ');
            obj.value = newstring;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        STUDENT ENQUIRY
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="panel-body" style="border: thin solid black; margin-left: 15px; margin-right: 15px;
            margin-top: 2px">
            <div id="page">
                <div id="Tabs" role="tabpanel">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active"><a href="#Enquiry" aria-controls="Enquiry" role="tab" data-toggle="tab">
                            Add/Edit Enquiry</a></li>
                        <li><a href="#EnquiryList" aria-controls="EnquiryList" role="tab" data-toggle="tab">
                            Enquiry List</a></li>
                    </ul>
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="Enquiry" style="background-color: White;
                            border-bottom: thin solid lightgray; border-right: thin solid lightgray; border-left: thin solid lightgray">
                            <div class="panel-body">
                                <div class="col-sm-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Enquiry No:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtEnquiryNo" CssClass="form-control  input-sm" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Student Name:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtStudentName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Area:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtVillage" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4" TargetControlID="txtVillage"
                                                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetVillageName" MinimumPrefixLength="1"
                                                    CompletionInterval="0" CompletionSetCount="20" CompletionListCssClass="completionList"
                                                    CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem"
                                                    DelimiterCharacters="&nbsp;,:" Enabled="True">
                                                </cc1:AutoCompleteExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Address:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtAddress" onkeyup="toUpper(this)" CssClass="form-control  input-sm" TextMode="MultiLine"
                                                    Height="50px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Contact No:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtContactNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Email Id:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtEmailId" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                <%--Previous <%= Session["ClassLableText"]%>:</label>--%>
                                                 <%  if (Session["CompanyType"].ToString() == "college")
                                                {%>
                                                Previous Class/ <% =Session["ClassLableText"]%>
                                                <% }
                                                else
                                                { %>

                                                 Previous <%=Session["ClassLableText"]%>

                                                <%}
                                                             %>:</label>
                                            <div class="col-xs-4">
                                                <asp:DropDownList ID="ddl_PreviousClass" CssClass="form-control  input-sm" AutoPostBack="true"
                                                    runat="server" OnSelectedIndexChanged="ddl_PreviousClass_SelectedIndexChanged">
                                                    <asp:ListItem>SELECT BATCH</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-xs-4" id="divPCP" runat="server" visible="false">
                                                <asp:TextBox ID="txtPCP" CssClass="form-control  input-sm" placeholder="%" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" id="divPrevousSchool" runat="server" visible="false">
                                            <label for="message" class="col-xs-4">
                                                 <%  if (Session["CompanyType"].ToString() == "college")
                                                {%>
                                                Previous School/ <% =Session["SchoolLableText"]%>
                                                <% }
                                                else
                                                { %>

                                                 Previous <%=Session["SchoolLableText"]%>

                                                <%}
                                                             %>:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtPreviousSchool" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtPreviousSchool"
                                                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetPreviousSchool" MinimumPrefixLength="1"
                                                    CompletionInterval="0" CompletionSetCount="20" CompletionListCssClass="completionList"
                                                    CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem"
                                                    DelimiterCharacters="&nbsp;,:" Enabled="True">
                                                </cc1:AutoCompleteExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Enquiry for <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddl_EnquiryForCourse" AutoPostBack="true" CssClass="form-control  input-sm"
                                                    runat="server" OnSelectedIndexChanged="ddl_EnquiryForCourse_SelectedIndexChanged">
                                                    <asp:ListItem>SELECT CLASS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Fees:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtFees" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <div class="col-xs-12">
                                             <asp:GridView ID="EnquiryFeeDetails" runat="server" 
                                                  Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                                                <Columns>
                                                </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Enquiry Date:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="dtEnquiryDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY"
                                                    runat="server"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    TargetControlID="dtEnquiryDate" CssClass="black" PopupPosition="TopRight">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Next Call Date:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="dtNextCallDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY"
                                                    runat="server"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtAdmDate1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    TargetControlID="dtNextCallDate" CssClass="black" PopupPosition="TopRight">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Image:</label>
                                            <div class="col-xs-8">
                                                <asp:FileUpload ID="UploadImage" CssClass="form-control  input-sm" runat="server">
                                                </asp:FileUpload>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-4" style="margin-left: -25px;">
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Phone number"
                                                    ForeColor="Red" ControlToValidate="txtContactNo" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                                                <br />
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                                    ForeColor="Red" ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                                            <div class="col-xs-8" style="margin-left: 25px;">
                                                <div class="row">
                                                    <div class="col-xs-6">
                                                        <asp:Image ID="Img1" Height="135px" Width="80%" BorderWidth="1px" runat="server">
                                                        </asp:Image>
                                                    </div>
                                                    <div class="col-xs-5">
                                                        <asp:Button ID="btnPicUpload" CssClass="form-control  input-sm" Text="Img Upload"
                                                            runat="server" OnClick="btnPicUpload_Click"></asp:Button>
                                                        <asp:Button ID="btnClearImg" CssClass="form-control  input-sm" Text="Clear Img" runat="server"
                                                            Style="margin-top: 20px;" OnClick="btnClearImg_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Remarks:</label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtRemarks" onkeyup="toUpper(this)" CssClass="form-control  input-sm" TextMode="MultiLine"
                                                    Height="50px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Status:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddl_Status" CssClass="form-control  input-sm" runat="server">
                                                    <asp:ListItem>SELECT STATUS</asp:ListItem>
                                                    <asp:ListItem>INTERESTED</asp:ListItem>
                                                    <asp:ListItem>NOT INTERESTED</asp:ListItem>
                                                    <asp:ListItem>JOINED</asp:ListItem>
                                                    <asp:ListItem>INTERESTED FOR BPL</asp:ListItem>
                                                    <asp:ListItem>INTERESTED FOR RTE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Enquiry For Session:</label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddlSession" CssClass="form-control  input-sm" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-4">
                                                <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                                <asp:Label ID="lbEnquiryId" runat="server" Visible="false" Text="0"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"
                                                    OnClick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%"
                                                    OnClick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="EnquiryList" style="background-color: White;
                            border-bottom: thin solid lightgray; border-right: thin solid lightgray; border-left: thin solid lightgray">
                            <div class="panel-body">
                                <div class="row" style="margin-top: 5px;">
                                    <div class="col-sm-12" style="margin-bottom: -30px;">
                                        <div class="form-horizontal">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="form-group" style="margin-top: 5px;">
                                                        <label for="message" class="col-xs-1">
                                                            Search:</label>
                                                        <div class="col-xs-2">
                                                            <asp:DropDownList ID="ddl_Search" CssClass="form-control  input-sm" onchange="Visibility()"
                                                                runat="server">
                                                                <asp:ListItem>By Student</asp:ListItem>
                                                                <asp:ListItem>By Contact No</asp:ListItem>
                                                                <asp:ListItem>By Date</asp:ListItem>
                                                                <asp:ListItem>By Previous School</asp:ListItem>
                                                                <asp:ListItem>By Area</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-xs-2" id="divStudent" runat="server">
                                                            <asp:TextBox ID="txtSearchByStudentName" CssClass="form-control  input-sm" placeholder="STUDENT NAME"
                                                                runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-2" id="divContact" runat="server" hidden="true">
                                                            <asp:TextBox ID="txtSearchByContact" CssClass="form-control  input-sm" placeholder="CONTACT No."
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-2" id="divSdate" runat="server" hidden="true">
                                                            <asp:TextBox ID="dtSDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY"
                                                                runat="server"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                TargetControlID="dtSDate" CssClass="black" PopupPosition="TopRight">
                                                            </cc1:CalendarExtender>
                                                        </div>
                                                        <label for="message" class="col-xs-1" runat="server" id="divTo" hidden="true" style="text-align: center">
                                                            To</label>
                                                        <div class="col-xs-2" id="divEdate" runat="server" hidden="true">
                                                            <asp:TextBox ID="dtEDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY"
                                                                runat="server"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                TargetControlID="dtEDate" CssClass="black" PopupPosition="TopRight">
                                                            </cc1:CalendarExtender>
                                                        </div>
                                                        <div class="col-xs-2" id="divPreviousSchool" runat="server" hidden="true">
                                                            <asp:TextBox ID="txtSearchByPreviousSchool" CssClass="form-control  input-sm" placeholder="Previous School"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-2" id="divVillage" runat="server" hidden="true">
                                                            <asp:TextBox ID="txtSearchByVillage" CssClass="form-control  input-sm" placeholder="Village"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" Width="80%"
                                                                OnClick="btnSearchDetails_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                                                            </asp:LinkButton>
                                                        </div>
                                                        <div class="col-xs-2">
                                                            <asp:LinkButton ID="btnPrint" CssClass="btn btn-success" runat="server" Width="80%"
                                                                Style="margin-left: -20px;" OnClick="btnPrint_Click"> 
                                <span aria-hidden="true" class="glyphicon glyphicon-print"> Print</span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:GridView ID="GridEnquiry" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                                            AllowPaging="true" PageSize="20" Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                                            HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                                            RowStyle-Font-Bold="true" AutoGenerateSelectButton="True" DataKeyNames="EnquiryId"
                                                            OnSelectedIndexChanging="GridEnquiry_SelectedIndexChanging" OnPageIndexChanging="GridEnquiry_PageIndexChanging"
                                                            OnRowDataBound="GridEnquiry_RowDataBound" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="3%" DataField="EnquiryNo" HeaderText="SNo" />
                                                                <asp:BoundField ItemStyle-Width="10%" DataField="StudentName" HeaderText="NAME" />
                                                                <asp:BoundField ItemStyle-Width="10%" DataField="Address" HeaderText="ADDRESS" />
                                                                <asp:BoundField ItemStyle-Width="8%" DataField="ContactNo" HeaderText="CONTACT" />
                                                                <asp:BoundField ItemStyle-Width="8%" DataField="PreviousClass" HeaderText="PRE-CLASS" />
                                                                <asp:BoundField ItemStyle-Width="10%" DataField="PreviousSchool" HeaderText="PRE-SCHOOL" />
                                                                <asp:BoundField ItemStyle-Width="10%" DataField="EnquiryForCourse" HeaderText="ENQUIRY-FOR" />
                                                                <asp:BoundField ItemStyle-Width="8%" DataField="fees" HeaderText="FEES" />
                                                                <asp:BoundField ItemStyle-Width="8%" DataField="EnquiryDate" HeaderText="DATE" DataFormatString="{0:d}" />
                                                                <asp:BoundField ItemStyle-Width="8%" DataField="NextCallDate" HeaderText="NEXT-CALL"
                                                                    DataFormatString="{0:d}" />
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        STATUS
                                                                        <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="StatusChanged"
                                                                            AutoPostBack="true" AppendDataBoundItems="true">
                                                                            <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Eval("Status")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="35%">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LnkDelete" OnClientClick="return confirm('Do you want to delete this row...')"
                                                                            CommandArgument='<%# Eval("EnquiryId") %>' ForeColor="Red" Font-Bold="true" runat="server"
                                                                            OnClick="LnkDelete_OnClick">Delete</asp:LinkButton>
                                                                        |<asp:LinkButton Text="Form" ID="LnkJoin" OnClick="OnSelectedJoin" ItemStyle-Width="2%"
                                                                            ForeColor="#337ab7" Font-Bold="true" runat="server" CommandArgument='<%# Eval("EnquiryId") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Right" CssClass="gridview" />
                                                            <SelectedRowStyle BackColor="Black" ForeColor="White" />
                                                            <EmptyDataTemplate>
                                                                No Record Available</EmptyDataTemplate>
                                                        </asp:GridView>
                                                        <b>
                                                            <asp:Label ID="lblAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
                                                        <span style="font-size: small; font-family: Lucida Bright; font-weight: bold;">Number
                                                            Of row :
                                                            <%= row %></span>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
