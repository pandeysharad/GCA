<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddmisionReportDataAll.aspx.cs" Inherits="Reports_AddmisionReportDataAll"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Links/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <!-- FOR Date -->
    <link href="../CalenderTheme/black.css" rel="stylesheet" type="text/css" />
    <link href="../CalenderTheme/orange.css" rel="stylesheet" type="text/css" />
    <link href="../CalenderTheme/red.css" rel="stylesheet" type="text/css" />
   <%-- <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Links/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="../Links/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Links/metisMenu/metisMenu.min.js" type="text/javascript"></script>
    <script src="../Links/raphael/raphael.min.js" type="text/javascript"></script>
    <script src="../Links/dist/js/sb-admin-2.min.js" type="text/javascript"></script>
    <link href="../css1/jquery-ui1.css" rel="stylesheet" type="text/css" />
      <%--  <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>--%>
    <script src="../js/html5shiv.js" type="text/javascript"></script>
    <script src="../js/respond.min.js" type="text/javascript"></script>
    <script src="../js/jquery.min1.js" type="text/javascript"></script>
       <script type="text/javascript" language="javascript">

           function MessageShow(msg) {
               alert(msg);
           }
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
           function SetPlaceHolderText() {
               var SelectedValue = $('#ddlSelectOption option:selected').val();
               if (SelectedValue == 0) {
               }
               if (SelectedValue == 1) {
                   $('#txtSearch').prop('placeholder', 'Enter Name...');
               }
               else if (SelectedValue == 2) {
                   $('#txtSearch').prop('placeholder', 'Enter Contact no...');
               }
               else if (SelectedValue == 3) {
                   $('#txtSearch').prop('placeholder', 'Enter Aadhar no...');
               }
               else if (SelectedValue == 4) {
                   $('#txtSearch').prop('placeholder', 'Enter Samagra Id...');
               }
               else if (SelectedValue == 5) {
                   $('#txtSearch').prop('placeholder', 'Enter Family Id...');
               }
               else if (SelectedValue == 6) {
                   $('#txtSearch').prop('placeholder', 'Enter Scholar/Admision no...');
               }
               else if (SelectedValue == 7) {
                   $('#txtSearch').prop('placeholder', 'Enter Bank account no. no...');
               }
               else if (SelectedValue == 8) {
                   $('#txtSearch').prop('placeholder', 'Enter Father’s name...');
               }
               else if (SelectedValue == 9) {
                   $('#txtSearch').prop('placeholder', 'Enter Mother’s name...');
               }
           }
    </script>
    <style type="text/css">
        .form
        {
            font-weight: bold;
            color: Black;
            display: block;
            width: 100%;
            margin-left:0px !important; 
        }
         .form1
        {
            font-weight: bold;
            color: Black;
            display: block;
            width: 100%;
            margin-left:0px !important; 
            font-size:12px;
        }
         input[type=text]:focus,input[type=submit]:focus,input[type=file]:focus,textarea:focus,select:focus,td:focus
        {
            background-color: Black;
            border: 1px solid Red;
            color:White;
            font-size:14px;
        }
        .style1
        {
            width: 3px;
        }
        .style2
        {
            width: 250px;
            height: 68px;
        }
  .container {
    display: block;
    position: relative;
    padding-left: 35px;
    margin-bottom: 12px;
    cursor: pointer;
    font-size: 14px;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

/* Hide the browser's default checkbox */
.container input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
    height: 0;
    width: 0;
}

/* Create a custom checkbox */
.checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 14px;
    width: 14px;
    border: 1px #2196F3 solid;
    background-color: #eee;
}

