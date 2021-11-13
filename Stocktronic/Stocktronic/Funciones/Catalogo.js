function AgregarCarrito(idProducto, nombreProducto) {
    $.ajax({
        type: 'GET',
        url: '/Catalogo/InsertarProducto',
        data: { idProducto: idProducto },
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

//// This function will reduce the product quantity
//$(".btnMinus").click(function () {
//    var cantidad = $(this).attr("data-filter");
//    if (cantidad == 1) {
//        Swal.fire({
//            icon: 'error',
//            title: 'Oops...',
//            text: 'No se puede reducir la cantidad',
//            confirmButtonText: `Aceptar`
//        });
//    } else {
//        var id = $(this).attr("data-id");
//        $.ajax({
//            type: "GET",
//            url: "../pages/carritoSP/updateCarrito.php",
//            data: {
//                idCarrito: id,
//                cantidad: -1
//            },
//            success: function (data) {
//                setTimeout(function () { location.reload(); }, 700);
//            },
//        });
//    }
//});

//// This function will increase the product quantity
//$(".btnPlus").click(function () {
//    var cantidad = $(this).attr("data-filter");
//    if (cantidad == 5) {
//        Swal.fire({
//            icon: 'error',
//            title: 'Oops...',
//            text: 'Límite de productos alcanzado!',
//            confirmButtonText: `Aceptar`
//        });
//    } else {
//        var id = $(this).attr("data-id");
//        $.ajax({
//            type: "GET",
//            url: "../pages/carritoSP/updateCarrito.php",
//            data: {
//                idCarrito: id,
//                cantidad: 1
//            },
//            success: function (data) {
//                setTimeout(function () { location.reload(); }, 700);
//            },
//        });
//    }
//});

//// This function will call an alert for the user
//$(".btnDelete").click(function () {
//    Swal.fire({
//        icon: 'warning',
//        title: 'Atención',
//        text: 'Desea eliminar el producto?',
//        showCancelButton: true,
//        confirmButtonColor: '#DC143C',
//        confirmButtonText: `Eliminar`,
//        cancelButtonText: 'Cancelar',
//    }).then((result) => {
//        // If the user confirm the action, then the product is deleted
//        if (result.isConfirmed) {
//            var id = $(this).attr("data-id");
//            $.ajax({
//                type: "GET",
//                url: "../pages/carritoSP/deleteCarrito.php",
//                data: {
//                    idCarrito: id
//                },
//                success: function (data) {
//                    setTimeout(Swal.fire({
//                        icon: 'error',
//                        title: 'Eliminando Producto',
//                        showCancelButton: false,
//                        showConfirmButton: false,
//                        allowEscapeKey: false,
//                        allowOutsideClick: false,
//                        timer: 1000,
//                        // This function works for printing the typical loading spiral
//                        didOpen: () => {
//                            Swal.showLoading()
//                            timerInterval = setInterval(() => {
//                                const content = Swal.getHtmlContainer()
//                                if (content) {
//                                    const b = content.querySelector('b')
//                                    if (b) {
//                                        b.textContent = Swal.getTimerLeft()
//                                    }
//                                }
//                            }, 100)
//                        },
//                        willClose: () => {
//                            clearInterval(timerInterval)
//                        }
//                    }), 1000);
//                    setTimeout(function () { location.reload(); }, 1000);
//                },
//            });
//        }
//    });
//});
