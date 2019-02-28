<%@ Page Title="All In One" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AllInOne.aspx.cs" Inherits="Pages_AllInOne" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><br />
      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
              <div class="row">
                  <div class="col-sm-12">
                      <div class="form-group">
                          <label for="message" class="col-xs-1">
                              Heading:</label>
                          <div class="col-xs-3">
                              <asp:DropDownList ID="ddltablehead" runat="server" CssClass="form-control  input-sm"
                                  AutoPostBack="True" OnSelectedIndexChanged="ddltablehead_SelectedIndexChanged">
                              </asp:DropDownList>
                          </div>
                      </div>
                      </div>
              </div>
               <div class="row">
                  <div class="col-sm-12">
              <div style="height: 500px; overflow: scroll; float: left">
                  <asp:GridView ID="Grd" runat="server" CellPadding="2" AutoGenerateColumns="false"
                      ForeColor="#333333" GridLines="None" DataKeyNames="SVID" ShowFooter="true" CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                      Width="500px">
                      <EmptyDataTemplate>
                          <table width="100%" cellpadding="0" cellspacing="0">
                              <tr>
                                  <td>
                                      <asp:TextBox ID="txteminsertvalue" Width="300px" runat="server"></asp:TextBox>
                                  </td>
                                  <td>
                                      <asp:ImageButton ID="btnsaveem" runat="server" ImageUrl="../img/Save.png" OnClick="btnsaveem_Click"
                                          ToolTip="Save" />
                                  </td>
                              </tr>
                          </table>
                      </EmptyDataTemplate>
                      <Columns>
                          <asp:TemplateField HeaderText="Value">
                              <ItemTemplate>
                                  <asp:Label ID="lblvalue" Text='<%#Eval("TABLEVALUE") %>' runat="server"></asp:Label>
                                  <asp:TextBox ID="txtvalue" Text='<%#Eval("TABLEVALUE") %>' Visible="false" Width="300px"
                                      runat="server"></asp:TextBox>
                              </ItemTemplate>
                              <FooterTemplate>
                                  <table>
                                      <tr align="left">
                                          <td>
                                              <asp:TextBox ID="txtinsertvalue" Width="300px" runat="server"></asp:TextBox>
                                          </td>
                                          <td>
                                              <asp:ImageButton ID="btnsave" ToolTip="Save" OnClick="btnsave_Click" runat="server"
                                                  ImageUrl="../img/Save.png" />
                                          </td>
                                      </tr>
                                  </table>
                              </FooterTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                              <ItemTemplate>
                                  <asp:ImageButton ID="btnupdate" ToolTip="Update" Visible="false" OnClick="btnupdate_Click"
                                      runat="server" ImageUrl="../img/Save.png" />
                                  <asp:ImageButton ID="btndelete" ToolTip="Delete" OnClick="btndelete_Click" OnClientClick="return confirm('Are u sure you want to delete data ?')"
                                      runat="server" ImageUrl="../img/delete.gif" />
                                  <asp:ImageButton ID="btnedit" ToolTip="Edit" OnClick="btnedit_Click" runat="server"
                                      ImageUrl="../img/edit.jpg" />
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                      <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                      <EditRowStyle CssClass="EditRowStyle" />
                     
                      <HeaderStyle CssClass="HeaderStyle" ForeColor="Black" />
                      <PagerStyle CssClass="PagerStyle" />
                      <RowStyle CssClass="RowStyle" />
                      <SelectedRowStyle CssClass="SelectedRowStyle" />
                      <SortedAscendingCellStyle CssClass="SortedAscendingCellStyle" />
                      <SortedAscendingHeaderStyle CssClass="SortedAscendingHeaderStyle" />
                      <SortedDescendingCellStyle CssClass="SortedDescendingCellStyle" />
                      <SortedDescendingHeaderStyle CssClass="SortedDescendingHeaderStyle" />
                  </asp:GridView>
              </div>
              <div style="height: 45%; float: left">
                <div class="col-lg-12 pn">
                      <table>
                    <tr>
                        <td>Head : &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtTableName" CssClass="form-control" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr><td colspan="2" style="height:8px;"></td></tr>
                    <tr>
                        <td colspan="2"> 
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm bg-purple2" Text="Save" 
                                    Visible="true" onclick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm bg-purple2" 
                                    Text="Update" Visible="false" onclick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-sm bg-purple2" 
                                    Text="Delete" Visible="false" onclick="btnDelete_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-sm bg-purple2" 
                                    Text="Clear" Visible="true" onclick="btnClear_Click" />
                                    <asp:Button ID="btnrefresh" runat="server" CssClass="btn btn-sm bg-purple2" 
                                    Text="Rrefresh" Visible="true" onclick="btnrefresh_Click" />
                                    <asp:HiddenField ID="Hiddenid" runat="server" Value="0" />
                        </td>
                    </tr>
                    <tr><td colspan="2" style="height:8px;"></td></tr>
                </table>
                <table style="width:100%">
                            <tr>
                                <td>
                                   <table class="alert alert-theme" style="width:100%">
                                         <tr>
                                             <td colspan="3">
                                                <table>
                                                    <tr>
                                                        <td>Search by Head :</td>
                                                        <td><asp:TextBox ID="txtSearch" CssClass="form-control" Width="170px"
                                                         style="margin-right:7px;" runat="server"></asp:TextBox></td>
                                                         <td><asp:Button ID="btnSearch" runat="server" CssClass="btn btn-sm bg-purple2" 
                                                                        Text="Search" Visible="true" onclick="btnSearch_Click" /></td>
                                                    </tr>
                                                </table>
                                             </td>
                                         </tr>         
                                   </table>
                                </td>
                            </tr>
                      </table>
                      <table style=" width:100%;">
                        <tr>
                            <td>
                                <div style="max-height:500px; overflow:auto; width:100%; vertical-align:top">
                <asp:GridView ID="GridView1" runat="server" DataKeyNames="STID" 
                    AutoGenerateColumns="false" onselectedindexchanging="Grd_SelectedIndexChanging" AutoGenerateSelectButton="false" CssClass="table table-bordered" ShowFooter="false">
                <Columns>
                <asp:BoundField DataField="TABLENAME"  HeaderText="Head"/>
                </Columns>
                </asp:GridView>
                </div>
                            </td>
                        </tr>
                      </table>
                    </div>
              </div>
              </div>
              </div>
          </ContentTemplate>
      </asp:UpdatePanel>
    </div>  
</asp:Content>

