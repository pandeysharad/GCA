<%@ Page Title="Create Bus Transport" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateBusTransport.aspx.cs" Inherits="Pages_CreateBusTransport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">

    function MessageShow(msg) {
        alert(msg);
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
      <div class="col-sm-12">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-top:2px"> 
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                    TRANSPORT
                    </div>
              </div>
      </div>
      </div>
      </div>
      <div class="row">
          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
              <ContentTemplate>
                  <div class="panel-body" style="border: thin solid black; margin-left: 15px; margin-right: 15px;
                      margin-top: 2px">
                      <div class="col-sm-12">
                          <div class="form-horizontal">
                              <div class="form-group">
                                  <label for="message" class="col-xs-3" style="margin-left: 150px;">
                                      From:<span for="message" style="color: Red">*</span></label>
                                  <div class="col-xs-4">
                                      <asp:TextBox ID="txtFrom" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                  </div>
                              </div>
                              <div class="form-group">
                                  <label for="message" class="col-xs-3" style="margin-left: 150px;">
                                      To:<span for="message" style="color: Red">*</span></label>
                                  <div class="col-xs-4">
                                      <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control  input-sm" AutoPostBack="true"
                                          OnSelectedIndexChanged="ddlTo_SelectedIndexChanged">
                                      </asp:DropDownList>
                                      <asp:TextBox ID="txtTo" Visible="false" CssClass="form-control  input-sm" runat="server"
                                          Style="margin-top: -30px; width: 300px;"></asp:TextBox>
                                  </div>
                              </div>
                              <div class="form-group">
                                  <div class="col-xs-6" style="margin-left: 150px;">
                                      <asp:CheckBox ID="ChkKM" runat="server" Text="Get Fees Kilo Meter Wise..." OnCheckedChanged="ChkKM_CheckedChanged"
                                          AutoPostBack="True" />
                                  </div>
                              </div>
                              <div class="form-group" runat="server" id="KM" visible="false">
                                  <label for="message" class="col-xs-3" style="margin-left: 150px;">
                                      Kilo Meter & Rupees Per Kilo Meter<span for="message" style="color: Red">*</span></label>
                                  <div class="col-xs-2">
                                      <asp:TextBox ID="txtKM" CssClass="form-control  input-sm" runat="server" placeholder="K.M"
                                          AutoPostBack="True" OnTextChanged="txtKM_TextChanged"></asp:TextBox>
                                  </div>
                                  <div class="col-xs-2">
                                      <asp:TextBox ID="txtRPKM" CssClass="form-control  input-sm" runat="server" placeholder="Rs. P.K.M"
                                          AutoPostBack="True" OnTextChanged="txtRPKM_TextChanged"></asp:TextBox>
                                  </div>
                              </div>
                              <div class="form-group">
                                  <label for="message" class="col-xs-3" style="margin-left: 150px;">
                                      Total Fees:<span for="message" style="color: Red">*</span></label>
                                  <div class="col-xs-4">
                                      <asp:TextBox ID="txtTotalFees" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                  </div>
                              </div>
                              <div class="form-group">
                                  <div class="col-xs-3" style="margin-left: 150px;">
                                      <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                      <asp:Label ID="lbId"  runat="server" Visible="false" Text="0"></asp:Label>
                                  </div>
                                  <div class="col-xs-2">
                                      <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"
                                          OnClick="btnSave_Click"> <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk">Save</span> </asp:LinkButton>
                                  </div>
                                  <div class="col-xs-2">
                                      <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%"
                                          OnClick="btnRefresh_Click"> <span aria-hidden="true" class="glyphicon glyphicon-refresh">Refresh</span> </asp:LinkButton>
                                  </div>
                              </div>
                              <div class="form-group">
                                  <div class="row">
                                      <div class="col-sm-12">
                                          <div class="col-xs-2">
                                          </div>
                                          <div class="col-xs-8">
                                              <asp:GridView ID="GridKM" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false"
                                                  Width="100%" HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"
                                                  HeaderStyle-Font-Bold="true" RowStyle-Font-Size="Small" RowStyle-Font-Names="Maiandra GD"
                                                  RowStyle-Font-Bold="true" DataKeyNames="TransportId" AutoGenerateSelectButton="true"
                                                  OnSelectedIndexChanging="GridKM_SelectedIndexChanging">
                                                  <Columns>
                                                      <asp:BoundField ItemStyle-Width="25%" DataField="From" HeaderText="FROM" />
                                                      <asp:BoundField ItemStyle-Width="30%" DataField="To" HeaderText="TO" />
                                                      <asp:BoundField ItemStyle-Width="15%" DataField="KM" HeaderText="KILO-Meter" />
                                                      <asp:BoundField ItemStyle-Width="15%" DataField="RPKM" HeaderText="RS.-PER-KM" />
                                                      <asp:BoundField ItemStyle-Width="15%" DataField="TotalFees" HeaderText="FEES" />
                                                  </Columns>
                                              </asp:GridView>
                                          </div>
                                          <div class="col-xs-2">
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </ContentTemplate>
          </asp:UpdatePanel>
                    </div>
</asp:Content>

