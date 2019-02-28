<%@ Page Title="Update Section/Batch" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateSections.aspx.cs" Inherits="Pages_UpdateSections" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">

        function MessageShow(msg) {
            alert(msg);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row"  style="margin-top:10px;margin-bottom:10px">
            <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;height:35px;margin-bottom:2px">  
            <div class="col-sm-12" style="margin-left:10px">
                    <div class="form-horizontal">    
                        <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                            MANAGE <%=Session["SectionLableText"].ToString().ToUpper()%>
                        </div>
                    </div>
            </div>
            </div>
            <div class="panel-body" style="border:thin solid black;">
             <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;height:40px;margin-bottom:2px;margin-top:-16px;margin-left:-16px;margin-right:-16px">  
              <div class="col-sm-10" >
                        <div class="form-horizontal">   
                     <div class="form-group" style="margin-top:-5px">  
                     <p>&nbsp;</p>
                     <asp:UpdateProgress ID="UpdateProgresspnl" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
    <ProgressTemplate>
    <img alt="Process....." src="../img/final_loading_big.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress>                                    
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate> 
                            <div class="col-xs-4" runat="server">
                                <asp:DropDownList ID="ddlClass" runat="server" 
                                    CssClass="form-control  input-sm" AutoPostBack="True" 
                                    onselectedindexchanged="ddlClass_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div  class="col-xs-2" runat="server">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" 
                                    Text="Update" onclick="btnSave_Click" />
                                <%--<asp:Button ID="btnRefresh" CssClass="btn btn-primary" runat="server" Text="Refresh" PostBackUrl="~/Pages/UpdateSections.aspx" />--%>
                            </div>

                             <asp:GridView ID="GridStudentWiseData" 
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" DataKeyNames="AdmissionId" Width="100%" 
                             runat="server" AutoGenerateColumns="false" 
                                onrowdatabound="GridStudentWiseData_RowDataBound" >
       <%----%>
      
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
          <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
          <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
          <asp:BoundField DataField="Section" HeaderText="Section" />
          <asp:TemplateField HeaderText="Section">
               <ItemTemplate>
                <asp:DropDownList ID="ddlSection" runat="server" 
                                    CssClass="form-control  input-sm"  >
                                    <asp:ListItem>New</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                </asp:DropDownList>
               </ItemTemplate>
          </asp:TemplateField>
       </Columns>
        </asp:GridView>      
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            
        <div class="col-sm-2" >
            <div class="form-horizontal">   
                <div class="form-group" style="margin-top:-13px">            
                      
            </div>
            </div>
        </div>
        </div>
        
       </div>
    </div>
</asp:Content>

