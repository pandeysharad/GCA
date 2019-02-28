<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductPurchase.aspx.cs" Inherits="Pages_ProductPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">
     function pageLoad() {
         $("#<%= dtPurchaseDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy" }).val()
     }

     $(function () {
         $("#<%= dtPurchaseDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy" }).val()
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
            <li class="active"><a href="#PurchaseInfo" aria-controls="PurchaseInfo" role="tab" data-toggle="tab">Purchase Info</a></li>
            <li><a href="#PurchaseDetails" aria-controls="PurchaseDetails" role="tab" data-toggle="tab">Purchase Details</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="PurchaseInfo" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
            <div class="panel-body">
                <div class="row">
             <div class="col-sm-6">
            <div class="form-horizontal">   
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Serial No:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtSerialNo" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>    
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Purchase Date:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="dtPurchaseDate" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>               
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Bill No:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtBillNo" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>      
                         <div class="form-group" style="margin-top:10px">
                             <label for="message" class="col-xs-4">Vendor Name:</label>
                             <div class="col-xs-8">
                                   <asp:DropDownList ID="comVendorName" CssClass="form-control  input-sm" AutoPostBack="true"  runat="server"></asp:DropDownList>
                             </div>
                         </div>         
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Product Category:</label>
                              <div class="col-xs-8">
                                   <asp:DropDownList ID="comCategory" CssClass="form-control  input-sm" AutoPostBack="true"   runat="server"></asp:DropDownList>
                             </div>
                         </div>               
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>  
                         <div class="form-group">
                          <label for="message" class="col-xs-4"></label>
                              <div class="col-xs-8">
                                  <asp:GridView ID="GridProducts" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                      HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                                      RowStyle-Font-Bold="true">
                                    <Columns>                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton Text="Del" ID="lnkSelect" ItemStyle-Width="5%"  ForeColor="Red" runat="server" CommandName="Select" />
                                        </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="PRODUCT NAME" ItemStyle-Width="75%">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtProductName" Enabled="false" Width="100%" runat="server" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="QTY" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" Width="100%" runat="server" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                             </asp:GridView>
                             </div>                         
                         </div>
                         </ContentTemplate>       
                         </asp:UpdatePanel>          
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Amount:</label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtAmount" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>                 
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>  
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-1">
                                    <asp:Label ID="lbPurchaseFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbPurchaseId" runat="server" Visible="false" Text="0"></asp:Label>
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
             <div role="tabpanel" class="tab-pane" id="PurchaseDetails" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
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
               <asp:GridView ID="GridPurchaseDtl" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                     HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true">
                        <Columns>                        
                            <asp:TemplateField HeaderText="EDIT">
                            <ItemTemplate >
                            <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%"  ForeColor="Red"  runat="server" CommandName="Select" />
                            </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:BoundField ItemStyle-Width="5%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="PurchaseDate" HeaderText="DATE" />
                            <asp:BoundField ItemStyle-Width="8%" DataField="BillNo" HeaderText="BILL-No" />
                            <asp:BoundField ItemStyle-Width="12%" DataField="VendorName" HeaderText="VENDOR" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="CategoryName" HeaderText="PRODUCT CATEGORY" />
                            <asp:BoundField ItemStyle-Width="35%" DataField="Products" HeaderText="PRODUCTS" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Amount" HeaderText="AMOUNT" />
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
