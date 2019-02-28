<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function MessageShow(msg) {
            alert(msg);
        }
        '<%Session["UpdatePage"] = "0"; %>';
    </script>
</head>
<body>
   <div class="container" style="margin-top:40px">
		<div class="row">
			<div class="col-sm-6 col-md-4 col-md-offset-4">
				<div class="panel panel-default">
					<div class="panel-heading" style="text-align:center;color:White;background-color:#333">
						<strong> SIGN IN TO CONTINUE...</strong>
					</div>
					<div class="panel-body">
						<form id="Form2" role="form" action="#" runat="server" method="POST" defaultbutton="btnLogin">
							<fieldset>
								<div class="row">
									<div class="col-sm-12 col-md-10  col-md-offset-1 ">
                                     <div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-lock"></i>
												</span>
                                                   <asp:DropDownList ID="ddlSession" class="form-control" runat="server" 
                                                    onselectedindexchanged="ddlSession_SelectedIndexChanged" 
                                                    AutoPostBack="True">
                                                   </asp:DropDownList>
											</div>
										</div>
										<div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-user"></i>
												</span> 
												<asp:TextBox ID="txtUserId" class="form-control" runat="server" placeholder="User-id" name="loginname" type="text"/>
											</div>
										</div>
										<div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-lock"></i>
												</span>
												<asp:TextBox ID="txtPassword" class="form-control" runat="server"  placeholder="Password" TextMode="Password" value=""/>
											</div>
										</div>
                                       
										<div class="form-group">
                                          <asp:LinkButton ID="btnLogin" CssClass="btn btn-primary" runat="server" 
                                                Width="100%" onclick="btnLogin_Click">
                                            <span aria-hidden="true" class="glyphicon glyphicon-log-in"> Login</span>
                                          </asp:LinkButton>
										</div>
									</div>
								</div>
							</fieldset>
						</form>
					</div>
					<div class="panel-footer"  style="text-align:center; height:20px; color:White;background-color:#333">
						
					</div>
                </div>
			</div>
		</div>
	</div>
</body>
</html>
