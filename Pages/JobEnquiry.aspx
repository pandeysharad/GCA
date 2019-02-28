<%@ Page Title="Job Enquiry" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="JobEnquiry.aspx.cs" Inherits="Pages_JobEnquiry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
             document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
             document.getElementById("<%=dtSDate.ClientID%>").Text = "";
             document.getElementById("<%=dtEDate.ClientID%>").Text = "";
             document.getElementById("<%=txtSearchByStudentName.ClientID%>").focus();
         }
         else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Contact No") {
             document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
             document.getElementById("<%=divContact.ClientID%>").style.display = "block";
             document.getElementById("<%=divSdate.ClientID%>").style.display = "none";
             document.getElementById("<%=divTo.ClientID%>").style.display = "none";
             document.getElementById("<%=divEdate.ClientID%>").style.display = "none";
             document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = "";
             document.getElementById("<%=dtSDate.ClientID%>").Text = "";
             document.getElementById("<%=dtEDate.ClientID%>").Text = "";
             document.getElementById("<%=txtSearchByContact.ClientID%>").focus();
         }
         else if (document.getElementById("<%=ddl_Search.ClientID%>").value == "By Date") {
             document.getElementById("<%=divStudent.ClientID%>").style.display = "none";
             document.getElementById("<%=divContact.ClientID%>").style.display = "none";
             document.getElementById("<%=divSdate.ClientID%>").style.display = "block";
             document.getElementById("<%=divTo.ClientID%>").style.display = "block";
             document.getElementById("<%=divEdate.ClientID%>").style.display = "block";
             document.getElementById("<%=txtSearchByStudentName.ClientID%>").Text = 
             document.getElementById("<%=txtSearchByContact.ClientID%>").Text = "";
             document.getElementById("<%=dtSDate.ClientID%>").focus();
         }
     }
     function MessageShow(msg) {
         alert(msg);
     }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
      <div class="col-sm-12">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-top:2px"> 
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       JOB(STAFF) ENQUIRY
                    </div>
              </div>
      </div>
      </div>
      </div>
  <div class="row">                 
     <div class="panel-body" style="border:thin solid black; margin-left:15px;margin-right:15px;margin-top:2px">
    <div id="page">
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#Enquiry" aria-controls="Enquiry" role="tab" data-toggle="tab">Add/Edit Enquiry</a></li>
            <li ><a href="#EnquiryList" aria-controls="EnquiryList" role="tab" data-toggle="tab">Job Enquiry List</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="Enquiry" style="background-color:White; border-bottom:thin solid lightgray; border-right: thin solid lightgray;border-left: thin solid lightgray">
            <div class="panel-body">      
               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>        
            <div class="col-sm-6" >
            <div class="form-horizontal">
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Job Enquiry No:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtJobEnquiryNo" CssClass="form-control  input-sm"  runat="server" Enabled="false"></asp:TextBox>
                             </div>
                         </div>
                           <div class="form-group">
                             <label for="message" class="col-xs-4">Enquiry Date:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                              
                              <asp:TextBox ID="dtEnquiryDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY" runat="server"></asp:TextBox>
                              <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" 
                                                                  Format="dd/MM/yyyy" TargetControlID="dtEnquiryDate" CssClass="black" PopupPosition="TopRight">
                                  </cc1:CalendarExtender> 
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Name:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtName" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Contact No:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtContactNo" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <div class="col-xs-4"><asp:CheckBox ID="CheckBox1" Text="WhatsApp No." 
                                     runat="server" AutoPostBack="True" 
                                     oncheckedchanged="CheckBox1_CheckedChanged" /></div>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtWhatsAppNo" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Address:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtAddress" CssClass="form-control  input-sm" TextMode="MultiLine" Height="50px"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                        
                         </div>
                         </div>
                           <div class="col-sm-6">
                         <div class="form-horizontal">
                          <div class="form-group">
                             <label for="message" class="col-xs-4">Email Id:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtEmailId" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                                
                             </div>
                         </div>
                         <div class="form-group">

                             <label for="message" class="col-xs-4">Experience:</label>
                              <div class="col-xs-2">
                             <asp:DropDownList ID="ddlNoOfEnpInYear" CssClass="form-control  input-sm"  
                                      runat="server" AutoPostBack="True" 
                                      onselectedindexchanged="ddlNoOfEnpInYear_SelectedIndexChanged"> 

                              </asp:DropDownList>
                             </div>
                              <div class="col-xs-2">
                             <asp:DropDownList ID="ddlYear" CssClass="form-control  input-sm" style="margin-left:-25px;width:83px;"  runat="server">
                              <asp:ListItem>YEAR</asp:ListItem>
                               <asp:ListItem>YEARS</asp:ListItem>
                              </asp:DropDownList>
                             </div>
                              <div class="col-xs-2">
                             <asp:DropDownList ID="ddlNoOfExpinMonth" CssClass="form-control  input-sm" 
                                      style="margin-left:-25px;"  runat="server" AutoPostBack="True" 
                                      onselectedindexchanged="ddlNoOfExpinMonth_SelectedIndexChanged"> 
                              </asp:DropDownList>
                             </div>
                              <div class="col-xs-2">
                             <asp:DropDownList ID="ddlMonth" CssClass="form-control  input-sm" style="margin-left:-49px;width:107px;"  runat="server"> 
                              <asp:ListItem>MONTH</asp:ListItem>
                              <asp:ListItem>MONTHS</asp:ListItem>
                              </asp:DropDownList>
                             </div>
                         </div>
                          <div class="form-group" id="divPreviousOrganization" runat="server" visible="false">
                             <label for="message" class="col-xs-4">Previous Organization:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtPreviousOrganization" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                          <div class="form-group" id="divDesignation" runat="server" visible="false">
                             <label for="message" class="col-xs-4">Designation:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtDesignation" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Qualification:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                                  <asp:DropDownList ID="ddlQualification" AutoPostBack="true" 
                                      CssClass="form-control  input-sm" runat="server"> 
                                  </asp:DropDownList>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Remarks:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtRemarks" CssClass="form-control  input-sm" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Status:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-8">
                              <asp:DropDownList ID="ddl_Status" CssClass="form-control  input-sm"  runat="server">   
                              <asp:ListItem>SELECT STATUS</asp:ListItem>
                              <asp:ListItem>INTERESTED</asp:ListItem>
                              <asp:ListItem>NOT INTERESTED</asp:ListItem>
                              </asp:DropDownList>
                             </div>
                         </div>
                          <div class="form-group">
                             <div class="col-xs-4">
                                 <asp:Label ID="Label1" runat="server" Visible="false" Text="0"></asp:Label>
                                 <asp:Label ID="Label2" runat="server"  Visible="false" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-4">
                          <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%" 
                                     onclick="btnSave_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-4">
                          <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" 
                                       onclick="btnRefresh_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div>  
                             
                         </div>
                         </div>
                           
                       </ContentTemplate>
                     </asp:UpdatePanel>
           
             </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="EnquiryList" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
              <div class="panel-body">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
             <div class="row" style="margin-top:5px;">
            <div class="col-sm-12" style="margin-bottom:-30px;">
            <div class="form-horizontal">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                <div class="form-group" style="margin-top:5px;">       
                <label for="message" class="col-xs-1" >Search:</label>
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddl_Search" CssClass="form-control  input-sm" onchange="Visibility()" runat="server">
                    <asp:ListItem>By Student</asp:ListItem>
                    <asp:ListItem>By Contact No</asp:ListItem>
                    <asp:ListItem>By Date</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2"  id="divStudent"  runat="server">
                     <asp:TextBox ID="txtSearchByStudentName" CssClass="form-control  input-sm"  placeholder="STUDENT NAME" runat="server"> </asp:TextBox>
                </div>
                <div class="col-xs-2"  id="divContact"  runat="server"   hidden="true">
                     <asp:TextBox ID="txtSearchByContact" CssClass="form-control  input-sm"  placeholder="CONTACT No." runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2"  id="divSdate"  runat="server" hidden="true">
                     <asp:TextBox ID="dtSDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY" runat="server"></asp:TextBox>
                      <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                       Format="dd/MM/yyyy" TargetControlID="dtSDate" CssClass="black" PopupPosition="TopRight">
                                  </cc1:CalendarExtender> 
                </div>
                <label for="message" class="col-xs-1"   runat="server"  id="divTo"  hidden="true" style="text-align:center">To</label>
                <div class="col-xs-2"  id="divEdate"  runat="server" hidden="true">
                     <asp:TextBox ID="dtEDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY" runat="server"></asp:TextBox>
                      <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                    Format="dd/MM/yyyy" TargetControlID="dtEDate" CssClass="black" PopupPosition="TopRight">
                                  </cc1:CalendarExtender> 
                </div>
                
                <div class="col-xs-2">
                    <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" 
                        Width="80%" onclick="btnSearchDetails_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                    </asp:LinkButton>
                </div>
                 <div class="col-xs-2">
                     <asp:LinkButton ID="btnPrint" CssClass="btn btn-success" runat="server" 
                         Width="80%" style="margin-left:-20px;" onclick="btnPrint_Click"> 
                                <span aria-hidden="true" class="glyphicon glyphicon-print"> Print</span>
                     </asp:LinkButton>
                </div>
             </div>
               <div class="form-group">
                <asp:GridView ID="GridEnquiry" runat="server" HeaderStyle-BackColor="#66ccff" 
                       AutoGenerateColumns="false" AllowPaging="true"  PageSize="10" Width="100%"
                           HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                       HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"  RowStyle-Font-Names="Maiandra GD"
                           RowStyle-Font-Bold="true" AutoGenerateSelectButton="True" 
                       DataKeyNames="JobEnquiryId"  onselectedindexchanging="GridEnquiry_SelectedIndexChanging" 
                       onpageindexchanging="GridEnquiry_PageIndexChanging" >
                        <Columns> 
                            <asp:BoundField ItemStyle-Width="3%"  DataField="JobEnquiryNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="10%"  DataField="EnquiryDate" HeaderText="DATE" DataFormatString="{0:d}" />
                            <asp:BoundField ItemStyle-Width="13%" DataField="Name" HeaderText="NAME" />
                            <asp:BoundField ItemStyle-Width="20%" DataField="Address" HeaderText="ADDRESS" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="ContactNo" HeaderText="CONTACT" />
                            <asp:BoundField ItemStyle-Width="4%" DataField="WhatsappNo" HeaderText="WHATSAPP" />
                            <asp:BoundField ItemStyle-Width="4%" DataField="ExpYear" HeaderText="YEAR-EXP" />
                            <asp:BoundField ItemStyle-Width="8%" DataField="ExpMonth" HeaderText="MONTH-EXP" />
                            <asp:BoundField ItemStyle-Width="8%" DataField="EmailId" HeaderText="E-MAIL"  />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Qualification" HeaderText="QUALIFICATION"/>
                            <asp:BoundField ItemStyle-Width="8%"  DataField="Status" HeaderText="STATUS" />
                             <asp:TemplateField>
                            <ItemTemplate>           
                                 <asp:LinkButton Text="Join" ID="LnkJoin" OnClick="OnSelectedJoin"  ItemStyle-Width="2%" ForeColor="Red" Font-Bold="true" runat="server" CommandArgument='<%# Eval("JobEnquiryId") %>' />                               
                            </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                        <SelectedRowStyle BackColor="Black" ForeColor="White" />
                    </asp:GridView>
                      <b><asp:Label ID="lblAuthorized" runat="server" Text="" Visible="false"></asp:Label></b>
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
      </div>
</asp:Content>

