<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Login</title>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <%--<link href="assets/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="assets/jQuery/jquery-3.3.1.min.js" type="text/javascript"></script>
      <script src="assets/jQuery/JScript.js" type="text/javascript"></script>
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function MessageShow(msg) {
            alert(msg);
        }
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <style type="text/css">
     #txtPassword{
           -webkit-text-security:disc;
       }
    </style>
  </head>

  <body>

      <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->
  
    
      <div id="login-page">
	  	<div class="container">
		      <form id="Form1" class="form-login" runat="server" defaultbutton="btnLogin" autocomplete="new-password">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods = "true">
                </asp:ScriptManager>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
		        <h2 class="form-login-heading">sign in now</h2>
		        <div class="login-wrap">
                <asp:DropDownList ID="ddlCompany" class="form-control" runat="server"
                AutoPostBack="True"
                onselectedindexchanged="ddlCompany_SelectedIndexChanged">
              </asp:DropDownList>
                <div runat="server" visible="false" id="mainDivForLogin">
                <div runat="server" visible="false" id="sessionDiv">
                </br/>
                <asp:DropDownList ID="ddlSession" class="form-control" runat="server" 
                onselectedindexchanged="ddlSession_SelectedIndexChanged" 
                AutoPostBack="True">
                </asp:DropDownList>
                </div>
                <br />
                <asp:TextBox ID="txtUserId" class="form-control" runat="server" placeholder="User-id" onkeydown="HideErrorLabel();" name="loginname" type="text" autofocus/>
                <asp:RequiredFieldValidator ID="txtUserIdR" ValidationGroup="INSERT" ControlToValidate="txtUserId"
                            runat="server" ErrorMessage="R" Text="Please enter User-id" ForeColor="Red"></asp:RequiredFieldValidator>
		           <%-- <input type="text" class="form-control" placeholder="User ID" autofocus>--%>
		            <br/>
                    <asp:TextBox ID="txtPassword" class="form-control" runat="server"  placeholder="Password" TextMode="Password" value="" autocomplete="new-password" />
                     <asp:RequiredFieldValidator ID="txtPasswordR" ValidationGroup="INSERT" ControlToValidate="txtPassword" 
                            runat="server" ErrorMessage="R" Text="Please enter password" ForeColor="Red" ></asp:RequiredFieldValidator>
		           <%-- <input type="password" class="form-control" placeholder="Password">--%>
		            <label class="checkbox">
		                <span class="pull-right">
		                    <a data-toggle="modal" href="login.html#myModal"> Forgot Password?</a>
		
		                </span>
		            </label>
                     <asp:LinkButton ID="btnLogin" ValidationGroup="INSERT" CssClass="btn btn-theme btn-block" runat="server" 
                        Width="100%" onclick="btnLogin_Click" >
                    <span aria-hidden="true" class="fa fa-lock" style="line-height: 1.4;"> SIGN IN</span>
                    </asp:LinkButton>
                    <p id="Errormsg" runat="server" style="color:Red;text-align:center;margin-top: 19px;" visible="false">Wrong user-id or password</p>
		            <%--<button class="btn btn-theme btn-block" href="index.html" type="submit"><i class="fa fa-lock"></i> SIGN IN</button>--%>
		            <%--<hr/>--%>
		        </div>
		        </div>
		
		          <!-- Modal -->
		          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                      <div class="modal-header">
		                          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
		                          <h4 class="modal-title">Forgot Password ?</h4>
		                      </div>
		                      <div class="modal-body">
		                          <p>Enter your e-mail address below to reset your password.</p>
		                          <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">
		
		                      </div>
		                      <div class="modal-footer">
                                  <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-theme" Text="Submit" onclick="btnSubmit_Click"/>
		                          <button data-dismiss="modal" class="btn btn-default" type="button">Cancel</button>
		                      </div>
		                  </div>
		              </div>
		          </div>
		          <!-- modal -->
		        </ContentTemplate>
             </asp:UpdatePanel>
		      </form>	  	
	  	
	  	</div>
	  </div>
    
	  

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script type="text/javascript">
        $.backstretch("assets/img/login-bg.jpg", { speed: 500 });
        $("btnLogin").click(function () {
            $("p").show("slow");
        });

         function HideErrorLabel() {
//             $('#Errormsg').css('display', 'none');
             $('#Errormsg').hide();
         }
    </script>


  </body>
</html>

