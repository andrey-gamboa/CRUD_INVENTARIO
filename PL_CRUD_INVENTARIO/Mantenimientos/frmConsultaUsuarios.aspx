<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaUsuarios.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmConsultaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!--/set-1-->
  <div class="set-1">
      <div class="col-md-6 graph-2">
          <h3 class="inner-tittle two">Filtros de Búsqueda de Usuarios </h3>
          <div class="grid-1">
              <div class="form-body">
                  <form class="form-horizontal" action="javascript: cargaListaUsuarios()" method="post">
                      <div class="form-group">
                          <label for="bsqCorreo" class="col-sm-2 control-label">Correo</label>
                          <div class="col-sm-9">
                              <input type="text" class="form-control" id="bsqCorreo" placeholder="Correo de Usuario">
                          </div>
                      </div>

                      <div class="form-group">
                          <label for="bsqUsuario" class="col-sm-2 control-label">Usuario</label>
                          <div class="col-sm-9">
                              <input type="text" class="form-control" id="bsqUsuario" placeholder="Nombre de Usuario">
                          </div>
                      </div>

                      <div class="form-group">
                          <label for="bsqEstado" class="col-sm-2 control-label">Estado</label>
                          <div class="col-sm-9">
                              <select id="bsqEstado" class="form-control">
                                  <option value="Activo">Activo</option>
                                  <option value="Inactivo">Inactivo</option>
                              </select>
                          </div>
                      </div>

                      <div class="form-group">
                          <div class="col-sm-offset-2 col-sm-10">
                              <button type="submit" class="btn btn-default">Buscar</button>
                              <button type="button" class="btn btn-primary" onclick="crearUsuario()">Crear</button>
                          </div>
                      </div>
                  </form>

              </div>

          </div>
      </div>
      <div class="clearfix"></div>
  </div>
  <div class="outter-wp">
      <div class="graph-visual tables-main">
          <h2 class="inner-tittle">Resultados de Búsqueda de Usuarios </h2>
          <div class="graph">
              <div class="tables">

                  <table class="table" id="tblUsuarios">
                    <%--Aquí se carga el contenido dinámico de la tabla--%>
                  </table>
              </div>
          </div>

      </div>
  </div>
  <script src="../JavaScript/Usuarios.js"></script>
   <script src="../javascript/jquery.cookie.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
