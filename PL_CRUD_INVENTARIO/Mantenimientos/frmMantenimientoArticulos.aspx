<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoArticulos.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmMantenimientoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
     <div class="set-1">
     <div class="graph-2 general">
         <h3 class="inner-tittle two"> Informacion del Articulo </h3>
         <div class="grid-1">
             <div class="form-body">
                 <form action="javascript: mantenimientoArticulo()" method="post" class="form-horizontal">

                     <div class="form-group">
                         <label for="bsqDescripcion" class="col-sm-2 control-label">Descripcion</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1" id="bsqDescripcion" placeholder="">
                         </div>
                     </div>
                      <div class="form-group">
                          <label for="cboSts" class="col-sm-2 control-label label-input-sm">Estado</label>
                          <div class="col-sm-8">
                          <select id="cboSts" class="form-control1">
                          <option value="A">Activo</option>
                          <option value="I">Inactivo</option>
                          </select>
                     </div>
                </div>

                     <div class="form-group">
                         <label for="bsqExistencias" class="col-sm-2 control-label">Existencias</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1" id="bsqExistencias" placeholder="">
                         </div>
                     </div>

                     <div class="form-group">
                         <label for="bsqPrecio" class="col-sm-2 control-label label-input-sm">Precio</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1 input-sm" id="bsqPrecio" placeholder="">
                         </div>
                     </div>
                          <div class="form-group">
                              <label for="cboProveedor" class="col-sm-2 control-label label-input-sm">Proveedor</label>
                              <div class="col-sm-8">
                              <select id="cboProveedor" class="form-control1">         
                              </select>
                         </div>
                   </div>
                     <div class="form-group">
                         <div class="col-sm-offset-2 col-sm-10">
                             <button type="submit" class="btn btn-default">Guardar</button>
                             <button type="button" class="btn btn-primary" onclick="javascript: regresar()">Regresar</button>
                         </div>
                     </div>

                 </form>
             </div>

         </div>
     </div>
 </div>
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../javascript/jquery.cookie.js"></script>
    <script src="../Base/assets/js/bootstrap.min.js"></script> 
   <script src="../JavaScript/Articulos.js"></script>
</asp:Content>