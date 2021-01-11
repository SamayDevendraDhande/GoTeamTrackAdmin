<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppDownload.aspx.cs" Inherits="AppDownload" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <meta charset="utf-8" />
    <title>Go Team</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/metro.css" rel="stylesheet" />
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/style_responsive.css" rel="stylesheet" />
    <link href="assets/css/style_default.css" rel="stylesheet" id="style_color" />
    <link rel="stylesheet" type="text/css" href="assets/uniform/css/uniform.default.css" />
    <%--<link rel="shortcut icon" href="images/logo.png" type="image/png" />--%>
    <style>
        body {
            font-family: calibri !important;
        }

        .btn {
            font-family: calibri !important;
        }

        input.m-wrap, button.m-wrap, select.m-wrap, textarea.m-wrap {
            font-family: calibri !important;
        }

        input, button, select, textarea {
            font-family: calibri !important;
        }
    </style>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="login">
    <form runat="server" id="form1">
        <!-- BEGIN LOGO -->
        <div class="logo">
            <img src="ss_icon_192x192.png" style="height: 50px;" alt="" />
            <h3 style="color: #FFFFFF;">Go Team</h3>
            <%--<img src="images/FAG_Logo.png" alt="" />--%>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <div class="form-vertical login-form">
                <div class="form-actions">
                    <a href="GoTeamApp_v1.4.apk" class="btn blue pull-left" style="width:90%; font-size: 24px;">Download App</a>
                </div>
            </div>
            <!-- END LOGIN FORM -->
        </div>
        <!-- END LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright">
            Powered By <a target="_blank" href="http://samaysoftware.net">Samay Software</a>
        </div>
        <!-- END COPYRIGHT -->
        <!-- BEGIN JAVASCRIPTS -->

        <script src="assets/js/jquery-1.8.3.min.js"></script>

        <script src="assets/bootstrap/js/bootstrap.min.js"></script>

        <script src="assets/uniform/jquery.uniform.min.js"></script>

        <script src="assets/js/jquery.blockui.js"></script>

        <script src="assets/js/app.js"></script>

        <script>
            jQuery(document).ready(function () {
                App.initLogin();
            });
        </script>

    </form>
</body>
<!-- END BODY -->
</html>
