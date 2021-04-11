<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sequoia_BE.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="id_Head" runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Sequoia BE | Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/square/blue.css">
  <%--<link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" >
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" >--%>
  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition login-page" style="background:#FFFFFF">
    <%--#f7f1d9--%>

    <div class="login-box" style="background:#ffb26b">  
        <%--CFC38F--%>
        <div class="login-logo">
            <a href="#">
                <label id="lblInstitutionName" runat="server" class="notbold">Beautesoft</label></a>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body" style="border-color:#ffb26b">

            <p class="login-box-msg">
                <img src="Img/octogonsmall.png" /></p>

            <form id="frm_Login" runat="server">
                <div class="form-group has-feedback">
                    <input type="text" id="txtUserName" class="form-control" runat="server" style="background:#FFFFFF;border-radius:20px;border-color:#8b7306" placeholder="User Id">
                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                </div>


                <div class="form-group has-feedback">

                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" onkeypress="return runScript(event)" class="form-control" style="background:#FFFFFF;border-radius:20px;border-color:#8b7306" placeholder="Password"></asp:TextBox>

                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                  
                </div>

                 <div class="form-group has-feedback" style="display:none">
                    <input type="text" id="txtLocale" class="form-control" runat="server" onkeypress="return runScript(event)"  style="background:#FFFFFF;border-radius:20px;border-color:#8b7306" placeholder="Locale">
                    <span class="glyphicon glyphicon-book form-control-feedback"></span>
                       <div id="validation_failed">
                        <label id="lblFailed" runat="server" style="color:red;margin-top:10px"></label>
                    </div>
                </div>
              
                <div class="row" style="display:none">
                    <div class="col-xs-12">
                        <div class="checkboxnew">
                            <label>
                                <input type="checkbox" id="chkRememberMe" runat="server" style="background:#ced4da">
                                Remember Me
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                   
                    <!-- /.col -->
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <button id="btnLogin" type="button" onserverclick="Login_Click" runat="server" class="btn btn-primary btn-block btn-flat" style="background:#ffb26b;border-radius:25px;margin-top:10px">Login</button>
                        <%--CFC38F--%>
                    </div>
                </div>

            </form>


        </div>
        <!-- /.login-box-body -->
    </div>

<!-- jQuery 3 -->
<script src="bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="plugins/iCheck/icheck.min.js"></script>
<script>
    function runScript(e) {
        if (e.keyCode == 13) {
            $("#btnLogin").click(); //jquery
            //document.getElementById("myButton").click(); //javascript
        }
    }

    $(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' /* optional */
        });
    });
</script>
</body>
</html>


