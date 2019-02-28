<%@ Page Title="Create Exam Tittle" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateExamTitle.aspx.cs" Inherits="Pages_CreateExamTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                        CREATE EXAM TERM/TITLE
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="panel-body" style="border: thin solid black; margin-left: 15px; margin-right: 15px;
                    margin-top: 2px">
                    <div class="col-xs-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-xs-12" style="background-color: lightseagreen; color: White;">
                                    <b>Create Exam Term:</b>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message" class="col-xs-2">
                                    Exam Term:<span for="message" style="color: Red">*</span></label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtExamTerm" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-2">
                                </div>
                                <div class="col-xs-2">
                                    <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"
                                        OnClick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Create</span>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-xs-2">
                                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%"
                                        OnClick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-xs-8">
                                            <asp:GridView ID="GridTerms" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                                Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                                HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="ExamTermId"
                                                AllowPaging="True" OnSelectedIndexChanging="GridTerms_SelectedIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNo">
                                                        <ItemStyle Width="25%" />
                                                        <ItemTemplate>
                                                            <%=SrNo++ %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-Width="80%" DataField="ExamTerm1" HeaderText="Exam Term">
                                                        <ItemStyle Width="70%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btndelete" ToolTip="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are u sure you want to delete data ?')"
                                                                runat="server" ImageUrl="../img/delete.gif" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#66CCFF" Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <RowStyle Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                                            </asp:GridView>
                                        </div>
                                        <div class="col-xs-2">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12" style="background-color: lightseagreen; color: White;">
                                    <b>Create Exam Title:</b>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message" class="col-xs-2">
                                    Select term:<span for="message" style="color: Red">*</span></label>
                                <div class="col-xs-4">
                                    <asp:DropDownList ID="ddlSelectTerm" runat="server" CssClass="form-control  input-sm"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSelectTerm_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message" class="col-xs-2">
                                    Exam Title:<span for="message" style="color: Red">*</span></label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtExamTitle" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-2">
                                </div>
                                <div class="col-xs-2">
                                    <asp:LinkButton ID="btnSaveExamTitle" CssClass="btn btn-primary" runat="server" Width="100%"
                                        OnClick="btnSaveExamTitle_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Create</span>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-xs-2">
                                    <asp:LinkButton ID="btnRefExamTitle" CssClass="btn btn-primary" runat="server" Width="100%"
                                        OnClick="btnRefExamTitle_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-xs-8">
                                            <asp:GridView ID="GridTitle" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                                Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                                HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="ExamTitleId"
                                                AllowPaging="True" OnSelectedIndexChanging="GridTitle_SelectedIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNo">
                                                        <ItemStyle Width="30%" />
                                                        <ItemTemplate>
                                                            <%=SrNo1++%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-Width="30%" DataField="ExamTerm1" HeaderText="EXAM TERM">
                                                        <ItemStyle Width="30%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField ItemStyle-Width="70%" DataField="ExamTitleName" HeaderText="EXAM TITLE NAME">
                                                        <ItemStyle Width="70%" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle BackColor="#66CCFF" Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <RowStyle Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                                            </asp:GridView>
                                        </div>
                                        <div class="col-xs-2">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
