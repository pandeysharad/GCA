<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OverAllFeeDetails.ascx.cs" Inherits="Controls_OverAllFeeDetails" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Over All Fee Details ( TODAY COLL. <asp:Label runat="server" ID="lblTodayCollection" ForeColor="Yellow" Text=""></asp:Label>)</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="Div2">
            <asp:GridView ID="GridData" runat="server" 
            Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black" >
                                        
                <Columns>
                </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>
     </ContentTemplate>
     </asp:UpdatePanel>
