<%@ Page Title="Staff" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Staff.aspx.cs" Inherits="Pages_Staff" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
    <!-- Bootstrap framework -->
    <%--    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css" />--%>
    <!-- jQuery UI theme -->
    <%--<link rel="stylesheet" href="../lib/jquery-ui/css/Aristo/Aristo.css" />
    <!-- breadcrumbs -->
    <link rel="stylesheet" href="../lib/jBreadcrumbs/css/BreadCrumb.css" />
    <!-- tooltips-->
    <link rel="stylesheet" href="../lib/qtip2/jquery.qtip.min.css" />
    <!-- colorbox -->
    <link rel="stylesheet" href="../lib/colorbox/colorbox.css" />
    <!-- code prettify -->
    <link rel="stylesheet" href="../lib/google-code-prettify/prettify.css" />
    <!-- sticky notifications -->
    <link rel="stylesheet" href="../lib/sticky/sticky.css" />
    <!-- aditional icons -->
    <link rel="stylesheet" href="../img/splashy/splashy.css" />
    <!-- flags -->
    <link rel="stylesheet" href="../img/flags/flags.css" />
    <!-- datatables -->
    <link rel="stylesheet" href="../lib/datatables/extras/TableTools/media/css/TableTools.css">
    <link href="../css/tab.css" rel="stylesheet" type="text/css" />
    <!-- main styles -->--%>    <%-- <link rel="stylesheet" href="../css/style.css" />--%>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <%--    <!-- theme color-->
    <link rel="stylesheet" href="../css/blue.css" id="link_theme" />
    <link href="../css/eastern_blue.css" rel="stylesheet" type="text/css" />--%>
    <!-- favicon -->
    <script src="../Scripts/ScrollableGridPlugin_ASP.NetAJAX_2.0.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 10px; margin-bottom: 10px">
        <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
            color: White; height: 35px; margin-bottom: 2px">
            <div class="col-sm-12" style="margin-left: 10px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        STAFF INFORMATION
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="border: thin solid black;">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-4">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Staff Id<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-5">
                                        <asp:TextBox ID="txtStaffId" CssClass="form-control  input-sm" Enabled="false" 
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:CheckBox ID="chkStaffNo" Text="Edit" runat="server" 
                                            AutoPostBack="True" oncheckedchanged="chkStaffNo_CheckedChanged" />
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Staff Type<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comStaffType" CssClass="form-control  input-sm" runat="server">
                                            <asp:ListItem>Select Staff Type...</asp:ListItem>
                                            <asp:ListItem>TEACHER</asp:ListItem>
                                            <asp:ListItem>OFFICE STAFF</asp:ListItem>
                                            <asp:ListItem>LIBRARY STAFF</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Join Date<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtJoinDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                          <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtJoinDate" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: 5px">
                                    <label for="message" class="col-xs-4">
                                        Staff Name<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtStaffName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: 17px">
                                    <label for="message" class="col-xs-4">
                                        Contact No<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtContactNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                       <asp:CheckBox ID="CheckBox1" Text="WhatsApp" 
                                     runat="server" AutoPostBack="True" 
                                     oncheckedchanged="CheckBox1_CheckedChanged" /></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtWhatsappNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Email-Id</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtEmailId" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4" style="margin-top: -8px">
                                        Father's Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtFathersName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4" style="margin-top: -8px">
                                        Mother's Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtMotherName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4" style="margin-top: -8px">
                                        Parent's Contact</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtParentContact" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        DOB<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtDOB" CssClass="form-control  input-sm" runat="server" 
                                            AutoPostBack="True" ontextchanged="txtDOB_TextChanged"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtDOB" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Age</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAge" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Gender<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comGender" CssClass="form-control  input-sm" 
                                            runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="comGender_SelectedIndexChanged">
                                            <asp:ListItem>--SELECT--</asp:ListItem>
                                            <asp:ListItem>MALE</asp:ListItem>
                                            <asp:ListItem>FEMALE</asp:ListItem>
                                            <asp:ListItem>OTHER</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        PAN Card No</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtPANCard" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Samagra Id</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtSamagraId" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Address</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAddress" onkeyup="toUpper(this)" TextMode="MultiLine" Height="70px" CssClass="form-control  input-sm"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -8px;">
                                    <label for="message" class="col-xs-4" style="margin-top: 16px;">
                                        Experience:</label>
                                    <div class="col-xs-4">
                                        <label for="message" style="color: Red">
                                            YEAR</label>
                                        <asp:DropDownList ID="ddlNoOfEnpInYear" CssClass="form-control  input-sm" runat="server"
                                            AutoPostBack="True" onselectedindexchanged="ddlNoOfEnpInYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                        <label for="message" style="color: Red">
                                            MONTH</label>
                                        <asp:DropDownList ID="ddlNoOfExpinMonth" CssClass="form-control  input-sm" runat="server"
                                            AutoPostBack="True" onselectedindexchanged="ddlNoOfExpinMonth_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" runat="server" id="divDesignation" visible="false" style="margin-top: -3px">
                                    <label for="message" class="col-xs-4">
                                        Designation</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtDesignation" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -3px">
                                    <label for="message" class="col-xs-4">
                                        Qualification</label>
                                    <div class="col-xs-8">
                                      <asp:DropDownList ID="ddlQualification" CssClass="form-control  input-sm" runat="server"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Department</label>
                                    <div class="col-xs-8">
                                      <asp:DropDownList ID="ddlDepartment" CssClass="form-control  input-sm" runat="server"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Basic Salary</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtBasicSalary" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Account No</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAccountNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Bank Name</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtBankName" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Branch</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtBranchName" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        IFSC Code</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtIFSCCode" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="message" class="col-xs-4">
                                        Staff Picture</label>
                                    <div class="col-xs-8">
                                        <asp:FileUpload ID="imgUpload" CssClass="form-control  input-sm" runat="server">
                                        </asp:FileUpload>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-4">
                                        <asp:Label ID="lbStaffFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                        <asp:Label ID="lbStaffId" runat="server" Visible="false" Text="0"></asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <div class="form-group">
                                            <div class="col-xs-12">
                                                <asp:Button ID="btnPicUpload" CssClass="form-control  input-sm" OnClick="btnPicUpload_Click" Text="Upload" runat="server">
                                                </asp:Button>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-12">
                                                <asp:Button ID="btnClearImg" CssClass="form-control  input-sm" Text="Clear" 
                                                    runat="server" onclick="btnClearImg_Click">
                                                </asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="col-xs-4" style="margin-left: -25px">
                                                <asp:Image ID="imgStaffImg" Height="135px" Width="115px" BorderWidth="1px" runat="server">
                                                </asp:Image>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Cast<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comCategory" CssClass="form-control  input-sm" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Religion<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comReligion" CssClass="form-control  input-sm" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Aadhar No</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtAadharNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Nationatity<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comNationality" CssClass="form-control  input-sm" runat="server">
                                            <asp:ListItem>--SELECT--</asp:ListItem>
                                            <asp:ListItem>INDIAN</asp:ListItem>
                                            <asp:ListItem>OTHER</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Status<label for="message" style="color: Red">*</label></label>
                                    <div class="col-xs-8">
                                        <asp:DropDownList ID="comStatus" CssClass="form-control  input-sm" runat="server">
                                            <asp:ListItem>--SELECT--</asp:ListItem>
                                            <asp:ListItem>ACTIVE</asp:ListItem>
                                            <asp:ListItem>INACTIVE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group" runat="server" id="divRegineDate" visible="false" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                        Regine Date</label>
                                    <div class="col-xs-8">
                                        <asp:TextBox ID="txtRegineDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtRegineDate" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                    </label>
                                    <div class="col-xs-4">
                                        <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" 
                                            Width="100%" onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                  <div class="form-group" style="margin-top: -5px">
                                    <label for="message" class="col-xs-4">
                                    </label>
                                    <div class="col-xs-2">
                                    </div>
                                    <div class="col-xs-6">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <fieldset>
                                    <legend><span style="margin-left: 10px;font-size: smaller;">ACADMIC INFORMATION</span>
                                     <asp:LinkButton ID="lblDoc" CssClass="btn btn-success"  runat="server" Width="20%"
                                                   Visible="false" onclick="lblDoc_Click">
                                <span aria-hidden="true" class="fa fa-upload"> Upload Certificate</span>
                                                </asp:LinkButton>
                                    </legend>
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group" style="margin-top: 27px; background-color: #04768e !important;">
                                            <label for="message" style="margin: 4px; color: White;">
                                                12th</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="message">
                                            Stream</label>
                                        <asp:DropDownList ID="ddl12Stream" CssClass="form-control  input-sm" runat="server">
                                            <asp:ListItem>STREAM</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <label for="message">
                                            Subject</label>
                                        <asp:TextBox ID="txt12Subject" onkeyup="toUpper(this)"  TextMode="MultiLine" Height="50px" CssClass="form-control  input-sm"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" style="margin-top: 12px;">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group" style="margin-top:27px; background-color: #04768e !important;">
                                        <label for="message" style="margin: 4px; color: White;">
                                            Graduation</label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <label for="message">
                                        Stream</label>
                                    <asp:DropDownList ID="ddlGraduationStream" CssClass="form-control  input-sm" runat="server">
                                        <asp:ListItem>STREAM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-4">
                                    <label for="message">
                                        Subject</label>
                                    <asp:TextBox ID="txtGraduationSubject" onkeyup="toUpper(this)" TextMode="MultiLine" Height="50px" CssClass="form-control  input-sm"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" style="margin-top: 12px;">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group" style="margin-top: 27px; background-color: #04768e !important;">
                                        <label for="message" style="margin: 4px; color: White;">
                                            Post Graduation</label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <label for="message">
                                        Stream</label>
                                    <asp:DropDownList ID="ddlPostGraduationStream" CssClass="form-control  input-sm"
                                        runat="server">
                                        <asp:ListItem>STREAM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-4">
                                    <label for="message">
                                        Subject</label>
                                    <asp:TextBox ID="txtPostGraduationSubject" onkeyup="toUpper(this)" TextMode="MultiLine" Height="50px" CssClass="form-control  input-sm"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" runat="server" id="StudentDoc" visible="false" style="border-top: thin solid black;">
                            <div class="col-sm-4">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="message" class="col-xs-12" style="background-color: #00BFFF;">
                                            STAFF'S DOCUMENTS</label>
                                    </div>
                                    <div class="form-group">
                                        <label for="message" class="col-xs-4">
                                            Document</label>
                                        <div class="col-xs-8">
                                            <asp:FileUpload ID="DocUpload" class="form-control  input-sm" runat="server"></asp:FileUpload>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-4">
                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <asp:Button ID="btnDocUpload" CssClass="form-control  input-sm" Text="Doc Upload"
                                                        runat="server"></asp:Button>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <asp:Button ID="btnDocClear" CssClass="form-control  input-sm" Text="Clear Doc" runat="server">
                                                    </asp:Button>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <asp:Label ID="lbDocFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                                    <asp:Label ID="lbDocId" runat="server" Visible="false" Text="0"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="col-xs-8">
                                                    <asp:Image ID="ImgDoc" Height="135px" Width="100%" BorderWidth="1px" runat="server">
                                                    </asp:Image>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group" style="margin-top: -5px">
                                        <label for="message" class="col-xs-4" style="margin-top: -5px">
                                            Document Type<label for="message" style="color: Red">*</label></label>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtDocumentName" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="margin-top: -5px">
                                        <label for="message" class="col-xs-4">
                                        </label>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnDocmSave" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnDocmRefresh" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <asp:GridView ID="GridStudentDocs" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="#333333" GridLines="Both" PageSize="2" Width="100%"
                                            HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD" HeaderStyle-Font-Bold="true"
                                            RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD" RowStyle-Font-Bold="true">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%" ForeColor="Red" runat="server"
                                                            CommandName="Select" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DocId" HeaderText="SNo" HeaderStyle-HorizontalAlign="Center"
                                                    ReadOnly="True" SortExpression="DocId">
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DocType" HeaderText="DOCUMENT TYPE/NAME" SortExpression="DocType">
                                                    <ItemStyle Width="65%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:ImageField DataAlternateTextField="DocName" DataImageUrlField="DocName" HeaderText="DOCUMENT IMAGE">
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                    <ControlStyle Height="120px" Width="100%" />
                                                </asp:ImageField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                    </div>
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
    </div>
</asp:Content>
