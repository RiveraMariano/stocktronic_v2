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

function MostrarDetalles(idOrden) {
    $.ajax({
        type: 'GET',
        url: '/Ordenes/ListarDetallesOrden',
        data: { idOrden: idOrden },
        dataType: 'json',
        success: function (data) {
            var lista = "";
            $.each(data, function (index, value) {
                lista += "<tr class='text-center'><th scope='row'>" + value.ID_DETALLEORDEN + "</th><td>" + value.PRO_NOMBRE +
                    "</td><td>" + value.DET_CANTIDAD + "</td><td>₡" + value.DET_PRECIO + "</td>" + "<td><img src=" + '"' + value.DET_URL_IMAGEN + '"' + "width=50 height=auto /></td>" + "</tr>";
            })
            $("#display_rows").html(lista);
        },
        error: function (data) {
            $("#tAjustes").html('<tr><td colspan="2">Sin Registros</td></tr>');
        }
    });

}