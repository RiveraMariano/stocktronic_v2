$(document).ready(function () {
    $('#tblHistorial').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf', 'print'
        ],
        language: {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar:",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            },
            "buttons": {
                "copy": "Copiar",
                "colvis": "Visibilidad"
            }
        }
    }
    );
});

function DisableBackButton() {
    window.history.forward()
}
DisableBackButton();
window.onload = DisableBackButton;
window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
window.onunload = function () { void (0) }


const idVal = document.getElementById('idVal');
let idProducto = document.getElementById('idProducto');
const nomVal = document.getElementById('nomVal');
let inputNombre = document.getElementById('nombre');
const descVal = document.getElementById('descVal');
let inputDescripcion = document.getElementById('desc');
const urlVal = document.getElementById('urlVal');
let inputImagen = document.getElementById('url');
const precioVal = document.getElementById('precioVal');
let inputPrecio = document.getElementById('precio');
const cantVal = document.getElementById('cantVal');
let inputCantidad = document.getElementById('cant');
let selectProveedor = document.getElementById('selectProveedor');
let selectCategoria = document.getElementById('selectCategoria');

const reparacionNom = nomVal.innerText;
const reparacionDesc = descVal.innerText;
const reparacionUrl = urlVal.innerText;
const reparacionPrecio = precioVal.innerText;
const reparacionCant = cantVal.innerText;


inputNombre.addEventListener('change', getValueNombre);
inputDescripcion.addEventListener('change', getValueDescripcion);
inputImagen.addEventListener('change', getValueImagen);
inputPrecio.addEventListener('change', getValuePrecio);
inputCantidad.addEventListener('change', getValueCantidad);

$(document).ready(function () {
    $('#btnInsert').attr('disabled', true);
    let regexURL = /^(https?|http):\/\/[^\s$.?#].[^\s]*$/;
    $('input').keyup(function () {
        if (
            inputNombre.value.trim().length >= 5 &&
            inputDescripcion.value.trim().length >= 10 &&
            inputImagen.value.trim().length >= 20 &&
            inputPrecio.value.trim().length >= 0 &&
            inputCantidad.value.trim().length >= 0
        ) {
            $('#btnInsert').attr('disabled', false);
        } else {
            $('#btnInsert').attr('disabled', true);
        }
    });
});

function getValueNombre(e) {
    if (e.target.value.trim() == 0) {
        nomVal.innerText = reparacionNom;
        let validacion = ' Obligatorio (*)';
        nomVal.innerText += validacion;
        nomVal.style.color = 'RED';
    } else if (e.target.value.trim() != 0) {
        nomVal.innerText = reparacionNom;
        nomVal.style.color = 'GREY';
        let noStartWS = e.target.value.trimStart();
        let withoutWS = noStartWS.replace(/  +/g, ' ');
        inputNombre.value = withoutWS;

        // If there isn't 16 caracteres print a message into the label
        if (inputNombre.value.length < 2) {
            nomVal.innerText = reparacionNom;
            let validacion = ' Mínimo 2 Caracteres (*)';
            nomVal.innerText += validacion;
            nomVal.style.color = 'RED';
        } else {
            nomVal.innerText = reparacionNom;
            let validacion = ' Válido';
            nomVal.innerText += validacion;
            nomVal.style.color = 'GREEN';
        }
    }
}
function getValueDescripcion(e) {
    if (e.target.value.trim() == 0) {
        descVal.innerText = reparacionDesc;
        let validacion = ' Obligatorio (*)';
        descVal.innerText += validacion;
        descVal.style.color = 'RED';
    } else if (e.target.value.trim() != 0) {
        descVal.innerText = reparacionDesc;
        descVal.style.color = 'GREY';
        let noStartWS = e.target.value.trimStart();
        let withoutWS = noStartWS.replace(/  +/g, ' ');
        inputDescripcion.value = withoutWS;

        // If there isn't 16 caracteres print a message into the label
        if (inputDescripcion.value.length < 2) {
            descVal.innerText = reparacionDesc;
            let validacion = ' Mínimo 2 Caracteres (*)';
            descVal.innerText += validacion;
            descVal.style.color = 'RED';
        } else {
            descVal.innerText = reparacionDesc;
            let validacion = ' Válido';
            descVal.innerText += validacion;
            descVal.style.color = 'GREEN';
        }
    }
}
function getValueImagen(e) {
    if (e.target.value.trim() == 0) {
        urlVal.innerText = reparacionUrl;
        let validacion = ' Obligatorio (*)';
        urlVal.innerText += validacion;
        urlVal.style.color = 'RED';
    } else if (e.target.value.trim() != 0) {
        urlVal.innerText = reparacionUrl;
        urlVal.style.color = 'GREY';
        let noStartWS = e.target.value.trimStart();
        let withoutWS = noStartWS.replace(/  +/g, ' ');
        inputImagen.value = withoutWS;

        // If there isn't 16 caracteres print a message into the label
        if (inputImagen.value.length < 2) {
            urlVal.innerText = reparacionUrl;
            let validacion = ' Mínimo 2 Caracteres (*)';
            urlVal.innerText += validacion;
            urlVal.style.color = 'RED';
        } else {
            urlVal.innerText = reparacionUrl;
            let validacion = ' Válido';
            urlVal.innerText += validacion;
            urlVal.style.color = 'GREEN';
        }
    }
}
function getValuePrecio(e) {
    if (e.target.value.trim() == 0) {
        precioVal.innerText = reparacionPrecio;
        let validacion = ' Obligatorio (*)';
        precioVal.innerText += validacion;
        precioVal.style.color = 'RED';
    } else if (e.target.value.trim() != 0) {
        precioVal.innerText = reparacionPrecio;
        precioVal.style.color = 'GREY';
        let noStartWS = e.target.value.trimStart();
        let withoutWS = noStartWS.replace(/  +/g, ' ');
        inputPrecio.value = withoutWS;

        // If there isn't 16 caracteres print a message into the label
        if (inputPrecio.value.length < 0) {
            precioVal.innerText = reparacionPrecio;
            let validacion = ' Precio debe ser mayor o igual a cero (*)';
            precioVal.innerText += validacion;
            precioVal.style.color = 'RED';
        } else {
            precioVal.innerText = reparacionPrecio;
            let validacion = ' Válida';
            precioVal.innerText += validacion;
            precioVal.style.color = 'GREEN';
        }
    }
}
function getValueCantidad(e) {
    if (e.target.value.trim() == 0) {
        cantVal.innerText = reparacionCant;
        let validacion = ' Obligatorio (*)';
        cantVal.innerText += validacion;
        cantVal.style.color = 'RED';
    } else if (e.target.value.trim() != 0) {
        cantVal.innerText = reparacionCant;
        cantVal.style.color = 'GREY';
        let noStartWS = e.target.value.trimStart();
        let withoutWS = noStartWS.replace(/  +/g, ' ');
        inputPassword.value = withoutWS;

        // If there isn't 16 caracteres print a message into the label
        if (inputCantidad.value.length < 8) {
            cantVal.innerText = reparacionCant;
            let validacion = ' Cantidad debe ser mayor o igual a cero (*)';
            cantVal.innerText += validacion;
            cantVal.style.color = 'RED';
        } else {
            cantVal.innerText = reparacionCant;
            let validacion = ' Válida';
            cantVal.innerText += validacion;
            cantVal.style.color = 'GREEN';
        }
    }
}


function ActualizarProducto() {
    $.ajax({
        type: 'GET',
        url: '/Productos/ActualizarProducto',
        data: {
            idProducto: idProducto.value,
            nombre: inputNombre.value,
            descripcion: inputDescripcion.value,
            imagen: inputImagen.value,
            precio: inputPrecio.value,
            cantidad: inputCantidad.value,
            idProveedor: $("#selectProveedor").val(),
            idCategoria: $("#selectCategoria").val(),
        },
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Atención!',
                text: 'Producto actualizado correctamente.',
                confirmButtonText: 'Aceptar',
            }).then(resultado => {
                if (resultado.value) {
                    // Hicieron click en "Aceptar"
                    window.location.href = "/Productos/Index";
                } else {
                                      
                }
            });
        },
    });
}

