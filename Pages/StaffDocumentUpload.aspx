<%@ Page Title="Staff Document Upload" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="StaffDocumentUpload.aspx.cs" Inherits="Pages_StaffDocumentUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">

        function MessageShow(msg) {
            alert(msg);
        }

    </script>
    
  
    <style type="text/css">
       
        .table tr:nth-child(even)
        {
            background:  #CC9999;
        }
        .table tr:nth-child(odd)
        {
            background:  #9999CC;
        }
        
        .table tr:hover
        {
            background: silver;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row" runat="server" id="StudentDoc">
       <div class="col-sm-4">
        <div class="form-horizontal">
            <div class="form-group">
                    <label for="message" class="col-xs-12" style="background-color:#00BFFF;">STAFF'S DOCUMENTS</label>
            </div>  
            <div class="form-group">
                    <label for="message" class="col-xs-4" style="margin-top:-5px">Document Type<label for="message" style="color:Red">*</label></label>
                    <div class="col-xs-8">
                    <asp:TextBox ID="txtDocumentName"  style="text-transform: uppercase;"  CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                    </div>
            </div>   
            <div class="form-group" style="margin-top:-5px">
                    <label for="message" class="col-xs-4">Staff's Document<label for="message" style="color:Red">*</label></label>
                    <div class="col-xs-8">
                    <asp:FileUpload ID="DocUpload" class="form-control  input-sm" runat="server"></asp:FileUpload>
                    </div>
            </div>   
            <div class="form-group" style="margin-top:-15px">
                    <div class="col-xs-4" > 
                    <div class="form-group" >                   
                        <div class="col-xs-12">
                        <asp:Button ID="btnDocUpload" CssClass="form-control  input-sm" Text="Doc Upload" 
                                runat="server" onclick="btnDocUpload_Click"></asp:Button>
                        </div>  
                        </div>    
                    <div class="form-group" >                      
                        <div class="col-xs-12">
                        <asp:Button ID="btnDocClear" CssClass="form-control  input-sm" Text="Clear Doc" runat="server"></asp:Button>
                        </div>
                        </div>                            
                    <div class="form-group" >                      
                        <div class="col-xs-12">
                    <asp:Label ID="lbDocFlag" runat="server" Visible="false" Text="0"></asp:Label>
                    <asp:Label ID="lbDocId" runat="server" Visible="false" Text="0"></asp:Label>
                        </div>
                    </div>
                        
                    </div>     
                        <div class="col-xs-8">
                        <asp:Image ID="ImgDoc" Height="135px" Width="100%" BorderWidth="1px" runat="server"></asp:Image>
                        </div>
                    </div>      
            <div class="form-group">
                    <label for="message" class="col-xs-4" ></label>
                    <div class="col-xs-4">
                    <asp:LinkButton ID="btnDocmSave" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnDocmSave_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                    </div>
                    <div class="col-xs-4">
                    <asp:LinkButton ID="btnDocmRefresh" CssClass="btn btn-primary" runat="server" 
                            Width="100%" onclick="btnDocmRefresh_Click">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                    </div>
            </div>
            </div>
            </div>
            <div class="col-sm-8">
            <div class="form-horizontal"> 
            <div class="form-group">
            <asp:GridView  ID="GridStudentDocs" runat="server" AllowPaging="True" CssClass="table"
                    AutoGenerateColumns="False" CellPadding="3" 
                    ForeColor="#333333" PageSize="5" 
                Width="100%" HeaderStyle-Font-Size="Small" 
                HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  
                    RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD" 
                    RowStyle-Font-Bold="true" AutoGenerateSelectButton="True" DataKeyNames="DocId" 
                    onselectedindexchanging="GridStudentDocs_SelectedIndexChanging" 
                    onpageindexchanging="GridStudentDocs_PageIndexChanging"   >
                <AlternatingRowStyle BackColor="White"/>
                <Columns>   
                    <asp:TemplateField HeaderText="SNo">
                       <ItemTemplate>
                        <%=SrNo++ %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DocName" HeaderText="DOCUMENT TYPE/NAME" SortExpression="DocType">
                        <ItemStyle Width="60%"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField>
                        <ItemTemplate>
                         <asp:LinkButton ID="lblDoc" CssClass="btn btn-danger" runat="server" Width="100%" 
                                OnClick="Delete_click" OnClientClick="return confirm('Are you sure ??');"  
                                CommandArgument='<%# Eval("DocId") %>' ToolTip="Delete">
                                <span aria-hidden="true" class="fa fa-trash-o fa-lg"> Delete</span>
                          </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="27px"
                                ImageUrl="~/images/images.jpg" Width="29px" CommandArgument='<%# Eval("DocType") %>'
                                OnClick="DownloadFile" ImageAlign="AbsMiddle" ToolTip="Download" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataAlternateTextField="DocType" DataImageUrlField="DocType" HeaderText="DOCUMENT IMAGE">
                        <ItemStyle Width="20%"></ItemStyle>
                        <ControlStyle Height="120px" Width="100%" />
                    </asp:ImageField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
            </div>
            </div>
            </div>
             </div>
</asp:Content>