<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaArticulos.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmConsultaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <div class="forms-inner">
    <!--/set-1-->
    <div class="set-1">
        <div class="col-md-6 graph-2">
            <h3 class="inner-tittle two">Filtros de Búsqueda de Articulos </h3>
            <div class="grid-1">
                <div class="form-body">
                    <form class="form-horizontal" action="javascript:cargaListaArticulos()" method="post">
                        <div class="form-group">
                            <label for="bsqDescripcion" class="col-sm-2 control-label">Descripcion</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="bsqDescripcion" placeholder="Nombre del articulo">
                            </div>
                        </div>
                               <div class="form-group">
                              <label for="bsqProveedor" class="col-sm-2 control-label label-input-sm">Proveedor</label>
                              <div class="col-sm-8">
                             <select id="bsqProveedor" class="form-control1"> 
                                 
                            </select>
                            </div>
                           </div>               
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-default">Buscar</button>
                               <button type="button" class="btn btn-primary" onclick="javascript: crearArticulo()">Crear</button>
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
            <h2 class="inner-tittle">Resultados de Búsqueda de Articulos </h2>
            <div class="graph">
                <div class="tables">

                    <table class="table" id="tblArticulos">
                      <%--Aquí se carga el contenido dinámico de la tabla--%>
                    </table>
                </div>
            </div>

        </div>
    </div>            
</div> 
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
   <script src="../javascript/jquery.cookie.js"></script>
    <script src="../Base/assets/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
   <script src="../JavaScript/Articulos.js"></script>
</asp:Content>
