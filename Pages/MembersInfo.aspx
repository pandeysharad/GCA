<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MembersInfo.aspx.cs" Inherits="Pages_MembersInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">
     function Showalert(msg) {
         alert(msg);
     }

     function Edit() {
         var a = document.getElementById("<%=chkMemberNo.ClientID%>");
         var serialno = document.getElementById("<%=txtMemberNo.ClientID%>");
         if (a.checked) {
             serialno.disabled = false;
             serialno.focus();
         }
         else {
             serialno.disabled = true;
         }
     }

     function Visibility() {
         if (document.getElementById("<%=comMemberType.ClientID%>").value == "Students") {
             document.getElementById("<%=divSearchNo.ClientID%>").style.display = "block";
             document.getElementById("<%=divCourse.ClientID%>").style.display = "block";
             document.getElementById("<%=divBatch.ClientID%>").style.display = "block";
             document.getElementById("<%=divDepartment.ClientID%>").style.display = "none";
         }
         else if (document.getElementById("<%=comMemberType.ClientID%>").value == "Teachers") {
             document.getElementById("<%=divSearchNo.ClientID%>").style.display = "none";
             document.getElementById("<%=divCourse.ClientID%>").style.display = "none";
             document.getElementById("<%=divBatch.ClientID%>").style.display = "none";
             document.getElementById("<%=divDepartment.ClientID%>").style.display = "block";
         }
         else {
             document.getElementById("<%=divSearchNo.ClientID%>").style.display = "none";
             document.getElementById("<%=divCourse.ClientID%>").style.display = "none";
             document.getElementById("<%=divBatch.ClientID%>").style.display = "none";
             document.getElementById("<%=divDepartment.ClientID%>").style.display = "none";
         }
     }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row"  style="margin-top:10px;margin-bottom:10px">

    <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
        <div class="col-sm-12" style="margin-left:10px">
            <div class="form-horizontal">    
                <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                    MEMBER INFORMATION
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body" style="border:thin solid black;">
     <div id="page" style="margin:-10px">
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#MemberInfo" aria-controls="MemberInfo" role="tab" data-toggle="tab">Member Info</a></li>
            <li><a href="#MemberList" aria-controls="MemberList" role="tab" data-toggle="tab">Member List</a></li>
        </ul>
        <div class="tab-content">
         <div role="tabpanel" class="tab-pane active" id="MemberInfo" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
             <div class="panel-body">
             <div class="row">
            <div class="col-sm-6" style="margin-bottom:-10px">                                               
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>   
            <div class="form-horizontal">
                         <div class="form-group">
                            <label for="message" class="col-xs-4">Member No:<label for="message" style="color:Red">*</label></label>
                            <div class="col-xs-6">
                            <asp:TextBox ID="txtMemberNo" CssClass="form-control  input-sm" Enabled="false"  runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                            <asp:CheckBox ID="chkMemberNo" Text="Edit" onClick="Edit()" runat="server" />
                            </div>
                         </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Member Type:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:DropDownList ID="comMemberType" CssClass="form-control  input-sm" AutoPostBack="true" runat="server">
                             <asp:ListItem>Select Member Type</asp:ListItem>
                             <asp:ListItem>Teachers</asp:ListItem>
                             <asp:ListItem>Students</asp:ListItem>
                             <asp:ListItem>Office Staff</asp:ListItem>
                             <asp:ListItem>Library Staff</asp:ListItem>  
                             </asp:DropDownList>
                             </div>
                        </div>
                        <div class="form-group" id="divDepartment"  runat="server" hidden="true">
                             <label for="message" class="col-xs-4">Department<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                                <asp:DropDownList ID="comDepartment" CssClass="form-control  input-sm" onchange="Visibility()" runat="server"/>
                             </div>
                        </div>
                        <div class="form-group" id="divSearchNo"  runat="server" hidden="true">
                             <label for="message" class="col-xs-4">Search By<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-4">
                             <asp:DropDownList ID="comSearchBy" CssClass="form-control  input-sm" onchange="Visibility()" runat="server">
                             <asp:ListItem>Enrollment No</asp:ListItem>
                             <asp:ListItem>Admission No</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                             <div class="col-xs-3" style="margin-left:-10px">
                             <asp:TextBox ID="txtSearchText" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                            <div class="col-xs-1" style="margin-left:-15px">
                                <asp:LinkButton ID="btnCardSearch" CssClass="btn btn-primary" runat="server">
                                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Member Name:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:DropDownList ID="comMemberName" CssClass="form-control  input-sm" runat="server"/>
                             </div>
                        </div>
                        <div class="form-group" id="divCourse"  runat="server" hidden="true">
                             <label for="message" class="col-xs-4">Course/Class:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtCourseName" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="form-group" id="divBatch"  runat="server" hidden="true">
                             <label for="message" class="col-xs-4">Year/Sem/Batch:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtBatch" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Contact No:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtContactNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div> 
                        <div class="form-group">
                            <label for="message" class="col-xs-4">Address:</label>
                            <div class="col-xs-8">
                            <asp:TextBox ID="txtAddress" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server"></asp:TextBox>
                            </div>
                        </div>      
                        <div class="form-group">
                             <label for="message" class="col-xs-4" style="margin-top:-9px">No Of Books To Issue:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtBookLimits" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server"></asp:TextBox>
                             </div>
                        </div>   
                        <div class="form-group" style="margin-top:-5px">
                             <div class="col-xs-4">
                                 <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                 <asp:Label ID="lbMemberId" runat="server"  Visible="false" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-4">
                    <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-4">
                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div> 
                        </div>    
                </ContentTemplate>
                </asp:UpdatePanel>                   
                    </div>
            </div>
            </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="MemberList" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
             <div class="panel-body">
            <div class="row" style="margin-top:5px;">
            <div class="col-sm-12" style="margin-bottom:-30px;">
            <div class="form-horizontal">
             <div class="form-group">
                <asp:GridView ID="GridEnquiry" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                           HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                           RowStyle-Font-Bold="true">
                        <Columns>                        
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="52%"  ForeColor="Blue" Font-Bold="true" runat="server" CommandName="Select" />                               
                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField ItemStyle-Width="5%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="EnquiryDate" HeaderText="DATE" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="StudentName" HeaderText="NAME" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="ContactNo" HeaderText="CONTACT" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="Father" HeaderText="FATHER" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="FatherContact" HeaderText="PARENT'S CONTACT" />
                            <asp:BoundField ItemStyle-Width="18%" DataField="Address" HeaderText="ADDRESS" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Status" HeaderText="STATUS" />
                        </Columns>
                    </asp:GridView>
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
    </div>
</asp:Content>
