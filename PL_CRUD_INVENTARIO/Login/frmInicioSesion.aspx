<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Login.frmInicioSesion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Inicio de Sesión</title>
  <link href="css/login-nuevo.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <div class="page">
      <div class="container">
        <div class="left">
          <div class="login">Inicio de Sesión</div>
          <div class="eula">Al iniciar sesión, aceptas los términos de uso.</div>
        </div>
        <div class="right">
          <svg viewBox="0 0 320 300">
            <defs>
              <linearGradient id="linearGradient" x1="13" y1="193.5" x2="307" y2="193.5" gradientUnits="userSpaceOnUse">
                <stop style="stop-color:#ff00ff;" offset="0" />
                <stop style="stop-color:#ff0000;" offset="1" />
              </linearGradient>
            </defs>
            <path id="animPath"
              d="m 40,120 
                 240,0 
                 c 0,0 25,1 25,35 
                 0,34 -25,35 -25,35 
                 h -240 
                 c 0,0 -25,4 -25,38.5 
                 0,34.5 25,38.5 25,38.5 
                 h 215 
                 c 0,0 20,-1 20,-25 
                 0,-24 -20,-25 -20,-25 
                 h -190 
                 c 0,0 -20,2 -20,25 
                 0,24 20,25 20,25 
                 h 168.57"
              style="stroke-dashoffset: 1000; stroke-dasharray: 240 1386;" />
          </svg>

          <div class="form">
            <label for="txtUsuario">Email</label>
            <input type="email" id="txtUsuario" />

            <label for="txtPassword">Password</label>
            <input type="password" id="txtPassword" />

            <input type="button" id="submit" value="Iniciar Sesión" onclick="inicioSesion();" />
          </div>
        </div>
      </div>
    </div>
  </form>

  <!-- Scripts -->
  <script src="js/jquery.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/animejs@3.2.1/lib/anime.min.js"></script>
  <script src="js/login-animacion.js"></script>
  <script src="../JavaScript/jquery.cookie.js"></script>
  <script src="../JavaScript/InicioSesion.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</body>
</html>
