﻿//---- TablaUno---------
$(document).ready(function () {

//    $('input[name="txtFecha"]').daterangepicker({
//        singleDatePicker: true,
//        showDropdowns: true,
//        applyClass: 'bg-slate-600',
//        cancelClass: 'btn-default'
//    },
//function (start, end, label) {
//    var years = moment().diff(start, 'years');
//    alert("You are " + years + " years old.");
//});
    // Accessibility labels
    $('.pickadate-accessibility').pickadate({
        labelMonthNext: 'Go to the next month',
        labelMonthPrev: 'Go to the previous month',
        labelMonthSelect: 'Pick a month from the dropdown',
        labelYearSelect: 'Pick a year from the dropdown',
        selectMonths: true,
        selectYears: true
    });


    function TablaUno() {
        this.id = 0;
        this.nombre = '';
        this.unico = '';
        this.fechaCreacion = '';
        this.fecha = '';
        this.condicion = '';
        this.hora = '';
        this.numero = '';
        this.idTablaDos = '';
        this.TablaDos = new TablaDos();
    }

    function TablaDos() {
        this.id = 0;
        this.nombre = '';
        this.esActivo = '';
        this.condicion = '';
        this.fechaCreacion = '';
    }

    var tablauno = new TablaUno()

    tablaunoTableList();
    tabladosList();
    function save() {
        tablauno.id = $('#txtId').val();
        tablauno.nombre = $('#txtNombre').val();
        tablauno.unico = $('#txtUnico').val();
        tablauno.fechaCreacion = new Date();
        tablauno.fecha = $('#txtFecha').val();
        tablauno.condicion = $('#txtCondicion').val();
        tablauno.hora = $('#txtHora').val();
        tablauno.numero = $('#txtNumero').val();
        tablauno.idTablaDos = $("#ddlTablaDos").val();
        var objJson = JSON.stringify(tablauno);
        $.ajax({
            type: 'POST',
            dataType: 'json', // Tipo de dato que devuelve el server
            contentType: 'application/json; charset=utf-8', // Tipo de datos que envío (importante!!)
            url: '/TablaUno/save',
            data: objJson
        }).done(function (response) {
            if (response === 'ok') {
                $('#modal_theme_success').modal('toggle');
                $.jGrowl('Se guardaron los datos correctamente', {
                    position: 'bottom-right',
                    header: 'Operación exitosa',
                    theme: 'alert-styled-left alert-arrow-left alert-success border-lg'
                });
                resetFields();
                tablaunoTableList();
            } else if (response === 'error') {
                alert('Error al realizar la operación');
            } else {
                alert(response);
            }
        }).fail(function (jqXHR, textStatus) {
            alert('Ocurrió un error en el servidor');
        });
    }
    function resetFields() {

        $('#txtId').val('');
        $('#txtNombre').val('');
        $('#txtUnico').val('');
        $('#txtFechacreacion').val('');
        $('#txtFecha').val('');
        $('#txtCondicion').val('');
        $('#txtHora').val('');
        $('#txtNumero').val('');
        $('#txtIdtablados').val('');
        $('#txtId').prop('disabled', false);
        $('#txtNombre').prop('disabled', false);
        $('#txtUnico').prop('disabled', false);
        $('#txtFechacreacion').prop('disabled', false);
        $('#txtFecha').prop('disabled', false);
        $('#txtCondicion').prop('disabled', false);
        $('#txtHora').prop('disabled', false);
        $('#txtNumero').prop('disabled', false);
        $('#txtIdtablados').prop('disabled', false);
    }
    function disableFields() {
        $('#btnSave').hide();
        $('#reset').hide();
        $('#txtId').prop('disabled', true);
        $('#txtNombre').prop('disabled', true);
        $('#txtUnico').prop('disabled', true);
        $('#txtFechacreacion').prop('disabled', true);
        $('#txtFecha').prop('disabled', true);
        $('#txtCondicion').prop('disabled', true);
        $('#txtHora').prop('disabled', true);
        $('#txtNumero').prop('disabled', true);
        $('#txtIdtablados').prop('disabled', true);
    }
    function enableFields() {
        $('#reset').show();
        $('#btnSave').show();
        $('#txtId').prop('disabled', false);
        $('#txtNombre').prop('disabled', false);
        $('#txtUnico').prop('disabled', false);
        $('#txtFechacreacion').prop('disabled', false);
        $('#txtFecha').prop('disabled', false);
        $('#txtCondicion').prop('disabled', false);
        $('#txtHora').prop('disabled', false);
        $('#txtNumero').prop('disabled', false);
        $('#txtIdtablados').prop('disabled', false);
    }
    function putFields(tablauno) {
        $('#txtId').val(tablauno.id);
        $('#txtNombre').val(tablauno.nombre);
        $('#txtUnico').val(tablauno.unico);
        $('#txtFechacreacion').val(tablauno.fechaCreacion);
        $('#txtFecha').val(tablauno.fecha);
        $('#txtCondicion').val(tablauno.condicion);
        $('#txtHora').val(tablauno.hora);
        $('#txtNumero').val(tablauno.numero);
        $('#txtIdtablados').val(tablauno.idTablaDos);
        $('#modal_theme_success').modal('toggle');
    }

    $('#btnSave').click(function () {
        var validator = $("#frmGuardar").validate();
        if (validator.form() == true) {
            save();
        }
    });

    $('#btnNew').click(function () {
        resetFields();
        enableFields();
    });

    $("#tblTablaUno").on("click", "tbody>tr>td>ul>li>ul>li>a.btnView", function () {
        disableFields();
        var idView = $(this).attr('data-view');
        $.ajax({
            type: 'POST',
            url: '/TablaUno/select',
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
    $("#tblTablaUno").on("click", "tbody>tr>td>ul>li>ul>li>a.btnEdit", function () {
        var idView = $(this).attr('data-view');
        $.ajax({
            type: 'POST',
            url: '/TablaUno/select',
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
    $("#tblTablaUno").on("click", "tbody>tr>td>ul>li>ul>li>a.btnDisable", function () {
        var idView = $(this).attr('data-view');
        console.log(idView);
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#EF5350",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel pls!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
       function (isConfirm) {
           if (isConfirm) {
               $.ajax({
                   type: 'POST',
                   url: '/TablaUno/disable',
                   data: { id: idView }
               }).done(function (response) {
                   if (response === 'ok') {
                       swal({
                           title: "Deleted!",
                           text: "Your imaginary file has been deleted.",
                           confirmButtonColor: "#66BB6A",
                           type: "success"
                       });
                       tablaunoTableList();
                   } else if (response == 'error') {
                       alert('Error al realizar la operación');
                   } else {
                       alert(response);
                   }
               }).fail(function (jqXHR, textStatus) {
                   alert('Ocurrió un error en el servidor');
               });

           }
           else {
               swal({
                   title: "Cancelled",
                   text: "Your imaginary file is safe :)",
                   confirmButtonColor: "#2196F3",
                   type: "error"
               });
           }
       });


    });

});

//---- TablaUnoList---------
function tablaunoTableList() {
    var html = '';
    html += "<thead>";
    html += "<tr>";
    html += "<th>Nombre</th>";
    html += "<th>Unico</th>";
    html += "<th>Fecha Creacion</th>";
    html += "<th>Fecha</th>";
    html += "<th>Condicion</th>";
    html += "<th>Hora</th>";
    html += "<th>Numero</th>";
    html += "<th>Tabla Dos</th>";
    html += "<th>Acción</th>";
    html += "</tr>";
    html += "</thead>";
    $.ajax({
        type: 'POST',
        url: '/TablaUno/selectAllbyActivo',
        data: { esActivo: true }
    }).done(function (response) {
        if (response instanceof Object) {
            html += "<tbody>";
            for (var i = 0; i < response.length; i++) {
                var tablauno = response[i];
                html += "<tr>";
                html += "<td>" + tablauno.nombre + "</td>";
                html += "<td>" + tablauno.unico + "</td>";
                html += "<td>" + tablauno.nombre + "</td>";
                html += "<td>" + tablauno.nombre + "</td>";
                html += "<td>" + tablauno.condicion + "</td>";
                html += "<td>" + tablauno.nombre + "</td>";
                html += "<td>" + tablauno.numero + "</td>";
                html += "<td>" + tablauno.idTablaDos + "</td>";
                html += "<td class='text-center'>";
                html += "<ul class='icons-list'>";
                html += "<li class='dropdown'>";
                html += "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>";
                html += "<i class='icon-menu9'></i>";
                html += "</a>";
                html += "<ul class='dropdown-menu dropdown-menu-right'>";
                html += "<li><a class='btnView' data-view=" + tablauno.id + " ><i class=' icon-search4'></i> Ver </a></li>";
                html += "<li><a class='btnEdit' data-view=" + tablauno.id + "><i class='icon-pencil5'></i> Editar </a></li>";
                html += "<li><a class='btnDisable' data-view=" + tablauno.id + "><i class='icon-trash'></i> Eliminar </a></li>";
                html += "</ul>";
                html += "</li>";
                html += "</ul>";
                html += "</td>";
                html += "</tr>";
            }
            html += "</tbody>";
            $("#tblTablaUno").html(html);
        } else if (response === 'empty') {
            html += "<tbody>";
            html += "<tr>";
            html += "<td>No hay datos</td>";
            html += "</tr>";
            html += "</tbody>";
            $("#tblTablaUno").html(html);
            console.log('La consulta es vacia');
        } else if (response == 'error') {
            html += "<tbody>";
            html += "<tr>";
            html += "<td>No hay datos</td>";
            html += "</tr>";
            html += "</tbody>";
            $("#tblTablaUno").html(html);
            console.log('Error al realizar la operación');
        } else {
            html += "<tbody>";
            html += "<tr>";
            html += "<td>No hay datos</td>";
            html += "</tr>";
            html += "</tbody>";
            $("#tblTablaUno").html(html);
            console.log(response);
        }
    }).fail(function (jqXHR, textStatus) {
        alert('Ocurrió un error en el servidor');
    });
}
//---- TablaUnoList---------