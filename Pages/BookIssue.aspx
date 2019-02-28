<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="BookIssue.aspx.cs" Inherits="Pages_BookIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">

     function Showalert(msg) {
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
                    BOOK ISSUING INFORMATION
                </div>
            </div>
        </div>
    </div>

    <div class="panel-body" style="border:thin solid black;">
       <div id="page" style="margin:-10px">
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#BookIssueInfo" aria-controls="BookIssueInfo" role="tab" data-toggle="tab">Book Issue Info</a></li>
            <li><a href="#BookIssueList" aria-controls="BookIssueList" role="tab" data-toggle="tab">Book Issue List</a></li>
        </ul>
        <div class="tab-content">
         <div role="tabpanel" class="tab-pane active" id="BookIssueInfo" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
             <div class="panel-body">
            <div class="row">
            <div class="col-sm-6" style="margin-bottom:-10px">
            <div class="form-horizontal">
                        <div class="form-group">
                            <label for="message" class="col-xs-4">Book Issue Date:<label for="message" style="color:Red">*</label></label>
                            <div class="col-xs-8">
                            <asp:TextBox ID="dtIssueDate" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Library Card No:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-6">
                             <asp:TextBox ID="txtCardNo" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                            <div class="col-xs-2">
                                <asp:LinkButton ID="btnCardSearch" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Member Type:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:DropDownList ID="comMemberType" CssClass="form-control  input-sm" runat="server">
                             <asp:ListItem>Select Member Type</asp:ListItem>
                             <asp:ListItem>Teacher</asp:ListItem>
                             <asp:ListItem>Student</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Book Category:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:DropDownList ID="comBookCategory" CssClass="form-control  input-sm" runat="server"/>
                             </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Book Title/Name:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:DropDownList ID="comBookTitle" CssClass="form-control  input-sm" runat="server"/>
                             </div>
                        </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Available Books:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtAvailableBooks" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Total Books Issued:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtTotalBooksIssue" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                        </div> 
                        <div class="form-group">
                            <label for="message" class="col-xs-4">Balance Books:</label>
                            <div class="col-xs-8">
                            <asp:TextBox ID="txtBalanceBooks" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server"></asp:TextBox>
                            </div>
                        </div>      
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Book Return Date:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="dtReturnDate" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server"></asp:TextBox>
                             </div>
                        </div>   
                        <div class="form-group">
                             <div class="col-xs-4">
                                 <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                 <asp:Label ID="lbBookIssueId" runat="server"  Visible="false" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-4">
                    <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-4">
                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div>                
                    </div>
            </div>
            </div>
            </div>
             <div role="tabpanel" class="tab-pane" id="BookIssueList" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
             <div class="panel-body">
             <div class="row" style="margin-top:5px;">
            <div class="col-sm-12" style="margin-bottom:-30px;">
            <div class="form-horizontal">
             <div class="form-group">
                <asp:GridView ID="GridEnquiry" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                           HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                           RowStyle-Font-Bold="true">
                        <Columns>                        
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="52%"  ForeColor="Blue" Font-Bold="true" runat="server" CommandName="Select" />                               
                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField ItemStyle-Width="5%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="EnquiryDate" HeaderText="DATE" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="StudentName" HeaderText="NAME" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="ContactNo" HeaderText="CONTACT" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="Father" HeaderText="FATHER" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="FatherContact" HeaderText="PARENT'S CONTACT" />
                            <asp:BoundField ItemStyle-Width="18%" DataField="Address" HeaderText="ADDRESS" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Status" HeaderText="STATUS" />
                        </Columns>
                    </asp:GridView>
               </div>
            </div>
         </div>
        </div>
             </div>
             </div>
            </div>
            </div>
            </div>
        </div>        
    </div>
</asp:Content>
