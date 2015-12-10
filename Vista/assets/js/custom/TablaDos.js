//---- TablaDos---------
$(document).ready(function () {
    function TablaDos() {
        this.id = '';
        this.nombre = '';
        this.esActivo = '';
        this.condicion = '';
        this.fechaCreacion = '';
    }
    var tablados = new TablaDos()
    function resetFields() {
        $('#txtId').val('');
        $('#txtNombre').val('');
        $('#txtEsactivo').val('');
        $('#txtCondicion').val('');
        $('#txtFechacreacion').val('');
        $('#txtId').prop('disabled', false);
        $('#txtNombre').prop('disabled', false);
        $('#txtEsactivo').prop('disabled', false);
        $('#txtCondicion').prop('disabled', false);
        $('#txtFechacreacion').prop('disabled', false);
    }
    function disableFields() {
        $('#btnSave').hide();
        $('#txtId').prop('disabled', true);
        $('#txtNombre').prop('disabled', true);
        $('#txtEsactivo').prop('disabled', true);
        $('#txtCondicion').prop('disabled', true);
        $('#txtFechacreacion').prop('disabled', true);
    }
    function enableFields() {
        $('#btnSave').show();
        $('#txtId').prop('disabled', false);
        $('#txtNombre').prop('disabled', false);
        $('#txtEsactivo').prop('disabled', false);
        $('#txtCondicion').prop('disabled', false);
        $('#txtFechacreacion').prop('disabled', false);
    }
    function putFields(tablados) {
        $('#txtId').val(tablados.id);
        $('#txtNombre').val(tablados.nombre);
        $('#txtEsactivo').val(tablados.esActivo);
        $('#txtCondicion').val(tablados.condicion);
        $('#txtFechacreacion').val(tablados.fechaCreacion);
    }
    $('#btnSave').click(function () {
        tablados.id = $('#txtId').val();
        tablados.nombre = $('#txtNombre').val();
        tablados.esActivo = $('#txtEsactivo').val();
        tablados.condicion = $('#txtCondicion').val();
        tablados.fechaCreacion = $('#txtFechacreacion').val();
        var objJson = JSON.stringify(tablados);
        $.ajax({
            type: 'POST',
            dataType: 'json', // Tipo de dato que devuelve el server
            contentType: 'application/json; charset=utf-8', // Tipo de datos que envío (importante!!)
            url: '/TablaDos/save',
            data: objJson
        }).done(function (response) {
            if (response === 'ok') {
                alert('Se guardaron los datos correctamente');
            } else if (response === 'error') {
                alert('Error al realizar la operación');
            } else {
                alert(response);
            }
        }).fail(function (jqXHR, textStatus) {
            alert('Ocurrió un error en el servidor');
        });
    });
    $('#btnNew').click(function () {
        resetFields();
    });
    $('.btnView').click(function () {
        disableFields();
        var idView = $(this).attr('data-view');
        $.ajax({
            type: 'POST',
            url: '/TablaDos/select',
            data: { id: idView, esActivo: true }
        }).done(function (response) {
            if (response instanceof Object) {
                putFields(response);
            } else if (response === 'empty') {
                alert('No existen datos');
            } else if (response == 'error') {
                alert('Error al realizar la operación');
            } else {
                alert(response);
            }
        }).fail(function (jqXHR, textStatus) {
            alert('Ocurrió un error en el servidor');
        });
    });
    $('.btnEdit').click(function () {
        var idView = $(this).attr('data-view');
        $.ajax({
            type: 'POST',
            url: '/TablaDos/select',
            data: { id: idView, esActivo: true }
        }).done(function (response) {
            if (response instanceof Object) {
                putFields(response);
                enableFields(response);
            } else if (response === 'empty') {
                alert('No existen datos');
            } else if (response == 'error') {
                alert('Error al realizar la operación');
            } else {
                alert(response);
            }
        }).fail(function (jqXHR, textStatus) {
            alert('Ocurrió un error en el servidor');
        });
    });
    $('.btnDisable').click(function () {
        var idView = $(this).attr('data-disable');
        $.ajax({
            type: 'POST',
            url: '/TablaDos/disable',
            data: { id: idView }
        }).done(function (response) {
            if (response === 'ok') {
                alert('La operación se realizó correctamente');
            } else if (response == 'error') {
                alert('Error al realizar la operación');
            } else {
                alert(response);
            }
        }).fail(function (jqXHR, textStatus) {
            alert('Ocurrió un error en el servidor');
        });
    });
});
//---- TablaDos---------
