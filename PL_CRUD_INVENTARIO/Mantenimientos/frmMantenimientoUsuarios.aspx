<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoUsuarios.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmMantenimientoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="set-1">
    <div class="graph-2 general">
        <h3 class="inner-tittle two">Informacion del usuario  </h3>
        <div class="grid-1">
            <div class="form-body">
                <form action="javascript: mantenimientoUsuario()" method="post" class="form-horizontal">

                    <div class="form-group">
                        <label for="txtEml" class="col-sm-2 control-label">Correo</label>
                        <div class="col-sm-8">
                            <input type="email" class="form-control1" id="txtEml" placeholder="Correo del ususario">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtNom" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control1" id="txtNom" placeholder="Nombre del ususario">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtApe1" class="col-sm-2 control-label label-input-sm">Primer apellido</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control1 input-sm" id="txtApe1" placeholder="Primer apellido">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtApe2" class="col-sm-2 control-label label-input-sm">Segundo apellido</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control1 input-sm" id="txtApe2" placeholder="Segundo apellido">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtPwd" class="col-sm-2 control-label label-input-sm">Password</label>
                        <div class="col-sm-8">
                            <input type="password" class="form-control1 input-sm" id="txtPwd" placeholder="Password">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="cboSts" class="col-sm-2 control-label label-input-sm">Estado</label>
                        <div class="col-sm-8">
                            <select id="cboSts" class="form-control1">
                                <option value="Activo">Activo</option>
                                <option value="Inactivo">Inactivo</option>
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
    <script src="../JavaScript/Usuarios.js"></script>
     <script src="../javascript/jquery.cookie.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
