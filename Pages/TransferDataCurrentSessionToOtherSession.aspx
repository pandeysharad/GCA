<%@ Page Title="Student Transfer" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="TransferDataCurrentSessionToOtherSession.aspx.cs" Inherits="Pages_TransferDataCurrentSessionToOtherSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
        <div class="form-horizontal">    
            <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
               TRANSFER DATA
            </div>
        </div>
      </div>
      </div>
      <div class="panel-body" style="border:thin solid black;">  
       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
          <ContentTemplate>
         <div class="col-sm-3">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-2">From:</label>
                    <div class="col-xs-8">
                    <asp:DropDownList ID="ddlFromSession" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True">
                    </asp:DropDownList>  
                    </div>
                </div>
            </div>
        </div>
         <div class="col-sm-3" style="margin-left: -51px;">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-2">To:</label>
                    <div class="col-xs-8">
                    <asp:DropDownList ID="ddlTo" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True">
                    </asp:DropDownList>  
                    </div>
                </div>
            </div>
        </div>
         <div class="col-sm-3" style="margin-left: -51px;">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-6">Transfer Type:</label>
                    <div class="col-xs-6">
                    <asp:DropDownList ID="ddlTansferType" CssClass="form-control  input-sm" 
                            runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTansferType_OnSelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Class</asp:ListItem>
                            <asp:ListItem>Student</asp:ListItem>
                    </asp:DropDownList>  
                    </div>
                </div>
            </div>
        </div>
         <div class="col-sm-3" id="ClassId" runat="server" visible="false">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-2">Class:</label>
                    <div class="col-xs-8">
                    <asp:DropDownList ID="ddlClass" CssClass="form-control  input-sm" OnSelectedIndexChanged="ddlClass_OnSelectedIndexChanged"
                            runat="server" AutoPostBack="True">
                    </asp:DropDownList>  
                    </div>
                </div>
            </div>
        </div>
         <div class="col-sm-1">
            <div class="form-horizontal"> 
                <div class="form-group" style="margin-top:-5px">
                    <asp:LinkButton ID="btnTransfer" CssClass="btn btn-primary" runat="server" 
                               style="height:30px;" Width="100%" onclick="btnTransfer_Click" OnClientClick="return confirm('Are you sure??');" > Transfer
                </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 5px;">
        <div class="col-sm-12" style="margin-bottom: -30px;">
        <div class="form-horizontal">
        </div>
        <asp:GridView ID="GridStudentWiseData" 
        CssClass="table table-striped table-bordered table-hover dataTable no-footer" DataKeyNames="AdmissionId" Width="100%" 
        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
        <PagerStyle CssClass="PagerStyle" />        
       <Columns> 
            <asp:TemplateField HeaderText="" Visible="false">
               <ItemTemplate>
                   <asp:TextBox ID="txtAdmissionId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"AdmissionId") %>'></asp:TextBox>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="SN.">
               <ItemTemplate>
               <%= ++SrNo%>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="AdmissionNo" HeaderText="Admission No." />
          <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
          <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
          <asp:BoundField DataField="R1" HeaderText="Status" />
          <asp:TemplateField HeaderText="Status">
               <ItemTemplate>
                <asp:DropDownList ID="ddlStatus" runat="server" 
                    CssClass="form-control  input-sm"  >
                    <asp:ListItem>SELECT</asp:ListItem>
                    <asp:ListItem>ACTIVE</asp:ListItem>
                    <asp:ListItem>ACTIVE RTE</asp:ListItem>
                    <asp:ListItem>INACTIVE</asp:ListItem>
                    <asp:ListItem>TC ISSUED</asp:ListItem>
                </asp:DropDownList>
               </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Exam Status">
               <ItemTemplate>
                <asp:DropDownList ID="ddlExamStatus" runat="server" 
                    CssClass="form-control  input-sm">
                    <asp:ListItem>PASS</asp:ListItem>
                    <asp:ListItem>FAIL</asp:ListItem>
                </asp:DropDownList>
               </ItemTemplate>
          </asp:TemplateField>
       </Columns>
       <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
        </div>
        </div>
         </ContentTemplate>
         </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

