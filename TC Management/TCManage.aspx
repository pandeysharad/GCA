<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="TCManage.aspx.cs" Inherits="TC_Management_TCManage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/main.css" rel="stylesheet" type="text/css" />
    <%--    <!-- theme color-->
    <link rel="stylesheet" href="../css/blue.css" id="link_theme" />
    <link href="../css/eastern_blue.css" rel="stylesheet" type="text/css" />--%>
    <!-- favicon -->
 <script src="../Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
 
 <script language="javascript" type="text/javascript">

     function UpdatePanel() {
         __doPostBack("<%=UpdatePanel2.UniqueID %>", "");
     }
     function MessageShow(msg) {
         alert(msg);
         document.getElementById("txtAdminNo").focus();
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel6" runat="server">
    <ProgressTemplate>
    <img alt="Process....." src="../img/final_loading_big.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress>
      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
       <ContentTemplate>        
   <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
            color: White; height: 35px; margin-bottom: 2px">
            <div class="col-sm-12" style="margin-left: 10px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        TC/CC ISSUE
                    </div>
                </div>
            </div>
        </div>
        
   <div class="panel-body" style="border: thin solid black;">
    <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:40px;margin-bottom:2px;margin-top:-16px;margin-left:-16px;margin-right:-16px">  
                      <div class="col-sm-12" >
                                <div class="form-horizontal">   
                             <div class="form-group" style="margin-top:-11px">                                      
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate> 
                                    <div class="col-xs-3"  id="divAdminNo" runat="server">
                                    <asp:TextBox ID="txtAdminNo"  CssClass="form-control  input-sm" 
                                            placeholder="Enter Admission No" runat="server" onkeyup = "SetContextKey()" 
                                            MaxLength="8" ></asp:TextBox>
                                        <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender4" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="GetAdmNo" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtAdminNo">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnSearchDetails_Click" >
                                           <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                                        </asp:LinkButton>
                                    </div> 
                                    <div class="col-xs-2">
                                        <asp:LinkButton ID="btnAllFeesRefresh" CssClass="btn btn-primary" runat="server" Width="100%" onclick="btnAllFeesRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                        </asp:LinkButton>
                                    </div> 
                                    <div id="Div1" class="col-xs-5" runat="server">
                                      <div class="form-group">
                                   <div class="col-xs-3">
                                        <asp:CheckBox ID="chkTcSerialNo" Text="TC Serial" runat="server" 
                                            AutoPostBack="True" oncheckedchanged="chkTcSerialNo_CheckedChanged" />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtTcSerialNo" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:CheckBox ID="chkCCSerialNo" Text="CC Serial" runat="server" 
                                            AutoPostBack="True" oncheckedchanged="chkCCSerialNo_CheckedChanged" />
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtCCSerialNo" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                    </div>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    
              <%--  <div class="col-sm-2" >
                    <div class="form-horizontal">   
                        <div class="form-group" style="margin-top:-13px">            
                              
                    </div>
                    </div>
                </div>--%>
                </div>

            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                       Session<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtSession" CssClass="form-control  input-sm" Enabled="false" 
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Adm No./Enroll No.<label for="message" style="color: Red">*</label></label>
                                     <div class="col-xs-8">
                                        <asp:TextBox ID="txtAdimissionNo" CssClass="form-control  input-sm" Enabled="false" 
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                               <%-- <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Roll No.<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtRollNo" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: 5px">
                                    <label for="message" class="col-xs-4">
                                        Enrollment No.<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtEnrollNo" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="form-group" style="margin-top: 17px">
                                    <label for="message" class="col-xs-4">
                                        Admission Date<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAdmissionDate" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtAdmissionDate" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Contact No.</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtContact" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Aadhar No.</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAadhar" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                              
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Samagra Id</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtSamagraId" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Gender</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtGender" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-horizontal">
                              <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtName" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Father's Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtFatherName" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Mother's Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtMotherName" Enabled="false"  CssClass="form-control  input-sm"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" runat="server" style="margin-top: -3px">
                                    <label for="message" class="col-xs-4">
                                        Religion</label>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtReligion" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                     <label for="message" class="col-xs-1">
                                       <span style="margin-left: -10px;">Cast</span> </label>
                                     <div class="col-xs-4">
                                        <asp:TextBox ID="txtCast" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                  <div id="Div2" class="form-group" runat="server" style="margin-top: -3px">
                                    <label for="message" class="col-xs-4">
                                        Current Class</label>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtCurrentClass" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                     <label for="message" class="col-xs-1">
                                        <span style="margin-left: -10px">Section</span></label>
                                     <div class="col-xs-4">
                                        <asp:TextBox ID="txtSection" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                 <div id="Div3" class="form-group" runat="server" style="margin-top: -3px">
                                    <label for="message" class="col-xs-4">
                                        Adm. Class</label>
                                    <div class="col-xs-3">
                                        <asp:TextBox ID="txtAdmClass" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                     <label for="message" class="col-xs-1">
                                        <span style="margin-left: -10px;">DOB</span></label>
                                     <div class="col-xs-4">
                                        <asp:TextBox ID="txtDOB" Enabled="false"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        </label>
                                    <div class="col-xs-4">
                                       <asp:CheckBox ID="chkDuplicateTc" Text="Duplicate TC" runat="server" />
                                    </div>
                                      <div class="col-xs-4">
                                       <asp:CheckBox ID="chkDuplicateCC" Text="Duplicate CC" runat="server" />
                                    </div>
                                </div>
                             
                             
                            </div>
                        </div>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
           
             <div class="panel-body" style="border: thin solid #42b3f4; padding:5px; margin-top: -6px;
                                            margin-bottom: 10px;">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-6">
                            <div class="form-horizontal">
                             <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                       Apply Date<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                          <asp:TextBox ID="txtApplyDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtApplyDate" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                       School Leaving Date<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                          <asp:TextBox ID="txtSchoolLeavingDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtSchoolLeavingDate" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Paid all dues till end<label for="message" style="color: Red">*</label></label>
                                     <div class="col-xs-8">
                                      <asp:TextBox ID="txtPaidallduestillend" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                       <cc1:AutoCompleteExtender runat="server" ID="AutotxtPaidallduestillendExtender1" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="PaidAllDue" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtPaidallduestillend">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Year<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                          <asp:TextBox ID="txtYear" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                       <cc1:AutoCompleteExtender runat="server" ID="AutotxtYearExtender2" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="Year" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtYear">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: 5px">
                                    <label for="message" class="col-xs-4">
                                        Examination<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                         <asp:TextBox ID="txtExamination" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                       <cc1:AutoCompleteExtender runat="server" ID="AutotxtExaminationExtender3" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="Examination" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtExamination">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-horizontal">
                                 <div class="form-group" >
                                    <label for="message" class="col-xs-4">
                                        Class</label>
                                    <div class="col-xs-3">
                                         <asp:TextBox ID="txtClass" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                       <cc1:AutoCompleteExtender runat="server" ID="AutotxtClassExtender5" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="Class" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtClass">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    <label for="message" class="col-xs-1">
                                        And</label>
                                        <div class="col-xs-4">
                                         <asp:TextBox ID="txtAnd" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                         <cc1:AutoCompleteExtender runat="server" ID="AutotxtAndExtender2" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="AndPassed" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtAnd">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        To Class</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtToClass" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                         <cc1:AutoCompleteExtender runat="server" ID="AutotxtToClassExtender2" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="ToClass" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtToClass">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        In words class</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtInwordsclass" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                         <cc1:AutoCompleteExtender runat="server" ID="AutotxtInwordsclassExtender2" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="InWordsClass" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtInwordsclass">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                              
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                         His/Her conduct was</label>
                                    <div class="col-xs-8">
                                    <asp:TextBox ID="txtHisHerConductwas" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                         <cc1:AutoCompleteExtender runat="server" ID="AutotxtHisHerConductwasExtender2" 
                                            ServicePath="~/AutoComplete.asmx" ServiceMethod="ConductWas" MinimumPrefixLength="1"
                                            CompletionInterval="0" UseContextKey="true" CompletionSetCount="20" CompletionListCssClass="CompletionListCssClass"
                                            CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                            CompletionListItemCssClass="CompletionListItemCssClass" DelimiterCharacters="&nbsp;,:"
                                            Enabled="True" TargetControlID="txtHisHerConductwas">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                         Remarks</label>
                                    <div class="col-xs-8">
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Height="50px" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                   <div class="form-group">
                                  <label for="message" class="col-xs-4">
                                        </label>
                                   <div class="col-xs-4">
                                        <asp:LinkButton ID="btnTcIssue" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnTcIssue_Click">
                                           <span aria-hidden="true" class="glyphicon glyphicon-search"><%=TCbtn%></span>
                                        </asp:LinkButton>
                                    </div> 
                                    <div class="col-xs-4">
                                        <asp:LinkButton ID="btnCCIssue" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnCCIssue_Click">
                                           <span aria-hidden="true" class="glyphicon glyphicon-search"><%=CCbtn%></span>
                                        </asp:LinkButton>
                                    </div> 
                                </div>
                            </div>
                        </div>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </div>
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-12">
                            <div class="form-horizontal">
                             <div class="form-group">
                        <asp:GridView ID="GridTC" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="20" Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                             DataKeyNames="TCId" AutoGenerateSelectButton="true"
                            ShowHeaderWhenEmpty="True" OnSelectedIndexChanging="GridTC_SelectedIndexChanging"
                             OnPageIndexChanging="GridTC_PageIndexChanging"  >
                            <Columns>
                                <asp:BoundField ItemStyle-Width="6%" DataField="AdmNo" 
                                    HeaderText="Adm-No" >
                                <ItemStyle Width="6%" />
                                </asp:BoundField>
                                
                                <asp:BoundField ItemStyle-Width="12%" DataField="StudentName" 
                                    HeaderText="Stu. Name" >
                                <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="8%" DataField="ContactNumber" 
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
                                <asp:BoundField ItemStyle-Width="8%" DataField="ApplyDate" HeaderText="Apply-Date"
                                    DataFormatString="{0:d}" >
                                <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="8%" DataField="SchoolLeavingDate" HeaderText="Leaving-Date"
                                DataFormatString="{0:d}" >
                                <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="8%" DataField="PaidAllDue" HeaderText="Paid-All-Due" >
                                <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="8%" DataField="Examination" HeaderText="Examination" >
                                <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="6%" DataField="ConductWas" HeaderText="Conduct-Was" >
                                <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <%--<asp:TemplateField>
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
                                </asp:TemplateField>--%>
                            </Columns>
                            <PagerStyle HorizontalAlign = "Right"   CssClass="gridview" />
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        </asp:GridView>
                        <b><asp:Label ID="lblAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
                        <span style="font-size:small;font-family:Lucida Bright;font-weight:bold;"></span>
                                                        <//div>
                        </div>
                        </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

