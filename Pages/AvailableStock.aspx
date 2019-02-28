<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AvailableStock.aspx.cs" Inherits="AvailableStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       AVAILABLE STOCK
                    </div>
              </div>
      </div>
      </div>

    <div class="panel-body" style="border:thin solid black;">
    <div class="row" style="margin-top:5px;">
            <div class="col-sm-12" style="margin-bottom:-30px;">
            <div class="form-horizontal">     
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>   
            <div class="form-group" style="margin-top:-10px;color:White;background-color:#000000;z-index:1000;margin-bottom:-10px">
                <label for="message" class="col-xs-12" style="margin-bottom:-1px;font-family:Maiandra GD">Search records using below dropdown box.</label>
            </div> 
                             
            <div class="form-group"  style="margin-top:20px;margin-bottom:8px">
                <label for="message" class="col-xs-1"  style="text-align:right">Category:</label>
                <div class="col-xs-3">
                <asp:DropDownList ID="comSearchBy" CssClass="form-control  input-sm" runat="server"> </asp:DropDownList>
                </div>
                  <div class="col-xs-2">
                        <asp:Button ID="btnExport" runat="server" Visible="false" Text="Export To Excel" CssClass="form-control  input-sm" />
                  </div>
                 </div>
                 
               </ContentTemplate>
               </asp:UpdatePanel> 
             <div class="form-group">
                    <asp:GridView ID="GridAvailableStock" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" Width="100%"
                           HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                           RowStyle-Font-Bold="true">
                        <Columns> 
                            <asp:BoundField ItemStyle-Width="30%" DataField="Category" HeaderText="CATEGORY" HeaderStyle-Width="5%"/>
                            <asp:BoundField ItemStyle-Width="50%" DataField="Product" HeaderText="PRODUCT" />
                            <asp:BoundField ItemStyle-Width="20%" DataField="Qty" HeaderText="QUANTITY" />
                        </Columns>
                    </asp:GridView>
               </div>      
            <div class="form-group">   
            <div class="col-xs-12" style="text-align:center">          
                <asp:Label ID="lbTotalRow" Text="0" runat="server"></asp:Label> 
            </div>
            </div>    
            </div>
         </div>
        </div>
    </div>
 </div>
</asp:Content>
