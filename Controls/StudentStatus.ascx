<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentStatus.ascx.cs" Inherits="Controls_StudentStatus" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1" style="max-width: 40% !important">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Student Status</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="Div2">
           <asp:GridView ID="GridStudentStaus" runat="server" 
                Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
            <Columns>
            </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
     </ContentTemplate>
     </asp:UpdatePanel>