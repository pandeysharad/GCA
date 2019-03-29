<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StaffBirthday.ascx.cs" Inherits="Controls_StaffBirthday" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Today Staff Birthday</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="Div2">
                    <input type="hidden" id="Hidden1" name="GUID" />
                    <input type="hidden" value="Manual Processing" name="BT" />
                   <%-- <table width="100%">
                        <tr>
                            <td align="center" valign="top">Remark : </td>
                            <td><input type="text" id="mannual" name="mannual" style="width: 310px;"/><br /><br /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button id="btnExpotToExcel" runat="server" Text="Export To Excel" OnClick="btnExpotToExcel_OnClick"></asp:Button></td>
                        </tr>
                    </table>--%>
                    <asp:GridView ID="GridViewStaffBirthday" runat="server" AutoGenerateColumns="false" DataKeyNames="StaffPId"
                            Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; ">
                        <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%= ++srno%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StaffId" HeaderText="STAFF ID" />
                        <asp:BoundField DataField="StaffName" HeaderText="STAFF NAME" />
                        <asp:BoundField DataField="ContactNo" HeaderText="CONTACT NO." />
                        <asp:BoundField DataField="StaffType" HeaderText="STAFF TYPE" />
                        <asp:BoundField DataField="FatherName" HeaderText="FATHER NAME" />
                        <asp:BoundField DataField="MotherName" HeaderText="MOTHER NAME" />
                        </Columns>
                        </asp:GridView>
                 <%-- <asp:Button id="Button1" runat="server" Text="Export To Excel"></asp:Button>--%>
            </div>
        </div>


    </div>
     </ContentTemplate>
     </asp:UpdatePanel>


