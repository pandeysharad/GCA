<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="BookInfo.aspx.cs" Inherits="Pages_BookInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="shortcut icon" type="image/x-icon" href="../Fevicon/educatorlogo.png" />
<script language="javascript" type="text/javascript">

    function print() {
        var divContents = document.getElementById("divPrint").innerHTML;
        var printWindow = window.open('', '', 'height=700px,width=1100px');
        printWindow.document.write('<html><head><title>STUDENT DETAILS</title>');
        printWindow.document.write('</head><body>');
        printWindow.document.write(divContents);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }

    function Showalert(msg) {
        alert(msg);
    }

    function UpdatePanel1() {
        __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
    }

    function UpdatePanel2() {
        __doPostBack("<%=UpdatePanel2.UniqueID %>", "");
    }

    function UpdatePanel3() {
        __doPostBack("<%=UpdatePanel3.UniqueID %>", "");
    }

    function divvisible() {
        var SearchBy = document.getElementById("<%=comSearchBy.ClientID%>");
        if (SearchBy.value == "By Category") {
            document.getElementById("<%=divCategory.ClientID%>").style.display = "block";
            document.getElementById("<%=divAuthor.ClientID%>").style.display = "none";
            document.getElementById("<%=divPublisher.ClientID%>").style.display = "none";
        }
        else if (SearchBy.value == "By Author") {
            document.getElementById("<%=divCategory.ClientID%>").style.display = "none";
            document.getElementById("<%=divAuthor.ClientID%>").style.display = "block";
            document.getElementById("<%=divPublisher.ClientID%>").style.display = "none";
        }
        else if (SearchBy.value == "By Publisher") {
            document.getElementById("<%=divCategory.ClientID%>").style.display = "none";
            document.getElementById("<%=divAuthor.ClientID%>").style.display = "none";
            document.getElementById("<%=divPublisher.ClientID%>").style.display = "block";
        }
        else if (SearchBy.value == "All") {
            document.getElementById("<%=divCategory.ClientID%>").style.display = "none";
            document.getElementById("<%=divAuthor.ClientID%>").style.display = "none";
            document.getElementById("<%=divPublisher.ClientID%>").style.display = "none";
        }
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row"  style="margin-top:10px;margin-bottom:10px">
      <div class="panel-body" style="border:thin solid black;background-color:#42b3f4;color:White;height:35px;margin-bottom:2px">  
      <div class="col-sm-12" style="margin-left:10px">
        <div class="form-horizontal">    
            <div class="form-group" style="text-align:center; margin-top:-12px;font-weight:bold;font-size:22px;font-family:Maiandra GD">
                BOOK INFORMATION
            </div>
        </div>
      </div>
      </div>
   <div class="panel-body" style="border:thin solid black;">
    <div id="page" style="margin:-10px">
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs" role="tablist">
            <li class="active"><a href="#BookInfo" aria-controls="BookInfo" role="tab" data-toggle="tab">Book Info</a></li>
            <li><a href="#BookList" aria-controls="BookList" role="tab" data-toggle="tab">Book List</a></li>
        </ul>
        <div class="tab-content">
         <div role="tabpanel" class="tab-pane active" id="BookInfo" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
             <div class="panel-body">
             <div class="row">
            <div class="col-sm-6" style="margin-bottom:-10px">
            <div class="form-horizontal">
                         <div class="form-group">
                            <label for="message" class="col-xs-4">Book No:<label for="message" style="color:Red">*</label></label>
                              <div class="col-xs-5">
                                <asp:TextBox ID="txtBookNo" CssClass="form-control  input-sm" Enabled="false"  runat="server" TabIndex="1"></asp:TextBox>
                             </div>
                            <div class="col-xs-3">                              
                            </div>
                         </div>
                         <div class="form-group">
                             <label for="message" class="col-xs-4">Book Name/Title:<label for="message" style="color:Red">*</label></label>
                              <div class="col-xs-8">
                             <asp:TextBox ID="txtBookName" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="2"></asp:TextBox>
                             </div>
                         </div> 
                         <div class="form-group">                             
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate> 
                             <label for="message" class="col-xs-4">Author Name:<label for="message" style="color:Red">*</label></label>                           
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtAuthorName" style="position:absolute;width:87%;text-transform:uppercase" Visible="false" CssClass="form-control  input-sm" runat="server" TabIndex="3"></asp:TextBox>
                             <asp:DropDownList ID="comAuthorName" CssClass="form-control  input-sm" AutoPostBack="true" runat="server" TabIndex="3">
                                 <asp:ListItem>SELECT AUTHOR NAME</asp:ListItem>
                                 <asp:ListItem>Add New</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                         <div class="form-group">                                 
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate> 
                             <label for="message" class="col-xs-4">Book Category:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtBookCategory" style="position:absolute;width:87%;text-transform:uppercase" Visible="false" CssClass="form-control  input-sm" runat="server" TabIndex="4"></asp:TextBox>
                             <asp:DropDownList ID="comBookCategory" CssClass="form-control  input-sm" AutoPostBack="true"  runat="server" TabIndex="4">
                             <asp:ListItem>SELECT BOOK CATEGORY</asp:ListItem>
                             <asp:ListItem>COMPUTER</asp:ListItem>
                             <asp:ListItem>MATHS</asp:ListItem>
                             <asp:ListItem>SCIENCE</asp:ListItem>
                             <asp:ListItem>COMMERCE</asp:ListItem>
                             <asp:ListItem>Add New</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                       <div class="form-group">                                 
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate> 
                             <label for="message" class="col-xs-4">Publisher Name:<label for="message" style="color:Red">*</label></label>
                             <div class="col-xs-8">
                             <asp:TextBox ID="txtPublication" style="position:absolute;width:87%;text-transform:uppercase" Visible="false" CssClass="form-control  input-sm" runat="server" TabIndex="5"></asp:TextBox>
                             <asp:DropDownList ID="comPublication" CssClass="form-control  input-sm" AutoPostBack="true" runat="server" TabIndex="5">
                             <asp:ListItem>SELECT PUBLISHER</asp:ListItem>
                             <asp:ListItem>Add New</asp:ListItem>
                             </asp:DropDownList>
                             </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div> 
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Book Edition:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtBookEdition" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="6"></asp:TextBox>
                             </div>
                        </div>     
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Language:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtLanguage" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="7"></asp:TextBox>
                             </div>
                        </div>      
                        <div class="form-group">
                             <label for="message" class="col-xs-4">Purchase Amount:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtPrice" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="7"></asp:TextBox>
                             </div>
                        </div>      
                        <div class="form-group">
                             <label for="message" class="col-xs-4">No Of Copies:</label>
                             <div class="col-xs-8">
                              <asp:TextBox ID="txtCopies" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="8"></asp:TextBox>
                             </div>
                        </div>   
                        <div class="form-group">
                             <label for="message" class="col-xs-3">Bar Code No:</label>
                             <div class="col-xs-5">
                                 <asp:DropDownList ID="comBarCodeType" CssClass="form-control  input-sm" AutoPostBack="true" runat="server" TabIndex="4">
                                 <asp:ListItem>EXISTING BARCODE</asp:ListItem>
                                 <asp:ListItem>SERIAL NO AS BARCODE</asp:ListItem>
                                 </asp:DropDownList>
                             </div>
                             <div class="col-xs-4">
                                 <asp:TextBox ID="txtBarCode" CssClass="form-control  input-sm" style="text-transform:uppercase" runat="server" TabIndex="7"></asp:TextBox>
                             </div>
                        </div>       
                        <div class="form-group">                            
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate> 
                             <div class="col-xs-3">
                                 <asp:Label ID="lbFlag" runat="server" Visible="false" Text="0"></asp:Label>
                                 <asp:Label ID="lbBookId" runat="server"  Visible="false" Text="0"></asp:Label>
                             </div>
                             <div class="col-xs-3">
                                <asp:LinkButton ID="btnSave" CssClass="btn btn-primary" runat="server" Width="100%"  TabIndex="9">
                                <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"> Save</span>
                                </asp:LinkButton>
                             </div>
                               <div class="col-xs-3">
                    <asp:LinkButton ID="btnRefresh" CssClass="btn btn-primary" runat="server" Width="100%"  TabIndex="10">
                                <span aria-hidden="true" class="glyphicon glyphicon-refresh"> Refresh</span>
                                </asp:LinkButton>
                                </div>
                               <div class="col-xs-3">
                    <asp:LinkButton ID="btnGenerateBarCode" CssClass="btn btn-primary" runat="server" Width="100%"  TabIndex="10">
                                <span aria-hidden="true" class="glyphicon glyphicon-barcode"> Barcode</span>
                                </asp:LinkButton>
                                </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                      </div>                
                    </div>
                    <div class="col-sm-6">                                                 
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate> 
                          <asp:PlaceHolder ID="plBarCode" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    </div>
            </div>
            </div>
        <div role="tabpanel" class="tab-pane" id="BookList" style="background-color:White;border-bottom: thin solid lightgray;border-right: thin solid lightgray;border-left: thin solid lightgray">
                                 
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>                      
<div class="panel-body" style="background-color:#05BBF7; height:50px"> 
      <div class="col-sm-3" style="margin-top:-5px">
            <div class="form-horizontal">   
             <div class="form-group">                                      
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate> 
                    <label for="message" class="col-xs-3" style="text-align:right;margin-top:5px">Search:</label>
                    <div class="col-xs-9">
                    <asp:DropDownList ID="comSearchBy" CssClass="form-control  input-sm" onchange="divvisible()" runat="server">
                    <asp:ListItem>By Category</asp:ListItem>
                    <asp:ListItem>By Author</asp:ListItem>
                    <asp:ListItem>By Publisher</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>    
      <div class="col-sm-4" style="margin-top:-5px">
            <div class="form-horizontal">   
             <div class="form-group">  
                <div class="col-xs-8"  id="divCategory" runat="server"  hidden="false">
                <asp:DropDownList ID="comCategory"  Width="100%" CssClass="form-control  input-sm" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-8"  id="divAuthor"  runat="server"  hidden="false">
                <asp:DropDownList ID="comAuthor"  Width="100%"  CssClass="form-control  input-sm" runat="server"></asp:DropDownList>
                </div>

                <div class="col-xs-8" id="divPublisher"  runat="server" hidden="false">
                <asp:DropDownList ID="comPublisher"  Width="100%"  CssClass="form-control  input-sm" runat="server"></asp:DropDownList>
                </div>
             </div>
         </div>
     </div>
      <div class="col-sm-3" style="margin-top:-5px">
            <div class="form-horizontal">   
             <div class="form-group">        
            
                    <div class="col-xs-6">
                    <asp:LinkButton ID="btnSearchDetails" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-search"> Search</span>
                    </asp:LinkButton>
                    </div>
                    <div class="col-xs-6">
                    <asp:LinkButton ID="btnPrint" CssClass="btn btn-primary" runat="server" Width="100%" >
                                <span aria-hidden="true" class="glyphicon glyphicon-print"> Print</span>
                    </asp:LinkButton>
                    </div>
                    </div>
                    </div>
                    </div>
</div> 
<div  id="divPrint" class="panel-body" style="margin-left:-15px; margin-right:-15px;margin-top:-10px"> 
  <asp:GridView ID="GridBookList" runat="server" HeaderStyle-BackColor="#66ccff" AutoGenerateColumns="false" GridLines="Both" AllowPaging="true" PageSize="10" Width="100%"
   HeaderStyle-Font-Size="Small" HeaderStyle-Font-Names="Maiandra GD"  HeaderStyle-Font-Bold="true"  RowStyle-Font-Size="Small"    RowStyle-Font-Names="Maiandra GD"
    RowStyle-Font-Bold="true">
            <Columns>                                         
                <asp:TemplateField ItemStyle-Width="3%">
                <ItemTemplate>
                <asp:LinkButton Text="Edit" ID="lnkSelect"  ForeColor="Blue" Font-Bold="true" runat="server" CommandName="Select" /><br/>                          
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ItemStyle-Width="6%" DataField="BookNo" HeaderText="BOOK-NO" />
                <asp:BoundField ItemStyle-Width="15%" DataField="BookTitle" HeaderText="BOOK-TITLE" />
                <asp:BoundField ItemStyle-Width="15%" DataField="AuthorName" HeaderText="AUTHOR-NAME" />
                <asp:BoundField ItemStyle-Width="15%" DataField="BookCategory" HeaderText="BOOK-CATEGORY" />
                <asp:BoundField ItemStyle-Width="15%" DataField="PublisherName" HeaderText="PUBLISHER" />
                <asp:BoundField ItemStyle-Width="10%" DataField="Edition" HeaderText="EDITION" />
                <asp:BoundField ItemStyle-Width="15%" DataField="Price" HeaderText="PRICE" />
                <asp:BoundField ItemStyle-Width="6%" DataField="BookCopies" HeaderText="COPIES" />
            </Columns>
            <HeaderStyle/>
        </asp:GridView>
    </div> 
</ContentTemplate>
</asp:UpdatePanel>
      </div>
            </div>
        </div>
       </div>
    </div>
 </div>
</asp:Content>
