function ReducirCantidad(idCarrito, cantidad) {
    if (cantidad === 1) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No se puede reducir la cantidad',
            confirmButtonText: `Aceptar`
        });
    } else {
        $.ajax({
            type: 'GET',
            url: '/Carrito/ReducirCantidad',
            data: { idCarrito: idCarrito },
            dataType: 'json',
            success: function (data) {
                setTimeout(Swal.fire({
                    icon: 'info',
                    title: 'Hubo un Cambio',
                    text: `Cantidad reducida`,
                    showCancelButton: false,
                    showConfirmButton: false,
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    timer: 1000,
                }), 1000);
                setTimeout(function () { location.reload(); }, 1000);
            }, error: {
                success: function (data) {
                    setTimeout(Swal.fire({
                        icon: 'error',
                        title: 'Error al reducir la cantidad',
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
}

function AumentarCantidad(idCarrito, cantidad) {
    if (cantidad === 5) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No se puede aumentar la cantidad',
            confirmButtonText: `Aceptar`
        });
    } else {
        $.ajax({
            type: 'GET',
            url: '/Carrito/AumentarCantidad',
            data: { idCarrito: idCarrito },
            dataType: 'json',
            success: function (data) {
                setTimeout(Swal.fire({
                    icon: 'info',
                    title: 'Hubo un Cambio',
                    text: `Cantidad aumentada`,
                    showCancelButton: false,
                    showConfirmButton: false,
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    timer: 1000,
                }), 1000);
                setTimeout(function () { location.reload(); }, 1000);
            }, error: {
                success: function (data) {
                    setTimeout(Swal.fire({
                        icon: 'error',
                        title: 'Error al aumentar la cantidad',
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
}

function EliminarProducto(idCarrito) {
    $.ajax({
        type: 'GET',
        url: '/Carrito/EliminarProducto',
        data: { idCarrito: idCarrito },
        dataType: 'json',
        success: function (data) {
            setTimeout(Swal.fire({
                icon: 'error',
                title: 'Eliminando Producto',
                text: `Espere unos segundos..`,
                showCancelButton: false,
                showConfirmButton: false,
                allowEscapeKey: false,
                allowOutsideClick: false,
                timer: 1000,
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
            }), 1000);
            setTimeout(function () { location.reload(); }, 1000);
        }, error: {
            success: function (data) {
                setTimeout(Swal.fire({
                    icon: 'error',
                    title: 'Error al eliminar el producto',
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
