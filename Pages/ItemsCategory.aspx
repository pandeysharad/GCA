<%@ Page Title="Items Category" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ItemsCategory.aspx.cs" Inherits="Pages_ItemsCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">
     function Showalert(msg) {
         alert(msg);
     }

     function CategoryValidate() {
         if (document.getElementById("<%=txtSerialNo.ClientID%>").value == "") {
             alert("Please enter serial no");
             document.getElementById("<%=txtSerialNo.ClientID%>").focus();
             return false;
         }
         if (document.getElementById("<%=txtCategoryName.ClientID%>").value == "") {
             alert("Please enter category name");
             document.getElementById("<%=txtCategoryName.ClientID%>").focus();
             return false;
         }
         return true;
     }

     function productValidation() {
         if (document.getElementById("<%=txtProductSerialNo.ClientID%>").value == "") {
             alert("Please enter serial no");
             document.getElementById("<%=txtProductSerialNo.ClientID%>").focus();
             return false;
         }
         if (document.getElementById("<%=comCategory.ClientID%>").value == "Select product category") {
             alert("Please select product category");
             document.getElementById("<%=comCategory.ClientID%>").focus();
             return false;
         }
         if (document.getElementById("<%=txtProductName.ClientID%>").value == "") {
             alert("Please enter product name");
             document.getElementById("<%=txtProductName.ClientID%>").focus();
             return false;
         }
         return true;
     }
     function CategoryNoEdit() {
         var a = document.getElementById("<%=chkProductCategoryNo.ClientID%>");
         var serialno = document.getElementById("<%=txtSerialNo.ClientID%>");
         if (a.checked) {
             serialno.disabled = false;
             serialno.focus();
         }
         else {
             serialno.disabled = true;
         }
     }
     function ProductNoEdit() {
         var a = document.getElementById("<%=chkProductSerialNo.ClientID%>");
         var serialno = document.getElementById("<%=txtProductSerialNo.ClientID%>");
         if (a.checked) {
             serialno.disabled = false;
             serialno.focus();
         }
         else {
             serialno.disabled = true;
         }
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
                       PRODUCT CATEGORY & NAME 
                    </div>
              </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
             <div class="col-sm-6" style="background-color:#b3daff;margin-left:-5px">
            <div class="form-horizontal">  
                         <div class="form-group" style="margin-top:-10px;color:White;text-align:center;background-color:#000000">
                             <label for="message" class="col-xs-12" style="margin-bottom:-1px;font-family:Maiandra GD">PRODUCT CATEGORIES</label>
                             </div> 
                         <div class="form-group" style="margin-top:10px">
                             <label for="message" class="col-xs-4">Serial No:</label>
                             <div class="col-xs-4">
                                    <asp:TextBox ID="txtSerialNo" Enabled="false"  style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                            <div class="col-xs-4">
                            <asp:CheckBox ID="chkProductCategoryNo" Text="Change" onClick="CategoryNoEdit()" runat="server" />
                            </div>
                         </div>             
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Product Category:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtCategoryName" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>                     
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>  
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-4">
                                    <asp:Label ID="lbCategoryFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbCategoryId" runat="server" Visible="false" Text="0"></asp:Label>
                                </div>
                                <div class="col-xs-4">     
                                 <asp:LinkButton ID="btnCategorySave" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> <asp:Label ID="lbCategorySaveMsg" runat="server" Text=" Save"/></span>
                                </asp:LinkButton>
                                </div>
                                <div class="col-xs-4">
                                    <asp:LinkButton ID="btnCategoryRefresh" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                                </div>
                          </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                         <asp:GridView ID="GridProductCategory" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                      HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true" >
                                    <Columns>                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%" ForeColor="Red" runat="server" CommandName="Select" />
                                        </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField ItemStyle-Width="20%" DataField="SerialNo" HeaderText="SNo" />
                                        <asp:BoundField ItemStyle-Width="75%" DataField="CategoryName" HeaderText="PRODUCT CATEGORY" />
                                    </Columns>
                       </asp:GridView>
                    </div>
            </div>
        </div>
        <div class="col-sm-6"  style="background-color:#b3daff;margin-left:5px">
            <div class="form-horizontal">  
                         <div class="form-group" style="margin-top:-10px;color:White;text-align:center;background-color:#000000">
                             <label for="message" class="col-xs-12" style="margin-bottom:-1px;font-family:Maiandra GD">PRODUCT NAME</label>
                             </div>   
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Serical No:</label>
                             <div class="col-xs-4">
                                    <asp:TextBox ID="txtProductSerialNo" Enabled="false" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                            <div class="col-xs-4">
                                    <asp:CheckBox ID="chkProductSerialNo" Text="Change" onClick="ProductNoEdit()" runat="server" />
                            </div>
                         </div>                
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Category Name:</label>
                              <div class="col-xs-8">
                                   <asp:DropDownList ID="comCategory" CssClass="form-control  input-sm" AutoPostBack="true"  runat="server"></asp:DropDownList>
                             </div>
                         </div>           
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Product Name:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtProductName" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>                     
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>  
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-4">
                                    <asp:Label ID="lbProductFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbProductId" runat="server" Visible="false" Text="0"></asp:Label>
                                </div>
                                <div class="col-xs-4">       
                                 <asp:LinkButton ID="btnProductSave" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"><asp:Label ID="lbProductSaveMsg" runat="server" Text=" Save"/></span>
                                </asp:LinkButton>
                                </div>
                                <div class="col-xs-4">
                                    <asp:LinkButton ID="btnProductClear" CssClass="btn btn-primary" runat="server" Width="100%">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                                </div>
                        </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                         <asp:GridView ID="GridProducts" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                     HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true"  >
                                    <Columns>                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%"  ForeColor="Red"  runat="server" CommandName="Select" />
                                        </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField ItemStyle-Width="10%" DataField="SerialNo" HeaderText="SNo" />
                                        <asp:BoundField ItemStyle-Width="35%" DataField="CategoryName" HeaderText="CATEGORY" />
                                        <asp:BoundField ItemStyle-Width="50%" DataField="ProductName" HeaderText="PRODUCT NAME" />
                                    </Columns>
                         </asp:GridView>
                    </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
