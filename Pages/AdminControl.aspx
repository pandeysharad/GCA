<%@ Page Title="Admin Control" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AdminControl.aspx.cs" Inherits="Pages_AdminControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../css/main.css" rel="stylesheet" type="text/css" />
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
                      ADMINISTRATOR CONTROLS
                    </div>
              </div>
      </div>
      </div>
    <div class="panel-body" style="border:thin solid black;">
    <div id="page"  style="margin:-10px">
         <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#Profile" aria-controls="Profile" role="tab" data-toggle="tab">ORG. PROFILE</a></li>
            <li><a href="#Users" aria-controls="Users" role="tab" data-toggle="tab">USERS INFO</a></li>
            <li><a href="#Permission" aria-controls="Permission" role="tab" data-toggle="tab">PERMISSION</a></li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="Profile" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
            <div class="panel-body">
            <div class="row">
             <div class="col-sm-2">
             </div>
            <div class="col-sm-6" style="margin-bottom:-10px">
            <div class="form-horizontal">
                         <div class="form-group">
                             <label for="message" class="col-xs-4">School Name:<span for="message" style="color: Red">*</span></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtSchoolName" CssClass="form-control  input-sm" style="text-transform:uppercase"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Address:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtSchoolAddress" CssClass="form-control  input-sm" style="text-transform:uppercase"  runat="server"></asp:TextBox>
                             </div>
                        </div>
                         <div class="form-group"  style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Phone Number:</label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtPhoneNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>
                         <div class="form-group"  style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Contact Number:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtContactNumber" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Website:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtWebsite" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>   
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Email:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtEmail" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                        </div>    
                        <div class="form-group">
                             <div class="col-xs-4">
                                 <asp:Label ID="lbFlag" Visible="false" runat="server" Text="0"></asp:Label>
                                 <asp:Label ID="lbSchoolId" Visible="false" runat="server" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-4">
                    <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%" 
                                     onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-4">
                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" 
                                       onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                        </div>        
                    </div>
                </div>
            </div>
    </div>
            </div>
             <div role="tabpanel" class="tab-pane" id="Users" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
              <div class="panel-body">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             <div class="row">
             <div class="col-sm-2">
             </div>
             <div class="col-sm-4">    
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Serial No:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtSerialNo" Enabled="false" CssClass="form-control  input-sm" style="text-transform:uppercase"  runat="server"></asp:TextBox>
                             </div>
                        </div>     
                         <div class="form-group">
                             <label for="message" class="col-xs-4">User Type:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:DropDownList ID="ddlUserType" CssClass="form-control  input-sm"  runat="server">
                              <asp:ListItem>--Select--</asp:ListItem>
                              <asp:ListItem>Admin</asp:ListItem>
                              <asp:ListItem>Staff</asp:ListItem>
                              <asp:ListItem>Teacher</asp:ListItem>
                              </asp:DropDownList>
                             </div>
                        </div>    
                         <div class="form-group">
                             <label for="message" class="col-xs-4">User Name:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtUserName" CssClass="form-control  input-sm" style="text-transform:uppercase"  runat="server"></asp:TextBox>
                             </div>
                        </div>      
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Login Id:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtLoginId" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>    
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Password:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtPassword" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                        </div>      
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Status:<span for="message" style="color: Red">*</span></label>
                             <div class="col-xs-8">
                              <asp:DropDownList ID="ddlStatus" CssClass="form-control  input-sm"  runat="server">
                               <asp:ListItem>--Select--</asp:ListItem>
                              <asp:ListItem>Active</asp:ListItem>
                              <asp:ListItem>Inactive</asp:ListItem>
                              </asp:DropDownList>
                             </div>
                        </div>   
                        <div class="form-group">
                             <div class="col-xs-4">
                                 <asp:Label ID="lbUserFlag" runat="server" Text="0"  Visible="false"></asp:Label>
                                 <asp:Label ID="lbUserId" runat="server" Text="0"  Visible="false"></asp:Label>
                             </div>
                             <div class="col-xs-4">
                    <asp:LinkButton ID="btnUserSave" CssClass="btn btn-primary" runat="server" Width="100%" 
                                     onclick="btnUserSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-4">
                    <asp:LinkButton ID="btnUserClear" CssClass="btn btn-primary" runat="server" Width="100%" 
                                       onclick="btnUserClear_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
             </div>
             </div>
             </div>
             <div class="row">
             <div class="col-sm-12">
            <div class="form-horizontal">
             <div class="form-group">
                <asp:GridView ID="GridUsers" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                           HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                           RowStyle-Font-Bold="true">
                        <Columns>                        
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:LinkButton Text="Select" ID="lnkSelect" ItemStyle-Width="3%" ForeColor="Blue" Font-Bold="true" runat="server" OnClick="Select_click" CommandArgument='<%# Eval("UserId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField ItemStyle-Width="8%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="40%" DataField="UserName" HeaderText="USER NAME" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="UserType" HeaderText="USER TYPE" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="UserLoingId" HeaderText="LOGIN ID" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Password" HeaderText="PASSWORD" />
                            <asp:BoundField ItemStyle-Width="8%" DataField="Status" HeaderText="STATUS" />
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
              <div role="tabpanel" class="tab-pane" id="Permission" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
              <div class="panel-body">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
               <div class="row">
             <div class="col-sm-2">
             </div>
             <div class="col-sm-4">    
                         <div class="form-group">
                             <label for="message" class="col-xs-4">User Name</label>
                             <div class="col-xs-8">
                               <asp:DropDownList ID="ddl_UserName" CssClass="form-control  input-sm"  
                                     runat="server" AutoPostBack="true" 
                                     onselectedindexchanged="ddl_UserName_SelectedIndexChanged">
                              </asp:DropDownList>
                             </div>
                        </div>      
                        
                        </div>  
             </div>
               <div class="row">
             <div class="col-sm-2">
             </div>
             <div class="col-sm-6">    
                         <div ID="pnl" class="labels" 
                                            style="height:450px; overflow: scroll;">
                                            <asp:GridView ID="GridRoles" runat="server" AutoGenerateColumns="False"  Width="400px"
                                                DataKeyNames="RoleId" OnRowDataBound="GridRoles_RowDataBound" CssClass="table table-striped table-bordered mediaTable activeMediaTable">
                                                <Columns>
                                                    <asp:BoundField DataField="Roles" HeaderText="Roles" />
                                                    <asp:TemplateField HeaderText="Add">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkInsert" runat="server" Checked="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Update">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkUpdate" runat="server" Checked="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkDelete" runat="server" Checked="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" Checked="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                        
                        </div>  
                <div class="col-sm-2">
                  <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" 
                                                        />
                                                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" 
                                                        Text="Update" Visible="False" />
                                                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" 
                                                        OnClientClick="return confirm('Are you sure ??');" Text="Delete" 
                                                        Visible="False"  />
                                                    <asp:Button ID="btnClear" runat="server"  
                        Text="Clear" onclick="btnClear_Click" 
                                                        />
             </div>
             </div>
             </ContentTemplate>
             </asp:UpdatePanel>
             </div>
             </div>

              </div>
              </div>
        </div>
    </div>
    </div>
</asp:Content>

