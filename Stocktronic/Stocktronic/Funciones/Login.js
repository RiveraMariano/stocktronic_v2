function IniciarSesion() {
    let correo = document.getElementById('emailLogin').value;
    let contrasenna = document.getElementById('passwordLogin').value;
    $.ajax({
        type: "GET",
        url: '/Login/IniciarSesion',
        data: { correo: correo, contrasenna: contrasenna },
        success: function (data) {
            setTimeout(Swal.fire({
                icon: 'info',
                title: 'Bienvenido',
                text: 'Iniciando sesión..',
                showCancelButton: false,
                showConfirmButton: false,
                allowEscapeKey: false,
                allowOutsideClick: false,
                timer: 3000,
                // This function works for printing the typical loading spiral
                didOpen: () => {
                    Swal.showLoading()
                    timerInterval = setInterval(() => {
                        const content = Swal.getHtmlContainer()
                        if (content) {
                            const b = content.querySelector('b')
                            if (b) {
                                b.textContent = Swal.getTimerLeft()
                            }
                        }
                    }, 100)
                },
                willClose: () => {
                    clearInterval(timerInterval)
                }
            }), 3000);
            // After 3s the page is redirected to confirmacion.php
            setTimeout(function () {
                window.location = '/Home/Index';
            }, 3000);
        }, error: {
            success: function (data) {
                setTimeout(Swal.fire({
                    icon: 'error',
                    title: 'Hubo un Error',
                    text: 'Usuario o contraseña incorrectos',
                    position: "top-end",
                    toast: true,
                    showCancelButton: false,
                    showConfirmButton: false,
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    timer: 1000,
                }), 1000);
            }
        }
    });
}