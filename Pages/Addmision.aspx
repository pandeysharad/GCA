<%@ Page Title="Addmision" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Addmision.aspx.cs" Inherits="Pages_Addmision"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function UpdatePanel() {
            __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
        }
        function Visibility() {
            if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Student") {
                document.getElementById("<%=divAdimissionNo.ClientID%>").style.display = "none";
                document.getElementById("<%=divStudent.ClientID%>").style.display = "block";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByAdimissionNo.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Adimission No") {
                document.getElementById("<%=divAdimissionNo.ClientID%>").style.display = "block";
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";

                document.getElementById("<%=txtSearchByAdimissionNo.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Contact No") {
                document.getElementById("<%=divAdimissionNo.ClientID%>").style.display = "none";
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "block";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
                document.getElementById("<%=divTo.ClientID%>").style.display = "none";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByAdimissionNo.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").Text = "";
                document.getElementById("<%=dtEDate.ClientID%>").Text = "";

                document.getElementById("<%=txtSearchByContact.ClientID%>").focus();
            }
            else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Date") {
                document.getElementById("<%=divAdimissionNo.ClientID%>").style.display = "none";
                document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
                document.getElementById("<%=divContact.ClientID%>").style.display = "none";
                document.getElementById("<%=divSdate.ClientID%>").style.display = "block";
                document.getElementById("<%=divTo.ClientID%>").style.display = "block";
                document.getElementById("<%=divEdate.ClientID%>").style.display = "block";
                document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByAdimissionNo.ClientID%>").Text = "";
                document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
                document.getElementById("<%=dtSDate.ClientID%>").focus();
            }
        }
        function MessageShow(msg) {
            alert(msg);
        }

        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);

            return ret;
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

        var isShift = false;
        var seperator = "/";
        function CheckDateFormate(e) {

            //Set Max Length.
            e.setAttribute("maxlength", 10);

            //Only allow Numeric Keys.
            e.onkeydown = function (e) {
                return IsNumeric1(this, e.keyCode);
            };

            //Validate Date as User types.
            e.onkeyup = function (e) {
                ValidateDateFormat(this, e.keyCode);
            };
        };

        function IsNumeric1(input, keyCode) {
            if (keyCode == 16) {
                isShift = true;
            }
            //Allow only Numeric Keys.
            if (((keyCode >= 48 && keyCode <= 57) || keyCode == 8 || keyCode <= 37 || keyCode <= 39 || (keyCode >= 96 && keyCode <= 105)) && isShift == false) {
                if ((input.value.length == 2 || input.value.length == 5) && keyCode != 8) {
                    input.value += seperator;
                }

                return true;
            }
            else {
                return false;
            }
        };

        function ValidateDateFormat(input, keyCode) {
            var dateString = input.value;
            if (keyCode == 16) {
                isShift = false;
            }
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;

            //Check whether valid dd/MM/yyyy Date Format.
            if (regex.test(dateString) || dateString.length == 0) {
                ShowHideError(input, "none");
            } else {
                ShowHideError(input, "block");
            }
        };

        function ShowHideError(textbox, display) {
            var row = textbox.parentNode.parentNode;
            var errorMsg = row.getElementsByTagName("span")[1];
            if (errorMsg != null) {
                errorMsg.style.display = display;
            }
        };

    </script>
 <%--   
    <script type="text/javascript">
        function SetUserName() {
           
            '<%Session["UpdatePage"] = "1"; %>';
            alert('<%=Session["UserName"] %>');
        }
            </script>--%>
    

    <style type="text/css">
        .bank
        {
            margin-top: 3px;
        }
        .btnCalAge
        {
        border-style: none;
        border-color: inherit;
        border-width: 0px;
        color: White;
        /* font-family: OpenSansLight; */
        cursor: pointer;
        background: #0b5390;
        -webkit-transition: background .3s;
        top: 0px;
        left: 11px;
        width: 50px;
        height: 25px;
        }
         .btnCalAge:hover
        {
        border-style: none;
        border-color: inherit;
        border-width: 0px;
        color: White;
        /* font-family: OpenSansLight; */
        cursor: pointer;
        background: orange;
        -webkit-transition: background .3s;
        top: 0px;
        left: 11px;
        width: 50px;
        height: 25px;
        }
         .error
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        ADMISSION
                    </div>
                </div>
            </div>
        </div>
    </div>
     
   <asp:UpdatePanel ID="upmain" runat="server">
   <ContentTemplate>
   <div class="row">
        <div class="col-sm-12">
   <div style="text-align:left;">
    <cc1:Accordion runat="server"  ID="Accordian" 
                         HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                         ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                         TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true" SelectedIndex="-1">
                         <HeaderTemplate >
                          REPORT - ENQUIRY
                         </HeaderTemplate>
                         <Panes>                        
                          <cc1:AccordionPane ID="AcPaymentReceipt" runat="server">
                          <Header>STUDENT STATUS</Header>
                            <Content>
                            <asp:GridView ID="GridStudentStaus" runat="server" 
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                                        <Columns>
                                        </Columns>
                                        </asp:GridView>
                            <fieldset style="width:95%; display:none">
                                <legend>Brother/Sister</legend>
                                <div class="row">
                              
                                    <div class="col-sm-11" style="margin-left:15px;margin-top:-15px; background-color:lightyellow;">
                                        <asp:Panel ID="PnlLabel" runat="server">

                                        </asp:Panel>
                                    </div>
                                </div>
                            </fieldset>
                            </Content>
                         </cc1:AccordionPane>
                         
                         </Panes>
                </cc1:Accordion>
                       
    </div>
    
   </div>
   </div>
   </ContentTemplate>
  </asp:UpdatePanel>
    <div class="panel-body" style="border: thin solid black; margin-top: 2px">
        <div id="page">
            <div id="Tabs" role="tabpanel">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#Admission" aria-controls="Admission" role="tab" data-toggle="tab">
                        Add/Edit Admission</a></li>
                    <li><a href="#AdmissionList" aria-controls="AdmissionList" role="tab" data-toggle="tab">
                        Admission List</a></li>
                    <li><a href="#StudentCourseList" aria-controls="StudentCourseList" role="tab" data-toggle="tab">
                        <%= Session["ClassLableText"]%> Info</a></li>
                </ul>
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="Admission" style="background-color: White;
                        border-bottom: thin solid lightgray; border-right: thin solid lightgray; border-left: thin solid lightgray">
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="col-sm-6">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   1. Adm./Scho. No:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-5">
                                                    <asp:TextBox ID="txtAdmissionNo" CssClass="form-control  input-sm" Enabled="false"
                                                        runat="server" ontextchanged="txtAdmissionNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </div>
                                                <div class="col-xs-3">
                                                    <asp:CheckBox ID="chkAdmissionNo" Text="Edit" runat="server" AutoPostBack="True" OnCheckedChanged="chkAdmissionNo_CheckedChanged" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   2. Adm. Date:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="dtAdmissionDate" CssClass="form-control  input-sm" 
                                                        runat="server" AutoPostBack="True" ontextchanged="dtAdmissionDate_TextChanged"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="dtAdmissionDate" CssClass="black" PopupPosition="TopRight">
                                                    </cc1:CalendarExtender>
                                                    <asp:DropDownList ID="ddlAddmisionIds" runat="server" Visible="False">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group" runat="server" id="AdmittedClass" visible="false">
                                                <label for="message" class="col-xs-4">
                                                   3. Admitted in <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                  <asp:DropDownList ID="ddlAdmittedClass" CssClass="form-control  input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div id="Div1" class="form-group" runat="server">
                                                <label for="message" class="col-xs-4">
                                                   4. Form No.:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFormNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   5. Session:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlSession" CssClass="form-control  input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   6. Student Name:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtStudent" CssClass="form-control  input-sm" onkeyup="toUpper(this)" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   7. Contact(SMS):<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtContact" CssClass="form-control  input-sm" runat="server" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"
                                                        MaxLength="10"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   8. Father's Name:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFatherName" CssClass="form-control  input-sm" onkeyup="toUpper(this)" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   9. Father's Occup.:</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFatherOccupation" CssClass="form-control  input-sm" onkeyup="toUpper(this)" runat="server"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender9" 
                                                        TargetControlID="txtFatherOccupation"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="Foccupation"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   10. Mother's Name:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtMother" CssClass="form-control  input-sm" onkeyup="toUpper(this)" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   11. Mother's Occup.:</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtMotherOccupation" CssClass="form-control  input-sm" onkeyup="toUpper(this)" runat="server"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender10" 
                                                        TargetControlID="txtMotherOccupation"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="Moccupation"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   12 Parent's Contact:</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtParentContact" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group" id="tblForm">
                                                <label for="message" class="col-xs-4">
                                                   13. DOB:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                  <asp:TextBox ID="dt_BOD" CssClass="form-control  input-sm date-format" AutoPostBack="true" ontextchanged="dt_BOD_TextChanged" onkeyup="CheckDateFormate(this)" placeholder="DD/MM/YYYY"
                                                        runat="server"></asp:TextBox>
                                                        <span class="error" style="display: none">Invalid Date. Only dd/MM/yyyy format allowed.</span>
                                                   <%-- <cc1:CalendarExtender ID="txtAdmDate2" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                        TargetControlID="dt_BOD" CssClass="black" PopupPosition="TopRight">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    <asp:Button ID="btnCalAge" CssClass="btnCalAge" runat="server" Text="Age" 
                                                    onclick="btnCalAge_Click" /></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtAge" CssClass="form-control  input-sm" runat="server" 
                                                        ></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--<div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    Section:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtSection" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>--%>
                                           
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   15. Email Id:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtEmailId" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   16. Gender:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlGender" CssClass="form-control  input-sm" 
                                                        runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlGender_SelectedIndexChanged">
                                                        <asp:ListItem>SELECT GENDER</asp:ListItem>
                                                        <asp:ListItem>MALE</asp:ListItem>
                                                        <asp:ListItem>FEMALE</asp:ListItem>
                                                        <asp:ListItem>OTHER</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   17. Category:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddl_Catrgory" CssClass="form-control  input-sm" runat="server">
                                                       
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   18. Religion:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddl_Religion" AutoPostBack="true" CssClass="form-control  input-sm"
                                                        runat="server">
                                                        <asp:ListItem>SELECT RELIGION</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   19.Area</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtVillage" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                      <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender4" 
                                                        TargetControlID="txtVillage"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="GetAdmVillageName"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   20. Address:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtAddress" CssClass="form-control  input-sm" runat="server" TextMode="MultiLine"
                                                        Height="50" AutoPostBack="True" onkeyup="toUpper(this)"></asp:TextBox>
                                                          <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender1" 
                                                        TargetControlID="txtAddress"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="GetAddress"
                                                        MinimumPrefixLength="1" 
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   21. Aadhar No:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtAadharCardNo" CssClass="form-control  input-sm" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"
                                                        runat="server" MaxLength="12"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   22. Samegra Id:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtSamegraId" CssClass="form-control  input-sm" runat="server"  onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"
                                                        MaxLength="9"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   23. Family Id:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFamilyId" CssClass="form-control  input-sm" runat="server"  onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"
                                                        MaxLength="8"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   24. Child Status:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddl_Nationality" CssClass="form-control  input-sm" 
                                                        runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddl_Nationality_SelectedIndexChanged">
                                                        <asp:ListItem>CHILD STATUS</asp:ListItem>
                                                        <asp:ListItem>FIRST</asp:ListItem>
                                                        <asp:ListItem>SECOND</asp:ListItem>
                                                        <asp:ListItem>THIRD</asp:ListItem>
                                                        <asp:ListItem>OTHER</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <table width="100%">
                                                <tr runat="server" id="trClass1">
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                          25.  <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlClass1" CssClass="form-control  input-sm" 
                                                                                runat="server" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlClass1_SelectedIndexChanged" >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           26. First Child Name:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlStudentName1" CssClass="form-control  input-sm" 
                                                                                runat="server"  >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                          27.  Relation:</label>
                                                                        <div class="col-xs-8">
                                                                            <asp:TextBox ID="txtRelation1" runat="server"  CssClass="form-control  input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trClass2">
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                          28.  <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlClass2" CssClass="form-control  input-sm" 
                                                                                runat="server" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlClass2_SelectedIndexChanged" >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           29. Second Child Name:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlStudentName2" CssClass="form-control  input-sm" 
                                                                                runat="server" >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           30. Relation:</label>
                                                                        <div class="col-xs-8">
                                                                            <asp:TextBox ID="txtRelation2" runat="server"  CssClass="form-control  input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trClass3">
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           31. <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlClass3" CssClass="form-control  input-sm" 
                                                                                runat="server" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlClass3_SelectedIndexChanged"  >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           32. Student Name:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlStudentName3" CssClass="form-control  input-sm" 
                                                                                runat="server" >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                          33.  Relation:</label>
                                                                        <div class="col-xs-8">
                                                                            <asp:TextBox ID="txtRelation3" runat="server"  CssClass="form-control  input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trOther1">
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           34. <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlClassOther1" CssClass="form-control  input-sm" 
                                                                                runat="server" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlClassOther1_SelectedIndexChanged"  >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                           35. Child Name:<span for="message" style="color: Red">*</span></label>
                                                                        <div class="col-xs-8">
                                                                            <asp:DropDownList ID="ddlStudentNameOther1" CssClass="form-control  input-sm" 
                                                                                runat="server" >
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <label for="message" class="col-xs-4">
                                                                          36.  Relation:</label>
                                                                        <div class="col-xs-8">
                                                                            <asp:TextBox ID="txtRelationOther1" runat="server"  CssClass="form-control  input-sm" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   37. Profile Pic.:</label>
                                                <div class="col-xs-8">
                                                    <asp:FileUpload ID="UploadImage" CssClass="form-control  input-sm" runat="server">
                                                    </asp:FileUpload>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                </label>
                                                <div class="col-xs-8">
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
                                                   38. Previous <%= Session["ClassLableText"]%>:</label>
                                                <div class="col-xs-4">
                                                    <asp:DropDownList ID="ddl_PreviousClass" CssClass="form-control  input-sm" AutoPostBack="true"
                                                        runat="server" OnSelectedIndexChanged="ddl_PreviousClass_SelectedIndexChanged">
                                                        <asp:ListItem>SELECT</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-xs-4" id="divPCP" runat="server" visible="false">
                                                    <asp:TextBox ID="txtPCP" CssClass="form-control  input-sm" placeholder="%" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group" id="divPreviousSchool" runat="server" visible="False">
                                                <label for="message" class="col-xs-4">
                                                    Previous <%=Session["SchoolLableText"]%>:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtPreviousSchool" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-7" style="color: Blue; margin-bottom: -5px;">
                                                    <u>39. <%= Session["ClassLableText"].ToString().ToUpper()%> INFORMATION:</u></label>
                                                <div class="col-xs-5" style="color: Blue;">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body" style="border: thin solid #42b3f4; padding:5px; margin-top: -2px;
                                            margin-bottom: 15px;">
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddl_Course" AutoPostBack="true" CssClass="form-control  input-sm"
                                                        runat="server" OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged">
                                                        <asp:ListItem>SELECT</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    <%= Session["ClassLableText"]%> Fees:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFees" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group" runat="server"> 
                                                <label for="message" class="col-xs-4">
                                                    Discount Type:</label>
                                                <div class="col-xs-4">
                                                    <asp:DropDownList ID="dd_DiscountType" CssClass="form-control  input-sm" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="dd_DiscountType_SelectedIndexChanged">
                                                        <asp:ListItem>Flat</asp:ListItem>
                                                        <asp:ListItem>Percent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-xs-4">
                                                    <asp:TextBox ID="txtDiscount" CssClass="form-control  input-sm" runat="server" OnTextChanged="txtDiscount_TextChanged"
                                                        AutoPostBack="True" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="Div2" class="form-group" runat="server">
                                                <label for="message" class="col-xs-4">
                                                Fees After Disc:<span for="message" style="color: Red">*</span></label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFeesAfterDisc" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="Div3" class="form-group" runat="server">
                                                <label for="message" class="col-xs-4">
                                                    Discount Reason:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFeesRemarks" CssClass="form-control  input-sm" runat="server"
                                                        TextMode="MultiLine" Height="50"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   <%=Session["SectionLableText"]%>:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlSection" CssClass="form-control  input-sm" runat="server">
                                                   <%-- <asp:ListItem>Not Assigned</asp:ListItem>
                                                    <asp:ListItem>A</asp:ListItem>
                                                    <asp:ListItem>B</asp:ListItem>
                                                    <asp:ListItem>C</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                               40. <asp:CheckBox ID="chkBank1" Text="Bank1 Details" AutoPostBack="true" OnCheckedChanged="chkBank1_OnCheckedChanged"
                                                    runat="server" /></label>
                                            <div class="col-xs-8" id="Bank1" runat="server" visible="false">
                                            <asp:TextBox ID="txtBankName1" CssClass="form-control  input-sm" runat="server"
                                                    placeholder="BANK NAME"></asp:TextBox>
                                                     <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender2" 
                                                        TargetControlID="txtBankName1"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="BankName1"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                <asp:TextBox ID="txtAccountNumber1" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="ACCOUNT NUMBER"></asp:TextBox>
                                                <asp:TextBox ID="txtIFSCcode1" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="IFSC CODE"></asp:TextBox>
                                                     <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender3" 
                                                        TargetControlID="txtIFSCcode1"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="IFSC1"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                <asp:TextBox ID="txtBranchName1" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="BRANCH NAME"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender5" 
                                                        TargetControlID="txtBranchName1"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="BranchName1"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                              41.  <asp:CheckBox ID="chkBank2" Text="Bank2 Details" AutoPostBack="true" OnCheckedChanged="chkBank2_OnCheckedChanged"
                                                    runat="server" /></label>
                                            <div class="col-xs-8" id="Bank2" runat="server" visible="false">
                                             <asp:TextBox ID="txtBankName2" CssClass="form-control  input-sm" runat="server"
                                                    placeholder="BANK NAME"></asp:TextBox>
                                                     <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender6" 
                                                        TargetControlID="txtBankName2"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="BankName2"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                <asp:TextBox ID="txtAccountNumber2" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="ACCOUNT NUMBER"></asp:TextBox>
                                                <asp:TextBox ID="txtIFSCcode2" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="IFSC CODE"></asp:TextBox>
                                                     <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender7" 
                                                        TargetControlID="txtIFSCcode2"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="IFSC2"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                <asp:TextBox ID="txtBranchName2" CssClass="form-control  input-sm bank" runat="server"
                                                    placeholder="BRANCH NAME"></asp:TextBox>
                                                     <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender8" 
                                                        TargetControlID="txtBranchName2"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="BranchName2"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                              42.  Fees Type:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-6">
                                                <asp:DropDownList ID="ddlPaymentType" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Installment</asp:ListItem>
                                                    <asp:ListItem>Monthly</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group" id="Install" runat="server" visible="false">
                                            <label for="message" class="col-xs-4">
                                                No. Of Installment:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-4">
                                                <asp:TextBox ID="txtNoOfInstallment" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="form-group" runat="server" ID="HideShowStudentCommingFrom" visible="false">
                                            <label for="message" class="col-xs-4">
                                              43.  Student coming from :</label>
                                            <div class="col-xs-6">
                                                <asp:DropDownList ID="ddlStudentComingFrom" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True"  OnSelectedIndexChanged="ddlStudentComingFrom_SelectedIndexChanged">
                                                    <asp:ListItem>SCHOOL TRANSPORT</asp:ListItem>
                                                    <asp:ListItem>SELF TRANSPORT</asp:ListItem>
                                                    <asp:ListItem>PUBLIC TRANSPORT</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="form-group" id="TrasportType" runat="server" visible="false">
                                            <label for="message" class="col-xs-4">
                                              <%=LabelTrasportType %>:</label>
                                            <div class="col-xs-6">
                                                <asp:DropDownList ID="ddlTrasportType" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group">
                                            <div class="col-xs-7" style="color: Blue;">
                                              <asp:CheckBox ID="ChkTransport" runat="server" Text="Transport facility..." AutoPostBack="true"
                                                    OnCheckedChanged="ChkTransport_CheckedChanged" Visible="False" />
                                            </div>
                                            <div class="col-xs-5">
                                                <asp:LinkButton ID="lblDoc" CssClass="btn btn-success" runat="server" Width="100%"
                                                    OnClick="lblDoc_Click" Visible="false">
                                <span aria-hidden="true" class="fa fa-upload"> Upload Certificate</span>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="panel-body" runat="server" visible="false" id="TrasportId" style="border: thin solid #42b3f4;
                                           padding: 5px; margin-top: -2px; margin-bottom: 15px;">
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    From:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtFrom" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    To:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control  input-sm" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    Transport Fees:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtTransportFees" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="Div4" class="form-group" runat="server" visible="false">
                                                <label for="message" class="col-xs-4">
                                                    Discount Type:</label>
                                                <div class="col-xs-4">
                                                    <asp:DropDownList ID="ddlTransportDiscType" CssClass="form-control  input-sm" AutoPostBack="true"
                                                        runat="server" OnSelectedIndexChanged="ddlTransportDiscType_SelectedIndexChanged">
                                                        <asp:ListItem>Flat</asp:ListItem>
                                                        <asp:ListItem>Percent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-xs-4">
                                                    <asp:TextBox ID="txtTransportDisc" CssClass="form-control  input-sm" AutoPostBack="true"
                                                        runat="server" OnTextChanged="txtTransportDisc_TextChanged"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="Div5" class="form-group" runat="server" visible="false">
                                                <label for="message" class="col-xs-4">
                                                    Fees After Disc:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtTransportFeesAfterDisc" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    Remarks:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtTransportRemarks" CssClass="form-control  input-sm" runat="server"
                                                        TextMode="MultiLine" Height="50"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-12" style="color: Blue;">
                                              44.  <asp:CheckBox ID="chkOtherInformation" runat="server" Text="Family Details" AutoPostBack="true"
                                                    OnCheckedChanged="chkOtherInformation_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="panel-body" runat="server" visible="false" id="DivOtherInformation" style="border: thin solid #42b3f4;
                                            height: 230px; margin-top: -2px; margin-bottom: 15px;">
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    No. Of Child In Family:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlNoOfChildInFamily" runat="server" CssClass="form-control  input-sm"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    No. Of Brothers /Sisters:</label>
                                                <div class="col-xs-4">
                                                    <asp:DropDownList ID="ddlNoOfBrothers" runat="server" CssClass="form-control  input-sm"
                                                        AutoPostBack="true" placeholder="No. Of Brothers">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-xs-4">
                                                    <asp:DropDownList ID="ddlNoOfSisters" runat="server" CssClass="form-control  input-sm"
                                                        AutoPostBack="true" placeholder="No. Of Sisters">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    Anual Income:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtAnualIncome" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                    Blood Group /Height:</label>
                                                <div class="col-xs-4">
                                                    <asp:TextBox ID="txtBloodGroup" CssClass="form-control  input-sm" runat="server"
                                                        placeholder="Blood Group"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender
                                                        runat="server"
                                                        ID="AutoCompleteExtender11" 
                                                        TargetControlID="txtBloodGroup"
                                                        ServicePath="~/AutoComplete.asmx"
                                                        ServiceMethod="BloodGroup"
                                                        MinimumPrefixLength="1"
                                                        CompletionInterval="0"
                                                        CompletionSetCount="20"
                                                        CompletionListCssClass="CompletionListCssClass"
                                                        CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                        CompletionListItemCssClass="CompletionListItemCssClass"
                                                        DelimiterCharacters="&nbsp;,:" 
                                                        Enabled="True" >
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                                <div class="col-xs-4">
                                                    <asp:TextBox ID="txtHeight" CssClass="form-control  input-sm" placeholder="Height"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                           <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                  45.  <%=Session["StreamLableText"]%>:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlStream" runat="server" CssClass="form-control  input-sm"
                                                        AutoPostBack="true">

                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   46. Other Fees:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txttotOtherFee" Enabled="false" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   47. Total Fees:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtTotalFees" Enabled="false" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="form-group">
                                               <label for="message" class="col-xs-4">
                                                   48. Status:</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control  input-sm"
                                                        AutoPostBack="true" 
                                                        onselectedindexchanged="ddlStatus_SelectedIndexChanged">

                                                    </asp:DropDownList>
                                            </div>
                                            </div>
                                              <div class="form-group" runat="server" id="TC" visible="false">
                                               <label for="message" class="col-xs-4">
                                                    TC Issue Date:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="txtTcIssueDate" CssClass="form-control  input-sm" 
                                                        runat="server" AutoPostBack="True"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="txtTcIssueDate" CssClass="black" PopupPosition="TopRight">
                                                    </cc1:CalendarExtender>
                                            </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="message" class="col-xs-4">
                                                   48. P.M Anniversary Date:</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox ID="dtPMADate" CssClass="form-control  input-sm" 
                                                        runat="server" AutoPostBack="True" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender15" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="dtPMADate" CssClass="black" PopupPosition="TopRight">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                        <div class="form-group">
                                            <div class="col-xs-4">
                                                <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                                <asp:Label ID="lbAdmissionId" runat="server" Visible="false" Text="0"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                               <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"
                                                   OnClientClick="return confirm('Are you sure??');" OnClick="btnSave_Click">
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnPicUpload" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="AdmissionList" style="background-color: White;
                        border-bottom: thin solid lightgray; border-right: thin solid lightgray; border-left: thin solid lightgray">
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
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
                                                                    <asp:ListItem>By Adimission No</asp:ListItem>
                                                                    <asp:ListItem>By Contact No</asp:ListItem>
                                                                    <asp:ListItem>By Date</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-xs-2" id="divStudent" runat="server">
                                                                <asp:TextBox ID="txtSearchByStudentName" CssClass="form-control  input-sm" placeholder="STUDENT NAME"
                                                                    runat="server"> </asp:TextBox>
                                                                     <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender13" ServicePath="~/AutoComplete.asmx"
                                                                    ServiceMethod="GetStudentName" MinimumPrefixLength="1" CompletionInterval="0" UseContextKey="true"
                                                                    CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                                                    Enabled="True" TargetControlID="txtSearchByStudentName">
                                                                </cc1:AutoCompleteExtender>
                                                            </div>
                                                            <div class="col-xs-2" id="divAdimissionNo" runat="server" hidden="true">
                                                                <asp:TextBox ID="txtSearchByAdimissionNo" CssClass="form-control  input-sm" placeholder="ADMISSION NO"
                                                                    runat="server"> </asp:TextBox>
                                                                     <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender12" ServicePath="~/AutoComplete.asmx"
                                                                    ServiceMethod="GetAdmNo" MinimumPrefixLength="1" CompletionInterval="0" UseContextKey="true"
                                                                    CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                                                    Enabled="True" TargetControlID="txtSearchByAdimissionNo">
                                                                </cc1:AutoCompleteExtender>
                                                            </div>
                                                            <div class="col-xs-2" id="divContact" runat="server" hidden="true">
                                                                <asp:TextBox ID="txtSearchByContact" CssClass="form-control  input-sm" placeholder="CONTACT No."
                                                                    runat="server"></asp:TextBox>
                                                                     <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender14" ServicePath="~/AutoComplete.asmx"
                                                                    ServiceMethod="GetContactNo" MinimumPrefixLength="1" CompletionInterval="0" UseContextKey="true"
                                                                    CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                                                    Enabled="True" TargetControlID="txtSearchByContact">
                                                                </cc1:AutoCompleteExtender>
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
                                                            <div class="col-xs-2">
                                                                <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" Width="80%"
                                                                    OnClick="btnSearchDetails_Click" OnClientClick="SetUserName()">
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
                                                            <asp:GridView ID="GridAdmission" runat="server" AutoGenerateColumns="false"
                                                                AllowPaging="true" PageSize="20" Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                                                 DataKeyNames="AdmissionId" AutoGenerateSelectButton="true"
                                                                OnSelectedIndexChanging="GridAdmission_SelectedIndexChanging" 
                                                                OnPageIndexChanging="GridAdmission_PageIndexChanging" 
                                                                ShowHeaderWhenEmpty="True">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="6%" DataField="AdmissionNo" 
                                                                        HeaderText="Adm-No" >
                                                                    <ItemStyle Width="6%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="AdmissionDate" HeaderText="Adm-Date"
                                                                        DataFormatString="{0:d}" >
                                                                    <ItemStyle Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="12%" DataField="StudentName" 
                                                                        HeaderText="Stu. Name" >
                                                                    <ItemStyle Width="12%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="ContactNo" 
                                                                        HeaderText="Contact" >
                                                                    <ItemStyle Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="13%" DataField="FatherName" 
                                                                        HeaderText="Father" >
                                                                    <ItemStyle Width="13%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="14%" DataField="MotherName" 
                                                                        HeaderText="Mother" >
                                                                    <ItemStyle Width="14%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="DOB" HeaderText="DOB" >
                                                                    <ItemStyle Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="CourseName" HeaderText="Class" >
                                                                    <ItemStyle Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="Section" HeaderText="SEC." >
                                                                    <ItemStyle Width="8%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="6%" DataField="Gender" HeaderText="GEN." >
                                                                    <ItemStyle Width="6%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="6%" DataField="EnrollmentNo" 
                                                                        HeaderText="Village" >
                                                                    <ItemStyle Width="6%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="12%" DataField="Address" HeaderText="Address" >
                                                                    <ItemStyle Width="12%" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            Status
                                                                            <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="StatusChanged"
                                                                                AutoPostBack="true" AppendDataBoundItems="true">
                                                                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("R1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle HorizontalAlign = "Right"   CssClass="gridview" />
                                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
                                                             <b><asp:Label ID="lblAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
                                                               <span style="font-size:small;font-family:Lucida Bright;font-weight:bold;"></span>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                              
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="StudentCourseList" style="background-color: White;
                        border-bottom: thin solid lightgray; border-right: thin solid lightgray; border-left: thin solid lightgray">
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-12" style="margin-bottom: -30px;">
                                            <div class="form-horizontal">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <div class="col-xs-3">
                                                                <asp:TextBox ID="txtSearch" CssClass="form-control  input-sm" runat="server" placeholder="Student Name and Course Name"></asp:TextBox>
                                                            </div>
                                                            <div class="col-xs-1">
                                                                <asp:LinkButton ID="btnCourseSearch" CssClass="btn btn-primary" runat="server" Width="100%"
                                                                    OnClick="btnCourseSearch_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col-xs-1">
                                                                <asp:LinkButton ID="btnCoursePrint" CssClass="btn btn-success" runat="server" Width="100%"
                                                                    Style="margin-left: -20px;" OnClick="btnCoursePrint_Click"> 
                                <span aria-hidden="true" class="glyphicon glyphicon-print"></span>
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:GridView ID="GridStudentCourse" runat="server"  CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                                                DataKeyNames="AdmissionId" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                                                OnPageIndexChanging="GridStudentCourse_PageIndexChanging" AutoGenerateSelectButton="true"
                                                                OnSelectedIndexChanging="GridStudentCourse_SelectedIndexChanging" 
                                                                ShowHeaderWhenEmpty="True">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="6%" DataField="AdmissionNo" HeaderText="Adm-No" />
                                                                    <asp:BoundField ItemStyle-Width="10%" DataField="StudentName" HeaderText="STUDENT NAME" />
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="ContactNo" HeaderText="CONTACT" />
                                                                    <asp:BoundField ItemStyle-Width="9%" DataField="FatherName" HeaderText="FATHER" />
                                                                    <asp:BoundField ItemStyle-Width="8%" DataField="CourseFees" HeaderText="FEES" />
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <%= Session["ClassLableText"].ToString().ToUpper()%>
                                                                            <asp:DropDownList ID="ddlCourseName" runat="server" OnSelectedIndexChanged="CourseNameChanged"
                                                                                AutoPostBack="true" AppendDataBoundItems="true">
                                                                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="ddlSection" runat="server" OnSelectedIndexChanged="SectionChanged"
                                                                                AutoPostBack="true" AppendDataBoundItems="true">
                                                                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("CourseName")%>(<%# Eval("Section")%>)
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="7%" DataField="CourseDiscountType" HeaderText="DISC TYPE" />
                                                                    <asp:BoundField ItemStyle-Width="7%" DataField="CourseDiscount" HeaderText="DISCOUT" />
                                                                    <asp:BoundField ItemStyle-Width="10%" DataField="CourseFeesAfterDisc" HeaderText="FEES AFTER DISC" />
                                                                    <asp:BoundField ItemStyle-Width="7%" DataField="TotalFees" HeaderText="TOTAL FEES" />
                                                                     <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            STATUS
                                                                            <asp:DropDownList ID="ddlCourseStatus" runat="server" OnSelectedIndexChanged="CourseStatusChanged"
                                                                                AutoPostBack="true" AppendDataBoundItems="true">
                                                                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Eval("R1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle HorizontalAlign = "Right"   CssClass="gridview" />
                                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
                                                             <b><asp:Label ID="lblCourseAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
                                                               <span style="font-size:small;font-family:Lucida Bright;font-weight:bold;"></span>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
