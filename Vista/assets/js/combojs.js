//---- TablaDosList---------
function tabladosList() {
    var html = '';
    html += "<option value=''>-- Seleccione --</option>";
    $.ajax({
        type: 'POST',
        url: '/TablaDos/selectAll',
        data: { esActivo: true }
    }).done(function (response) {
        if (response instanceof Object) {
            for (var i = 0; i < response.length; i++) {
                var tablados = response[i];
                html += "<option value='" + tablados.id + "'>"
                + tablados.id + "</option>";
            }
            $("#ddlTablaDos").html(html);
        } else if (response === 'empty') {
            html += "<option value=''>No existen datos</option>";
        } else if (response == 'error') {
            html += "<option value=''>No existen datos</option>";
            console.log('Error al realizar la operación');
        } else {
            html += "<option value=''>No existen datos</option>";
            console.log(response);
        }
    }).fail(function (jqXHR, textStatus) {
        alert('Ocurrió un error en el servidor');
    });
}
//---- TablaDosList---------
//---- TablaUnoList---------
function tablaunoDdlList() {
    var html = '';
    html += "<option value=''>-- Seleccione --</option>";
    $.ajax({
        type: 'POST',
        url: '/TablaUno/selectAll',
        data: { esActivo: true }
    }).done(function (response) {
        if (response instanceof Object) {
            for (var i = 0; i < response.length; i++) {
                var tablauno = response[i];
                html += "<option value='" + tablauno.id + "'>"
                + tablauno.id + "</option>";
            }
            $("#ddlTablaUno").html(html);
        } else if (response === 'empty') {
            html += "<option value=''>No existen datos</option>";
        } else if (response == 'error') {
            html += "<option value=''>No existen datos</option>";
            console.log('Error al realizar la operación');
        } else {
            html += "<option value=''>No existen datos</option>";
            console.log(response);
        }
    }).fail(function (jqXHR, textStatus) {
        alert('Ocurrió un error en el servidor');
    });
}
//---- TablaUnoList---------
