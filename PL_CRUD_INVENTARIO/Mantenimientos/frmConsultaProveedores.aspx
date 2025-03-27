<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaProveedores.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmConsultaProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms-inner">
    <!--/set-1-->
    <div class="set-1">
        <div class="col-md-6 graph-2">
            <h3 class="inner-tittle two">Filtros de Búsqueda de Proveedores </h3>
            <div class="grid-1">
                <div class="form-body">
                    <form class="form-horizontal" action="javascript: cargaListaProveedores()" method="post">
                        <div class="form-group">
                            <label for="bsqProveedor" class="col-sm-2 control-label">Proveedor</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="bsqProveedor" placeholder="Nombre del proveedor">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="bsqContacto" class="col-sm-2 control-label">Contacto</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="bsqContacto" placeholder="Nombre de contacto">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="bsqEstado" class="col-sm-2 control-label">Estado</label>
                            <div class="col-sm-9">
                                <select id="bsqEstado" class="form-control">
                                    <option value="A">Activo</option>
                                    <option value="I">Inactivo</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-default">Buscar</button>
                                <button type="button" class="btn btn-primary" onclick="crearProveedor()">Crear</button>
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
            <h2 class="inner-tittle">Resultados de Búsqueda de Proveedores </h2>
            <div class="graph">
                <div class="tables">

                    <table class="table" id="tblProveedores">
                      <%--Aquí se carga el contenido dinámico de la tabla--%>
                    </table>
                </div>
            </div>

        </div>
    </div>
    <script src="../JavaScript/Proveedores.js"></script>
     <script src="../javascript/jquery.cookie.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
