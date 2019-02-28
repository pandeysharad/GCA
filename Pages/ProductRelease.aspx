<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductRelease.aspx.cs" Inherits="Pages_ProductRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">
     function pageLoad() {
         $("#<%= dtAllocatedDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy" }).val()
     }

     $(function () {
         $("#<%= dtAllocatedDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy" }).val()
     });

     function Showalert(msg) {
         alert(msg);
     }

  
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<meta name="viewport" content="width=device-width, initialscale=1">    
<script type="text/javascript" src="../Scripts/bootstrap.min.js"></script> 
<div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
            <div class="form-horizontal">    
                <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                    PURCHASE INFORMATION
                </div>
            </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
         
    <div id="page" style="margin:-10px">
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#ReleaseInfo" aria-controls="ReleaseInfo" role="tab" data-toggle="tab">Release Info</a></li>
            <li><a href="#ReleaseDetails" aria-controls="ReleaseDetails" role="tab" data-toggle="tab">Release Details</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="ReleaseInfo" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
            <div class="panel-body">
            <div class="row"> 
            <div class="col-sm-4">
            <div class="form-horizontal">             
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-3">Serial_No:</label>
                    <div class="col-xs-5">
                         <asp:TextBox ID="txtSerialNo" Enabled="false" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>   
            </div>
            </div>
            <div class="col-sm-4">
            <div class="form-horizontal">           
                <div class="form-group" style="margin-top:-5px">
                    <div class="col-xs-5">
                        <asp:Label ID="lbProductFlag" runat="server" Visible="false" Text="0"></asp:Label>
                        <asp:Label ID="lbIndex" runat="server" Visible="false" Text="0"></asp:Label>
                    </div>
                </div>
            </div>
            </div>
            </div>
            <div class="row">                     
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>  
            <div class="col-sm-4">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-3">Category:</label>
                    <div class="col-xs-9">
                        <asp:DropDownList ID="comProductCategory" CssClass="form-control  input-sm" AutoPostBack="true"  runat="server"></asp:DropDownList>
                    </div>
                </div>  
            </div>
            </div>
             <div class="col-sm-4">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-4">Products:</label>
                    <div class="col-xs-8">
                        <asp:DropDownList ID="comProductList" AutoPostBack="true"   CssClass="form-control  input-sm" runat="server"></asp:DropDownList>                  
                          </div>
                </div>  
            </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            <div class="row">                    
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>  
            <div class="col-sm-4">
            <div class="form-horizontal">       
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-3">Available:</label>
                    <div class="col-xs-5">
                         <asp:TextBox ID="txtAvailableStock" Enabled="false" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>  
                </div>
                </div>
            <div class="col-sm-4">
            <div class="form-horizontal">            
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-4">Releasing:</label>
                    <div class="col-xs-5">
                             <asp:TextBox ID="txtReleasingStock" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-3">
                        <asp:LinkButton ID="btnAdd" CssClass="btn btn-primary" runat="server" Width="100%">
                    <span aria-hidden="true" class="glyphicon glyphicon-plus">Add</span>
                    </asp:LinkButton>
                    </div>
                </div>  
            </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>           
            <div class="row">                
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>  
            <div class="col-sm-1">
              <div class="form-horizontal">       
                <div class="form-group" style="margin-top:-5px"> 
                </div>
              </div>
            </div>
            <div class="col-sm-7">
            <div class="form-horizontal">       
                <div class="form-group" style="margin-top:-5px">    
                    <div class="col-xs-12">
                        <div  style="height:135px;background-color:#0077b3;border:thin solid black">
                        <asp:Label ID="lbProductMSG" runat="server" style="color:White" Text="Please add some product to release...." Visible="true"></asp:Label>
                    <asp:GridView ID="GridProductList" runat="server" HeaderStyle-BackColor="#000000" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="White" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" AllowPaging="true" PageSize="20"
                    HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                    RowStyle-Font-Bold="true" Width="100%">
                <Columns>                        
                    <asp:TemplateField HeaderText="ACTION">
                    <ItemTemplate>
                    <asp:LinkButton Text="EDIT" ID="lnkSelect"  ItemStyle-Width="8%" ForeColor="Yellow" Font-Bold="true" runat="server" CommandName="Select" /> |  
                    <asp:LinkButton Text="DEL." ID="LinkButton1"  ItemStyle-Width="8%" ForeColor="Red" Font-Bold="true" runat="server" CommandName="Select" />                            
                    </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:BoundField ItemStyle-Width="30%" DataField="Category" HeaderText="CATEGORY" /> 
                    <asp:BoundField ItemStyle-Width="47%" DataField="Product" HeaderText="PRODUCT / ITEMS" /> 
                    <asp:BoundField ItemStyle-Width="10%" DataField="Qty" HeaderText="QTY" />
                </Columns>
            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            <div class="row">
            <div class="col-sm-4">
            <div class="form-horizontal">   
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Department:</label>
                              <div class="col-xs-8">
                                   <asp:DropDownList ID="comDepartment" CssClass="form-control  input-sm" AutoPostBack="true"  runat="server"></asp:DropDownList>
                             </div>
                         </div>    
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Allocated To:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtAllocatedTo" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>               
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="margin-top:-5px">Allocated Date:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="dtAllocatedDate" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>      
                         <div class="form-group" style="margin-top:-12px">
                             <label for="message" class="col-xs-4">Remarks:</label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtRemarks" TextMode="MultiLine" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>      
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>  
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-1">
                                    <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbId" runat="server" Visible="false" Text="0"></asp:Label>
                                </div>
                                <div class="col-xs-3">
                                   <asp:DropDownList ID="comDetailId" Visible="false" CssClass="form-control  input-sm" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-xs-4">     
                                 <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> <asp:Label ID="lbSaveMsg" runat="server" Text=" Save"/></span>
                                </asp:LinkButton>
                                </div>
                                <div class="col-xs-4">
                                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                                </div>
                          </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </div>
         </div>  
            </div>
            </div>
            </div>
             <div role="tabpanel" class="tab-pane" id="ReleaseDetails" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
              <div class="panel-body">
             <div class="row" style="margin-top:5px;">
            <div class="col-sm-12" style="margin-bottom:-30px;">
            <div class="form-horizontal">                                
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>   
            <div class="form-group" style="margin-top:-10px;color:White;background-color:#000000;z-index:1000;margin-bottom:-10px">
                <label for="message" class="col-xs-12" style="margin-bottom:-1px;font-family:Maiandra GD">Search records using search box.</label>
            </div>                  
             <div class="form-group">
               <asp:GridView ID="GridReleaseDtl" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                     HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true">
                        <Columns>                        
                            <asp:TemplateField HeaderText="EDIT">
                            <ItemTemplate >
                            <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="3%" ForeColor="Red"  runat="server" CommandName="Select" />
                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField ItemStyle-Width="4%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="8%" DataField="AllocatedDate" HeaderText="DATE" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Department" HeaderText="DEPARTMENT" />
                            <asp:BoundField ItemStyle-Width="20%" DataField="AllocatedTo" HeaderText="ALLOCATED TO" />
                            <asp:BoundField ItemStyle-Width="35%" DataField="Stock" HeaderText="PRODUCTS / ITMES" />
                            <asp:BoundField ItemStyle-Width="20%" DataField="Remarks" HeaderText="REMARKS" />
                        </Columns>
                         </asp:GridView>
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
    </div>
 </div>
 </div>
</asp:Content>
