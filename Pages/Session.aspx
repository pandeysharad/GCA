<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Session.aspx.cs" Inherits="Pages_Session" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">

    function MessageShow(msg) {
        alert(msg);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       SESSION CREATION
                    </div>
              </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
             <div class="col-sm-4">
            <div class="form-horizontal"> 
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;">Session:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtSession"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;">Status:</label>
                              <div class="col-xs-8">
                             <asp:DropDownList ID="ddl_Status" CssClass="form-control  input-sm" runat="server">
                             <asp:ListItem>ACTIVE</asp:ListItem>
                             <asp:ListItem>INACTIVE</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                         </div>     
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-4">
                                    <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbId" runat="server" Visible="false" Text="0"></asp:Label>
                                </div>
                                <div class="col-xs-4">         
                                 <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                        Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                                </div>
                                <div class="col-xs-4">
                                <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Clear</span>
                                </asp:LinkButton>
                                </div>
                          </div>
                         <div class="form-group" style="height:300px">
                              <div class="col-xs-12">
                                 
                    <asp:GridView ID="GridSessions" runat="server" HeaderStyle-BackColor="#66ccff" 
                                      AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Width="100%"
                            HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                      HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                          RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" 
                                      OnPageIndexChanging="OnPageIndexChanging" DataKeyNames="Sessionid" 
                                      onselectedindexchanging="GridSessions_SelectedIndexChanging">
                        <Columns> 
                             <asp:BoundField ItemStyle-Width="65%" DataField="SessionName" 
                                HeaderText="SESSION" >
                            <ItemStyle Width="65%" />
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-Width="30%" DataField="Status" HeaderText="STATUS">
                            <ItemStyle Width="30%" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#66CCFF" ForeColor="White" />
                        <HeaderStyle Font-Names="Maiandra GD" Font-Size="Small" />
                        <PagerStyle BackColor="#66CCFF" Font-Bold="False" Font-Names="Lucida Bright" 
                            Font-Size="Smaller" Font-Underline="False" HorizontalAlign="Center" />
                        <RowStyle Font-Names="Maiandra GD" Font-Size="Small" />
                 </asp:GridView>
                      </div>
              </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>

