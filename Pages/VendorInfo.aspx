<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="VendorInfo.aspx.cs" Inherits="Pages_VendorInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
 <script language="javascript" type="text/javascript">
     function Showalert(msg) {
         alert(msg);
     }

     function VendorValidate() {
         if (document.getElementById("<%=txtSerialNo.ClientID%>").value == "") {
             alert("Please enter serial no");
             document.getElementById("<%=txtSerialNo.ClientID%>").focus();
             return false;
         }
         if (document.getElementById("<%=txtVendorName.ClientID%>").value == "") {
             alert("Please enter category name");
             document.getElementById("<%=txtVendorName.ClientID%>").focus();
             return false;
         }
         return true;
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
                       VENDOR DETAILS
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
                            <asp:CheckBox ID="chkVendorNo" Text="Change" runat="server" />
                            </div>
                         </div>             
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Vendor Name:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtVendorName" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>              
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Contact:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtVendorContact" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>                    
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Address:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtAddress" TextMode="MultiLine" style="text-transform: uppercase;" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                             </div>
                         </div>                 
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>  
                         <div class="form-group" style="margin-top:-5px">
                                <div class="col-xs-4">
                                    <asp:Label ID="lbVendorFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:Label ID="lbVendorId" runat="server" Visible="false" Text="0"></asp:Label>
                                </div>
                                <div class="col-xs-4">     
                                 <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"  >
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
                        <div class="form-group">
                         <asp:GridView ID="GridVendor" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                      HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true" >
                                    <Columns>                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton Text="Edit" ID="lnkSelect" ItemStyle-Width="5%" ForeColor="Red" runat="server" CommandName="Select" />
                                        </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField ItemStyle-Width="15%" DataField="SerialNo" HeaderText="SNo" />
                                        <asp:BoundField ItemStyle-Width="30%" DataField="VendorName" HeaderText="VENDOR NAME" />
                                        <asp:BoundField ItemStyle-Width="20%" DataField="ContactNo" HeaderText="CONTACT" />
                                        <asp:BoundField ItemStyle-Width="30%" DataField="Address" HeaderText="ADDRESS" />
                                    </Columns>
                             </asp:GridView>
                    </div>
            </div>
        </div>     
          
        </div>
    </div>
</asp:Content>
