<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Aspfiles_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Bootstrap -->
    <link href="../css/bootstrap.css" rel="stylesheet" media="screen" />
    <link href="../css/thin-admin.css" rel="stylesheet" media="screen" />
    <link href="../css/font-awesome.css" rel="stylesheet" media="screen" />
    <link href="../style/style.css" rel="stylesheet" />
    <script src="js/common.js"></script>
    <script src="js/ezval-1.0.js"></script>
    <script src="js/jquery.js"></script>
</head>
<body>
    <div class="login-logo">
<%--        <img src="../images/logo.png" alt="Context SMS" />--%>
        <img src="images/coromandal.gif" alt="Context SMS" />
    </div>

    <div class="widget">
        <div class="login-content">
            <div class="widget-content" style="padding-bottom: 0;">
                <form  class="no-margin" runat="server" id="frmLogin">
                    <h3 class="form-title">Login to your account</h3>
                    <div class="form-group no-margin">
                        <asp:Label ID="lblUsername" runat="server" Text="User Name"></asp:Label>
                        <div class="input-group input-group-lg">
                            <span class="input-group-addon">
                                <i class="icon-user"></i>
                            </span>
                            <asp:TextBox ID="txtUserName" runat="server" placeholder="Your UserName" class="form-control input-lg" rule="{'User Name', 'required'}"></asp:TextBox>
                        </div>
<%--                        <asp:RequiredFieldValidator ID="RFVtxtusername" ControlToValidate="txtUserName" runat="server" ErrorMessage="" Text="*" Font-Bold="true" Font-Italic="true" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        <div class="input-group input-group-lg">
                            <span class="input-group-addon">
                                <i class="icon-lock"></i>
                            </span>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control input-lg" placeholder="Your Password" TextMode="Password" rule="{'Password','required'}"></asp:TextBox>
                        </div>
<%--                        <asp:RequiredFieldValidator ID="RFVtxtpassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="" Text="*" Font-Bold="true" Font-Italic="true" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="form-actions">
                        <div class="checker">
                            <span>
                                <asp:CheckBox ID="chkboxRemember" runat="server" Text="Remember me" />
                            </span>
                        </div>
                        <label class="checkbox">
                        </label>
                        <asp:Button ID="btnSubmit" runat="server" Text="Login" class="btn btn-warning pull-right"  OnClientClick="return validateLogin();" />
                        <i class="m-icon-swapright m-icon-white"></i>
                        <div class="forgot"><a href="#" class="forgot">Forgot Username or Password?</a></div>
                    </div>
                </form>
            </div>
        </div>
    </div>


    <script type="text/javascript">

       
        function validateLogin() {
           
            var errorcount = 0;
            var errorMessage = 'Please check the Following';

            
        }
    </script>

</body>
</html>
