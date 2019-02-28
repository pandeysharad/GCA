<%@ Page Title="Setting" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Pages_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        SETTING
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
                    <div class="col-xs-12" style="background-color: lightseagreen; color: White;">
                        <b>MESSAGE API:</b>
                    </div>
                </div>
                <div class="form-group">
                    <label for="message" class="col-xs-2">
                        Message API:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txtMsgAPI" CssClass="form-control  input-sm" runat="server" TextMode="MultiLine"
                            Height="80px"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group">
                    <label for="message" class="col-xs-2">
                        At a Time Accept Payment:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-10">
                        <asp:CheckBox ID="chkSendMsg" Text="Send Message" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-2">
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Send</span>
                        </asp:LinkButton>
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

