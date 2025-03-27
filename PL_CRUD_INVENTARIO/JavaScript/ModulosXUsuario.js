var g_Dominio = "localhost";
var TLTC = 60;
$(document).ready(function () {

    cargaListaModulos();

    setTimeout(function () {
        cargaListaModulosXUsuario();
    }, 1500);
})


function cargaListaModulos() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax(
            {
                type: "POST",
                url: "frmMantenimientoModulosXUsuario.aspx/CargaListaModulos",
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {
                    var res = msg.d;

                    if (res === undefined) {
                        Swal.fire({
                            title: "Error en la conexión",
                            text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema",
                            icon: "error"
                        });
                    }
                    else {
                        if (res === "No se encontraron registros") {
                            $("#tblModulosDisponibles").html("");
                            paginar("#tblModulosDisponibles");

                            Swal.fire({
                                title: "Búsqueda de registros",
                                text: res,
                                icon: "info"
                            });
                        }
                        else {
                            $("#tblModulosDisponibles").html(res);
                            paginar("#tblModulosDisponibles");
                        }
                    }
                },
                failure: function (msg) {

                },
                error: function (xhr, err) {

                }


            });

    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: "error",
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true,
        });

        //redireccionar al login
        setTimeout(function () {
            location.href = "/Login/frmLogIn.aspx";
        }, 5000);
    }
}


function cargaListaModulosXUsuario() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax(
            {
                type: "POST",
                url: "frmMantenimientoModulosXUsuario.aspx/CargaListaModulosXUsuario",
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {
                    var res = msg.d;

                    if (res === undefined) {
                        Swal.fire({
                            title: "Error en la conexión",
                            text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema",
                            icon: "error"
                        });
                    }
                    else {
                        if (res === "No se encontraron registros") {
                            $("#tblModulosXUsuario").html("");
                            paginar("#tblModulosXUsuario");

                            Swal.fire({
                                title: "Búsqueda de registros",
                                text: res,
                                icon: "info"
                            });
                        }
                        else {
                            $("#tblModulosXUsuario").html(res);
                            paginar("#tblModulosXUsuario");
                        }
                    }
                },
                failure: function (msg) {

                },
                error: function (xhr, err) {

                }


            });

    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: "error",
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true,
        });

        //redireccionar al login
        setTimeout(function () {
            location.href = "/Login/frmLogIn.aspx";
        }, 5000);
    }
}

function asignaModulosXUsuario(id) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = id;
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {

        jQuery.ajax(
            {
                type: "POST",
                url: "frmMantenimientoModulosXUsuario.aspx/AsignarModulosXUsuario",
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {
                    var res = msg.d;

                    if (res === undefined) {
                        Swal.fire({
                            title: "Error en la conexión",
                            text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema",
                            icon: "error"
                        });
                    }
                    else {

                        var arreglo = new Array();
                        var str;

                        str = res;
                        arreglo = (str.split("<SPLITER>"));

                        var resultado = arreglo[0]

                        if ((resultado != "0") && (resultado != "-1")) {
                            Swal.fire({
                                position: 'center-center',
                                icon: "success",
                                title: "Información de Registros",
                                text: arreglo[1],
                                showConfirmButton: false,
                                timer: 2500,
                                timerProgressBar: true,
                            });

                            setTimeout(function () {
                                cargaListaModulosXUsuario();;
                            }, 3000);

                        }
                        else {

                            cargaListaModulosXUsuario();

                            Swal.fire({
                                title: "Información de registros",
                                text: arreglo[1],
                                icon: "info"
                            });
                        }
                    }
                },
                failure: function (msg) {

                },
                error: function (xhr, err) {

                }


            });

    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: "error",
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true,
        });

        //redireccionar al login
        setTimeout(function () {
            location.href = "/Login/frmLogIn.aspx";
        }, 5000);
    }
}

function eliminaModuloXUsuario(id) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("USRUNI");
    obj_Parametros_JS[1] = id;
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {

        jQuery.ajax(
            {
                type: "POST",
                url: "frmMantenimientoModulosXUsuario.aspx/EliminarModulosXUsuario",
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {
                    var res = msg.d;

                    if (res === undefined) {
                        Swal.fire({
                            title: "Error en la conexión",
                            text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema",
                            icon: "error"
                        });
                    }
                    else {

                        var arreglo = new Array();
                        var str;

                        str = res;
                        arreglo = (str.split("<SPLITER>"));

                        var resultado = arreglo[0]

                        if ((resultado != "0") && (resultado != "-1")) {
                            Swal.fire({
                                position: 'center-center',
                                icon: "success",
                                title: "Información de Registros",
                                text: arreglo[1],
                                showConfirmButton: false,
                                timer: 2500,
                                timerProgressBar: true,
                            });

                            setTimeout(function () {
                                cargaListaModulosXUsuario();
                            }, 3000);

                        }
                        else {

                            cargaListaModulosXUsuario();

                            Swal.fire({
                                title: "Información de registros",
                                text: arreglo[1],
                                icon: "info"
                            });
                        }
                    }
                },
                failure: function (msg) {

                },
                error: function (xhr, err) {

                }


            });

    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: "error",
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true,
        });

        //redireccionar al login
        setTimeout(function () {
            location.href = "/Login/frmLogIn.aspx";
        }, 5000);
    }
}

function regresar() {
    location.href = "frmConsultaUsuarios.aspx";
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