function InsertarProducto() {
    $.ajax({
        type: 'GET',
        url: '/Productos/InsertarProducto',
        data: {
            nombre: inputNombre.value,
            descripcion: inputDescripcion.value,
            imagen: inputImagen.value,
            precio: inputPrecio.value,
            cantidad: inputCantidad.value,
            idProveedor: $("#selectProveedor").val(),
            idCategoria: $("#selectCategoria").val(),
        },
        success: function (data) {
            setTimeout(
                Swal.fire({
                    icon: 'success',
                    title: 'Registrando producto',
                    text: 'Redirigiendo... espere unos segundos.',
                    showCancelButton: false,
                    showConfirmButton: false,
                    allowEscapeKey: false,
                    allowOutsideClick: false,
                    timer: 3000,
                    didOpen: () => {
                        Swal.showLoading();
                        timerInterval = setInterval(() => {
                            const content = Swal.getHtmlContainer();
                            if (content) {
                                const b = content.querySelector('b');
                                if (b) {
                                    b.textContent = Swal.getTimerLeft();
                                }
                            }
                        }, 100);
                    },
                    willClose: () => {
                        clearInterval(timerInterval);
                    },
                }),
                3000
            );
            setTimeout(function () {
                window.location = '/Productos/Index';
            }, 3000);
        },
    });
}


function EliminarProducto(idProducto) {
    // First calls a pop-up message
    Swal.fire({
        icon: 'warning',
        title: 'Atención',
        text: '¿Desea eliminar producto?',
        showCancelButton: true,
        confirmButtonColor: '#DC143C',
        confirmButtonText: `Eliminar`,
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        // If the user confirm the action, then it calls an AJAX
        if (result.isConfirmed) {
            // Start the AJAX
            $.ajax({
                type: 'GET',
                url: '/Productos/EliminarProducto',
                data: {
                    idProducto: idProducto,
                },
                // If it succeded it sends a pop-up to the user
                success: function (data) {
                    setTimeout(
                        Swal.fire({
                            icon: 'info',
                            title: 'Producto Eliminado Correctamente',
                            text: 'Redirigiendo... espere unos segundos.',
                            showCancelButton: false,
                            showConfirmButton: false,
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            timer: 3000,
                            didOpen: () => {
                                Swal.showLoading();
                                timerInterval = setInterval(() => {
                                    const content = Swal.getHtmlContainer();
                                    if (content) {
                                        const b = content.querySelector('b');
                                        if (b) {
                                            b.textContent = Swal.getTimerLeft();
                                        }
                                    }
                                }, 100);
                            },
                            willClose: () => {
                                clearInterval(timerInterval);
                            },
                        }),
                        3000
                    );
                    // Afther 3s the page will reload itsealf
                    setTimeout(function () {
                        window.location = '/Productos/Index';
                    }, 3000);
                },
                error: function (data) {
                    Swal.fire({
                        icon: 'info',
                        title: 'Atención!',
                        text: 'No se puede eliminar el producto por que tiene ordenes o pedidos registrados.',
                        confirmButtonText: 'Aceptar',
                    })
                }
            });
        }
    });
}