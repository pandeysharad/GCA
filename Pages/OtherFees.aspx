<%@ Page Title="Other Fees" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="OtherFees.aspx.cs" Inherits="Pages_OtherFees" %>

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
                OTHER FEES
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
                             <label for="message" class="col-xs-4" style="text-align: right;">Serial No:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtSerialNo" style="text-transform: uppercase;" CssClass="form-control  input-sm" Enabled="false" runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4">Select <%=Session["ClassLableText"]%>:</label>
                              <div class="col-xs-8">
                             <asp:DropDownList ID="ddlSelectClass" CssClass="form-control  input-sm" 
                                      runat="server" AutoPostBack="True" 
                                      onselectedindexchanged="ddlSelectClass_SelectedIndexChanged">
                             </asp:DropDownList>  
                             </div>
                         </div>             
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;">Fees Head:</label>
                              <div class="col-xs-8">
                              <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control  input-sm" AutoPostBack="true"
                                          OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                                      </asp:DropDownList>
                                      <asp:TextBox ID="txtFeesType" Visible="false" CssClass="form-control  input-sm" runat="server"
                                          style="margin-top: -30px; width: 168px;text-transform: uppercase;"></asp:TextBox>
                             </div>
                         </div>                 
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;">Fees Type:</label>
                              <div class="col-xs-8">
                                    <asp:DropDownList ID="ddlTakePayment" runat="server" CssClass="form-control  input-sm">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>One Time</asp:ListItem>
                                        <asp:ListItem>Yearly</asp:ListItem>
                                    </asp:DropDownList>
                             </div>
                         </div>
                         <div class="form-group" style="margin-top:-5px">
                             <label for="message" class="col-xs-4" style="text-align: right;">Fees:</label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtFees" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
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
                                <asp:LinkButton ID="btnDelete" CssClass="btn btn-primary" runat="server"
                                       Width="100%" Visible="false" onclick="btnDelete_Click" >
                               <span aria-hidden="true" class="glyphicon glyphicon-Delete"> Delete</span>
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
                        <asp:GridView ID="GridOtherFees" runat="server" HeaderStyle-BackColor="#66ccff" 
                                      AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                            HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                      HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                            RowStyle-Font-Bold="true" DataKeyNames="OtherFeesId" AutoGenerateSelectButton="true" 
                                      onselectedindexchanging="GridOtherFees_SelectedIndexChanging" OnPageIndexChanging="GridOtherFees_PageIndexChanging">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="10%" DataField="SerialNo" HeaderText="SNo" />
                            <asp:BoundField ItemStyle-Width="40%" DataField="FeesType" HeaderText="FEES HEAD" />
                            <asp:BoundField ItemStyle-Width="40%" DataField="PayType" HeaderText="FEES TYPE" />
                            <asp:BoundField ItemStyle-Width="10%" DataField="Fees" HeaderText="FEES" />
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

