<%@ Page Title="All Repport" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Pages_Reports" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleSheet.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upmain" runat="server">
   <ContentTemplate>
   <div style="text-align:left;">
    <cc1:Accordion runat="server"  ID="Accordian" 
                         HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                         ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                         TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                         <HeaderTemplate >
                          REPORT - ENQUIRY
                         </HeaderTemplate>
                         <Panes>                        
                          <cc1:AccordionPane ID="AcPaymentReceipt" runat="server">
                          <Header>REPORTS</Header>
                            <Content>
                                <table  align="left" width="100%">
                                    <tr>
                                        <td style="vertical-align:top;text-align:left; width:40%;" >
                                        <fieldset>
                                          <legend>Search Options</legend>
                                           <table cellspacing="13px">
                                                <tr>
                                                    <td class="labels">
                                                       <b>Class Name:</b>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlClassName"  Width="180px" runat="server" >
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td style="text-align: left">
                                                         <asp:CheckBox ID="ChkToday" OnCheckedChanged="ChkToday_CheckedChanged" AutoPostBack="true" Text="TODAY" runat="server" />
                                                    </td>
                                                </tr>
                                                   <tr>
                                                <td colspan="2" style="height:10px;">
                                                       
                                                    </td>
                                               </tr>
                                                    <td class="labels">
                                                        <b>From Date:</b>
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFrom"  Width="180px" runat="server" AutoPostBack="true" OnTextChanged="txtFrom_OnTextChanged"></asp:TextBox>
                                                                      <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtFrom" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                 
                                                </tr>
                                                 <tr>
                                                <td colspan="2" style="height:10px;">
                                                       
                                                    </td>
                                               </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <b>To Date:</b>
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtTo" Width="180px" runat="server" AutoPostBack="true" OnTextChanged="txtTo_OnTextChanged"></asp:TextBox>
                                                                      <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtTo" CssClass="red" PopupPosition="TopRight">
                                                                </cc1:CalendarExtender>
                                                                </td>
                                                            </tr> 
                                                        </table>
                                                    </td>                                                  
                                                </tr>
                                                  <tr>
                                                <td style="height:10px;">
                                                       
                                                    </td>
                                               </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
                                                        <asp:Button ID="Button2" runat="server" Text="Clear"  OnClick="Button2_Click"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                            
                                        </td>
                                        
                                         <td style="vertical-align:top;text-align:left; width:55%;" >
                                          <table cellpadding="10px"  cellspacing="10px" width="100%" align="center">
                                            <tr>
                                             <td>
                                                 <fieldset>
                                                  <legend>List of Reports</legend>
                                                 
                                             <asp:RadioButtonList  ID="RadReportType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadReportType_OnSelectedIndexChanged">
                                                    <asp:ListItem>Installment Due Sheet</asp:ListItem>
                                                    <asp:ListItem>Monthly Due Sheet</asp:ListItem>
                                                     <asp:ListItem>All Payment Received/Due Sheet</asp:ListItem>
                                                     <asp:ListItem>School Wise Collection</asp:ListItem>
                                                     <asp:ListItem>Class Wise Collection</asp:ListItem>
                                                 </asp:RadioButtonList>
                                               
                                                 </fieldset>
                                                 
                                             </td>
                                            </tr>
                                          </table>
                                        </td>
                                    </tr>
                                </table>
                             
                            </Content>
                         </cc1:AccordionPane>
                         
                         </Panes>
                         </cc1:Accordion>
                       
    </div>
    
   </ContentTemplate>
  </asp:UpdatePanel>
    
</asp:Content>

