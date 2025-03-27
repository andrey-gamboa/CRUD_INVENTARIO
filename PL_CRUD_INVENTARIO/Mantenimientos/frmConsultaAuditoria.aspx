<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaAuditoria.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmConsultaAuditoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--/set-1-->
 <div class="set-1">
     <div class="col-md-6 graph-2">
         <h3 class="inner-tittle two">Filtros de Búsqueda de Auditoría</h3>
         <div class="grid-1">
             <div class="form-body">
                 <form class="form-horizontal" action="javascript: cargaListaAuditoria()" method="post">

                     <div class="form-group">
                         <label for="bsqUsuario" class="col-sm-2 control-label">Usuario</label>
                         <div class="col-sm-9">
                             <select id="bsqUsuario" class="form-control">
                             </select>
                         </div>
                     </div>


                     <div class="form-group">
                         <label for="bsqAccion" class="col-sm-2 control-label">Acción</label>
                         <div class="col-sm-9">
                             <select id="bsqAccion" class="form-control">
                            <option value="T">Todas</option>
                            <option value="A">Actualizar</option>
                            <option value="I">Insertar</option>
                            <option value="E">Eliminar</option>
                             </select>
                         </div>
                     </div>


                     <div class="form-group">
                         <label for="bsqFdd" class="col-sm-2 control-label">Fecha Desde</label>
                         <div class="col-sm-9">
                             <input type="date" class="form-control" id="bsqFdd" required="">
                         </div>
                     </div>

                     <div class="form-group">
                         <label for="bsqFhh" class="col-sm-2 control-label">Fecha Hasta</label>
                         <div class="col-sm-9">
                             <input type="date" class="form-control" id="bsqFhh" required="">
                         </div>
                     </div>

                     <div class="form-group">
                         <div class="col-sm-offset-2 col-sm-10">
                             <button type="submit" class="btn btn-default">Buscar</button>
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
         <h2 class="inner-tittle">Resultados de Búsqueda de Auditoría </h2>
         <div class="graph">
             <div class="tables">

                 <table class="table" id="tblAuditoria">
                   <%--Aquí se carga el contenido dinámico de la tabla--%>
                 </table>
             </div>
         </div>

     </div>
 </div>
 <script src="../JavaScript/Auditoria.js"></script>
  <script src="../javascript/jquery.cookie.js"></script>
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
