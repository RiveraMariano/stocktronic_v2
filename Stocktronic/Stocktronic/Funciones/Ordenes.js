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