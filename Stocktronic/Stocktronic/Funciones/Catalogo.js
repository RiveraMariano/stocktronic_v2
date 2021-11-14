function AgregarCarrito(idProducto, nombreProducto, idUsuario) {
    $.ajax({
        type: 'GET',
        url: '/Catalogo/InsertarProducto',
        data: { idProducto: idProducto, idUsuario: idUsuario },
        dataType: 'json',
        success: function (data) {
            setTimeout(Swal.fire({
                icon: 'success',
                title: `${nombreProducto} agregado`,
                position: "top-end",
                toast: true,
                showCancelButton: false,
                showConfirmButton: false,
                allowEscapeKey: false,
                allowOutsideClick: false,
                timer: 2000,
            }), 2000);
        }, error: {
            success: function (data) {
                setTimeout(Swal.fire({
                    icon: 'error',
                    title: 'Error al insertar el producto',
                    position: "top-end",
                    toast: true,
                    showCancelButton: false,
                    showConfirmButton: false,
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    timer: 2000,
                }), 2000);
            }
        }
    });
}
