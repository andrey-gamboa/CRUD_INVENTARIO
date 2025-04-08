document.addEventListener("DOMContentLoaded", function () {
    var current = null;

    const inputUsuario = document.querySelector('#txtUsuario');
    const inputPassword = document.querySelector('#txtPassword');
    const submit = document.querySelector('#submit');
    const path = document.querySelector('#animPath');

    if (!path) return; // seguridad por si el path no existe

    if (inputUsuario) {
        inputUsuario.addEventListener('focus', function () {
            if (current) current.pause();
            current = anime({
                targets: '#animPath',
                strokeDashoffset: {
                    value: 0,
                    duration: 700,
                    easing: 'easeOutQuart'
                },
                strokeDasharray: {
                    value: '240 1386',
                    duration: 700,
                    easing: 'easeOutQuart'
                }
            });
        });
    }

    if (inputPassword) {
        inputPassword.addEventListener('focus', function () {
            if (current) current.pause();
            current = anime({
                targets: '#animPath',
                strokeDashoffset: {
                    value: -336,
                    duration: 700,
                    easing: 'easeOutQuart'
                },
                strokeDasharray: {
                    value: '240 1386',
                    duration: 700,
                    easing: 'easeOutQuart'
                }
            });
        });
    }

    if (submit) {
        submit.addEventListener('focus', function () {
            if (current) current.pause();
            current = anime({
                targets: '#animPath',
                strokeDashoffset: {
                    value: -730,
                    duration: 700,
                    easing: 'easeOutQuart'
                },
                strokeDasharray: {
                    value: '530 1386',
                    duration: 700,
                    easing: 'easeOutQuart'
                }
            });
        });
    }
});
