<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoModulosXUsuario.aspx.cs" Inherits="PL_CRUD_INVENTARIO.Mantenimientos.frmMantenimientoModulosXUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="outter-wp">
        <div class="graph-visual tables-main">
            <h2 class="inner-tittle">Módulos Disponibles </h2>
            <div class="graph">
                <div class="tables">

                    <table class="table" id="tblModulosDisponibles">
                        <%--Aquí se carga el contenido dinámico de la tabla--%>
                    </table>
                    <form id="frmModulosXUsuario">
                      <button type="button" class="btn btn-primary" onclick="javascript: regresar()">Regresar</button>
                    </form>

                </div>
            </div>

        </div>
    </div>

    <div class="outter-wp">
        <div class="graph-visual tables-main">
            <h2 class="inner-tittle">Resultados de Búsqueda de Módulos Asignados </h2>
            <div class="graph">
                <div class="tables">

                    <table class="table" id="tblModulosXUsuario">
                        <%--Aquí se carga el contenido dinámico de la tabla--%>
                    </table>
                </div>
            </div>

        </div>
    </div>


    <script src="../JavaScript/ModulosXUsuario.js"></script>
    <script src="../javascript/jquery.cookie.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
