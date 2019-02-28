<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" Inherits="SessionExpired" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Session Expire</title>

    <!-- Bootstrap core CSS -->
    <link href="../assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="../assets/css/style.css" rel="stylesheet">
    <link href="../assets/css/style-responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function MessageShow(msg) {
            alert(msg);
        }
    </script>
  </head>

  <body onload="getTime()">

      <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->
     
	  	<div class="container">
	  	 <form id="Form2" role="form" action="#" runat="server" method="POST" defaultbutton="btnLogin">
	  		<div id="showtime"></div>
	  			<div class="col-lg-4 col-lg-offset-4">
	  				<div class="lock-screen">
		  				<h2><a data-toggle="modal" href="#myModal"><i class="fa fa-lock"></i></a></h2>
		  				<p>UNLOCK</p>
		  				
				          <!-- Modal -->
				          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
				              <div class="modal-dialog">
				                  <div class="modal-content">
				                      <div class="modal-header">
				                          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				                          <h4 class="modal-title">Welcome Back</h4>
				                      </div>
				                      <div class="modal-body">
				                          <p class="centered"><img class="img-circle" width="80" src="../assets/img/login.png"></p>
				                          <%--<input type="password" name="password" placeholder="Password" autocomplete="off" class="form-control placeholder-no-fix">--%>
				                          <asp:TextBox ID="txtPassword" class="form-control placeholder-no-fix" runat="server"  placeholder="Password" TextMode="Password" value="" autocomplete="off" />
				                      </div>
				                      <div class="modal-footer centered">
                                       <asp:LinkButton ID="btnLogin" CssClass="btn btn-theme03" runat="server" 
                                               onclick="btnLogin_Click">
                                            <span aria-hidden="true"> Login</span>
                                          </asp:LinkButton>
				                         <%-- <button class="btn btn-theme03" type="button">Login</button>--%>
				                          <button data-dismiss="modal" class="btn btn-theme04" type="button">Cancel</button>
                                         
				                      </div>
				                  </div>
				              </div>
				          </div>
				          <!-- modal -->
		  				
		  				
	  				</div><! --/lock-screen -->
	  			</div><!-- /col-lg-4 -->
	  	</form>
	  	</div><!-- /container -->
        
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="../assets/js/jquery.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="../assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("../assets/img/login-bg.jpg", { speed: 500 });
    </script>

    <script type="text/javascript">
        function getTime() {
            var sessionTimeout = "<%= Session.Timeout %>";
            if (sessionTimeout == 16) {
                var minute = sessionTimeout - 3
                var second = 60;
            }
            else {
                var minute = 13
                var second = 60;
            }
            setInterval(function () {
                second--;
                second = checkTime(second);
                document.getElementById('showtime').innerHTML = '00:' + minute + ":" + second;
                if (second == 0) {
                    minute--;
                    minute = checkTime(minute);
                    second = 60;
                }
                if (minute == 0) {
                    window.location = "../Default.aspx";
                }
            }, 1000);
        }
        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
            return i;
        }
    </script>

  </body>
</html>

