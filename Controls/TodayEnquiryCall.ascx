<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TodayEnquiryCall.ascx.cs" Inherits="Controls_TodayEnquiryCall"   %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<link href="../css/main.css" rel="stylesheet" type="text/css" />--%>
<%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">--%>

 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>
    <div class="modal-dialog1">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header View_header">
                <h4 class="modal-title">Today Enquiry Call</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <!-- Modal body -->
            <div class="modal-body" id="mannualProcess">
                    <input type="hidden" id="IDH1" name="GUID" />
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
                     <div id="IdErrorMsg" runat="server" visible="false" class="alert alert-danger fade in">
                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                        <strong>Error!</strong> Something went wrong.
                    </div>
                   <div id="IdSuccessMsg" runat="server" visible="false" class="alert alert-success fade in">
                            <a href="#" class="close" data-dismiss="alert">&times;</a>
                            <strong>Success!</strong> Record saved successfully.
                    </div>
                    <asp:GridView ID="EnquiryStudentNextCall" runat="server" AutoGenerateColumns="false" DataKeyNames="EnquiryId"
                            Width="100%" CssClass="table table-striped table-bordered table-hover dataTable no-footer" style="color:Black; ">
                                        
                        <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%= ++srno%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EnquiryNo" HeaderText="SNo" />
                        <asp:BoundField DataField="StudentName" HeaderText="NAME" />
                        <asp:BoundField DataField="Address" HeaderText="ADDRESS" />
                        <asp:BoundField DataField="ContactNo" HeaderText="CONTACT" />
                        <asp:BoundField DataField="EnquiryForCourse" HeaderText="ENQUIRY-FOR" />
                        <asp:BoundField DataField="fees" HeaderText="FEES" />
                        <asp:BoundField DataField="EnquiryDate" HeaderText="DATE" DataFormatString="{0:d}" />
                        <%--<asp:BoundField DataField="NextCallDate" HeaderText="NEXT-CALL"
                            DataFormatString="{0:d}" />--%>
                        <asp:TemplateField HeaderText="NEXT-CALL" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtNextCallDate" Width="100%" Height="30px" BorderStyle="None" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "NextCallDate")).ToShortDateString()%>' />
                         
                        </ItemTemplate>
                        </asp:TemplateField>
                                        
                        </Columns>
                        </asp:GridView>
                <asp:Button id="btnExpotToExcel" Enabled="false" runat="server" Text="Print" OnClick="btnExpotToExcel_OnClick"></asp:Button>
                <asp:Button id="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" CssClass="ButtonRinght"></asp:Button>
            </div>
        </div>


    </div>
     </ContentTemplate>
     </asp:UpdatePanel>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#IdSuccessMsg").show().delay(5000).fadeOut();
         });
     </script>