<%@ Page Title="Message Dashboard" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MsgDashBoard.aspx.cs" Inherits="Pages_MsgDashBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

    function MessageShow(msg) {
        alert(msg);
    }

    function ismaxlength(objTxtCtrl, nLength) {
        console.log("Hello world!");
        var ddlMsgType = document.getElementById("ContentPlaceHolder1_ddlMsgType").value;
        if (ddlMsgType == 'English') {
            nLength = 290;
        }
        else if (ddlMsgType == 'Hindi') {
            nLength = 190;
        }
        //console.log(document.getElementById("txtMsg").value);
        if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
            objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

        if (document.all)
            document.getElementById('<%= lblCaption.ClientID %>').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
        else
            document.getElementById('<%= lblCaption.ClientID %>').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

    }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
      <div class="col-sm-12">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-top:2px"> 
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       MESSAGE DASH BOARD
                    </div>
              </div>
      </div>
      </div>
      </div>
      <div class="row">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate> 
     <div class="panel-body" style="border:thin solid black; margin-left:15px;margin-right:15px;margin-top:2px">
   <div class="col-sm-12" >
            <div class="form-horizontal"> 
                         <div class="form-group"> 
                             <label for="message" class="col-xs-3" style="margin-left:150px;">Message Type:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                                 <asp:DropDownList ID="ddlMsgType" runat="server" CssClass="form-control  input-sm" >
                             <asp:ListItem Value="0">Language Type</asp:ListItem>
                             <asp:ListItem Value="English">English</asp:ListItem>
                             <asp:ListItem Value="Hindi">Hindi</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                         </div>
                         <div class="form-group"> 
                            
                             <label for="message" class="col-xs-3" style="margin-left:150px;">Message Head:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                                  <asp:DropDownList  ID="ddlMsgHeads" CssClass="form-control  input-sm" 
                                      runat="server" AutoPostBack="True" 
                                      onselectedindexchanged="ddlMsgHeads_SelectedIndexChanged">
                                  </asp:DropDownList>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-3"  style="margin-left:150px;">Message:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                             <asp:TextBox ID="txtMsg" CssClass="form-control  input-sm"  runat="server" 
                                      Height="80px"  onkeyup="return ismaxlength(this, 290)" TextMode="MultiLine"></asp:TextBox>
                             </div>
                         </div>
                          <div class="form-group" style="margin-top: -12px;">
                             <label for="message" class="col-xs-3"  style="margin-left:150px;"></label>
                              <div class="col-xs-4">
                                  <asp:Label ID="lblCaption" runat="server" Font-Bold="true"></asp:Label>
                             </div>
                         </div>
                            <div class="form-group" style="margin-top: -12px;">
                              <div class="col-xs-3"style="margin-left:150px;">
                                  <asp:CheckBox ID="chkSchedule" runat="server" Text="Set Schedule Date/Time" 
                                      AutoPostBack="true" oncheckedchanged="chkSchedule_CheckedChanged" />
                             </div>
                               <div class="col-xs-2">
                             <asp:TextBox ID="txtDate" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"  PopupPosition="TopRight"
                                                                  Format="dd/MM/yyyy" TargetControlID="txtDate" CssClass="black">
                                  </cc1:CalendarExtender> 
                             </div>
                              <div class="col-xs-2">
                                  <cc1:TimeSelector ID="TimeSelector2"  CssClass="form-control  input-sm" BackColor="lightseagreen" ForeColor="White" BorderColor="Red" runat="server" AllowSecondEditing="true">
                                  </cc1:TimeSelector>
                             </div>
                         </div>
                         <div class="form-group" style="background-color: lightseagreen;">
                              <div class="col-xs-2"  style="margin-left:150px;">
                                  <asp:CheckBox ID="chkStudet" runat="server" Text="STUDENT" AutoPostBack="true" 
                                      oncheckedchanged="chkStudet_CheckedChanged" />
                             </div>
                              <div class="col-xs-2">
                                  <asp:CheckBox ID="chkStaff" runat="server" Text="STAFF" AutoPostBack="true" 
                                      oncheckedchanged="chkStaff_CheckedChanged" />
                             </div>
                         </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:Panel ID="pnlStudent" runat="server" Visible="False" Width="900px"
                                        Height="300px">
                                        <div class="form-group">
                                            <div class="col-sm-4" style="margin-left:150px;">
                                                <asp:DropDownList ID="ddlAllClass" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True"  onselectedindexchanged="ddlAllClass_SelectedIndexChanged">
                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                    <asp:ListItem>ALL CLASS</asp:ListItem>
                                                    <asp:ListItem>SPECIFIC CLASS</asp:ListItem>
                                                    <asp:ListItem>PERTICULAR STUDENT</asp:ListItem>
                                                    <asp:ListItem>ENQUIRY STUDENT</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="form-group" runat="server" id="DivCheckBoxClasses" visible="false">
                                            <div class="col-sm-4"  style="margin-left:150px;">
                                                <asp:CheckBoxList ID="CheckBoxClasses" runat="server" RepeatDirection="Vertical">
                                        
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                         <div class="form-group" runat="server" id="DivChkSpecificStudent" visible="false">
                                            <div class="col-sm-3"  style="margin-left:150px;">
                                                <asp:RadioButtonList ID="chkSpecificStudent" runat="server"  RepeatDirection="Vertical" AutoPostBack="True" 
                                                    onselectedindexchanged="chkSpecificStudent_SelectedIndexChanged" >
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-sm-7">
                                            <div class="col-sm-6">
                                              <asp:TextBox ID="txtsearch" CssClass="form-control  input-sm" placeholder="By Student Name/Admission No." style="margin-left:-15px;margin-bottom:10px" runat="server" ></asp:TextBox>
                                              </div>
                                               <div class="col-sm-6">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                                    onclick="btnSearch_Click" />
                                                    </div>
                                                <asp:GridView ID="Grid" CssClass="GridViewStyle_List" Width="100%" PageSize="15" DataKeyNames="AdmissionId"
                                                    runat="server" AutoGenerateColumns="false" OnPageIndexChanging="Grid_PageIndexChanging">
                                                    <%----%>
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkDelete" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SN.">
                                                            <ItemTemplate>
                                                                <%=SrNo++ %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="ADMISSION NO." DataField="AdmissionNo" ItemStyle-VerticalAlign="Top" />
                                                        <asp:BoundField HeaderText="STUDENT NAME" DataField="StudentName" />
                                                        <asp:BoundField HeaderText="CONTACT NO." DataField="ContactNo" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle Font-Bold="true" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="form-group" runat="server" id="DivEnquiryStudent" visible="false">
                                            <div class="col-sm-3"  style="margin-left:150px;">
                                                <asp:RadioButtonList ID="RadioEnquiryStudent" runat="server"  RepeatDirection="Vertical" AutoPostBack="True"
                                                onselectedindexchanged="RadioEnquiryStudent_SelectedIndexChanged">
                                                <asp:ListItem Text="INTERESTED" Value="INTERESTED"></asp:ListItem>
                                                <asp:ListItem Text="NOT INTERESTED" Value="NOT INTERESTED"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-sm-7">
                                            <div class="col-sm-6">
                                              <asp:TextBox ID="txtSearchEnquiry" CssClass="form-control  input-sm" placeholder="By Student Name" style="margin-left:-15px;margin-bottom:10px" runat="server" ></asp:TextBox>
                                              </div>
                                               <div class="col-sm-6">
                                                <asp:Button ID="btnSearchEnquiry" runat="server" Text="Search" 
                                                    onclick="btnSearchEnquiry_Click" />
                                                    </div>
                                                <asp:GridView ID="GridEnquiryStudent" CssClass="GridViewStyle_List" Width="100%" PageSize="15" DataKeyNames="EnquiryId"
                                                    runat="server" AutoGenerateColumns="false">
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkHeader" OnCheckedChanged="chkHeader_CheckedChanged" runat="server" AutoPostBack="true" />
                                                        </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkRow" OnCheckedChanged="chkRow_CheckedChanged" runat="server" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SN.">
                                                            <ItemTemplate>
                                                                <%=SrNo++ %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="ENQUIRY NO." DataField="EnquiryNo" ItemStyle-VerticalAlign="Top" />
                                                        <asp:BoundField HeaderText="STUDENT NAME" DataField="StudentName" />
                                                        <asp:BoundField HeaderText="CONTACT NO." DataField="ContactNo" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle Font-Bold="true" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlStaff" runat="server" Visible="False" Width="900px"
                                        Height="300px">
                                        <div class="form-group">
                                            <div class="col-sm-4" style="margin-left:150px;">
                                                <asp:DropDownList ID="ddlStaffAllClass" CssClass="form-control  input-sm" runat="server"
                                                    AutoPostBack="True" 
                                                    onselectedindexchanged="ddlStaffAllClass_SelectedIndexChanged">
                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                    <asp:ListItem>ALL STAFF</asp:ListItem>
                                                    <asp:ListItem>SPECIFIC DEPARTMENT</asp:ListItem>
                                                    <asp:ListItem>PERTICULAR STAFF</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                         <div class="form-group" runat="server" id="DivchkDepartment" visible="false">
                                            <div class="col-sm-4"  style="margin-left:150px;">
                                                <asp:CheckBoxList ID="chkDepartment" runat="server" RepeatDirection="Vertical">
                                        
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                         <div class="form-group" runat="server" id="DivchkSpecificStaff" visible="false">
                                            <div class="col-sm-3"  style="margin-left:150px;">
                                                <asp:RadioButtonList ID="chkSpecificStaff" runat="server"  
                                                    RepeatDirection="Vertical" AutoPostBack="True" onselectedindexchanged="chkSpecificStaff_SelectedIndexChanged" 
                                                    >
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-sm-7">
                                            <div class="col-sm-6">
                                              <asp:TextBox ID="txtStaffSearch" CssClass="form-control  input-sm" placeholder="By Staff Name/Staff Id" style="margin-left:-15px;margin-bottom:10px" runat="server" ></asp:TextBox>
                                              </div>
                                               <div class="col-sm-6">
                                                <asp:Button ID="btnStaffSearch" runat="server" Text="Search" onclick="btnStaffSearch_Click" 
                                                     />
                                                    </div>
                                                <asp:GridView ID="GridStaff" CssClass="GridViewStyle_List" Width="100%" PageSize="15" DataKeyNames="StaffPId"
                                                    runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GridStaff_PageIndexChanging">
                                                    <%----%>
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkDelete" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SN.">
                                                            <ItemTemplate>
                                                                <%=SrNo++ %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="STAFF ID" DataField="StaffId" ItemStyle-VerticalAlign="Top" />
                                                        <asp:BoundField HeaderText="STAFF NAME" DataField="StaffName" />
                                                        <asp:BoundField HeaderText="CONTACT NO." DataField="ContactNo" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                                    <FooterStyle Font-Bold="true" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                         
                          <div class="form-group">
                             <div class="col-xs-3"  style="margin-left:150px;">
                             </div>
                             <div class="col-xs-2">
                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server"
                                     Width="100%" onclick="btnSave_Click" OnClientClick="return confirm('Are you sure??');" AccessKey="s">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Send</span>
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnSchedule" CssClass="btn btn-primary" runat="server" 
                                     Width="100%" Visible="false" onclick="btnSchedule_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Schedule</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-2">
                          <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" onclick="btnRefresh_Click" 
                                      >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div>  
                      
                          </div>
                         </div>
                         </div>
                          </ContentTemplate>
                             </asp:UpdatePanel>
                    </div>
</asp:Content>

