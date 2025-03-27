<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Login.frmInicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Sistema CRUD Hotel</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Bootstrap Core CSS -->
    <link href="../Base/assets/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../Base/assets/css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../Base/assets/css/font-awesome.css" rel="stylesheet">
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css'>
    <!-- lined-icons -->
    <link rel="stylesheet" href="../Base/assets/css/icon-font.min.css" type='text/css' />
    <!-- //lined-icons -->
    <script src="../Base/assets/js/jquery-1.10.2.min.js"></script>
    <!--clock init-->
</head>

<body>
    <!--/login-->

    <div class="error_page">
        <!--/login-top-->

        <div class="error-top">
            <h2 class="inner-tittle page">SISTEMA HOTEL</h2>
            <div class="login">
                <h3 class="inner-tittle t-inner">BIENVENIDO</h3>
                <form action="javascript: inicioSesion()" method="post">
                    <input type="text" id="txtUsuario" class="text" value="Correo Electronico" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Correo Electronico';}">
                    <input type="password" id="txtPassword" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}">
                    <div class="submit">
                        <input type="submit" value="Iniciar Sesion"></div>
                </form>
            </div>

        </div>
        <!--//login-top-->
    </div>

    <!--//login-->
    <!--footer section start-->
    <div class="footer">
        <p>&copy 2016 Augment . All Rights Reserved | Design by <a href="https://w3layouts.com/" target="_blank">W3layouts.</a></p>
    </div>
    <!--footer section end-->
    <!--/404-->
    <!--js -->
    <script src="../Base/assets/js/jquery.nicescroll.js"></script>
    <script src="../Base/assets/js/scripts.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../Base/assets/js/bootstrap.min.js"></script>
    <script src="../javascript/InicioSesion.js"></script>
    <script src="../javascript/jquery.cookie.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</html>
