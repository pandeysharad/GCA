<%@ Page Title="Create Class Head" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateClassHead.aspx.cs" Inherits="Pages_CreateClassHead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">

        function MessageShow(msg) {
            alert(msg);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
        <div class="form-horizontal">    
            <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
               CREATE FEE HEAD
            </div>
        </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
             <div class="col-sm-4">
            <div class="form-horizontal"> 
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;"><%= Session["ClassLableText"]%> Head:<label for="message" style="color: Red">*</label></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtClassHead"  CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
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
                                <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" 
                                        Width="100%" onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Clear</span>
                                </asp:LinkButton>
                                </div>
                          </div>
                         <div class="form-group" style="height:300px">
                              <div class="col-xs-12">
                        <asp:GridView ID="GridClassHead" runat="server" HeaderStyle-BackColor="#66ccff" 
                                      AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                            HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                      HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                            RowStyle-Font-Bold="true" DataKeyNames="ClassHeadId" AutoGenerateSelectButton="true" 
                                      onselectedindexchanging="GridClassHead_SelectedIndexChanging" OnPageIndexChanging="GridClassHead_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No" InsertVisible="False">
                                <ItemTemplate>
                                    <%#Sno++%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ItemStyle-Width="60%" DataField="Head" HeaderText="Head" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkDelete" OnClientClick="return confirm('Do you want to delete this row...')"
                                        CommandArgument='<%# Eval("ClassHeadId") %>' ForeColor="Red" Font-Bold="true"
                                        runat="server" OnClick="LnkDelete_OnClick">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                 </asp:GridView>
               </div>
             </div>
            </div>
         </div>
         </ContentTemplate>
         </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