/* On mouse-over, add a grey background color */
.container:hover input ~ .checkmark {
    background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.container input:checked ~ .checkmark {
    background-color: #2196F3;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
    content: "";
    position: absolute;
    display: none;
}

/* Show the checkmark when checked */
.container input:checked ~ .checkmark:after {
    display: block;
}

/* Style the checkmark/indicator */
.container .checkmark:after {
    left: 4px;
    top: 0px;
    width: 3px;
    height: 10px;
    border: solid white;
    border-width: 0 3px 3px 0;
    -webkit-transform: rotate(45deg);
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
}
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #fff;
            border: 3px solid #ccc;
            width:60%;
        }
        .close 
        {
    float: right;
    margin-right: 16px
}
    </style>
     
  </head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods = "true">
    </asp:ScriptManager>
    <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>--%>
      <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel6" runat="server">
    <ProgressTemplate>
    <img alt="Process....." src="../img/final_loading_big.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress> 
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="UpdateProgresspnl"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none;">
        <div>
        <asp:Button ID="btnClose" CssClass="close" runat="server" Text="Close" />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                                color: White; height: 30px; margin-top: 1px">
                                <div class="form-horizontal">
                                    <div class="form-group" style="text-align: center;font-weight: bold;
                                        font-size: 22px; font-family: Maiandra GD; margin-top: 1px">
                                       EDIT ADMISION DETAILS 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                        <table style="width:100%;padding:10px;">
                        <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Admission no.</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtAdmissionno" style="width:90%;" Enabled="false" 
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Student Name</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtStudentName" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                       <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Contact no.</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtContact" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Father's Name</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtFatherName" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                        <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Mother's Name</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtMotherName" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Parent's Contact</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtParentContact" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                          <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Bank Name</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtBankName" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Account No.</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtAccountNo" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                          <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Aadhar No.</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtAadharNo" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Samegra Id</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtSamegraId" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                         <tr>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Family Id</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtFamilyId" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        <td style='width:20%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'>Email Id</td>
                        <td style='width:30%;font-family: Lucida Bright;font-size:15px;font-weight: bold;padding-bottom:0px;'><asp:textbox id="txtEmailId" style="width:90%;"
                                            runat="server"></asp:textbox></td>
                        </tr>
                        </table>
                   <%-- <div class="row">
                        <div class="col-sm-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="message" class="col-xs-6">
                                        1. Adm./Scho. No:<span for="message" style="color: Red">*</span></label>
                                    <div class="col-xs-6">
                                        <asp:TextBox ID="txtAdmissionNo" CssClass="form-control  input-sm" Enabled="false"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    
             <asp:Button ID="BtnSubmit" runat="server" Text="Save" OnClick="BtnSubmit_OnClick" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <br /><br /><asp:Label ID="lblMsg" runat="server" Text="" Visible="false"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
    </asp:Panel>
     
     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
       <ContentTemplate>
    <div>
      <div style="width:100%">
           
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
           <div style="text-align:center">
           <table style="width:100%">
            <tr style="background-color:#EDEDED">
             <td  style="width:100%;font-weight:bold;font-family:Lucida Bright;color:#0487B2;font-size:22px;font-weight:bold" colspan="5" align="center"><%=SchoolName%><span style="float:right;font-size:15px;font-weight:bold;background-color:Yellow;">&nbsp;&nbsp;&nbsp;&nbsp;No. Of Rows:-&nbsp;&nbsp;<%=GridRowCount%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
             </tr>
           <tr>
             <td  style="width:15%" align="left">
                <asp:DropDownList ID="ddlSelectOption" style="width:100%;height: 32px !important;margin-top: 2px;" CssClass="Form" runat="server" 
                AutoPostBack="true" OnSelectedIndexChanged="ddlSelectOption_OnSelectedIndexChanged" onchange="SetPlaceHolderText();">
                <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                <asp:ListItem Text="STUDENT NAME" Value="1"></asp:ListItem>
                <asp:ListItem Text="CONTACT NO." Value="2"></asp:ListItem>
                <asp:ListItem Text="AADHAR" Value="3"></asp:ListItem>
                <asp:ListItem Text="SAMAGRA ID" Value="4"></asp:ListItem>
                <asp:ListItem Text="FAMILY ID" Value="5"></asp:ListItem>
                <asp:ListItem Text="SCHOLAR/ADMISION NO." Value="6"></asp:ListItem>
                <asp:ListItem Text="BANK ACCOUNT NO." Value="7"></asp:ListItem>
                <asp:ListItem Text="FATHER’S NAME" Value="8"></asp:ListItem>
                <asp:ListItem Text="MOTHER’S NAME" Value="9"></asp:ListItem>
             </asp:DropDownList>
             </td>
               <td  style="width:20%" runat="server" id="TdSearch" align="left" >
              <asp:TextBox ID="txtSearch" style="width:80%;" Enabled="false" CssClass="form" runat="server" AutoPostBack="true" onkeyup = "SetContextKey()"
              OnTextChanged="txtSearch_OnTextChanged"></asp:TextBox>
               <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4"
                                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetALLByOption" MinimumPrefixLength="1"
                                    CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                    CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                    CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                    Enabled="True" TargetControlID="txtSearch">
                                </cc1:AutoCompleteExtender>                         
             </td>
             <td  style="width:40;font-size:17px;font-weight:bold">REPORT-STUDENT ADMISSION DETAILS</td>
             <td  style="width:15%">Print DateTime: <%= System.DateTime.Now.ToString("dd/MM/yy HH:MM") %>
             <asp:ImageButton ID="ImageButton1" runat="server" Visible="false" ImageUrl="~/img/exl.png" ToolTip="Export in Excel"
                                Height="19px" Width="19px" OnClick="ExportToExcel" />
             </td>
             <td  style="width:10%" align="center">
                  <asp:Button ID="btnPrint" CssClass="form-control  input-sm" Text="PRINT" 
                                                    runat="server" OnClick="btnPrint_OnClick"  >
                                                </asp:Button>
                                             
             </td>
             </tr>
           </table>

           </div>
           <hr style="color:Black;margin:0px 0px 0px 0px"/>
      </div>
     
       <div style="">
      <div>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
        <asp:GridView ID="GridCourseWiseData" style="text-align:left;padding:5px;font-weight:bold" 
        CssClass="table table-striped table-bordered table-hover dataTable no-footer" Width="100%"
         DataKeyNames="CourseId" runat="server" ShowFooter="false"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="True"
         EmptyDataText="No records Found" >
       <%----%>
        
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
        
          <asp:TemplateField HeaderText="#">
               <ItemTemplate>
               <%=SrNo++ %>
               </ItemTemplate>
          </asp:TemplateField>
          <%--<asp:BoundField DataField="AdmissionNo" HeaderText="Adm-No." />--%>
          <asp:TemplateField>
            <HeaderTemplate>
                 <label class="container">
                <asp:CheckBox ID="chkAdmissionNo" runat="server" />
                <span class="checkmark"></span>
                Schol.-No.
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("AdmissionNo")%>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkStudentName" runat="server"   />
                <span class="checkmark"></span>
             Student Name
            </HeaderTemplate>
            <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("StudentName")%>' ID="lnkPrint" ForeColor="#0487B2" OnClick="StudentName_Click" runat="server" CommandArgument='<%# Eval("AdmissionId") %>' />
                <%--<%# Eval("StudentName")%>--%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="AdmittedInClass" HeaderText="Admitted Class" />--%>
          <%--<asp:BoundField DataField="CourseName" HeaderText="Current Class" />--%> 
            <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkCourseName" runat="server" />
                <span class="checkmark"></span>
                Current <%=Session["ClassLableText"]%>
              </label>
                <asp:DropDownList ID="ddlCourseName" CssClass="form" runat="server" OnSelectedIndexChanged="CourseNameChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("CourseName")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="Section" HeaderText="Section" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkSection" runat="server"   />
                <span class="checkmark"></span>
               <%=Session["SectionLableText"]%>
               </label>
               <asp:DropDownList ID="ddlSection" CssClass="form" runat="server" OnSelectedIndexChanged="SectionChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Section")%>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkStream" runat="server" />
                <span class="checkmark"></span>
                <%=Session["StreamLableText"]%>
              </label>
                <asp:DropDownList ID="ddlStream" CssClass="form" runat="server" OnSelectedIndexChanged="StreamChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Stream")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="Status" HeaderText="Prev. School" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkStatus" runat="server"   />
                <span class="checkmark"></span>
              <%-- Prev. <%=Session["SchoolLableText"]%>--%>
                <%  if (Session["CompanyType"].ToString() == "college")
                    {%>
                    Prev.School/ <% =Session["SchoolLableText"]%>
                    <% }
                    else
                    { %>

                        Prev.<%=Session["SchoolLableText"]%>

                    <%}
                                    %>
                </label>
                <asp:DropDownList ID="ddlPrevSchool" CssClass="form" runat="server" OnSelectedIndexChanged="PrevSchoolChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Status")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="EnrollmentNo" HeaderText="Area" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkEnrollmentNo" runat="server"   />
                <span class="checkmark"></span>
               Area
              </label>
                <asp:DropDownList ID="ddlArea" CssClass="form" runat="server" OnSelectedIndexChanged="AreaChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("EnrollmentNo")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="AdmissionDate" HeaderText="AdmDate" DataFormatString="{0:dd/MM/yyyy}" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkAdmissionDate" runat="server"   />
                <span class="checkmark"></span>
              AdmDate
              </label>
                <asp:TextBox ID="txtFrom" CssClass="form" placeholder="From" runat="server" AutoPostBack="true" ontextchanged="txtFrom_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                         TargetControlID="txtFrom" CssClass="black" PopupPosition="BottomRight">
                          </cc1:CalendarExtender>
                <asp:TextBox ID="txtTo" CssClass="form" placeholder="To" runat="server" AutoPostBack="true" ontextchanged="txtTo_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                         TargetControlID="txtTo" CssClass="black" PopupPosition="BottomRight">
                          </cc1:CalendarExtender>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Convert.ToDateTime(Eval("AdmissionDate")).ToString("dd/MM/yyyy") %>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="StudentName" HeaderText="Student Name" />--%>
          
          <%--<asp:BoundField DataField="ContactNo" HeaderText="Contact" />--%>
            <asp:TemplateField>
            <HeaderTemplate>
              <label class="container">
                <asp:CheckBox ID="chkContactNo" runat="server"   />
                <span class="checkmark"></span>
             Contact
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("ContactNo")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="FatherName" HeaderText="Father" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkFatherName" runat="server"   />
                <span class="checkmark"></span>
             Father
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("FatherName")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="Foccupation" HeaderText="F. Occup." />--%>
            <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkFoccupation" runat="server"   />
                <span class="checkmark"></span>
            F. Occup.
            </label>
             <asp:DropDownList ID="ddlFoccupation" CssClass="form" runat="server" OnSelectedIndexChanged="FoccupationChanged"
                AutoPostBack="true" >
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Foccupation")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="ParentContact" HeaderText="Mob.No." />--%>
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkParentContact" runat="server"   />
                <span class="checkmark"></span>
             P.Mob.No.
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("ParentContact")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="MotherName" HeaderText="Mother" />--%> 
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkMotherName" runat="server"   />
                <span class="checkmark"></span>
                Mother
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("MotherName")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="Moccupation" HeaderText="M. Occup." />--%>     
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkMoccupation" runat="server"   />
                <span class="checkmark"></span>
                M. Occup.
                </label>
                <asp:DropDownList ID="ddlMoccupation" CssClass="form" runat="server" OnSelectedIndexChanged="MoccupationChanged"
                AutoPostBack="true" >
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Moccupation")%>
            </ItemTemplate>
        </asp:TemplateField>  
         <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkChildStatus" runat="server" />
                <span class="checkmark"></span>
                Child Status
              </label>
                <asp:DropDownList ID="ddlChildStatus" CssClass="form" runat="server" OnSelectedIndexChanged="ChildStatusChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Nationality")%>
            </ItemTemplate>
        </asp:TemplateField>  
          <%--<asp:BoundField DataField="DOB" HeaderText="DOB" />--%>     
            <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkDOB" runat="server"   />
                <span class="checkmark"></span>
                DOB
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("DOB")%>
            </ItemTemplate>
        </asp:TemplateField>    
         <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkStudentAge" runat="server"   />
                <span class="checkmark"></span>
                Student Age
                </label>
                 <asp:TextBox ID="txtExtraAge" CssClass="form" Placeholder="Select Date" runat="server" AutoPostBack="true" ontextchanged="txtExtraAge_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy"
                         TargetControlID="txtExtraAge" CssClass="black" PopupPosition="BottomRight">
                          </cc1:CalendarExtender>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("StudentAge")%>
            </ItemTemplate>
        </asp:TemplateField>        
          <%--<asp:BoundField DataField="Medium" HeaderText="Medium" Visible="false"/>--%>
          <%--<asp:BoundField DataField="Gender" HeaderText="Gender" />--%>
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkGender" runat="server"   />
                <span class="checkmark"></span>
                Gender
              </label>
                <asp:DropDownList ID="ddlGender" CssClass="form" runat="server" OnSelectedIndexChanged="GenderChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Gender")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="Category" HeaderText="Category" />--%>
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkCategory" runat="server"   />
                <span class="checkmark"></span>
                Category
              </label>
                 <asp:DropDownList ID="ddlCategory" CssClass="form" runat="server" OnSelectedIndexChanged="CategoryChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Category")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="Religion" HeaderText="Religion" />--%>
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkReligion" runat="server"   />
                <span class="checkmark"></span>
                Religion
                 </label>
                <asp:DropDownList ID="ddlReligion" CssClass="form" runat="server" OnSelectedIndexChanged="ReligionChanged"
                AutoPostBack="true" >
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Religion")%>
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkBankName" runat="server" />
                <span class="checkmark"></span>
                Bank Name
              </label>
                <asp:DropDownList ID="ddlBankName" CssClass="form" runat="server" OnSelectedIndexChanged="BankNameChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("BankName")%>
            </ItemTemplate>
        </asp:TemplateField>
          <%--<asp:BoundField DataField="CourseFees" HeaderText="Class Fees" />
          <asp:BoundField DataField="CourseDiscountType" HeaderText="Disc. Type" />
          <asp:BoundField DataField="CourseDiscount" HeaderText="Disc." />
          <asp:BoundField DataField="CourseFeesAfterDisc" HeaderText="After Disc." />
          <asp:BoundField DataField="CourseRemarks" HeaderText="Course Remarks" />
          <asp:BoundField DataField="To" HeaderText="To" />--%>
          <%--<asp:BoundField DataField="Address" HeaderText="Address" />--%>
            <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkAddress" runat="server"   />
                <span class="checkmark"></span>
               Address
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Address")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="PaymentType" HeaderText="Month / Install" />
          <asp:BoundField DataField="NoOfInstallment" HeaderText="NOI" />--%>
          <%--<asp:BoundField DataField="AadharCardNo" HeaderText="Aadhar" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkAadharCardNo" runat="server"   />
                <span class="checkmark"></span>
               Aadhar
               </label>
                <asp:DropDownList ID="ddlAadhar" CssClass="form" runat="server" OnSelectedIndexChanged="AadharChanged"
                AutoPostBack="true" >
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem>AVAILABLE</asp:ListItem>
                <asp:ListItem>NOT AVAILABLE</asp:ListItem>
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("AadharCardNo")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="SamegraId" HeaderText="Samegra Id" />--%>
          <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkSamegraId" runat="server"   />
                <span class="checkmark"></span>
               Samegra Id
               </label>
                <asp:DropDownList ID="ddlSamegra" CssClass="form" runat="server" OnSelectedIndexChanged="SamegraChanged"
                AutoPostBack="true" >
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem>AVAILABLE</asp:ListItem>
                <asp:ListItem>NOT AVAILABLE</asp:ListItem>
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("SamegraId")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="FamilyId" HeaderText="Family Id" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkFamilyId" runat="server"   />
                <span class="checkmark"></span>
               Family Id
               </label>
                <asp:DropDownList ID="ddlFamily" CssClass="form" runat="server" OnSelectedIndexChanged="FamilyChanged"
                AutoPostBack="true" >
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem>AVAILABLE</asp:ListItem>
                <asp:ListItem>NOT AVAILABLE</asp:ListItem>
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("FamilyId")%>
            </ItemTemplate>
        </asp:TemplateField> 
          
          <%--<asp:BoundField DataField="EmailId" HeaderText="EmailId" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
            <label class="container">
                <asp:CheckBox ID="chkEmailId" runat="server"   />
                <span class="checkmark"></span>
               EmailId
               </label>
                <asp:DropDownList ID="ddlEmailId" CssClass="form" runat="server" OnSelectedIndexChanged="EmailIdChanged"
                AutoPostBack="true" >
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem>AVAILABLE</asp:ListItem>
                <asp:ListItem>NOT AVAILABLE</asp:ListItem>
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("EmailId")%>
            </ItemTemplate>
        </asp:TemplateField> 
          <%--<asp:BoundField DataField="R1" HeaderText="Status" />--%>
           <asp:TemplateField>
            <HeaderTemplate>
             <label class="container">
                <asp:CheckBox ID="chkR1" runat="server"   />
                <span class="checkmark"></span>
               Status
              </label>
               <asp:DropDownList ID="ddlCourseStatus" CssClass="form" runat="server" OnSelectedIndexChanged="CourseStatusChanged"
                AutoPostBack="true" >
            </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("R1")%>
            </ItemTemplate>
        </asp:TemplateField>
       </Columns>
       
       <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
       <FooterStyle Font-Bold="true" />
        </asp:GridView>      
      </ContentTemplate>
        </asp:UpdatePanel>
      </div>
       </div>
       
    </div>
      </ContentTemplate>
       </asp:UpdatePanel>
    </form>
</body>
</html>

