<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoProveedores.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmMantenimentoProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="set-1">
     <div class="graph-2 general">
         <h3 class="inner-tittle two">Informacion del Hotel  </h3>
         <div class="grid-1">
             <div class="form-body">
                 <form action="javascript: mantenimientoProveedor()" method="post" class="form-horizontal">

                     <div class="form-group">
                         <label for="NombreProveedor" class="col-sm-2 control-label">Nombre Proveedor</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1" id="NombreProveedor" placeholder="">
                         </div>
                     </div>

                     <div class="form-group">
                         <label for="ContactoProveedor" class="col-sm-2 control-label">Nombre del Contacto</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1" id="ContactoProveedor" placeholder="">
                         </div>
                     </div>

                     <div class="form-group">
                         <label for="telProveedor" class="col-sm-2 control-label label-input-sm">Teléfono</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1 input-sm" id="telProveedor" placeholder="">
                         </div>
                     </div>
                     <div class="form-group">
                         <label for="emailProveedor" class="col-sm-2 control-label label-input-sm">Correo Electrónico</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1 input-sm" id="emailProveedor" placeholder="">
                         </div>
                     </div>
                                          <div class="form-group">
                         <label for="DirecProveedor" class="col-sm-2 control-label">Dirección física</label>
                         <div class="col-sm-8">
                             <input type="text" class="form-control1" id="DirecProveedor" placeholder="">
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
     <script src="../JavaScript/Proveedores.js"></script>
      <script src="../javascript/jquery.cookie.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
