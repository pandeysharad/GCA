<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
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
                <%--<div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                    color: White; height: 35px; margin-bottom: 2px">
                    <div class="col-sm-12" style="margin-left: 10px">
                        <div class="form-horizontal">
                            <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                                font-size: 22px; font-family: Maiandra GD">
                                Dashboard
                            </div>
                        </div>
                    </div>
                </div>--%>
                <div class="panel-body" style="border: thin solid black;">
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -16px;
                        margin-right: -16px; "> 
                        <div class="PandelHeading">Over All Fee Details ( TODAY COLL. <asp:Label runat="server" ID="lblTodayCollection" ForeColor="Yellow" Text=""></asp:Label>)</div>
                        
                        <div class="col-sm-12" style="margin-top: 40px;" id="IdMonthlyInstallments" runat="server"
                            visible="true">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -25px;margin-bottom:-25px">
                                    <asp:GridView ID="GridData" runat="server" 
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                                        <Columns>
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="border: thin solid black; width:25%; margin-top:5px;float:left" >
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -10px;
                        margin-right: -10px; "> 
                        <div class="PandelHeading">Student Status</div>
                        
                        <div class="col-sm-12" style="margin-top: 23px; margin-bottom:-45px">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -13px">
                                    <asp:GridView ID="GridStudentStaus" runat="server" 
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                                        <Columns>
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="border: thin solid black; width:50%; margin-top:5px;float:left"  id="SectionGridUpdateApprovals" runat="server" visible="false">
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -10px;
                        margin-right: -10px; "> 
                        <div class="PandelHeading">Grid Update Approvals</div>
                        
                        <div class="col-sm-12" style="margin-top: 23px; margin-bottom:-45px">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -13px">
                                    <asp:GridView ID="GridGridUpdateApprovals" runat="server" AutoGenerateColumns="false" DataKeyNames="AdmissionId"
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; 
                                        background-color :lightblue;">
                                        
                                        <Columns>
                                        <asp:BoundField DataField="AdmissionNo" HeaderText="AdmissionNo" />
                                        <asp:BoundField DataField="R2" HeaderText="Student Name" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnView" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnView_Click" Text="View">
                                </asp:LinkButton>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                        <asp:LinkButton ID="btnApproved" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnApproved_Click" Text="Approved" OnClientClick="return confirm('Are you sure Approve ??');">
                                </asp:LinkButton>
                                </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                        <asp:LinkButton ID="btnCancel" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnCancel_Click" Text="Cancel" OnClientClick="return confirm('Are you sure Cancel??');">
                                </asp:LinkButton>
                                </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                  <div class="panel-body" style="border: thin solid black; width:50%; margin-top:5px;float:left"  id="SelectGridDiscountApprovals" runat="server" visible="false">
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -10px;
                        margin-right: -10px; "> 
                        <div class="PandelHeading">Discount Approvals</div>
                        
                        <div class="col-sm-12" style="margin-top: 23px; margin-bottom:-45px">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -13px">
                                    <asp:GridView ID="GridDiscountApprovals" runat="server" AutoGenerateColumns="false" DataKeyNames="AdmissionId"
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; 
                                        background-color :lightblue;">
                                        
                                        <Columns>
                                        <asp:BoundField DataField="AdmissionNo" HeaderText="AdmissionNo" />
                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                        <asp:BoundField DataField="DiscountAmount" HeaderText="Discount Amount" />
                                      
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                        <asp:LinkButton ID="btnApproved" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnDiscountApproved_Click" Text="Approved" OnClientClick="return confirm('Are you sure Approve ??');">
                                </asp:LinkButton>
                                </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                        <asp:LinkButton ID="btnCancel" CssClass="btn btn-primary" runat="server" 
                                    Width="100%" onclick="btnDiscountCancel_Click" Text="Cancel" OnClientClick="return confirm('Are you sure Cancel??');">
                                </asp:LinkButton>
                                </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="border: thin solid black; width:75%; margin-top:5px;float:left"  >
                    <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                        color: White; height: 40px; margin-bottom: 2px; margin-top: -16px; margin-left: -10px;
                        margin-right: -10px; "> 
                        <div class="PandelHeading">Top 20 Defaulter Student</div>
                        
                        <div class="col-sm-12" style="margin-top: 23px; margin-bottom:-45px">
                            <div class="form-horizontal">
                                <div class="form-group" style="margin-top: -13px">
                                    <asp:GridView ID="GridTop20Defaulter" runat="server" AutoGenerateColumns="false" DataKeyNames="AdmissionId"
                                         Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; ">
                                        
                                        <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%= ++srnoTop20Defaulter%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="AdmissionNo" HeaderText="AdmissionNo" />
                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                                        <asp:BoundField DataField="ParentContact" HeaderText="Parent Contact" />
                                        <asp:BoundField DataField="CourseName" HeaderText="Class" />
                                        <asp:BoundField DataField="CourseBalance" HeaderText="Class Bla." />
                                        <asp:BoundField DataField="TransportBalance" HeaderText="Trans. Bla" />
                                        <asp:BoundField DataField="OverAllBal" HeaderText="Total Bla." />
                                        
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        
        function sessionExpireAlert() {
        debugger
            
            setTimeout(function () {
                window.location = "SessionExpired.aspx";
            }, 120000);
        }
    </script>
</asp:Content>

