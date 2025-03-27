var g_Dominio = "localhost";
var TLTC = 60;

$(document).ready(function () {

    var PageName = window.location.pathname.split('/').pop();

    if (PageName == 'frmConsultaUsuarios.aspx') {
        cargaListaUsuarios();
    }
    else if (PageName == 'frmMantenimientoUsuarios.aspx') {
        obtieneDetalleUsuario();
    }


});

function crearUsuario() {
    //Al crear un registro nuevo, la cookie del identificador de la entidad vamos a hacerla 0 
    $.cookie('USRUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoUsuarios.aspx";

}

function regresar() {
    location.href = "frmConsultaUsuarios.aspx";
}

function cargaListaUsuarios() {
    $.cookie('USRUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqCorreo").val();
    obj_Parametros_JS[1] = $("#bsqUsuario").val();
    obj_Parametros_JS[2] = $("#bsqEstado").val();
    obj_Parametros_JS[3] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[3] != 0) && (obj_Parametros_JS[3] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmConsultaUsuarios.aspx/CargaListaUsuarios",
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

                        $("#tblUsuarios").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblUsuarios").html(res);
                        paginar("#tblUsuarios");
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

function defineUsuario(uni) {
    $.cookie('USRUNI', uni, { expires: TLTC, path: '/', domain: g_Dominio });

    location.href = "frmMantenimientoUsuarios.aspx";
}

function obtieneDetalleUsuario() {

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/CargaInfoUsuario",
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

                            $("#txtNom").val(arreglo[1]);
                            $("#txtApe1").val(arreglo[2]);
                            $("#txtApe2").val(arreglo[3]);
                            $("#txtEml").val(arreglo[4]);
                            $("#cboSts").val(arreglo[5]);
                            $("#txtPwd").val(arreglo[6]);

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

function mantenimientoUsuario() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $("#txtEml").val();
    obj_Parametros_JS[2] = $("#txtNom").val();
    obj_Parametros_JS[3] = $("#txtApe1").val();
    obj_Parametros_JS[4] = $("#txtApe2").val();
    obj_Parametros_JS[5] = $("#txtPwd").val();
    obj_Parametros_JS[6] = $("#cboSts").val();
    obj_Parametros_JS[7] = $.cookie("GLBUNI");


    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[7] != 0) && (obj_Parametros_JS[7] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/MantenimientoUsuarios",
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
                            location.href = "frmConsultaUsuarios.aspx";
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


function modulosUsuario(id) {
    $.cookie('USRUNI', id, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoModulosXUsuario.aspx"
}

function eliminaUsuario(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoUsuarios.aspx/EliminarUsuarios",
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
                            cargaListaUsuarios();
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