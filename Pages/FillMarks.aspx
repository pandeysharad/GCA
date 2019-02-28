<%@ Page Title="Fill Marks" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="FillMarks.aspx.cs" Inherits="Pages_FillMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../css/SoftGreyGridView.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
                color: White; height: 35px; margin-top: 2px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                       FILL MARKS 
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
                        Exam Term:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlTerms" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlTerms_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>
                </div>
            <div class="form-group">
                    <label for="message" class="col-xs-2">
                        Exam Title:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlExamTitle" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlExamTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group">
                    <label for="message" class="col-xs-2">
                       Student Name:<span for="message" style="color: Red">*</span></label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddlStudentName" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" >
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="col-sm-12" style="margin-top:30px;" id="IdInstallments" runat="server">
            <div class="form-horizontal">
                <div class="form-group" style="margin-top:-13px">            
                  <asp:GridView ID="GridFillMarks" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
            ShowFooter="True" Width="100%" CellPadding="4" ForeColor="#333333" 
                GridLines="None" DataKeyNames="ExamScheduleId">
              <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Subjects" HeaderText="Subjects">
                    <ItemStyle Width="25%" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText="Subject Marks">
                    <ItemTemplate>
                     <ItemStyle Width="20%" />
                            <asp:TextBox ID="txtMarks" runat="server" Height="30px"
                                Text=''></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adn Subject Marks">
                <ItemTemplate>
                 <ItemStyle Width="20%" />
                    <asp:TextBox ID="txtAdnMarks"  runat="server" Height="30px"
                        Text=''></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="Minimum" HeaderText="Minimum">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="Maximum" HeaderText="Maximum">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
            </Columns>
              <EditRowStyle BackColor="#7C6F57" />
              <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#E3EAEB" Font-Bold="true" />
              <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F8FAFA" />
              <SortedAscendingHeaderStyle BackColor="#246B61" />
              <SortedDescendingCellStyle BackColor="#D4DFE1" />
              <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>    
            </div>
            </div>
        </div>
                <div class="form-group">
                    <div class="col-xs-2">
                       <asp:DropDownList ID="ddlFillMarksId" CssClass="form-control  input-sm" 
                            runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
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
                        <div class="col-xs-12">
                            <asp:GridView ID="Gridfill" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                Width="100%" CssClass="GridViewStyle_List" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="AdmiId"
                                AllowPaging="True" OnRowDataBound="OnRowDataBoundGridfill" 
                                onselectedindexchanging="Gridfill_SelectedIndexChanging">
                                <PagerStyle CssClass="PagerStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN.">
                                        <ItemTemplate>
                                            <%=SrNo++ %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STUDENT DETAILS" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <a href='#' target="_blank" style="text-decoration: none">
                                                <%#DataBinder.Eval(Container.DataItem, "StudentName")%><hr style="margin: 0; padding: 0" />
                                                <%#DataBinder.Eval(Container.DataItem, "RollNo")%><hr style="margin: 0; padding: 0" />
                                                <%#DataBinder.Eval(Container.DataItem, "ContactNumber")%><hr style="margin: 0; padding: 0" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CLASS/SECTION" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "CourseName")%><hr style="margin: 0; padding: 0" />
                                            <%#DataBinder.Eval(Container.DataItem, "Section")%><hr style="margin: 0; padding: 0" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="" ItemStyle-VerticalAlign="Top" />
                                </Columns>
                                <HeaderStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                <FooterStyle BackColor="#EDEDED" ForeColor="#0487B2" />
                                <FooterStyle Font-Bold="true" />
                            </asp:GridView>
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

