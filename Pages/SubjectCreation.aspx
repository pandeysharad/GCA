<%@ Page Title="Subject Create" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectCreation.aspx.cs" Inherits="Pages_SubjectCreation" %>

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
                       SUBJECT CREATION CLASS WISE
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
                        <asp:TextBox ID="txtSubjectName" CssClass="form-control  input-sm" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <asp:CheckBox ID="chkShortName" Text="Any Short Name" runat="server" 
                            AutoPostBack="True" oncheckedchanged="chkShortName_CheckedChanged" />
                    </div>
                     <div class="col-xs-2">
                       <asp:TextBox ID="txtSubjectShortName" CssClass="form-control  input-sm" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-2">
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Create</span>
                        </asp:LinkButton>
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                        </asp:LinkButton>
                    </div>
                </div>
                  <div class="form-group"> 
                        <div class="row">
                          <div class="col-sm-12">
                             <div class="col-xs-8">
                              <asp:GridView ID="GridSubjects" runat="server" HeaderStyle-BackColor="#66ccff" 
                                     AutoGenerateColumns="false" Width="100%"
                                HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                     HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="SubjectId"
                                     AllowPaging="True" 
                                     onselectedindexchanging="GridSubjects_SelectedIndexChanging">
                                    <Columns> 
                                        <asp:BoundField ItemStyle-Width="20%" DataField="CourseName" 
                                            HeaderText="CLASS NAME" >
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="50%" DataField="SubjectName" HeaderText="SUBJECT NAME" >
                                        <ItemStyle Width="50%" />
                                        </asp:BoundField>
                                         <asp:BoundField ItemStyle-Width="40%" DataField="SubjectShortName" HeaderText="SHORT NAME" >
                                        <ItemStyle Width="40%" />
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