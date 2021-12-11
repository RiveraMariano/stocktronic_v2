function RegistrarUsuario() {
    let nombre = document.getElementById('name').value;
    let apellido1 = document.getElementById('lastName1').value;
    let apellido2 = document.getElementById('lastName2').value;
    let correo = document.getElementById('email').value;
    let contrasenna = document.getElementById('password').value;
    $.ajax({
        type: "GET",
        url: '/Login/RegistrarUsuario',
        data: {
            nombre: nombre,
            apellido1: apellido1,
            apellido2: apellido2,
            correo: correo,
            contrasenna: contrasenna,
        },
        success: function (data) {
            setTimeout(Swal.fire({
                icon: 'info',
                title: 'Bienvenido',
                text: 'Ingresando..',
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
                    text: 'Error al registrar usuario',
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