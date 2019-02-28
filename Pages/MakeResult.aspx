<%@ Page Title="Schedule Exam" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="MakeResult.aspx.cs" Inherits="Pages_MakeResult" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                       CREATE SCHEDULE EXAM
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate> 
     <div class="panel-body" style="border:thin solid black; margin-left:15px;margin-right:15px;margin-top:2px">
        <div class="col-xs-12">
            <div class="form-horizontal">
            <div class="form-group">
                    <label for="message" class="col-xs-2">
                        Exam Title:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlExamTitle" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" >
                        </asp:DropDownList>
                    </div>
                </div>
              <div class="form-group">
                    <label for="message" class="col-xs-2">
                        Class:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlClass" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group">
                    <label for="message" class="col-xs-2">
                       Subject Name:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlSubjectName" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" >
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="message" class="col-xs-2">
                        Exam Date:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="dtExamDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtAdmDate_CalExt" runat="server" Enabled="True" Format="dd/MM/yyyy"
                            TargetControlID="dtExamDate" CssClass="black" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-2">
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                            Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Create</span>
                        </asp:LinkButton>
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                        </asp:LinkButton>
                    </div>
                </div>
                  <div class="form-group"> 
                        <div class="row">
                          <div class="col-sm-12" style="margin-left:150px;">
                             <div class="col-xs-8">
                              <asp:GridView ID="GridMsgTemplate" runat="server" HeaderStyle-BackColor="#66ccff" 
                                     AutoGenerateColumns="false" Width="100%"
                                HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                     HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="MagTemplateId"
                                     AllowPaging="True">
                                    <Columns> 
                                        <asp:BoundField ItemStyle-Width="30%" DataField="MsgHead" 
                                            HeaderText="MSG HEAD" >
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="70%" DataField="Msg" HeaderText="MESSAGE" >
                                        <ItemStyle Width="70%" />
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

