<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top20DefaulterStudent.ascx.cs" Inherits="Controls_Top20DefaulterStudent" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Top 20 Defaulter Student</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="Div2">
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
                <asp:BoundField DataField="CourseName" HeaderText="Class/Course" />
                <asp:BoundField DataField="CourseBalance" HeaderText="Class/Course Bal." />
                <asp:BoundField DataField="TransportBalance" HeaderText="Trans. Bal" />
                <asp:BoundField DataField="OverAllBal" HeaderText="Total Bal." />
                                        
                </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>
     </ContentTemplate>
     </asp:UpdatePanel>
