var g_Dominio = "localhost";
var TLTC = 60;

$(document).ready(function () {

    //Evalua la página en la que estoy para determinar si ejecuto la función o no
    var pageName = window.location.pathname.split('/').pop();

    if (pageName !== 'frmInicioSesion.aspx') {
        cargaOpcionesUsuario();
    }

});

function cargaOpcionesUsuario() {
    $("#nombreUsuario").html($.cookie("GLBDSC"));
    $("#emlUsuario").html($.cookie("GLBCOD"));
}

function inicioSesion() {
    var obj_Parametros_JS = new Array();

    obj_Parametros_JS[0] = $("#txtUsuario").val();
    obj_Parametros_JS[1] = $("#txtPassword").val();

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    jQuery.ajax({
        type: "POST",
        url: "frmInicioSesion.aspx/InicioSesionUsuarios",
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
                    $.cookie('GLBUNI', arreglo[0], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie('GLBCOD', arreglo[2], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie('GLBDSC', arreglo[3], { expires: TLTC, path: '/', domain: g_Dominio });

                    Swal.fire({
                        position: 'center-center',
                        icon: 'success',
                        title: 'Inicio de Sesión de Usuario',
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
                    });

                    setTimeout(function () {
                        location.href = "../Mantenimientos/frmPrincipal.aspx";
                    }, 4500);

                }
                else {
                    Swal.fire({
                        position: 'center-center',
                        icon: 'error',
                        title: 'Inicio de Sesión',
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
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

