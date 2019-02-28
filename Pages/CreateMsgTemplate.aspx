<%@ Page Title="Create Message Template" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateMsgTemplate.aspx.cs" Inherits="Pages_CreateMsgTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">

    function MessageShow(msg) {
        alert(msg);
    }
    function ismaxlength(objTxtCtrl, nLength) {
        if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
            objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

        if (document.all)
            document.getElementById('<%= lblCaption.ClientID %>').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
        else
            document.getElementById('<%= lblCaption.ClientID %>').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

        }
//    function ismaxlength(objTxtCtrl, nLength) {
//        console.log("Hello world!");
//        var ddlMsgType = document.getElementById("ContentPlaceHolder1_ddlMsgType").value;
//        if (ddlMsgType == 'English') {
//            nLength = 286;
//        }
//        else if (ddlMsgType == 'English') {
//            nLength = 105;
//        }
//        //console.log(document.getElementById("txtMsg").value);
//        if (objTxtCtrl.getAttribute && objTxtCtrl.value.length > nLength)
//            objTxtCtrl.value = objTxtCtrl.value.substring(0, nLength)

//        if (document.all)
//            document.getElementById('<%= lblCaption.ClientID %>').innerText = objTxtCtrl.value.length + ' Out Of ' + nLength;
//        else
//            document.getElementById('<%= lblCaption.ClientID %>').textContent = objTxtCtrl.value.length + ' Out Of ' + nLength;

//    }
    </script>
    <style type="text/css">
    .GridHeaderStyle
    {
        text-align:center !important;
    }
    th
    {
         text-align:center !important;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
      <div class="col-sm-12">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-top:2px"> 
               <div class="form-horizontal">    
                    <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                       CREATE TEMPLATE
                    </div>
              </div>
      </div>
      </div>
      </div>
      <div class="row">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate> 
     <div class="panel-body" style="border:thin solid black; margin-left:15px;margin-right:15px;margin-top:2px">
   <div class="col-sm-12" >
            <div class="form-horizontal"> 
                         <div class="form-group"> 
                             <label for="message" class="col-xs-3" style="margin-left:150px;">Message Head:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                             <asp:TextBox ID="txtMsgHeads" CssClass="form-control  input-sm"  runat="server"></asp:TextBox>
                             </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-3"  style="margin-left:150px;">Message:<span for="message" style="color:Red">*</span></label>
                              <div class="col-xs-4">
                             <asp:TextBox ID="txtMsg" CssClass="form-control  input-sm"  runat="server" 
                                      Height="135px"  onkeyup="return ismaxlength(this,286)" TextMode="MultiLine"></asp:TextBox>
                             </div>
                         </div>
                             <div class="form-group" style="margin-top: -12px;">
                             <label for="message" class="col-xs-3"  style="margin-left:150px;"></label>
                              <div class="col-xs-4">
                                  <asp:Label ID="lblCaption" runat="server" Font-Bold="true"></asp:Label>
                             </div>
                         </div>
                          <div class="form-group">
                             <div class="col-xs-3"  style="margin-left:150px;">
                             </div>
                             <div class="col-xs-2">
                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                     Width="100%" onclick="btnSave_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-2">
                          <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%" 
                                       onclick="btnRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                             </div>
                   </div>  
                        <div class="form-group"> 
                        <div class="row">
                          <div class="col-sm-12" style="margin-left:150px;">
                             <div class="col-xs-8">
                              <asp:GridView ID="GridMsgTemplate" runat="server" HeaderStyle-BackColor="#66ccff" 
                                     AutoGenerateColumns="false" Width="100%"
                                HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  
                                     HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
                                RowStyle-Font-Bold="true" AutoGenerateSelectButton="true" DataKeyNames="MagTemplateId"
                                     AllowPaging="True" 
                                     onselectedindexchanging="GridMsgTemplate_SelectedIndexChanging">
                                    <Columns> 
                                      
                                        <asp:BoundField ItemStyle-Width="30%" DataField="MsgHead" 
                                            HeaderText="MSG HEAD" >
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="70%" DataField="Msg" HeaderText="MESSAGE" >
                                        <ItemStyle Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BackColor="#66CCFF" Font-Bold="True" Font-Names="Maiandra GD" 
                                        Font-Size="Small" />
                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle Font-Bold="True" Font-Names="Maiandra GD" Font-Size="Small" />
                             </asp:GridView>
                             </div>
                             <div class="col-xs-2"></div>
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


