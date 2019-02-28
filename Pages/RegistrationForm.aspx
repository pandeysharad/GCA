<%@ Page Title="Addmision Form" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationForm.aspx.cs" Inherits="Pages_RegistrationForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script language="javascript" type="text/javascript">

     function MessageShow(msg) {
         alert(msg);
     }
     function toUpper(obj) {
         var mystring = obj.value;
         var sp = mystring.split(' ');
         var wl = 0;
         var f, r;
         var word = new Array();
         for (i = 0; i < sp.length; i++) {
             f = sp[i].substring(0, 1).toUpperCase();
             r = sp[i].substring(1);
             word[i] = f + r;
         }
         newstring = word.join(' ');
         obj.value = newstring;
         return true;
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
        <div class="form-horizontal">    
            <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
              ADMISSION FORM
            </div>
        </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
          <div class="row">
                            <div class="col-sm-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Form No:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtFormNo" CssClass="form-control  input-sm" runat="server" 
                                                    Enabled="true"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender TargetControlID="txtFormNo" ID="FilteredTextBoxExtender6" runat="server" Enabled="True" ValidChars="1234567890."></cc1:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Student Name:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtStudentName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                               Father Name:</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtFatherName" onkeyup="toUpper(this)" CssClass="form-control  input-sm" 
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                          <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                <%= Session["ClassLableText"]%>:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:DropDownList ID="ddl_Course" AutoPostBack="true" CssClass="form-control  input-sm"
                                                    runat="server">
                                                    <asp:ListItem>SELECT CLASS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Address:</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtAddress" onkeyup="toUpper(this)" CssClass="form-control  input-sm" TextMode="MultiLine"
                                                    Height="50px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                      
                                    </div>
                                </div>
                                 <div class="col-sm-6">
                                    <div class="form-horizontal">
                                      <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Contact No:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtContactNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Date:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="dtDate" CssClass="form-control  input-sm" placeholder="DD/MM/YYYY"
                                                    runat="server"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    TargetControlID="dtDate" CssClass="black" PopupPosition="TopRight">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                           <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Amount:<span for="message" style="color: Red">*</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtAmount" CssClass="form-control  input-sm" runat="server" Enabled="false"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender TargetControlID="txtAmount" ID="FilteredTextBoxExtender1" runat="server" Enabled="True" ValidChars="1234567890.-"></cc1:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                            <div class="form-group">
                                            <label for="message" class="col-xs-4">
                                                Remarks:</span></label>
                                            <div class="col-xs-8">
                                                <asp:TextBox ID="txtRemarks" onkeyup="toUpper(this)" CssClass="form-control  input-sm" TextMode="MultiLine"
                                                    Height="50px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-4">
                                                <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                                <asp:Label ID="lbEnquiryId" runat="server" Visible="false" Text="0"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                                    Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" 
                                                    Width="100%" onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                                </div>
                                <div class="row" style="margin-top: 41px;">
                                 <div class="col-sm-4">
                                    <div class="form-horizontal">
                                        <div class="form-horizontal">
                                       <div class="form-group">
                                                <label for="message" class="col-xs-6">
                                                    FromNo:</span></label>
                                                <div class="col-xs-6">
                                                    <asp:TextBox ID="txtSearchFormNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                    </div>
                                    </div>
                                    
                                </div>
                                 <div class="col-sm-4">
                                   
                                    <div class="form-group">
                                                <label for="message" class="col-xs-5">
                                                    Student Name:</span></label>
                                                <div class="col-xs-6">
                                                    <asp:TextBox ID="txtSearchStudentName" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                </div>
                                 <div class="col-sm-1">
                                     <div class="form-group">
                                                <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary" runat="server" 
                                                    Width="100%" onclick="btnSearch_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Search</span>
                                                </asp:LinkButton>
                                            </div>
                                </div>
                                </div>
                               <%-- <table align="left" width="100%" style="visibility:visible">
                                    <tr>
                                        <td>
                                            
                                        </td>
                                         <td>
                                            
                                        </td>
                                         <td>
                                            <div class="form-group">
                                                <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary" runat="server" 
                                                    Width="100%" onclick="btnSearch_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Search</span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>--%>
                <div class="form-group">
                  <asp:GridView ID="GridRegistrationForm" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                      AllowPaging="true" PageSize="20" Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                      HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                      RowStyle-Font-Bold="true" AutoGenerateSelectButton="True" DataKeyNames="FrormRegistrationId"
                      OnSelectedIndexChanging="GridRegistrationForm_SelectedIndexChanging" OnPageIndexChanging="GridRegistrationForm_PageIndexChanging"
                      ShowHeaderWhenEmpty="True"  OnRowDataBound="GridRegistrationForm_RowDataBound">
                      <Columns>
                          <asp:BoundField ItemStyle-Width="8%" DataField="FormNo" HeaderText="FORM No" />
                          <asp:BoundField ItemStyle-Width="14%" DataField="StudentName" HeaderText="NAME" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="FatherName" HeaderText="FATHER" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="ContactNo" HeaderText="CONTACT" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="Class" HeaderText="CLASS" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="Date" HeaderText="DATE" DataFormatString="{0:d}" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="Amount" HeaderText="AMOUNT" />
                          <asp:BoundField ItemStyle-Width="10%" DataField="Address" HeaderText="ADDRESS" />
                          <asp:TemplateField HeaderStyle-Width="25%">
                              <ItemTemplate>
                                  <asp:LinkButton ID="LnkDelete" OnClientClick="return confirm('Do you want to delete this row...')"
                                      CommandArgument='<%# Eval("FrormRegistrationId") %>' ForeColor="Red" Font-Bold="true" runat="server"
                                      OnClick="LnkDelete_OnClick">Delete</asp:LinkButton>
                                  |<asp:LinkButton Text="Join" ID="LnkJoin" OnClick="OnSelectedJoin" ItemStyle-Width="2%"
                                      ForeColor="#337ab7" Font-Bold="true" runat="server" CommandArgument='<%# Eval("FrormRegistrationId") %>' />
                                  |<asp:LinkButton Text="Print" ID="btnPrint" OnClick="OnSelectedPrint" ItemStyle-Width="2%"
                                      ForeColor="#337ab7" Font-Bold="true" runat="server" CommandArgument='<%# Eval("FrormRegistrationId") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                      <PagerStyle HorizontalAlign="Right" CssClass="gridview" />
                      <SelectedRowStyle BackColor="Black" ForeColor="White" />
                      <EmptyDataTemplate>
                          No Record Available
                          </EmptyDataTemplate>
                  </asp:GridView>
              </div>
         </ContentTemplate>
         </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

