﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DiscountApprovals.ascx.cs" Inherits="Controls_DiscountApprovals" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1" style="max-width: 60% !important">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Discount Approvals</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="Div2">
            <asp:GridView ID="GridDiscountApprovals" runat="server" AutoGenerateColumns="false" DataKeyNames="AdmissionId"
                Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; 
            background-color :lightblue;">
                                        
            <Columns>
            <asp:BoundField DataField="AdmissionNo" HeaderText="AdmissionNo" />
            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
            <asp:BoundField DataField="CourseName" HeaderText="Class/Course" />
            <asp:BoundField DataField="CourseRemarks" HeaderText="Discount Reason" />
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
     </ContentTemplate>
     </asp:UpdatePanel>
