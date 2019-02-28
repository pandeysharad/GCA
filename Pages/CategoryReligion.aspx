<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="CategoryReligion.aspx.cs" Inherits="Pages_CategoryReligion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initialscale=1">
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <div class="row" style="margin-top: 10px; margin-bottom: 10px">
        <div class="panel-body" style="border: thin solid black; background-color: #42b3f4;
            color: White; height: 35px; margin-bottom: 2px">
            <div class="col-sm-12" style="margin-left: 10px">
                <div class="form-horizontal">
                    <div class="form-group" style="text-align: center; margin-top: -12px; font-weight: bold;
                        font-size: 22px; font-family: Maiandra GD">
                       CAST & RELIGION CREATION
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="border: thin solid black;">
           
            <div class="col-sm-6" style="background-color: #b3daff; margin-left: -5px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="form-group" style="margin-top: -10px; color: White; text-align: center;
                                background-color: #000000">
                                <label for="message" class="col-xs-12" style="margin-bottom: -1px; font-family: Maiandra GD">
                                    CAST</label>
                            </div>
                            <div class="form-group">
                                <label for="message" class="col-xs-4">
                                    Serial No:</label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtCategoryNo" Enabled="false"
                                        CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-xs-4">
                                    <asp:CheckBox ID="chkCategoryNo" Text="Change" 
                                        runat="server" oncheckedchanged="chkCategoryNo_CheckedChanged" 
                                        AutoPostBack="True" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top: -5px">
                                <label for="message" class="col-xs-4">
                                    Category:</label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtCategory" Style="text-transform: uppercase;" CssClass="form-control  input-sm"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group" style="margin-top: -5px">
                                        <div class="col-xs-4">
                                            <asp:Label ID="lbCategoryFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                            <asp:Label ID="lbCategoryId" runat="server" Visible="false" Text="0"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnCatSave" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnCatClear" CssClass="btn btn-primary" runat="server" Width="100%"
                                              >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <asp:GridView ID="GridCategory" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="20" Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                    HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                    RowStyle-Font-Bold="true">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%" ForeColor="Red" runat="server"
                                                    CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ItemStyle-Width="20%" DataField="SerialNo" HeaderText="SNo" />
                                        <asp:BoundField ItemStyle-Width="75%" DataField="Category" HeaderText="CATEGORY" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
             <div class="col-sm-6" style="background-color: #b3daff; margin-left: 5px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="form-group" style="margin-top: -10px; color: White; text-align: center;
                                background-color: #000000">
                                <label for="message" class="col-xs-12" style="margin-bottom: -1px; font-family: Maiandra GD">
                                    RELIGION</label>
                            </div>
                            <div class="form-group" style="margin-top: 10px">
                                <label for="message" class="col-xs-4">
                                    Serial No:</label>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtReligionNo" Enabled="false"
                                        CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-xs-4">
                                    <asp:CheckBox ID="chkReligionNo" Text="Change"  runat="server" 
                                        oncheckedchanged="chkReligionNo_CheckedChanged" AutoPostBack="True" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-top: -5px">
                                <label for="message" class="col-xs-4">
                                    Religion:</label>
                                <div class="col-xs-8">
                                    <asp:TextBox ID="txtReligion" Style="text-transform: uppercase;" CssClass="form-control  input-sm"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="form-group" style="margin-top: -5px">
                                        <div class="col-xs-4">
                                            <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                            <asp:Label ID="lbId" runat="server" Visible="false" Text="0"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnReligSave" CssClass="btn btn-primary" runat="server" Width="100%"
                                             >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                            </asp:LinkButton>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:LinkButton ID="btnReligRefresh" CssClass="btn btn-primary" runat="server" Width="100%">
                                              
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <asp:GridView ID="GridReligion" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="20" Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                    HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                    RowStyle-Font-Bold="true">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%" ForeColor="Red" runat="server"
                                                    CommandName="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ItemStyle-Width="20%" DataField="SerialNo" HeaderText="SNo" />
                                        <asp:BoundField ItemStyle-Width="75%" DataField="ReligionName" HeaderText="CATEGORY" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
