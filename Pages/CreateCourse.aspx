<%@ Page Title="Create Class/Course" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateCourse.aspx.cs" Inherits="Pages_CreateCourse" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">

    function MessageShow(msg) {
        alert(msg);
    }
    </script>
    <style type="text/css">
    .GridHeaderStyle
    {
        text-align:center !important;
    }
    th
    {
         text-align:center !important;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
      <div class="col-sm-12">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-top:2px"> 
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       CREATE CLASS / COURSE FEE
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
                             <label for="message" class="col-xs-3" style="margin-left:150px;">Serial No:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                             <asp:TextBox ID="txtSerialNo" CssClass="form-control  input-sm"  runat="server"  Enabled="false"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-3"  style="margin-left:150px;"><%= Session["ClassLableText"]  %> Name:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                             <asp:TextBox ID="txtCourseName" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                              <cc1:AutoCompleteExtender
                                runat="server"
                                ID="AutoCompleteExtender1" 
                                TargetControlID="txtCourseName"
                                ServicePath="~/AutoComplete.asmx"
                                ServiceMethod="GetCourseName"
                                MinimumPrefixLength="1" 
                                CompletionInterval="0"
                                CompletionSetCount="20"
                                CompletionListCssClass="CompletionListCssClass"
                                CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass"
                                CompletionListItemCssClass="CompletionListItemCssClass"
                                DelimiterCharacters="&nbsp;,:" 
                                Enabled="True" >
                            </cc1:AutoCompleteExtender>
                             </div>
                         </div>
                        
                    <div class="form-group">
                     <div class="row">
                             <div class="col-xs-12" style="margin-left:100px;">
                             <div class="col-xs-2"></div>
                               <div class="col-xs-10">
                                   <asp:GridView ID="GridCourseHead" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                       BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" DataKeyNames="CourseHeadId"
                                       ShowFooter="True" OnRowCommand="GridCourseHead_RowCommand" ShowHeaderWhenEmpty="True"
                                       EmptyDataText="No Records Found" Font-Bold="True" CellSpacing="2" ForeColor="Black" HeaderStyle-CssClass="GridHeaderStyle">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("CourseHeadId") %>' ForeColor="Blue"
                            Font-Bold="true" runat="server" CommandName="EditRow">Edit</asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkUpdate" CommandArgument='<%# Eval("CourseHeadId") %>' ForeColor="Blue"
                            Font-Bold="true" runat="server"  OnClick="lnkUpdate_OnClick">Update</asp:LinkButton>

                        <asp:LinkButton ID="LnkCancle" CommandArgument='<%# Eval("CourseHeadId") %>' ForeColor="Blue"
                            Font-Bold="true" runat="server" CommandName="CancleUpdate">Cancle</asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CourseId" InsertVisible="False" SortExpression="EmployeeId" Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CourseHeadId") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CourseHeadId") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Serial No"  InsertVisible="False" SortExpression="EmployeeId">
                    <EditItemTemplate>
                       <%#Sno++%>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <%#Sno++%>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Head" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Head") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Head") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    <asp:DropDownList ID="ddlHead"  AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlHead_OnSelectedIndexChanged">
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RfvtxtName" ValidationGroup="INSERT" ControlToValidate="ddlHead" InitialValue="0"
                            runat="server" ErrorMessage="R" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Monthly Amount" SortExpression="Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtAddress" ValidationGroup="INSERT" ControlToValidate="txtAmount"
                            runat="server" ErrorMessage="R" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="LnkDelete" OnClientClick="return confirm('Do you want to delete this row...')"
                         CommandArgument='<%# Eval("CourseHeadId") %>' ForeColor="Red" Font-Bold="true"
                         runat="server" OnClick="LnkDelete_OnClick">Delete</asp:LinkButton>
                 </ItemTemplate>
                  <FooterTemplate>
                        <asp:LinkButton ID="linkinsert" ValidationGroup="INSERT" Font-Bold="true" CommandName="InsertRow" OnClick="linkinsert_OnClick"
                            runat="server">Insert</asp:LinkButton>
                    </FooterTemplate>
                 </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
                                 </div>
                             </div>
                             </div>
                   </div>  
                    <div class="form-group">
                             <label for="message" class="col-xs-2"  style="margin-left:150px;">1st Child Fees:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-3">
                                     <asp:TextBox ID="txtFees" Enabled="false" style="margin-left:-50px;"  CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                           <div class="form-group">
                             <label for="message" class="col-xs-2" style="margin-left:150px;">2nd Child Fees:<span for="message" style="color:Red">*</span></label>
                               <div class="col-xs-2">
                                   <asp:DropDownList ID="ddlSecondDiscountType" runat="server" AutoPostBack="true" 
                                       CssClass="form-control  input-sm" style="margin-left:-50px;" 
                                       onselectedindexchanged="ddlSecondDiscountType_SelectedIndexChanged">
                                   <asp:ListItem>Flat</asp:ListItem>
                                   <asp:ListItem>Percent</asp:ListItem>
                                   </asp:DropDownList>
                             </div>
                               <div class="col-xs-2" style="margin-left:-70px;">
                                     <asp:TextBox ID="txtSecondDiscount" CssClass="form-control  input-sm"  
                                         runat="server" AutoPostBack="True" 
                                         ontextchanged="txtSecondDiscount_TextChanged"></asp:TextBox>
                             </div>
                              <div class="col-xs-3" style="margin-left:-20px;">
                                     <asp:TextBox ID="txtSecondChildFees" CssClass="form-control  input-sm" Enabled="false" runat="server"></asp:TextBox>
                             </div>
                         </div>
                           <div class="form-group">
                             <label for="message" class="col-xs-2" style="margin-left:150px;">3rd Child Fees:<span for="message" style="color:Red">*</span></label>
                               <div class="col-xs-2">
                                   <asp:DropDownList ID="ddlThirdDiscountType" AutoPostBack="true" runat="server" 
                                       CssClass="form-control  input-sm" style="margin-left:-50px;" 
                                       onselectedindexchanged="ddlThirdDiscountType_SelectedIndexChanged">
                                   <asp:ListItem>Flat</asp:ListItem>
                                   <asp:ListItem>Percent</asp:ListItem>
                                   </asp:DropDownList>
                             </div>
                               <div class="col-xs-2" style="margin-left:-70px;">
                                     <asp:TextBox ID="txtThirdDiscount" CssClass="form-control  input-sm"  
                                         runat="server" AutoPostBack="True" ontextchanged="txtThirdDiscount_TextChanged"></asp:TextBox>
                             </div>
                              <div class="col-xs-3" style="margin-left:-20px;">
                                     <asp:TextBox ID="txtThirdChildFees" CssClass="form-control  input-sm" Enabled="false"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                          <div class="form-group">
                             <div class="col-xs-3"  style="margin-left:150px;">
                                 <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                 <asp:Label ID="lbId" runat="server"  Visible="false" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-2">
                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                     Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-2">
                          <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" 
                                       onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div>  
                        <div class="form-group"> 
                        <div class="row">
                          <div class="col-sm-12" style="margin-left:150px;">
                             <div class="col-xs-8">
                              <asp:GridView ID="GridCourse" runat="server" HeaderStyle-BackColor="#66ccff" 
                                     AutoGenerateColumns="false" Width="100%"
                                HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                     HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="CourseId"
                                     onselectedindexchanging="GridCourse_SelectedIndexChanging" OnPageIndexChanging="GridCourse_PageIndexChanging"
                                     AllowPaging="True" PageSize="20">
                                    <Columns> 
                                        <asp:BoundField ItemStyle-Width="25%" DataField="SerialNo" HeaderText="SNo" >
                                        <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="40%" DataField="CourseName" 
                                            HeaderText="CLASS/COURSE" >
                                        <ItemStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="30%" DataField="FirstChildFees" HeaderText="MONTHLY FEES" >
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BackColor="#66CCFF" Font-Bold="True" Font-Names="Maiandra GD" 
                                        Font-Size="Small" />
                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                             </asp:GridView>
                             </div>
                             <div class="col-xs-2"></div>
                             </div>
                             </div>
                             </div>
                          </div>
                         </div>
                         </div>
                          </ContentTemplate>
                             </asp:UpdatePanel>
                    </div>
</asp:Content>


