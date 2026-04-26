var g_Dominio = "localhost";
var TLTC = 60;
$(document).ready(function () {
    cargaProveedores();

    var PageName = window.location.pathname.split('/').pop();

    if (PageName == 'frmConsultaArticulos.aspx') {
        setTimeout(function () {
            cargaListaArticulos();
        }, 1500);

    }
    else if (PageName == 'frmMantenimientoArticulos.aspx') {
        setTimeout(function () {
            obtieneDetalleArticulo();
        }, 1500);

    }
});

function cargaProveedores() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("ART");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmConsultaProveedores.aspx/CargaListaProveedoresCombo",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {
                    if (res === "No se encontraron registros") {
                        $("#bsqProveedor").html("");
                        $("#cboProveedor").html("");
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });

                        setTimeout(function () {
                            location.href("frmPrincipal.aspx");
                        }, 2000);

                    }
                    else {
                        $("#bsqProveedor").html(res);
                        $("#cboProveedor").html(res);
                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}
function crearArticulo() {
    $.cookie('ART', 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoArticulos.aspx";
}
function regresar() {
    location.href = "frmConsultaArticulos.aspx";
}


function cargaListaArticulos() {
    console.log("Función cargaListaArticulos llamada");
    $.cookie('ART', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqDescripcion").val();
    obj_Parametros_JS[1] = $("#bsqProveedor").val();
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmConsultaArticulos.aspx/CargaListaArticulos",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {
                    if (res === "No se encontraron registros") {

                        $("#tblArticulos").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblArticulos").html(res);
                        paginar("#tblArticulos");
                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}

function defineArticulo(uni) {
    $.cookie('ART', uni, { expires: TLTC, path: '/', domain: g_Dominio });

    location.href = "frmMantenimientoArticulos.aspx";
}

function obtieneDetalleArticulo() {

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("ART");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoArticulos.aspx/CargaInfoArticulo",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {

                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if (res === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        if (resultado != "") {
                            $("#bsqDescripcion").val(arreglo[1]);
                            $("#cboSts").val(arreglo[2]);
                            $("#bsqExistencias").val(arreglo[3]);
                            $("#bsqPrecio").val(arreglo[4]);
                            $("#cboProveedor").val(arreglo[5]);
                        }

                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }

}

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}

function mantenimientoArticulo() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("ART");
    obj_Parametros_JS[1] = $("#bsqDescripcion").val();
    obj_Parametros_JS[2] = $("#cboSts").val();
    obj_Parametros_JS[3] = $("#bsqExistencias").val();
    obj_Parametros_JS[4] = $("#bsqPrecio").val();
    obj_Parametros_JS[5] = $("#cboProveedor").val();
    obj_Parametros_JS[6] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[6] != 0) && (obj_Parametros_JS[6] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoArticulos.aspx/MantenimientoArticulos",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {

                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: 'center-center',
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona al LogIn
                        setTimeout(function () {
                            location.href = "frmConsultaArticulos.aspx";
                        }, 5000);
                    }
                    else {
                        Swal.fire({
                            icon: "info",
                            title: "Información de Registros",
                            text: arreglo[1],
                        });
                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}


function eliminaArticulo(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoArticulos.aspx/EliminarArticulos",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {

                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: 'center-center',
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 2500,
                            timerProgressBar: true
                        });

                        //Se redirecciona al LogIn
                        setTimeout(function () {
                            cargaListaArticulos();
                        }, 3000);
                    }
                    else {
                        Swal.fire({
                            icon: "info",
                            title: "Información de Registros",
                            text: arreglo[1],
                        });
                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}

function paginar(elemento) {


    var table;

    if ($.fn.DataTable.isDataTable(elemento)) {

        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
    else {
        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });

    }

};