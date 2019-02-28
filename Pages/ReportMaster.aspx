<%@ Page Title="Report Master" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ReportMaster.aspx.cs" Inherits="Pages_ReportMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table Class="table table-striped table-bordered table-hover dataTable no-footer" style="width:50%; padding:20px" align="center">
    <tr>
        <td colspan="2">
            <asp:RadioButtonList ID="rblReport" runat="server" RepeatDirection="Vertical">
                <asp:ListItem Value="1" >Collection Report Class Wise</asp:ListItem>
                <asp:ListItem Value="2" >Collection Report Recipt Wise</asp:ListItem>
                <asp:ListItem Value="3" Selected="True">Collection Report Recipt Wise (Only Coll. Column)</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>From Date : </td>
        <td>
                    <asp:TextBox ID="txtFromDate" CssClass="form-control  input-sm"  
                        runat="server" ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" CssClass="black" 
                                                                  Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                                  </cc1:CalendarExtender> </td>
    </tr>
    <tr>
        <td>From Date : </td>
        <td>
                    <asp:TextBox ID="txtToDate" CssClass="form-control  input-sm"  AutoCompleteType="None"
                        runat="server" ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" CssClass="black"
                                                                  Format="dd/MM/yyyy" TargetControlID="txtToDate">
                                  </cc1:CalendarExtender> </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" 
                Text="Search" onclick="btnSearch_Click"/>
                                   
        </td>
    </tr>
</table>
</asp:Content>

